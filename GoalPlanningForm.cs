using System;
using System.Globalization;
using System.Drawing;
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
			savedGoalsGrid.CellPainting += savedGoalsGrid_CellPainting;
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

			if (!DateTime.TryParseExact(txtTargetDate.Text.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime targetDate))
			{
				ShowValidation("Please enter a valid target date (YYYY-MM-DD).");
				txtTargetDate.Focus();
				return;
			}

			if (targetDate.Date <= DateTime.Today)
			{
				ShowValidation("Target date must be in the future.");
				txtTargetDate.Focus();
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
					bool created = budgetRepo.SaveGoalAndGetCreated(userId, categoryId, amount, targetDate);
					LoadSavedGoals();
					MessageBox.Show(created ? "Goal created successfully!" : "Goal updated successfully!", "Goal Planning", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

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
			txtTargetDate.Clear();
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
			if (textBox1.Focused || txtTargetDate.Focused)
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
			txtTargetDate.Clear();
			UpdateClock();
			LoadSavedGoals();
			clockTimer.Start();
		}

		private void LoadSavedGoals()
		{
			try
			{
				var goals = budgetRepo.GetGoalsForUser(userId);
				savedGoalsGrid.Rows.Clear();

				if (goals.Count == 0)
				{
					savedGoalsGrid.Visible = false;
					lblNoGoals.Text = "No saved goals yet.";
					lblNoGoals.Visible = true;
					return;
				}

				savedGoalsGrid.Visible = true;
				lblNoGoals.Visible = false;
				foreach (SavedGoal goal in goals)
				{
					decimal progress = CalculateProgress(goal.CurrentBalance, goal.TargetAmount);
					decimal remaining = Math.Max(0, goal.TargetAmount - Math.Max(0, goal.CurrentBalance));
					string status = GetGoalStatus(goal);

					int rowIndex = savedGoalsGrid.Rows.Add(
						goal.CategoryName,
						FormatCurrency(goal.TargetAmount),
						FormatCurrency(goal.CurrentBalance),
						progress,
						FormatCurrency(remaining),
						goal.TargetDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
						status);
					savedGoalsGrid.Rows[rowIndex].Cells["Progress"].Style.Format = "0.#'%'";
					savedGoalsGrid.Rows[rowIndex].Cells["Status"].Style.ForeColor = GetStatusColor(status);
				}
			}
			catch (Exception)
			{
				savedGoalsGrid.Rows.Clear();
				savedGoalsGrid.Visible = false;
				lblNoGoals.Text = "Saved goals could not be loaded. Please check the database connection.";
				lblNoGoals.Visible = true;
			}
		}

		private static decimal CalculateProgress(decimal currentBalance, decimal targetAmount)
		{
			if (currentBalance <= 0 || targetAmount <= 0)
				return 0;

			return Math.Min(100, currentBalance / targetAmount * 100);
		}

		private static string GetGoalStatus(SavedGoal goal)
		{
			if (goal.TargetAmount > 0 && goal.CurrentBalance >= goal.TargetAmount)
				return "Completed";

			if (goal.TargetDate.Date < DateTime.Today)
				return "Overdue";

			return "In Progress";
		}

		private static string FormatCurrency(decimal amount)
		{
			return $"₱{amount:N0}";
		}

		private static Color GetStatusColor(string status)
		{
			return status switch
			{
				"Completed" => Color.FromArgb(43, 125, 55),
				"Overdue" => Color.Firebrick,
				_ => Color.FromArgb(29, 109, 190)
			};
		}

		private void savedGoalsGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0 || savedGoalsGrid.Columns[e.ColumnIndex].Name != "Progress")
				return;

			if (!decimal.TryParse(Convert.ToString(e.Value, CultureInfo.InvariantCulture), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal progress))
				return;

			e.PaintBackground(e.CellBounds, true);
			Rectangle barBounds = new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 7, e.CellBounds.Width - 8, e.CellBounds.Height - 14);
			using (var backgroundBrush = new SolidBrush(Color.FromArgb(232, 238, 245)))
			using (var progressBrush = new SolidBrush(Color.FromArgb(43, 125, 55)))
			using (var textBrush = new SolidBrush(Color.FromArgb(20, 42, 78)))
			{
				e.Graphics.FillRectangle(backgroundBrush, barBounds);
				int progressWidth = (int)Math.Round(barBounds.Width * progress / 100m);
				if (progressWidth > 0)
					e.Graphics.FillRectangle(progressBrush, new Rectangle(barBounds.X, barBounds.Y, progressWidth, barBounds.Height));

				string text = $"{progress:0.#}%";
				using (var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
					e.Graphics.DrawString(text, e.CellStyle.Font, textBrush, e.CellBounds, format);
			}

			e.Handled = true;
		}

		private void clockTimer_Tick(object sender, EventArgs e)
		{
			UpdateClock();
		}

		private void UpdateClock()
		{
			lblDateTime.Text = DateTime.Now.ToString("MMM dd, yyyy | hh:mm tt", CultureInfo.InvariantCulture);
		}

		private void GoalPlanningForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			clockTimer.Stop();
		}

		private void GoalPlanningForm_Resize(object sender, EventArgs e)
		{
			if (pnlContent != null)
			{
				int horizontalPadding = Math.Max(24, (pnlContent.ClientSize.Width - 1200) / 2);
				pnlContent.Padding = new Padding(horizontalPadding, 0, horizontalPadding, 0);
			}

			if (categoryLayout != null)
			{
				int buttonGroupWidth = button1.Width + button2.Width + button3.Width
					+ button1.Margin.Horizontal + button2.Margin.Horizontal + button3.Margin.Horizontal;
				int categoryPadding = Math.Max(0, (categoryLayout.ClientSize.Width - buttonGroupWidth) / 2);
				categoryLayout.Padding = new Padding(categoryPadding, 20, categoryPadding, 20);
			}

			lblDateTime.Location = new System.Drawing.Point(Math.Max(0, ClientSize.Width - lblDateTime.Width - 24), 20);
		}

		private void ShowValidation(string message)
		{
			lblValidation.ForeColor = System.Drawing.Color.Firebrick;
			lblValidation.Text = message;
		}
	}
}