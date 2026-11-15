using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
	public partial class TransactionMonitoringForm : Form
	{
		private bool isLoadingFilters;

		public TransactionMonitoringForm(int administratorUserId)
		{
			InitializeComponent();
			if (administratorUserId <= 0)
				throw new ArgumentOutOfRangeException(nameof(administratorUserId));

			lblStatus.Text = "Loading transactions...";
			LoadData(reloadTypes: true);
		}

		private void LoadData(bool reloadTypes)
		{
			try
			{
				using var connection = DatabaseHelper.GetConnection();
				connection.Open();

				if (reloadTypes)
					LoadTransactionTypes(connection);

				var conditions = new List<string>();
				using var command = connection.CreateCommand();

				if (cmbTransactionType.SelectedIndex > 0)
				{
					conditions.Add("t.type = @type");
					command.Parameters.AddWithValue("@type", cmbTransactionType.SelectedItem!.ToString());
				}

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

				string sql = @"
					SELECT t.id AS `Transaction ID`,
						t.user_id AS `User ID`,
						COALESCE(u.full_name, 'Unknown user') AS `User Full Name`,
						t.type AS `Transaction Type`,
						COALESCE(bc.category_name, 'Uncategorized') AS `Category`,
						t.amount AS `Amount`,
						t.created_at AS `Transaction Date and Time`
					FROM transactions t
					LEFT JOIN users u ON u.id = t.user_id
					LEFT JOIN budget_categories bc
						ON bc.id = t.category_id
					   AND bc.user_id = t.user_id";

				if (conditions.Count > 0)
					sql += "\nWHERE " + string.Join(" AND ", conditions);

				sql += "\nORDER BY t.created_at DESC, t.id DESC";
				command.CommandText = sql;

				using var adapter = new MySqlDataAdapter(command);
				var transactions = new DataTable();
				adapter.Fill(transactions);
				dgvTransactions.DataSource = transactions;
				FormatGridColumns();
				lblStatus.Text = transactions.Rows.Count == 0
					? "No transactions match the selected filters."
					: $"{transactions.Rows.Count:N0} transaction record(s).";
			}
			catch (MySqlException)
			{
				ShowLoadError("Transaction records could not be loaded because of a database error. Please try again.");
			}
			catch (Exception)
			{
				ShowLoadError("Transaction records could not be loaded. Please try again.");
			}
		}

		private void LoadTransactionTypes(MySqlConnection connection)
		{
			string previousSelection = cmbTransactionType.SelectedItem as string ?? "All";
			isLoadingFilters = true;
			try
			{
				cmbTransactionType.Items.Clear();
				cmbTransactionType.Items.Add("All");

				using var command = new MySqlCommand(
					"SELECT DISTINCT type FROM transactions WHERE type IS NOT NULL ORDER BY type",
					connection);
				using var reader = command.ExecuteReader();
				while (reader.Read())
					cmbTransactionType.Items.Add(reader.GetString("type"));

				int previousIndex = cmbTransactionType.Items.IndexOf(previousSelection);
				cmbTransactionType.SelectedIndex = previousIndex >= 0 ? previousIndex : 0;
			}
			finally
			{
				isLoadingFilters = false;
			}
		}

		private void FormatGridColumns()
		{
			if (dgvTransactions.Columns.Contains("Amount"))
			{
				dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "N2";
				dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}

			if (dgvTransactions.Columns.Contains("Transaction Date and Time"))
				dgvTransactions.Columns["Transaction Date and Time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
		}

		private void ShowLoadError(string message)
		{
			dgvTransactions.DataSource = null;
			lblStatus.Text = "Transactions could not be loaded.";
			MessageBox.Show(this, message, "Unable to Load Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isLoadingFilters)
				LoadData(reloadTypes: false);
		}

		private void chkDateRange_CheckedChanged(object sender, EventArgs e)
		{
			dtpStartDate.Enabled = chkDateRange.Checked;
			dtpEndDate.Enabled = chkDateRange.Checked;
			if (!isLoadingFilters)
				LoadData(reloadTypes: false);
		}

		private void dateFilter_ValueChanged(object sender, EventArgs e)
		{
			if (chkDateRange.Checked && !isLoadingFilters)
				LoadData(reloadTypes: false);
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadData(reloadTypes: true);
		}

		private void btnClearFilters_Click(object sender, EventArgs e)
		{
			isLoadingFilters = true;
			cmbTransactionType.SelectedIndex = 0;
			chkDateRange.Checked = false;
			dtpStartDate.Value = DateTime.Today;
			dtpEndDate.Value = DateTime.Today;
			isLoadingFilters = false;
			LoadData(reloadTypes: false);
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
