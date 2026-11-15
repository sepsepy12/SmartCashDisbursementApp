using System;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
	internal static class SystemActivityLogger
	{
		internal static void Log(
			MySqlConnection connection,
			int administratorUserId,
			string actionType,
			int? targetUserId,
			string description,
			MySqlTransaction? transaction = null)
		{
			const string sql = @"
				INSERT INTO admin_activity_logs (admin_user_id, action_type, target_user_id, description)
				VALUES (@adminUserId, @actionType, @targetUserId, @description)";

			using var command = transaction is null
				? new MySqlCommand(sql, connection)
				: new MySqlCommand(sql, connection, transaction);
			command.Parameters.AddWithValue("@adminUserId", administratorUserId);
			command.Parameters.AddWithValue("@actionType", actionType);
			command.Parameters.AddWithValue("@targetUserId", targetUserId.HasValue ? targetUserId.Value : DBNull.Value);
			command.Parameters.AddWithValue("@description", description.Length <= 255 ? description : description[..255]);
			if (command.ExecuteNonQuery() != 1)
				throw new InvalidOperationException("The administrator activity could not be recorded.");
		}
	}
}
