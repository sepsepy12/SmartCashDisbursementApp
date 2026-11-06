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
        private Label instructionLabel;
        private FlowLayoutPanel cardsPanel;
        private Panel contentView;
        private Label contentTitleLabel;
        private RichTextBox contentTextBox;
        private Panel footerPanel;
        private Label securityLabel;
        private Label dateTimeLabel;
        private Button backButton;
        private Button confirmButton;
        private Button contentBackButton;

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
            instructionLabel = new Label();
            cardsPanel = new FlowLayoutPanel();
            contentView = new Panel();
            contentTitleLabel = new Label();
            contentTextBox = new RichTextBox();
            footerPanel = new Panel();
            securityLabel = new Label();
            dateTimeLabel = new Label();
            backButton = new Button();
            confirmButton = new Button();
            contentBackButton = new Button();
            SuspendLayout();

            headerPanel.BackColor = Color.FromArgb(8, 52, 105);
            headerPanel.Controls.Add(appNameLabel);
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 88;
            appNameLabel.Dock = DockStyle.Top;
            appNameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            appNameLabel.ForeColor = Color.White;
            appNameLabel.Padding = new Padding(28, 12, 0, 0);
            appNameLabel.Text = "SMART CASH DISBURSEMENT";
            appNameLabel.Height = 48;
            subtitleLabel.Dock = DockStyle.Top;
            subtitleLabel.Font = new Font("Segoe UI", 10F);
            subtitleLabel.ForeColor = Color.FromArgb(180, 225, 245);
            subtitleLabel.Padding = new Padding(30, 0, 0, 0);
            subtitleLabel.Text = "BUDGETING MACHINE";
            subtitleLabel.Height = 28;

            selectionView.Dock = DockStyle.Fill;
            selectionView.Padding = new Padding(35, 18, 35, 12);
            selectionView.Controls.Add(cardsPanel);
            selectionView.Controls.Add(instructionLabel);
            instructionLabel.Dock = DockStyle.Top;
            instructionLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            instructionLabel.ForeColor = Color.FromArgb(13, 49, 108);
            instructionLabel.Height = 48;
            instructionLabel.Text = "COUNSELING HUB & RESOURCES\r\nREQUEST ADVICE & ACCESS HELPFUL RESOURCES\r\n\r\nSELECT AN OPTION (PRESS A, B, C, OR D)";
            instructionLabel.TextAlign = ContentAlignment.MiddleCenter;
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
            footerPanel.Height = 64;
            footerPanel.Controls.Add(securityLabel);
            footerPanel.Controls.Add(dateTimeLabel);
            footerPanel.Controls.Add(contentBackButton);
            footerPanel.Controls.Add(confirmButton);
            footerPanel.Controls.Add(backButton);
            securityLabel.AutoSize = true;
            securityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            securityLabel.ForeColor = Color.White;
            securityLabel.Location = new Point(24, 12);
            securityLabel.Text = "SECURE SYSTEM\r\nYour security is our priority.";
            dateTimeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Font = new Font("Segoe UI", 10F);
            dateTimeLabel.ForeColor = Color.White;
            dateTimeLabel.Location = new Point(800, 22);
            dateTimeLabel.TextAlign = ContentAlignment.MiddleRight;
            backButton.BackColor = Color.FromArgb(90, 100, 115);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(250, 13);
            backButton.Size = new Size(110, 38);
            backButton.Text = "←  BACK";
            backButton.Click += backButton_Click;
            confirmButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            confirmButton.BackColor = Color.FromArgb(10, 125, 55);
            confirmButton.FlatStyle = FlatStyle.Flat;
            confirmButton.FlatAppearance.BorderSize = 0;
            confirmButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            confirmButton.ForeColor = Color.White;
            confirmButton.Size = new Size(150, 38);
            confirmButton.Text = "✓  CONFIRM";
            confirmButton.Click += confirmButton_Click;
            contentBackButton.BackColor = Color.FromArgb(90, 100, 115);
            contentBackButton.FlatStyle = FlatStyle.Flat;
            contentBackButton.FlatAppearance.BorderSize = 0;
            contentBackButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            contentBackButton.ForeColor = Color.White;
            contentBackButton.Location = new Point(390, 13);
            contentBackButton.Size = new Size(170, 38);
            contentBackButton.Text = "←  OPTIONS";
            contentBackButton.Visible = false;
            contentBackButton.Click += contentBackButton_Click;

            Controls.Add(selectionView);
            Controls.Add(contentView);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 252);
            ClientSize = new Size(1100, 700);
            MinimumSize = new Size(760, 560);
            Name = "CounselingHub_Resources";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Counseling Hub & Resources";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            KeyPreview = true;
            KeyDown += CounselingHub_Resources_KeyDown;
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
            backButton.Location = new Point(24, 13);
            contentBackButton.Location = new Point(24, 13);
            confirmButton.Location = new Point(Math.Max(24, footerPanel.ClientSize.Width - confirmButton.Width - 24), 13);
            dateTimeLabel.Location = new Point(Math.Max(400, footerPanel.ClientSize.Width - dateTimeLabel.Width - 24), 22);
        }
    }
}
