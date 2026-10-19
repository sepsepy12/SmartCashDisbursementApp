using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    public partial class GoalPlanningForm : Form
    {
        private int userId;
        private string selectedCategory = null;
        private BudgetRepository budgetRepo = new BudgetRepository();

        public GoalPlanningForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        // button1 = "A. Savings"
        private void button1_Click(object sender, EventArgs e)
        {
            SelectCategory("Savings", button1);
        }

        // button2 = "B. Wants"
        private void button2_Click(object sender, EventArgs e)
        {
            SelectCategory("Wants", button2);
        }

        // button3 = "C. Needs"
        private void button3_Click(object sender, EventArgs e)
        {
            SelectCategory("Needs", button3);
        }

        private void SelectCategory(string categoryName, Button clickedButton)
        {
            selectedCategory = categoryName;

            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;

            clickedButton.BackColor = System.Drawing.Color.LightGreen;
        }

        // textBox2 = date field, auto-formats digits into YYYY-MM-DD
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string digitsOnly = new string(textBox2.Text.Where(char.IsDigit).ToArray());

            if (digitsOnly.Length > 8)
                digitsOnly = digitsOnly.Substring(0, 8);

            string formatted = digitsOnly;
            if (digitsOnly.Length > 4)
                formatted = digitsOnly.Substring(0, 4) + "-" + digitsOnly.Substring(4);
            if (digitsOnly.Length > 6)
                formatted = digitsOnly.Substring(0, 4) + "-" + digitsOnly.Substring(4, 2) + "-" + digitsOnly.Substring(6);

            if (textBox2.Text != formatted)
            {
                textBox2.TextChanged -= textBox2_TextChanged;
                textBox2.Text = formatted;
                textBox2.SelectionStart = textBox2.Text.Length;
                textBox2.TextChanged += textBox2_TextChanged;
            }
        }

        // button5 = "Confirm ->"
        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null)
            {
                MessageBox.Show("Please select a category (A, B, or C) first.");
                return;
            }

            if (!decimal.TryParse(textBox1.Text.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            string dateText = textBox2.Text.Trim();
            if (!DateTime.TryParseExact(dateText, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime targetDate))
            {
                MessageBox.Show("Please enter a valid date (digits only, e.g. 20261225).");
                return;
            }

            if (targetDate <= DateTime.Today)
            {
                MessageBox.Show("Target date must be in the future.");
                return;
            }

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                int categoryId = budgetRepo.GetOrCreateCategoryId(userId, selectedCategory, conn);
                budgetRepo.SaveGoal(userId, categoryId, amount, targetDate);
            }

            MessageBox.Show($"Goal set: ₱{amount:F2} for {selectedCategory} by {targetDate:yyyy-MM-dd}");
            ClearForm();
        }

        // button6 = "D. Clear"
        private void button6_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedCategory = null;
            textBox1.Clear();
            textBox2.Clear();
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;
        }

        // button4 = "<- Back"
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}