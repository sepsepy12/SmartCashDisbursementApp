using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
	public partial class SystemActivityLogsForm : Form
	{
		private bool isLoadingFilters;

		public SystemActivityLogsForm()
		{
			InitializeComponent();
			cboActionType.Items.Add("All actions");
			cboActionType.Items.AddRange(new object[]
			{
				"ADMIN_LOGIN",
				"ADMIN_SIGN_OUT",
				"USER_REGISTERED",
				"USER_ACTIVATED",
				"USER_DEACTIVATED",
				"DEPOSIT_AUTHORIZED"
			});
			cboActionType.SelectedIndex = 0;
			lblRecordCount.Text = "Loading system activity...";
			LoadData();
		}

		private void LoadData()
		{
			if (dtpDateFrom.Checked && dtpDateTo.Checked && dtpDateFrom.Value.Date > dtpDateTo.Value.Date)
			{
				MessageBox.Show(this,
					"The start date must be on or before the end date.",
					"Invalid Date Range",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			try
			{
				using var connection = DatabaseHelper.GetConnection();
				connection.Open();
				using var command = connection.CreateCommand();
				var conditions = new List<string>();

				if (dtpDateFrom.Checked)
				{
					conditions.Add("log.created_at >= @dateFrom");
					command.Parameters.AddWithValue("@dateFrom", dtpDateFrom.Value.Date);
				}

				if (dtpDateTo.Checked)
				{
					conditions.Add("log.created_at < @dateToExclusive");
					command.Parameters.AddWithValue("@dateToExclusive", dtpDateTo.Value.Date.AddDays(1));
				}

				if (cboActionType.SelectedIndex > 0)
				{
					conditions.Add("log.action_type = @actionType");
					command.Parameters.AddWithValue("@actionType", cboActionType.SelectedItem!.ToString());
				}

				command.CommandText = @"
					SELECT log.id AS `Log ID`,
						COALESCE(admin_user.full_name, 'Unknown administrator') AS `Administrator Name`,
						log.action_type AS `Action Type`,
						COALESCE(target_user.full_name, 'Not applicable') AS `Target User Name`,
						log.description AS `Description`,
						log.created_at AS `Date and Time`
					FROM admin_activity_logs log
					LEFT JOIN users admin_user ON admin_user.id = log.admin_user_id
					LEFT JOIN users target_user ON target_user.id = log.target_user_id" +
					(conditions.Count == 0 ? string.Empty : "\n\t\t\t\t\tWHERE " + string.Join(" AND ", conditions)) + @"
					ORDER BY log.created_at DESC, log.id DESC";

				using var adapter = new MySqlDataAdapter(command);
				var records = new DataTable();
				adapter.Fill(records);
				dgvActivityLogs.DataSource = records;
				if (dgvActivityLogs.Columns.Contains("Date and Time"))
					dgvActivityLogs.Columns["Date and Time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
				lblRecordCount.Text = $"Total records: {records.Rows.Count:N0}";
			}
			catch (MySqlException)
			{
				ShowLoadError("System activity logs could not be loaded because of a database error. Please try again.");
			}
			catch (Exception)
			{
				ShowLoadError("System activity logs could not be loaded. Please try again.");
			}
		}

		private void ShowLoadError(string message)
		{
			dgvActivityLogs.DataSource = null;
			lblRecordCount.Text = "System activity logs could not be loaded.";
			MessageBox.Show(this, message, "Unable to Load System Activity Logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void filter_ValueChanged(object sender, EventArgs e)
		{
			if (!isLoadingFilters)
				LoadData();
		}

		private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isLoadingFilters)
				LoadData();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnClearFilters_Click(object sender, EventArgs e)
		{
			isLoadingFilters = true;
			dtpDateFrom.Checked = false;
			dtpDateTo.Checked = false;
			dtpDateFrom.Value = DateTime.Today;
			dtpDateTo.Value = DateTime.Today;
			cboActionType.SelectedIndex = 0;
			isLoadingFilters = false;
			LoadData();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
