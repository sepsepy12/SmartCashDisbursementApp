using System;
using System.Drawing;
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
		private bool isSaving;

		public WithdrawalForm(int userId)
		{
			InitializeComponent();
			this.userId = userId;
			dateTimeLabel.Text = DateTime.Now.ToString("MMM d, yyyy | h:mm tt");
			LoadAvailableBalance();
			Resize += WithdrawalForm_Resize;
			ApplyResponsiveLayout();
		}

		private void button1_Click(object sender, EventArgs e) => SelectCategory("Needs");

		private void button2_Click(object sender, EventArgs e) => SelectCategory("Wants");

		private void button3_Click(object sender, EventArgs e) => SelectCategory("Savings");

		private void SelectCategory(string category)
		{
			if (isSaving)
				return;

			selectedCategory = category;
			ClearPendingWithdrawal();

			if (!TryGetAmount(out decimal amount))
			{
				lblReview.Text = $"Selected category: {category}. Enter a valid amount to continue.";
				return;
			}

			try
			{
				RefreshSelectedCategoryBalance();
				if (amount > availableBalance)
				{
					lblReview.Text = "The requested amount is greater than the available balance.";
					MessageBox.Show("Insufficient balance.", "Withdrawal Declined", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				pendingAmount = amount;
				ShowWithdrawalConfirmation();
			}
			catch (Exception)
			{
				ClearPendingWithdrawal();
				lblReview.Text = $"Selected category: {category}. The balance could not be checked.";
				MessageBox.Show("The selected category balance could not be loaded. Please try again.", "Balance Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ShowWithdrawalConfirmation()
		{
			string confirmation =
				$"WITHDRAWAL CONFIRMATION\n\nAmount: ₱{pendingAmount:F2}\n" +
				$"Category: {selectedCategory.ToUpperInvariant()}\n" +
				$"Available Balance: ₱{availableBalance:F2}\n" +
				$"Remaining Balance: ₱{availableBalance - pendingAmount:F2}\n\n" +
				"Are you sure you want to proceed with this withdrawal?";

			if (MessageBox.Show(confirmation, "Withdrawal Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				ConfirmWithdrawal();
			else
				ClearPendingWithdrawal();
		}

		private void ConfirmWithdrawal()
		{
			if (isSaving || pendingAmount <= 0 || string.IsNullOrEmpty(selectedCategory))
				return;

			if (!TryGetAmount(out decimal enteredAmount))
			{
				ClearPendingWithdrawal();
				return;
			}

			if (enteredAmount != pendingAmount)
			{
				ClearPendingWithdrawal();
				MessageBox.Show("The withdrawal amount has changed. Please select a category again.", "Withdrawal Changed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			isSaving = true;
			SetCategoryButtonsEnabled(false);
			try
			{
				decimal amount = pendingAmount;
				if (budgetRepo.TryWithdraw(userId, selectedCategory, amount, out decimal remainingBalance, out string failureReason))
				{
					availableBalance = remainingBalance;
					lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
					MessageBox.Show($"Withdrawal successful!\n\nAmount: ₱{amount:F2}\nCategory: {selectedCategory}", "Withdrawal Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
					ResetWithdrawal();
					return;
				}

				availableBalance = remainingBalance;
				lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
				ClearPendingWithdrawal();
				lblReview.Text = failureReason ?? "The withdrawal was declined. Please select a category again.";
				MessageBox.Show(failureReason ?? "The withdrawal was declined.", "Withdrawal Declined", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception)
			{
				ClearPendingWithdrawal();
				MessageBox.Show("The withdrawal could not be saved. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				isSaving = false;
				SetCategoryButtonsEnabled(true);
			}
		}

		private void SetCategoryButtonsEnabled(bool enabled)
		{
			button1.Enabled = enabled;
			button2.Enabled = enabled;
			button3.Enabled = enabled;
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
			ClearPendingWithdrawal();
			lblAvailableBalance.Text = $"Available balance: ₱{availableBalance:F2}";
			lblReview.Text = $"Selected category: {selectedCategory}. Enter an amount and select a category to continue.";
		}

		private void ClearPendingWithdrawal()
		{
			pendingAmount = 0;
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

		private void WithdrawalForm_Resize(object sender, EventArgs e)
		{
			ApplyResponsiveLayout();
		}

		private void ApplyResponsiveLayout()
		{
			if (pnlAmount == null)
				return;

			int groupLeft = Math.Max(0, (ClientSize.Width - 800) / 2);
			int amountLeft = Math.Max(24, (ClientSize.Width - pnlAmount.Width) / 2);
			pnlAmount.Left = amountLeft;
			lblReview.Location = new Point(amountLeft, lblReview.Top);
			label3.Left = amountLeft;
			label4.Left = groupLeft + 20;
			button1.Left = groupLeft + 20;
			button2.Left = groupLeft + 305;
			button3.Left = groupLeft + 590;
			lblAmountHint.Left = amountLeft + Math.Max(0, (pnlAmount.Width - lblAmountHint.Width) / 2);
			lblAvailableBalance.Left = amountLeft + 400;
			label1.Left = Math.Max(24, (ClientSize.Width - label1.Width) / 2);
			label2.Left = Math.Max(24, (ClientSize.Width - label2.Width) / 2);
		}
	}
}