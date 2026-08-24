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
    public partial class frmCatalogs002 : Form
    {
        private int _CatalogID = 0;
        
        public frmCatalogs002()
        {
            InitializeComponent();
        }

        private void lstCatalogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            if (lstCatalogs.SelectedIndex > -1)
            {
                btnDeleteCatalog.Enabled = true;
                btnSelectProducts.Enabled = true;

                ListItem Item = (ListItem)lstCatalogs.SelectedItem;

                _CatalogID = Item.ID;

                grpCatalogDetails.Enabled = true;

                GetCatalogDetails();
            }
            else
            {
                btnDeleteCatalog.Enabled = false;
                btnSelectProducts.Enabled = false;

                _CatalogID = 0;

                grpCatalogDetails.Enabled = false;
            }

            txtName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCatalogs_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Refresh();

            Global.AddFormToList(this);

            GetLocalCatalogList();
        }

        private void GetLocalCatalogList()
        {
            string Query = "SELECT ID, ISNULL(Name,'') AS Name, StartDate, EndDate FROM Catalog ORDER BY startdate desc";
            DateTime Start = DateTime.MinValue;
            DateTime End = DateTime.MinValue;
            string Name = "";
            int ID = 0;
            string Text = "";

            Cursor.Current = Cursors.WaitCursor;

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            lstCatalogs.Items.Clear();
            lstCatalogs.BeginUpdate();

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ID = Convert.ToInt32(Row[0]);
                Name = Row[1].ToString();
                Start = Convert.ToDateTime(Row[2]);
                End = Convert.ToDateTime(Row[3]);

                if (Name.Length > 0)
                {
                    Text = Name + " (" + Start.ToString("d") + " to " + End.ToString("d") + ")";
                }
                else
                {
                    Text = Start.ToString("d") + " to " + End.ToString("d");
                }

                ListItem Item = new ListItem(ID, Text);

                lstCatalogs.Items.Add(Item);
            }

            lstCatalogs.EndUpdate();
            Cursor.Current = Cursors.Default;

        }

        private void GetRPMCatalogList()
        {
            string Query = "";

            Query = "SELECT ";
        }

        private void GetCatalogDetails()
        {
            string Query = "SELECT ID, ISNULL(Name,'') AS Name, StartDate, EndDate FROM Catalog WHERE ID = " + _CatalogID;
            DateTime Start = DateTime.MinValue;
            DateTime End = DateTime.MinValue;
            string Name = "";
            int ID = 0;

            Cursor.Current = Cursors.WaitCursor;

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ID = Convert.ToInt32(Row[0]);
                Name = Row[1].ToString();
                Start = Convert.ToDateTime(Row[2]);
                End = Convert.ToDateTime(Row[3]);

                txtName.Text = Name.ToString();
                datStart.Text = Start.ToString();
                datEnd.Text = End.ToString();

                GetCatalogProducts();
            }

            Cursor.Current = Cursors.Default;
        }

        private void GetCatalogProducts()
        {
            // Get the list of products that are already in this catalog

            this.Refresh();

            string Query = "select count (*) from productcatalog inner join product on product.id = productcatalog.productid where catalogid = " + _CatalogID;

            Cursor.Current = Cursors.WaitCursor;

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            lblProductCount.Text = Data.Tables[0].Rows[0][0].ToString() + " products in this catalog.";

            Data = null;
            this.Refresh();

            Cursor.Current = Cursors.Default;
        }

        private void btnDeleteCatalog_Click(object sender, EventArgs e)
        {
            string Query = "";
            DialogResult Result = MessageBox.Show("This cannot be undone - are you sure?","Please confirm",MessageBoxButtons.YesNo);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // Build the query
                Query = "DELETE FROM Catalog WHERE ID = " + _CatalogID;

                // Execute this query to delete the catalog
                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                // Build the query
                Query = "DELETE FROM ProductCatalog WHERE CatalogID = " + _CatalogID;

                // Execute this query to remove the catalog items for this catalog
                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                GetLocalCatalogList();
            }

            EnableDisableButtons();
        }

        private void btnAddCatalog_Click(object sender, EventArgs e)
        {
            grpCatalogDetails.Enabled = true;
            btnSelectProducts.Enabled = false;

            _CatalogID = 0;

            datStart.Value = DateTime.Now;
            datEnd.Value = DateTime.Now;

            txtName.Text = "";
            txtName.SelectAll();
            txtName.Focus();

        }

        private void btnSelectProducts_Click(object sender, EventArgs e)
        {
            frmCatalogDetail001 CatalogForm = new frmCatalogDetail001();

            CatalogForm.CatalogID = _CatalogID;

            CatalogForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            datStart.Value = DateTime.Now;
            datEnd.Value = DateTime.Now;

            btnDeleteCatalog.Enabled = false;

            txtName.Text = "";
            grpCatalogDetails.Enabled = false;
        }

        private void btnSaveCatalog_Click(object sender, EventArgs e)
        {
            string Query = "";
            
            if (_CatalogID > 0)
            {
                Query = "UPDATE catalog SET Name = '" + txtName.Text.Replace("'", "''") + "', StartDate = '" + datStart.Value.ToString("yyyyMMdd") + "', EndDate = '" + datEnd.Value.ToString("yyyyMMdd") + "' WHERE ID = " + _CatalogID.ToString();
            }
            else
            {
                Query = "INSERT INTO catalog (Name, StartDate, EndDate) VALUES ('" + txtName.Text.Replace("'", "''") + "','" + datStart.Value.ToString("yyyyMMdd") + "', '" + datEnd.Value.ToString("yyyyMMdd") + "')";
            }

            Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

            btnSelectProducts.Enabled = true;

            //ResetForm();

            GetLocalCatalogList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();

            GetLocalCatalogList();
        }

        private void frmCatalogs002_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }
    }
}
