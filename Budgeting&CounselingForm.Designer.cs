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
            lblTitle = new Label();
            lblSection = new Label();
            lblInstruction = new Label();
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
            lblFooter = new Label();
            btnBack = new Button();
            btnConfirm = new Button();
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
            pnlHeader.BackColor = Color.FromArgb(8, 80, 145);
            pnlHeader.Controls.Add(lblAppName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(10);
            pnlHeader.Size = new Size(800, 70);
            pnlHeader.TabIndex = 4;
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
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(360, 80);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(149, 30);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "DASHBOARD";
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSection.Location = new Point(300, 110);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(324, 21);
            lblSection.TabIndex = 2;
            lblSection.Text = "BUDGETING AND COUNSELING SERVICES";
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInstruction.Location = new Point(140, 140);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(393, 21);
            lblInstruction.TabIndex = 1;
            lblInstruction.Text = "1. SELECT A COUNSELING OR BUDGETING OPTION:";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlOptionA);
            pnlMain.Controls.Add(pnlOptionB);
            pnlMain.Controls.Add(pnlOptionC);
            pnlMain.Location = new Point(40, 170);
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
            pnlFooter.BackColor = Color.FromArgb(8, 80, 145);
            pnlFooter.Controls.Add(lblFooter);
            pnlFooter.Controls.Add(btnBack);
            pnlFooter.Controls.Add(btnConfirm);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 460);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(8);
            pnlFooter.Size = new Size(800, 60);
            pnlFooter.TabIndex = 5;
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
            btnBack.Click += button4_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(660, 12);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 36);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.Click += button5_Click;
            // 
            // BudgetingCounselingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            // Larger default font for fullscreen
            this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ClientSize = new Size(800, 520);
            Controls.Add(pnlMain);
            Controls.Add(lblInstruction);
            Controls.Add(lblSection);
            Controls.Add(lblTitle);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Name = "BudgetingCounselingForm";
            Text = "Budgeting & Counseling";
            // Start in borderless fullscreen (kiosk) mode
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
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
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblAppName;
        private Label lblTitle;
        private Label lblSection;
        private Label lblInstruction;
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
        private Label lblFooter;
        private Button btnBack;
        private Button btnConfirm;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
