using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    partial class BudgetingCounselingForm
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
            pnlHeader = new Panel();
            lblAppName = new Label();
            lblAppSubtitle = new Label();
            lblTitle = new Label();
            lblSection = new Label();
            lblInstruction = new Label();
            pnlContent = new Panel();
            pnlMain = new Panel();
            pnlOptionA = new Panel();
            label1 = new Label();
            pnlOptionB = new Panel();
            label2 = new Label();
            pnlOptionC = new Panel();
            label4 = new Label();
            label3 = new Label();
            pbA = new PictureBox();
            lblAIndex = new Label();
            lblATitle = new Label();
            lblADesc = new Label();
            pbB = new PictureBox();
            lblBIndex = new Label();
            lblBTitle = new Label();
            lblBDesc = new Label();
            pbC = new PictureBox();
            lblCIndex = new Label();
            lblCTitle = new Label();
            lblCDesc = new Label();
            pnlFooter = new Panel();
            actionBar = new Panel();
            securityFooter = new Panel();
            lblFooter = new Label();
            lblFooterSubtitle = new Label();
            dateTimeLabel = new Label();
            btnBack = new Button();
            components = new Container();
            clockTimer = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlOptionA.SuspendLayout();
            pnlOptionB.SuspendLayout();
            pnlOptionC.SuspendLayout();
            ((ISupportInitialize)pbA).BeginInit();
            ((ISupportInitialize)pbB).BeginInit();
            ((ISupportInitialize)pbC).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
            pnlHeader.Controls.Add(lblAppName);
            pnlHeader.Controls.Add(lblAppSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Height = 76;
            pnlHeader.TabIndex = 4;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(96, 13);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(400, 31);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "SMART CASH DISBURSEMENT";
            // 
            // lblAppSubtitle
            // 
            lblAppSubtitle.AutoSize = true;
            lblAppSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAppSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
            lblAppSubtitle.Location = new Point(98, 42);
            lblAppSubtitle.Name = "lblAppSubtitle";
            lblAppSubtitle.Size = new Size(178, 20);
            lblAppSubtitle.TabIndex = 1;
            lblAppSubtitle.Text = "BUDGETING MACHINE";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(360, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(149, 30);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "BUDGETING & COUNSELING";
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSection.Location = new Point(300, 55);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(324, 21);
            lblSection.TabIndex = 2;
            lblSection.Text = "BUDGETING AND COUNSELING SERVICES";
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInstruction.Location = new Point(140, 85);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(393, 21);
            lblInstruction.TabIndex = 1;
            lblInstruction.Text = "1. SELECT A COUNSELING OR BUDGETING OPTION:";
            // 
            // pnlMain
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.AutoScroll = true;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(pnlMain);
            pnlContent.Controls.Add(lblInstruction);
            pnlContent.Controls.Add(lblSection);
            pnlContent.Controls.Add(lblTitle);
            pnlMain.Controls.Add(pnlOptionA);
            pnlMain.Controls.Add(pnlOptionB);
            pnlMain.Controls.Add(pnlOptionC);
            pnlMain.Location = new Point(40, 115);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(720, 240);
            pnlMain.TabIndex = 0;
            // 
            // pnlOptionA
            // 
            pnlOptionA.BackColor = Color.White;
            pnlOptionA.BorderStyle = BorderStyle.FixedSingle;
            pnlOptionA.Controls.Add(label1);
            pnlOptionA.Cursor = Cursors.Hand;
            pnlOptionA.Location = new Point(0, 0);
            pnlOptionA.Name = "pnlOptionA";
            pnlOptionA.Size = new Size(220, 220);
            pnlOptionA.TabIndex = 0;
            pnlOptionA.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 85);
            label1.Name = "label1";
            label1.Size = new Size(205, 25);
            label1.TabIndex = 0;
            label1.Text = "A. Goal Planning Hub";
            label1.Click += label1_Click;
            // 
            // pnlOptionB
            // 
            pnlOptionB.BackColor = Color.White;
            pnlOptionB.BorderStyle = BorderStyle.FixedSingle;
            pnlOptionB.Controls.Add(label2);
            pnlOptionB.Cursor = Cursors.Hand;
            pnlOptionB.Location = new Point(250, 0);
            pnlOptionB.Name = "pnlOptionB";
            pnlOptionB.Size = new Size(220, 220);
            pnlOptionB.TabIndex = 1;
            pnlOptionB.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 85);
            label2.Name = "label2";
            label2.Size = new Size(204, 25);
            label2.TabIndex = 0;
            label2.Text = "B. Spending Analytics";
            // 
            // pnlOptionC
            // 
            pnlOptionC.BackColor = Color.White;
            pnlOptionC.BorderStyle = BorderStyle.FixedSingle;
            pnlOptionC.Controls.Add(label4);
            pnlOptionC.Controls.Add(label3);
            pnlOptionC.Cursor = Cursors.Hand;
            pnlOptionC.Location = new Point(500, 0);
            pnlOptionC.Name = "pnlOptionC";
            pnlOptionC.Size = new Size(220, 220);
            pnlOptionC.TabIndex = 2;
            pnlOptionC.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(38, 100);
            label4.Name = "label4";
            label4.Size = new Size(145, 25);
            label4.TabIndex = 1;
            label4.Text = " and Resources";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 75);
            label3.Name = "label3";
            label3.Size = new Size(183, 25);
            label3.TabIndex = 0;
            label3.Text = "C. Counseling Hub ";
            // 
            // pbA
            // 
            pbA.Location = new Point(18, 18);
            pbA.Name = "pbA";
            pbA.Size = new Size(80, 80);
            pbA.SizeMode = PictureBoxSizeMode.Zoom;
            pbA.TabIndex = 0;
            pbA.TabStop = false;
            pbA.Click += button1_Click;
            // 
            // lblAIndex
            // 
            lblAIndex.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAIndex.ForeColor = Color.FromArgb(8, 80, 145);
            lblAIndex.Location = new Point(20, 110);
            lblAIndex.Name = "lblAIndex";
            lblAIndex.Size = new Size(40, 40);
            lblAIndex.TabIndex = 0;
            lblAIndex.Text = "A";
            lblAIndex.TextAlign = ContentAlignment.MiddleCenter;
            lblAIndex.Click += button1_Click;
            // 
            // lblATitle
            // 
            lblATitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblATitle.Location = new Point(70, 100);
            lblATitle.Name = "lblATitle";
            lblATitle.Size = new Size(130, 60);
            lblATitle.TabIndex = 0;
            lblATitle.Text = "A. GOAL\r\nPLANNING HUB";
            lblATitle.Click += button1_Click;
            // 
            // lblADesc
            // 
            lblADesc.Font = new Font("Segoe UI", 9F);
            lblADesc.Location = new Point(20, 160);
            lblADesc.Name = "lblADesc";
            lblADesc.Size = new Size(180, 40);
            lblADesc.TabIndex = 0;
            lblADesc.Text = "(SET & TRACK CUSTOM SAVINGS TARGETS)";
            // 
            // pbB
            // 
            pbB.Location = new Point(18, 18);
            pbB.Name = "pbB";
            pbB.Size = new Size(80, 80);
            pbB.SizeMode = PictureBoxSizeMode.Zoom;
            pbB.TabIndex = 0;
            pbB.TabStop = false;
            pbB.Click += button2_Click;
            // 
            // lblBIndex
            // 
            lblBIndex.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblBIndex.ForeColor = Color.FromArgb(8, 80, 145);
            lblBIndex.Location = new Point(20, 110);
            lblBIndex.Name = "lblBIndex";
            lblBIndex.Size = new Size(40, 40);
            lblBIndex.TabIndex = 0;
            lblBIndex.Text = "B";
            lblBIndex.TextAlign = ContentAlignment.MiddleCenter;
            lblBIndex.Click += button2_Click;
            // 
            // lblBTitle
            // 
            lblBTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBTitle.Location = new Point(70, 100);
            lblBTitle.Name = "lblBTitle";
            lblBTitle.Size = new Size(130, 60);
            lblBTitle.TabIndex = 0;
            lblBTitle.Text = "B. SPENDING\r\nANALYTICS";
            lblBTitle.Click += button2_Click;
            // 
            // lblBDesc
            // 
            lblBDesc.Font = new Font("Segoe UI", 9F);
            lblBDesc.Location = new Point(20, 160);
            lblBDesc.Name = "lblBDesc";
            lblBDesc.Size = new Size(180, 40);
            lblBDesc.TabIndex = 0;
            lblBDesc.Text = "(ANALYZE YOUR PAST SPENDING DATA)";
            // 
            // pbC
            // 
            pbC.Location = new Point(18, 18);
            pbC.Name = "pbC";
            pbC.Size = new Size(80, 80);
            pbC.SizeMode = PictureBoxSizeMode.Zoom;
            pbC.TabIndex = 0;
            pbC.TabStop = false;
            pbC.Click += button3_Click;
            // 
            // lblCIndex
            // 
            lblCIndex.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblCIndex.ForeColor = Color.FromArgb(8, 80, 145);
            lblCIndex.Location = new Point(20, 110);
            lblCIndex.Name = "lblCIndex";
            lblCIndex.Size = new Size(40, 40);
            lblCIndex.TabIndex = 0;
            lblCIndex.Text = "C";
            lblCIndex.TextAlign = ContentAlignment.MiddleCenter;
            lblCIndex.Click += button3_Click;
            // 
            // lblCTitle
            // 
            lblCTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCTitle.Location = new Point(70, 100);
            lblCTitle.Name = "lblCTitle";
            lblCTitle.Size = new Size(130, 60);
            lblCTitle.TabIndex = 0;
            lblCTitle.Text = "C. COUNSELING\r\nHUB & RESOURCES";
            lblCTitle.Click += button3_Click;
            // 
            // lblCDesc
            // 
            lblCDesc.Font = new Font("Segoe UI", 9F);
            lblCDesc.Location = new Point(20, 160);
            lblCDesc.Name = "lblCDesc";
            lblCDesc.Size = new Size(180, 40);
            lblCDesc.TabIndex = 0;
            lblCDesc.Text = "(REQUEST ADVICE & ACCESS MATERIALS)";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(8, 52, 105);
            pnlFooter.Controls.Add(securityFooter);
            pnlFooter.Controls.Add(actionBar);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Height = 116;
            pnlFooter.TabIndex = 5;
            actionBar.BackColor = Color.FromArgb(8, 52, 105);
            actionBar.Controls.Add(btnBack);
            actionBar.Dock = DockStyle.Top;
            actionBar.Height = 52;
            securityFooter.BackColor = Color.FromArgb(8, 52, 105);
            securityFooter.Controls.Add(dateTimeLabel);
            securityFooter.Controls.Add(lblFooterSubtitle);
            securityFooter.Controls.Add(lblFooter);
            securityFooter.Dock = DockStyle.Bottom;
            securityFooter.Height = 64;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFooter.ForeColor = Color.White;
            lblFooter.Location = new Point(24, 8);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(125, 15);
            lblFooter.TabIndex = 0;
            lblFooter.Text = "SECURE SYSTEM";
            lblFooterSubtitle.AutoSize = true;
            lblFooterSubtitle.Font = new Font("Segoe UI", 9F);
            lblFooterSubtitle.ForeColor = Color.White;
            lblFooterSubtitle.Location = new Point(24, 26);
            lblFooterSubtitle.Name = "lblFooterSubtitle";
            lblFooterSubtitle.Size = new Size(171, 15);
            lblFooterSubtitle.TabIndex = 1;
            lblFooterSubtitle.Text = "Your security is our priority.";
            dateTimeLabel.AutoSize = false;
            dateTimeLabel.Dock = DockStyle.Right;
            dateTimeLabel.Font = new Font("Segoe UI", 10F);
            dateTimeLabel.ForeColor = Color.White;
            dateTimeLabel.Padding = new Padding(0, 0, 24, 0);
            dateTimeLabel.Size = new Size(300, 64);
            dateTimeLabel.TextAlign = ContentAlignment.MiddleRight;
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
            btnBack.Click += button4_Click;
            clockTimer.Interval = 1000;
            // 
            // BudgetingCounselingForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 16F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BudgetingCounselingForm";
            Text = "Budgeting & Counseling";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            Load += BudgetingCounselingForm_Load_1;
            FormClosed += BudgetingCounselingForm_FormClosed;
            clockTimer.Tick += clockTimer_Tick;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlOptionA.ResumeLayout(false);
            pnlOptionA.PerformLayout();
            pnlOptionB.ResumeLayout(false);
            pnlOptionB.PerformLayout();
            pnlOptionC.ResumeLayout(false);
            pnlOptionC.PerformLayout();
            ((ISupportInitialize)pbA).EndInit();
            ((ISupportInitialize)pbB).EndInit();
            ((ISupportInitialize)pbC).EndInit();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            actionBar.ResumeLayout(false);
            securityFooter.ResumeLayout(false);
            securityFooter.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblAppName;
        private Label lblAppSubtitle;
        private Label lblTitle;
        private Label lblSection;
        private Label lblInstruction;
        private Panel pnlContent;
        private Panel pnlMain;
        private Panel pnlOptionA;
        private PictureBox pbA;
        private Label lblAIndex;
        private Label lblATitle;
        private Label lblADesc;
        private Panel pnlOptionB;
        private PictureBox pbB;
        private Label lblBIndex;
        private Label lblBTitle;
        private Label lblBDesc;
        private Panel pnlOptionC;
        private PictureBox pbC;
        private Label lblCIndex;
        private Label lblCTitle;
        private Label lblCDesc;
        private Panel pnlFooter;
        private Panel actionBar;
        private Panel securityFooter;
        private Label lblFooter;
        private Label lblFooterSubtitle;
        private Label dateTimeLabel;
        private Button btnBack;
        private System.Windows.Forms.Timer clockTimer;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
