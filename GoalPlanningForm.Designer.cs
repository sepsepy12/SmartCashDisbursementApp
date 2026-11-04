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
			button1 = new Button();
			button4 = new Button();
			button5 = new Button();
			button6 = new Button();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			button2 = new Button();
			button3 = new Button();
			textBox3 = new TextBox();
			textBox4 = new TextBox();
			textBox5 = new TextBox();
			textBox6 = new TextBox();
			textBox7 = new TextBox();
			textBox8 = new TextBox();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(195, 235);
			button1.Name = "button1";
			button1.Size = new Size(179, 125);
			button1.TabIndex = 0;
			button1.Text = "           A               Savings";
			button1.Click += button1_Click;
			// 
			// button4
			// 
			button4.Location = new Point(20, 680);
			button4.Name = "button4";
			button4.Size = new Size(80, 36);
			button4.TabIndex = 5;
			button4.Text = "<- Back";
			button4.Click += button4_Click;
			// 
			// button5
			// 
			button5.Location = new Point(1200, 680);
			button5.Name = "button5";
			button5.Size = new Size(100, 36);
			button5.TabIndex = 6;
			button5.Text = "Confirm";
			button5.Click += button5_Click;
			// 
			// button6
			// 
			button6.Location = new Point(677, 680);
			button6.Name = "button6";
			button6.Size = new Size(100, 36);
			button6.TabIndex = 7;
			button6.Text = "Clear";
			button6.Click += button6_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(258, 502);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(180, 36);
			textBox1.TabIndex = 3;
			textBox1.Text = "0.00";
			// 
			// textBox2
			// 
			textBox2.Location = new Point(887, 502);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(196, 36);
			textBox2.TabIndex = 4;
			textBox2.Text = "YYYY-MM-DD";
			textBox2.TextChanged += textBox2_TextChanged;
			// 
			// button2
			// 
			button2.Location = new Point(632, 235);
			button2.Name = "button2";
			button2.Size = new Size(179, 125);
			button2.TabIndex = 8;
			button2.Text = "            B              Wants";
			button2.Click += button2_Click_1;
			// 
			// button3
			// 
			button3.Location = new Point(1035, 235);
			button3.Name = "button3";
			button3.Size = new Size(179, 125);
			button3.TabIndex = 9;
			button3.Text = "            C              Needs";
			// 
			// textBox3
			// 
			textBox3.Location = new Point(614, 12);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(222, 36);
			textBox3.TabIndex = 10;
			textBox3.Text = "GOAL PLANNING HUB";
			textBox3.TextChanged += textBox3_TextChanged_1;
			// 
			// textBox4
			// 
			textBox4.Font = new Font("Segoe UI", 11F);
			textBox4.Location = new Point(632, 54);
			textBox4.Name = "textBox4";
			textBox4.Size = new Size(182, 27);
			textBox4.TabIndex = 11;
			textBox4.Text = "Set & Track Savings Target";
			// 
			// textBox5
			// 
			textBox5.Location = new Point(374, 146);
			textBox5.Name = "textBox5";
			textBox5.Size = new Size(659, 36);
			textBox5.TabIndex = 12;
			textBox5.Text = "                                    STEP 1: Select Category";
			// 
			// textBox6
			// 
			textBox6.Location = new Point(374, 396);
			textBox6.Name = "textBox6";
			textBox6.Size = new Size(659, 36);
			textBox6.TabIndex = 13;
			textBox6.Text = "                                      STEP 2: Enter Details";
			// 
			// textBox7
			// 
			textBox7.Font = new Font("Segoe UI", 11F);
			textBox7.Location = new Point(256, 469);
			textBox7.Name = "textBox7";
			textBox7.Size = new Size(182, 27);
			textBox7.TabIndex = 14;
			textBox7.Text = "ENTER AMMOUNT (₱)";
			textBox7.TextChanged += textBox7_TextChanged;
			// 
			// textBox8
			// 
			textBox8.Font = new Font("Segoe UI", 11F);
			textBox8.Location = new Point(885, 469);
			textBox8.Name = "textBox8";
			textBox8.Size = new Size(198, 27);
			textBox8.TabIndex = 15;
			textBox8.Text = "ENTER DATE (YYYY-MM-DD)";
			// 
			// GoalPlanningForm
			// 
			ClientSize = new Size(1850, 728);
			Controls.Add(textBox8);
			Controls.Add(textBox7);
			Controls.Add(textBox6);
			Controls.Add(textBox5);
			Controls.Add(textBox4);
			Controls.Add(textBox3);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(textBox1);
			Controls.Add(textBox2);
			Controls.Add(button4);
			Controls.Add(button5);
			Controls.Add(button6);
			Font = new Font("Segoe UI", 16F);
			FormBorderStyle = FormBorderStyle.None;
			Name = "GoalPlanningForm";
			Text = "Goal Planning Hub";
			TopMost = true;
			WindowState = FormWindowState.Maximized;
			Load += GoalPlanningForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		// Controls referenced by GoalPlanningForm.cs
		private Button button1;
        private Button button4;
        private Button button5;
        private Button button6;
        private TextBox textBox1;
        private TextBox textBox2;
		private Button button2;
		private Button button3;
		private TextBox textBox3;
		private TextBox textBox4;
		private TextBox textBox5;
		private TextBox textBox6;
		private TextBox textBox7;
		private TextBox textBox8;
	}
}
