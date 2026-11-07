using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class WithdrawalForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			pnlHeader = new Panel();
			lblAppSubtitle = new Label();
			lblAppName = new Label();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			lblAvailableBalance = new Label();
			lblReview = new Label();
			pnlAmount = new Panel();
			txtAmount = new TextBox();
			lblPeso = new Label();
			lblAmountHint = new Label();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			pnlFooter = new Panel();
			pnlSecurityFooter = new Panel();
			dateTimeLabel = new Label();
			lblFooterSubtitle = new Label();
			lblFooter = new Label();
			actionBar = new Panel();
			btnBack = new Button();
			pnlHeader.SuspendLayout();
			pnlAmount.SuspendLayout();
			pnlFooter.SuspendLayout();
			pnlSecurityFooter.SuspendLayout();
			actionBar.SuspendLayout();
			SuspendLayout();
			// 
			// pnlHeader
			// 
			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblAppSubtitle);
			pnlHeader.Controls.Add(lblAppName);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Location = new Point(0, 0);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new Size(800, 76);
			pnlHeader.TabIndex = 12;
			// 
			// lblAppSubtitle
			// 
			lblAppSubtitle.AutoSize = true;
			lblAppSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			lblAppSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblAppSubtitle.Location = new Point(98, 42);
			lblAppSubtitle.Name = "lblAppSubtitle";
			lblAppSubtitle.Size = new Size(171, 20);
			lblAppSubtitle.TabIndex = 0;
			lblAppSubtitle.Text = "BUDGETING MACHINE";
			// 
			// lblAppName
			// 
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(96, 13);
			lblAppName.Name = "lblAppName";
			lblAppName.Size = new Size(340, 31);
			lblAppName.TabIndex = 1;
			lblAppName.Text = "SMART CASH DISBURSEMENT";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16F);
			label1.ForeColor = Color.FromArgb(35, 45, 60);
			label1.Location = new Point(315, 104);
			label1.Name = "label1";
			label1.Size = new Size(214, 30);
			label1.TabIndex = 11;
			label1.Text = "CASH WITHDRAWAL";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label2.Location = new Point(300, 132);
			label2.Name = "label2";
			label2.Size = new Size(184, 21);
			label2.TabIndex = 10;
			label2.Text = "WITHDRAWAL DETAILS";
			label2.Click += label2_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label3.Location = new Point(235, 164);
			label3.Name = "label3";
			label3.Size = new Size(383, 21);
			label3.TabIndex = 9;
			label3.Text = "1. HOW MUCH WOULD YOU LIKE TO WITHDRAW?";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label4.Location = new Point(24, 274);
			label4.Name = "label4";
			label4.Size = new Size(322, 21);
			label4.TabIndex = 8;
			label4.Text = "2. CHOOSE WHERE TO WITHDRAW FROM:";
			label4.Click += label4_Click;
			// 
			// lblAvailableBalance
			// 
			lblAvailableBalance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
			lblAvailableBalance.ForeColor = Color.FromArgb(60, 75, 90);
			lblAvailableBalance.Location = new Point(466, 274);
			lblAvailableBalance.Name = "lblAvailableBalance";
			lblAvailableBalance.Size = new Size(310, 22);
			lblAvailableBalance.TabIndex = 5;
			lblAvailableBalance.Text = "Available balance: ₱0.00";
			lblAvailableBalance.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lblReview
			// 
			lblReview.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
			lblReview.ForeColor = Color.FromArgb(45, 65, 85);
			lblReview.Location = new Point(24, 408);
			lblReview.Name = "lblReview";
			lblReview.Size = new Size(752, 44);
			lblReview.TabIndex = 4;
			lblReview.Text = "Enter an amount and select a category to continue.";
			lblReview.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// pnlAmount
			// 
			pnlAmount.BackColor = Color.WhiteSmoke;
			pnlAmount.BorderStyle = BorderStyle.FixedSingle;
			pnlAmount.Controls.Add(txtAmount);
			pnlAmount.Controls.Add(lblPeso);
			pnlAmount.Location = new Point(130, 196);
			pnlAmount.Name = "pnlAmount";
			pnlAmount.Size = new Size(540, 52);
			pnlAmount.TabIndex = 7;
			// 
			// txtAmount
			// 
			txtAmount.BorderStyle = BorderStyle.None;
			txtAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			txtAmount.ForeColor = Color.DimGray;
			txtAmount.Location = new Point(170, 6);
			txtAmount.Name = "txtAmount";
			txtAmount.Size = new Size(220, 32);
			txtAmount.TabIndex = 0;
			txtAmount.Text = "0.00";
			txtAmount.TextAlign = HorizontalAlignment.Center;
			// 
			// lblPeso
			// 
			lblPeso.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			lblPeso.ForeColor = Color.DimGray;
			lblPeso.Location = new Point(130, 5);
			lblPeso.Name = "lblPeso";
			lblPeso.Size = new Size(40, 40);
			lblPeso.TabIndex = 1;
			lblPeso.Text = "₱";
			lblPeso.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblAmountHint
			// 
			lblAmountHint.AutoSize = true;
			lblAmountHint.Font = new Font("Segoe UI", 9F);
			lblAmountHint.Location = new Point(280, 251);
			lblAmountHint.Name = "lblAmountHint";
			lblAmountHint.Size = new Size(193, 15);
			lblAmountHint.TabIndex = 6;
			lblAmountHint.Text = "(Enter amount via numeric keypad)";
			// 
			// button1
			// 
			button1.BackColor = Color.White;
			button1.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			button1.ForeColor = Color.FromArgb(20, 75, 115);
			button1.Location = new Point(91, 304);
			button1.Name = "button1";
			button1.Size = new Size(190, 90);
			button1.TabIndex = 3;
			button1.Text = "A. NEEDS\n\n(WITHDRAWAL FOR\nESSENTIAL LIVING\nEXPENSES)";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.BackColor = Color.White;
			button2.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
			button2.FlatStyle = FlatStyle.Flat;
			button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			button2.ForeColor = Color.FromArgb(20, 75, 115);
			button2.Location = new Point(305, 304);
			button2.Name = "button2";
			button2.Size = new Size(190, 90);
			button2.TabIndex = 2;
			button2.Text = "B. WANTS\n\n(WITHDRAWAL FOR\nDISCRETIONARY OR\nLEISURE SPENDING)";
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.BackColor = Color.White;
			button3.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
			button3.FlatStyle = FlatStyle.Flat;
			button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			button3.ForeColor = Color.FromArgb(20, 75, 115);
			button3.Location = new Point(519, 304);
			button3.Name = "button3";
			button3.Size = new Size(190, 90);
			button3.TabIndex = 1;
			button3.Text = "C. SAVINGS\n\n(WITHDRAWAL FROM\nEMERGENCY OR\nGOAL FUNDS)";
			button3.UseVisualStyleBackColor = false;
			button3.Click += button3_Click;
			// 
			// pnlFooter
			// 
			pnlFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlFooter.Controls.Add(pnlSecurityFooter);
			pnlFooter.Controls.Add(actionBar);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Location = new Point(0, 404);
			pnlFooter.Name = "pnlFooter";
			pnlFooter.Size = new Size(800, 116);
			pnlFooter.TabIndex = 0;
			// 
			// pnlSecurityFooter
			// 
			pnlSecurityFooter.BackColor = Color.FromArgb(8, 52, 105);
			pnlSecurityFooter.Controls.Add(dateTimeLabel);
			pnlSecurityFooter.Controls.Add(lblFooterSubtitle);
			pnlSecurityFooter.Controls.Add(lblFooter);
			pnlSecurityFooter.Dock = DockStyle.Bottom;
			pnlSecurityFooter.Location = new Point(0, 52);
			pnlSecurityFooter.Name = "pnlSecurityFooter";
			pnlSecurityFooter.Size = new Size(800, 64);
			pnlSecurityFooter.TabIndex = 0;
			// 
			// dateTimeLabel
			// 
			dateTimeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			dateTimeLabel.Font = new Font("Segoe UI", 10F);
			dateTimeLabel.ForeColor = Color.White;
			dateTimeLabel.Location = new Point(1136, 20);
			dateTimeLabel.Name = "dateTimeLabel";
			dateTimeLabel.Size = new Size(240, 24);
			dateTimeLabel.TabIndex = 0;
			dateTimeLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lblFooterSubtitle
			// 
			lblFooterSubtitle.AutoSize = true;
			lblFooterSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFooterSubtitle.ForeColor = Color.White;
			lblFooterSubtitle.Location = new Point(24, 31);
			lblFooterSubtitle.Name = "lblFooterSubtitle";
			lblFooterSubtitle.Size = new Size(158, 15);
			lblFooterSubtitle.TabIndex = 1;
			lblFooterSubtitle.Text = "Your security is our priority.";
			// 
			// lblFooter
			// 
			lblFooter.AutoSize = true;
			lblFooter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblFooter.ForeColor = Color.White;
			lblFooter.Location = new Point(25, 14);
			lblFooter.Name = "lblFooter";
			lblFooter.Size = new Size(98, 15);
			lblFooter.TabIndex = 2;
			lblFooter.Text = "SECURE SYSTEM";
			// 
			// actionBar
			// 
			actionBar.BackColor = Color.FromArgb(8, 52, 105);
			actionBar.Controls.Add(btnBack);
			actionBar.Dock = DockStyle.Top;
			actionBar.Location = new Point(0, 0);
			actionBar.Name = "actionBar";
			actionBar.Size = new Size(800, 52);
			actionBar.TabIndex = 1;
			// 
			// btnBack
			// 
			btnBack.BackColor = Color.FromArgb(90, 100, 115);
			btnBack.Cursor = Cursors.Hand;
			btnBack.FlatAppearance.BorderSize = 0;
			btnBack.FlatStyle = FlatStyle.Flat;
			btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnBack.ForeColor = Color.White;
			btnBack.Location = new Point(24, 7);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(110, 38);
			btnBack.TabIndex = 0;
			btnBack.Text = "← BACK";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			// 
			// WithdrawalForm
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(248, 249, 251);
			ClientSize = new Size(800, 520);
			Controls.Add(pnlFooter);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(lblReview);
			Controls.Add(lblAvailableBalance);
			Controls.Add(lblAmountHint);
			Controls.Add(pnlAmount);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(pnlHeader);
			Font = new Font("Segoe UI", 10F);
			FormBorderStyle = FormBorderStyle.None;
			Name = "WithdrawalForm";
			Text = "Cash Withdrawal";
			WindowState = FormWindowState.Maximized;
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlAmount.ResumeLayout(false);
			pnlAmount.PerformLayout();
			pnlFooter.ResumeLayout(false);
			pnlSecurityFooter.ResumeLayout(false);
			pnlSecurityFooter.PerformLayout();
			actionBar.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private Panel pnlHeader;
		private Label lblAppName;
		private Label lblAppSubtitle;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label lblAvailableBalance;
		private Label lblReview;
		private Panel pnlAmount;
		private Label lblPeso;
		private TextBox txtAmount;
		private Label lblAmountHint;
		private Button button1;
		private Button button2;
		private Button button3;
		private Panel pnlFooter;
		private Panel pnlSecurityFooter;
		private Panel actionBar;
		private Label lblFooter;
		private Label lblFooterSubtitle;
		private Label dateTimeLabel;
		private Button btnBack;
	}
}
