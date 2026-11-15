namespace SmartCashDisbursementApp
{
	partial class UserManagementForm
	{
		private System.ComponentModel.IContainer components = null!;
		private Panel pnlHeader = null!;
		private Label lblTitle = null!;
		private Label lblSubtitle = null!;
		private DataGridView dgvUsers = null!;
		private Button btnRefresh = null!;
		private Button btnActivate = null!;
		private Button btnDeactivate = null!;
		private Button btnBack = null!;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
				components.Dispose();

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			pnlHeader = new Panel();
			lblSubtitle = new Label();
			lblTitle = new Label();
			dgvUsers = new DataGridView();
			btnRefresh = new Button();
			btnActivate = new Button();
			btnDeactivate = new Button();
			btnBack = new Button();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
			SuspendLayout();
			// 
			// pnlHeader
			// 
			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblSubtitle);
			pnlHeader.Controls.Add(lblTitle);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Location = new Point(0, 0);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new Size(1000, 112);
			pnlHeader.TabIndex = 0;
			// 
			// lblSubtitle
			// 
			lblSubtitle.AutoSize = true;
			lblSubtitle.Font = new Font("Segoe UI", 10F);
			lblSubtitle.ForeColor = Color.White;
			lblSubtitle.Location = new Point(34, 66);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Size = new Size(274, 19);
			lblSubtitle.TabIndex = 1;
			lblSubtitle.Text = "View and manage registered user accounts.";
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			lblTitle.ForeColor = Color.White;
			lblTitle.Location = new Point(30, 18);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(253, 37);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "User Management";
			// 
			// dgvUsers
			// 
			dgvUsers.AllowUserToAddRows = false;
			dgvUsers.AllowUserToDeleteRows = false;
			dgvUsers.AllowUserToResizeRows = false;
			dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvUsers.BackgroundColor = Color.White;
			dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvUsers.Location = new Point(30, 142);
			dgvUsers.MultiSelect = false;
			dgvUsers.Name = "dgvUsers";
			dgvUsers.ReadOnly = true;
			dgvUsers.RowHeadersVisible = false;
			dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvUsers.Size = new Size(940, 400);
			dgvUsers.TabIndex = 1;
			// 
			// btnRefresh
			// 
			btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnRefresh.BackColor = Color.FromArgb(164, 213, 255);
			btnRefresh.FlatStyle = FlatStyle.Flat;
			btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnRefresh.ForeColor = Color.FromArgb(7, 57, 113);
			btnRefresh.Location = new Point(30, 562);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(130, 44);
			btnRefresh.TabIndex = 2;
			btnRefresh.Text = "Refresh";
			btnRefresh.UseVisualStyleBackColor = false;
			btnRefresh.Click += btnRefresh_Click;
			// 
			// btnActivate
			// 
			btnActivate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnActivate.BackColor = Color.FromArgb(7, 57, 113);
			btnActivate.FlatStyle = FlatStyle.Flat;
			btnActivate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnActivate.ForeColor = Color.White;
			btnActivate.Location = new Point(550, 562);
			btnActivate.Name = "btnActivate";
			btnActivate.Size = new Size(130, 44);
			btnActivate.TabIndex = 3;
			btnActivate.Text = "Activate Account";
			btnActivate.TextAlign = ContentAlignment.MiddleCenter;
			btnActivate.Padding = new Padding(0, 10, 0, 0);
			btnActivate.UseVisualStyleBackColor = false;
			btnActivate.Click += btnActivate_Click;
			// 
			// btnDeactivate
			// 
			btnDeactivate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnDeactivate.BackColor = Color.FromArgb(7, 57, 113);
			btnDeactivate.FlatStyle = FlatStyle.Flat;
			btnDeactivate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnDeactivate.ForeColor = Color.White;
			btnDeactivate.Location = new Point(690, 562);
			btnDeactivate.Name = "btnDeactivate";
			btnDeactivate.Size = new Size(150, 44);
			btnDeactivate.TabIndex = 4;
			btnDeactivate.Text = "Deactivate Account";
			btnDeactivate.UseVisualStyleBackColor = false;
			btnDeactivate.Click += btnDeactivate_Click;
			// 
			// btnBack
			// 
			btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnBack.BackColor = Color.White;
			btnBack.FlatStyle = FlatStyle.Flat;
			btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnBack.ForeColor = Color.FromArgb(7, 57, 113);
			btnBack.Location = new Point(850, 562);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(120, 44);
			btnBack.TabIndex = 5;
			btnBack.Text = "Back";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			// 
			// UserManagementForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1000, 630);
			Controls.Add(btnBack);
			Controls.Add(btnDeactivate);
			Controls.Add(btnActivate);
			Controls.Add(btnRefresh);
			Controls.Add(dgvUsers);
			Controls.Add(pnlHeader);
			Font = new Font("Segoe UI", 9F);
			MinimumSize = new Size(850, 550);
			Name = "UserManagementForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "User Management";
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
			ResumeLayout(false);
		}
	}
}
