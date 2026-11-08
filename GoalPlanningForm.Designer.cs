using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class GoalPlanningForm
	{
		private IContainer components = null;
		private Panel pnlHeader;
		private Label lblAppName;
		private Label lblAppSubtitle;
		private Panel pnlContent;
		private Label lblTitle;
		private Label lblSubtitle;
		private Panel pnlStep1;
		private Label lblStep1;
		private Label lblChooseCategory;
		private FlowLayoutPanel categoryLayout;
		private Panel pnlStep2;
		private Label lblStep2;
		private TableLayoutPanel detailsLayout;
		private Label lblAmount;
		private Label lblDate;
		private TextBox textBox1;
		private TextBox txtTargetDate;
		private Label lblValidation;
		private TableLayoutPanel actionLayout;
		private Button button4;
		private Button button6;
		private Button button5;
		private Button button1;
		private Button button2;
		private Button button3;
		private Panel pnlFooter;
		private Panel pnlSecurityFooter;
		private Label lblSecurity;
		private Label lblDateTime;
		private System.Windows.Forms.Timer clockTimer;
		private Panel pnlSavedGoals;
		private Label lblSavedGoals;
		private Label lblNoGoals;
		private DataGridView savedGoalsGrid;

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				clockTimer?.Dispose();
				components?.Dispose();
			}

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new Container();
			pnlHeader = new Panel();
			lblAppName = new Label();
			lblAppSubtitle = new Label();
			pnlContent = new Panel();
			lblTitle = new Label();
			lblSubtitle = new Label();
			pnlStep1 = new Panel();
			lblStep1 = new Label();
			lblChooseCategory = new Label();
			categoryLayout = new FlowLayoutPanel();
			button1 = CreateCategoryButton("A\nSAVINGS", Color.FromArgb(43, 125, 55));
			button2 = CreateCategoryButton("B\nWANTS", Color.FromArgb(29, 109, 190));
			button3 = CreateCategoryButton("C\nNEEDS", Color.FromArgb(239, 124, 9));
			pnlStep2 = new Panel();
			lblStep2 = new Label();
			detailsLayout = new TableLayoutPanel();
			lblAmount = new Label();
			lblDate = new Label();
			textBox1 = new TextBox();
			txtTargetDate = new TextBox();
			lblValidation = new Label();
		actionLayout = new TableLayoutPanel();
			button4 = new Button();
			button6 = new Button();
			button5 = new Button();
			pnlFooter = new Panel();
			pnlSecurityFooter = new Panel();
			lblSecurity = new Label();
			lblDateTime = new Label();
			clockTimer = new System.Windows.Forms.Timer(components);
			pnlSavedGoals = new Panel();
			lblSavedGoals = new Label();
			lblNoGoals = new Label();
			savedGoalsGrid = new DataGridView();
			pnlHeader.SuspendLayout();
			pnlContent.SuspendLayout();
			pnlStep1.SuspendLayout();
			categoryLayout.SuspendLayout();
			pnlStep2.SuspendLayout();
			detailsLayout.SuspendLayout();
			actionLayout.SuspendLayout();
			pnlFooter.SuspendLayout();
			pnlSecurityFooter.SuspendLayout();
			((ISupportInitialize)savedGoalsGrid).BeginInit();
			SuspendLayout();

			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblAppSubtitle);
			pnlHeader.Controls.Add(lblAppName);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Height = 76;
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(96, 13);
			lblAppName.Text = "SMART CASH DISBURSEMENT";
			lblAppSubtitle.AutoSize = true;
			lblAppSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			lblAppSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblAppSubtitle.Location = new Point(98, 42);
			lblAppSubtitle.Text = "BUDGETING MACHINE";

			pnlContent.BackColor = Color.WhiteSmoke;
			pnlContent.AutoScroll = true;
			pnlContent.Controls.Add(pnlSavedGoals);
			pnlContent.Controls.Add(pnlStep2);
			pnlContent.Controls.Add(pnlStep1);
			pnlContent.Controls.Add(lblSubtitle);
			pnlContent.Controls.Add(lblTitle);
			pnlContent.Dock = DockStyle.Fill;
			pnlSavedGoals.BackColor = Color.White;
			pnlSavedGoals.BorderStyle = BorderStyle.FixedSingle;
			pnlSavedGoals.Dock = DockStyle.Top;
			pnlSavedGoals.Height = 250;
			pnlSavedGoals.Padding = new Padding(12, 0, 12, 12);
			pnlSavedGoals.Controls.Add(savedGoalsGrid);
			pnlSavedGoals.Controls.Add(lblNoGoals);
			pnlSavedGoals.Controls.Add(lblSavedGoals);
			lblSavedGoals.BackColor = Color.FromArgb(7, 57, 113);
			lblSavedGoals.Dock = DockStyle.Top;
			lblSavedGoals.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			lblSavedGoals.ForeColor = Color.White;
			lblSavedGoals.Height = 44;
			lblSavedGoals.Text = "SAVED GOALS & PROGRESS";
			lblSavedGoals.TextAlign = ContentAlignment.MiddleCenter;
			lblNoGoals.Dock = DockStyle.Fill;
			lblNoGoals.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblNoGoals.ForeColor = Color.FromArgb(20, 42, 78);
			lblNoGoals.Text = "No saved goals yet.";
			lblNoGoals.TextAlign = ContentAlignment.MiddleCenter;
			savedGoalsGrid.AllowUserToAddRows = false;
			savedGoalsGrid.AllowUserToDeleteRows = false;
			savedGoalsGrid.AllowUserToResizeRows = false;
			savedGoalsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			savedGoalsGrid.BackgroundColor = Color.White;
			savedGoalsGrid.BorderStyle = BorderStyle.None;
			savedGoalsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 42, 78);
			savedGoalsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			savedGoalsGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			savedGoalsGrid.ColumnHeadersHeight = 32;
			savedGoalsGrid.Dock = DockStyle.Fill;
			savedGoalsGrid.EnableHeadersVisualStyles = false;
			savedGoalsGrid.ReadOnly = true;
			savedGoalsGrid.RowHeadersVisible = false;
			savedGoalsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			savedGoalsGrid.Columns.Add("Category", "Category");
			savedGoalsGrid.Columns.Add("Target", "Target Amount");
			savedGoalsGrid.Columns.Add("Balance", "Current Balance");
			savedGoalsGrid.Columns.Add("Progress", "Progress");
			savedGoalsGrid.Columns.Add("Remaining", "Remaining");
			savedGoalsGrid.Columns.Add("TargetDate", "Target Date");
			savedGoalsGrid.Columns.Add("Status", "Status");
			lblTitle.Dock = DockStyle.Top;
			lblTitle.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
			lblTitle.ForeColor = Color.FromArgb(8, 57, 113);
			lblTitle.Height = 51;
			lblTitle.Text = "GOAL PLANNING HUB";
			lblTitle.TextAlign = ContentAlignment.BottomCenter;
			lblSubtitle.Dock = DockStyle.Top;
			lblSubtitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
			lblSubtitle.ForeColor = Color.FromArgb(20, 42, 78);
			lblSubtitle.Height = 42;
			lblSubtitle.Text = "SET & TRACK SAVINGS TARGETS";
			lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

			ConfigureSection(pnlStep1, lblStep1, "STEP 1: SELECT CATEGORY");
			pnlStep1.Controls.Add(categoryLayout);
			pnlStep1.Controls.Add(lblChooseCategory);
			pnlStep1.Controls.Add(lblStep1);
			pnlStep1.Dock = DockStyle.Top;
			pnlStep1.Height = 270;
			lblChooseCategory.Dock = DockStyle.Top;
			lblChooseCategory.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
			lblChooseCategory.ForeColor = Color.FromArgb(20, 42, 78);
			lblChooseCategory.Height = 48;
			lblChooseCategory.Text = "CHOOSE A CATEGORY (PRESS A, B, OR C)";
			lblChooseCategory.TextAlign = ContentAlignment.MiddleCenter;
			categoryLayout.AutoSize = false;
			categoryLayout.Dock = DockStyle.Fill;
			categoryLayout.FlowDirection = FlowDirection.LeftToRight;
			categoryLayout.Padding = new Padding(42, 20, 42, 20);
			categoryLayout.WrapContents = false;
			categoryLayout.Controls.Add(button1);
			categoryLayout.Controls.Add(button2);
			categoryLayout.Controls.Add(button3);

			ConfigureSection(pnlStep2, lblStep2, "STEP 2: ENTER DETAILS");
			pnlStep2.Controls.Add(detailsLayout);
			pnlStep2.Controls.Add(lblStep2);
			pnlStep2.Dock = DockStyle.Top;
			pnlStep2.Height = 178;
			detailsLayout.ColumnCount = 2;
			detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			detailsLayout.Dock = DockStyle.Fill;
			detailsLayout.Padding = new Padding(28, 12, 28, 15);
			detailsLayout.RowCount = 2;
			detailsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
			detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			detailsLayout.Controls.Add(lblAmount, 0, 0);
			detailsLayout.Controls.Add(lblDate, 1, 0);
			detailsLayout.Controls.Add(textBox1, 0, 1);
			detailsLayout.Controls.Add(txtTargetDate, 1, 1);
			ConfigureInputLabel(lblAmount, "ENTER AMOUNT (₱)");
			ConfigureInputLabel(lblDate, "ENTER DATE (YYYY-MM-DD)");
			lblAmount.Dock = DockStyle.Fill;
			lblAmount.Margin = new Padding(0, 0, 18, 0);
			lblDate.Dock = DockStyle.Fill;
			lblDate.Margin = new Padding(18, 0, 0, 0);
			textBox1.Dock = DockStyle.Fill;
			textBox1.Font = new Font("Segoe UI", 14F);
			textBox1.Margin = new Padding(0, 2, 18, 0);
			textBox1.MaxLength = 18;
			textBox1.PlaceholderText = "0.00";
			txtTargetDate.Dock = DockStyle.Fill;
			txtTargetDate.Font = new Font("Segoe UI", 14F);
			txtTargetDate.Margin = new Padding(18, 2, 0, 0);
			txtTargetDate.MaxLength = 10;
			txtTargetDate.PlaceholderText = "YYYY-MM-DD";

			actionLayout.ColumnCount = 4;
			actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
			actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
			actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
			actionLayout.Controls.Add(button4, 0, 0);
			actionLayout.Controls.Add(button6, 1, 0);
			actionLayout.Controls.Add(button5, 3, 0);
			actionLayout.BackColor = Color.FromArgb(8, 52, 105);
			actionLayout.Dock = DockStyle.Top;
			actionLayout.Height = 52;
			actionLayout.Padding = new Padding(24, 0, 24, 0);
			actionLayout.RowCount = 1;
			actionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			ConfigureActionButton(button4, "←  BACK", Color.FromArgb(110, 110, 110));
			ConfigureActionButton(button6, "CLEAR", Color.FromArgb(90, 100, 115));
			ConfigureActionButton(button5, "✓  CONFIRM", Color.FromArgb(39, 125, 48));
			button4.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			button4.BackColor = Color.FromArgb(90, 100, 115);
			button4.Cursor = Cursors.Hand;
			button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			button4.Margin = new Padding(0, 7, 0, 0);
			button4.Size = new Size(110, 38);
			button5.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			button5.BackColor = Color.FromArgb(10, 125, 55);
			button5.Cursor = Cursors.Hand;
			button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			button5.Margin = new Padding(0, 7, 0, 0);
			button5.Size = new Size(150, 38);
			button6.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			button6.BackColor = Color.FromArgb(90, 100, 115);
			button6.Cursor = Cursors.Hand;
			button6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			button6.Margin = new Padding(0, 7, 0, 0);
			button6.Size = new Size(110, 38);

			lblValidation.Dock = DockStyle.Bottom;
			lblValidation.ForeColor = Color.Firebrick;
			lblValidation.Height = 25;
			lblValidation.TextAlign = ContentAlignment.MiddleCenter;
			pnlContent.Controls.Add(lblValidation);

			pnlFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlFooter.Controls.Add(pnlSecurityFooter);
			pnlFooter.Controls.Add(actionLayout);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Height = 116;
			pnlSecurityFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlSecurityFooter.Controls.Add(lblDateTime);
			pnlSecurityFooter.Controls.Add(lblSecurity);
			pnlSecurityFooter.Dock = DockStyle.Fill;
			lblSecurity.AutoSize = true;
			lblSecurity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblSecurity.ForeColor = Color.White;
			lblSecurity.Location = new Point(24, 8);
			lblSecurity.Text = "SECURE SYSTEM\r\nYour security is our priority.";
			lblDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lblDateTime.Font = new Font("Segoe UI", 10F);
			lblDateTime.ForeColor = Color.White;
			lblDateTime.Location = new Point(700, 20);
			lblDateTime.Size = new Size(420, 25);
			lblDateTime.TextAlign = ContentAlignment.MiddleRight;
			clockTimer.Interval = 1000;
			clockTimer.Tick += clockTimer_Tick;

			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.WhiteSmoke;
			ClientSize = new Size(1152, 768);
			Controls.Add(pnlContent);
			Controls.Add(pnlFooter);
			Controls.Add(pnlHeader);
			Font = new Font("Segoe UI", 10F);
			FormBorderStyle = FormBorderStyle.None;
			KeyPreview = true;
			Name = "GoalPlanningForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Goal Planning Hub";
			WindowState = FormWindowState.Maximized;
			Load += GoalPlanningForm_Load;
			KeyDown += GoalPlanningForm_KeyDown;
			Resize += GoalPlanningForm_Resize;
			FormClosed += GoalPlanningForm_FormClosed;
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlContent.ResumeLayout(false);
			pnlStep1.ResumeLayout(false);
			categoryLayout.ResumeLayout(false);
			pnlStep2.ResumeLayout(false);
			detailsLayout.ResumeLayout(false);
			detailsLayout.PerformLayout();
			actionLayout.ResumeLayout(false);
			pnlSecurityFooter.ResumeLayout(false);
			pnlSecurityFooter.PerformLayout();
			pnlFooter.ResumeLayout(false);
			pnlFooter.PerformLayout();
			((ISupportInitialize)savedGoalsGrid).EndInit();
			ResumeLayout(false);
		}

		private static Button CreateCategoryButton(string text, Color color)
		{
			return new Button
			{
				BackColor = Color.White,
				FlatStyle = FlatStyle.Flat,
				Font = new Font("Segoe UI", 18F, FontStyle.Bold),
				ForeColor = color,
				Margin = new Padding(8),
				Size = new Size(280, 145),
				Text = text,
				UseVisualStyleBackColor = false
			};
		}

		private static void ConfigureSection(Panel panel, Label label, string text)
		{
			panel.BackColor = Color.White;
			panel.BorderStyle = BorderStyle.FixedSingle;
			label.BackColor = Color.FromArgb(7, 57, 113);
			label.Dock = DockStyle.Top;
			label.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			label.ForeColor = Color.White;
			label.Height = 44;
			label.Text = text;
			label.TextAlign = ContentAlignment.MiddleCenter;
		}

		private static void ConfigureInputLabel(Label label, string text)
		{
			label.AutoSize = false;
			label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			label.ForeColor = Color.FromArgb(20, 42, 78);
			label.Text = text;
			label.TextAlign = ContentAlignment.BottomLeft;
		}

		private static void ConfigureActionButton(Button button, string text, Color color)
		{
			button.BackColor = color;
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			button.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			button.ForeColor = Color.White;
			button.Margin = new Padding(8, 0, 8, 0);
			button.Size = new Size(280, 55);
			button.Text = text;
			button.UseVisualStyleBackColor = false;
		}
	}
}