using System;
using System.Windows.Forms;
using System.Linq;

namespace SmartCashDisbursementApp
{
    public partial class CounselingHub_Resources : Form
    {
        private readonly int userId;
        private readonly BudgetRepository budgetRepository = new BudgetRepository();
        private char? selectedOption;

        public CounselingHub_Resources(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            UpdateDateTime();
            SelectOption('A');
            selectedOption = null;
            UpdateCardStyles();
            footerClockTimer.Start();
        }

        public void SelectOption(char option)
        {
            option = char.ToUpperInvariant(option);
            if (option < 'A' || option > 'D') return;
            selectedOption = option;
            UpdateCardStyles();
        }

        private void AddCardClickHandlers(Control control)
        {
            control.Click += card_Click;
            foreach (Control child in control.Controls) AddCardClickHandlers(child);
        }

        private void card_Click(object? sender, EventArgs e)
        {
            var control = sender as Control;
            while (control != null && control.Tag is not char) control = control.Parent;
            if (control?.Tag is char option) SelectOption(option);
        }

        private void UpdateCardStyles()
        {
            foreach (Control control in cardsPanel.Controls)
            {
                if (control is Panel card && card.Tag is char option)
                {
                    card.BackColor = selectedOption == option ? Color.FromArgb(225, 237, 255) : Color.White;
                    card.BorderStyle = selectedOption == option ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
                }
            }
        }

        private void ResizeCards()
        {
            if (cardsPanel == null) return;
            int width = Math.Max(240, (cardsPanel.ClientSize.Width - cardsPanel.Padding.Horizontal - 40) / 2);
            foreach (Control card in cardsPanel.Controls) card.Width = width;
        }

        private void confirmButton_Click(object? sender, EventArgs e)
        {
            if (!selectedOption.HasValue)
            {
                MessageBox.Show("Please select an option before continuing.", "Counseling Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowContent(selectedOption.Value);
        }

        private void ShowContent(char option)
        {
            contentTitleLabel.Text = option switch
            {
                'A' => "A — BUDGETING TIPS",
                'B' => "B — SAVING TIPS",
                'C' => "C — SPENDING ADVICE",
                _ => "D — CONTACT INFO"
            };
            contentTextBox.Text = option switch
            {
                'A' => "Track all cash received and expenses so you know where your money goes.\r\n\r\n• Separate needs from wants before making a purchase.\r\n• The 50/30/20 guideline can be a useful reference: about 50% for needs, 30% for wants, and 20% for savings. It is not a mandatory rule and should be adjusted to your circumstances.\r\n• Set a spending limit for each category.\r\n• Review remaining balances regularly.\r\n• Avoid spending money already assigned to savings or essential expenses.",
                'B' => BuildSavingAdvice(),
                'C' => BuildSpendingAdvice(),
                _ => "Support contact details have not been configured for this installation.\r\n\r\nPlease ask the institution or system administrator to configure the official support contact information. No unverified telephone numbers, email addresses, or office locations are shown here."
            };
            selectionView.Visible = false;
            contentView.Visible = true;
            confirmButton.Visible = false;
            backButton.Visible = false;
            contentBackButton.Visible = true;
        }

        private string BuildSavingAdvice()
        {
            try
            {
                var goals = budgetRepository.GetGoalsForUser(userId);
                if (goals.Count > 0)
                {
                    var goal = goals.OrderByDescending(g => g.CurrentBalance).First();
                    return $"Set a clear savings target and save a portion of money received before discretionary spending.\r\n\r\n• Avoid unnecessary purchases and compare prices before buying.\r\n• Keep savings separate from everyday spending money.\r\n• Monitor progress toward your saved goals.\r\n\r\nYour saved goal for {goal.CategoryName} is already available in Goal Planning. Review it regularly and keep contributions consistent.\r\n\r\nSmall, regular contributions can be more manageable than waiting to save whatever remains at the end of the month.";
                }
            }
            catch { }
            return "Set a clear savings target and save a portion of money received before discretionary spending.\r\n\r\n• Avoid unnecessary purchases.\r\n• Compare prices before buying.\r\n• Keep savings separate from everyday spending money.\r\n• Monitor progress toward saved goals.\r\n\r\nNo saved goals are currently available. You can create one in Goal Planning and review your progress regularly.";
        }

        private string BuildSpendingAdvice()
        {
            try
            {
                var now = DateTime.Now;
                var categories = budgetRepository.GetAnalyticsCategories(userId, new DateTime(now.Year, now.Month, 1), new DateTime(now.Year, now.Month, 1).AddMonths(1));
                var spendingCategories = categories.Where(c => c.MonthlyWithdrawals > 0).ToList();
                if (spendingCategories.Count > 0)
                {
                    var highest = spendingCategories.OrderByDescending(c => c.MonthlyWithdrawals).First();
                    var advice = $"This month's highest withdrawal category is {highest.Name}. Review its recent transactions before making another withdrawal.";
                    var depleted = categories.Where(c => c.AvailableBalance <= 0).Select(c => c.Name).ToList();
                    if (depleted.Count > 0) advice += $"\r\n\r\nAvailable balance is at or below zero for: {string.Join(", ", depleted)}. Consider pausing non-essential spending in these categories.";
                    return advice + "\r\n\r\nKeep spending within available funds and review transactions regularly. If spending is high compared with available funds, delay non-essential purchases and reassess your category limits.";
                }
            }
            catch { }
            return "Review your transactions before making another withdrawal. Identify which categories receive the most spending, avoid unnecessary expenses, and check that money remains available for essential needs.\r\n\r\nPersonalized category advice is not available until transaction and category data can be loaded.";
        }

        private void contentBackButton_Click(object? sender, EventArgs e)
        {
            contentView.Visible = false;
            selectionView.Visible = true;
            confirmButton.Visible = true;
            backButton.Visible = true;
            contentBackButton.Visible = false;
        }

        private void backButton_Click(object? sender, EventArgs e) => Close();

        private void CounselingHub_Resources_Shown(object? sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Bounds = Screen.FromControl(this).Bounds;
        }

        private void CounselingHub_Resources_FormClosed(object? sender, FormClosedEventArgs e) => footerClockTimer.Stop();

        private void CounselingHub_Resources_KeyDown(object? sender, KeyEventArgs e)
        {
            if (contentView.Visible)
            {
                if (e.KeyCode == Keys.Escape) contentBackButton.PerformClick();
                return;
            }
            if (e.KeyCode is Keys.A or Keys.B or Keys.C or Keys.D) SelectOption((char)('A' + (e.KeyCode - Keys.A)));
            else if (e.KeyCode == Keys.Enter) confirmButton.PerformClick();
            else if (e.KeyCode == Keys.Escape) backButton.PerformClick();
        }

        private void UpdateDateTime() => dateTimeLabel.Text = DateTime.Now.ToString("MMM d, yyyy | h:mm tt");
    }
}
