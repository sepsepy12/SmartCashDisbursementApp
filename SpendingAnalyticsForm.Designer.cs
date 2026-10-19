namespace SmartCashDisbursementApp
{
    partial class SpendingAnalyticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCategoryBalances = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategoryBalances).BeginInit();
            SuspendLayout();
            // 
            // dgvCategoryBalances
            // 
            dgvCategoryBalances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategoryBalances.Location = new Point(127, 24);
            dgvCategoryBalances.Name = "dgvCategoryBalances";
            dgvCategoryBalances.Size = new Size(445, 140);
            dgvCategoryBalances.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(65, 393);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // SpendingAnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            // Use larger default font so UI scales for fullscreen
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(dgvCategoryBalances);
            Name = "SpendingAnalyticsForm";
            Text = "SpendingAnalyticsForm";
            // Start in borderless fullscreen (kiosk) mode
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            // Make grid use larger text
            dgvCategoryBalances.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // Configure back button for runtime centering (handled on Load/Resize)
            btnBack.Height = 64;
            btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnBack.Anchor = AnchorStyles.None;
            // Wire up runtime layout events to center controls
            this.Load += SpendingAnalyticsForm_Load;
            this.Resize += SpendingAnalyticsForm_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvCategoryBalances).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCategoryBalances;
        private Button btnBack;
    }
}