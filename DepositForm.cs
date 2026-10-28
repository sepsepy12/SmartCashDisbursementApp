using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
    public partial class DepositForm : Form
    {
        private readonly int userId;
        private readonly BudgetRepository budgetRepo = new BudgetRepository();
        private readonly DecisionSupportSystem dss = new DecisionSupportSystem();
        private Dictionary<string, decimal> pendingAllocation;
        private string pendingSpecificCategory;
        private decimal pendingSpecificAmount;
        private string selectedMethod;
        private bool isSaving;

        public DepositForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!TryGetDepositAmount(out decimal amount)) return;

            pendingAllocation = dss.AutoAllocate(amount);
            pendingSpecificCategory = null;
            pendingSpecificAmount = 0;
            selectedMethod = "Automated";
            cmbCategory.Visible = false;
            lblCategory.Visible = false;

            MessageBox.Show(
                $"Total Deposit: ₱{amount:F2}\n\nNeeds: ₱{pendingAllocation["Needs"]:F2}\nWants: ₱{pendingAllocation["Wants"]:F2}\nSavings: ₱{pendingAllocation["Savings"]:F2}\n\nClick CONFIRM to save this deposit.",
                "Automated Budgeting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!TryGetDepositAmount(out decimal amount)) return;

            pendingAllocation = null;
            pendingSpecificAmount = amount;
            selectedMethod = "Specific";
            cmbCategory.Visible = true;
            lblCategory.Visible = true;
            pendingSpecificCategory = cmbCategory.SelectedItem as string;
            UpdateSpecificPreview();
        }

        private void button3_Click(object sender, EventArgs e) => Close();

        private void button4_Click(object sender, EventArgs e)
        {
            if (isSaving) return;
            if (string.IsNullOrEmpty(selectedMethod))
            {
                MessageBox.Show("Please choose a deposit method (A or B) first.", "Deposit Method Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMethod == "Automated")
            {
                if (pendingAllocation == null || pendingAllocation.Count == 0)
                {
                    MessageBox.Show("No deposit allocation is available.", "Deposit Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ConfirmDeposit(pendingAllocation, $"Total Deposited: ₱{GetPendingTotal():F2}\nNeeds: ₱{pendingAllocation["Needs"]:F2}\nWants: ₱{pendingAllocation["Wants"]:F2}\nSavings: ₱{pendingAllocation["Savings"]:F2}");
            }
            else if (string.IsNullOrEmpty(pendingSpecificCategory) || pendingSpecificAmount <= 0)
            {
                MessageBox.Show("Please select a category before confirming the deposit.", "Category Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ConfirmDeposit(new Dictionary<string, decimal> { { pendingSpecificCategory, pendingSpecificAmount } }, $"Total Deposited: ₱{pendingSpecificAmount:F2}\nCategory: {pendingSpecificCategory}");
            }
        }

        private void ConfirmDeposit(Dictionary<string, decimal> allocations, string summary)
        {
            isSaving = true;
            btnConfirm.Enabled = false;
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    foreach (var allocation in allocations)
                    {
                        int categoryId = budgetRepo.GetOrCreateCategoryId(userId, allocation.Key, conn);
                        const string sql = "INSERT INTO transactions (user_id, category_id, type, amount) VALUES (@userId, @categoryId, 'deposit', @amount)";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@categoryId", categoryId);
                            cmd.Parameters.AddWithValue("@amount", allocation.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Deposit confirmed successfully!\n\n" + summary, "Deposit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetPendingDeposit();
            }
            catch (Exception)
            {
                MessageBox.Show("The deposit could not be saved. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isSaving = false;
                btnConfirm.Enabled = true;
            }
        }

        private bool TryGetDepositAmount(out decimal amount)
        {
            string text = txtAmountDisplay.Text.Replace("P", "").Replace("₱", "").Trim();
            if (decimal.TryParse(text, out amount) && amount > 0) return true;
            amount = 0;
            MessageBox.Show("Please enter a valid deposit amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private decimal GetPendingTotal()
        {
            decimal total = 0;
            foreach (decimal amount in pendingAllocation.Values) total += amount;
            return total;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            pendingSpecificCategory = cmbCategory.SelectedItem as string;
            if (selectedMethod == "Specific") UpdateSpecificPreview();
        }

        private void UpdateSpecificPreview()
        {
            lblSpecificDesc.Text = pendingSpecificCategory == null
                ? "(Select a category below)"
                : $"{pendingSpecificCategory}: ₱{pendingSpecificAmount:F2}";
        }

        private void ResetPendingDeposit()
        {
            txtAmountDisplay.Text = "0.00";
            selectedMethod = null;
            pendingAllocation = null;
            pendingSpecificCategory = null;
            pendingSpecificAmount = 0;
            cmbCategory.SelectedIndex = -1;
            cmbCategory.Visible = false;
            lblCategory.Visible = false;
            lblSpecificDesc.Text = "(Select a specific budget category)";
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