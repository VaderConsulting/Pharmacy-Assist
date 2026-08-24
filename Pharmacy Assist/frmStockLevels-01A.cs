using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmStockLevels01A : Form
    {
        public frmStockLevels01A()
        {
            InitializeComponent();
        }

        private void frmStockLevels01A_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            gpTitle.Image = Properties.Resources.supervista_business_bar_chart_256;
            this.Icon = Properties.Resources.supervista_business_bar_chart;
            gpTitle.GradientStartColor = Global.Theme[21];
        }

        private void frmStockLevels01A_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }
    }
}
