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
    public partial class frmLinkedItems006 : Form
    {
        public string ItemName { get; set; }
        public string ProductDeleteQuery { get; set; }
        public string ProductSelectQuery { get; set; }
        public string SecondaryDeleteQuery { get; set; }
        public string SecondarySelectQuery { get; set; }

        public frmLinkedItems006()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("This will delete the linking regardless of any linked items, and will result in 'orphaned' records.\n\n Really delete?", "Delete", MessageBoxButtons.YesNo);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                ExecuteProductDeleteQuery();
            }
        }

        private void btnOpenItem_Click(object sender, EventArgs e)
        {
            ListItem Item = (ListItem)lstItems.SelectedItem;

            GetItemDetails(Item);

            btnOpenItem.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ExecuteProductSelectQuery();
        }

        private void ExecuteProductDeleteQuery()
        {
            if (ProductDeleteQuery.Length > 0)
            {
                Core.SQL.Functions.ExecuteNonQuery(ProductDeleteQuery.Replace("'", "''"), Global.SqlConnectionString);

                ExecuteProductSelectQuery();
            }
        }

        private void ExecuteProductSelectQuery()
        {
            if (ProductSelectQuery.Length > 0)
            {
                DataSet Data = Core.SQL.Functions.Execute(ProductSelectQuery, Global.SqlConnectionString);

                lstItems.Items.Clear();
                lstItems.BeginUpdate();

                foreach (DataRow Row in Data.Tables[0].Rows)
                {
                    if (Row[0] != null && Row[1] != null && Microsoft.VisualBasic.Information.IsNumeric(Row[0]))
                    {
                        ListItem Item = new ListItem((int)Row[0], (string)Row[1]);

                        lstItems.Items.Add(Item);
                    }
                }

                lstItems.EndUpdate();
                lblItemCount.Text = lstItems.Items.Count.ToString() + " " + ItemName + "(s) listed.";
            }
        }

        private void frmLinkedItems_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            this.Text = "Linked " + ItemName + "s";

            switch (ItemName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        gpTitle.Image = Properties.Resources.vista_medical_laboratory_256;
                        this.Icon = Properties.Resources.vista_medical_laboratory;
                        gpTitle.GradientStartColor = Global.Theme[0];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_business_brand_256;
                        this.Icon = Properties.Resources.vista_business_brand;
                        gpTitle.GradientStartColor = Global.Theme[1];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Catalog":
                case "Catalogs":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.clean_business_catalog_256;
                        this.Icon = Properties.Resources.clean_business_catalog;
                        gpTitle.GradientStartColor = Global.Theme[2];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_accounting_inventory_categories_256;
                        this.Icon = Properties.Resources.vista_accounting_inventory_categories;
                        gpTitle.GradientStartColor = Global.Theme[2];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_mobile_certificate_management_256;
                        this.Icon = Properties.Resources.realvista_mobile_certificate_management;
                        gpTitle.GradientStartColor = Global.Theme[3];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_medical_diagnostic_256;
                        this.Icon = PharmacyAssist.Properties.Resources.realvista_medical_diagnostic;
                        gpTitle.GradientStartColor = Global.Theme[4];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_general_book_256;
                        this.Icon = Properties.Resources.supervista_general_book;
                        gpTitle.GradientStartColor = Global.Theme[5];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "End Use":
                case "End Uses":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_medical_patient_information_256;
                        this.Icon = PharmacyAssist.Properties.Resources.supervista_medical_patient_information;
                        gpTitle.GradientStartColor = Global.Theme[6];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Event":
                case "Events":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_business_meeting_256;
                        this.Icon = Properties.Resources.vista_business_meeting;
                        gpTitle.GradientStartColor = Global.Theme[7];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_general_stats_256;
                        this.Icon = Properties.Resources.supervista_general_stats;
                        gpTitle.GradientStartColor = Global.Theme[8];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_security_application_modules_256;
                        this.Icon = Properties.Resources.supervista_security_application_modules;
                        gpTitle.GradientStartColor = Global.Theme[9];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Presenter":
                case "Presenters":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.windows7_general_group_256;
                        this.Icon = Properties.Resources.windows7_general_group;
                        gpTitle.GradientStartColor = Global.Theme[10];
                        break;
                    }
                case "Product":
                case "Products":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_business_benchmarking_256;
                        this.Icon = Properties.Resources.supervista_business_benchmarking;
                        gpTitle.GradientStartColor = Global.Theme[16];
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_networking_role_256;
                        this.Icon = Properties.Resources.vista_networking_role;
                        gpTitle.GradientStartColor = Global.Theme[11];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_communications_skin_256;
                        this.Icon = Properties.Resources.vista_communications_skin;
                        gpTitle.GradientStartColor = Global.Theme[12];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_realestate_drugstore_256;
                        this.Icon = Properties.Resources.realvista_realestate_drugstore;
                        gpTitle.GradientStartColor = Global.Theme[13];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.plasticxp_medical_allergy_vials_256;
                        this.Icon = Properties.Resources.plasticxp_medical_allergy_vials;
                        gpTitle.GradientStartColor = Global.Theme[14];

                        btnOpenItem.Enabled = false;
                        break;
                    }
                case "User Account":
                case "User Accounts":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.windows7_general_group_256;
                        this.Icon = Properties.Resources.windows7_general_group;
                        gpTitle.GradientStartColor = Global.Theme[15];
                        break;
                    }
            }

            ExecuteProductSelectQuery();

            if (ProductDeleteQuery != null) btnDelete.Visible = true;
        }

        private void frmLinkedItems006_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void GetItemDetails(ListItem Item)
        {
            int ItemUniqueIdentifier = Item.ID;
            string Query = "";
            int ItemID = 0;

            switch (ItemName)
            {
                case "Product":
                case "Products":
                    {
                        //Query = "SELECT ID FROM Product WHERE ID = " + ItemUniqueIdentifier;

                        //ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        //frmProductDetail DetailForm = new frmProductDetail(ID: ItemID, Parent: null);
                        frmProductDetail DetailForm = new frmProductDetail(ID: ItemUniqueIdentifier, Parent: null);
                        DetailForm.Show();

                        break;
                    }
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        // An ingredient can be linked to a condition or a Product

                        //Query = "SELECT ID FROM Product WHERE UPI = " + ItemUniqueIdentifier;

                        //ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        //frmProductDetail DetailForm = new frmProductDetail(ID: ItemID, Parent: null);
                        //DetailForm.Show();

                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        // A Condition can be linked to an Ingredient or a Product

                        //Query = "SELECT ID FROM Product WHERE UPI = " + ItemUniqueIdentifier;

                        //ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        //frmProductDetail DetailForm = new frmProductDetail(ID: ItemID, Parent: null);
                        //DetailForm.Show();

                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        //Query = "SELECT ID FROM Product WHERE UPI = " + ItemUniqueIdentifier;

                        //ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        //frmProductDetail DetailForm = new frmProductDetail(ID: ItemID, Parent: null);
                        //DetailForm.Show();

                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        //Query = "SELECT ID FROM Product WHERE UPI = " + ItemUniqueIdentifier;

                        //ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        //frmProductDetail DetailForm = new frmProductDetail(ID: ItemID, Parent: null);
                        //DetailForm.Show();

                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        //Query = "SELECT ID FROM Product WHERE UPI = " + ItemUniqueIdentifier;

                        //ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        //frmProductDetail DetailForm = new frmProductDetail(ID: ItemID, Parent: null);
                        //DetailForm.Show();

                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        break;
                    }
                case "End Use":
                case "End Uses":
                    {
                        //Query = "SELECT ID FROM Product WHERE UPI = " + ItemUniqueIdentifier;

                        //ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        //frmProductDetail DetailForm = new frmProductDetail(ID: ItemID, Parent: null);
                        //DetailForm.Show();

                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        //Query = "SELECT ID FROM Product WHERE UPI = " + ItemUniqueIdentifier;

                        //ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        //frmProductDetail DetailForm = new frmProductDetail(ID: ItemID, Parent: null);
                        //DetailForm.Show();

                        break;
                    }
                case "User Account":
                case "User Accounts":
                    {
                        Query = "SELECT ID FROM UserAccount WHERE ID = " + ItemUniqueIdentifier;

                        ItemID = (int)Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);

                        frmUserDetails DetailForm = new frmUserDetails(ItemID, "", false);
                        DetailForm.Show();
                        break;
                    }
            }
        }

        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstItems.SelectedIndex != -1)
            {
                ListItem Item = (ListItem)lstItems.SelectedItem;

                GetItemDetails(Item);

                btnOpenItem.Enabled = false;
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex != -1)
            {
                btnOpenItem.Enabled = true;
            }
        }
    }
}
