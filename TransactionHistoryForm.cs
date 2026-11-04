using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
	public partial class TransactionHistoryForm : Form
	{
		private readonly int userId;
		private DataTable rawTransactions = new DataTable();
		private string idColumn;
		private string dateColumn;
		private string typeColumn;
		private string amountColumn;
		private const string CategoryColumn = "joined_category_name";

		public TransactionHistoryForm(int userId)
		{
			InitializeComponent();
			this.userId = userId;
			LoadTransactions();
		}

		private void LoadTransactions()
		{
			try
			{
				using (var conn = DatabaseHelper.GetConnection())
				{
					conn.Open();
					const string sql = @"
						SELECT t.*, bc.category_name AS joined_category_name
						FROM transactions t
						LEFT JOIN budget_categories bc
							ON bc.id = t.category_id
						   AND bc.user_id = @userId
						WHERE t.user_id = @userId";

					using (var cmd = new MySqlCommand(sql, conn))
					{
						cmd.Parameters.AddWithValue("@userId", userId);
						using (var reader = cmd.ExecuteReader())
						{
							rawTransactions = new DataTable();
							rawTransactions.Load(reader);
						}
					}
				}

				DetectColumns();
				PopulateCategoryFilter();
				ApplyFilters();
			}
			catch (Exception)
			{
				rawTransactions = new DataTable();
				transactionGrid.Rows.Clear();
				transactionGrid.Columns.Clear();
				lblEmpty.Text = "Transaction history could not be loaded. Please try again.";
				lblEmpty.Visible = true;
				MessageBox.Show(
					"Transaction history could not be loaded. Please try again.",
					"History Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void DetectColumns()
		{
			idColumn = FindColumn("id", "transaction_id");
			dateColumn = FindColumn("transaction_date", "created_at", "created_on", "date", "timestamp");
			typeColumn = FindColumn("type");
			amountColumn = FindColumn("amount");
		}

		private string FindColumn(params string[] candidates)
		{
			foreach (string candidate in candidates)
			{
				DataColumn column = rawTransactions.Columns
					.Cast<DataColumn>()
					.FirstOrDefault(item => string.Equals(item.ColumnName, candidate, StringComparison.OrdinalIgnoreCase));
				if (column != null)
					return column.ColumnName;
			}

			return null;
		}

		private void PopulateCategoryFilter()
		{
			string previousSelection = categoryFilter.SelectedItem as string;
			categoryFilter.BeginUpdate();
			categoryFilter.Items.Clear();
			categoryFilter.Items.Add("All");

			if (rawTransactions.Columns.Contains(CategoryColumn))
			{
				var categories = rawTransactions.Rows
					.Cast<DataRow>()
					.Select(row => Convert.ToString(row[CategoryColumn]))
					.Where(value => !string.IsNullOrWhiteSpace(value))
					.Distinct(StringComparer.OrdinalIgnoreCase)
					.OrderBy(value => value);

				foreach (string category in categories)
					categoryFilter.Items.Add(category);
			}

			categoryFilter.SelectedIndex = categoryFilter.Items.Contains(previousSelection)
				? categoryFilter.Items.IndexOf(previousSelection)
				: 0;
			categoryFilter.EndUpdate();
		}

		private void ApplyFilters()
		{
			transactionGrid.Rows.Clear();
			transactionGrid.Columns.Clear();

			AddGridColumns();

			string selectedType = typeFilter.SelectedItem as string ?? "All";
			string selectedCategory = categoryFilter.SelectedItem as string ?? "All";
			var rows = rawTransactions.Rows.Cast<DataRow>()
				.Where(row => MatchesType(row, selectedType))
				.Where(row => MatchesCategory(row, selectedCategory))
				.ToList();

			SortRows(rows);
			foreach (DataRow row in rows)
				AddGridRow(row);

			lblEmpty.Visible = rows.Count == 0;
		}

		private void AddGridColumns()
		{
			if (!string.IsNullOrEmpty(idColumn))
				transactionGrid.Columns.Add("TransactionId", "Transaction ID");
			if (!string.IsNullOrEmpty(dateColumn))
				transactionGrid.Columns.Add("TransactionDate", "Date / Time");

			transactionGrid.Columns.Add("TransactionType", "Type");
			transactionGrid.Columns.Add("Category", "Category");
			transactionGrid.Columns.Add("Amount", "Amount");

			foreach (DataGridViewColumn column in transactionGrid.Columns)
			{
				column.ReadOnly = true;
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}

			if (transactionGrid.Columns.Contains("TransactionId"))
				transactionGrid.Columns["TransactionId"].Width = 110;
			if (transactionGrid.Columns.Contains("TransactionDate"))
				transactionGrid.Columns["TransactionDate"].Width = 170;
			transactionGrid.Columns["TransactionType"].Width = 110;
			transactionGrid.Columns["Category"].Width = 180;
			transactionGrid.Columns["Amount"].Width = 140;
			transactionGrid.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}

		private bool MatchesType(DataRow row, string selectedType)
		{
			if (selectedType == "All" || string.IsNullOrEmpty(typeColumn))
				return true;

			string type = Convert.ToString(row[typeColumn]);
			return selectedType == "Deposits"
				? string.Equals(type, "deposit", StringComparison.OrdinalIgnoreCase)
				: string.Equals(type, "withdrawal", StringComparison.OrdinalIgnoreCase);
		}

		private bool MatchesCategory(DataRow row, string selectedCategory)
		{
			if (selectedCategory == "All" || !rawTransactions.Columns.Contains(CategoryColumn))
				return true;

			return string.Equals(
				Convert.ToString(row[CategoryColumn]),
				selectedCategory,
				StringComparison.OrdinalIgnoreCase);
		}

		private void SortRows(List<DataRow> rows)
		{
			if (!string.IsNullOrEmpty(dateColumn))
			{
				rows.Sort((left, right) => GetDate(right).CompareTo(GetDate(left)));
			}
			else if (!string.IsNullOrEmpty(idColumn))
			{
				rows.Sort((left, right) => GetDecimal(right, idColumn).CompareTo(GetDecimal(left, idColumn)));
			}
		}

		private DateTime GetDate(DataRow row)
		{
			DateTime.TryParse(
				Convert.ToString(row[dateColumn]),
				CultureInfo.CurrentCulture,
				DateTimeStyles.None,
				out DateTime value);
			return value;
		}

		private decimal GetDecimal(DataRow row, string columnName)
		{
			decimal.TryParse(Convert.ToString(row[columnName]), out decimal value);
			return value;
		}

		private void AddGridRow(DataRow row)
		{
			var values = new List<object>();
			if (!string.IsNullOrEmpty(idColumn))
				values.Add(Convert.ToString(row[idColumn]));
			if (!string.IsNullOrEmpty(dateColumn))
				values.Add(FormatDate(row[dateColumn]));

			string type = Convert.ToString(row[typeColumn]);
			values.Add(string.Equals(type, "withdrawal", StringComparison.OrdinalIgnoreCase)
				? "Withdrawal"
				: "Deposit");
			values.Add(rawTransactions.Columns.Contains(CategoryColumn)
				? Convert.ToString(row[CategoryColumn])
				: "Uncategorized");
			values.Add(FormatAmount(row[amountColumn]));
			transactionGrid.Rows.Add(values.ToArray());
		}

		private string FormatDate(object value)
		{
			if (DateTime.TryParse(Convert.ToString(value), out DateTime date))
				return date.ToString("yyyy-MM-dd HH:mm:ss");
			return Convert.ToString(value);
		}

		private string FormatAmount(object value)
		{
			if (decimal.TryParse(Convert.ToString(value), out decimal amount))
				return $"₱{amount:N2}";
			return Convert.ToString(value);
		}

		private void typeFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			ApplyFilters();
		}

		private void categoryFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			ApplyFilters();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadTransactions();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
