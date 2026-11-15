using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class DepositAuthorizationHistoryForm
	{
		private System.ComponentModel.IContainer components = null;
		private Panel pnlHeader;
		private Label lblTitle;
		private Label lblSubtitle;
		private Panel pnlFilters;
		private CheckBox chkDateRange;
		private Label lblStartDate;
		private DateTimePicker dtpStartDate;
		private Label lblEndDate;
		private DateTimePicker dtpEndDate;
		private Button btnClearFilters;
		private Button btnRefresh;
		private Panel pnlGrid;
		private DataGridView dgvAuthorizationHistory;
		private Label lblRecordCount;
		private Panel pnlFooter;
		private Button btnBack;
		private Label lblReadOnly;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			pnlHeader = new Panel();
			lblTitle = new Label();
			lblSubtitle = new Label();
			pnlFilters = new Panel();
			chkDateRange = new CheckBox();
			lblStartDate = new Label();
			dtpStartDate = new DateTimePicker();
			lblEndDate = new Label();
			dtpEndDate = new DateTimePicker();
			btnClearFilters = new Button();
			btnRefresh = new Button();
			pnlGrid = new Panel();
			dgvAuthorizationHistory = new DataGridView();
			lblRecordCount = new Label();
			pnlFooter = new Panel();
			btnBack = new Button();
			lblReadOnly = new Label();
			pnlHeader.SuspendLayout();
			pnlFilters.SuspendLayout();
			pnlGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvAuthorizationHistory).BeginInit();
			pnlFooter.SuspendLayout();
			SuspendLayout();
			//
			// pnlHeader
			//
			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblSubtitle);
			pnlHeader.Controls.Add(lblTitle);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Height = 82;
			pnlHeader.Name = "pnlHeader";
			//
			// lblTitle
			//
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			lblTitle.ForeColor = Color.White;
			lblTitle.Location = new Point(24, 10);
			lblTitle.Name = "lblTitle";
			lblTitle.Text = "DEPOSIT AUTHORIZATION HISTORY";
			//
			// lblSubtitle
			//
			lblSubtitle.AutoSize = true;
			lblSubtitle.Font = new Font("Segoe UI", 10F);
			lblSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblSubtitle.Location = new Point(27, 47);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Text = "Read-only history of deposit authorization records";
			//
			// pnlFilters
			//
			pnlFilters.BackColor = Color.FromArgb(239, 244, 249);
			pnlFilters.Controls.Add(chkDateRange);
			pnlFilters.Controls.Add(lblStartDate);
			pnlFilters.Controls.Add(dtpStartDate);
			pnlFilters.Controls.Add(lblEndDate);
			pnlFilters.Controls.Add(dtpEndDate);
			pnlFilters.Controls.Add(btnClearFilters);
			pnlFilters.Controls.Add(btnRefresh);
			pnlFilters.Dock = DockStyle.Top;
			pnlFilters.Height = 100;
			pnlFilters.Name = "pnlFilters";
			//
			// chkDateRange
			//
			chkDateRange.AutoSize = true;
			chkDateRange.Location = new Point(22, 41);
			chkDateRange.Name = "chkDateRange";
			chkDateRange.Text = "Filter by date";
			chkDateRange.CheckedChanged += chkDateRange_CheckedChanged;
			//
			// lblStartDate
			//
			lblStartDate.AutoSize = true;
			lblStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblStartDate.Location = new Point(195, 12);
			lblStartDate.Name = "lblStartDate";
			lblStartDate.Text = "From";
			//
			// dtpStartDate
			//
			dtpStartDate.Enabled = false;
			dtpStartDate.Format = DateTimePickerFormat.Short;
			dtpStartDate.Location = new Point(195, 38);
			dtpStartDate.Name = "dtpStartDate";
			dtpStartDate.Size = new Size(150, 23);
			dtpStartDate.ValueChanged += dateFilter_ValueChanged;
			//
			// lblEndDate
			//
			lblEndDate.AutoSize = true;
			lblEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblEndDate.Location = new Point(365, 12);
			lblEndDate.Name = "lblEndDate";
			lblEndDate.Text = "To";
			//
			// dtpEndDate
			//
			dtpEndDate.Enabled = false;
			dtpEndDate.Format = DateTimePickerFormat.Short;
			dtpEndDate.Location = new Point(365, 38);
			dtpEndDate.Name = "dtpEndDate";
			dtpEndDate.Size = new Size(150, 23);
			dtpEndDate.ValueChanged += dateFilter_ValueChanged;
			//
			// btnClearFilters
			//
			btnClearFilters.BackColor = Color.FromArgb(90, 100, 115);
			btnClearFilters.FlatAppearance.BorderSize = 0;
			btnClearFilters.FlatStyle = FlatStyle.Flat;
			btnClearFilters.ForeColor = Color.White;
			btnClearFilters.Location = new Point(710, 34);
			btnClearFilters.Name = "btnClearFilters";
			btnClearFilters.Size = new Size(135, 32);
			btnClearFilters.Text = "Clear Filters";
			btnClearFilters.UseVisualStyleBackColor = false;
			btnClearFilters.Click += btnClearFilters_Click;
			//
			// btnRefresh
			//
			btnRefresh.BackColor = Color.FromArgb(8, 80, 145);
			btnRefresh.FlatAppearance.BorderSize = 0;
			btnRefresh.FlatStyle = FlatStyle.Flat;
			btnRefresh.ForeColor = Color.White;
			btnRefresh.Location = new Point(860, 34);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(120, 32);
			btnRefresh.Text = "Refresh";
			btnRefresh.UseVisualStyleBackColor = false;
			btnRefresh.Click += btnRefresh_Click;
			//
			// pnlGrid
			//
			pnlGrid.Controls.Add(dgvAuthorizationHistory);
			pnlGrid.Controls.Add(lblRecordCount);
			pnlGrid.Dock = DockStyle.Fill;
			pnlGrid.Name = "pnlGrid";
			//
			// dgvAuthorizationHistory
			//
			dgvAuthorizationHistory.AllowUserToAddRows = false;
			dgvAuthorizationHistory.AllowUserToDeleteRows = false;
			dgvAuthorizationHistory.AllowUserToOrderColumns = false;
			dgvAuthorizationHistory.AllowUserToResizeRows = false;
			dgvAuthorizationHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvAuthorizationHistory.BackgroundColor = Color.White;
			dgvAuthorizationHistory.BorderStyle = BorderStyle.FixedSingle;
			dgvAuthorizationHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvAuthorizationHistory.Dock = DockStyle.Fill;
			dgvAuthorizationHistory.MultiSelect = false;
			dgvAuthorizationHistory.Name = "dgvAuthorizationHistory";
			dgvAuthorizationHistory.ReadOnly = true;
			dgvAuthorizationHistory.RowHeadersVisible = false;
			dgvAuthorizationHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			//
			// lblRecordCount
			//
			lblRecordCount.BackColor = Color.White;
			lblRecordCount.Dock = DockStyle.Bottom;
			lblRecordCount.ForeColor = Color.DimGray;
			lblRecordCount.Height = 28;
			lblRecordCount.Name = "lblRecordCount";
			lblRecordCount.Padding = new Padding(8, 5, 0, 0);
			lblRecordCount.Text = "";
			//
			// pnlFooter
			//
			pnlFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlFooter.Controls.Add(lblReadOnly);
			pnlFooter.Controls.Add(btnBack);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Height = 64;
			pnlFooter.Name = "pnlFooter";
			//
			// btnBack
			//
			btnBack.BackColor = Color.FromArgb(90, 100, 115);
			btnBack.FlatAppearance.BorderSize = 0;
			btnBack.FlatStyle = FlatStyle.Flat;
			btnBack.ForeColor = Color.White;
			btnBack.Location = new Point(22, 14);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(110, 36);
			btnBack.Text = "Back";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			//
			// lblReadOnly
			//
			lblReadOnly.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lblReadOnly.AutoSize = true;
			lblReadOnly.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblReadOnly.ForeColor = Color.White;
			lblReadOnly.Location = new Point(950, 22);
			lblReadOnly.Name = "lblReadOnly";
			lblReadOnly.Text = "AUTHORIZATION HISTORY - READ ONLY";
			//
			// DepositAuthorizationHistoryForm
			//
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1200, 720);
			Controls.Add(pnlGrid);
			Controls.Add(pnlFilters);
			Controls.Add(pnlHeader);
			Controls.Add(pnlFooter);
			MinimumSize = new Size(1020, 560);
			Name = "DepositAuthorizationHistoryForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Deposit Authorization History";
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlFilters.ResumeLayout(false);
			pnlFilters.PerformLayout();
			pnlGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvAuthorizationHistory).EndInit();
			pnlFooter.ResumeLayout(false);
			pnlFooter.PerformLayout();
			ResumeLayout(false);
		}
	}
}
