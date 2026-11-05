using System;
using System.Globalization;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	public partial class GoalPlanningForm : Form
	{
		private readonly int userId;
		private readonly BudgetRepository budgetRepo = new BudgetRepository();
		private string selectedCategory;
		private Button selectedCategoryButton;
		private bool saveInProgress;

		public GoalPlanningForm(int userId)
		{
			InitializeComponent();
			this.userId = userId;

			button1.Click += button1_Click;
			button2.Click += button2_Click;
			button3.Click += button3_Click;
			button4.Click += button4_Click;
			button5.Click += button5_Click;
			button6.Click += button6_Click;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SelectCategory("Savings", button1);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SelectCategory("Wants", button2);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SelectCategory("Needs", button3);
		}

		private void SelectCategory(string categoryName, Button clickedButton)
		{
			selectedCategory = categoryName;
			selectedCategoryButton = clickedButton;

			ResetCategoryButton(button1, System.Drawing.Color.FromArgb(43, 125, 55));
			ResetCategoryButton(button2, System.Drawing.Color.FromArgb(29, 109, 190));
			ResetCategoryButton(button3, System.Drawing.Color.FromArgb(239, 124, 9));

			clickedButton.BackColor = clickedButton.ForeColor;
			clickedButton.ForeColor = System.Drawing.Color.White;
			lblValidation.Text = $"Selected category: {categoryName.ToUpperInvariant()}";
			lblValidation.ForeColor = System.Drawing.Color.FromArgb(43, 125, 55);
		}

		private static void ResetCategoryButton(Button button, System.Drawing.Color color)
		{
			button.BackColor = System.Drawing.Color.White;
			button.ForeColor = color;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (saveInProgress)
				return;

			if (string.IsNullOrEmpty(selectedCategory))
			{
				ShowValidation("Please select a category (A, B, or C).");
				return;
			}

			if (!decimal.TryParse(textBox1.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal amount) || amount <= 0)
			{
				ShowValidation("Please enter an amount greater than zero.");
				textBox1.Focus();
				return;
			}

			DateTime targetDate = datePicker.Value.Date;
			if (targetDate <= DateTime.Today)
			{
				ShowValidation("Target date must be in the future.");
				datePicker.Focus();
				return;
			}

			saveInProgress = true;
			button5.Enabled = false;
			try
			{
				textBox1.Text = amount.ToString("0.##", CultureInfo.CurrentCulture);
				using (var conn = DatabaseHelper.GetConnection())
				{
					conn.Open();
					int categoryId = budgetRepo.GetOrCreateCategoryId(userId, selectedCategory, conn);
					budgetRepo.SaveGoal(userId, categoryId, amount, targetDate);
				}

				MessageBox.Show("Goal saved successfully!", "Goal Planning", MessageBoxButtons.OK, MessageBoxIcon.Information);
				ClearForm();
			}
			catch (Exception)
			{
				ShowValidation("The goal could not be saved. Please check the database connection and try again.");
			}
			finally
			{
				saveInProgress = false;
				button5.Enabled = true;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			ClearForm();
		}

		private void ClearForm()
		{
			selectedCategory = null;
			selectedCategoryButton = null;
			textBox1.Clear();
			datePicker.Value = DateTime.Today.AddDays(1);
			ResetCategoryButton(button1, System.Drawing.Color.FromArgb(43, 125, 55));
			ResetCategoryButton(button2, System.Drawing.Color.FromArgb(29, 109, 190));
			ResetCategoryButton(button3, System.Drawing.Color.FromArgb(239, 124, 9));
			lblValidation.Text = string.Empty;
			lblValidation.ForeColor = System.Drawing.Color.Firebrick;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void GoalPlanningForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (textBox1.Focused || datePicker.Focused)
				return;

			switch (e.KeyCode)
			{
				case Keys.A:
					SelectCategory("Savings", button1);
					e.Handled = true;
					break;
				case Keys.B:
					SelectCategory("Wants", button2);
					e.Handled = true;
					break;
				case Keys.C:
					SelectCategory("Needs", button3);
					e.Handled = true;
					break;
			}
		}

		private void GoalPlanningForm_Load(object sender, EventArgs e)
		{
			datePicker.MinDate = DateTime.Today.AddDays(1);
			datePicker.Value = datePicker.MinDate;
			UpdateClock();
			clockTimer.Start();
		}

		private void clockTimer_Tick(object sender, EventArgs e)
		{
			UpdateClock();
		}

		private void UpdateClock()
		{
			lblDateTime.Text = $"◷  {DateTime.Now:MMM dd, yyyy | hh:mm tt}";
		}

		private void GoalPlanningForm_Resize(object sender, EventArgs e)
		{
			lblDateTime.Location = new System.Drawing.Point(Math.Max(0, ClientSize.Width - 450), 22);
		}

		private void ShowValidation(string message)
		{
			lblValidation.ForeColor = System.Drawing.Color.Firebrick;
			lblValidation.Text = message;
		}
	}
}