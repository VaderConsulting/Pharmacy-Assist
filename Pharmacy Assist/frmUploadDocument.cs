using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmUploadDocument : Form
    {
        public string DocumentPath { get; set; }

        public frmUploadDocument()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog Browse = new OpenFileDialog();

            using (Browse)
            {
                Browse.AutoUpgradeEnabled = true;
                Browse.Filter = "Word files (*.doc, *.docx)|*.doc;*.docx;|Excel files (*.xls, *.xlsx)|*.xls;*.xlsx|PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";

                Browse.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                DialogResult Result = Browse.ShowDialog();

                if (Result == System.Windows.Forms.DialogResult.OK)
                {
                    txtFilename.Text = Browse.FileName;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string SourceFilename = "";
            string SourceFolder = "";
            string Extension = "";

            if (txtFilename.Text.Trim() != "")
            {
                SourceFolder = System.IO.Path.GetDirectoryName(txtFilename.Text.Trim());
                SourceFilename = System.IO.Path.GetFileNameWithoutExtension(txtFilename.Text.Trim());
                Extension = System.IO.Path.GetExtension(txtFilename.Text.Trim());
                StartUpload(SourceFolder, SourceFilename, Extension, lblPathValue.Text);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void StartUpload(string LocalFolderName, string FileName, string Extension, string RemoteFolderName)
        {
            string RemoteFilename = FileName;
            List<DatabaseColumn> Columns = new List<DatabaseColumn>();

            DatabaseColumn DbColumn = new DatabaseColumn();

            UploadFile(LocalFolderName, FileName + Extension, RemoteFolderName, RemoteFilename + Extension);

            Global.Audit("Document upload", "Document", "", 0, Global.Username, "", "", Application.ProductName, false);

        }

        private bool UploadFile(string LocalFoldername, string LocalFilename, string DestinationFoldername, string DestinationFilename)
        {
            bool Result = false;

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Properties.Settings.Default.FTPHost + "/" + DestinationFoldername + "/" + DestinationFilename);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(Properties.Settings.Default.FTPUsername, Properties.Settings.Default.FTPPassword);

            // Copy the contents of the file to the request stream.
            // http://msdn.microsoft.com/en-us/library/ms229715(v=vs.90).aspx
            // AND
            // http://stackoverflow.com/questions/221925/creating-a-byte-array-from-a-stream

            StreamReader sourceStream = new StreamReader(LocalFoldername + @"\" + LocalFilename);
            byte[] fileContents = Global.ReadFully(sourceStream.BaseStream);
            sourceStream.Close();

            FtpWebResponse response = null;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                response = (FtpWebResponse)request.GetResponse();

                Result = true;
            }
            catch (Exception ex)
            {
                Global.Common.Logging.WriteErrorEvent(String.Format("Create Document form (UploadFile) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                Result = false;
            }

            response.Close();

            Cursor.Current = Cursors.Default;

            return Result;
        }

        private void frmUploadDocument_Load(object sender, EventArgs e)
        {
            lblPathValue.Text = DocumentPath;
        }

        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtFilename.Text.Trim().Length > 0;
        }
    }
}
