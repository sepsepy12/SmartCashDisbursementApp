using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartCashDisbursementApp
{
    public partial class CounselingHub_Resources : Form
    {
        private readonly int userId;

        public CounselingHub_Resources(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
    }
}
