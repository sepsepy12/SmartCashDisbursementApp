using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    partial class GoalPlanningForm
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
            this.components = new Container();
            // Larger default font for fullscreen
            this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // Minimal layout to satisfy references from GoalPlanningForm.cs
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.button5 = new Button();
            this.button6 = new Button();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();

            // Set basic properties
            this.button1.Text = "A";
            this.button2.Text = "B";
            this.button3.Text = "C";
            this.button4.Text = "<- Back";
            this.button5.Text = "Confirm";
            this.button6.Text = "Clear";

            this.textBox1.Text = "0.00";
            this.textBox2.Text = "YYYY-MM-DD";

            // Wire up event handlers used by the code-behind
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button5.Click += new EventHandler(this.button5_Click);
            this.button6.Click += new EventHandler(this.button6_Click);
            this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);

            // Simple layout
            this.button1.Location = new Point(20, 100);
            this.button2.Location = new Point(100, 100);
            this.button3.Location = new Point(180, 100);
            this.textBox1.Location = new Point(20, 160);
            this.textBox2.Location = new Point(220, 160);
            this.button5.Location = new Point(20, 220);
            this.button6.Location = new Point(140, 220);
            this.button4.Location = new Point(260, 220);

            this.button1.Size = new Size(60, 40);
            this.button2.Size = new Size(60, 40);
            this.button3.Size = new Size(60, 40);
            this.textBox1.Size = new Size(180, 30);
            this.textBox2.Size = new Size(180, 30);
            this.button5.Size = new Size(100, 36);
            this.button6.Size = new Size(100, 36);
            this.button4.Size = new Size(80, 36);

            // Add controls to the form
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);

            // Form properties
            this.Text = "Goal Planning Hub";
            this.ClientSize = new Size(420, 300);
            // Start in borderless fullscreen (kiosk) mode
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
        }

        // Controls referenced by GoalPlanningForm.cs
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
