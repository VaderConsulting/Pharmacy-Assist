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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(string Message)
        {
            InitializeComponent();

            lblInfo.Text = Message;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string Query = "";

            try
            {
                // Save the updated details
                Cursor.Current = Cursors.WaitCursor;

                DataSet Data = Core.SQL.Functions.Execute("SELECT ISNULL(Password,'') FROM UserAccount WHERE ID = " + Global.UserID,Global.SqlConnectionString);

                Global.Audit("Password change", "UserAccount", "Password", Global.UserID, Global.Username.Replace("'", "''"), Convert.ToString(Data.Tables[0].Rows[0][0]).Replace("'", "''"), txtPassword.Text.Replace("'", "''"), Application.ProductName, false);

                Query = "UPDATE UserAccount SET Password = '" + txtPassword.Text.Replace("'", "''") + "', MustResetPassword = 0 WHERE ID = " + Global.UserID;
                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);
                Cursor.Current = Cursors.Default;

                this.Close();
            }
            catch 
            {
                errorProvider.SetError(btnOK, "Could not save new password.");
            }
        }

        private void txtPasswordConfirmation_TextChanged(object sender, EventArgs e)
        {
            if (txtPasswordConfirmation.Text != txtPassword.Text)
            {
                errorProvider.SetError(txtPasswordConfirmation, "Please ensure the passwords match");
                btnOK.Enabled = false;
            }
            else
            {
                errorProvider.SetError(txtPasswordConfirmation, "");
                btnOK.Enabled = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPasswordConfirmation.Text != txtPassword.Text)
            {
                //errorProvider.SetError(txtPassword, "Please ensure the passwords match");
                btnOK.Enabled = false;
            }
            else
            {
                //errorProvider.SetError(txtPassword, "");
                btnOK.Enabled = true;
            }
        }

        private void frmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }
    }
}
