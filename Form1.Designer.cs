namespace SmartCashDisbursementApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtRfidUid = new TextBox();
            txtPin = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(363, 24);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = " RFID UID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(381, 171);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 1;
            label2.Text = "PIN";
            // 
            // txtRfidUid
            // 
            txtRfidUid.Location = new Point(318, 65);
            txtRfidUid.Multiline = true;
            txtRfidUid.Name = "txtRfidUid";
            txtRfidUid.Size = new Size(157, 25);
            txtRfidUid.TabIndex = 2;
            txtRfidUid.Text = "TESTCARD001";
            txtRfidUid.TextAlign = HorizontalAlignment.Center;
            txtRfidUid.TextChanged += txtRfidUid_TextChanged;
            // 
            // txtPin
            // 
            txtPin.Location = new Point(342, 189);
            txtPin.MaxLength = 4;
            txtPin.Name = "txtPin";
            txtPin.PasswordChar = '*';
            txtPin.Size = new Size(100, 23);
            txtPin.TabIndex = 3;
            txtPin.Text = "1234";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(332, 349);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            // Larger default font to match fullscreen UI
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ClientSize = new Size(839, 481);
            Controls.Add(btnLogin);
            Controls.Add(txtPin);
            Controls.Add(txtRfidUid);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            // Start the application in borderless fullscreen (kiosk) mode
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtRfidUid;
        private TextBox txtPin;
        private Button btnLogin;
    }
}
