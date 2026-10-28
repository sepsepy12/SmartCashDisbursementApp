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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblAppName = new Label();
            lblSectionTitle = new Label();
            lblSubTitle = new Label();
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
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            pnlFooter = new Panel();
            lblFooter = new Label();
            btnBack = new Button();
            btnConfirm = new Button();
            label1 = new Label();
            pnlHeader.SuspendLayout();
            pnlAmountBox.SuspendLayout();
            pnlOptions.SuspendLayout();
            pnlAuto.SuspendLayout();
            ((ISupportInitialize)pbAuto).BeginInit();
            pnlSpecific.SuspendLayout();
            ((ISupportInitialize)pbSpecific).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(8, 80, 145);
            pnlHeader.Controls.Add(lblAppName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(10);
            pnlHeader.Size = new Size(800, 70);
            pnlHeader.TabIndex = 6;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(12, 22);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(231, 21);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "SMART CASH DISBURSEMENT";
            // 
            // lblSectionTitle
            // 
            lblSectionTitle.AutoSize = true;
            lblSectionTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSectionTitle.Location = new Point(330, 73);
            lblSectionTitle.Name = "lblSectionTitle";
            lblSectionTitle.Size = new Size(149, 30);
            lblSectionTitle.TabIndex = 5;
            lblSectionTitle.Text = "DASHBOARD";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.Location = new Point(340, 103);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(117, 19);
            lblSubTitle.TabIndex = 4;
            lblSubTitle.Text = "DEPOSIT DETAILS";
            // 
            // pnlAmountBox
            // 
            pnlAmountBox.BackColor = Color.WhiteSmoke;
            pnlAmountBox.BorderStyle = BorderStyle.FixedSingle;
            pnlAmountBox.Controls.Add(lblPeso);
            pnlAmountBox.Controls.Add(txtAmountDisplay);
            pnlAmountBox.Location = new Point(140, 152);
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
            txtAmountDisplay.Size = new Size(430, 40);
            txtAmountDisplay.TabIndex = 1;
            txtAmountDisplay.Text = "0.00";
            txtAmountDisplay.TextAlign = HorizontalAlignment.Center;
            // 
            // lblAmountHint
            // 
            lblAmountHint.AutoSize = true;
            lblAmountHint.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblAmountHint.Location = new Point(330, 225);
            lblAmountHint.Name = "lblAmountHint";
            lblAmountHint.Size = new Size(192, 15);
            lblAmountHint.TabIndex = 2;
            lblAmountHint.Text = "(Enter amount via numeric keypad)";
            // 
            // lblChooseMethod
            // 
            lblChooseMethod.AutoSize = true;
            lblChooseMethod.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChooseMethod.Location = new Point(140, 240);
            lblChooseMethod.Name = "lblChooseMethod";
            lblChooseMethod.Size = new Size(212, 21);
            lblChooseMethod.TabIndex = 1;
            lblChooseMethod.Text = "2. Choose deposit method:";
            // 
            // pnlOptions
            // 
            pnlOptions.Controls.Add(pnlAuto);
            pnlOptions.Controls.Add(pnlSpecific);
            pnlOptions.Location = new Point(140, 270);
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
            // pnlFooter
            // lblCategory
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(140, 420);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(78, 15);
            lblCategory.TabIndex = 9;
            lblCategory.Text = "Category:";
            lblCategory.Visible = false;
            // cmbCategory
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Needs", "Wants", "Savings", "Other" });
            cmbCategory.Location = new Point(220, 417);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 23);
            cmbCategory.TabIndex = 10;
            cmbCategory.Visible = false;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // pnlFooter
            pnlFooter.BackColor = Color.FromArgb(8, 80, 145);
            pnlFooter.Controls.Add(lblFooter);
            pnlFooter.Controls.Add(btnBack);
            pnlFooter.Controls.Add(btnConfirm);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 460);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(8);
            pnlFooter.Size = new Size(800, 60);
            pnlFooter.TabIndex = 7;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.Font = new Font("Segoe UI", 9F);
            lblFooter.ForeColor = Color.White;
            lblFooter.Location = new Point(140, 20);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(249, 15);
            lblFooter.TabIndex = 0;
            lblFooter.Text = "SECURE SYSTEM - Your security is our priority.";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(20, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 36);
            btnBack.TabIndex = 1;
            btnBack.Text = "<- BACK";
            btnBack.Click += button3_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(660, 12);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 36);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(140, 128);
            label1.Name = "label1";
            label1.Size = new Size(313, 21);
            label1.TabIndex = 8;
            label1.Text = "1. How much would you like to deposit?";
            label1.Click += label1_Click;
            // 
            // DepositForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            // Larger default font for fullscreen
            this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ClientSize = new Size(800, 520);
            Controls.Add(label1);
            Controls.Add(pnlOptions);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(lblChooseMethod);
            Controls.Add(lblAmountHint);
            Controls.Add(pnlAmountBox);
            Controls.Add(lblSubTitle);
            Controls.Add(lblSectionTitle);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Name = "DepositForm";
            Text = "Deposit";
            Load += DepositForm_Load;
            // Start in borderless fullscreen (kiosk) mode
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlAmountBox.ResumeLayout(false);
            pnlOptions.ResumeLayout(false);
            pnlAuto.ResumeLayout(false);
            ((ISupportInitialize)pbAuto).EndInit();
            pnlSpecific.ResumeLayout(false);
            ((ISupportInitialize)pbSpecific).EndInit();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblAppName;
        private Label lblSectionTitle;
        private Label lblSubTitle;
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
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Panel pnlFooter;
        private Button btnBack;
        private Button btnConfirm;
        private Label lblFooter;
        private Label label1;
    }
}
