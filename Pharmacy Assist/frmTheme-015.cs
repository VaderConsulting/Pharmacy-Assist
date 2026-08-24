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
    public partial class frmTheme015 : Form
    {
        List<Color> _Theme = new List<Color>();
        
        public frmTheme015()
        {
            InitializeComponent();
        }

        private void frmTheme_Load(object sender, EventArgs e)
        {
            gpTitle.Image = Properties.Resources.supervista_graphics_color_256;
            this.Icon = Properties.Resources.supervista_graphics_color;
            gpTitle.GradientStartColor = Global.Theme[19];
            
            picItemImage0.Image = Properties.Resources.vista_medical_laboratory_32;
            picItemImage1.Image = Properties.Resources.vista_business_brand_32;
            picItemImage2.Image = Properties.Resources.vista_accounting_inventory_categories_32;
            picItemImage3.Image = Properties.Resources.realvista_mobile_certificate_management_32;
            picItemImage4.Image = Properties.Resources.realvista_medical_diagnostic_32;
            picItemImage5.Image = Properties.Resources.supervista_general_book_32;
            picItemImage6.Image = Properties.Resources.supervista_medical_patient_information_32;
            picItemImage7.Image = Properties.Resources.vista_business_meeting_32;
            picItemImage8.Image = Properties.Resources.supervista_general_stats_32;
            picItemImage9.Image = Properties.Resources.supervista_security_application_modules_32;
            picItemImage10.Image = Properties.Resources.windows7_general_group_32;
            picItemImage11.Image = Properties.Resources.vista_networking_role_32;
            picItemImage12.Image = Properties.Resources.vista_communications_skin_32;
            picItemImage13.Image = Properties.Resources.realvista_realestate_drugstore_32;
            picItemImage14.Image = Properties.Resources.plasticxp_medical_allergy_vials_32;
            picItemImage15.Image = Properties.Resources.windows7_general_group_32;
            picItemImage16.Image = Properties.Resources.supervista_business_benchmarking_32;
            picItemImage17.Image = Properties.Resources.realvista_general_gear_32;
            picItemImage18.Image = Properties.Resources.clean_business_catalog_32;
            picItemImage19.Image = Properties.Resources.realvista_projectmanagment_task_32;
            picItemImage20.Image = Properties.Resources.supervista_general_clock_32;
            picItemImage21.Image = Properties.Resources.supervista_business_bar_chart_32;

            picItemImage30.Image = null;
            picItemImage31.Image = null;

            _Theme = Global.Theme;

            SetColorsFromTheme();

            tbrTheme.Value = Properties.Settings.Default.SearchColourThemeNumber;
        }

        private void SetColorsFromTheme()
        {
            lblItemColour0.BackColor = _Theme[0];
            lblItemColour1.BackColor = _Theme[1];
            lblItemColour2.BackColor = _Theme[2];
            lblItemColour3.BackColor = _Theme[3];
            lblItemColour4.BackColor = _Theme[4];
            lblItemColour5.BackColor = _Theme[5];
            lblItemColour6.BackColor = _Theme[6];
            lblItemColour7.BackColor = _Theme[7];
            lblItemColour8.BackColor = _Theme[8];
            lblItemColour9.BackColor = _Theme[9];
            lblItemColour10.BackColor = _Theme[10];
            lblItemColour11.BackColor = _Theme[11];
            lblItemColour12.BackColor = _Theme[12];
            lblItemColour13.BackColor = _Theme[13];
            lblItemColour14.BackColor = _Theme[14];
            lblItemColour15.BackColor = _Theme[15];
            lblItemColour16.BackColor = _Theme[16];
            lblItemColour17.BackColor = _Theme[17];
            lblItemColour18.BackColor = _Theme[18];
            lblItemColour19.BackColor = _Theme[19];
            lblItemColour20.BackColor = _Theme[20];
            lblItemColour21.BackColor = _Theme[21];

            lblItemColour30.BackColor = _Theme[30];
            lblItemColour31.BackColor = _Theme[31];
        }

        private void tbrTheme_ValueChanged(object sender, EventArgs e)
        {
            _Theme = Global.LoadTheme(tbrTheme.Value);

            SetColorsFromTheme();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Global.Theme = Global.LoadTheme(tbrTheme.Value);
            Properties.Settings.Default.SearchColourThemeNumber = tbrTheme.Value;

            this.Close();
        }

        private void tbrTheme_Scroll(object sender, EventArgs e)
        {

        }
    }
}
