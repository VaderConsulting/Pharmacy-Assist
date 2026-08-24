using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecurrenceGenerator;

namespace Recurrance_Checker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            txtNextDate.Text = RecurrenceHelper.GetNextDate(DateTime.Now, txtRecurranceValue.Text).ToString("d MMM, yyyy");

            switch (txtRecurranceValue.Text.Substring(0, 1))
            {
                case "D":
                    {
                        lblFrequency.Text = "Daily";
                        break;
                    }
                case "W":
                    {
                        lblFrequency.Text = "Weekly";
                        break;
                    }
                case "M":
                    {
                        lblFrequency.Text = "Monthly";
                        break;
                    }
                case "Y":
                    {
                        lblFrequency.Text = "Yearly";
                        break;
                    }
            }
        }
    }
}
