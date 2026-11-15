using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
	public partial class UserManagementForm : Form
	{
		private readonly int administratorUserId;

		public UserManagementForm(int administratorUserId)
		{
			InitializeComponent();
			this.administratorUserId = administratorUserId;
			LoadAccounts();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadAccounts();
		}

		private void btnActivate_Click(object sender, EventArgs e)
		{
			ChangeSelectedAccountStatus(true);
		}

		private void btnDeactivate_Click(object sender, EventArgs e)
		{
			ChangeSelectedAccountStatus(false);
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LoadAccounts()
		{
			try
			{
				using var connection = DatabaseHelper.GetConnection();
				connection.Open();
				const string sql = @"
					SELECT id AS `User ID`,
						full_name AS `Full Name`,
						rfid_uid AS `RFID UID`,
						role AS `Role`,
						CASE WHEN is_active THEN 'Active' ELSE 'Inactive' END AS `Account Status`
					FROM users
					ORDER BY id";
				using var command = new MySqlCommand(sql, connection);
				using var adapter = new MySqlDataAdapter(command);
				var accounts = new DataTable();
				adapter.Fill(accounts);
				dgvUsers.DataSource = accounts;
			}
			catch (MySqlException)
			{
				MessageBox.Show(this,
					"User accounts could not be loaded because of a database error. Please try again.",
					"Unable to Load Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception)
			{
				MessageBox.Show(this,
					"User accounts could not be loaded. Please try again.",
					"Unable to Load Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ChangeSelectedAccountStatus(bool isActive)
		{
			if (dgvUsers.SelectedRows.Count == 0)
			{
				MessageBox.Show(this, "Select an account first.", "No Account Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var selectedRow = dgvUsers.SelectedRows[0];
			if (!int.TryParse(Convert.ToString(selectedRow.Cells["User ID"].Value), out int selectedUserId))
			{
				MessageBox.Show(this, "The selected account could not be identified. Refresh the account list and try again.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string role = Convert.ToString(selectedRow.Cells["Role"].Value) ?? string.Empty;
			if (!string.Equals(role, "user", StringComparison.Ordinal))
			{
				MessageBox.Show(this, "Only standard user accounts can be activated or deactivated.", "Account Not Eligible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (selectedUserId == administratorUserId)
			{
				MessageBox.Show(this, "You cannot change your own account status.", "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string accountName = Convert.ToString(selectedRow.Cells["Full Name"].Value) ?? "the selected account";
			string action = isActive ? "activate" : "deactivate";
			string actionTitle = isActive ? "Activate" : "Deactivate";
			var confirmation = MessageBox.Show(this,
				$"Are you sure you want to {action} the account for {accountName}?",
				$"Confirm {actionTitle} Account",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if (confirmation != DialogResult.Yes)
				return;

			try
			{
				using var connection = DatabaseHelper.GetConnection();
				connection.Open();
				using var transaction = connection.BeginTransaction();

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
						"This action is not allowed because your administrator account is no longer active or authorized.",
						"Administrator Authorization Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				const string accountSql = @"
					SELECT role, is_active
					FROM users
					WHERE id = @userId
					FOR UPDATE";
				string currentRole;
				bool currentStatus;
				bool accountExists;
				using (var accountCommand = new MySqlCommand(accountSql, connection, transaction))
				{
					accountCommand.Parameters.AddWithValue("@userId", selectedUserId);
					using var reader = accountCommand.ExecuteReader();
					accountExists = reader.Read();
					if (accountExists)
					{
						currentRole = Convert.ToString(reader["role"]) ?? string.Empty;
						currentStatus = reader["is_active"] is not DBNull && Convert.ToBoolean(reader["is_active"]);
					}
					else
					{
						currentRole = string.Empty;
						currentStatus = false;
					}
				}

				if (!accountExists)
				{
					transaction.Rollback();
					MessageBox.Show(this, "The selected account no longer exists. Refresh the account list and try again.", "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (!string.Equals(currentRole, "user", StringComparison.Ordinal) || selectedUserId == administratorUserId)
				{
					transaction.Rollback();
					MessageBox.Show(this, "Only standard user accounts other than your own can be changed. Refresh the account list and try again.", "Account Not Eligible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (currentStatus == isActive)
				{
					transaction.Rollback();
					MessageBox.Show(this, $"The selected account is already {(isActive ? "Active" : "Inactive")}.", "No Change Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadAccounts();
					return;
				}

				const string updateSql = @"
					UPDATE users
					SET is_active = @isActive
					WHERE id = @userId AND BINARY role = BINARY 'user'";
				using (var updateCommand = new MySqlCommand(updateSql, connection, transaction))
				{
					updateCommand.Parameters.AddWithValue("@isActive", isActive);
					updateCommand.Parameters.AddWithValue("@userId", selectedUserId);
					if (updateCommand.ExecuteNonQuery() != 1)
					{
						transaction.Rollback();
						MessageBox.Show(this, "The account status was not changed. Refresh the account list and try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}

				SystemActivityLogger.Log(
					connection,
					administratorUserId,
					isActive ? "USER_ACTIVATED" : "USER_DEACTIVATED",
					selectedUserId,
					$"{(isActive ? "Activated" : "Deactivated")} user account for {accountName}.",
					transaction);
				transaction.Commit();
				MessageBox.Show(this, $"The account was {(isActive ? "activated" : "deactivated")} successfully.", "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadAccounts();
			}
			catch (MySqlException)
			{
				MessageBox.Show(this,
					"The account status could not be changed because of a database error. Please try again.",
					"Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception)
			{
				MessageBox.Show(this,
					"The account status could not be changed. Please try again.",
					"Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
