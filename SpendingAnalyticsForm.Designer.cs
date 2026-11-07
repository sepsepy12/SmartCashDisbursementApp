using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class SpendingAnalyticsForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				clockTimer?.Stop();
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			clockTimer = new System.Windows.Forms.Timer(components);
			pnlScroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.FromArgb(245, 247, 250) };
			pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(1080, 76), BackColor = Color.FromArgb(7, 57, 113), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
			pnlHeader.Controls.Add(new Label { Text = "SMART CASH DISBURSEMENT", Location = new Point(96, 13), AutoSize = true, Font = new Font("Segoe UI", 17F, FontStyle.Bold), ForeColor = Color.White });
			pnlHeader.Controls.Add(new Label { Text = "BUDGETING MACHINE", Location = new Point(98, 42), AutoSize = true, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(164, 213, 255) });
			lblTitle = new Label { Text = "SPENDING ANALYTICS", Location = new Point(24, 84), Size = new Size(1032, 36), Font = new Font("Segoe UI", 20F, FontStyle.Bold), ForeColor = Color.FromArgb(13, 49, 108), TextAlign = ContentAlignment.MiddleCenter };
			lblSubtitle = new Label { Text = "ANALYZE YOUR PAST SPENDING DATA", Location = new Point(24, 120), Size = new Size(1032, 28), Font = new Font("Segoe UI", 11F), ForeColor = Color.FromArgb(55, 75, 105), TextAlign = ContentAlignment.MiddleCenter };
			pnlOverview = Section("1. OVERVIEW SUMMARY", 20, 160, 700, 130);
			pnlCategories = Section("2. SPENDING BY SECTION", 20, 305, 700, 300);
			pnlTrend = Section("3. SPENDING TREND (LAST 14 DAYS)", 20, 620, 700, 280);
			pnlRecent = Section("4. RECENT TRANSACTIONS", 740, 160, 320, 390);
			pnlInsights = Section("5. INSIGHTS", 740, 565, 320, 335);
			lblMonthlyCashIn = CardLabel("TOTAL CASH IN", 15, 40, Color.FromArgb(35, 112, 205), pnlOverview);
			lblMonthlyWithdrawn = CardLabel("TOTAL WITHDRAWN", 185, 40, Color.FromArgb(80, 160, 45), pnlOverview);
			lblDailyAverage = CardLabel("DAILY AVERAGE SPENT", 355, 40, Color.FromArgb(116, 75, 180), pnlOverview);
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
			pnlFooter = new Panel { Dock = DockStyle.Bottom, Height = 116, BackColor = Color.FromArgb(8, 52, 105) };
			actionBar = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = Color.FromArgb(8, 52, 105) };
			pnlSecurityFooter = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(8, 52, 105) };
			lblSecurity = new Label { Text = "SECURE SYSTEM\r\nYour security is our priority.", Location = new Point(24, 8), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.White };
			lblDateTime = new Label { Location = new Point(700, 20), Size = new Size(420, 25), Font = new Font("Segoe UI", 10F), ForeColor = Color.White, Anchor = AnchorStyles.Top | AnchorStyles.Right, TextAlign = ContentAlignment.MiddleRight };
			pnlSecurityFooter.Controls.Add(lblSecurity);
			pnlSecurityFooter.Controls.Add(lblDateTime);
			pnlFooter.Controls.Add(pnlSecurityFooter);
			pnlFooter.Controls.Add(actionBar);
			btnBack = ActionButton("BACK", 24, 7, 110, actionBar, btnBack_Click);
			btnBack.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			btnBack.BackColor = Color.FromArgb(90, 100, 115);
			btnBack.Cursor = Cursors.Hand;
			btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnBack.Size = new Size(110, 38);
			btnViewAll.Size = new Size(220, 38);
			btnViewAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnExport = ActionButton("EXPORT REPORT", 880, 7, 170, actionBar, btnExport_Click);
			btnExport.BackColor = Color.FromArgb(10, 125, 55);
			btnExport.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			btnExport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			pnlScroll.Controls.AddRange(new Control[] { pnlHeader, lblTitle, lblSubtitle, pnlOverview, pnlCategories, pnlTrend, pnlRecent, pnlInsights });
			BackColor = Color.FromArgb(245, 247, 250);
			ClientSize = new Size(1100, 760);
			Controls.Add(pnlScroll);
			Controls.Add(pnlFooter);
			FormBorderStyle = FormBorderStyle.None;
			WindowState = FormWindowState.Maximized;
			Name = "SpendingAnalyticsForm";
			Text = "Spending Analytics";
			Load += SpendingAnalyticsForm_Load;
			Resize += SpendingAnalyticsForm_Resize;
			FormClosed += SpendingAnalyticsForm_FormClosed;
			clockTimer.Interval = 1000;
			clockTimer.Tick += clockTimer_Tick;
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
			var button = new Button { Text = text, Location = new Point(x, y), Size = new Size(width, 38), BackColor = Color.FromArgb(8, 80, 145), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold), UseVisualStyleBackColor = false }; button.FlatAppearance.BorderSize = 0; button.Click += click; parent.Controls.Add(button); return button;
		}

		private void ConfigureGrid(DataGridView grid, int x, int y, int width, int height, Control parent)
		{
			grid.Location = new Point(x, y); grid.Size = new Size(width, height); grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false; grid.ReadOnly = true; grid.RowHeadersVisible = false; grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; grid.BackgroundColor = Color.White; grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; parent.Controls.Add(grid);
		}

		private Panel pnlScroll, pnlHeader, pnlFooter, pnlSecurityFooter, actionBar, pnlOverview, pnlCategories, pnlTrend, pnlRecent, pnlInsights;
		private Label lblTitle, lblSubtitle, lblMonthlyCashIn, lblMonthlyWithdrawn, lblDailyAverage, lblTotalSpent, lblCategoryEmpty, lblTransactionEmpty;
		private Label lblSecurity, lblDateTime;
		private DataGridView categoryGrid, transactionGrid;
		private Panel pieChart, trendChart;
		private ListBox insightsList;
		private Button btnViewAll, btnBack, btnExport;
		private System.Windows.Forms.Timer clockTimer;
	}
}