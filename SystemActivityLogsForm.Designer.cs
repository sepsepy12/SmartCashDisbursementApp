using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class SystemActivityLogsForm
	{
		private System.ComponentModel.IContainer components = null;
		private Panel pnlHeader;
		private Label lblTitle;
		private Label lblSubtitle;
		private Panel pnlFilters;
		private Label lblDateFrom;
		private DateTimePicker dtpDateFrom;
		private Label lblDateTo;
		private DateTimePicker dtpDateTo;
		private Label lblActionType;
		private ComboBox cboActionType;
		private Button btnClearFilters;
		private Button btnRefresh;
		private Panel pnlGrid;
		private DataGridView dgvActivityLogs;
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
			lblDateFrom = new Label();
			dtpDateFrom = new DateTimePicker();
			lblDateTo = new Label();
			dtpDateTo = new DateTimePicker();
			lblActionType = new Label();
			cboActionType = new ComboBox();
			btnClearFilters = new Button();
			btnRefresh = new Button();
			pnlGrid = new Panel();
			dgvActivityLogs = new DataGridView();
			lblRecordCount = new Label();
			pnlFooter = new Panel();
			btnBack = new Button();
			lblReadOnly = new Label();
			pnlHeader.SuspendLayout();
			pnlFilters.SuspendLayout();
			pnlGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvActivityLogs).BeginInit();
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
			lblTitle.Text = "SYSTEM ACTIVITY LOGS";
			//
			// lblSubtitle
			//
			lblSubtitle.AutoSize = true;
			lblSubtitle.Font = new Font("Segoe UI", 10F);
			lblSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblSubtitle.Location = new Point(27, 47);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Text = "Read-only history of successful administrator actions";
			//
			// pnlFilters
			//
			pnlFilters.BackColor = Color.FromArgb(239, 244, 249);
			pnlFilters.Controls.Add(lblDateFrom);
			pnlFilters.Controls.Add(dtpDateFrom);
			pnlFilters.Controls.Add(lblDateTo);
			pnlFilters.Controls.Add(dtpDateTo);
			pnlFilters.Controls.Add(lblActionType);
			pnlFilters.Controls.Add(cboActionType);
			pnlFilters.Controls.Add(btnClearFilters);
			pnlFilters.Controls.Add(btnRefresh);
			pnlFilters.Dock = DockStyle.Top;
			pnlFilters.Height = 100;
			pnlFilters.Name = "pnlFilters";
			//
			// lblDateFrom
			//
			lblDateFrom.AutoSize = true;
			lblDateFrom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblDateFrom.Location = new Point(22, 12);
			lblDateFrom.Name = "lblDateFrom";
			lblDateFrom.Text = "Date from";
			//
			// dtpDateFrom
			//
			dtpDateFrom.Checked = false;
			dtpDateFrom.Format = DateTimePickerFormat.Short;
			dtpDateFrom.Location = new Point(22, 38);
			dtpDateFrom.Name = "dtpDateFrom";
			dtpDateFrom.ShowCheckBox = true;
			dtpDateFrom.Size = new Size(160, 23);
			dtpDateFrom.ValueChanged += filter_ValueChanged;
			//
			// lblDateTo
			//
			lblDateTo.AutoSize = true;
			lblDateTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblDateTo.Location = new Point(205, 12);
			lblDateTo.Name = "lblDateTo";
			lblDateTo.Text = "Date to";
			//
			// dtpDateTo
			//
			dtpDateTo.Checked = false;
			dtpDateTo.Format = DateTimePickerFormat.Short;
			dtpDateTo.Location = new Point(205, 38);
			dtpDateTo.Name = "dtpDateTo";
			dtpDateTo.ShowCheckBox = true;
			dtpDateTo.Size = new Size(160, 23);
			dtpDateTo.ValueChanged += filter_ValueChanged;
			//
			// lblActionType
			//
			lblActionType.AutoSize = true;
			lblActionType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblActionType.Location = new Point(390, 12);
			lblActionType.Name = "lblActionType";
			lblActionType.Text = "Action type";
			//
			// cboActionType
			//
			cboActionType.DropDownStyle = ComboBoxStyle.DropDownList;
			cboActionType.Location = new Point(390, 38);
			cboActionType.Name = "cboActionType";
			cboActionType.Size = new Size(220, 23);
			cboActionType.SelectedIndexChanged += cboActionType_SelectedIndexChanged;
			//
			// btnClearFilters
			//
			btnClearFilters.BackColor = Color.FromArgb(90, 100, 115);
			btnClearFilters.FlatAppearance.BorderSize = 0;
			btnClearFilters.FlatStyle = FlatStyle.Flat;
			btnClearFilters.ForeColor = Color.White;
			btnClearFilters.Location = new Point(825, 34);
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
			btnRefresh.Location = new Point(975, 34);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(120, 32);
			btnRefresh.Text = "Refresh";
			btnRefresh.UseVisualStyleBackColor = false;
			btnRefresh.Click += btnRefresh_Click;
			//
			// pnlGrid
			//
			pnlGrid.Controls.Add(dgvActivityLogs);
			pnlGrid.Controls.Add(lblRecordCount);
			pnlGrid.Dock = DockStyle.Fill;
			pnlGrid.Name = "pnlGrid";
			//
			// dgvActivityLogs
			//
			dgvActivityLogs.AllowUserToAddRows = false;
			dgvActivityLogs.AllowUserToDeleteRows = false;
			dgvActivityLogs.AllowUserToOrderColumns = false;
			dgvActivityLogs.AllowUserToResizeRows = false;
			dgvActivityLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvActivityLogs.BackgroundColor = Color.White;
			dgvActivityLogs.BorderStyle = BorderStyle.FixedSingle;
			dgvActivityLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvActivityLogs.Dock = DockStyle.Fill;
			dgvActivityLogs.MultiSelect = false;
			dgvActivityLogs.Name = "dgvActivityLogs";
			dgvActivityLogs.ReadOnly = true;
			dgvActivityLogs.RowHeadersVisible = false;
			dgvActivityLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
			lblReadOnly.Text = "SYSTEM ACTIVITY LOGS - READ ONLY";
			//
			// SystemActivityLogsForm
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
			Name = "SystemActivityLogsForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "System Activity Logs";
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlFilters.ResumeLayout(false);
			pnlFilters.PerformLayout();
			pnlGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvActivityLogs).EndInit();
			pnlFooter.ResumeLayout(false);
			pnlFooter.PerformLayout();
			ResumeLayout(false);
		}
	}
}
