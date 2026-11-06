using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class SpendingAnalyticsForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null) components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			pnlScroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.FromArgb(245, 247, 250) };
			pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(1080, 75), BackColor = Color.FromArgb(8, 55, 115), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
			pnlHeader.Controls.Add(new Label { Text = "SMART CASH DISBURSEMENT", Location = new Point(20, 10), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.White });
			pnlHeader.Controls.Add(new Label { Text = "BUDGETING MACHINE", Location = new Point(20, 35), AutoSize = true, Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = Color.FromArgb(190, 215, 245) });
			lblTitle = new Label { Text = "SPENDING ANALYTICS", Location = new Point(740, 12), AutoSize = true, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.White, Anchor = AnchorStyles.Top | AnchorStyles.Right };
			lblSubtitle = new Label { Text = "ANALYZE YOUR PAST SPENDING DATA", Location = new Point(740, 42), AutoSize = true, Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = Color.FromArgb(220, 230, 245), Anchor = AnchorStyles.Top | AnchorStyles.Right };
			pnlHeader.Controls.Add(lblTitle); pnlHeader.Controls.Add(lblSubtitle);
			pnlOverview = Section("1. OVERVIEW SUMMARY", 20, 95, 700, 130);
			pnlCategories = Section("2. SPENDING BY SECTION", 20, 240, 700, 300);
			pnlTrend = Section("3. SPENDING TREND (THIS MONTH)", 20, 555, 700, 280);
			pnlRecent = Section("4. RECENT TRANSACTIONS", 740, 95, 320, 390);
			pnlInsights = Section("5. INSIGHTS", 740, 500, 320, 335);
			lblMonthlyCashIn = CardLabel("TOTAL CASH IN", 15, 40, Color.FromArgb(35, 112, 205), pnlOverview);
			lblMonthlyWithdrawn = CardLabel("TOTAL WITHDRAWN", 185, 40, Color.FromArgb(80, 160, 45), pnlOverview);
			lblCurrentBalance = CardLabel("CURRENT BALANCE", 355, 40, Color.FromArgb(245, 140, 20), pnlOverview);
			lblDailyAverage = CardLabel("DAILY AVERAGE SPENT", 525, 40, Color.FromArgb(116, 75, 180), pnlOverview);
			pieChart = ChartPanel(15, 45, 300, 235, pnlCategories, pieChart_Paint);
			categoryGrid = new DataGridView();
			ConfigureGrid(categoryGrid, 330, 50, 350, 190, pnlCategories);
			categoryGrid.Columns.Add("Section", "Section"); categoryGrid.Columns.Add("Spent", "Monthly Spent"); categoryGrid.Columns.Add("Percent", "%"); categoryGrid.Columns.Add("Available", "Available Balance");
			lblCategoryEmpty = EmptyLabel("No withdrawals are recorded for this month.", 330, 125, pnlCategories);
			lblTotalSpent = new Label { AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(8, 80, 145), Location = new Point(330, 250) };
			pnlCategories.Controls.Add(lblTotalSpent);
			trendChart = ChartPanel(15, 40, 670, 225, pnlTrend, trendChart_Paint);
			transactionGrid = new DataGridView();
			ConfigureGrid(transactionGrid, 15, 45, 290, 245, pnlRecent);
			transactionGrid.Columns.Add("Type", "Type"); transactionGrid.Columns.Add("Section", "Section"); transactionGrid.Columns.Add("Amount", "Amount"); transactionGrid.Columns.Add("Date", "Date and Time");
			lblTransactionEmpty = EmptyLabel("No transactions available.", 80, 150, pnlRecent);
			btnViewAll = ActionButton("VIEW ALL TRANSACTIONS", 15, 305, 290, pnlRecent, btnViewAll_Click);
			insightsList = new ListBox { Location = new Point(15, 45), Size = new Size(290, 255), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 9), IntegralHeight = false, DrawMode = DrawMode.OwnerDrawVariable, HorizontalScrollbar = false, SelectionMode = SelectionMode.None };
			insightsList.MeasureItem += insightsList_MeasureItem;
			insightsList.DrawItem += insightsList_DrawItem;
			pnlInsights.Controls.Add(insightsList);
			pnlFooter = new Panel { Location = new Point(0, 855), Size = new Size(1080, 65), BackColor = Color.FromArgb(8, 55, 115), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
			btnBack = ActionButton("BACK", 20, 14, 140, pnlFooter, btnBack_Click);
			btnExport = ActionButton("EXPORT REPORT", 880, 14, 170, pnlFooter, btnExport_Click);
			pnlScroll.Controls.AddRange(new Control[] { pnlHeader, pnlOverview, pnlCategories, pnlTrend, pnlRecent, pnlInsights, pnlFooter });
			BackColor = Color.FromArgb(245, 247, 250);
			ClientSize = new Size(1100, 760);
			Controls.Add(pnlScroll);
			FormBorderStyle = FormBorderStyle.None;
			WindowState = FormWindowState.Maximized;
			Name = "SpendingAnalyticsForm";
			Text = "Spending Analytics";
			Load += SpendingAnalyticsForm_Load;
			Resize += SpendingAnalyticsForm_Resize;
		}

		private Panel Section(string title, int x, int y, int width, int height)
		{
			var panel = new Panel { BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Location = new Point(x, y), Size = new Size(width, height) };
			panel.Controls.Add(new Label { Text = title, BackColor = Color.FromArgb(8, 55, 115), ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold), Dock = DockStyle.Top, Height = 28, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(12, 0, 0, 0) });
			return panel;
		}

		private Label CardLabel(string title, int x, int y, Color color, Control parent)
		{
			var panel = new Panel { Location = new Point(x, y), Size = new Size(155, 75), BackColor = Color.FromArgb(248, 249, 251), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Top | AnchorStyles.Left };
			panel.Controls.Add(new Label { Text = title, Location = new Point(12, 10), AutoSize = true, Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = color });
			var value = new Label { Text = "₱0", Location = new Point(12, 32), AutoSize = true, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.FromArgb(30, 30, 30) };
			panel.Controls.Add(value); parent.Controls.Add(panel); return value;
		}

		private Panel ChartPanel(int x, int y, int width, int height, Control parent, PaintEventHandler paint)
		{
			var panel = new Panel { Location = new Point(x, y), Size = new Size(width, height), BackColor = Color.White }; panel.Paint += paint; parent.Controls.Add(panel); return panel;
		}

		private Label EmptyLabel(string text, int x, int y, Control parent)
		{
			var label = new Label { Text = text, Location = new Point(x, y), AutoSize = true, ForeColor = Color.Gray, Font = new Font("Segoe UI", 10, FontStyle.Italic) }; parent.Controls.Add(label); return label;
		}

		private Button ActionButton(string text, int x, int y, int width, Control parent, EventHandler click)
		{
			var button = new Button { Text = text, Location = new Point(x, y), Size = new Size(width, 38), BackColor = Color.FromArgb(8, 80, 145), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) }; button.Click += click; parent.Controls.Add(button); return button;
		}

		private void ConfigureGrid(DataGridView grid, int x, int y, int width, int height, Control parent)
		{
			grid.Location = new Point(x, y); grid.Size = new Size(width, height); grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false; grid.ReadOnly = true; grid.RowHeadersVisible = false; grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; grid.BackgroundColor = Color.White; grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; parent.Controls.Add(grid);
		}

		private Panel pnlScroll, pnlHeader, pnlFooter, pnlOverview, pnlCategories, pnlTrend, pnlRecent, pnlInsights;
		private Label lblTitle, lblSubtitle, lblMonthlyCashIn, lblMonthlyWithdrawn, lblCurrentBalance, lblDailyAverage, lblTotalSpent, lblCategoryEmpty, lblTransactionEmpty;
		private DataGridView categoryGrid, transactionGrid;
		private Panel pieChart, trendChart;
		private ListBox insightsList;
		private Button btnViewAll, btnBack, btnExport;
	}
}