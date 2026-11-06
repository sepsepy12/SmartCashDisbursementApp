using System;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    public partial class BudgetingCounselingForm : Form
    {
        private int userId;

        public BudgetingCounselingForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            dateTimeLabel.Text = DateTime.Now.ToString("MMM d, yyyy | h:mm tt");
            Resize += BudgetingCounselingForm_Resize;
            ApplyResponsiveLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // A. Goal Planning
            this.Hide();
            var goalForm = new GoalPlanningForm(userId);
            goalForm.FormClosed += (s, args) => this.Show();
            goalForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // B. Spending Analytics
            this.Hide();
            var analyticsForm = new SpendingAnalyticsForm(userId);
            analyticsForm.FormClosed += (s, args) => this.Show();
            analyticsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // C. Counseling hub placeholder
            this.Hide();
            var counselinghubForm = new CounselingHub_Resources(userId);
            counselinghubForm.FormClosed += (s, args) => this.Show();
            counselinghubForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Confirm (no-op because buttons A/B/C navigate immediately)
            MessageBox.Show("Use the A/B/C buttons to open the corresponding section.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Back
            this.Close();
        }

        private void BudgetingCounselingForm_Load(object sender, EventArgs e)
        {
            // Optional: initialize UI state
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BudgetingCounselingForm_Load_1(object sender, EventArgs e)
        {

        }

        private void BudgetingCounselingForm_Resize(object sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (pnlMain == null || lblTitle == null || lblSection == null || lblInstruction == null)
                return;

            pnlMain.Left = Math.Max(24, (ClientSize.Width - pnlMain.Width) / 2);
            lblTitle.Left = Math.Max(24, (ClientSize.Width - lblTitle.Width) / 2);
            lblSection.Left = Math.Max(24, (ClientSize.Width - lblSection.Width) / 2);
            lblInstruction.Left = Math.Max(24, (ClientSize.Width - lblInstruction.Width) / 2);
        }
    }
}
