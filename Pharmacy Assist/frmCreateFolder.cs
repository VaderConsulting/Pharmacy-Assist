using Core.FileTransfer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace PharmacyAssist
{
    public partial class frmCreateFolder : Form
    {
        public Document ThisFTPEntry { get; set; }
        
        public frmCreateFolder()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Core.FileTransfer.FTP FTP = new FTP();

            FTP.RemoteUsername = Properties.Settings.Default.FTPUsername;
            FTP.RemotePassword = Properties.Settings.Default.FTPPassword;
            FTP.RemoteHost = Properties.Settings.Default.FTPHost;

            // TODO:  Check for invalid filename characters

            FTP.CreateRemoteDirectory(lblPathValue.Text + "/" + txtName.Text.Trim());

            ThisFTPEntry.Path = lblPathValue.Text;
            ThisFTPEntry.FileName = txtName.Text.Trim();

            FTP.Dispose();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void frmCreateFolder_Load(object sender, EventArgs e)
        {
            if (ThisFTPEntry.IsFolder)
            {
                lblPathValue.Text = ThisFTPEntry.Path + "/" + ThisFTPEntry.FileName;
            }
            else
            {
                lblPathValue.Text = ThisFTPEntry.Path;
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtName.Text.Trim().Length > 0;
        }
    }
}
