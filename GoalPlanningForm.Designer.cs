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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			pnlHeader = new Panel();
			lblAppSubtitle = new Label();
			lblAppName = new Label();
			pnlContent = new Panel();
			pnlSavedGoals = new Panel();
			savedGoalsGrid = new DataGridView();
			dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			lblNoGoals = new Label();
			lblSavedGoals = new Label();
			pnlStep2 = new Panel();
			detailsLayout = new TableLayoutPanel();
			lblAmount = new Label();
			lblDate = new Label();
			textBox1 = new TextBox();
			txtTargetDate = new TextBox();
			lblStep2 = new Label();
			pnlStep1 = new Panel();
			categoryLayout = new FlowLayoutPanel();
			lblChooseCategory = new Label();
			lblStep1 = new Label();
			lblSubtitle = new Label();
			lblTitle = new Label();
			lblValidation = new Label();
			actionLayout = new TableLayoutPanel();
			button4 = new Button();
			button6 = new Button();
			button5 = new Button();
			pnlFooter = new Panel();
			pnlSecurityFooter = new Panel();
			lblDateTime = new Label();
			lblSecurity = new Label();
			clockTimer = new System.Windows.Forms.Timer(components);
			pnlHeader.SuspendLayout();
			pnlContent.SuspendLayout();
			pnlSavedGoals.SuspendLayout();
			((ISupportInitialize)savedGoalsGrid).BeginInit();
			pnlStep2.SuspendLayout();
			detailsLayout.SuspendLayout();
			pnlStep1.SuspendLayout();
			actionLayout.SuspendLayout();
			pnlFooter.SuspendLayout();
			pnlSecurityFooter.SuspendLayout();
			SuspendLayout();
			// 
			// pnlHeader
			// 
			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblAppSubtitle);
			pnlHeader.Controls.Add(lblAppName);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Location = new Point(0, 0);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new Size(1152, 76);
			pnlHeader.TabIndex = 2;
			// 
			// lblAppSubtitle
			// 
			lblAppSubtitle.AutoSize = true;
			lblAppSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			lblAppSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblAppSubtitle.Location = new Point(98, 42);
			lblAppSubtitle.Name = "lblAppSubtitle";
			lblAppSubtitle.Size = new Size(171, 20);
			lblAppSubtitle.TabIndex = 0;
			lblAppSubtitle.Text = "BUDGETING MACHINE";
			// 
			// lblAppName
			// 
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(96, 13);
			lblAppName.Name = "lblAppName";
			lblAppName.Size = new Size(340, 31);
			lblAppName.TabIndex = 1;
			lblAppName.Text = "SMART CASH DISBURSEMENT";
			// 
			// pnlContent
			// 
			pnlContent.AutoScroll = true;
			pnlContent.BackColor = Color.WhiteSmoke;
			pnlContent.Controls.Add(pnlSavedGoals);
			pnlContent.Controls.Add(pnlStep2);
			pnlContent.Controls.Add(pnlStep1);
			pnlContent.Controls.Add(lblSubtitle);
			pnlContent.Controls.Add(lblTitle);
			pnlContent.Controls.Add(lblValidation);
			pnlContent.Dock = DockStyle.Fill;
			pnlContent.Location = new Point(0, 76);
			pnlContent.Name = "pnlContent";
			pnlContent.Size = new Size(1152, 576);
			pnlContent.TabIndex = 0;
			// 
			// pnlSavedGoals
			// 
			pnlSavedGoals.BackColor = Color.White;
			pnlSavedGoals.BorderStyle = BorderStyle.FixedSingle;
			pnlSavedGoals.Controls.Add(savedGoalsGrid);
			pnlSavedGoals.Controls.Add(lblNoGoals);
			pnlSavedGoals.Controls.Add(lblSavedGoals);
			pnlSavedGoals.Dock = DockStyle.Top;
			pnlSavedGoals.Location = new Point(0, 541);
			pnlSavedGoals.Name = "pnlSavedGoals";
			pnlSavedGoals.Padding = new Padding(12, 0, 12, 12);
			pnlSavedGoals.Size = new Size(1135, 250);
			pnlSavedGoals.TabIndex = 0;
			// 
			// savedGoalsGrid
			// 
			savedGoalsGrid.AllowUserToAddRows = false;
			savedGoalsGrid.AllowUserToDeleteRows = false;
			savedGoalsGrid.AllowUserToResizeRows = false;
			savedGoalsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			savedGoalsGrid.BackgroundColor = Color.White;
			savedGoalsGrid.BorderStyle = BorderStyle.None;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.FromArgb(20, 42, 78);
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = Color.White;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			savedGoalsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			savedGoalsGrid.ColumnHeadersHeight = 32;
			savedGoalsGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
			savedGoalsGrid.Dock = DockStyle.Fill;
			savedGoalsGrid.EnableHeadersVisualStyles = false;
			savedGoalsGrid.Location = new Point(12, 44);
			savedGoalsGrid.Name = "savedGoalsGrid";
			savedGoalsGrid.ReadOnly = true;
			savedGoalsGrid.RowHeadersVisible = false;
			savedGoalsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			savedGoalsGrid.Size = new Size(1109, 192);
			savedGoalsGrid.TabIndex = 0;
			// 
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewTextBoxColumn1.HeaderText = "Category";
			dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewTextBoxColumn2.HeaderText = "Target Amount";
			dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			dataGridViewTextBoxColumn3.HeaderText = "Current Balance";
			dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			dataGridViewTextBoxColumn4.HeaderText = "Progress";
			dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn5
			// 
			dataGridViewTextBoxColumn5.HeaderText = "Remaining";
			dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			dataGridViewTextBoxColumn5.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn6
			// 
			dataGridViewTextBoxColumn6.HeaderText = "Target Date";
			dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			dataGridViewTextBoxColumn6.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn7
			// 
			dataGridViewTextBoxColumn7.HeaderText = "Status";
			dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			dataGridViewTextBoxColumn7.ReadOnly = true;
			// 
			// lblNoGoals
			// 
			lblNoGoals.Dock = DockStyle.Fill;
			lblNoGoals.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblNoGoals.ForeColor = Color.FromArgb(20, 42, 78);
			lblNoGoals.Location = new Point(12, 44);
			lblNoGoals.Name = "lblNoGoals";
			lblNoGoals.Size = new Size(1109, 192);
			lblNoGoals.TabIndex = 1;
			lblNoGoals.Text = "No saved goals yet.";
			lblNoGoals.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblSavedGoals
			// 
			lblSavedGoals.BackColor = Color.FromArgb(7, 57, 113);
			lblSavedGoals.Dock = DockStyle.Top;
			lblSavedGoals.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			lblSavedGoals.ForeColor = Color.White;
			lblSavedGoals.Location = new Point(12, 0);
			lblSavedGoals.Name = "lblSavedGoals";
			lblSavedGoals.Size = new Size(1109, 44);
			lblSavedGoals.TabIndex = 2;
			lblSavedGoals.Text = "SAVED GOALS & PROGRESS";
			lblSavedGoals.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// pnlStep2
			// 
			pnlStep2.Controls.Add(detailsLayout);
			pnlStep2.Controls.Add(lblStep2);
			pnlStep2.Dock = DockStyle.Top;
			pnlStep2.Location = new Point(0, 363);
			pnlStep2.Name = "pnlStep2";
			pnlStep2.Size = new Size(1135, 178);
			pnlStep2.TabIndex = 1;
			// 
			// detailsLayout
			// 
			detailsLayout.ColumnCount = 2;
			detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			detailsLayout.Controls.Add(lblAmount, 0, 0);
			detailsLayout.Controls.Add(lblDate, 1, 0);
			detailsLayout.Controls.Add(textBox1, 0, 1);
			detailsLayout.Controls.Add(txtTargetDate, 1, 1);
			detailsLayout.Dock = DockStyle.Fill;
			detailsLayout.Location = new Point(0, 0);
			detailsLayout.Name = "detailsLayout";
			detailsLayout.Padding = new Padding(28, 12, 28, 15);
			detailsLayout.RowCount = 2;
			detailsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
			detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			detailsLayout.Size = new Size(1135, 178);
			detailsLayout.TabIndex = 0;
			// 
			// lblAmount
			// 
			lblAmount.Location = new Point(31, 12);
			lblAmount.Name = "lblAmount";
			lblAmount.Size = new Size(100, 23);
			lblAmount.TabIndex = 0;
			// 
			// lblDate
			// 
			lblDate.Location = new Point(570, 12);
			lblDate.Name = "lblDate";
			lblDate.Size = new Size(100, 23);
			lblDate.TabIndex = 1;
			// 
			// textBox1
			// 
			textBox1.Dock = DockStyle.Fill;
			textBox1.Font = new Font("Segoe UI", 14F);
			textBox1.Location = new Point(28, 43);
			textBox1.Margin = new Padding(0, 2, 18, 0);
			textBox1.MaxLength = 18;
			textBox1.Name = "textBox1";
			textBox1.PlaceholderText = "0.00";
			textBox1.Size = new Size(521, 32);
			textBox1.TabIndex = 2;
			// 
			// txtTargetDate
			// 
			txtTargetDate.Dock = DockStyle.Fill;
			txtTargetDate.Font = new Font("Segoe UI", 14F);
			txtTargetDate.Location = new Point(585, 43);
			txtTargetDate.Margin = new Padding(18, 2, 0, 0);
			txtTargetDate.MaxLength = 10;
			txtTargetDate.Name = "txtTargetDate";
			txtTargetDate.PlaceholderText = "YYYY-MM-DD";
			txtTargetDate.Size = new Size(522, 32);
			txtTargetDate.TabIndex = 3;
			// 
			// lblStep2
			// 
			lblStep2.Location = new Point(0, 0);
			lblStep2.Name = "lblStep2";
			lblStep2.Size = new Size(100, 23);
			lblStep2.TabIndex = 1;
			// 
			// pnlStep1
			// 
			pnlStep1.Controls.Add(categoryLayout);
			pnlStep1.Controls.Add(lblChooseCategory);
			pnlStep1.Controls.Add(lblStep1);
			pnlStep1.Dock = DockStyle.Top;
			pnlStep1.Location = new Point(0, 93);
			pnlStep1.Name = "pnlStep1";
			pnlStep1.Size = new Size(1135, 270);
			pnlStep1.TabIndex = 2;
			// 
			// categoryLayout
			// 
			categoryLayout.Dock = DockStyle.Fill;
			categoryLayout.Location = new Point(0, 48);
			categoryLayout.Name = "categoryLayout";
			categoryLayout.Padding = new Padding(42, 20, 42, 20);
			categoryLayout.Size = new Size(1135, 222);
			categoryLayout.TabIndex = 0;
			categoryLayout.WrapContents = false;
			// 
			// lblChooseCategory
			// 
			lblChooseCategory.Dock = DockStyle.Top;
			lblChooseCategory.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
			lblChooseCategory.ForeColor = Color.FromArgb(20, 42, 78);
			lblChooseCategory.Location = new Point(0, 0);
			lblChooseCategory.Name = "lblChooseCategory";
			lblChooseCategory.Size = new Size(1135, 48);
			lblChooseCategory.TabIndex = 1;
			lblChooseCategory.Text = "CHOOSE A CATEGORY (PRESS A, B, OR C)";
			lblChooseCategory.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblStep1
			// 
			lblStep1.Location = new Point(0, 0);
			lblStep1.Name = "lblStep1";
			lblStep1.Size = new Size(100, 23);
			lblStep1.TabIndex = 2;
			// 
			// lblSubtitle
			// 
			lblSubtitle.Dock = DockStyle.Top;
			lblSubtitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
			lblSubtitle.ForeColor = Color.FromArgb(20, 42, 78);
			lblSubtitle.Location = new Point(0, 51);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Size = new Size(1135, 42);
			lblSubtitle.TabIndex = 3;
			lblSubtitle.Text = "SET & TRACK SAVINGS TARGETS";
			lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblTitle
			// 
			lblTitle.Dock = DockStyle.Top;
			lblTitle.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
			lblTitle.ForeColor = Color.FromArgb(8, 57, 113);
			lblTitle.Location = new Point(0, 0);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(1135, 51);
			lblTitle.TabIndex = 4;
			lblTitle.Text = "GOAL PLANNING HUB";
			lblTitle.TextAlign = ContentAlignment.BottomCenter;
			// 
			// lblValidation
			// 
			lblValidation.Dock = DockStyle.Bottom;
			lblValidation.ForeColor = Color.Firebrick;
			lblValidation.Location = new Point(0, 791);
			lblValidation.Name = "lblValidation";
			lblValidation.Size = new Size(1135, 25);
			lblValidation.TabIndex = 5;
			lblValidation.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// actionLayout
			// 
			actionLayout.BackColor = Color.FromArgb(8, 52, 105);
			actionLayout.ColumnCount = 4;
			actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
			actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
			actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
			actionLayout.Controls.Add(button4, 0, 0);
			actionLayout.Controls.Add(button6, 1, 0);
			actionLayout.Controls.Add(button5, 3, 0);
			actionLayout.Dock = DockStyle.Top;
			actionLayout.Location = new Point(0, 0);
			actionLayout.Name = "actionLayout";
			actionLayout.Padding = new Padding(24, 0, 24, 0);
			actionLayout.RowCount = 1;
			actionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			actionLayout.Size = new Size(1152, 52);
			actionLayout.TabIndex = 1;
			// 
			// button4
			// 
			button4.BackColor = Color.FromArgb(90, 100, 115);
			button4.Cursor = Cursors.Hand;
			button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			button4.Location = new Point(24, 7);
			button4.Margin = new Padding(0, 7, 0, 0);
			button4.Name = "button4";
			button4.Size = new Size(110, 38);
			button4.TabIndex = 0;
			button4.UseVisualStyleBackColor = false;
			// 
			// button6
			// 
			button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button6.BackColor = Color.FromArgb(90, 100, 115);
			button6.Cursor = Cursors.Hand;
			button6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			button6.Location = new Point(856, 7);
			button6.Margin = new Padding(0, 7, 0, 0);
			button6.Name = "button6";
			button6.Size = new Size(110, 38);
			button6.TabIndex = 1;
			button6.UseVisualStyleBackColor = false;
			// 
			// button5
			// 
			button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button5.BackColor = Color.FromArgb(10, 125, 55);
			button5.Cursor = Cursors.Hand;
			button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			button5.Location = new Point(978, 7);
			button5.Margin = new Padding(0, 7, 0, 0);
			button5.Name = "button5";
			button5.Size = new Size(150, 38);
			button5.TabIndex = 2;
			button5.UseVisualStyleBackColor = false;
			// 
			// pnlFooter
			// 
			pnlFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlFooter.Controls.Add(pnlSecurityFooter);
			pnlFooter.Controls.Add(actionLayout);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Location = new Point(0, 652);
			pnlFooter.Name = "pnlFooter";
			pnlFooter.Size = new Size(1152, 116);
			pnlFooter.TabIndex = 1;
			// 
			// pnlSecurityFooter
			// 
			pnlSecurityFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlSecurityFooter.Controls.Add(lblDateTime);
			pnlSecurityFooter.Controls.Add(lblSecurity);
			pnlSecurityFooter.Dock = DockStyle.Fill;
			pnlSecurityFooter.Location = new Point(0, 52);
			pnlSecurityFooter.Name = "pnlSecurityFooter";
			pnlSecurityFooter.Size = new Size(1152, 64);
			pnlSecurityFooter.TabIndex = 0;
			// 
			// lblDateTime
			// 
			lblDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lblDateTime.Font = new Font("Segoe UI", 10F);
			lblDateTime.ForeColor = Color.White;
			lblDateTime.Location = new Point(1652, 20);
			lblDateTime.Name = "lblDateTime";
			lblDateTime.Size = new Size(420, 25);
			lblDateTime.TabIndex = 0;
			lblDateTime.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lblSecurity
			// 
			lblSecurity.AutoSize = true;
			lblSecurity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblSecurity.ForeColor = Color.White;
			lblSecurity.Location = new Point(24, 8);
			lblSecurity.Name = "lblSecurity";
			lblSecurity.Size = new Size(158, 30);
			lblSecurity.TabIndex = 1;
			lblSecurity.Text = "SECURE SYSTEM\r\nYour security is our priority.";
			// 
			// clockTimer
			// 
			clockTimer.Interval = 1000;
			clockTimer.Tick += clockTimer_Tick;
			// 
			// GoalPlanningForm
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
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
			FormClosed += GoalPlanningForm_FormClosed;
			Load += GoalPlanningForm_Load;
			KeyDown += GoalPlanningForm_KeyDown;
			Resize += GoalPlanningForm_Resize;
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlContent.ResumeLayout(false);
			pnlSavedGoals.ResumeLayout(false);
			((ISupportInitialize)savedGoalsGrid).EndInit();
			pnlStep2.ResumeLayout(false);
			detailsLayout.ResumeLayout(false);
			detailsLayout.PerformLayout();
			pnlStep1.ResumeLayout(false);
			actionLayout.ResumeLayout(false);
			pnlFooter.ResumeLayout(false);
			pnlSecurityFooter.ResumeLayout(false);
			pnlSecurityFooter.PerformLayout();
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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
	}
}