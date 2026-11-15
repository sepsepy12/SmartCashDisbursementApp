using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
	public partial class DepositAuthorizationHistoryForm : Form
	{
		private bool isLoadingFilters;

		public DepositAuthorizationHistoryForm(int administratorUserId)
		{
			InitializeComponent();
			if (administratorUserId <= 0)
				throw new ArgumentOutOfRangeException(nameof(administratorUserId));

			lblRecordCount.Text = "Loading deposit authorization records...";
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				using var connection = DatabaseHelper.GetConnection();
				connection.Open();

				using var command = connection.CreateCommand();
				var conditions = new List<string> { "t.type = @type" };
				command.Parameters.AddWithValue("@type", "deposit");

				if (chkDateRange.Checked)
				{
					if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
					{
						MessageBox.Show(this,
							"The start date must be on or before the end date.",
							"Invalid Date Range",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);
						return;
					}

					conditions.Add("t.created_at >= @startDate");
					conditions.Add("t.created_at < @endDateExclusive");
					command.Parameters.AddWithValue("@startDate", dtpStartDate.Value.Date);
					command.Parameters.AddWithValue("@endDateExclusive", dtpEndDate.Value.Date.AddDays(1));
				}

				command.CommandText = @"
					SELECT t.id AS `Transaction ID`,
						t.user_id AS `User ID`,
						COALESCE(receiving_user.full_name, 'Unknown user') AS `User Full Name`,
						COALESCE(bc.category_name, 'Uncategorized') AS `Category`,
						t.amount AS `Deposit Amount`,
						COALESCE(authorizing_user.full_name, 'Not Recorded') AS `Authorized By`,
						t.created_at AS `Date and Time`
					FROM transactions t
					LEFT JOIN users receiving_user ON receiving_user.id = t.user_id
					LEFT JOIN budget_categories bc
						ON bc.id = t.category_id
					   AND bc.user_id = t.user_id
					LEFT JOIN users authorizing_user ON authorizing_user.id = t.authorized_by_user_id
					WHERE " + string.Join(" AND ", conditions) + @"
					ORDER BY t.created_at DESC, t.id DESC";

				using var adapter = new MySqlDataAdapter(command);
				var records = new DataTable();
				adapter.Fill(records);
				dgvAuthorizationHistory.DataSource = records;
				FormatGridColumns();
				lblRecordCount.Text = records.Rows.Count == 0
					? "No deposit authorization records match the selected filters."
					: $"{records.Rows.Count:N0} record(s).";
			}
			catch (MySqlException)
			{
				ShowLoadError("Deposit authorization history could not be loaded because of a database error. Please try again.");
			}
			catch (Exception)
			{
				ShowLoadError("Deposit authorization history could not be loaded. Please try again.");
			}
		}

		private void FormatGridColumns()
		{
			if (dgvAuthorizationHistory.Columns.Contains("Deposit Amount"))
			{
				dgvAuthorizationHistory.Columns["Deposit Amount"].DefaultCellStyle.Format = "N2";
				dgvAuthorizationHistory.Columns["Deposit Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}

			if (dgvAuthorizationHistory.Columns.Contains("Date and Time"))
				dgvAuthorizationHistory.Columns["Date and Time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
		}

		private void ShowLoadError(string message)
		{
			dgvAuthorizationHistory.DataSource = null;
			lblRecordCount.Text = "Deposit authorization records could not be loaded.";
			MessageBox.Show(this, message, "Unable to Load Deposit Authorization History", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void chkDateRange_CheckedChanged(object sender, EventArgs e)
		{
			dtpStartDate.Enabled = chkDateRange.Checked;
			dtpEndDate.Enabled = chkDateRange.Checked;
			if (!isLoadingFilters)
				LoadData();
		}

		private void dateFilter_ValueChanged(object sender, EventArgs e)
		{
			if (chkDateRange.Checked && !isLoadingFilters)
				LoadData();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnClearFilters_Click(object sender, EventArgs e)
		{
			isLoadingFilters = true;
			chkDateRange.Checked = false;
			dtpStartDate.Value = DateTime.Today;
			dtpEndDate.Value = DateTime.Today;
			isLoadingFilters = false;
			LoadData();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
