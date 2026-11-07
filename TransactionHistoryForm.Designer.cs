using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class TransactionHistoryForm
	{
		private System.ComponentModel.IContainer components = null;
		private Panel pnlContent;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			pnlContent = new Panel();
			pnlHeader = new Panel();
			lblAppName = new Label();
			lblAppSubtitle = new Label();
			lblTitle = new Label();
			lblSubtitle = new Label();
			lblType = new Label();
			typeFilter = new ComboBox();
			lblCategory = new Label();
			categoryFilter = new ComboBox();
			btnRefresh = new Button();
			transactionGrid = new DataGridView();
			lblEmpty = new Label();
			pnlFooter = new Panel();
			actionBar = new Panel();
			pnlSecurityFooter = new Panel();
			lblFooter = new Label();
			dateTimeLabel = new Label();
			btnBack = new Button();
			pnlContent.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)transactionGrid).BeginInit();
			pnlFooter.SuspendLayout();
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
			pnlHeader.Size = new Size(900, 76);
			pnlHeader.TabIndex = 0;
			// 
			// lblAppName
			// 
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(96, 13);
			lblAppName.Name = "lblAppName";
			lblAppName.Text = "SMART CASH DISBURSEMENT";
			// 
			// lblAppSubtitle
			// 
			lblAppSubtitle.AutoSize = true;
			lblAppSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			lblAppSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblAppSubtitle.Location = new Point(98, 42);
			lblAppSubtitle.Name = "lblAppSubtitle";
			lblAppSubtitle.Text = "BUDGETING MACHINE";
			// 
			// lblTitle
			// 
			lblTitle.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
			lblTitle.ForeColor = Color.FromArgb(8, 57, 113);
			lblTitle.Location = new Point(0, 0);
			lblTitle.Size = new Size(900, 51);
			lblTitle.Name = "lblTitle";
			lblTitle.Text = "TRANSACTION HISTORY";
			lblTitle.TextAlign = ContentAlignment.BottomCenter;
			//
			// lblSubtitle
			//
			lblSubtitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
			lblSubtitle.ForeColor = Color.FromArgb(20, 42, 78);
			lblSubtitle.Location = new Point(0, 51);
			lblSubtitle.Size = new Size(900, 42);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Text = "VIEW YOUR DEPOSITS AND WITHDRAWALS";
			lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblType
			// 
			lblType.AutoSize = true;
			lblType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblType.Location = new Point(70, 108);
			lblType.Name = "lblType";
			lblType.Text = "Type:";
			// 
			// typeFilter
			// 
			typeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
			typeFilter.FormattingEnabled = true;
			typeFilter.Items.AddRange(new object[] { "All", "Deposits", "Withdrawals" });
			typeFilter.Location = new Point(115, 105);
			typeFilter.Name = "typeFilter";
			typeFilter.Size = new Size(150, 25);
			typeFilter.TabIndex = 2;
			typeFilter.SelectedIndex = 0;
			typeFilter.SelectedIndexChanged += typeFilter_SelectedIndexChanged;
			// 
			// lblCategory
			// 
			lblCategory.AutoSize = true;
			lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblCategory.Location = new Point(310, 108);
			lblCategory.Name = "lblCategory";
			lblCategory.Text = "Category:";
			// 
			// categoryFilter
			// 
			categoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
			categoryFilter.FormattingEnabled = true;
			categoryFilter.Location = new Point(385, 105);
			categoryFilter.Name = "categoryFilter";
			categoryFilter.Size = new Size(180, 25);
			categoryFilter.TabIndex = 3;
			categoryFilter.SelectedIndexChanged += categoryFilter_SelectedIndexChanged;
			// 
			// btnRefresh
			// 
			btnRefresh.BackColor = Color.FromArgb(7, 57, 113);
			btnRefresh.FlatAppearance.BorderSize = 0;
			btnRefresh.FlatStyle = FlatStyle.Flat;
			btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			btnRefresh.ForeColor = Color.White;
			btnRefresh.Location = new Point(550, 102);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(130, 32);
			btnRefresh.TabIndex = 4;
			btnRefresh.Text = "REFRESH";
			btnRefresh.UseVisualStyleBackColor = false;
			btnRefresh.Click += btnRefresh_Click;
			// 
			// transactionGrid
			// 
			transactionGrid.AllowUserToAddRows = false;
			transactionGrid.AllowUserToDeleteRows = false;
			transactionGrid.AllowUserToResizeRows = false;
			transactionGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			transactionGrid.BackgroundColor = Color.White;
			transactionGrid.BorderStyle = BorderStyle.FixedSingle;
			transactionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			transactionGrid.Location = new Point(24, 150);
			transactionGrid.MultiSelect = false;
			transactionGrid.Name = "transactionGrid";
			transactionGrid.ReadOnly = true;
			transactionGrid.RowHeadersVisible = false;
			transactionGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			transactionGrid.Size = new Size(852, 300);
			transactionGrid.TabIndex = 5;
			// 
			// lblEmpty
			// 
			lblEmpty.AutoSize = true;
			lblEmpty.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
			lblEmpty.ForeColor = Color.DimGray;
			lblEmpty.Location = new Point(330, 300);
			lblEmpty.Name = "lblEmpty";
			lblEmpty.Text = "No transactions available.";
			lblEmpty.Visible = false;
			//
			// pnlContent
			//
			pnlContent.BackColor = Color.WhiteSmoke;
			pnlContent.Controls.Add(transactionGrid);
			pnlContent.Controls.Add(lblEmpty);
			pnlContent.Controls.Add(btnRefresh);
			pnlContent.Controls.Add(categoryFilter);
			pnlContent.Controls.Add(lblCategory);
			pnlContent.Controls.Add(typeFilter);
			pnlContent.Controls.Add(lblType);
			pnlContent.Controls.Add(lblSubtitle);
			pnlContent.Controls.Add(lblTitle);
			pnlContent.Dock = DockStyle.Fill;
			pnlContent.Name = "pnlContent";
			//
			// pnlFooter
			//
			pnlFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlFooter.Controls.Add(pnlSecurityFooter);
			pnlFooter.Controls.Add(actionBar);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Name = "pnlFooter";
			pnlFooter.Height = 116;
			pnlFooter.TabIndex = 7;
			actionBar.BackColor = Color.FromArgb(8, 52, 105);
			actionBar.Controls.Add(btnBack);
			actionBar.Dock = DockStyle.Top;
			actionBar.Height = 52;
			//
			// pnlSecurityFooter
			//
			pnlSecurityFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlSecurityFooter.Controls.Add(dateTimeLabel);
			pnlSecurityFooter.Controls.Add(lblFooter);
			pnlSecurityFooter.Dock = DockStyle.Fill;
			//
			// lblFooter
			//
			lblFooter.AutoSize = true;
			lblFooter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblFooter.ForeColor = Color.White;
			lblFooter.Location = new Point(24, 8);
			lblFooter.Name = "lblFooter";
			lblFooter.Text = "SECURE SYSTEM\r\nYour security is our priority.";
			dateTimeLabel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			dateTimeLabel.AutoSize = true;
			dateTimeLabel.Font = new Font("Segoe UI", 10F);
			dateTimeLabel.ForeColor = Color.White;
			dateTimeLabel.Location = new Point(720, 21);
			// 
			// btnBack
			// 
			btnBack.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			btnBack.BackColor = Color.FromArgb(90, 100, 115);
			btnBack.FlatAppearance.BorderSize = 0;
			btnBack.FlatStyle = FlatStyle.Flat;
			btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnBack.ForeColor = Color.White;
			btnBack.Cursor = Cursors.Hand;
			btnBack.Location = new Point(24, 7);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(110, 38);
			btnBack.TabIndex = 1;
			btnBack.Text = "←  BACK";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			// 
			// TransactionHistoryForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.WhiteSmoke;
			ClientSize = new Size(900, 520);
			Controls.Add(pnlContent);
			Controls.Add(pnlFooter);
			Controls.Add(pnlHeader);
			MinimumSize = new Size(800, 520);
			Font = new Font("Segoe UI", 10F);
			FormBorderStyle = FormBorderStyle.None;
			Name = "TransactionHistoryForm";
			Text = "Transaction History";
			TopMost = true;
			WindowState = FormWindowState.Maximized;
			pnlContent.ResumeLayout(false);
			pnlContent.PerformLayout();
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)transactionGrid).EndInit();
			pnlFooter.ResumeLayout(false);
			pnlFooter.PerformLayout();
			actionBar.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private Panel pnlHeader;
		private Label lblAppName;
		private Label lblAppSubtitle;
		private Label lblTitle;
		private Label lblSubtitle;
		private Label lblType;
		private ComboBox typeFilter;
		private Label lblCategory;
		private ComboBox categoryFilter;
		private Button btnRefresh;
		private DataGridView transactionGrid;
		private Label lblEmpty;
		private Panel pnlFooter;
		private Panel actionBar;
		private Panel pnlSecurityFooter;
		private Label lblFooter;
		private Label dateTimeLabel;
		private Button btnBack;
	}
}
	