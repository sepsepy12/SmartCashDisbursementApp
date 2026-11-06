using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	public partial class SpendingAnalyticsForm : Form
	{
		private readonly int userId;
		private readonly BudgetRepository budgetRepo = new BudgetRepository();
		private decimal monthlyCashIn;
		private decimal monthlyWithdrawn;
		private decimal currentBalance;
		private decimal dailyAverage;
		private List<AnalyticsCategory> categories = new List<AnalyticsCategory>();
		private List<DailySpending> dailySpending = new List<DailySpending>();
		private List<RecentTransaction> recentTransactions = new List<RecentTransaction>();
		private DateTime monthStart;

		public SpendingAnalyticsForm(int userId)
		{
			InitializeComponent();
			this.userId = userId;
		}

		private void SpendingAnalyticsForm_Load(object sender, EventArgs e) => RefreshAnalytics();

		private void RefreshAnalytics()
		{
			try
			{
				monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
				DateTime nextMonthStart = monthStart.AddMonths(1);
				monthlyCashIn = budgetRepo.GetMonthlyTransactionTotal(userId, "deposit", monthStart, nextMonthStart);
				monthlyWithdrawn = budgetRepo.GetMonthlyTransactionTotal(userId, "withdrawal", monthStart, nextMonthStart);
				currentBalance = budgetRepo.GetOverallBalance(userId);
				dailyAverage = monthlyWithdrawn / DateTime.Today.Day;
				categories = budgetRepo.GetAnalyticsCategories(userId, monthStart, nextMonthStart);
				dailySpending = budgetRepo.GetDailyWithdrawals(userId, monthStart, nextMonthStart);
				recentTransactions = budgetRepo.GetRecentTransactions(userId);
				PopulateControls();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Spending analytics could not be loaded.\n\n{ex.Message}", "Analytics Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PopulateControls()
		{
			lblMonthlyCashIn.Text = FormatMoney(monthlyCashIn);
			lblMonthlyWithdrawn.Text = FormatMoney(monthlyWithdrawn);
			lblCurrentBalance.Text = FormatMoney(currentBalance);
			lblDailyAverage.Text = FormatMoney(dailyAverage);
			lblTotalSpent.Text = $"Total spent this month: {FormatMoney(monthlyWithdrawn)}";

			categoryGrid.Rows.Clear();
			foreach (AnalyticsCategory category in categories)
			{
				decimal percentage = monthlyWithdrawn == 0 ? 0 : category.MonthlyWithdrawals / monthlyWithdrawn * 100;
				categoryGrid.Rows.Add(category.Name, FormatMoney(category.MonthlyWithdrawals), $"{percentage:0.0}%", FormatMoney(category.AvailableBalance));
			}
			categoryGrid.Visible = categories.Count > 0;
			lblCategoryEmpty.Visible = categories.Count == 0;

			transactionGrid.Rows.Clear();
			foreach (RecentTransaction transaction in recentTransactions)
			{
				transactionGrid.Rows.Add(
					transaction.Type.Equals("deposit", StringComparison.OrdinalIgnoreCase) ? "CASH IN" : "WITHDRAW",
					transaction.CategoryName,
					FormatMoney(transaction.Amount),
					transaction.CreatedAt.ToString("MMM d, yyyy h:mm tt"));
			}
			transactionGrid.Visible = recentTransactions.Count > 0;
			lblTransactionEmpty.Visible = recentTransactions.Count == 0;
			insightsList.Items.Clear();
			foreach (string insight in BuildInsights())
				insightsList.Items.Add(insight);

			pieChart.Invalidate();
			trendChart.Invalidate();
		}

		private List<string> BuildInsights()
		{
			var insights = new List<string>();
			if (monthlyCashIn == 0 && monthlyWithdrawn == 0)
				return new List<string> { "No transaction history is available yet. Add a cash-in or withdrawal to receive personalized insights." };

			if (monthlyWithdrawn == 0)
				insights.Add("GOOD JOB: You have no withdrawals recorded this month. Continue tracking your spending as transactions occur.");
			else if (monthlyCashIn > 0 && monthlyWithdrawn <= monthlyCashIn)
				insights.Add($"GOOD JOB: This month's withdrawals are {FormatMoney(monthlyCashIn - monthlyWithdrawn)} lower than this month's cash in.");

			AnalyticsCategory highest = categories.OrderByDescending(c => c.MonthlyWithdrawals).FirstOrDefault();
			if (highest != null && highest.MonthlyWithdrawals > 0)
			{
				decimal share = highest.MonthlyWithdrawals / monthlyWithdrawn * 100;
				insights.Add($"ATTENTION: {highest.Name} is your highest-spending section this month at {share:0.0}% of monthly withdrawals ({FormatMoney(highest.MonthlyWithdrawals)}).");
			}

			AnalyticsCategory savings = categories.FirstOrDefault(c => c.Name.Equals("Savings", StringComparison.OrdinalIgnoreCase));
			if (savings != null && savings.AvailableBalance <= 0)
				insights.Add("TIP: Your Savings available balance is not positive. Consider reviewing future cash-in allocations before making discretionary withdrawals.");
			else if (currentBalance < 0)
				insights.Add("TIP: Your overall transaction balance is negative. Review recent withdrawals and available category balances before spending more.");
			else if (insights.Count == 1)
				insights.Add("TIP: Keep reviewing this dashboard after each transaction so your spending pattern stays visible.");

			return insights;
		}

		private void btnViewAll_Click(object sender, EventArgs e)
		{
			Hide();
			var history = new TransactionHistoryForm(userId);
			history.FormClosed += (s, args) => Show();
			history.Show();
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog { Filter = "CSV report (*.csv)|*.csv", FileName = $"spending-analytics-{DateTime.Today:yyyy-MM}.csv" })
			{
				if (dialog.ShowDialog(this) != DialogResult.OK)
					return;

				var report = new StringBuilder();
				report.AppendLine("Spending Analytics Report");
				report.AppendLine($"Generated,{Csv(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))}");
				report.AppendLine("Metric,Amount");
				report.AppendLine($"Monthly cash in,{Csv(monthlyCashIn.ToString(CultureInfo.InvariantCulture))}");
				report.AppendLine($"Monthly withdrawn,{Csv(monthlyWithdrawn.ToString(CultureInfo.InvariantCulture))}");
				report.AppendLine($"Current balance,{Csv(currentBalance.ToString(CultureInfo.InvariantCulture))}");
				report.AppendLine($"Daily average spent,{Csv(dailyAverage.ToString(CultureInfo.InvariantCulture))}");
				report.AppendLine();
				report.AppendLine("Category,Monthly Withdrawals,Percentage,Available Balance");
				foreach (AnalyticsCategory category in categories)
					report.AppendLine(string.Join(",", Csv(category.Name), Csv(category.MonthlyWithdrawals.ToString(CultureInfo.InvariantCulture)), Csv((monthlyWithdrawn == 0 ? 0 : category.MonthlyWithdrawals / monthlyWithdrawn * 100).ToString("0.0", CultureInfo.InvariantCulture)), Csv(category.AvailableBalance.ToString(CultureInfo.InvariantCulture))));
				report.AppendLine();
				report.AppendLine("Daily spending date,Amount");
				foreach (DateTime date in EachDay(monthStart, monthStart.AddMonths(1)))
					report.AppendLine($"{date:yyyy-MM-dd},{Csv((dailySpending.FirstOrDefault(d => d.Date.Date == date)?.Amount ?? 0).ToString(CultureInfo.InvariantCulture))}");
				report.AppendLine();
				report.AppendLine("Type,Section,Amount,Date and Time");
				foreach (RecentTransaction transaction in recentTransactions)
					report.AppendLine(string.Join(",", Csv(transaction.Type), Csv(transaction.CategoryName), Csv(transaction.Amount.ToString(CultureInfo.InvariantCulture)), Csv(transaction.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))));
				report.AppendLine();
				report.AppendLine("Insights");
				foreach (string insight in BuildInsights()) report.AppendLine(Csv(insight));
				File.WriteAllText(dialog.FileName, report.ToString(), Encoding.UTF8);
				MessageBox.Show("The analytics report was exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private static IEnumerable<DateTime> EachDay(DateTime start, DateTime exclusiveEnd)
		{
			for (DateTime day = start; day < exclusiveEnd; day = day.AddDays(1)) yield return day;
		}

		private static string Csv(string value) => $"\"{value.Replace("\"", "\"\"")}\"";
		private static string FormatMoney(decimal amount) => $"₱{Math.Round(amount, 0):N0}";
		private void btnBack_Click(object sender, EventArgs e) => Close();

		private void pieChart_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			decimal total = categories.Sum(c => c.MonthlyWithdrawals);
			if (total <= 0)
			{
				e.Graphics.DrawString("No withdrawals this month", Font, Brushes.Gray, 25, pieChart.Height / 2 - 10);
				return;
			}
			Rectangle bounds = new Rectangle(20, 15, Math.Min(pieChart.Width - 40, pieChart.Height - 30), Math.Min(pieChart.Width - 40, pieChart.Height - 30));
			float start = -90;
			Color[] colors = { Color.FromArgb(35, 112, 205), Color.FromArgb(80, 160, 45), Color.FromArgb(245, 140, 20) };
			for (int i = 0; i < categories.Count; i++)
			{
				float sweep = (float)(categories[i].MonthlyWithdrawals / total * 360);
				using (var brush = new SolidBrush(colors[i % colors.Length])) e.Graphics.FillPie(brush, bounds, start, sweep);
				start += sweep;
			}
		}

		private void trendChart_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Rectangle plot = new Rectangle(45, 15, trendChart.Width - 60, trendChart.Height - 45);
			using (var gridPen = new Pen(Color.Gainsboro))
			using (var axisPen = new Pen(Color.Gray))
			{
				e.Graphics.DrawLine(axisPen, plot.Left, plot.Bottom, plot.Right, plot.Bottom);
				e.Graphics.DrawLine(axisPen, plot.Left, plot.Top, plot.Left, plot.Bottom);
				for (int i = 1; i < 4; i++) e.Graphics.DrawLine(gridPen, plot.Left, plot.Top + plot.Height * i / 4, plot.Right, plot.Top + plot.Height * i / 4);
			}
			DateTime end = monthStart.AddMonths(1);
			var points = EachDay(monthStart, end).Select(day => new { day, amount = dailySpending.FirstOrDefault(d => d.Date.Date == day)?.Amount ?? 0 }).ToList();
			decimal max = Math.Max(1, points.Max(p => p.amount));
			if (points.Count > 1)
			{
				var coordinates = points.Select((p, i) => new PointF(plot.Left + i * plot.Width / (float)(points.Count - 1), plot.Bottom - (float)(p.amount / max) * plot.Height)).ToArray();
				using (var pen = new Pen(Color.FromArgb(30, 103, 205), 2)) e.Graphics.DrawLines(pen, coordinates);
			}
			e.Graphics.DrawString($"₱{max:N0}", Font, Brushes.DimGray, 3, plot.Top - 5);
			e.Graphics.DrawString("₱0", Font, Brushes.DimGray, 15, plot.Bottom - 8);
		}
	}
}