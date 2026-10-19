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
            components = new System.ComponentModel.Container();
            pnlHeader = new System.Windows.Forms.Panel();
            lblAppName = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            pnlMain = new System.Windows.Forms.Panel();
            pnlOptionA = new System.Windows.Forms.Panel();
            pbA = new System.Windows.Forms.PictureBox();
            lblAIndex = new System.Windows.Forms.Label();
            lblAName = new System.Windows.Forms.Label();
            pnlOptionB = new System.Windows.Forms.Panel();
            pbB = new System.Windows.Forms.PictureBox();
            lblBIndex = new System.Windows.Forms.Label();
            lblBName = new System.Windows.Forms.Label();
            pnlOptionC = new System.Windows.Forms.Panel();
            pbC = new System.Windows.Forms.PictureBox();
            lblCIndex = new System.Windows.Forms.Label();
            lblCName = new System.Windows.Forms.Label();
            pnlFooter = new System.Windows.Forms.Panel();
            lblSecurity = new System.Windows.Forms.Label();
            lblDateTime = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(8, 80, 145);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Height = 70;
            pnlHeader.Padding = new System.Windows.Forms.Padding(10);
            pnlHeader.Controls.Add(lblAppName);
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAppName.ForeColor = System.Drawing.Color.White;
            lblAppName.Location = new System.Drawing.Point(12, 20);
            lblAppName.Name = "lblAppName";
            lblAppName.Text = "SMART CASH DISBURSEMENT";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.Location = new System.Drawing.Point(340, 90);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(120, 30);
            lblTitle.Text = "DASHBOARD";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblSubtitle.Location = new System.Drawing.Point(260, 125);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(300, 19);
            lblSubtitle.Text = "MAIN MENU - PLEASE SELECT AN OPTION";
            // 
            // pnlMain
            // 
            pnlMain.Location = new System.Drawing.Point(40, 160);
            pnlMain.Size = new System.Drawing.Size(720, 220);
            pnlMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // pnlOptionA
            // 
            pnlOptionA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlOptionA.Location = new System.Drawing.Point(0, 0);
            pnlOptionA.Size = new System.Drawing.Size(220, 200);
            pnlOptionA.BackColor = System.Drawing.Color.White;
            pnlOptionA.Cursor = System.Windows.Forms.Cursors.Hand;
            pnlOptionA.Click += btnCashDeposit_Click;
            // 
            // pbA
            // 
            pbA.Location = new System.Drawing.Point(20, 20);
            pbA.Size = new System.Drawing.Size(64, 64);
            pbA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbA.BackColor = System.Drawing.Color.Transparent;
            pbA.Image = null;
            pbA.Click += btnCashDeposit_Click;
            // 
            // lblAIndex
            // 
            lblAIndex.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAIndex.ForeColor = System.Drawing.Color.FromArgb(8, 80, 145);
            lblAIndex.Location = new System.Drawing.Point(20, 100);
            lblAIndex.Size = new System.Drawing.Size(40, 40);
            lblAIndex.Text = "A";
            lblAIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblAIndex.Click += btnCashDeposit_Click;
            // 
            // lblAName
            // 
            lblAName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAName.Location = new System.Drawing.Point(80, 85);
            lblAName.Size = new System.Drawing.Size(120, 50);
            lblAName.Text = "CASH\r\nDEPOSIT";
            lblAName.Click += btnCashDeposit_Click;
            // 
            // combine A
            // 
            pnlOptionA.Controls.Add(pbA);
            pnlOptionA.Controls.Add(lblAIndex);
            pnlOptionA.Controls.Add(lblAName);
            // 
            // pnlOptionB
            // 
            pnlOptionB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlOptionB.Location = new System.Drawing.Point(250, 0);
            pnlOptionB.Size = new System.Drawing.Size(220, 200);
            pnlOptionB.BackColor = System.Drawing.Color.White;
            pnlOptionB.Cursor = System.Windows.Forms.Cursors.Hand;
            pnlOptionB.Click += btnCashWithdrawal_Click;
            // 
            // pbB
            // 
            pbB.Location = new System.Drawing.Point(20, 20);
            pbB.Size = new System.Drawing.Size(64, 64);
            pbB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbB.Image = null;
            pbB.Click += btnCashWithdrawal_Click;
            // 
            // lblBIndex
            // 
            lblBIndex.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblBIndex.ForeColor = System.Drawing.Color.FromArgb(8, 80, 145);
            lblBIndex.Location = new System.Drawing.Point(20, 100);
            lblBIndex.Size = new System.Drawing.Size(40, 40);
            lblBIndex.Text = "B";
            lblBIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblBIndex.Click += btnCashWithdrawal_Click;
            // 
            // lblBName
            // 
            lblBName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblBName.Location = new System.Drawing.Point(80, 85);
            lblBName.Size = new System.Drawing.Size(140, 50);
            lblBName.Text = "CASH\r\nWITHDRAWAL";
            lblBName.Click += btnCashWithdrawal_Click;
            pnlOptionB.Controls.Add(pbB);
            pnlOptionB.Controls.Add(lblBIndex);
            pnlOptionB.Controls.Add(lblBName);
            // 
            // pnlOptionC
            // 
            pnlOptionC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlOptionC.Location = new System.Drawing.Point(500, 0);
            pnlOptionC.Size = new System.Drawing.Size(220, 200);
            pnlOptionC.BackColor = System.Drawing.Color.White;
            pnlOptionC.Cursor = System.Windows.Forms.Cursors.Hand;
            pnlOptionC.Click += btnBudgetingCounseling_Click;
            // 
            // pbC
            // 
            pbC.Location = new System.Drawing.Point(20, 20);
            pbC.Size = new System.Drawing.Size(64, 64);
            pbC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbC.Image = null;
            pbC.Click += btnBudgetingCounseling_Click;
            // 
            // lblCIndex
            // 
            lblCIndex.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblCIndex.ForeColor = System.Drawing.Color.FromArgb(8, 80, 145);
            lblCIndex.Location = new System.Drawing.Point(20, 100);
            lblCIndex.Size = new System.Drawing.Size(40, 40);
            lblCIndex.Text = "C";
            lblCIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCIndex.Click += btnBudgetingCounseling_Click;
            // 
            // lblCName
            // 
            lblCName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblCName.Location = new System.Drawing.Point(80, 75);
            lblCName.Size = new System.Drawing.Size(130, 80);
            lblCName.Text = "BUDGETING/\r\nCOUNSELING";
            lblCName.Click += btnBudgetingCounseling_Click;
            pnlOptionC.Controls.Add(pbC);
            pnlOptionC.Controls.Add(lblCIndex);
            pnlOptionC.Controls.Add(lblCName);
            // 
            // add option panels to main
            // 
            pnlMain.Controls.Add(pnlOptionA);
            pnlMain.Controls.Add(pnlOptionB);
            pnlMain.Controls.Add(pnlOptionC);
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = System.Drawing.Color.FromArgb(8, 80, 145);
            pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlFooter.Height = 40;
            pnlFooter.Padding = new System.Windows.Forms.Padding(8);
            pnlFooter.Controls.Add(lblSecurity);
            pnlFooter.Controls.Add(lblDateTime);
            // 
            // lblSecurity
            // 
            lblSecurity.AutoSize = true;
            lblSecurity.ForeColor = System.Drawing.Color.White;
            lblSecurity.Location = new System.Drawing.Point(12, 12);
            lblSecurity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblSecurity.Text = "SECURE SYSTEM - Your security is our priority.";
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.ForeColor = System.Drawing.Color.White;
            lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDateTime.Location = new System.Drawing.Point(640, 12);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Text = System.DateTime.Now.ToString("MMMM d, yyyy | h:mm tt");
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // Larger default font for fullscreen
            this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ClientSize = new System.Drawing.Size(800, 520);
            Controls.Add(pnlMain);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Name = "DashboardForm";
            Text = "Dashboard";
            // Start in borderless fullscreen (kiosk) mode
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlOptionA;
        private System.Windows.Forms.PictureBox pbA;
        private System.Windows.Forms.Label lblAIndex;
        private System.Windows.Forms.Label lblAName;
        private System.Windows.Forms.Panel pnlOptionB;
        private System.Windows.Forms.PictureBox pbB;
        private System.Windows.Forms.Label lblBIndex;
        private System.Windows.Forms.Label lblBName;
        private System.Windows.Forms.Panel pnlOptionC;
        private System.Windows.Forms.PictureBox pbC;
        private System.Windows.Forms.Label lblCIndex;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.Label lblDateTime;
    }
}