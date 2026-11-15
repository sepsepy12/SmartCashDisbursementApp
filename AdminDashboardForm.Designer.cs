namespace SmartCashDisbursementApp
{
	partial class AdminDashboardForm
	{
		private System.ComponentModel.IContainer components = null;
		private Panel pnlHeader;
		private Label lblAppName;
		private Panel pnlNavigation;
		private FlowLayoutPanel flpNavigation;
		private Button btnDashboardOverview;
		private Button btnAccountRegistration;
		private Button btnUserManagement;
		private Button btnTransactionMonitoring;
		private Button btnAuthorizationHistory;
		private Button btnActivityLogs;
		private Button btnSignOut;
		private Panel pnlContent;
		private Label lblPageTitle;
		private Label lblWelcome;
		private Label lblContentTitle;
		private Label lblContentMessage;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
				components.Dispose();

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			pnlHeader = new Panel();
			lblAppName = new Label();
			pnlNavigation = new Panel();
			flpNavigation = new FlowLayoutPanel();
			btnDashboardOverview = CreateNavigationButton("Dashboard Overview");
			btnAccountRegistration = CreateNavigationButton("Account Registration");
			btnUserManagement = CreateNavigationButton("User Management");
			btnTransactionMonitoring = CreateNavigationButton("Transaction Monitoring");
			btnAuthorizationHistory = CreateNavigationButton("Deposit Authorization History");
			btnActivityLogs = CreateNavigationButton("System Activity Logs");
			btnSignOut = CreateNavigationButton("Sign Out");
			pnlContent = new Panel();
			lblPageTitle = new Label();
			lblWelcome = new Label();
			lblContentTitle = new Label();
			lblContentMessage = new Label();
			pnlHeader.SuspendLayout();
			pnlNavigation.SuspendLayout();
			flpNavigation.SuspendLayout();
			pnlContent.SuspendLayout();
			SuspendLayout();
			// 
			// pnlHeader
			// 
			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblAppName);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Location = new Point(0, 0);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new Size(1100, 82);
			pnlHeader.TabIndex = 0;
			// 
			// lblAppName
			// 
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(28, 22);
			lblAppName.Name = "lblAppName";
			lblAppName.Size = new Size(469, 32);
			lblAppName.TabIndex = 0;
			lblAppName.Text = "SMART CASH DISBURSEMENT BUDGETING MACHINE";
			// 
			// pnlNavigation
			// 
			pnlNavigation.BackColor = Color.FromArgb(239, 244, 249);
			pnlNavigation.Controls.Add(flpNavigation);
			pnlNavigation.Controls.Add(btnSignOut);
			pnlNavigation.Dock = DockStyle.Left;
			pnlNavigation.Location = new Point(0, 82);
			pnlNavigation.Name = "pnlNavigation";
			pnlNavigation.Padding = new Padding(12);
			pnlNavigation.Size = new Size(300, 638);
			pnlNavigation.TabIndex = 1;
			// 
			// flpNavigation
			// 
			flpNavigation.AutoScroll = true;
			flpNavigation.Controls.Add(btnDashboardOverview);
			flpNavigation.Controls.Add(btnAccountRegistration);
			flpNavigation.Controls.Add(btnUserManagement);
			flpNavigation.Controls.Add(btnTransactionMonitoring);
			flpNavigation.Controls.Add(btnAuthorizationHistory);
			flpNavigation.Controls.Add(btnActivityLogs);
			flpNavigation.Dock = DockStyle.Fill;
			flpNavigation.FlowDirection = FlowDirection.TopDown;
			flpNavigation.Location = new Point(12, 12);
			flpNavigation.Name = "flpNavigation";
			flpNavigation.Size = new Size(276, 560);
			flpNavigation.TabIndex = 0;
			flpNavigation.WrapContents = false;
			// 
			// btnDashboardOverview
			// 
			btnDashboardOverview.BackColor = Color.FromArgb(7, 57, 113);
			btnDashboardOverview.ForeColor = Color.White;
			btnDashboardOverview.Click += btnNavigation_Click;
			// 
			// btnAccountRegistration
			// 
			btnAccountRegistration.Click += btnNavigation_Click;
			// 
			// btnUserManagement
			// 
			btnUserManagement.Click += btnNavigation_Click;
			// 
			// btnTransactionMonitoring
			// 
			btnTransactionMonitoring.Click += btnNavigation_Click;
			// 
			// btnAuthorizationHistory
			// 
			btnAuthorizationHistory.Click += btnNavigation_Click;
			// 
			// btnActivityLogs
			// 
			btnActivityLogs.Click += btnNavigation_Click;
			// 
			// btnSignOut
			// 
			btnSignOut.BackColor = Color.FromArgb(164, 213, 255);
			btnSignOut.Dock = DockStyle.Bottom;
			btnSignOut.ForeColor = Color.FromArgb(7, 57, 113);
			btnSignOut.Location = new Point(12, 572);
			btnSignOut.Name = "btnSignOut";
			btnSignOut.Size = new Size(276, 54);
			btnSignOut.TabIndex = 1;
			btnSignOut.Text = "Sign Out";
			btnSignOut.Click += btnSignOut_Click;
			// 
			// pnlContent
			// 
			pnlContent.BackColor = Color.White;
			pnlContent.Controls.Add(lblContentMessage);
			pnlContent.Controls.Add(lblContentTitle);
			pnlContent.Controls.Add(lblWelcome);
			pnlContent.Controls.Add(lblPageTitle);
			pnlContent.Dock = DockStyle.Fill;
			pnlContent.Location = new Point(300, 82);
			pnlContent.Name = "pnlContent";
			pnlContent.Padding = new Padding(36);
			pnlContent.Size = new Size(800, 638);
			pnlContent.TabIndex = 2;
			// 
			// lblPageTitle
			// 
			lblPageTitle.AutoSize = true;
			lblPageTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			lblPageTitle.ForeColor = Color.FromArgb(7, 57, 113);
			lblPageTitle.Location = new Point(36, 34);
			lblPageTitle.Name = "lblPageTitle";
			lblPageTitle.Size = new Size(360, 37);
			lblPageTitle.TabIndex = 0;
			lblPageTitle.Text = "Administrator Dashboard";
			// 
			// lblWelcome
			// 
			lblWelcome.AutoSize = true;
			lblWelcome.Font = new Font("Segoe UI", 11F);
			lblWelcome.ForeColor = Color.FromArgb(55, 75, 105);
			lblWelcome.Location = new Point(40, 88);
			lblWelcome.Name = "lblWelcome";
			lblWelcome.Size = new Size(86, 20);
			lblWelcome.TabIndex = 1;
			lblWelcome.Text = "Welcome";
			// 
			// lblContentTitle
			// 
			lblContentTitle.AutoSize = true;
			lblContentTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			lblContentTitle.Location = new Point(40, 164);
			lblContentTitle.Name = "lblContentTitle";
			lblContentTitle.Size = new Size(223, 30);
			lblContentTitle.TabIndex = 2;
			lblContentTitle.Text = "Dashboard Overview";
			// 
			// lblContentMessage
			// 
			lblContentMessage.AutoSize = true;
			lblContentMessage.Font = new Font("Segoe UI", 11F);
			lblContentMessage.ForeColor = Color.FromArgb(55, 75, 105);
			lblContentMessage.Location = new Point(42, 212);
			lblContentMessage.Name = "lblContentMessage";
			lblContentMessage.Size = new Size(275, 20);
			lblContentMessage.TabIndex = 3;
			lblContentMessage.Text = "Select a module from the navigation menu.";
			// 
			// AdminDashboardForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1100, 720);
			Controls.Add(pnlContent);
			Controls.Add(pnlNavigation);
			Controls.Add(pnlHeader);
			Font = new Font("Segoe UI", 9F);
			MinimumSize = new Size(900, 600);
			Name = "AdminDashboardForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Administrator Dashboard";
			WindowState = FormWindowState.Maximized;
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlNavigation.ResumeLayout(false);
			flpNavigation.ResumeLayout(false);
			pnlContent.ResumeLayout(false);
			pnlContent.PerformLayout();
			ResumeLayout(false);
		}

		private Button CreateNavigationButton(string text)
		{
			return new Button
			{
				BackColor = Color.White,
				FlatStyle = FlatStyle.Flat,
				Font = new Font("Segoe UI", 10F, FontStyle.Bold),
				ForeColor = Color.FromArgb(7, 57, 113),
				Margin = new Padding(0, 0, 0, 8),
				Name = $"btn{text.Replace(" ", string.Empty)}",
				Size = new Size(264, 48),
				Text = text,
				TextAlign = ContentAlignment.MiddleLeft,
				UseVisualStyleBackColor = false
			};
		}
	}
}
