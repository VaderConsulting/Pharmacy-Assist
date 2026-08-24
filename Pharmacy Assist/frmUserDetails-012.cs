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
    public partial class frmUserDetails : Form
    {
        bool _ReadOnly = false;
        int _UserID = 0;
        int _UserStartPage = 0;
        int _UserStoreId = 0;

        public frmUserDetails(int UserID, string Message, bool ReadOnly)
        {
            InitializeComponent();

            _UserID = UserID;
            lblMessage.Text = Message;
            _ReadOnly = ReadOnly;
        }

        private void ApplyPermissions()
        {
            if (!_ReadOnly || Global.Permissions.Contains("Write User Account") || Global.UserID == _UserID)
            {
                txtFirstname.Enabled = true;
                txtLastname.Enabled = true;
                txtTitle.Enabled = true;
                txtEmailAddress.Enabled = true;
                cmbStore.Enabled = true;
                cmbStartPage.Enabled = true;
                btnOK.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string Query = "";
            int StoreID = 0;
            int PageID = 0;

            // Determine which store the user is at
            if (cmbStore.SelectedItem != null)
            {
                StoreID = (int)((ListItem)cmbStore.SelectedItem).ID;
            }

            // Determine which page to use for the start page
            if (cmbStartPage.SelectedItem != null)
            {
                PageID = (int)((ListItem)cmbStartPage.SelectedItem).ID;
            }

            try
            {
                // Save the updated details
                Cursor.Current = Cursors.WaitCursor;
                Query = string.Format("UPDATE UserAccount SET Firstname = '{0}', Lastname = '{1}', Title = '{2}', Email = '{3}', StoreID = {4}, StartPageID = {5} WHERE ID = {6}", txtFirstname.Text.Replace("'", "''"), txtLastname.Text.Replace("'", "''"), txtTitle.Text.Replace("'", "''"), txtEmailAddress.Text.Replace("'", "''"), StoreID, PageID, Global.UserID);
                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);
                Cursor.Current = Cursors.Default;
                this.Close();
            }
            catch
            {
                
            }
        }

        private void frmUserDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);
            
            gpTitle.Image = PharmacyAssist.Properties.Resources.windows7_general_group_256;
            gpTitle.GradientStartColor = Global.Theme[15];
            
            LoadUserDetails();
            LoadStores();
            LoadPages();
            ApplyPermissions();
        }

        private void LoadPages()
        {
            string Query = "";
            DataSet Data = null;

            // Get page list from SQL
            Query = "SELECT ID, ISNULL(Name,'') AS Name FROM Page";
            Cursor.Current = Cursors.WaitCursor;
            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            ListItem Item = new ListItem(0, "");

            cmbStartPage.Items.Add(Item);  // Add an empty start page

            // Place the pages into the combobox
            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                Item = new ListItem();

                Item.ID = (int)Row["ID"];
                Item.Name = (string)Row["Name"];

                cmbStartPage.Items.Add(Item);

                if (Item.ID == _UserStartPage) cmbStartPage.SelectedItem = Item;
            }
        }

        private void LoadStores()
        {
            string Query = "";
            DataSet Data = null;

            // Get store list from SQL
            Query = "SELECT ID, ISNULL(Name,'') AS Name FROM Store";
            Cursor.Current = Cursors.WaitCursor;
            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            // Place the stores into the combobox
            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem Item = new ListItem();

                Item.ID = (int)Row["ID"];
                Item.Name = (string)Row["Name"];
                cmbStore.Items.Add(Item);

                if (Item.ID == _UserStoreId) cmbStore.SelectedItem = Item;
            }
        }

        private void LoadUserDetails()
        {
            string Query = "";
            DataSet Data = null;

            lstPermissions.Items.Clear();

            // Get user details from SQL
            Query = "SELECT ID, Username, FirstName, LastName, Title, Email, StoreID, StartPageID FROM UserAccount WHERE ID = " + _UserID;
            Cursor.Current = Cursors.WaitCursor;
            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            try
            {
                txtUsername.Text = (string)Data.Tables[0].Rows[0]["Username"] + "";
                txtFirstname.Text = (string)Data.Tables[0].Rows[0]["Firstname"] + "";
                txtLastname.Text = (string)Data.Tables[0].Rows[0]["Lastname"] + "";
                txtTitle.Text = (string)Data.Tables[0].Rows[0]["Title"] + "";
                txtEmailAddress.Text = (string)Data.Tables[0].Rows[0]["Email"] + "";
                _UserStoreId = (int)Data.Tables[0].Rows[0]["StoreID"];
                _UserStartPage = (int)Data.Tables[0].Rows[0]["StartPageID"];

                // Permissions
                Query = string.Format("select p.Name, u.Username from dbo.permission p left join rolepermission rp on rp.permissionid = p.id left join role r on r.id = rp.roleid left join useraccountrole ur on ur.roleid = r.id left join useraccount u on u.id = ur.useraccountid where u.ID = '{0}'", _UserID);

                Cursor.Current = Cursors.WaitCursor;
                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                Cursor.Current = Cursors.Default;

                // Place the list of permissions for this user into the listbox
                foreach (DataRow Row in Data.Tables[0].Rows)
                {
                    lstPermissions.Items.Add((string)Row[0]);
                }

            }
            catch { }
        }
    }
}
