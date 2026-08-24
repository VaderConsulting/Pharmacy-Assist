using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using PharmacyAssist;

namespace Pharmacy_Docs
{
    public partial class frmDocs : Form
    {
        private TreeNode _SelectedTreeNode = null;
        
        public frmDocs()
        {
            InitializeComponent();
        }

        private void frmDocs_Load(object sender, EventArgs e)
        {
            Global.SqlConnectionString = Properties.Settings.Default.DataConnectionString;

            LoadDocumentList();
        }

        private void LoadDocumentList()
        {
            List<Document> Documents = Global.GetAllDocuments(false);
           
            TreeNode root = tvwFolders.Nodes.Add("root","Server Root");
            TreeNode node = root;

            foreach (Document document in Documents)
            {
                node = root;

                string PathAndFilename = document.Path;

                foreach (string pathBits in PathAndFilename.Split('/'))
                {
                    if (pathBits.Length > 0)
                        node = AddNode(node, pathBits);
                }
            }

        }

        private TreeNode AddNode(TreeNode node, string key)
        {
            if (node.Nodes.ContainsKey(key))
            {
                return node.Nodes[key];
            }
            else
            {
                return node.Nodes.Add(key, key);

            }
        }

        private void tvwFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClickTreeNode();
        }

        private void ClickTreeNode()
        {
            if (_SelectedTreeNode != null)
            {
                lblStatus.Text = "Loading folder list...";
                this.Refresh();
                Console.WriteLine("ClickTreeNode()");
                if (_SelectedTreeNode.Tag != null) _SelectedFTPEntry = (FTPEntry)_SelectedTreeNode.Tag;
                btnAddFolder.Enabled = Global.Permissions.Contains("Create Document Folder");

                List<FTPEntry> Entries = Global.GetFTPDirectoryEntries(true, _SelectedFTPEntry.Path + "/" + _SelectedFTPEntry.Filename, Global.FTPEntrySelection.Folder);

                foreach (FTPEntry Entry in Entries)
                {
                    AddNodeToTreeview(_SelectedTreeNode, Entry.Filename, Entry.Filename, 1, 1);
                }

                DoSearch(txtSearch.Text);

                lblStatus.Text = "Idle";
            }
        }
    }
}
