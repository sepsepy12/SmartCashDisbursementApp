using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class AccountRegistrationForm
	{
		private IContainer components = null!;
		private Panel pnlHeader = null!;
		private Label lblTitle = null!;
		private Label lblSubtitle = null!;
		private Label lblFullName = null!;
		private Label lblRfidUid = null!;
		private Label lblPin = null!;
		private Label lblConfirmPin = null!;
		private TextBox txtFullName = null!;
		private TextBox txtRfidUid = null!;
		private TextBox txtPin = null!;
		private TextBox txtConfirmPin = null!;
		private Button btnRegister = null!;
		private Button btnClear = null!;
		private Button btnBack = null!;

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				components?.Dispose();

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new Container();
			pnlHeader = new Panel();
			lblTitle = new Label();
			lblSubtitle = new Label();
			lblFullName = new Label();
			lblRfidUid = new Label();
			lblPin = new Label();
			lblConfirmPin = new Label();
			txtFullName = new TextBox();
			txtRfidUid = new TextBox();
			txtPin = new TextBox();
			txtConfirmPin = new TextBox();
			btnRegister = new Button();
			btnClear = new Button();
			btnBack = new Button();
			pnlHeader.SuspendLayout();
			SuspendLayout();
			// 
			// pnlHeader
			// 
			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblTitle);
			pnlHeader.Controls.Add(lblSubtitle);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Location = new Point(0, 0);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new Size(760, 92);
			pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			lblTitle.ForeColor = Color.White;
			lblTitle.Location = new Point(34, 14);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(255, 32);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "Account Registration";
			// 
			// lblSubtitle
			// 
			lblSubtitle.AutoSize = true;
			lblSubtitle.Font = new Font("Segoe UI", 10F);
			lblSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblSubtitle.Location = new Point(37, 53);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Size = new Size(345, 19);
			lblSubtitle.TabIndex = 1;
			lblSubtitle.Text = "Register a standard user account using their PLMUN RFID UID.";
			// 
			// lblFullName
			// 
			lblFullName.AutoSize = true;
			lblFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblFullName.ForeColor = Color.FromArgb(7, 57, 113);
			lblFullName.Location = new Point(80, 135);
			lblFullName.Name = "lblFullName";
			lblFullName.Size = new Size(77, 19);
			lblFullName.TabIndex = 0;
			lblFullName.Text = "Full Name";
			// 
			// txtFullName
			// 
			txtFullName.Font = new Font("Segoe UI", 11F);
			txtFullName.Location = new Point(83, 160);
			txtFullName.Name = "txtFullName";
			txtFullName.Size = new Size(594, 27);
			txtFullName.TabIndex = 1;
			// 
			// lblRfidUid
			// 
			lblRfidUid.AutoSize = true;
			lblRfidUid.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblRfidUid.ForeColor = Color.FromArgb(7, 57, 113);
			lblRfidUid.Location = new Point(80, 210);
			lblRfidUid.Name = "lblRfidUid";
			lblRfidUid.Size = new Size(120, 19);
			lblRfidUid.TabIndex = 2;
			lblRfidUid.Text = "PLMUN RFID UID";
			// 
			// txtRfidUid
			// 
			txtRfidUid.Font = new Font("Segoe UI", 11F);
			txtRfidUid.Location = new Point(83, 235);
			txtRfidUid.Name = "txtRfidUid";
			txtRfidUid.Size = new Size(594, 27);
			txtRfidUid.TabIndex = 3;
			// 
			// lblPin
			// 
			lblPin.AutoSize = true;
			lblPin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblPin.ForeColor = Color.FromArgb(7, 57, 113);
			lblPin.Location = new Point(80, 285);
			lblPin.Name = "lblPin";
			lblPin.Size = new Size(30, 19);
			lblPin.TabIndex = 4;
			lblPin.Text = "PIN";
			// 
			// txtPin
			// 
			txtPin.Font = new Font("Segoe UI", 11F);
			txtPin.Location = new Point(83, 310);
			txtPin.MaxLength = 4;
			txtPin.Name = "txtPin";
			txtPin.PasswordChar = '*';
			txtPin.Size = new Size(594, 27);
			txtPin.TabIndex = 5;
			// 
			// lblConfirmPin
			// 
			lblConfirmPin.AutoSize = true;
			lblConfirmPin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblConfirmPin.ForeColor = Color.FromArgb(7, 57, 113);
			lblConfirmPin.Location = new Point(80, 360);
			lblConfirmPin.Name = "lblConfirmPin";
			lblConfirmPin.Size = new Size(86, 19);
			lblConfirmPin.TabIndex = 6;
			lblConfirmPin.Text = "Confirm PIN";
			// 
			// txtConfirmPin
			// 
			txtConfirmPin.Font = new Font("Segoe UI", 11F);
			txtConfirmPin.Location = new Point(83, 385);
			txtConfirmPin.MaxLength = 4;
			txtConfirmPin.Name = "txtConfirmPin";
			txtConfirmPin.PasswordChar = '*';
			txtConfirmPin.Size = new Size(594, 27);
			txtConfirmPin.TabIndex = 7;
			// 
			// btnRegister
			// 
			btnRegister.BackColor = Color.FromArgb(7, 57, 113);
			btnRegister.FlatStyle = FlatStyle.Flat;
			btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnRegister.ForeColor = Color.White;
			btnRegister.Location = new Point(83, 463);
			btnRegister.Name = "btnRegister";
			btnRegister.Size = new Size(180, 46);
			btnRegister.TabIndex = 8;
			btnRegister.Text = "Register";
			btnRegister.UseVisualStyleBackColor = false;
			btnRegister.Click += btnRegister_Click;
			// 
			// btnClear
			// 
			btnClear.BackColor = Color.FromArgb(239, 244, 249);
			btnClear.FlatStyle = FlatStyle.Flat;
			btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnClear.ForeColor = Color.FromArgb(7, 57, 113);
			btnClear.Location = new Point(290, 463);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(180, 46);
			btnClear.TabIndex = 9;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = false;
			btnClear.Click += btnClear_Click;
			// 
			// btnBack
			// 
			btnBack.BackColor = Color.FromArgb(164, 213, 255);
			btnBack.FlatStyle = FlatStyle.Flat;
			btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnBack.ForeColor = Color.FromArgb(7, 57, 113);
			btnBack.Location = new Point(497, 463);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(180, 46);
			btnBack.TabIndex = 10;
			btnBack.Text = "Back";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			// 
			// AccountRegistrationForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(760, 550);
			Controls.Add(btnBack);
			Controls.Add(btnClear);
			Controls.Add(btnRegister);
			Controls.Add(txtConfirmPin);
			Controls.Add(lblConfirmPin);
			Controls.Add(txtPin);
			Controls.Add(lblPin);
			Controls.Add(txtRfidUid);
			Controls.Add(lblRfidUid);
			Controls.Add(txtFullName);
			Controls.Add(lblFullName);
			Controls.Add(pnlHeader);
			Font = new Font("Segoe UI", 9F);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AccountRegistrationForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Account Registration";
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
