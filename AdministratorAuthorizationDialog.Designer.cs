using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	partial class AdministratorAuthorizationDialog
	{
		private System.ComponentModel.IContainer components = null;
		private Panel pnlHeader;
		private Label lblTitle;
		private Label lblSubtitle;
		private Label lblRfidUid;
		private TextBox txtRfidUid;
		private Label lblPin;
		private TextBox txtPin;
		private Button btnAuthorize;
		private Button btnCancel;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			pnlHeader = new Panel();
			lblTitle = new Label();
			lblSubtitle = new Label();
			lblRfidUid = new Label();
			txtRfidUid = new TextBox();
			lblPin = new Label();
			txtPin = new TextBox();
			btnAuthorize = new Button();
			btnCancel = new Button();
			pnlHeader.SuspendLayout();
			SuspendLayout();
			//
			// pnlHeader
			//
			pnlHeader.BackColor = Color.FromArgb(7, 57, 113);
			pnlHeader.Controls.Add(lblSubtitle);
			pnlHeader.Controls.Add(lblTitle);
			pnlHeader.Dock = DockStyle.Top;
			pnlHeader.Height = 74;
			pnlHeader.Name = "pnlHeader";
			//
			// lblTitle
			//
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
			lblTitle.ForeColor = Color.White;
			lblTitle.Location = new Point(20, 8);
			lblTitle.Name = "lblTitle";
			lblTitle.Text = "ADMINISTRATOR AUTHORIZATION";
			//
			// lblSubtitle
			//
			lblSubtitle.AutoSize = true;
			lblSubtitle.Font = new Font("Segoe UI", 9F);
			lblSubtitle.ForeColor = Color.FromArgb(164, 213, 255);
			lblSubtitle.Location = new Point(23, 42);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Text = "Verify an administrator before completing this deposit";
			//
			// lblRfidUid
			//
			lblRfidUid.AutoSize = true;
			lblRfidUid.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblRfidUid.Location = new Point(28, 96);
			lblRfidUid.Name = "lblRfidUid";
			lblRfidUid.Text = "Administrator RFID UID";
			//
			// txtRfidUid
			//
			txtRfidUid.Location = new Point(28, 119);
			txtRfidUid.MaxLength = 50;
			txtRfidUid.Name = "txtRfidUid";
			txtRfidUid.Size = new Size(408, 23);
			txtRfidUid.TabIndex = 0;
			//
			// lblPin
			//
			lblPin.AutoSize = true;
			lblPin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			lblPin.Location = new Point(28, 154);
			lblPin.Name = "lblPin";
			lblPin.Text = "Administrator PIN";
			//
			// txtPin
			//
			txtPin.Location = new Point(28, 177);
			txtPin.MaxLength = 255;
			txtPin.Name = "txtPin";
			txtPin.Size = new Size(408, 23);
			txtPin.TabIndex = 1;
			txtPin.UseSystemPasswordChar = true;
			//
			// btnAuthorize
			//
			btnAuthorize.BackColor = Color.FromArgb(8, 80, 145);
			btnAuthorize.FlatAppearance.BorderSize = 0;
			btnAuthorize.FlatStyle = FlatStyle.Flat;
			btnAuthorize.ForeColor = Color.White;
			btnAuthorize.Location = new Point(180, 224);
			btnAuthorize.Name = "btnAuthorize";
			btnAuthorize.Size = new Size(150, 34);
			btnAuthorize.TabIndex = 2;
			btnAuthorize.Text = "Authorize Deposit";
			btnAuthorize.UseVisualStyleBackColor = false;
			btnAuthorize.Click += btnAuthorize_Click;
			//
			// btnCancel
			//
			btnCancel.BackColor = Color.FromArgb(90, 100, 115);
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = FlatStyle.Flat;
			btnCancel.ForeColor = Color.White;
			btnCancel.Location = new Point(345, 224);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(91, 34);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = false;
			//
			// AdministratorAuthorizationDialog
			//
			AcceptButton = btnAuthorize;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			CancelButton = btnCancel;
			ClientSize = new Size(464, 280);
			Controls.Add(btnCancel);
			Controls.Add(btnAuthorize);
			Controls.Add(txtPin);
			Controls.Add(lblPin);
			Controls.Add(txtRfidUid);
			Controls.Add(lblRfidUid);
			Controls.Add(pnlHeader);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AdministratorAuthorizationDialog";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Administrator Authorization";
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
