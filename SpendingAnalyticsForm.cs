using System;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    public partial class SpendingAnalyticsForm : Form
    {
        private int userId;
        private BudgetRepository budgetRepo = new BudgetRepository();

        public SpendingAnalyticsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadCategoryBalances();
        }

        private void SpendingAnalyticsForm_Load(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void SpendingAnalyticsForm_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // Calculate sizes relative to client area for responsive layout
            int margin = 40;
            int buttonHeight = btnBack.Height > 0 ? btnBack.Height : 64;

            int targetWidth = (int)(this.ClientSize.Width * 0.7);
            int targetHeight = (int)(this.ClientSize.Height * 0.65) - buttonHeight;
            if (targetWidth < 300) targetWidth = 300;
            if (targetHeight < 150) targetHeight = 150;

            dgvCategoryBalances.Size = new System.Drawing.Size(targetWidth, targetHeight);
            dgvCategoryBalances.Location = new System.Drawing.Point((this.ClientSize.Width - dgvCategoryBalances.Width) / 2,
                                                                  Math.Max(margin, (this.ClientSize.Height - dgvCategoryBalances.Height - buttonHeight) / 2));

            // Place back button centered below the grid with some spacing
            int btnY = dgvCategoryBalances.Bottom + 20;
            btnBack.Size = new System.Drawing.Size(200, buttonHeight);
            btnBack.Location = new System.Drawing.Point((this.ClientSize.Width - btnBack.Width) / 2, btnY);
        }

        private void LoadCategoryBalances()
        {
            var categories = budgetRepo.GetCategoriesForUser(userId);

            dgvCategoryBalances.Rows.Clear();
            dgvCategoryBalances.Columns.Clear();
            dgvCategoryBalances.Columns.Add("Category", "Category");
            dgvCategoryBalances.Columns.Add("Allocated", "Allocated (₱)");
            dgvCategoryBalances.Columns.Add("Spent", "Spent (₱)");
            dgvCategoryBalances.Columns.Add("Available", "Available Balance (₱)");

            foreach (var cat in categories)
            {
                dgvCategoryBalances.Rows.Add(
                    cat.Name,
                    cat.Allocated.ToString("F2"),
                    cat.Spent.ToString("F2"),
                    cat.Remaining.ToString("F2")
                );
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}