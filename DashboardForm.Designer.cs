namespace SmartCashDisbursementApp
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

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
			lblSubtitle = new Label();
			pnlMain = new Panel();
			pnlCashDeposit = new Panel();
			pbA = new PictureBox();
			lblAIndex = new Label();
			lblAName = new Label();
			pnlCashWithdrawal = new Panel();
			pbB = new PictureBox();
			lblBIndex = new Label();
			lblBName = new Label();
			pnlBudgeting = new Panel();
			pbC = new PictureBox();
			lblCIndex = new Label();
			lblCName = new Label();
			pnlFooter = new Panel();
			lblSecurity = new Label();
			lblDateTime = new Label();
			pnlHeader.SuspendLayout();
			pnlMain.SuspendLayout();
			pnlCashDeposit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbA).BeginInit();
			pnlCashWithdrawal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbB).BeginInit();
			pnlBudgeting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbC).BeginInit();
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
			pnlHeader.TabIndex = 3;
			// 
			// lblAppName
			// 
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(12, 20);
			lblAppName.Name = "lblAppName";
			lblAppName.Size = new Size(231, 21);
			lblAppName.TabIndex = 0;
			lblAppName.Text = "SMART CASH DISBURSEMENT";
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			lblTitle.Location = new Point(340, 90);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(149, 30);
			lblTitle.TabIndex = 2;
			lblTitle.Text = "DASHBOARD";
			// 
			// lblSubtitle
			// 
			lblSubtitle.AutoSize = true;
			lblSubtitle.Font = new Font("Segoe UI", 10F);
			lblSubtitle.Location = new Point(260, 125);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Size = new Size(274, 19);
			lblSubtitle.TabIndex = 1;
			lblSubtitle.Text = "MAIN MENU - PLEASE SELECT AN OPTION";
			// 
			// pnlMain
			// 
			pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			pnlMain.Controls.Add(pnlCashDeposit);
			pnlMain.Controls.Add(pnlCashWithdrawal);
			pnlMain.Controls.Add(pnlBudgeting);
			pnlMain.Location = new Point(40, 160);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new Size(720, 220);
			pnlMain.TabIndex = 0;
			// 
			// pnlCashDeposit
			// 
			pnlCashDeposit.BackColor = Color.White;
			pnlCashDeposit.BorderStyle = BorderStyle.FixedSingle;
			pnlCashDeposit.Controls.Add(pbA);
			pnlCashDeposit.Controls.Add(lblAIndex);
			pnlCashDeposit.Controls.Add(lblAName);
			pnlCashDeposit.Cursor = Cursors.Hand;
			pnlCashDeposit.Location = new Point(0, 0);
			pnlCashDeposit.Name = "pnlCashDeposit";
			pnlCashDeposit.Size = new Size(220, 200);
			pnlCashDeposit.TabIndex = 0;
			pnlCashDeposit.Click += btnCashDeposit_Click;
			pnlCashDeposit.Paint += pnlOptionA_Paint;
			// 
			// pbA
			// 
			pbA.BackColor = Color.Transparent;
			pbA.Location = new Point(20, 20);
			pbA.Name = "pbA";
			pbA.Size = new Size(64, 64);
			pbA.SizeMode = PictureBoxSizeMode.Zoom;
			pbA.TabIndex = 0;
			pbA.TabStop = false;
			pbA.Click += btnCashDeposit_Click;
			// 
			// lblAIndex
			// 
			lblAIndex.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			lblAIndex.ForeColor = Color.FromArgb(8, 80, 145);
			lblAIndex.Location = new Point(20, 100);
			lblAIndex.Name = "lblAIndex";
			lblAIndex.Size = new Size(40, 40);
			lblAIndex.TabIndex = 1;
			lblAIndex.Text = "A";
			lblAIndex.TextAlign = ContentAlignment.MiddleCenter;
			lblAIndex.Click += btnCashDeposit_Click;
			// 
			// lblAName
			// 
			lblAName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblAName.Location = new Point(80, 85);
			lblAName.Name = "lblAName";
			lblAName.Size = new Size(120, 50);
			lblAName.TabIndex = 2;
			lblAName.Text = "CASH\r\nDEPOSIT";
			lblAName.Click += btnCashDeposit_Click;
			// 
			// pnlCashWithdrawal
			// 
			pnlCashWithdrawal.BackColor = Color.White;
			pnlCashWithdrawal.BorderStyle = BorderStyle.FixedSingle;
			pnlCashWithdrawal.Controls.Add(pbB);
			pnlCashWithdrawal.Controls.Add(lblBIndex);
			pnlCashWithdrawal.Controls.Add(lblBName);
			pnlCashWithdrawal.Cursor = Cursors.Hand;
			pnlCashWithdrawal.Location = new Point(250, 0);
			pnlCashWithdrawal.Name = "pnlCashWithdrawal";
			pnlCashWithdrawal.Size = new Size(220, 200);
			pnlCashWithdrawal.TabIndex = 1;
			pnlCashWithdrawal.Click += btnCashWithdrawal_Click;
			// 
			// pbB
			// 
			pbB.Location = new Point(20, 20);
			pbB.Name = "pbB";
			pbB.Size = new Size(64, 64);
			pbB.SizeMode = PictureBoxSizeMode.Zoom;
			pbB.TabIndex = 0;
			pbB.TabStop = false;
			pbB.Click += btnCashWithdrawal_Click;
			// 
			// lblBIndex
			// 
			lblBIndex.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			lblBIndex.ForeColor = Color.FromArgb(8, 80, 145);
			lblBIndex.Location = new Point(20, 100);
			lblBIndex.Name = "lblBIndex";
			lblBIndex.Size = new Size(40, 40);
			lblBIndex.TabIndex = 1;
			lblBIndex.Text = "B";
			lblBIndex.TextAlign = ContentAlignment.MiddleCenter;
			lblBIndex.Click += btnCashWithdrawal_Click;
			// 
			// lblBName
			// 
			lblBName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblBName.Location = new Point(80, 85);
			lblBName.Name = "lblBName";
			lblBName.Size = new Size(140, 50);
			lblBName.TabIndex = 2;
			lblBName.Text = "CASH\r\nWITHDRAWAL";
			lblBName.Click += btnCashWithdrawal_Click;
			// 
			// pnlBudgeting
			// 
			pnlBudgeting.BackColor = Color.White;
			pnlBudgeting.BorderStyle = BorderStyle.FixedSingle;
			pnlBudgeting.Controls.Add(pbC);
			pnlBudgeting.Controls.Add(lblCIndex);
			pnlBudgeting.Controls.Add(lblCName);
			pnlBudgeting.Cursor = Cursors.Hand;
			pnlBudgeting.Location = new Point(500, 0);
			pnlBudgeting.Name = "pnlBudgeting";
			pnlBudgeting.Size = new Size(220, 200);
			pnlBudgeting.TabIndex = 2;
			pnlBudgeting.Click += btnBudgetingCounseling_Click;
			// 
			// pbC
			// 
			pbC.Location = new Point(20, 20);
			pbC.Name = "pbC";
			pbC.Size = new Size(64, 64);
			pbC.SizeMode = PictureBoxSizeMode.Zoom;
			pbC.TabIndex = 0;
			pbC.TabStop = false;
			pbC.Click += btnBudgetingCounseling_Click;
			// 
			// lblCIndex
			// 
			lblCIndex.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			lblCIndex.ForeColor = Color.FromArgb(8, 80, 145);
			lblCIndex.Location = new Point(20, 100);
			lblCIndex.Name = "lblCIndex";
			lblCIndex.Size = new Size(40, 40);
			lblCIndex.TabIndex = 1;
			lblCIndex.Text = "C";
			lblCIndex.TextAlign = ContentAlignment.MiddleCenter;
			lblCIndex.Click += btnBudgetingCounseling_Click;
			// 
			// lblCName
			// 
			lblCName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			lblCName.Location = new Point(80, 75);
			lblCName.Name = "lblCName";
			lblCName.Size = new Size(130, 80);
			lblCName.TabIndex = 2;
			lblCName.Text = "BUDGETING/\r\nCOUNSELING";
			lblCName.Click += btnBudgetingCounseling_Click;
			// 
			// pnlFooter
			// 
			pnlFooter.BackColor = Color.FromArgb(8, 80, 145);
			pnlFooter.Controls.Add(lblSecurity);
			pnlFooter.Controls.Add(lblDateTime);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Location = new Point(0, 480);
			pnlFooter.Name = "pnlFooter";
			pnlFooter.Padding = new Padding(8);
			pnlFooter.Size = new Size(800, 40);
			pnlFooter.TabIndex = 4;
			// 
			// lblSecurity
			// 
			lblSecurity.AutoSize = true;
			lblSecurity.Font = new Font("Segoe UI", 9F);
			lblSecurity.ForeColor = Color.White;
			lblSecurity.Location = new Point(12, 12);
			lblSecurity.Name = "lblSecurity";
			lblSecurity.Size = new Size(249, 15);
			lblSecurity.TabIndex = 0;
			lblSecurity.Text = "SECURE SYSTEM - Your security is our priority.";
			// 
			// lblDateTime
			// 
			lblDateTime.AutoSize = true;
			lblDateTime.Font = new Font("Segoe UI", 9F);
			lblDateTime.ForeColor = Color.White;
			lblDateTime.Location = new Point(640, 12);
			lblDateTime.Name = "lblDateTime";
			lblDateTime.Size = new Size(152, 15);
			lblDateTime.TabIndex = 1;
			lblDateTime.Text = "October 28, 2026 | 10:59 PM";
			// 
			// DashboardForm
			// 
			AutoScaleDimensions = new SizeF(12F, 30F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 520);
			Controls.Add(pnlMain);
			Controls.Add(lblSubtitle);
			Controls.Add(lblTitle);
			Controls.Add(pnlHeader);
			Controls.Add(pnlFooter);
			Font = new Font("Segoe UI", 16F);
			FormBorderStyle = FormBorderStyle.None;
			Name = "DashboardForm";
			Text = "Dashboard";
			TopMost = true;
			WindowState = FormWindowState.Maximized;
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlMain.ResumeLayout(false);
			pnlCashDeposit.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pbA).EndInit();
			pnlCashWithdrawal.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pbB).EndInit();
			pnlBudgeting.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pbC).EndInit();
			pnlFooter.ResumeLayout(false);
			pnlFooter.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlCashDeposit;
        private System.Windows.Forms.PictureBox pbA;
        private System.Windows.Forms.Label lblAIndex;
        private System.Windows.Forms.Label lblAName;
        private System.Windows.Forms.Panel pnlCashWithdrawal;
        private System.Windows.Forms.PictureBox pbB;
        private System.Windows.Forms.Label lblBIndex;
        private System.Windows.Forms.Label lblBName;
        private System.Windows.Forms.Panel pnlBudgeting;
        private System.Windows.Forms.PictureBox pbC;
        private System.Windows.Forms.Label lblCIndex;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.Label lblDateTime;
    }
}