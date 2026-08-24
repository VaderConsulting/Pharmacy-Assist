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
    public partial class frmUserAccounts : Form
    {
        private bool _NewAccount = false;
        private int _CurrentUserId = 0;
        int _UserStoreId = 0;
        int _UserStartPage = 0;
        int _UserManagerID = 0;
        
        public frmUserAccounts()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserAccounts_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);
            
            gpTitle.Image = PharmacyAssist.Properties.Resources.windows7_general_group_256;
            gpTitle.GradientStartColor = Global.Theme[15];
            
            LoadUserList();
            LoadStores();
            LoadPages();

            if (Global.Permissions.Contains("Create User")) btnCreateAccount.Enabled = true;
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

        private void LoadUserList()
        {
            DataSet Data = null;

            lstUserAccounts.Items.Clear();
            lstPermissions.Items.Clear();
            lstRoles.Items.Clear();
            cmbManager.Items.Clear();

            txtUsername.ReadOnly = true;
            txtUsername.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtTitle.Text = "";
            txtEmailAddress.Text = "";
            txtLastLogon.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cmbStore.SelectedItem = null;
            cmbStartPage.SelectedItem = null;
            chkEnabled.Checked = false;
            chkFirstLogon.Checked = false;
            chkMustResetPassword.Checked = false;
            btnDeleteAccount.Enabled = false;

            _NewAccount = false;

            ListItem BlankManager = new ListItem(0, "");
            cmbManager.Items.Add(BlankManager);

            string Query = "SELECT ID, UserName, Fullname = CASE FirstName + ' ' + LastName WHEN ' ' THEN '(' + UserName + ')' ELSE FirstName + ' ' + LastName END FROM UserAccount";

            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            lstUserAccounts.BeginUpdate();

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem UsernameItem = new ListItem((int)Row[0], (string)Row[1]);
                ListItem FullnameItem = new ListItem((int)Row[0], (string)Row[2]);

                lstUserAccounts.Items.Add(UsernameItem);
                if (FullnameItem.Name.Trim() != "") cmbManager.Items.Add(FullnameItem);
            }

            lstUserAccounts.EndUpdate();
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

        private void lstUserAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Query = "";
            DataSet Data = null;

            if (lstUserAccounts.SelectedItem != null)
            {
                if (Global.Permissions.Contains("Delete User")) btnDeleteAccount.Enabled = true;

                ListItem Item = (ListItem)lstUserAccounts.SelectedItem;

                _CurrentUserId = Item.ID;
                _NewAccount = false;

                lstRoles.Items.Clear();
                lstPermissions.Items.Clear();
                cmbStore.SelectedItem = null;
                cmbStartPage.SelectedItem = null;
                cmbManager.Enabled = true;
                cmbStartPage.Enabled = true;
                cmbStore.Enabled = true;

                btnCheckUsername.Enabled = false;
                if (Global.Permissions.Contains("Write User"))
                {
                    btnSave.Enabled = true;
                }

                // Get user details from SQL
                Query = "SELECT ID, Username, FirstName, LastName, Title, Email,Enabled, FirstLogon, MustResetPassword, ISNULL(LastLogonTimestamp,'01/01/1900') AS LastLogonTimestamp, StoreID, StartPageID, ManagerID, ISNULL(Password,'') AS Password FROM UserAccount WHERE ID = " + Item.ID;
                Cursor.Current = Cursors.WaitCursor;
                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                Cursor.Current = Cursors.Default;

                if (Data.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        txtUsername.Text = (string)Data.Tables[0].Rows[0]["Username"] + "";
                        txtFirstname.Text = (string)Data.Tables[0].Rows[0]["Firstname"] + "";
                        txtLastname.Text = (string)Data.Tables[0].Rows[0]["Lastname"] + "";
                        txtTitle.Text = (string)Data.Tables[0].Rows[0]["Title"] + "";
                        txtEmailAddress.Text = (string)Data.Tables[0].Rows[0]["Email"] + "";
                        chkMustResetPassword.Checked = (bool)Data.Tables[0].Rows[0]["MustResetPassword"];
                        chkFirstLogon.Checked = (bool)Data.Tables[0].Rows[0]["FirstLogon"];
                        chkEnabled.Checked = (bool)Data.Tables[0].Rows[0]["Enabled"];
                        _UserStoreId = (int)Data.Tables[0].Rows[0]["StoreID"];
                        _UserStartPage = (int)Data.Tables[0].Rows[0]["StartPageID"];
                        _UserManagerID = (int)Data.Tables[0].Rows[0]["ManagerID"];
                        txtPassword.Text = (string)Data.Tables[0].Rows[0]["Password"] + "";
                        txtConfirmPassword.Text = (string)Data.Tables[0].Rows[0]["Password"] + "";

                        txtFirstname.Enabled = true;
                        txtLastname.Enabled = true;
                        txtTitle.Enabled = true;
                        txtEmailAddress.Enabled = true;
                        txtPassword.Enabled = true;
                        txtConfirmPassword.Enabled = true;

                        cmbStore.Enabled = true;
                        cmbStartPage.Enabled = true;
                        cmbManager.Enabled = true;
                        btnShowRoles.Enabled = true;

                        chkEnabled.Enabled = true;
                        chkFirstLogon.Enabled = true;
                        chkMustResetPassword.Enabled = true;

                        if (Data.Tables[0].Rows[0]["LastLogonTimestamp"] != null && ((DateTime)Data.Tables[0].Rows[0]["LastLogonTimestamp"]).ToString("g") != "1/01/1900 12:00 AM")
                        {
                            txtLastLogon.Text = ((DateTime)Data.Tables[0].Rows[0]["LastLogonTimestamp"]).ToString("g");
                        }
                        else
                        {
                            txtLastLogon.Text = "";
                        }

                        // Choose the correct store
                        foreach (ListItem Store in cmbStore.Items)
                        {
                            if (Store.ID == _UserStoreId)
                            {
                                cmbStore.SelectedItem = Store;
                                break;
                            }
                        }

                        // Choose the correct start page
                        foreach (ListItem Page in cmbStartPage.Items)
                        {
                            if (Page.ID == _UserStartPage)
                            {
                                cmbStartPage.SelectedItem = Page;
                                break;
                            }
                        }

                        // Choose the correct Manager
                        foreach (ListItem UserAccount in cmbManager.Items)
                        {
                            if (UserAccount.ID == _UserManagerID)
                            {
                                cmbManager.SelectedItem = UserAccount;
                                break;
                            }
                        }

                        // Roles
                        Query = string.Format("SELECT r.Name FROM dbo.Role r LEFT JOIN dbo.UserAccountRole ur ON ur.RoleID = r.ID LEFT JOIN dbo.UserAccount u ON ur.UserAccountID = u.ID WHERE u.ID = '{0}'", Item.ID);

                        Cursor.Current = Cursors.WaitCursor;
                        Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                        Cursor.Current = Cursors.Default;

                        // Place the list of roles for this user into the listbox
                        foreach (DataRow Row in Data.Tables[0].Rows)
                        {
                            lstRoles.Items.Add((string)Row[0]);
                        }

                        // Permissions
                        Query = string.Format("SELECT DISTINCT p.Name, u.Username from dbo.permission p left join rolepermission rp on rp.permissionid = p.id left join role r on r.id = rp.roleid left join useraccountrole ur on ur.roleid = r.id left join useraccount u on u.id = ur.useraccountid where u.ID = '{0}'", Item.ID);

                        Cursor.Current = Cursors.WaitCursor;
                        Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                        Cursor.Current = Cursors.Default;

                        // Place the list of permissions for this user into the listbox
                        foreach (DataRow Row in Data.Tables[0].Rows)
                        {
                            lstPermissions.Items.Add((string)Row[0]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Query = "";
            int MustResetPassword = 0;
            int FirstLogon = 0;
            int Enabled = 0;
            int StoreID = 0;
            int PageID = 0;
            int ManagerID = 0;

            ListItem SelectedUserAccount = (ListItem)lstUserAccounts.SelectedItem;

            if (chkMustResetPassword.Checked) MustResetPassword = 1;
            if (chkFirstLogon.Checked) FirstLogon = 1;
            if (chkEnabled.Checked) Enabled = 1;          

            // Determine which store the user is at
            if (cmbStore.SelectedItem != null)
            {
                StoreID = (int)((ListItem)cmbStore.SelectedItem).ID;
            }

            // Determine which page is the user's start page
            if (cmbStartPage.SelectedItem != null)
            {
                PageID = (int)((ListItem)cmbStartPage.SelectedItem).ID;
            }

            // Determine which page is the user's start page
            if (cmbManager.SelectedItem != null)
            {
                ManagerID = (int)((ListItem)cmbManager.SelectedItem).ID;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (_NewAccount)
                {
                    // Save the new details
                    Query = string.Format("INSERT INTO UserAccount (Username, FirstName, LastName, Title, Email, MustResetPassword, FirstLogon, Enabled, StoreID, StartPageID, ManagerID, Password) VALUES " +
                                                                  "('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9},{10},'{11}');SELECT SCOPE_IDENTITY()",
                                                                  txtUsername.Text.Trim().Replace("'", "''"),
                                                                  txtFirstname.Text.Trim().Replace("'", "''"),
                                                                  txtLastname.Text.Trim().Replace("'", "''"),
                                                                  txtTitle.Text.Trim().Replace("'", "''"),
                                                                  txtEmailAddress.Text.Trim().Replace("'", "''"),
                                                                  MustResetPassword,
                                                                  FirstLogon,
                                                                  Enabled,
                                                                  StoreID,
                                                                  PageID,
                                                                  ManagerID,
                                                                  txtPassword.Text);
                    DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                    int NewID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                    // AUDITING
                    Global.Audit("Insert", "UserAccount", "ID", NewID, Global.Username.Replace("'", "''"), "", NewID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "Username", NewID, Global.Username.Replace("'", "''"), "", txtUsername.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "FirstName", NewID, Global.Username.Replace("'", "''"), "", txtFirstname.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "LastName", NewID, Global.Username.Replace("'", "''"), "", txtLastname.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "Title", NewID, Global.Username.Replace("'", "''"), "", txtTitle.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "Email", NewID, Global.Username.Replace("'", "''"), "", txtEmailAddress.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "Enabled", NewID, Global.Username.Replace("'", "''"), "", Enabled.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "FirstLogon", NewID, Global.Username.Replace("'", "''"), "", FirstLogon.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "MustResetPassword", NewID, Global.Username.Replace("'", "''"), "", MustResetPassword.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "StoreID", NewID, Global.Username.Replace("'", "''"), "", StoreID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "PageID", NewID, Global.Username.Replace("'", "''"), "", PageID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "ManagerID", NewID, Global.Username.Replace("'", "''"), "", ManagerID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "UserAccount", "Password", NewID, Global.Username.Replace("'", "''"), "", txtPassword.Text, Application.ProductName, false);
                }
                else
                {
                    // Save the updated details

                    Cursor.Current = Cursors.WaitCursor;

                    // Get original user details from SQL
                    Query = "SELECT ID, Username, FirstName, LastName, Title, Email,Enabled, FirstLogon, MustResetPassword, StoreID, StartPageID, ISNULL(ManagerID,0) AS ManagerID, ISNULL(Password,'') AS Password FROM UserAccount WHERE ID = " + SelectedUserAccount.ID;

                    DataSet OriginalData = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                    Query = string.Format("UPDATE UserAccount SET FirstName = '{0}', LastName = '{1}', Title = '{2}', Email = '{3}', MustResetPassword = {4}, FirstLogon = {5}, Enabled = {6}, StoreID = {7}, StartPageID = {8}, ManagerID = {9}, Password = '{10}' WHERE ID = {11}",
                                                                  txtFirstname.Text.Trim().Replace("'","''"),
                                                                  txtLastname.Text.Trim().Replace("'", "''"),
                                                                  txtTitle.Text.Trim().Replace("'", "''"),
                                                                  txtEmailAddress.Text.Trim().Replace("'", "''"),
                                                                  MustResetPassword,
                                                                  FirstLogon,
                                                                  Enabled,
                                                                  StoreID,
                                                                  PageID,
                                                                  ManagerID,
                                                                  txtPassword.Text,
                                                                  _CurrentUserId);
                    DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                    Global.Audit("Update", "UserAccount", "FirstName", _CurrentUserId, Global.Username.Replace("'", "''"), ((string)OriginalData.Tables[0].Rows[0]["FirstName"]).Replace("'", "''"), txtFirstname.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "LastName", _CurrentUserId, Global.Username.Replace("'", "''"), ((string)OriginalData.Tables[0].Rows[0]["LastName"]).Replace("'", "''"), txtLastname.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "Title", _CurrentUserId, Global.Username.Replace("'", "''"), ((string)OriginalData.Tables[0].Rows[0]["Title"]).Replace("'", "''"), txtTitle.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "Email", _CurrentUserId, Global.Username.Replace("'", "''"), ((string)OriginalData.Tables[0].Rows[0]["Email"]).Replace("'", "''"), txtEmailAddress.Text.Replace("'", "''"), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "Enabled", _CurrentUserId, Global.Username.Replace("'", "''"), ((bool)OriginalData.Tables[0].Rows[0]["Enabled"]).ToString(), Enabled.ToString(), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "FirstLogon", _CurrentUserId, Global.Username.Replace("'", "''"), ((bool)OriginalData.Tables[0].Rows[0]["FirstLogon"]).ToString(), FirstLogon.ToString(), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "MustResetPassword", _CurrentUserId, Global.Username.Replace("'", "''"), ((bool)OriginalData.Tables[0].Rows[0]["MustResetPassword"]).ToString(), MustResetPassword.ToString(), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "StoreID", _CurrentUserId, Global.Username.Replace("'", "''"), ((int)OriginalData.Tables[0].Rows[0]["StoreID"]).ToString(), StoreID.ToString(), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "StartPageID", _CurrentUserId, Global.Username.Replace("'", "''"), ((int)OriginalData.Tables[0].Rows[0]["StartPageID"]).ToString(), PageID.ToString(), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "ManagerID", _CurrentUserId, Global.Username.Replace("'", "''"), "", ((int)OriginalData.Tables[0].Rows[0]["ManagerID"]).ToString(), Application.ProductName, false);
                    Global.Audit("Update", "UserAccount", "Password", _CurrentUserId, Global.Username.Replace("'", "''"), "", ((string)OriginalData.Tables[0].Rows[0]["Password"]).ToString(), Application.ProductName, false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            Cursor.Current = Cursors.Default;

            LoadUserList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserList();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you sure?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;

                // Get original user details from SQL
                string Query = "SELECT ID, Username, FirstName, LastName, Title, Email,Enabled, FirstLogon, MustResetPassword, StoreID FROM UserAccount WHERE ID = " + _CurrentUserId;

                DataSet OriginalData = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                Query = string.Format("DELETE FROM UserAccount WHERE ID = {0}", _CurrentUserId);
                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                Global.Audit("Delete", "UserAccount", "ID", _CurrentUserId, Global.Username, ((int)OriginalData.Tables[0].Rows[0]["ID"]).ToString(), "", Application.ProductName, false);
                Global.Audit("Delete", "UserAccount", "FirstName", _CurrentUserId, Global.Username, (string)OriginalData.Tables[0].Rows[0]["FirstName"], "", Application.ProductName, false);
                Global.Audit("Delete", "UserAccount", "LastName", _CurrentUserId, Global.Username, (string)OriginalData.Tables[0].Rows[0]["LastName"], "", Application.ProductName, false);
                Global.Audit("Delete", "UserAccount", "Title", _CurrentUserId, Global.Username, (string)OriginalData.Tables[0].Rows[0]["Title"], "", Application.ProductName, false);
                Global.Audit("Delete", "UserAccount", "Email", _CurrentUserId, Global.Username, (string)OriginalData.Tables[0].Rows[0]["Email"], "", Application.ProductName, false);
                Global.Audit("Delete", "UserAccount", "Enabled", _CurrentUserId, Global.Username, ((bool)OriginalData.Tables[0].Rows[0]["Enabled"]).ToString(), "", Application.ProductName, false);
                Global.Audit("Delete", "UserAccount", "FirstLogon", _CurrentUserId, Global.Username, ((bool)OriginalData.Tables[0].Rows[0]["FirstLogon"]).ToString(), "", Application.ProductName, false);
                Global.Audit("Delete", "UserAccount", "MustResetPassword", _CurrentUserId, Global.Username, ((bool)OriginalData.Tables[0].Rows[0]["MustResetPassword"]).ToString(), "", Application.ProductName, false);
                Global.Audit("Delete", "UserAccount", "StoreID", _CurrentUserId, Global.Username, ((int)OriginalData.Tables[0].Rows[0]["StoreID"]).ToString(), "", Application.ProductName, false);

                Cursor.Current = Cursors.Default;
                LoadUserList();
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            _NewAccount = true;

            lstRoles.Items.Clear();
            lstPermissions.Items.Clear();

            txtUsername.Text = "";
            txtFirstname.Text = ""; txtFirstname.Enabled = false;
            txtLastname.Text = ""; txtLastname.Enabled = false;
            txtTitle.Text = ""; txtTitle.Enabled = false;
            txtEmailAddress.Text = ""; txtEmailAddress.Enabled = false;
            txtLastLogon.Text = "";
            chkEnabled.Checked = true; chkEnabled.Enabled = false;
            chkFirstLogon.Checked = true; chkFirstLogon.Enabled = false;
            chkMustResetPassword.Checked = false; chkMustResetPassword.Enabled = false;
            btnDeleteAccount.Enabled = false;
            btnShowRoles.Enabled = false;
            cmbStore.Enabled = false;
            cmbStartPage.Enabled = false;
            cmbManager.Enabled = false;
            btnSave.Enabled = false;

            cmbStore.SelectedItem = null;
            cmbManager.SelectedItem = null;
            cmbStartPage.SelectedItem = null;

            txtUsername.ReadOnly = false;
            //txtUsername.Enabled = true;
            txtUsername.Focus();
        }

        private void btnShowRoles_Click(object sender, EventArgs e)
        {
            OpenItemSelectionForm();
        }

        private void OpenItemSelectionForm()
        {
            frmListItemSelection008 ItemSelectionForm = new frmListItemSelection008(null, Helper.ItemType.UserAccount);

            ItemSelectionForm.ParentObjectID = _CurrentUserId;
            ItemSelectionForm.SingleItemConstraint = false;
            ItemSelectionForm.ListDisplayName = "Roles";
            ItemSelectionForm.ParentType = Helper.ItemType.UserAccount;

            ItemSelectionForm.Show();

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnCheckUsername.Enabled = (txtUsername.Text.Trim().Length > 0 && _NewAccount);
        }

        private void btnCheckUsername_Click(object sender, EventArgs e)
        {
            string Query = "SELECT ID FROM UserAccount WHERE Username like '" + txtUsername.Text.Trim().Replace("'","''") + "'" ;

            int UserCount = Core.SQL.Functions.Count(Query, Global.SqlConnectionString);

            if (UserCount == 0)
            {
                btnCheckUsername.Enabled = false;

                txtUsername.ReadOnly = true;
                txtFirstname.Enabled = true;
                txtLastname.Enabled = true;
                txtEmailAddress.Enabled = true;
                txtTitle.Enabled = true;
                txtPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;
                chkEnabled.Enabled = true;
                chkFirstLogon.Enabled = true;
                chkMustResetPassword.Enabled = true;
                btnSave.Enabled = true;

                txtFirstname.Focus();
            }
            else
            {
                MessageBox.Show("A User Account with this Username already exists", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsername.Focus();
                txtUsername.SelectAll();
            }
        }

        private void frmUserAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            EnableDisableSaveButton();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            EnableDisableSaveButton();
        }

        private void EnableDisableSaveButton()
        {
            btnSave.Enabled = (txtPassword.Text == txtConfirmPassword.Text);
        }
    }
}
