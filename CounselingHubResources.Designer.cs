using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    partial class CounselingHub_Resources
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label appNameLabel;
        private Label subtitleLabel;
        private Panel selectionView;
        private Label selectionTitleLabel;
        private Label selectionSubtitleLabel;
        private Label keyboardInstructionLabel;
        private FlowLayoutPanel cardsPanel;
        private Panel contentView;
        private Label contentTitleLabel;
        private RichTextBox contentTextBox;
        private Panel footerPanel;
        private Panel actionBar;
        private Panel securityFooter;
        private Label securityLabel;
        private Label dateTimeLabel;
        private Button backButton;
        private Button confirmButton;
        private Button contentBackButton;
        private System.Windows.Forms.Timer footerClockTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new Panel();
            appNameLabel = new Label();
            subtitleLabel = new Label();
            selectionView = new Panel();
            selectionTitleLabel = new Label();
            selectionSubtitleLabel = new Label();
            keyboardInstructionLabel = new Label();
            cardsPanel = new FlowLayoutPanel();
            contentView = new Panel();
            contentTitleLabel = new Label();
            contentTextBox = new RichTextBox();
            footerPanel = new Panel();
            actionBar = new Panel();
            securityFooter = new Panel();
            securityLabel = new Label();
            dateTimeLabel = new Label();
            backButton = new Button();
            confirmButton = new Button();
            contentBackButton = new Button();
            footerClockTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();

            headerPanel.BackColor = Color.FromArgb(7, 57, 113);
            headerPanel.Controls.Add(appNameLabel);
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 76;
            headerPanel.Padding = new Padding(10);
            appNameLabel.AutoSize = true;
            appNameLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            appNameLabel.ForeColor = Color.White;
            appNameLabel.Location = new Point(96, 13);
            appNameLabel.Text = "SMART CASH DISBURSEMENT";
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            subtitleLabel.ForeColor = Color.FromArgb(164, 213, 255);
            subtitleLabel.Location = new Point(98, 42);
            subtitleLabel.Text = "BUDGETING MACHINE";

            selectionView.Dock = DockStyle.Fill;
            selectionView.Padding = new Padding(35, 12, 35, 12);
            selectionView.Controls.Add(cardsPanel);
            selectionView.Controls.Add(keyboardInstructionLabel);
            selectionView.Controls.Add(selectionSubtitleLabel);
            selectionView.Controls.Add(selectionTitleLabel);
            selectionTitleLabel.Dock = DockStyle.Top;
            selectionTitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            selectionTitleLabel.ForeColor = Color.FromArgb(13, 49, 108);
            selectionTitleLabel.Height = 34;
            selectionTitleLabel.Text = "COUNSELING HUB & RESOURCES";
            selectionTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            selectionSubtitleLabel.Dock = DockStyle.Top;
            selectionSubtitleLabel.Font = new Font("Segoe UI", 11F);
            selectionSubtitleLabel.ForeColor = Color.FromArgb(55, 75, 105);
            selectionSubtitleLabel.Height = 30;
            selectionSubtitleLabel.Text = "REQUEST ADVICE & ACCESS HELPFUL RESOURCES";
            selectionSubtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            keyboardInstructionLabel.Dock = DockStyle.Top;
            keyboardInstructionLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            keyboardInstructionLabel.ForeColor = Color.FromArgb(13, 49, 108);
            keyboardInstructionLabel.Height = 32;
            keyboardInstructionLabel.Text = "SELECT AN OPTION (PRESS A, B, C, OR D)";
            keyboardInstructionLabel.TextAlign = ContentAlignment.MiddleCenter;
            cardsPanel.Dock = DockStyle.Fill;
            cardsPanel.AutoScroll = true;
            cardsPanel.FlowDirection = FlowDirection.LeftToRight;
            cardsPanel.WrapContents = true;
            cardsPanel.Padding = new Padding(0, 10, 0, 10);
            cardsPanel.Resize += cardsPanel_Resize;
            cardsPanel.Controls.Add(CreateOptionCard('A', "BUDGETING TIPS", "Learn simple budgeting tips to manage your money better.", Color.FromArgb(20, 84, 180)));
            cardsPanel.Controls.Add(CreateOptionCard('B', "SAVING TIPS", "Discover smart ways to build your savings and secure your future.", Color.FromArgb(15, 117, 55)));
            cardsPanel.Controls.Add(CreateOptionCard('C', "SPENDING ADVICE", "Get advice on how to reduce unnecessary expenses.", Color.FromArgb(235, 105, 0)));
            cardsPanel.Controls.Add(CreateOptionCard('D', "CONTACT INFO", "View contact information for support and inquiries.", Color.FromArgb(72, 48, 150)));

            contentView.Dock = DockStyle.Fill;
            contentView.Padding = new Padding(60, 30, 60, 20);
            contentView.Visible = false;
            contentView.Controls.Add(contentTextBox);
            contentView.Controls.Add(contentTitleLabel);
            contentTitleLabel.Dock = DockStyle.Top;
            contentTitleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            contentTitleLabel.ForeColor = Color.FromArgb(13, 49, 108);
            contentTitleLabel.Height = 54;
            contentTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            contentTextBox.BackColor = Color.White;
            contentTextBox.BorderStyle = BorderStyle.FixedSingle;
            contentTextBox.Dock = DockStyle.Fill;
            contentTextBox.Font = new Font("Segoe UI", 13F);
            contentTextBox.ReadOnly = true;
            contentTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;

            footerPanel.BackColor = Color.FromArgb(8, 52, 105);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Height = 116;
            footerPanel.Controls.Add(securityFooter);
            footerPanel.Controls.Add(actionBar);
            actionBar.Dock = DockStyle.Top;
            actionBar.Height = 52;
            actionBar.Controls.Add(contentBackButton);
            actionBar.Controls.Add(confirmButton);
            actionBar.Controls.Add(backButton);
            securityFooter.Dock = DockStyle.Fill;
            securityFooter.Controls.Add(securityLabel);
            securityFooter.Controls.Add(dateTimeLabel);
            securityLabel.AutoSize = true;
            securityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            securityLabel.ForeColor = Color.White;
            securityLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            securityLabel.Location = new Point(24, 8);
            securityLabel.Text = "SECURE SYSTEM\r\nYour security is our priority.";
            dateTimeLabel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Font = new Font("Segoe UI", 10F);
            dateTimeLabel.ForeColor = Color.White;
            dateTimeLabel.Location = new Point(800, 21);
            dateTimeLabel.TextAlign = ContentAlignment.MiddleRight;
            backButton.BackColor = Color.FromArgb(90, 100, 115);
            backButton.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            backButton.Cursor = Cursors.Hand;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(24, 7);
            backButton.Size = new Size(110, 38);
            backButton.Text = "←  BACK";
            backButton.Click += backButton_Click;
            confirmButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            confirmButton.BackColor = Color.FromArgb(10, 125, 55);
            confirmButton.Cursor = Cursors.Hand;
            confirmButton.FlatStyle = FlatStyle.Flat;
            confirmButton.FlatAppearance.BorderSize = 0;
            confirmButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            confirmButton.ForeColor = Color.White;
            confirmButton.Size = new Size(150, 38);
            confirmButton.Location = new Point(926, 7);
            confirmButton.Text = "✓  CONFIRM";
            confirmButton.Click += confirmButton_Click;
            contentBackButton.BackColor = Color.FromArgb(90, 100, 115);
            contentBackButton.FlatStyle = FlatStyle.Flat;
            contentBackButton.FlatAppearance.BorderSize = 0;
            contentBackButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            contentBackButton.ForeColor = Color.White;
            contentBackButton.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            contentBackButton.Cursor = Cursors.Hand;
            contentBackButton.Location = new Point(24, 7);
            contentBackButton.Size = new Size(170, 38);
            contentBackButton.Text = "←  OPTIONS";
            contentBackButton.Visible = false;
            contentBackButton.Click += contentBackButton_Click;

            Controls.Add(selectionView);
            Controls.Add(contentView);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(248, 249, 252);
            ClientSize = new Size(1100, 700);
            Name = "CounselingHub_Resources";
            StartPosition = FormStartPosition.Manual;
            Text = "Counseling Hub & Resources";
            WindowState = FormWindowState.Normal;
            KeyPreview = true;
            Shown += CounselingHub_Resources_Shown;
            KeyDown += CounselingHub_Resources_KeyDown;
            FormClosed += CounselingHub_Resources_FormClosed;
            footerClockTimer.Interval = 1000;
            footerClockTimer.Tick += (sender, e) => UpdateDateTime();
            Resize += CounselingHub_Resources_Resize;
            ResumeLayout(false);
        }

        private Panel CreateOptionCard(char option, string title, string description, Color accent)
        {
            var card = new Panel { Name = "card" + option, Tag = option, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Cursor = Cursors.Hand, Margin = new Padding(10), Padding = new Padding(18), Height = 150 };
            var badge = new Label { Text = option.ToString(), BackColor = accent, ForeColor = Color.White, Font = new Font("Segoe UI", 30F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Left, Width = 82 };
            var titleLabel = new Label { Text = title, ForeColor = accent, Font = new Font("Segoe UI", 13F, FontStyle.Bold), Dock = DockStyle.Top, Height = 38, Padding = new Padding(16, 5, 0, 0) };
            var descriptionLabel = new Label { Text = description, ForeColor = Color.FromArgb(35, 35, 35), Font = new Font("Segoe UI", 11F), Dock = DockStyle.Fill, Padding = new Padding(16, 0, 10, 0) };
            card.Controls.Add(descriptionLabel);
            card.Controls.Add(titleLabel);
            card.Controls.Add(badge);
            AddCardClickHandlers(card);
            return card;
        }

        private void cardsPanel_Resize(object sender, System.EventArgs e) { ResizeCards(); }
        private void CounselingHub_Resources_Resize(object sender, System.EventArgs e)
        {
            ResizeCards();
            backButton.Location = new Point(24, 7);
            contentBackButton.Location = new Point(24, 7);
            confirmButton.Location = new Point(Math.Max(24, actionBar.ClientSize.Width - confirmButton.Width - 24), 7);
            dateTimeLabel.Location = new Point(Math.Max(24, securityFooter.ClientSize.Width - dateTimeLabel.Width - 24), Math.Max(0, securityFooter.ClientSize.Height - dateTimeLabel.Height - 10));
        }
    }
}
