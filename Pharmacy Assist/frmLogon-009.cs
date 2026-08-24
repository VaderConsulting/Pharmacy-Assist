using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmLogon : Form
    {
        private bool _PassThrough = false;
        private bool _FormClosingProgrammatically = false;

        public frmLogon()
        {
            InitializeComponent();
        }

        private void frmLogon_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            // If running in the development environment, assume connection to developer database
            if (Debugger.IsAttached || ModifierKeys == Keys.Control)
            {
                Global.UseDeveloperSettings = true;
                Global.SqlConnectionString = Properties.Settings.Default.DevDataConnection;
                this.picDatabase.Image = Properties.Resources.realvista_networking_net_admin_32;
            }
            
            this.Show();
            this.Refresh();

            DoLogon();
        }

        private void DoLogon()
        {
            ResetForm();

            // For now, disable Remember me
            // It should read from the database and act accordingly
            // ===============================================================================

            //chkRememberMe.Checked = Properties.Settings.Default.RememberUsername;

            //if (chkRememberMe.Checked)
            //{
            //    txtUsername.Text = Properties.Settings.Default.LastUsername;
            //}

            //if (chkRememberMe.Checked && txtUsername.Text.Trim().Length > 0)
            //{
            //    txtUsername.Text = Properties.Settings.Default.LastUsername.Trim();

            //    _PassThrough = true;

            //    this.Refresh();

            //    DoAuthorisationProcess();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _FormClosingProgrammatically = true;
            Environment.Exit(0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DoAuthorisationProcess();
        }

        internal void ResetForm()
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            chkRememberMe.Enabled = true;
            btnOK.Enabled = false;
            btnCancel.Enabled = true;

            txtUsername.Focus();
            txtUsername.SelectAll();

            this.Refresh();
        }

        private void DoAuthorisationProcess()
        {
            string Query = "";
            DataSet Data = null;
            bool CorrectPasswordOrPassthrough = _PassThrough;

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            chkRememberMe.Enabled = false;
            btnOK.Enabled = false;
            btnCancel.Enabled = false;

            // Get user details from SQL
            Query = "SELECT ID, Username, ISNULL(FirstName,'') AS Firstname, ISNULL(LastName,'') AS Lastname, Firstname + ' ' + Lastname AS Fullname, Password, Enabled, FirstLogon, MustResetPassword, StoreID, StartPageID FROM UserAccount WHERE Username like '" + txtUsername.Text.Trim() + "'";
            Cursor.Current = Cursors.WaitCursor;
            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            if (Data.Tables[0].Rows.Count > 0)
            {
                //if (Data.Tables[0].Rows.Count > 0)
                //{
                CorrectPasswordOrPassthrough = (Data.Tables[0].Rows[0]["Password"].ToString() == txtPassword.Text) || _PassThrough;

                if (CorrectPasswordOrPassthrough)
                {
                    // Valid Username and Password -OR- Passthrough from RememberMe
                    if ((bool)Data.Tables[0].Rows[0]["Enabled"])
                    {
                        Global.UserID = (int)Data.Tables[0].Rows[0]["ID"];
                        Global.UserStoreID = (int)Data.Tables[0].Rows[0]["StoreID"];
                        Global.UserStartPageID = (int)Data.Tables[0].Rows[0]["StartPageID"];
                        Global.UserFullname = (string)Data.Tables[0].Rows[0]["Fullname"];

                        // Now to check if the User has logged on before
                        if ((bool)Data.Tables[0].Rows[0]["FirstLogon"])
                        {
                            // This is the User's first logon.  Present to them their stored details, allowing to change them if they wish
                            frmUserDetails UserDetailsForm = new frmUserDetails(Global.UserID, "Please update the following details if necessary", false);

                            UserDetailsForm.ShowDialog();
                        }

                        // Now to check if the User has to change their password
                        if ((bool)Data.Tables[0].Rows[0]["MustResetPassword"])
                        {
                            frmChangePassword ChangePasswordForm = new frmChangePassword("You are required to change your password.");

                            ChangePasswordForm.ShowDialog();
                        }

                        Query = string.Format("SELECT DISTINCT p.Name, u.Username from dbo.permission p left join rolepermission rp on rp.permissionid = p.id left join role r on r.id = rp.roleid left join useraccountrole ur on ur.roleid = r.id left join useraccount u on u.id = ur.useraccountid where u.username like '{0}'", txtUsername.Text.Trim());

                        Cursor.Current = Cursors.WaitCursor;
                        Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                        Cursor.Current = Cursors.Default;

                        // Save the username
                        Global.Username = Data.Tables[0].Rows[0][1].ToString();

                        // Store the list of permissions for this user
                        foreach (DataRow Row in Data.Tables[0].Rows)
                        {
                            string Permission = Row[0].ToString();

                            // If we don't have already have this permission, add it to the list
                            if (!Global.Permissions.Contains(Permission)) Global.Permissions.Add(Permission);
                        }

                        Properties.Settings.Default.RememberUsername = chkRememberMe.Checked;

                        if (chkRememberMe.Checked)
                        {
                            Properties.Settings.Default.LastUsername = Global.Username;
                        }

                        Properties.Settings.Default.Save();

                        // Update the LastLoggedOnTimeStamp and FirstLogon for this user
                        Cursor.Current = Cursors.WaitCursor;
                        Query = "UPDATE UserAccount SET LastLogonTimestamp = GETDATE(), FirstLogon = 0 WHERE ID = " + Global.UserID;
                        Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);
                        Cursor.Current = Cursors.Default;

                        _FormClosingProgrammatically = true;
                        this.Close();

                    }
                    else
                    {
                        // Account not enabled
                        lblProblem.Text = "Your account is disabled.  Contact your manager.";
                        ResetForm();
                    }
                }
                else
                {
                    // Incorrect Password
                    lblProblem.Text = "Incorrect Username or Password";
                    ResetForm();
                }
                //}
            }
            else
            {
                // Incorrect Username
                lblProblem.Text = "Incorrect Username or Password";
                ResetForm();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtUsername.Text.Trim().Length > 0;

            lblProblem.Text = "";
        }

        private void frmLogon_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
            
            if (!_FormClosingProgrammatically)
            {
                Environment.Exit(0);
            }
        }

        private void lblProblem_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            { 
                e.SuppressKeyPress = true;
                e.Handled = true;
                DoAuthorisationProcess();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                DoAuthorisationProcess();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void frmLogon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
            }
        }
    }
}
