using System;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
	public partial class AdministratorAuthorizationDialog : Form
	{
		public AdministratorAuthorizationDialog()
		{
			InitializeComponent();
		}

		internal void TakeCredentials(out string rfidUid, out string pin)
		{
			rfidUid = txtRfidUid.Text.Trim();
			pin = txtPin.Text.Trim();
			txtRfidUid.Clear();
			txtPin.Clear();
		}

		private void btnAuthorize_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtRfidUid.Text) || string.IsNullOrWhiteSpace(txtPin.Text))
			{
				MessageBox.Show(this,
					"Enter the administrator RFID UID and PIN to continue.",
					"Credentials Required",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			DialogResult = DialogResult.OK;
		}
	}
}
