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
			lblAppName = new Label();
			lblAppSubtitle = new Label();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			lblAvailableBalance = new Label();
			lblReview = new Label();
			pnlAmount = new Panel();
			lblPeso = new Label();
			txtAmount = new TextBox();
			lblAmountHint = new Label();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			button4 = new Button();
			button5 = new Button();
			pnlFooter = new Panel();
			lblFooter = new Label();
			btnBack = new Button();
			pnlHeader.SuspendLayout();
			pnlAmount.SuspendLayout();
			pnlFooter.SuspendLayout();
			SuspendLayout();
			//
			// pnlHeader
			//
			pnlHeader.BackColor = Color.FromArgb(8, 80, 145);
			pnlHeader.Controls.Add(lblAppSubtitle);
			pnlHeader.Controls.Add(lblAppName);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Size = new Size(800, 70);
			//
			// lblAppName
			//
			lblAppName.AutoSize = true;
			lblAppName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			lblAppName.ForeColor = Color.White;
			lblAppName.Location = new Point(62, 15);
			lblAppName.Text = "SMART CASH DISBURSEMENT";
			//
			// lblAppSubtitle
			//
			lblAppSubtitle.AutoSize = true;
			lblAppSubtitle.Font = new Font("Segoe UI", 8F);
			lblAppSubtitle.ForeColor = Color.FromArgb(215, 232, 245);
			lblAppSubtitle.Location = new Point(63, 39);
			lblAppSubtitle.Text = "BUDGETING MACHINE";
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16F);
			label1.ForeColor = Color.FromArgb(35, 45, 60);
			label1.Location = new Point(315, 80);
			label1.Text = "DASHBOARD";
			//
			// label2
			//
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label2.Location = new Point(300, 116);
			label2.Text = "WITHDRAWAL DETAILS";
			label2.Click += label2_Click;
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label3.Location = new Point(235, 148);
			label3.Text = "1. HOW MUCH WOULD YOU LIKE TO WITHDRAW?";
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label4.Location = new Point(230, 258);
			label4.Text = "2. CHOOSE WHERE TO WITHDRAW FROM:";
			label4.Click += label4_Click;
			//
			// lblAvailableBalance
			//
			lblAvailableBalance.AutoSize = true;
			lblAvailableBalance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
			lblAvailableBalance.ForeColor = Color.FromArgb(60, 75, 90);
			lblAvailableBalance.Location = new Point(530, 234);
			lblAvailableBalance.Text = "Available balance: ₱0.00";
			//
			// pnlAmount
			//
			pnlAmount.BackColor = Color.WhiteSmoke;
			pnlAmount.BorderStyle = BorderStyle.FixedSingle;
			pnlAmount.Controls.Add(txtAmount);
			pnlAmount.Controls.Add(lblPeso);
			pnlAmount.Location = new Point(130, 178);
			pnlAmount.Size = new Size(540, 52);
			//
			// lblPeso
			//
			lblPeso.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			lblPeso.ForeColor = Color.DimGray;
			lblPeso.Location = new Point(130, 5);
			lblPeso.Size = new Size(40, 40);
			lblPeso.Text = "₱";
			lblPeso.TextAlign = ContentAlignment.MiddleCenter;
			//
			// txtAmount
			//
			txtAmount.BorderStyle = BorderStyle.None;
			txtAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			txtAmount.ForeColor = Color.DimGray;
			txtAmount.Location = new Point(170, 6);
			txtAmount.Size = new Size(220, 32);
			txtAmount.Text = "0.00";
			txtAmount.TextAlign = HorizontalAlignment.Center;
			//
			// lblAmountHint
			//
			lblAmountHint.AutoSize = true;
			lblAmountHint.Font = new Font("Segoe UI", 9F);
			lblAmountHint.Location = new Point(302, 234);
			lblAmountHint.Text = "(Enter amount via numeric keypad)";
			//
			// lblReview
			//
			lblReview.AutoSize = false;
			lblReview.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
			lblReview.ForeColor = Color.FromArgb(45, 65, 85);
			lblReview.Location = new Point(130, 395);
			lblReview.Size = new Size(540, 25);
			lblReview.Text = "Select a category and review your withdrawal before confirming.";
			//
			// button1
			//
			button1.BackColor = Color.White;
			button1.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
			button1.FlatAppearance.BorderSize = 1;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			button1.ForeColor = Color.FromArgb(20, 75, 115);
			button1.Location = new Point(20, 292);
			button1.Size = new Size(190, 90);
			button1.Text = "A. NEEDS\n\n(WITHDRAWAL FOR\nESSENTIAL LIVING\nEXPENSES)";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			//
			// button2
			//
			button2.BackColor = Color.White;
			button2.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
			button2.FlatAppearance.BorderSize = 1;
			button2.FlatStyle = FlatStyle.Flat;
			button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			button2.ForeColor = Color.FromArgb(20, 75, 115);
			button2.Location = new Point(305, 292);
			button2.Size = new Size(190, 90);
			button2.Text = "B. WANTS\n\n(WITHDRAWAL FOR\nDISCRETIONARY OR\nLEISURE SPENDING)";
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			//
			// button3
			//
			button3.BackColor = Color.White;
			button3.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
			button3.FlatAppearance.BorderSize = 1;
			button3.FlatStyle = FlatStyle.Flat;
			button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			button3.ForeColor = Color.FromArgb(20, 75, 115);
			button3.Location = new Point(590, 292);
			button3.Size = new Size(190, 90);
			button3.Text = "C. SAVINGS\n\n(WITHDRAWAL FROM\nEMERGENCY OR\nGOAL FUNDS)";
			button3.UseVisualStyleBackColor = false;
			button3.Click += button3_Click;
			//
			// pnlFooter
			//
			pnlFooter.BackColor = Color.FromArgb(8, 80, 145);
			pnlFooter.Controls.Add(lblFooter);
			pnlFooter.Controls.Add(btnBack);
			pnlFooter.Controls.Add(button5);
			pnlFooter.Controls.Add(button4);
			pnlFooter.Dock = DockStyle.Bottom;
			pnlFooter.Size = new Size(800, 60);
			//
			// lblFooter
			//
			lblFooter.AutoSize = true;
			lblFooter.Font = new Font("Segoe UI", 8F);
			lblFooter.ForeColor = Color.White;
			lblFooter.Location = new Point(150, 22);
			lblFooter.Text = "SECURE SYSTEM - Your security is our priority.";
			//
			// btnBack
			//
			btnBack.BackColor = Color.FromArgb(120, 120, 120);
			btnBack.FlatAppearance.BorderSize = 0;
			btnBack.FlatStyle = FlatStyle.Flat;
			btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnBack.ForeColor = Color.White;
			btnBack.Location = new Point(20, 13);
			btnBack.Size = new Size(100, 34);
			btnBack.Text = "← BACK";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			//
			// button5
			//
			button5.BackColor = Color.FromArgb(55, 105, 145);
			button5.FlatAppearance.BorderSize = 0;
			button5.FlatStyle = FlatStyle.Flat;
			button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			button5.ForeColor = Color.White;
			button5.Location = new Point(485, 13);
			button5.Size = new Size(145, 34);
			button5.Text = "REVIEW WITHDRAWAL";
			button5.UseVisualStyleBackColor = false;
			button5.Click += button5_Click;
			//
			// button4
			//
			button4.BackColor = Color.FromArgb(170, 170, 170);
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatStyle = FlatStyle.Flat;
			button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			button4.ForeColor = Color.White;
			button4.Location = new Point(650, 13);
			button4.Size = new Size(125, 34);
			button4.Text = "CONFIRM";
			button4.UseVisualStyleBackColor = false;
			button4.Click += button4_Click;
			//
			// WithdrawalForm
			//
			AutoScaleDimensions = new SizeF(7F, 15F);
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
			FormBorderStyle = FormBorderStyle.None;
			Font = new Font("Segoe UI", 10F);
			Name = "WithdrawalForm";
			Text = "Cash Withdrawal";
			TopMost = true;
			WindowState = FormWindowState.Maximized;
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			pnlAmount.ResumeLayout(false);
			pnlAmount.PerformLayout();
			pnlFooter.ResumeLayout(false);
			pnlFooter.PerformLayout();
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
		private Button button4;
		private Button button5;
		private Panel pnlFooter;
		private Label lblFooter;
		private Button btnBack;
	}
}
