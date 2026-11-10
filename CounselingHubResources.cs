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
            int availableWidth = cardsPanel.ClientSize.Width;
            int width = Math.Min(520, Math.Max(240, (availableWidth - 40) / 2));
            int cardHeight = width < 300 ? 240 : 180;
            int horizontalPadding = Math.Max(0, (availableWidth - (width * 2) - 40) / 2);
            cardsPanel.Padding = new Padding(horizontalPadding, 14, horizontalPadding, 14);
            foreach (Control card in cardsPanel.Controls)
            {
                card.Width = width;
                card.Height = cardHeight;
            }

            if (contentView != null)
            {
                int contentPadding = Math.Max(48, (contentView.ClientSize.Width - 1400) / 2);
                contentView.Padding = new Padding(contentPadding, 26, contentPadding, 26);
            }
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
                'A' => """
                    A budget is a plan for how you will use the money you receive. It helps you understand where your money goes, make informed choices, and keep spending aligned with your priorities.

                    A. UNDERSTANDING BUDGETING
                    A budget compares your income with your planned expenses and savings. Planning ahead can help you cover important costs, avoid overspending, and prepare for future needs.

                    B. APPLY THE 50/30/20 BUDGETING RULE
                    The 50/30/20 rule is a general guide: about 50% for needs, 30% for wants, and 20% for savings. Adjust it to your circumstances and actual expenses; it is not a mandatory rule.

                    Example for a ₱10,000 deposit:
                    • Needs — ₱5,000 (50%) for essentials such as food, transportation, and utilities.
                    • Wants — ₱3,000 (30%) for non-essential expenses such as entertainment and personal purchases.
                    • Savings — ₱2,000 (20%) for future goals and emergencies.

                    C. PRIORITIZE ESSENTIAL EXPENSES
                    Plan for necessary expenses such as food, transportation, and utilities before spending on non-essential items. This helps protect the money needed for everyday needs.

                    D. TRACK INCOME AND EXPENSES
                    Record deposits and withdrawals and regularly review the remaining balance in each category. Keeping track helps you notice changes early and make adjustments before a balance runs low.

                    E. SET REALISTIC SPENDING LIMITS
                    Choose a spending limit for each category based on your income and essential costs. A realistic limit makes it easier to follow your plan and avoid spending more than you intended.

                    PRACTICAL RECOMMENDATION
                    Create a budget before spending your money. Always prioritize essential expenses and regularly review your remaining balances to avoid overspending.
                    """,
                'B' => BuildSavingAdvice(),
                'C' => BuildSpendingAdvice(),
                _ => """
                    Financial guidance can help you understand your options and make a plan when managing money feels difficult.

                    A. PURPOSE OF FINANCIAL ASSISTANCE
                    You can seek guidance if you are having trouble managing your budget, controlling expenses, or reaching your savings goals. Discussing your situation may help you identify practical next steps.

                    B. WHEN TO SEEK ASSISTANCE
                    Consider asking for guidance if you:
                    • Have difficulty managing monthly expenses.
                    • Frequently run out of budget before the next deposit.
                    • Find it difficult to maintain savings.
                    • Are unsure how to allocate money among budget categories.
                    • Have difficulty controlling unnecessary spending.

                    C. AVAILABLE SUPPORT INFORMATION
                    No official contact details are configured in this application. Do not rely on unverified contact information.

                    D. CONTACT INFORMATION AVAILABILITY
                    Contact information is currently unavailable. Please coordinate with the appropriate project administrator or designated support personnel for assistance.

                    PRACTICAL RECOMMENDATION
                    Seeking guidance when experiencing budgeting difficulties can help you understand your financial situation and make better financial decisions.
                    """
            };
            selectionView.Visible = false;
            contentView.Visible = true;
            confirmButton.Visible = false;
            backButton.Visible = false;
            contentBackButton.Visible = true;
        }

        private string BuildSavingAdvice()
        {
            var personalizedInsight = string.Empty;
            try
            {
                var goals = budgetRepository.GetGoalsForUser(userId);
                if (goals.Count > 0)
                {
                    var goal = goals.OrderByDescending(g => g.CurrentBalance).First();
                    personalizedInsight = $"\r\n\r\nYour current savings goal for {goal.CategoryName} is set up in Goal Planning. Review its progress regularly and keep your contributions consistent.";
                }
            }
            catch { }

            return """
                Saving regularly can help you prepare for planned expenses, emergencies, and future goals. Choose an amount you can sustain and make saving part of your budget.

                A. SET CLEAR SAVINGS GOALS
                Decide what you are saving for, set a specific target amount, and choose a realistic deadline. A clear goal makes it easier to plan how much to contribute and track your progress.

                B. SAVE CONSISTENTLY
                Set aside a portion of every deposit rather than waiting to see whether money is left over. Even small, regular contributions can build over time.

                C. BUILD AN EMERGENCY FUND
                Keep money available for unexpected expenses, such as an urgent repair or an unplanned essential cost. An emergency fund can reduce the need to disrupt other goals when surprises occur.

                D. AVOID UNNECESSARY PURCHASES
                Before buying non-essential items, consider whether the purchase fits your priorities. Reducing some optional spending can free money for your savings goals.

                E. MONITOR SAVINGS PROGRESS
                Review your savings balance and compare it with your target regularly. If your circumstances change, adjust the contribution or deadline to keep the goal realistic.
                """ + personalizedInsight + """

                PRACTICAL RECOMMENDATION
                Develop a consistent savings habit, even if you can only save a small amount. Regular contributions can gradually help you achieve your financial goals.
                """;
        }

        private string BuildSpendingAdvice()
        {
            var personalizedInsight = string.Empty;
            try
            {
                var now = DateTime.Now;
                var categories = budgetRepository.GetAnalyticsCategories(userId, new DateTime(now.Year, now.Month, 1), new DateTime(now.Year, now.Month, 1).AddMonths(1));
                var spendingCategories = categories.Where(c => c.MonthlyWithdrawals > 0).ToList();
                if (spendingCategories.Count > 0)
                {
                    var highest = spendingCategories.OrderByDescending(c => c.MonthlyWithdrawals).First();
                    personalizedInsight = $"Your highest withdrawal this month is in the {highest.Name} category. Review its recent transactions before making another purchase.";
                    var depleted = categories.Where(c => c.AvailableBalance <= 0).Select(c => c.Name).ToList();
                    if (depleted.Count > 0) personalizedInsight += $"\r\n\r\nThe available balance is at or below zero in these categories: {string.Join(", ", depleted)}. Consider pausing non-essential spending in them.";
                }
                else
                {
                    personalizedInsight = "No spending category information is available for this month. Check category balances before making purchases and review your spending when transaction data is available.";
                }
            }
            catch { }

            return """
                Responsible spending means making choices that fit your priorities and available budget. Checking your balances and reviewing purchases can help you manage expenses.

                A. UNDERSTAND NEEDS AND WANTS
                Needs are essential purchases, such as food, transportation, and utilities. Wants are non-essential purchases, such as entertainment or optional personal items. Consider which type an expense is before using your budget.

                B. AVOID IMPULSE BUYING
                Pause before making an unplanned purchase. Give yourself time to decide whether you need the item, whether it fits your budget, and whether the money has a higher-priority use.

                C. MONITOR CATEGORY BALANCES
                Check your available Needs, Wants, and Savings balances before spending. A quick review can help you avoid withdrawing money that is already reserved for another purpose.

                D. MANAGE INSUFFICIENT BUDGET BALANCES
                If a category does not have enough money, consider reducing the expense, postponing the purchase, or adding funds to the category if your budget allows.

                Example:
                If your Wants balance is ₱300 and you want to withdraw ₱500, your available balance is insufficient. Consider reducing the withdrawal to ₱300 or less, postponing the purchase, or depositing additional funds into the Wants category.

                E. REVIEW SPENDING HABITS
                Examine your transaction history regularly to see where your money goes. Look for optional expenses you could reduce and use what you learn to update your budget.

                F. MAKE BETTER FINANCIAL DECISIONS
                Spend within the available category balance and avoid unnecessary withdrawals. If your priorities change, review your budget first rather than relying on money assigned to another purpose.
                """ + (string.IsNullOrWhiteSpace(personalizedInsight) ? string.Empty : "\r\n\r\nTHIS MONTH'S SPENDING\r\n" + personalizedInsight) + """

                PRACTICAL RECOMMENDATION
                Before making a purchase, check your available category balance and consider whether the expense is necessary. Avoid spending more than your allocated budget.
                """;
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
