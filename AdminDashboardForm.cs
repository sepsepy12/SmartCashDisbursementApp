using System;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	public partial class AdminDashboardForm : Form
	{
		private int? userId;
		private string? fullName;

		internal int? UserId => userId;
		internal bool IsSigningOut { get; private set; }

		public AdminDashboardForm(int userId, string fullName)
		{
			InitializeComponent();
			this.userId = userId;
			this.fullName = fullName;
			lblWelcome.Text = $"Welcome, {fullName}";
		}

		private void btnNavigation_Click(object sender, EventArgs e)
		{
			if (sender is not Button button)
				return;

			if (button == btnDashboardOverview)
			{
				lblContentTitle.Text = "Dashboard Overview";
				lblContentMessage.Text = $"Welcome, {fullName}. Select a module from the navigation menu.";
				return;
			}

			if (button == btnAccountRegistration)
			{
				if (userId.HasValue)
				{
					using var registrationForm = new AccountRegistrationForm(userId.Value);
					registrationForm.ShowDialog(this);
				}
				return;
			}

			if (button == btnUserManagement)
			{
				if (userId.HasValue)
				{
					using var userManagementForm = new UserManagementForm(userId.Value);
					userManagementForm.ShowDialog(this);
				}
				return;
			}

			if (button == btnTransactionMonitoring)
			{
				if (userId.HasValue)
				{
					using var transactionMonitoringForm = new TransactionMonitoringForm(userId.Value);
					transactionMonitoringForm.ShowDialog(this);
				}
				return;
			}

			if (button == btnAuthorizationHistory)
			{
				if (userId.HasValue)
				{
					using var authorizationHistoryForm = new DepositAuthorizationHistoryForm(userId.Value);
					authorizationHistoryForm.ShowDialog(this);
				}
				return;
			}

			MessageBox.Show(
				$"{button.Text} will be implemented in a later phase.",
				"Coming Later",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void btnSignOut_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show(
				"Are you sure you want to sign out?",
				"Sign Out",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				IsSigningOut = true;
				userId = null;
				fullName = null;
				Close();
			}
		}
	}
}
