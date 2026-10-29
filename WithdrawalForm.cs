using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
	public partial class WithdrawalForm : Form
	{
		private readonly int userId;
		private readonly BudgetRepository budgetRepo = new BudgetRepository();
		private string selectedCategory;
		private decimal pendingAmount;
		private decimal availableBalance;
		private bool isSaving;

		public WithdrawalForm(int userId)
		{
			InitializeComponent();
			this.userId = userId;
			LoadAvailableBalance();
		}

		private void button1_Click(object sender, EventArgs e) => SelectCategory("Needs");

		private void button2_Click(object sender, EventArgs e) => SelectCategory("Wants");

		private void button3_Click(object sender, EventArgs e) => SelectCategory("Savings");

		private void SelectCategory(string category)
		{
			selectedCategory = category;
			lblReview.Text = $"Selected category: {category}. Enter an amount and click REVIEW WITHDRAWAL.";
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (isSaving)
				return;

			if (string.IsNullOrEmpty(selectedCategory))
			{
				MessageBox.Show("Please select a withdrawal category.", "Category Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (!TryGetAmount(out decimal amount))
				return;

			try
			{
				availableBalance = GetAvailableBalance();
				lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";

				if (amount > availableBalance)
				{
					pendingAmount = 0;
					lblReview.Text = "The requested amount is greater than the available balance.";
					MessageBox.Show("Insufficient balance.", "Withdrawal Declined", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				pendingAmount = amount;
				lblReview.Text = $"Review: Withdraw ₱{pendingAmount:F2} from {selectedCategory}. Click CONFIRM to save.";
			}
			catch (Exception)
			{
				MessageBox.Show("The available balance could not be checked. Please try again.", "Balance Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (isSaving)
				return;

			if (pendingAmount <= 0 || string.IsNullOrEmpty(selectedCategory))
			{
				MessageBox.Show("Please select a category and review a valid withdrawal before confirming.", "Withdrawal Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			isSaving = true;
			button4.Enabled = false;

			try
			{
				using (var conn = DatabaseHelper.GetConnection())
				{
					conn.Open();
					decimal currentBalance = GetAvailableBalance(conn);
					if (pendingAmount > currentBalance)
					{
						pendingAmount = 0;
						lblAvailableBalance.Text = $"Available balance: ₱{currentBalance:F2}";
						lblReview.Text = "The available balance changed. Please review the withdrawal again.";
						MessageBox.Show("Insufficient balance.", "Withdrawal Declined", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					int categoryId = budgetRepo.GetOrCreateCategoryId(userId, selectedCategory, conn);
					const string insertSql =
						"INSERT INTO transactions (user_id, category_id, type, amount) " +
						"VALUES (@userId, @categoryId, 'withdrawal', @amount)";

					using (var cmd = new MySqlCommand(insertSql, conn))
					{
						cmd.Parameters.AddWithValue("@userId", userId);
						cmd.Parameters.AddWithValue("@categoryId", categoryId);
						cmd.Parameters.AddWithValue("@amount", pendingAmount);
						cmd.ExecuteNonQuery();
					}
				}

				MessageBox.Show(
					$"Withdrawal successful!\n\nAmount: ₱{pendingAmount:F2}\nCategory: {selectedCategory}",
					"Withdrawal Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
				ResetWithdrawal();
			}
			catch (Exception)
			{
				MessageBox.Show("The withdrawal could not be saved. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				isSaving = false;
				button4.Enabled = true;
			}
		}

		private bool TryGetAmount(out decimal amount)
		{
			string text = txtAmount.Text.Replace("P", "").Replace("₱", "").Trim();
			if (decimal.TryParse(text, out amount) && amount > 0)
				return true;

			amount = 0;
			MessageBox.Show("Please enter a valid withdrawal amount greater than zero.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return false;
		}

		private void LoadAvailableBalance()
		{
			try
			{
				availableBalance = GetAvailableBalance();
				lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
			}
			catch (Exception)
			{
				lblAvailableBalance.Text = "Available balance: unavailable";
				MessageBox.Show("The available balance could not be loaded. Please try again.", "Balance Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private decimal GetAvailableBalance()
		{
			using (var conn = DatabaseHelper.GetConnection())
			{
				conn.Open();
				return GetAvailableBalance(conn);
			}
		}

		private decimal GetAvailableBalance(MySqlConnection conn)
		{
			const string sql = @"
				SELECT
					COALESCE(SUM(CASE WHEN type = 'deposit' THEN amount ELSE 0 END), 0),
					COALESCE(SUM(CASE WHEN type = 'withdrawal' THEN amount ELSE 0 END), 0)
				FROM transactions
				WHERE user_id = @userId";

			using (var cmd = new MySqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@userId", userId);
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return 0;

					decimal deposits = Convert.ToDecimal(reader.GetValue(0));
					decimal withdrawals = Convert.ToDecimal(reader.GetValue(1));
					return Math.Max(0, deposits - withdrawals);
				}
			}
		}

		private void ResetWithdrawal()
		{
			availableBalance -= pendingAmount;
			txtAmount.Text = "0.00";
			selectedCategory = null;
			pendingAmount = 0;
			lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
			lblReview.Text = "Select a category and review your withdrawal before confirming.";
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}