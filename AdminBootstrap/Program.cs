using System.Text;
using MySql.Data.MySqlClient;
using SmartCashDisbursementApp;

namespace AdminBootstrap;

internal static class Program
{
	private const string ProvisioningLockName = "smart_cash_db:initial_admin_provisioning:v1";
	private const int LockTimeoutSeconds = 15;

	private static int Main()
	{
		Console.Write("Administrator full name: ");
		string fullName = (Console.ReadLine() ?? string.Empty).Trim();

		Console.Write("RFID UID: ");
		string enteredUid = (Console.ReadLine() ?? string.Empty).Trim();
		string rfidUid = string.Concat(enteredUid.Where(character => !char.IsWhiteSpace(character)))
			.ToUpperInvariant();

		Console.Write("PIN: ");
		string pin = ReadMaskedInput().Trim();
		Console.Write("Confirm PIN: ");
		string confirmPin = ReadMaskedInput().Trim();

		if (string.IsNullOrWhiteSpace(fullName))
		{
			Console.WriteLine("Administrator full name is required.");
			return 1;
		}

		if (fullName.Length > 50)
		{
			Console.WriteLine("Administrator full name must not exceed 50 characters.");
			return 1;
		}

		if (rfidUid.Length == 0 || rfidUid.Length > 50 || rfidUid.Length % 2 != 0 || !rfidUid.All(Uri.IsHexDigit))
		{
			Console.WriteLine("RFID UID must be a nonempty, even-length hexadecimal string no longer than 50 characters.");
			return 1;
		}

		if (string.IsNullOrWhiteSpace(pin) || string.IsNullOrWhiteSpace(confirmPin))
		{
			Console.WriteLine("PIN and Confirm PIN are required.");
			return 1;
		}

		if (!string.Equals(pin, confirmPin, StringComparison.Ordinal))
		{
			Console.WriteLine("PIN and Confirm PIN do not match.");
			return 1;
		}

		using var connection = DatabaseHelper.GetConnection();
		bool lockAcquired = false;

		try
		{
			connection.Open();
			using (var lockCommand = new MySqlCommand("SELECT GET_LOCK(@lockName, @timeoutSeconds)", connection))
			{
				lockCommand.Parameters.AddWithValue("@lockName", ProvisioningLockName);
				lockCommand.Parameters.AddWithValue("@timeoutSeconds", LockTimeoutSeconds);
				object? lockResult = lockCommand.ExecuteScalar();
				lockAcquired = lockResult is not null &&
					lockResult is not DBNull &&
					Convert.ToInt32(lockResult) == 1;
			}

			if (!lockAcquired)
			{
				Console.WriteLine("Could not acquire the initial-administrator provisioning lock. No account was created.");
				return 1;
			}

			if (Exists(connection, "SELECT 1 FROM users WHERE role = @value LIMIT 1", "@value", "admin"))
			{
				Console.WriteLine("An administrator account already exists. No initial administrator was created.");
				return 1;
			}

			if (Exists(connection, "SELECT 1 FROM users WHERE rfid_uid = @value LIMIT 1", "@value", rfidUid))
			{
				Console.WriteLine("That RFID UID is already registered. No account was created.");
				return 1;
			}

			string passwordHash = BCrypt.Net.BCrypt.HashPassword(pin);
			using var transaction = connection.BeginTransaction();

			try
			{
				const string insertSql = @"
					INSERT INTO users (rfid_uid, password_hash, full_name, role, is_active)
					VALUES (@rfidUid, @passwordHash, @fullName, @role, TRUE)";

				using var insertCommand = new MySqlCommand(insertSql, connection, transaction);
				insertCommand.Parameters.AddWithValue("@rfidUid", rfidUid);
				insertCommand.Parameters.AddWithValue("@passwordHash", passwordHash);
				insertCommand.Parameters.AddWithValue("@fullName", fullName);
				insertCommand.Parameters.AddWithValue("@role", "admin");

				if (insertCommand.ExecuteNonQuery() != 1)
				{
					transaction.Rollback();
					Console.WriteLine("The administrator account could not be created. No changes were committed.");
					return 1;
				}

				transaction.Commit();
				Console.WriteLine("Initial administrator account created successfully.");
				return 0;
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
		}
		catch (MySqlException exception) when (exception.Number == 1062)
		{
			Console.WriteLine("A duplicate account value prevented provisioning. The RFID UID may already be registered.");
			return 1;
		}
		catch
		{
			Console.WriteLine("Provisioning failed because of a database or unexpected error. No account success was reported.");
			return 1;
		}
		finally
		{
			if (lockAcquired)
			{
				try
				{
					using var releaseCommand = new MySqlCommand("SELECT RELEASE_LOCK(@lockName)", connection);
					releaseCommand.Parameters.AddWithValue("@lockName", ProvisioningLockName);
					object? releaseResult = releaseCommand.ExecuteScalar();
					if (releaseResult is null || releaseResult is DBNull || Convert.ToInt32(releaseResult) != 1)
					{
						Console.WriteLine("Warning: the database did not confirm release of the provisioning lock; closing the connection will release it.");
					}
				}
				catch
				{
					Console.WriteLine("Warning: the provisioning lock could not be explicitly released; closing the connection will release it.");
				}
			}
		}
	}

	private static bool Exists(MySqlConnection connection, string sql, string parameterName, string value)
	{
		using var command = new MySqlCommand(sql, connection);
		command.Parameters.AddWithValue(parameterName, value);
		return command.ExecuteScalar() is not null;
	}

	private static string ReadMaskedInput()
	{
		var input = new StringBuilder();

		while (true)
		{
			ConsoleKeyInfo key = Console.ReadKey(intercept: true);
			if (key.Key == ConsoleKey.Enter)
			{
				Console.WriteLine();
				return input.ToString();
			}

			if (key.Key == ConsoleKey.Backspace)
			{
				if (input.Length > 0)
				{
					input.Length--;
					Console.Write("\b \b");
				}

				continue;
			}

			if (!char.IsControl(key.KeyChar))
			{
				input.Append(key.KeyChar);
				Console.Write('*');
			}
		}
	}
}
