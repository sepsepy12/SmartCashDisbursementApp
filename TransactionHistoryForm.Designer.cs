using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class TransactionHistoryForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			pnlHeader = new Panel();
			lblAppName = new Label();
			lblAppSubtitle = new Label();
			lblTitle = new Label();
			lblType = new Label();
			typeFilter = new ComboBox();
			lblCategory = new Label();
			categoryFilter = new ComboBox();
			btnRefresh = new Button();
			transactionGrid = new DataGridView();
			lblEmpty = new Label();
			pnlFooter = new Panel();
			lblFooter = new Label();
			btnBack = new Button();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)transactionGrid).BeginInit();
			pnlFooter.SuspendLayout();
			SuspendLayout();
			// 
			// pnlHeader
			// 
			pnlHeader.BackColor = Color.FromArgb(8, 80, 145);
			pnlHeader.Controls.Add(lblAppSubtitle);
			pnlHeader.Controls.Add(lblAppName);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Location = new Point(0, 0);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new Size(900, 70);
			pnlHeader.TabIndex = 0;
			// 
			// lblAppName
			// 
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(30, 15);
			lblAppName.Name = "lblAppName";
			lblAppName.Text = "SMART CASH DISBURSEMENT";
			// 
			// lblAppSubtitle
			// 
			lblAppSubtitle.AutoSize = true;
			lblAppSubtitle.Font = new Font("Segoe UI", 8F);
			lblAppSubtitle.ForeColor = Color.FromArgb(215, 232, 245);
			lblAppSubtitle.Location = new Point(31, 39);
			lblAppSubtitle.Name = "lblAppSubtitle";
			lblAppSubtitle.Text = "BUDGETING MACHINE";
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			lblTitle.ForeColor = Color.FromArgb(35, 45, 60);
			lblTitle.Location = new Point(330, 88);
			lblTitle.Name = "lblTitle";
			lblTitle.Text = "TRANSACTION HISTORY";
			// 
			// lblType
			// 
			lblType.AutoSize = true;
			lblType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblType.Location = new Point(70, 145);
			lblType.Name = "lblType";
			lblType.Text = "Type:";
			// 
			// typeFilter
			// 
			typeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
			typeFilter.FormattingEnabled = true;
			typeFilter.Items.AddRange(new object[] { "All", "Deposits", "Withdrawals" });
			typeFilter.Location = new Point(115, 142);
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
			lblCategory.Location = new Point(310, 145);
			lblCategory.Name = "lblCategory";
			lblCategory.Text = "Category:";
			// 
			// categoryFilter
			// 
			categoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
			categoryFilter.FormattingEnabled = true;
			categoryFilter.Location = new Point(385, 142);
			categoryFilter.Name = "categoryFilter";
			categoryFilter.Size = new Size(180, 25);
			categoryFilter.TabIndex = 3;
			categoryFilter.SelectedIndexChanged += categoryFilter_SelectedIndexChanged;
			// 
			// btnRefresh
			// 
			btnRefresh.BackColor = Color.FromArgb(8, 80, 145);
			btnRefresh.FlatAppearance.BorderSize = 0;
			btnRefresh.FlatStyle = FlatStyle.Flat;
			btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			btnRefresh.ForeColor = Color.White;
			btnRefresh.Location = new Point(690, 139);
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
			transactionGrid.Location = new Point(70, 195);
			transactionGrid.MultiSelect = false;
			transactionGrid.Name = "transactionGrid";
			transactionGrid.ReadOnly = true;
			transactionGrid.RowHeadersVisible = false;
			transactionGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			transactionGrid.Size = new Size(760, 235);
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
			// pnlFooter
			// 
			pnlFooter.BackColor = Color.FromArgb(8, 80, 145);
			pnlFooter.Controls.Add(lblFooter);
			pnlFooter.Controls.Add(btnBack);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Location = new Point(0, 460);
			pnlFooter.Name = "pnlFooter";
			pnlFooter.Size = new Size(900, 60);
			pnlFooter.TabIndex = 7;
			// 
			// lblFooter
			// 
			lblFooter.AutoSize = true;
			lblFooter.Font = new Font("Segoe UI", 8F);
			lblFooter.ForeColor = Color.White;
			lblFooter.Location = new Point(150, 22);
			lblFooter.Name = "lblFooter";
			lblFooter.Text = "SECURE SYSTEM - Your security is our priority.";
			// 
			// btnBack
			// 
			btnBack.BackColor = Color.FromArgb(120, 120, 120);
			btnBack.FlatAppearance.BorderSize = 0;
			btnBack.FlatStyle = FlatStyle.Flat;
			btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnBack.ForeColor = Color.White;
			btnBack.Location = new Point(20, 13);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(100, 34);
			btnBack.TabIndex = 1;
			btnBack.Text = "← BACK";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			// 
			// TransactionHistoryForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(248, 249, 251);
			ClientSize = new Size(900, 520);
			Controls.Add(lblEmpty);
			Controls.Add(transactionGrid);
			Controls.Add(btnRefresh);
			Controls.Add(categoryFilter);
			Controls.Add(lblCategory);
			Controls.Add(typeFilter);
			Controls.Add(lblType);
			Controls.Add(lblTitle);
			Controls.Add(pnlHeader);
			Controls.Add(pnlFooter);
			Font = new Font("Segoe UI", 10F);
			FormBorderStyle = FormBorderStyle.None;
			Name = "TransactionHistoryForm";
			Text = "Transaction History";
			TopMost = true;
			WindowState = FormWindowState.Maximized;
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)transactionGrid).EndInit();
			pnlFooter.ResumeLayout(false);
			pnlFooter.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private Panel pnlHeader;
		private Label lblAppName;
		private Label lblAppSubtitle;
		private Label lblTitle;
		private Label lblType;
		private ComboBox typeFilter;
		private Label lblCategory;
		private ComboBox categoryFilter;
		private Button btnRefresh;
		private DataGridView transactionGrid;
		private Label lblEmpty;
		private Panel pnlFooter;
		private Label lblFooter;
		private Button btnBack;
	}
}
