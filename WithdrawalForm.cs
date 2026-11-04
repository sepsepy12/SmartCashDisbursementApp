using System;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	public partial class WithdrawalForm : Form
	{
		private readonly int userId;
		private readonly BudgetRepository budgetRepo = new BudgetRepository();
		private string selectedCategory;
		private decimal pendingAmount;
		private decimal availableBalance;
		private bool hasReviewedWithdrawal;
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
			pendingAmount = 0;
			hasReviewedWithdrawal = false;
			try
			{
				RefreshSelectedCategoryBalance();
				lblReview.Text = $"Selected category: {category}. Available balance: ₱{availableBalance:F2}. Enter an amount and click REVIEW WITHDRAWAL.";
			}
			catch (Exception)
			{
				availableBalance = 0;
				lblAvailableBalance.Text = "Available balance: unavailable";
				lblReview.Text = $"Selected category: {category}. The balance could not be checked.";
				MessageBox.Show("The selected category balance could not be loaded. Please try again.", "Balance Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
				RefreshSelectedCategoryBalance();

				if (amount > availableBalance)
				{
					pendingAmount = 0;
					hasReviewedWithdrawal = false;
					lblReview.Text = "The requested amount is greater than the available balance.";
					MessageBox.Show("Insufficient balance.", "Withdrawal Declined", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				pendingAmount = amount;
				hasReviewedWithdrawal = true;
				lblReview.Text = $"Review: Withdraw ₱{pendingAmount:F2} from {selectedCategory}. Click CONFIRM to save.";
			}
			catch (Exception)
			{
				pendingAmount = 0;
				hasReviewedWithdrawal = false;
				lblReview.Text = "The balance could not be verified. Please review the withdrawal again.";
				MessageBox.Show("The available balance could not be checked. Please try again.", "Balance Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (isSaving)
				return;

			if (!hasReviewedWithdrawal || pendingAmount <= 0 || string.IsNullOrEmpty(selectedCategory))
			{
				MessageBox.Show("Please select a category and review a valid withdrawal before confirming.", "Withdrawal Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			isSaving = true;
			button4.Enabled = false;

			try
			{
				decimal amount = pendingAmount;
				if (budgetRepo.TryWithdraw(userId, selectedCategory, amount, out decimal remainingBalance, out string failureReason))
				{
					availableBalance = remainingBalance;
					lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
					MessageBox.Show(
						$"Withdrawal successful!\n\nAmount: ₱{amount:F2}\nCategory: {selectedCategory}",
						"Withdrawal Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
					ResetWithdrawal();
					return;
				}

				availableBalance = remainingBalance;
				lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
				pendingAmount = 0;
				hasReviewedWithdrawal = false;
				lblReview.Text = failureReason ?? "The withdrawal was declined. Please review it again.";
				MessageBox.Show(failureReason ?? "The withdrawal was declined.", "Withdrawal Declined", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
			availableBalance = 0;
			lblAvailableBalance.Text = "Available balance: select a category";
		}

		private void RefreshSelectedCategoryBalance()
		{
			availableBalance = budgetRepo.GetCategoryBalance(userId, selectedCategory);
			lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
		}

		private void ResetWithdrawal()
		{
			txtAmount.Text = "0.00";
			pendingAmount = 0;
			hasReviewedWithdrawal = false;
			lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
			lblReview.Text = $"Selected category: {selectedCategory}. Enter an amount and click REVIEW WITHDRAWAL.";
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