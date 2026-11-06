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
			var root = new TableLayoutPanel { Dock = DockStyle.Fill, MinimumSize = new Size(900, 820), Padding = new Padding(10), ColumnCount = 1, RowCount = 4, BackColor = Color.FromArgb(245, 247, 250) };
			root.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
			root.RowStyles.Add(new RowStyle(SizeType.Absolute, 108));
			root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
			root.RowStyles.Add(new RowStyle(SizeType.Absolute, 44));

			var header = new Panel { Dock = DockStyle.Fill };
			lblTitle = new Label { Text = "SPENDING ANALYTICS", Location = new Point(4, 0), AutoSize = true, Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.FromArgb(8, 55, 115) };
			lblSubtitle = new Label { Text = "ANALYZE YOUR ACTUAL SPENDING DATA", Location = new Point(7, 32), AutoSize = true, Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = Color.FromArgb(55, 75, 100) };
			header.Controls.Add(lblTitle);
			header.Controls.Add(lblSubtitle);
			root.Controls.Add(header, 0, 0);

			pnlOverview = Section("1. OVERVIEW SUMMARY", 0, 0, 0, 0);
			pnlOverview.Dock = DockStyle.Fill;
			var overviewCards = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10, 7, 10, 7), ColumnCount = 4, RowCount = 1 };
			for (int i = 0; i < 4; i++) overviewCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
			pnlOverview.Controls.Add(overviewCards);
			lblMonthlyCashIn = CardLabel("TOTAL CASH IN", 0, 0, Color.FromArgb(35, 112, 205), overviewCards);
			lblMonthlyWithdrawn = CardLabel("TOTAL WITHDRAWN", 0, 0, Color.FromArgb(80, 160, 45), overviewCards);
			lblCurrentBalance = CardLabel("CURRENT BALANCE", 0, 0, Color.FromArgb(245, 140, 20), overviewCards);
			lblDailyAverage = CardLabel("DAILY AVERAGE SPENT", 0, 0, Color.FromArgb(116, 75, 180), overviewCards);
			root.Controls.Add(pnlOverview, 0, 1);

			var main = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Padding = new Padding(0, 4, 0, 4) };
			main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
			main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
			var left = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(0, 0, 4, 0) };
			left.RowStyles.Add(new RowStyle(SizeType.Percent, 43));
			left.RowStyles.Add(new RowStyle(SizeType.Percent, 57));
			var right = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(4, 0, 0, 0) };
			right.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
			right.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

			pnlCategories = Section("2. SPENDING BY SECTION", 0, 0, 0, 0);
			pnlCategories.Dock = DockStyle.Fill;
			var categoriesBody = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
			categoriesBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));
			categoriesBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64));
			categoriesBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
			categoriesBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
			pieChart = ChartPanel(0, 0, 0, 0, categoriesBody, pieChart_Paint);
			categoriesBody.Controls.Add(pieChart, 0, 0);
			var categoryHost = new Panel { Dock = DockStyle.Fill, Padding = new Padding(4, 8, 8, 2), BackColor = Color.White };
			categoryGrid = new DataGridView();
			ConfigureGrid(categoryGrid, 0, 0, 0, 0, categoryHost);
			categoryGrid.Columns.Add("Section", "Section"); categoryGrid.Columns.Add("Spent", "Monthly Spent"); categoryGrid.Columns.Add("Percent", "%"); categoryGrid.Columns.Add("Available", "Available Balance");
			lblCategoryEmpty = EmptyLabel("No withdrawals are recorded for this month.", 0, 0, categoryHost);
			lblCategoryEmpty.Dock = DockStyle.Fill;
			lblCategoryEmpty.TextAlign = ContentAlignment.MiddleCenter;
			categoriesBody.Controls.Add(categoryHost, 1, 0);
			lblTotalSpent = new Label { AutoSize = true, Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(8, 80, 145), TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(8, 0, 0, 0) };
			categoriesBody.Controls.Add(lblTotalSpent, 1, 1);
			pnlCategories.Controls.Add(categoriesBody);

			pnlTrend = Section("3. SPENDING TREND (THIS MONTH)", 0, 0, 0, 0);
			pnlTrend.Dock = DockStyle.Fill;
			trendChart = ChartPanel(0, 0, 0, 0, pnlTrend, trendChart_Paint);
			trendChart.Dock = DockStyle.Fill;
			trendChart.Margin = new Padding(8, 8, 8, 8);
			left.Controls.Add(pnlCategories, 0, 0);
			left.Controls.Add(pnlTrend, 0, 1);

			pnlRecent = Section("4. RECENT TRANSACTIONS", 0, 0, 0, 0);
			pnlRecent.Dock = DockStyle.Fill;
			var recentBody = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(8) };
			recentBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
			recentBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
			var transactionHost = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
			transactionGrid = new DataGridView();
			ConfigureGrid(transactionGrid, 0, 0, 0, 0, transactionHost);
			transactionGrid.Columns.Add("Type", "Type"); transactionGrid.Columns.Add("Section", "Section"); transactionGrid.Columns.Add("Amount", "Amount"); transactionGrid.Columns.Add("Date", "Date and Time");
			lblTransactionEmpty = EmptyLabel("No transactions available.", 0, 0, transactionHost);
			lblTransactionEmpty.Dock = DockStyle.Fill;
			lblTransactionEmpty.TextAlign = ContentAlignment.MiddleCenter;
			recentBody.Controls.Add(transactionHost, 0, 0);
			btnViewAll = ActionButton("VIEW ALL TRANSACTIONS", 0, 0, 260, recentBody, btnViewAll_Click);
			recentBody.Controls.Add(btnViewAll, 0, 1);
			pnlRecent.Controls.Add(recentBody);

			pnlInsights = Section("5. INSIGHTS", 0, 0, 0, 0);
			pnlInsights.Dock = DockStyle.Fill;
			insightsList = new FlowLayoutPanel { Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle, AutoScroll = true, FlowDirection = FlowDirection.TopDown, WrapContents = false, Padding = new Padding(10), BackColor = Color.White };
			pnlInsights.Controls.Add(insightsList);
			right.Controls.Add(pnlRecent, 0, 0);
			right.Controls.Add(pnlInsights, 0, 1);
			main.Controls.Add(left, 0, 0);
			main.Controls.Add(right, 1, 0);
			root.Controls.Add(main, 0, 2);

			var footer = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 1 };
			footer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
			footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
			footer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170));
			btnBack = ActionButton("BACK", 0, 0, 140, footer, btnBack_Click);
			btnExport = ActionButton("EXPORT REPORT", 0, 0, 170, footer, btnExport_Click);
			footer.Controls.Remove(btnBack); footer.Controls.Remove(btnExport);
			footer.Controls.Add(btnBack, 0, 0); footer.Controls.Add(btnExport, 2, 0);
			root.Controls.Add(footer, 0, 3);
			pnlScroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.FromArgb(245, 247, 250) };
			pnlScroll.Controls.Add(root);
			BackColor = Color.FromArgb(245, 247, 250);
			ClientSize = new Size(1100, 760);
			Controls.Add(pnlScroll);
			FormBorderStyle = FormBorderStyle.None;
			WindowState = FormWindowState.Maximized;
			Name = "SpendingAnalyticsForm";
			Text = "Spending Analytics";
			Load += SpendingAnalyticsForm_Load;
		}

		private Panel Section(string title, int x, int y, int width, int height)
		{
			var panel = new Panel { BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Location = new Point(x, y), Size = new Size(width, height) };
			panel.Controls.Add(new Label { Text = title, BackColor = Color.FromArgb(8, 55, 115), ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold), Dock = DockStyle.Top, Height = 28, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(12, 0, 0, 0) });
			return panel;
		}

		private Label CardLabel(string title, int x, int y, Color color, Control parent)
		{
			var panel = new Panel { Location = new Point(x, y), Size = new Size(220, 75), Dock = DockStyle.Fill, Margin = new Padding(4), BackColor = Color.FromArgb(248, 249, 251), BorderStyle = BorderStyle.FixedSingle };
			panel.Controls.Add(new Label { Text = title, Location = new Point(12, 10), AutoSize = true, Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = color });
			var value = new Label { Text = "₱0", Location = new Point(12, 32), AutoSize = true, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.FromArgb(30, 30, 30) };
			panel.Controls.Add(value); parent.Controls.Add(panel); return value;
		}

		private Panel ChartPanel(int x, int y, int width, int height, Control parent, PaintEventHandler paint)
		{
			var panel = new Panel { Location = new Point(x, y), Size = new Size(width, height), Dock = DockStyle.Fill, BackColor = Color.White }; panel.Paint += paint; parent.Controls.Add(panel); return panel;
		}

		private Label EmptyLabel(string text, int x, int y, Control parent)
		{
			var label = new Label { Text = text, Location = new Point(x, y), AutoSize = true, ForeColor = Color.Gray, Font = new Font("Segoe UI", 10, FontStyle.Italic) }; parent.Controls.Add(label); return label;
		}

		private Button ActionButton(string text, int x, int y, int width, Control parent, EventHandler click)
		{
			var button = new Button { Text = text, Location = new Point(x, y), Size = new Size(width, 38), Dock = DockStyle.Fill, Margin = new Padding(0, 2, 0, 2), BackColor = Color.FromArgb(8, 80, 145), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) }; button.Click += click; parent.Controls.Add(button); return button;
		}

		private void ConfigureGrid(DataGridView grid, int x, int y, int width, int height, Control parent)
		{
			grid.Location = new Point(x, y); grid.Size = new Size(width, height); grid.Dock = DockStyle.Fill; grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false; grid.ReadOnly = true; grid.RowHeadersVisible = false; grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; grid.BackgroundColor = Color.White; grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; parent.Controls.Add(grid);
		}

		private Panel pnlScroll, pnlOverview, pnlCategories, pnlTrend, pnlRecent, pnlInsights;
		private Label lblTitle, lblSubtitle, lblMonthlyCashIn, lblMonthlyWithdrawn, lblCurrentBalance, lblDailyAverage, lblTotalSpent, lblCategoryEmpty, lblTransactionEmpty;
		private DataGridView categoryGrid, transactionGrid;
		private Panel pieChart, trendChart;
		private FlowLayoutPanel insightsList;
		private Button btnViewAll, btnBack, btnExport;
	}
}