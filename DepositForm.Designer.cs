using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    partial class DepositForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
			if (disposing)
            {
				clockTimer?.Stop();
				components?.Dispose();
            }
            base.Dispose(disposing);
        }

		private void InitializeComponent()
		{
			components = new Container();
			pnlHeader = new Panel();
			lblAppName = new Label();
			lblSectionTitle = new Label();
			lblSubTitle = new Label();
			pnlContent = new Panel();
			pnlAmountBox = new Panel();
			lblPeso = new Label();
			txtAmountDisplay = new TextBox();
			lblAmountHint = new Label();
			lblChooseMethod = new Label();
			pnlOptions = new Panel();
			pnlAuto = new Panel();
			pbAuto = new PictureBox();
			lblAutoTitle = new Label();
			lblAutoDesc = new Label();
			pnlSpecific = new Panel();
			pbSpecific = new PictureBox();
			lblSpecificTitle = new Label();
			lblSpecificDesc = new Label();
			pnlCategorySelection = new Panel();
			btnNeeds = new Button();
			btnWants = new Button();
			btnSavings = new Button();
			pnlSpecificReview = new Panel();
			lblSpecificReview = new Label();
			btnChangeCategory = new Button();
			pnlFooter = new Panel();
			pnlActionBar = new Panel();
			lblFooter = new Label();
			lblDateTime = new Label();
			btnBack = new Button();
			btnConfirm = new Button();
			label1 = new Label();
			clockTimer = new System.Windows.Forms.Timer(components);
			pnlHeader.SuspendLayout();
			pnlContent.SuspendLayout();
			pnlAmountBox.SuspendLayout();
			pnlOptions.SuspendLayout();
			pnlAuto.SuspendLayout();
			((ISupportInitialize)pbAuto).BeginInit();
			pnlSpecific.SuspendLayout();
			((ISupportInitialize)pbSpecific).BeginInit();
			pnlCategorySelection.SuspendLayout();
			pnlSpecificReview.SuspendLayout();
			pnlFooter.SuspendLayout();
			pnlActionBar.SuspendLayout();
			SuspendLayout();
			// 
			// pnlHeader
			// 
			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblAppName);
			pnlHeader.Controls.Add(lblSubTitle);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Location = new Point(0, 0);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new Size(800, 76);
			pnlHeader.TabIndex = 6;
			// 
			// lblAppName
			// 
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(96, 13);
			lblAppName.Name = "lblAppName";
			lblAppName.Size = new Size(340, 31);
			lblAppName.TabIndex = 0;
			lblAppName.Text = "SMART CASH DISBURSEMENT";
			// 
			// lblSectionTitle
			// 
			lblSectionTitle.AutoSize = true;
			lblSectionTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			lblSectionTitle.Location = new Point(330, 16);
			lblSectionTitle.Name = "lblSectionTitle";
			lblSectionTitle.Size = new Size(149, 30);
			lblSectionTitle.TabIndex = 5;
			lblSectionTitle.Text = "CASH DEPOSIT";
			// 
			// lblSubTitle
			// 
			lblSubTitle.AutoSize = true;
			lblSubTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			lblSubTitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblSubTitle.Location = new Point(98, 42);
			lblSubTitle.Name = "lblSubTitle";
			lblSubTitle.Size = new Size(190, 20);
			lblSubTitle.TabIndex = 4;
			lblSubTitle.Text = "BUDGETING MACHINE";
			// 
			// pnlAmountBox
			// 
			pnlAmountBox.BackColor = Color.WhiteSmoke;
			pnlAmountBox.BorderStyle = BorderStyle.FixedSingle;
			pnlAmountBox.Controls.Add(lblPeso);
			pnlAmountBox.Controls.Add(txtAmountDisplay);
			pnlAmountBox.Location = new Point(140, 76);
			pnlAmountBox.Name = "pnlAmountBox";
			pnlAmountBox.Size = new Size(520, 70);
			pnlAmountBox.TabIndex = 3;
			pnlAmountBox.Paint += pnlAmountBox_Paint;
			// 
			// lblPeso
			// 
			lblPeso.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			lblPeso.Location = new Point(20, 12);
			lblPeso.Name = "lblPeso";
			lblPeso.Size = new Size(40, 40);
			lblPeso.TabIndex = 0;
			lblPeso.Text = "₱";
			lblPeso.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// txtAmountDisplay
			// 
			txtAmountDisplay.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			txtAmountDisplay.Location = new Point(70, 12);
			txtAmountDisplay.Name = "txtAmountDisplay";
			txtAmountDisplay.Size = new Size(430, 39);
			txtAmountDisplay.TabIndex = 1;
			txtAmountDisplay.Text = "0.00";
			txtAmountDisplay.TextAlign = HorizontalAlignment.Center;
			// 
			// lblAmountHint
			// 
			lblAmountHint.AutoSize = true;
			lblAmountHint.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
			lblAmountHint.Location = new Point(330, 149);
			lblAmountHint.Name = "lblAmountHint";
			lblAmountHint.Size = new Size(192, 15);
			lblAmountHint.TabIndex = 2;
			lblAmountHint.Text = "(Enter amount via numeric keypad)";
			// 
			// lblChooseMethod
			// 
			lblChooseMethod.AutoSize = true;
			lblChooseMethod.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblChooseMethod.Location = new Point(140, 164);
			lblChooseMethod.Name = "lblChooseMethod";
			lblChooseMethod.Size = new Size(212, 21);
			lblChooseMethod.TabIndex = 1;
			lblChooseMethod.Text = "2. Choose deposit method:";
			// 
			// pnlOptions
			// 
			pnlOptions.Controls.Add(pnlAuto);
			pnlOptions.Controls.Add(pnlSpecific);
			pnlOptions.Location = new Point(140, 194);
			pnlOptions.Name = "pnlOptions";
			pnlOptions.Size = new Size(520, 140);
			pnlOptions.TabIndex = 0;
			// 
			// pnlAuto
			// 
			pnlAuto.BorderStyle = BorderStyle.FixedSingle;
			pnlAuto.Controls.Add(pbAuto);
			pnlAuto.Controls.Add(lblAutoTitle);
			pnlAuto.Controls.Add(lblAutoDesc);
			pnlAuto.Cursor = Cursors.Hand;
			pnlAuto.Location = new Point(0, 0);
			pnlAuto.Name = "pnlAuto";
			pnlAuto.Size = new Size(260, 140);
			pnlAuto.TabIndex = 0;
			pnlAuto.Click += button1_Click;
			// 
			// pbAuto
			// 
			pbAuto.Location = new Point(12, 20);
			pbAuto.Name = "pbAuto";
			pbAuto.Size = new Size(64, 64);
			pbAuto.SizeMode = PictureBoxSizeMode.Zoom;
			pbAuto.TabIndex = 0;
			pbAuto.TabStop = false;
			pbAuto.Click += button1_Click;
			// 
			// lblAutoTitle
			// 
			lblAutoTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblAutoTitle.Location = new Point(90, 20);
			lblAutoTitle.Name = "lblAutoTitle";
			lblAutoTitle.Size = new Size(165, 42);
			lblAutoTitle.TabIndex = 1;
			lblAutoTitle.Text = "A. Automated Budgeting System";
			lblAutoTitle.Click += button1_Click;
			// 
			// lblAutoDesc
			// 
			lblAutoDesc.Font = new Font("Segoe UI", 9F);
			lblAutoDesc.Location = new Point(90, 62);
			lblAutoDesc.Name = "lblAutoDesc";
			lblAutoDesc.Size = new Size(160, 60);
			lblAutoDesc.TabIndex = 2;
			lblAutoDesc.Text = "(Allocate to pre-set categories)";
			lblAutoDesc.Click += lblAutoDesc_Click;
			// 
			// pnlSpecific
			// 
			pnlSpecific.BorderStyle = BorderStyle.FixedSingle;
			pnlSpecific.Controls.Add(pbSpecific);
			pnlSpecific.Controls.Add(lblSpecificTitle);
			pnlSpecific.Controls.Add(lblSpecificDesc);
			pnlSpecific.Cursor = Cursors.Hand;
			pnlSpecific.Location = new Point(270, 0);
			pnlSpecific.Name = "pnlSpecific";
			pnlSpecific.Size = new Size(250, 140);
			pnlSpecific.TabIndex = 1;
			pnlSpecific.Click += button5_Click;
			// 
			// pbSpecific
			// 
			pbSpecific.Location = new Point(12, 20);
			pbSpecific.Name = "pbSpecific";
			pbSpecific.Size = new Size(64, 64);
			pbSpecific.SizeMode = PictureBoxSizeMode.Zoom;
			pbSpecific.TabIndex = 0;
			pbSpecific.TabStop = false;
			pbSpecific.Click += button5_Click;
			// 
			// lblSpecificTitle
			// 
			lblSpecificTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblSpecificTitle.Location = new Point(90, 20);
			lblSpecificTitle.Name = "lblSpecificTitle";
			lblSpecificTitle.Size = new Size(150, 42);
			lblSpecificTitle.TabIndex = 1;
			lblSpecificTitle.Text = "B. Specific Section Deposit";
			lblSpecificTitle.Click += button5_Click;
			// 
			// lblSpecificDesc
			// 
			lblSpecificDesc.Font = new Font("Segoe UI", 9F);
			lblSpecificDesc.Location = new Point(90, 62);
			lblSpecificDesc.Name = "lblSpecificDesc";
			lblSpecificDesc.Size = new Size(150, 60);
			lblSpecificDesc.TabIndex = 2;
			lblSpecificDesc.Text = "(Select a specific budget category)";
			lblSpecificDesc.Click += lblSpecificDesc_Click;
			// 
			// pnlCategorySelection
			// 
			pnlCategorySelection.Controls.Add(btnSavings);
			pnlCategorySelection.Controls.Add(btnWants);
			pnlCategorySelection.Controls.Add(btnNeeds);
			pnlCategorySelection.Location = new Point(140, 344);
			pnlCategorySelection.Name = "pnlCategorySelection";
			pnlCategorySelection.Size = new Size(520, 70);
			pnlCategorySelection.TabIndex = 9;
			pnlCategorySelection.Visible = false;
			pnlSpecificReview.BackColor = Color.White;
			pnlSpecificReview.BorderStyle = BorderStyle.FixedSingle;
			pnlSpecificReview.Controls.Add(lblSpecificReview);
			pnlSpecificReview.Controls.Add(btnChangeCategory);
			pnlSpecificReview.Location = new Point(140, 344);
			pnlSpecificReview.Name = "pnlSpecificReview";
			pnlSpecificReview.Size = new Size(520, 70);
			pnlSpecificReview.Visible = false;
			lblSpecificReview.Dock = DockStyle.Top;
			lblSpecificReview.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblSpecificReview.Height = 40;
			lblSpecificReview.ForeColor = Color.FromArgb(20, 42, 78);
			lblSpecificReview.TextAlign = ContentAlignment.MiddleCenter;
			btnChangeCategory.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnChangeCategory.BackColor = Color.FromArgb(90, 100, 115);
			btnChangeCategory.FlatAppearance.BorderSize = 0;
			btnChangeCategory.FlatStyle = FlatStyle.Flat;
			btnChangeCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			btnChangeCategory.ForeColor = Color.White;
			btnChangeCategory.Location = new Point(360, 40);
			btnChangeCategory.Name = "btnChangeCategory";
			btnChangeCategory.Size = new Size(150, 26);
			btnChangeCategory.Text = "CHANGE CATEGORY";
			btnChangeCategory.UseVisualStyleBackColor = false;
			btnChangeCategory.Click += btnChangeCategory_Click;
			// btnNeeds
			// 
			btnNeeds.BackColor = Color.WhiteSmoke;
			btnNeeds.FlatStyle = FlatStyle.Flat;
			btnNeeds.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			btnNeeds.Location = new Point(0, 10);
			btnNeeds.Name = "btnNeeds";
			btnNeeds.Size = new Size(165, 50);
			btnNeeds.TabIndex = 0;
			btnNeeds.Tag = "Needs";
			btnNeeds.Text = "NEEDS";
			btnNeeds.UseVisualStyleBackColor = false;
			btnNeeds.Click += CategoryButton_Click;
			// 
			// btnWants
			// 
			btnWants.BackColor = Color.WhiteSmoke;
			btnWants.FlatStyle = FlatStyle.Flat;
			btnWants.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			btnWants.Location = new Point(177, 10);
			btnWants.Name = "btnWants";
			btnWants.Size = new Size(165, 50);
			btnWants.TabIndex = 1;
			btnWants.Tag = "Wants";
			btnWants.Text = "WANTS";
			btnWants.UseVisualStyleBackColor = false;
			btnWants.Click += CategoryButton_Click;
			// 
			// btnSavings
			// 
			btnSavings.BackColor = Color.WhiteSmoke;
			btnSavings.FlatStyle = FlatStyle.Flat;
			btnSavings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			btnSavings.Location = new Point(354, 10);
			btnSavings.Name = "btnSavings";
			btnSavings.Size = new Size(165, 50);
			btnSavings.TabIndex = 2;
			btnSavings.Tag = "Savings";
			btnSavings.Text = "SAVINGS";
			btnSavings.UseVisualStyleBackColor = false;
			btnSavings.Click += CategoryButton_Click;
			// 
			// pnlFooter
			// 
			pnlFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlFooter.Controls.Add(lblDateTime);
			pnlFooter.Controls.Add(lblFooter);
			pnlFooter.Controls.Add(pnlActionBar);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Name = "pnlFooter";
			pnlFooter.Visible = true;
			pnlFooter.Height = 116;
			pnlFooter.TabIndex = 7;
			pnlActionBar.BackColor = Color.FromArgb(8, 52, 105);
			pnlActionBar.Controls.Add(btnBack);
			pnlActionBar.Controls.Add(btnConfirm);
			pnlActionBar.Dock = DockStyle.Top;
			pnlActionBar.Visible = true;
			pnlActionBar.Height = 52;
			// 
			// lblFooter
			// 
			lblFooter.AutoSize = false;
			lblFooter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblFooter.ForeColor = Color.White;
			lblFooter.Location = new Point(24, 60);
			lblFooter.Name = "lblFooter";
			lblFooter.Size = new Size(300, 44);
			lblFooter.TabIndex = 0;
			lblFooter.Text = "SECURE SYSTEM\r\nYour security is our priority.";
			lblFooter.TextAlign = ContentAlignment.MiddleLeft;
			lblDateTime.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			lblDateTime.AutoSize = true;
			lblDateTime.Font = new Font("Segoe UI", 10F);
			lblDateTime.ForeColor = Color.White;
			lblDateTime.Location = new Point(620, 75);
			lblDateTime.TextAlign = ContentAlignment.MiddleRight;
			// 
			// btnBack
			// 
			btnBack.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			btnBack.BackColor = Color.FromArgb(90, 100, 115);
			btnBack.Cursor = Cursors.Hand;
			btnBack.FlatAppearance.BorderSize = 0;
			btnBack.FlatStyle = FlatStyle.Flat;
			btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnBack.ForeColor = Color.White;
			btnBack.Location = new Point(24, 7);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(110, 38);
			btnBack.TabIndex = 1;
			btnBack.Text = "←  BACK";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += button3_Click;
			// 
			// btnConfirm
			// 
			btnConfirm.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			btnConfirm.BackColor = Color.FromArgb(10, 125, 55);
			btnConfirm.Cursor = Cursors.Hand;
			btnConfirm.FlatAppearance.BorderSize = 0;
			btnConfirm.FlatStyle = FlatStyle.Flat;
			btnConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnConfirm.ForeColor = Color.White;
			btnConfirm.Location = new Point(626, 7);
			btnConfirm.Name = "btnConfirm";
			btnConfirm.Size = new Size(150, 38);
			btnConfirm.TabIndex = 2;
			btnConfirm.Text = "CONFIRM";
			btnConfirm.Visible = true;
			btnConfirm.UseVisualStyleBackColor = false;
			btnConfirm.Click += button4_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(140, 52);
			label1.Name = "label1";
			label1.Size = new Size(313, 21);
			label1.TabIndex = 8;
			label1.Text = "1. How much would you like to deposit?";
			label1.Click += label1_Click;
			// 
			// DepositForm
			// 
			AutoScaleDimensions = new SizeF(12F, 30F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 600);
			pnlContent.AutoScroll = true;
			pnlContent.BackColor = Color.WhiteSmoke;
			pnlContent.Controls.Add(label1);
			pnlContent.Controls.Add(pnlOptions);
			pnlContent.Controls.Add(pnlCategorySelection);
			pnlContent.Controls.Add(pnlSpecificReview);
			pnlContent.Controls.Add(lblChooseMethod);
			pnlContent.Controls.Add(lblAmountHint);
			pnlContent.Controls.Add(pnlAmountBox);
			pnlContent.Controls.Add(lblSectionTitle);
			pnlContent.Dock = DockStyle.Fill;
			pnlContent.Name = "pnlContent";
			pnlContent.TabIndex = 0;
			Controls.Add(pnlContent);
			Controls.Add(pnlHeader);
			Controls.Add(pnlFooter);
			Font = new Font("Segoe UI", 16F);
			FormBorderStyle = FormBorderStyle.None;
			Name = "DepositForm";
			Text = "Deposit";
			TopMost = true;
			WindowState = FormWindowState.Maximized;
			Load += DepositForm_Load;
			FormClosed += DepositForm_FormClosed;
			clockTimer.Interval = 1000;
			clockTimer.Tick += clockTimer_Tick;
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlContent.ResumeLayout(false);
			pnlContent.PerformLayout();
			pnlAmountBox.ResumeLayout(false);
			pnlAmountBox.PerformLayout();
			pnlOptions.ResumeLayout(false);
			pnlAuto.ResumeLayout(false);
			((ISupportInitialize)pbAuto).EndInit();
			pnlSpecific.ResumeLayout(false);
			((ISupportInitialize)pbSpecific).EndInit();
			pnlCategorySelection.ResumeLayout(false);
			pnlSpecificReview.ResumeLayout(false);
			pnlFooter.ResumeLayout(false);
			pnlFooter.PerformLayout();
			pnlActionBar.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private Panel pnlHeader;
        private Label lblAppName;
        private Label lblSectionTitle;
        private Label lblSubTitle;
		private Panel pnlContent;
        private Panel pnlAmountBox;
        private Label lblPeso;
        private TextBox txtAmountDisplay;
        private Label lblAmountHint;
        private Label lblChooseMethod;
        private Panel pnlOptions;
        private Panel pnlAuto;
        private PictureBox pbAuto;
        private Label lblAutoTitle;
        private Label lblAutoDesc;
        private Panel pnlSpecific;
        private PictureBox pbSpecific;
        private Label lblSpecificTitle;
        private Label lblSpecificDesc;
		private Panel pnlCategorySelection;
		private Button btnNeeds;
		private Button btnWants;
		private Button btnSavings;
		private Panel pnlSpecificReview;
		private Label lblSpecificReview;
		private Button btnChangeCategory;
        private Panel pnlFooter;
		private Panel pnlActionBar;
        private Button btnBack;
        private Button btnConfirm;
        private Label lblFooter;
		private Label lblDateTime;
		private System.Windows.Forms.Timer clockTimer;
        private Label label1;
    }
}
