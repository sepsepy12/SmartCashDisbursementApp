using System;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    public partial class DashboardForm : Form
    {
        private int userId;
        private string fullName;

        public DashboardForm(int userId, string fullName)
        {
            InitializeComponent();
            this.userId = userId;
            this.fullName = fullName;
            lblSubtitle.Text = $"MAIN MENU - PLEASE SELECT AN OPTION  |  Welcome, {fullName}";
            Resize += DashboardForm_Resize;
            ApplyResponsiveLayout();
        }

        private void btnCashDeposit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var deposit = new DepositForm(userId);
            deposit.FormClosed += (s, args) => this.Show();
            deposit.Show();
        }

        private void btnCashWithdrawal_Click(object sender, EventArgs e)
        {
            this.Hide();
            var withdraw = new WithdrawalForm(userId);
            withdraw.FormClosed += (s, args) => this.Show();
            withdraw.Show();
        }

        private void btnBudgetingCounseling_Click(object sender, EventArgs e)
        {
            this.Hide();
            var counseling = new BudgetingCounselingForm(userId);
            counseling.FormClosed += (s, args) => this.Show();
            counseling.Show();
        }

        private void pnlOptionA_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Resize(object sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (pnlMain == null || lblTitle == null || lblSubtitle == null)
                return;

            pnlMain.Left = Math.Max(24, (ClientSize.Width - pnlMain.Width) / 2);
            lblTitle.Left = Math.Max(24, (ClientSize.Width - lblTitle.Width) / 2);
            lblSubtitle.Left = Math.Max(24, (ClientSize.Width - lblSubtitle.Width) / 2);
        }
    }
}
