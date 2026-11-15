using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private decimal pendingDepositAmount;
        private string selectedMethod;
        private bool isSaving;

        public DepositForm(int userId)
        {
            InitializeComponent();
            btnConfirm.Parent = pnlActionBar;
            pnlFooter.Visible = true;
            pnlActionBar.Visible = true;
            btnConfirm.Visible = true;
            btnConfirm.BringToFront();
            this.userId = userId;
            UpdateDateTime();
            clockTimer.Start();
            Shown += DepositForm_Shown;
            Resize += DepositForm_Resize;
            ApplyResponsiveLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!TryGetDepositAmount(out decimal amount)) return;

            pendingAllocation = dss.AutoAllocate(amount);
            pendingSpecificCategory = null;
            pendingSpecificAmount = 0;
            pendingDepositAmount = amount;
            selectedMethod = "Automated";
            pnlCategorySelection.Visible = false;
            pnlSpecificReview.Visible = false;
            btnConfirm.Visible = true;

            MessageBox.Show(
                $"Total Deposit: ₱{amount:F2}\n\nNeeds: ₱{pendingAllocation["Needs"]:F2}\nWants: ₱{pendingAllocation["Wants"]:F2}\nSavings: ₱{pendingAllocation["Savings"]:F2}\n\nClick CONFIRM to save this deposit.",
                "Automated Budgeting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!TryGetDepositAmount(out decimal amount)) return;

            pendingAllocation = null;
            pendingSpecificAmount = amount;
            pendingDepositAmount = amount;
            selectedMethod = "Specific";
            pnlCategorySelection.Visible = true;
            pnlSpecificReview.Visible = false;
            btnConfirm.Visible = true;
            SelectSpecificCategory(null);
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

            if (!TryValidatePendingAmount()) return;

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
            if (!CashAmountValidator.IsValid(pendingDepositAmount))
            {
                MessageBox.Show(
                    "Invalid deposit amount. Only ₱50, ₱100, ₱200, ₱500, and ₱1,000 bills are accepted.",
                    "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isSaving = true;
            btnConfirm.Enabled = false;
            string rfidUid = string.Empty;
            string pin = string.Empty;
            try
            {
                using (var authorizationDialog = new AdministratorAuthorizationDialog())
                {
                    if (authorizationDialog.ShowDialog(this) != DialogResult.OK)
                    {
                        MessageBox.Show(this,
                            "Administrator authorization was cancelled. No deposit was made.",
                            "Authorization Cancelled",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    authorizationDialog.TakeCredentials(out rfidUid, out pin);
                }

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            if (!TryVerifyAdministrator(conn, transaction, rfidUid, pin, out int administratorUserId, out string authorizationError))
                            {
                                transaction.Rollback();
                                MessageBox.Show(this,
                                    authorizationError,
                                    "Administrator Authorization Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            pin = string.Empty;
                            foreach (var allocation in allocations)
                            {
                                int categoryId = budgetRepo.GetOrCreateCategoryId(userId, allocation.Key, conn, transaction);
                                const string updateSql = @"
                                    UPDATE budget_categories
                                    SET allocated_amount = allocated_amount + @amount
                                    WHERE user_id = @userId AND id = @categoryId";
                                using (var updateCommand = new MySqlCommand(updateSql, conn, transaction))
                                {
                                    updateCommand.Parameters.AddWithValue("@amount", allocation.Value);
                                    updateCommand.Parameters.AddWithValue("@userId", userId);
                                    updateCommand.Parameters.AddWithValue("@categoryId", categoryId);
                                    int updatedRows = updateCommand.ExecuteNonQuery();
                                    if (updatedRows != 1 && allocation.Value != 0)
                                    {
                                        throw new InvalidOperationException("The deposit category balance could not be updated.");
                                    }
                                }

                                const string sql = @"
                                    INSERT INTO transactions (user_id, category_id, type, amount, authorized_by_user_id)
                                    VALUES (@userId, @categoryId, 'deposit', @amount, @administratorUserId)";
                                using (var cmd = new MySqlCommand(sql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@userId", userId);
                                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                                    cmd.Parameters.AddWithValue("@amount", allocation.Value);
                                    cmd.Parameters.AddWithValue("@administratorUserId", administratorUserId);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            SystemActivityLogger.Log(
                                conn,
                                administratorUserId,
                                "DEPOSIT_AUTHORIZED",
                                userId,
                                $"Authorized deposit of {pendingDepositAmount:C}.",
                                transaction);
                            transaction.Commit();
                        }
                        catch
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch
                            {
                            }

                            throw;
                        }
                    }
                }

                MessageBox.Show("Deposit confirmed successfully!\n\n" + summary, "Deposit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetPendingDeposit();
            }
            catch (MySqlException)
            {
                MessageBox.Show("A database error occurred while verifying the administrator or saving the deposit. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("The deposit could not be saved. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                rfidUid = string.Empty;
                pin = string.Empty;
                isSaving = false;
                btnConfirm.Enabled = true;
            }
        }

        private bool TryVerifyAdministrator(
            MySqlConnection connection,
            MySqlTransaction transaction,
            string rfidUid,
            string pin,
            out int administratorUserId,
            out string errorMessage)
        {
            administratorUserId = 0;
            errorMessage = "The administrator RFID UID or PIN is invalid.";

            const string sql = @"
                SELECT id, password_hash, role, is_active
                FROM users
                WHERE rfid_uid = @rfidUid
                FOR UPDATE";
            string passwordHash;
            string role;
            bool isActive;
            using (var command = new MySqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@rfidUid", rfidUid);
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return false;

                    administratorUserId = reader.GetInt32("id");
                    passwordHash = Convert.ToString(reader["password_hash"]) ?? string.Empty;
                    role = Convert.ToString(reader["role"]) ?? string.Empty;
                    isActive = reader["is_active"] is not DBNull && Convert.ToBoolean(reader["is_active"]);
                }
            }

            if (!BCrypt.Net.BCrypt.Verify(pin, passwordHash))
            {
                administratorUserId = 0;
                return false;
            }

            if (!isActive)
            {
                administratorUserId = 0;
                errorMessage = "This administrator account is inactive and cannot authorize deposits.";
                return false;
            }

            if (!string.Equals(role, "admin", StringComparison.Ordinal))
            {
                administratorUserId = 0;
                errorMessage = "This account is not authorized to approve deposits.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private bool TryGetDepositAmount(out decimal amount)
        {
            string text = txtAmountDisplay.Text.Replace("P", "").Replace("₱", "").Trim();
            if (decimal.TryParse(text, out amount) && CashAmountValidator.IsValid(amount)) return true;
            amount = 0;
            MessageBox.Show(
                "Invalid deposit amount. Only ₱50, ₱100, ₱200, ₱500, and ₱1,000 bills are accepted.",
                "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private decimal GetPendingTotal()
        {
            decimal total = 0;
            foreach (decimal amount in pendingAllocation.Values) total += amount;
            return total;
        }

        private bool TryValidatePendingAmount()
        {
            if (!TryGetDepositAmount(out decimal currentAmount))
            {
                ClearPendingDepositState();
                return false;
            }

            if (currentAmount == pendingDepositAmount) return true;

            ClearPendingDepositState();
            MessageBox.Show(
                "The deposit amount has changed. Please select the deposit method again.",
                "Deposit Method Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        public void SelectSpecificCategory(string category)
        {
            if (category != null && category != "Needs" && category != "Wants" && category != "Savings") return;

            pendingSpecificCategory = category;
            UpdateSpecificPreview();
            UpdateCategoryButtonStyles();
            if (category != null && selectedMethod == "Specific")
            {
                lblSpecificReview.Text = $"Deposit amount: ₱{pendingSpecificAmount:F2}\r\nCategory: {pendingSpecificCategory}";
                pnlCategorySelection.Visible = false;
                pnlSpecificReview.Visible = true;
                btnConfirm.Visible = true;
            }
        }

        private void btnChangeCategory_Click(object sender, EventArgs e)
        {
            pnlSpecificReview.Visible = false;
            pnlCategorySelection.Visible = true;
            btnConfirm.Visible = true;
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string category)
            {
                SelectSpecificCategory(category);
            }
        }

        private void UpdateCategoryButtonStyles()
        {
            SetCategoryButtonStyle(btnNeeds, "Needs");
            SetCategoryButtonStyle(btnWants, "Wants");
            SetCategoryButtonStyle(btnSavings, "Savings");
        }

        private void SetCategoryButtonStyle(Button button, string category)
        {
            bool isSelected = pendingSpecificCategory == category;
            button.BackColor = isSelected ? System.Drawing.Color.FromArgb(8, 80, 145) : System.Drawing.Color.WhiteSmoke;
            button.ForeColor = isSelected ? System.Drawing.Color.White : System.Drawing.Color.Black;
            button.FlatAppearance.BorderColor = isSelected ? System.Drawing.Color.FromArgb(8, 80, 145) : System.Drawing.Color.Gray;
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
            ClearPendingDepositState();
        }

        private void ClearPendingDepositState()
        {
            selectedMethod = null;
            pendingAllocation = null;
            pendingSpecificCategory = null;
            pendingSpecificAmount = 0;
            pendingDepositAmount = 0;
            pnlCategorySelection.Visible = false;
            pnlSpecificReview.Visible = false;
            btnConfirm.Visible = true;
            UpdateCategoryButtonStyles();
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

        private void DepositForm_Resize(object sender, EventArgs e)
        {
            ApplyResponsiveLayout();
            PositionConfirmButton();
        }

        private void DepositForm_Shown(object sender, EventArgs e)
        {
            pnlFooter.Visible = true;
            pnlActionBar.Visible = true;
            btnConfirm.Visible = true;
            btnConfirm.BringToFront();
            pnlFooter.PerformLayout();
            pnlActionBar.PerformLayout();
            PositionConfirmButton();
            WriteConfirmButtonDiagnostics();
        }

        private void PositionConfirmButton()
        {
            if (pnlActionBar == null || btnConfirm == null)
                return;

            btnConfirm.Size = new Size(150, 38);
            btnConfirm.Location = new Point(
                Math.Max(0, pnlActionBar.ClientSize.Width - btnConfirm.Width - 24),
                7);
        }

        private void WriteConfirmButtonDiagnostics()
        {
            Debug.WriteLine(
                $"DepositForm CONFIRM diagnostics: pnlFooter.ClientSize={pnlFooter.ClientSize}; " +
                $"pnlActionBar.ClientSize={pnlActionBar.ClientSize}; " +
                $"btnConfirm.Bounds={btnConfirm.Bounds}; btnConfirm.Visible={btnConfirm.Visible}; " +
                $"btnConfirm.Parent={btnConfirm.Parent?.Name ?? "<none>"}; " +
                $"pnlActionBar.Controls.Contains(btnConfirm)={pnlActionBar.Controls.Contains(btnConfirm)}");
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void DepositForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            clockTimer.Stop();
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = DateTime.Now.ToString("MMM dd, yyyy | hh:mm tt");
        }

        private void ApplyResponsiveLayout()
        {
            if (pnlAmountBox == null)
                return;

            int contentLeft = Math.Max(24, (pnlContent.ClientSize.Width - pnlAmountBox.Width) / 2);
            pnlAmountBox.Left = contentLeft;
            pnlOptions.Left = contentLeft;
            pnlCategorySelection.Left = contentLeft;
            pnlSpecificReview.Left = contentLeft;
            label1.Left = contentLeft;
            lblChooseMethod.Left = contentLeft;
            lblAmountHint.Left = contentLeft + Math.Max(0, (pnlAmountBox.Width - lblAmountHint.Width) / 2);
            lblSectionTitle.Left = Math.Max(24, (pnlContent.ClientSize.Width - lblSectionTitle.Width) / 2);
        }
    }
}