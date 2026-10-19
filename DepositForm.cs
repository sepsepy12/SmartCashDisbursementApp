using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
    public partial class DepositForm : Form
    {
        private int userId;
        private BudgetRepository budgetRepo = new BudgetRepository();
        private DecisionSupportSystem dss = new DecisionSupportSystem();

        public DepositForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        // button1 = "A. Automated Budgeting System"
        private void button1_Click(object sender, EventArgs e)
        {
            string amountText = txtAmountDisplay.Text.Replace("P", "").Replace("₱", "").Trim();

            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid deposit amount.");
                return;
            }

            var allocation = dss.AutoAllocate(amount);

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                foreach (var kv in allocation)
                {
                    string categoryName = kv.Key;
                    decimal categoryAmount = kv.Value;

                    int categoryId = budgetRepo.GetOrCreateCategoryId(userId, categoryName, conn);

                    string insertSql = "INSERT INTO transactions (user_id, category_id, type, amount) VALUES (@userId, @categoryId, 'deposit', @amount)";
                    using (var cmd = new MySqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@categoryId", categoryId);
                        cmd.Parameters.AddWithValue("@amount", categoryAmount);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show($"Deposited P{amount:F2}!\nNeeds: P{allocation["Needs"]:F2}\nWants: P{allocation["Wants"]:F2}\nSavings: P{allocation["Savings"]:F2}");
            txtAmountDisplay.Text = "0.00";
        }

        // button5 = "B. Specific Section Deposit" - placeholder for now
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Specific Section Deposit - coming soon");
        }

        // button3 = "<- Back"
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // button4 = "Confirm ->"
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please choose a deposit method (A or B) first.");
        }

        private void txtAmountDisplay_Click(object sender, EventArgs e)
        {

        }

        private void lblAutoDesc_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSpecificDesc_Click(object sender, EventArgs e)
        {

        }

        private void DepositForm_Load(object sender, EventArgs e)
        {

        }

        private void pnlAmountBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}