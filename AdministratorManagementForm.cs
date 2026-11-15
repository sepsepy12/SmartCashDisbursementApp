using System;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
	public partial class AdministratorManagementForm : Form
	{
		private readonly int administratorUserId;

		public AdministratorManagementForm(int administratorUserId)
		{
			InitializeComponent();
			this.administratorUserId = administratorUserId;
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			try
			{
				using var connection = DatabaseHelper.GetConnection();
				connection.Open();
				using var transaction = connection.BeginTransaction();

				try
				{
					const string administratorSql = @"
						SELECT role, is_active
						FROM users
						WHERE id = @administratorUserId
						FOR UPDATE";
					bool isAuthorizedAdministrator;
					using (var administratorCommand = new MySqlCommand(administratorSql, connection, transaction))
					{
						administratorCommand.Parameters.AddWithValue("@administratorUserId", administratorUserId);
						using var reader = administratorCommand.ExecuteReader();
						isAuthorizedAdministrator = reader.Read() &&
							string.Equals(Convert.ToString(reader["role"]), "admin", StringComparison.Ordinal) &&
							reader["is_active"] is not DBNull &&
							Convert.ToBoolean(reader["is_active"]);
					}

					if (!isAuthorizedAdministrator)
					{
						transaction.Rollback();
						MessageBox.Show(this,
							"Administrator registration is not allowed because your account is no longer active or authorized.",
							"Administrator Authorization Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					string fullName = txtFullName.Text.Trim();
					string enteredUid = txtRfidUid.Text.Trim();
					string rfidUid = string.Concat(enteredUid.Where(character => !char.IsWhiteSpace(character)))
						.ToUpperInvariant();
					string pin = txtPin.Text.Trim();
					string confirmPin = txtConfirmPin.Text.Trim();

					if (string.IsNullOrWhiteSpace(fullName) ||
						string.IsNullOrWhiteSpace(enteredUid) ||
						string.IsNullOrWhiteSpace(pin) ||
						string.IsNullOrWhiteSpace(confirmPin))
					{
						transaction.Rollback();
						MessageBox.Show(this, "Please complete all fields.", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					if (fullName.Length > 50)
					{
						transaction.Rollback();
						MessageBox.Show(this, "Full name must not exceed 50 characters.", "Invalid Full Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtFullName.Focus();
						return;
					}

					if (rfidUid.Length == 0 || rfidUid.Length > 50 || rfidUid.Length % 2 != 0 || !rfidUid.All(Uri.IsHexDigit))
					{
						transaction.Rollback();
						MessageBox.Show(this,
							"RFID UID must be an even-length hexadecimal string no longer than 50 characters.",
							"Invalid RFID UID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtRfidUid.Focus();
						return;
					}

					if (!string.Equals(pin, confirmPin, StringComparison.Ordinal))
					{
						transaction.Rollback();
						MessageBox.Show(this, "PIN and Confirm PIN do not match.", "PIN Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtConfirmPin.Focus();
						return;
					}

					const string duplicateSql = "SELECT id FROM users WHERE rfid_uid = @rfidUid LIMIT 1";
					using (var duplicateCommand = new MySqlCommand(duplicateSql, connection, transaction))
					{
						duplicateCommand.Parameters.AddWithValue("@rfidUid", rfidUid);
						if (duplicateCommand.ExecuteScalar() is not null)
						{
							transaction.Rollback();
							MessageBox.Show(this, "That RFID UID is already registered.", "Duplicate RFID UID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							txtRfidUid.Focus();
							return;
						}
					}

					string passwordHash = BCrypt.Net.BCrypt.HashPassword(pin);
					int registeredAdministratorId;
					const string insertSql = @"
						INSERT INTO users (rfid_uid, password_hash, full_name, role, is_active)
						VALUES (@rfidUid, @passwordHash, @fullName, 'admin', TRUE)";
					using (var insertCommand = new MySqlCommand(insertSql, connection, transaction))
					{
						insertCommand.Parameters.AddWithValue("@rfidUid", rfidUid);
						insertCommand.Parameters.AddWithValue("@passwordHash", passwordHash);
						insertCommand.Parameters.AddWithValue("@fullName", fullName);
						if (insertCommand.ExecuteNonQuery() != 1)
							throw new InvalidOperationException("The administrator account could not be inserted.");
						registeredAdministratorId = checked((int)insertCommand.LastInsertedId);
					}

					SystemActivityLogger.Log(connection, administratorUserId, "ADMIN_REGISTERED", registeredAdministratorId,
						$"Registered administrator account for {fullName}.", transaction);
					transaction.Commit();
				}
				catch
				{
					try
					{
						transaction.Rollback();
					}
					catch
					{
					}

					throw;
				}

				MessageBox.Show(this, "The administrator account was registered successfully.", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
				ClearRegistrationFields();
			}
			catch (MySqlException exception) when (exception.Number == 1062)
			{
				MessageBox.Show(this, "That RFID UID is already registered.", "Duplicate RFID UID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtRfidUid.Focus();
			}
			catch (MySqlException)
			{
				MessageBox.Show(this, "The administrator account could not be registered because of a database error. Please try again.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception)
			{
				MessageBox.Show(this, "The administrator account could not be registered. Please try again.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			ClearRegistrationFields();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ClearRegistrationFields()
		{
			txtFullName.Clear();
			txtRfidUid.Clear();
			txtPin.Clear();
			txtConfirmPin.Clear();
			txtFullName.Focus();
		}
	}
}
