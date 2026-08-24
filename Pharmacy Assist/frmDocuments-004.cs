using Core.FileTransfer;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmDocuments : Form
    {
        private delegate void TreeviewUpdater(TreeNode Node, string Key, string Text, int ImageIndex, int SelectedImageIndex);

        private MouseButtons _Buttons = System.Windows.Forms.MouseButtons.None;
        private List<Document> _Documents = new List<Document>();

        //public string ConditionName { get; set; }
        //public string Ingredientname { get; set; }

        private Document _SelectedDocument = null;
        private Document _SelectedDocumentEntry = null;
        private TreeNode _SelectedTreeNode = null;
        private bool ManageMode = false;
        private TreeviewUpdater UpdateDelegate;

        public frmDocuments()
        {
            InitializeComponent();
        }

        private void AddDocument()
        {
            frmUploadDocument UploadDocumentForm = new frmUploadDocument();

            UploadDocumentForm.DocumentPath = txtPath.Text;

            DialogResult Result = UploadDocumentForm.ShowDialog();

            if (Result == System.Windows.Forms.DialogResult.OK)
            {
                DoStartup();
            }

        }

        private void AddFolder()
        {
            frmCreateFolder CreateFolderForm = new frmCreateFolder();

            CreateFolderForm.ThisFTPEntry = _SelectedDocumentEntry;

            DialogResult Result = CreateFolderForm.ShowDialog();

            if (Result == System.Windows.Forms.DialogResult.OK)
            {
                DoStartup();
            }
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        //private TreeNode AddNode(TreeNode node, string key)
        //{
        //    if (node.Nodes.ContainsKey(key))
        //    {
        //        return node.Nodes[key];
        //    }
        //    else
        //    {
        //        return node.Nodes.Add(key, key, 2, 2);

        //    }
        //}

        private TreeNode AddNode(string ParentKey, string Key, int ImageIndex)
        {
            TreeNode ThisNode = null;
            TreeNode[] Nodes = null;

            // Remove trailing /
            if (ParentKey.EndsWith("/")) ParentKey = ParentKey.Substring(0,ParentKey.Length-1);

            // Find this node (if it exists)
            //Console.WriteLine("Looking for " + ParentKey + " / " + Key);
            Nodes = tvwFolders.Nodes.Find(ParentKey + "/" + Key, true);

            Document DocumentEntry = new Document();
            DocumentEntry.IsFolder = true;
            DocumentEntry.Path = "/" + ParentKey + "/" + Key;

            if (Nodes.Length > 0)
            {
                ThisNode = Nodes[0];
                //Console.WriteLine("Found node (" + Key + ")");
            }
            else
            {
                if (ParentKey == "")
                {
                    ThisNode = tvwFolders.Nodes.Add(Key, Key, ImageIndex, ImageIndex);
                    ThisNode.Tag = DocumentEntry;

                    //Console.WriteLine("Added node to root (" + Key + ")");
                }
                else
                {
                    // Find the parentnode with the ParentKey                   
                    Nodes = tvwFolders.Nodes.Find(ParentKey, true);

                    if (Nodes.Length > 0)
                    {
                        // Key found - add the new node to the Parent node
                        if (Key != ParentKey)  // Kludge to prevent document/documents from being created
                        {
                            ThisNode = Nodes[0].Nodes.Add(ParentKey + "/" + Key, Key, ImageIndex, ImageIndex);
                            ThisNode.Tag = DocumentEntry;
                            //Console.WriteLine("Parent found (" + ParentKey + ") - added '" + Key + "' with a Key of '" + ParentKey + "/" + Key + "'");
                        }
                    }
                    else
                    {
                        // Key not found - add the new node to the root
                        //TreeNode Root = tvwFolders.Nodes[0];
                        ThisNode = tvwFolders.Nodes.Add(ParentKey, Key, ImageIndex, ImageIndex);
                        ThisNode.Tag = DocumentEntry;
                        //Console.WriteLine("Parent not found (" + ParentKey + ") - added " + Key + "' with a Key of '" + ParentKey + "'");
                    }
                }
            }

            return ThisNode;
        }

        private void AddNodeToTreeview(string Path, int ImageIndex)
        {
            //string Path = "";
            string NodeName = "";
            string Key = "";
            string[] Parts = { };
            TreeNode ThisNode = null;
            string ParentKey = "";

            // remove leading /
            if (Path.StartsWith("/")) Path = Path.Substring(1);

            // Extract out the info we need
            if (Path.Contains("/"))
            {
                NodeName = Path.Substring(Path.LastIndexOf("/") + 1);
                //Path = Path.Substring(0, Path.LastIndexOf("/") + 1);
                if (Path.EndsWith("/")) Path = Path.Substring(0, Path.Length - 1);
            }
            else
            {
                NodeName = Path;
                Path = "";
            }

            Key = Path;

            Parts = Path.Split(Convert.ToChar("/"));

            for (int i = 0; i < Parts.Length ; i++)
            {
                if (i == 0)
                {
                    ThisNode = AddNode(Parts[0], Parts[0], ImageIndex);
                    //Console.WriteLine(string.Format("Added Node.  Path: {0} NodeName: {1}", "root", Parts[0]));
                }
                else
                {
                    ParentKey += Parts[i - 1] + "/";

                    //if (ParentKey.EndsWith("/")) ParentKey = ParentKey.Substring(0, ParentKey.Length - 1);
                    ThisNode = AddNode(ParentKey, Parts[i], ImageIndex);
                }
            }
        }

        private void AddNodeToTreeview(TreeNode ParentNode, string Key, string Text, int ImageIndex, int SelectedImageIndex)
        {
            if (tvwFolders.InvokeRequired)
            {
                this.Invoke(UpdateDelegate, ParentNode, Key, Text, ImageIndex, SelectedImageIndex);
            }
            else
            {
                Document NewDocumentEntry = new Document();
                TreeNode ChildNode = new TreeNode();
                ChildNode.ImageKey = Key;
                ChildNode.Text = Text;
                ChildNode.ImageIndex = ImageIndex;
                ChildNode.SelectedImageIndex = SelectedImageIndex;
                ChildNode.Tag = NewDocumentEntry;
                ChildNode.Name = NewDocumentEntry.Path + "/" + NewDocumentEntry.FileName;

                if (ParentNode == null)
                {
                    NewDocumentEntry.Path = "";
                    NewDocumentEntry.FileName = "";
                    NewDocumentEntry.IsFolder = true;

                    TreeNode NewNode = new TreeNode();
                    NewNode.ImageKey = Key;
                    NewNode.Text = Text;
                    NewNode.ImageIndex = ImageIndex;
                    NewNode.SelectedImageIndex = SelectedImageIndex;
                    NewNode.Tag = NewDocumentEntry;
                    NewNode.Name = NewDocumentEntry.Path + "/" + NewDocumentEntry.FileName;

                    tvwFolders.Nodes.Add(NewNode);

                    ParentNode = tvwFolders.Nodes[0];
                }
                else
                {
                    Document ParentEntry = (Document)ParentNode.Tag;
                    if (ParentEntry.FileName != "")
                    {
                        NewDocumentEntry.Path = ParentEntry.Path + "/" + ParentEntry.FileName;
                    }
                    else
                    {
                        NewDocumentEntry.Path = ParentEntry.Path;
                    }

                    NewDocumentEntry.FileName = Key;
                    NewDocumentEntry.IsFolder = true;

                    TreeNode NewNode = new TreeNode();
                    NewNode.ImageKey = Key;
                    NewNode.Text = Text;
                    NewNode.ImageIndex = ImageIndex;
                    NewNode.SelectedImageIndex = SelectedImageIndex;
                    NewNode.Tag = NewDocumentEntry;
                    NewNode.Name = NewDocumentEntry.Path + "/" + NewDocumentEntry.FileName;

                    if (!ParentNode.Nodes.ContainsKey(NewDocumentEntry.Path + "/" + NewDocumentEntry.FileName)) ParentNode.Nodes.Add(NewNode);

                    ChildNode = ParentNode.Nodes[ParentNode.Nodes.Count - 1];
                }

                Cursor.Current = Cursors.AppStarting;
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDocument();
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            AddDocument();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Search";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteDocument_Click(object sender, EventArgs e)
        {
            DeleteDocument();
        }

        private void btnDeleteFolder_Click(object sender, EventArgs e)
        {
            DeleteFolder();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            GetDocumentInformation();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageMode = true;

            DoStartup();
        }

        //private void GetDocumentList()
        //{
        //    DataSet Data = null;

        //    lstDocuments.Items.Clear();

        //    string Query = "select id, name from brand";

        //    Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

        //    foreach (DataRow Row in Data.Tables[0].Rows)
        //    {
        //        ListItem Item = new ListItem((int)Row[0], (string)Row[1]);
        //        if (lstItems.Items.Contains(Item))
        //            lblDuplicates.Visible = true;
        //        lstItems.Items.Add(Item);
        //    }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoSearch(txtSearch.Text);
        }

        private void btnViewDocument_Click(object sender, EventArgs e)
        {
            GetDocument();
        }

        private void ClickTreeNode()
        {
            if (_SelectedTreeNode != null)
            {
                if (_SelectedTreeNode.Tag != null)
                {
                    _SelectedDocumentEntry = (Document)_SelectedTreeNode.Tag;
                    txtPath.Text = _SelectedDocumentEntry.Path;
                }

                btnAddFolder.Enabled = ManageMode && Global.Permissions.Contains("Create Document Folder");
                btnInfo.Enabled = false;

                // ManageMode (FTP) needs the folder list to be built
                if (ManageMode)
                {
                    lblStatus.Text = "Loading folder list...";
                    this.Refresh();

                    List<Document> Documents = Global.GetDocumentsFromPath(true, _SelectedDocumentEntry.Path, Global.FileOrFolderSelection.Folder);

                    foreach (Document DocumentEntry in Documents)
                    {
                        if (DocumentEntry.IsFolder)
                        {
                            AddNodeToTreeview(DocumentEntry.Path, 1);
                        }
                    }
                }

                DoSearch(txtSearch.Text);

                lblStatus.Text = "Idle";
            }
        }

        private void DeleteDocument()
        {
            int DocumentID = 0;

            btnDeleteDocument.Enabled = false;

            if (_SelectedDocument != null)
            {
                DocumentID = _SelectedDocument.ID;

                Core.SQL.Functions.ExecuteNonQuery("DELETE FROM Document WHERE ID = " + DocumentID, Global.SqlConnectionString);
                Core.SQL.Functions.ExecuteNonQuery("DELETE FROM ConditionDocument WHERE DocumentID = " + DocumentID, Global.SqlConnectionString);
                Core.SQL.Functions.ExecuteNonQuery("DELETE FROM TaskDocument WHERE DocumentID = " + DocumentID, Global.SqlConnectionString);
                Core.SQL.Functions.ExecuteNonQuery("DELETE FROM EventDocument WHERE DocumentID = " + DocumentID, Global.SqlConnectionString);

                // Refresh document list
                ClickTreeNode();
            }
        }

        private void DeleteFolder()
        {
            // Refresh the folder to ensure we know the latest info before we attempt to delete it
        }

        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFolder();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDocument();
        }

        private void DoSearch(string SearchTerm)
        {
            if (txtSearch.Text != "Search")
            {
                RefreshFileList(SearchTerm);
            }
            else
            {
                RefreshFileList("");
            }
        }

        private void DoStartup()
        {
            _SelectedDocument = null;
            _SelectedDocumentEntry = null;
            tvwFolders.Nodes.Clear();
            lvwDocuments.Clear();
            btnAddDocument.Enabled = false;
            btnAddFolder.Enabled = false;
            btnDeleteDocument.Enabled = false;
            btnDeleteFolder.Enabled = false;

            lvwDocuments.Columns.Add("Filename", 250);
            lvwDocuments.Columns.Add("Name", 150);
            //lvwDocuments.Columns.Add("Path", 100);  // displayed in txtPath, so why add it here??
            lvwDocuments.Columns.Add("Public", 50);
            lvwDocuments.Columns.Add("Free Service", 80);
            lvwDocuments.Columns.Add("Keywords", 100);

            txtPath.Text = "/documents";

            GetFolderlist();

            tvwFolders.Nodes[0].Remove();  // This is an extra Documents node

            btnAddDocument.Enabled = ManageMode && Global.Permissions.Contains("Create Document");

            btnManage.Enabled = !ManageMode &&
                                (Global.Permissions.Contains("Create Document") || Global.Permissions.Contains("Delete Document") ||
                                Global.Permissions.Contains("Create Document Folder") || Global.Permissions.Contains("Delete Document Folder") || Global.Permissions.Contains("Write Document Folder"));

            this.Show();
            this.Refresh();
        }

        private void frmDocuments_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void frmDocuments_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_general_book_256;
            this.Icon = Properties.Resources.supervista_general_book;
            gpTitle.GradientStartColor = Global.Theme[5];

            DoStartup();

            // When editing the folder names is to be allowed, uncomment the following line
            //tvwFolders.LabelEdit = Global.Permissions.Contains("Write Document Folder");

        }

        private void GetDocument()
        {
            if (lvwDocuments.SelectedItems.Count > 0)
            {
                Document Doc = new Document();

                Doc.FileName = _SelectedDocumentEntry.FileName;
                Doc.Path = _SelectedDocumentEntry.Path;

                //Doc.FileName = _SelectedDocument.FileName;
                //Doc.Path = _SelectedDocument.Path;

                lblStatus.Text = "Opening Document";
                Application.DoEvents();

                OpenDocument(Doc);

                lblStatus.Text = "Idle";
            }
        }

        private void GetDocumentInformation()
        {
            frmDocumentInfo DocumentInfo = new frmDocumentInfo();

            DocumentInfo.ThisDocument = _SelectedDocument;
            DocumentInfo.ThisFile = _SelectedDocumentEntry;

            DialogResult Result = DocumentInfo.ShowDialog();

            if (Result == System.Windows.Forms.DialogResult.OK)
            {
                _SelectedDocument = DocumentInfo.ThisDocument;
                ListViewItem SelectedListViewDocument = lvwDocuments.SelectedItems[0];

                SelectedListViewDocument.Text = _SelectedDocument.FileName;
                SelectedListViewDocument.SubItems[1].Text = _SelectedDocument.Name;
                if (SelectedListViewDocument.SubItems.Count > 2)
                {
                    SelectedListViewDocument.SubItems[2].Text = _SelectedDocument.Public.ToString();
                }
                else
                {
                    SelectedListViewDocument.SubItems.Add(_SelectedDocument.Public.ToString());
                }
                if (SelectedListViewDocument.SubItems.Count > 3)
                {
                    SelectedListViewDocument.SubItems[3].Text = _SelectedDocument.FreeService.ToString();
                }
                else
                {
                    SelectedListViewDocument.SubItems.Add(_SelectedDocument.FreeService.ToString());
                }
                if (SelectedListViewDocument.SubItems.Count > 4)
                {
                    SelectedListViewDocument.SubItems[4].Text = _SelectedDocument.Keywords;
                }
                else
                {
                    SelectedListViewDocument.SubItems.Add(_SelectedDocument.Keywords);
                }

            }
        }

        //private void GetFileList(TreeNode ParentNode, string Path, bool Recursive, PharmacyAssist.Global.FileOrFolderSelection Selection)
        //{
        //    string PathFromRoot = "";

        //    tvwFolders.BeginUpdate();

        //    if (ParentNode != null)
        //    {
        //        Document ParentEntry = (Document)ParentNode.Tag;
        //        if (ParentEntry.FileName != "")
        //        {
        //            PathFromRoot = ParentEntry.Path + "/" + ParentEntry.FileName + "/";
        //        }
        //        else
        //        {
        //            PathFromRoot = ParentEntry.Path + "/";
        //        }

        //    }

        //    // Get list of folders on FTP server
        //    List<Document> Entries = null;

        //    if (ManageMode)
        //    {
        //        Entries = Global.GetDocumentsFromPath(true, PathFromRoot + Path, Selection);
        //    }
        //    else
        //    {
        //        Entries = Global.GetDocumentsFromDatabase(PathFromRoot + Path, Selection);
        //    }

        //    foreach (Document Entry in Entries)
        //    {
        //        TreeNode Node = new TreeNode();

        //        Node.Text = Entry.FileName;
        //        Node.Tag = Entry;

        //        if (Entry.IsFolder)
        //        {
        //            Node.ImageIndex = 1;
        //            Node.SelectedImageIndex = 1;
        //        }
        //        else
        //        {
        //            Node.ImageIndex = 2;
        //            Node.SelectedImageIndex = 2;
        //        }

        //        ParentNode.Nodes.Add(Node);

        //        if (Recursive && Entry.IsFolder && (Selection == Global.FileOrFolderSelection.Folder))
        //        {
        //            GetFileList(Node, Entry.Path + "/" + Entry.FileName, Recursive, Selection);
        //        }
        //    }

        //    tvwFolders.EndUpdate();
        //}

        private void GetFolderlist()
        {
            lblStatus.Text = "Loading folder list...";

            tvwFolders.Nodes.Clear();
            _Documents.Clear();

            Cursor.Current = Cursors.WaitCursor;

            AddNodeToTreeview(null, "root", "Server Root", 0, 0);
            _SelectedDocumentEntry = new Document();
            _SelectedDocumentEntry.Path = "/documents";
            _SelectedDocumentEntry.IsFolder = true;

            tvwFolders.Nodes[0].Tag = _SelectedDocumentEntry;

            if (ManageMode)
            {
                _Documents = Global.GetAllDocuments(false, "", Global.FileOrFolderSelection.Folder);
                List <Document> Documents = Global.GetDocumentsFromPath(true, "/documents", Global.FileOrFolderSelection.Folder);

                foreach (Document DocumentEntry in Documents)
                {
                    if (DocumentEntry.IsFolder)
                    {
                        AddNodeToTreeview(DocumentEntry.Path, 1);
                    }
                }
            }
            else
            {
                _Documents = Global.GetAllDocuments(false, "", Global.FileOrFolderSelection.Folder);

                foreach (Document DocumentEntry in _Documents)
                {
                    if (DocumentEntry.IsFolder)
                    {
                        AddNodeToTreeview(DocumentEntry.Path, 1);
                    }
                }
            }

            lblStatus.Text = "Idle";

            Cursor.Current = Cursors.Default;
        }

        private void lvwDocuments_Leave(object sender, EventArgs e)
        {
            btnViewDocument.Enabled = false;
        }

        private void lvwDocuments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_SelectedDocument != null) GetDocument();
        }

        private void lvwDocuments_MouseUp(object sender, MouseEventArgs e)
        {
            // This event occurs if you click anywhere in the control

            _Buttons = e.Button;

            if (_Buttons == System.Windows.Forms.MouseButtons.Right)
            {
                if (lvwDocuments.SelectedItems.Count > 0)
                {
                    openToolStripMenuItem.Enabled = true;
                    propertiesToolStripMenuItem.Enabled = true;
                }
                else
                {
                    openToolStripMenuItem.Enabled = false;
                    propertiesToolStripMenuItem.Enabled = false;
                }

                cmsRightClickDocumentList.Show(lvwDocuments, e.Location);
            }
        }

        private void lvwDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "Retrieving details for the selected Document";
            lblStatus.Refresh();

            if (lvwDocuments.SelectedItems.Count > 0)
            {
                _SelectedDocumentEntry = (Document)lvwDocuments.SelectedItems[0].Tag;

                txtPath.Text = _SelectedDocumentEntry.Path;

                btnViewDocument.Enabled = true;
                btnInfo.Enabled = true;
                //btnDeleteDocument.Enabled = ManageMode && Global.Permissions.Contains("Delete Document");
                

                // Get corresponding Document information
                var SelectedDocument = (from Document d in _Documents
                                        where d.FileName.ToLower() == _SelectedDocumentEntry.FileName.ToLower() && d.Path.ToLower() == _SelectedDocumentEntry.Path.ToLower()
                                        select d).FirstOrDefault();

                if (SelectedDocument != null)
                {
                    _SelectedDocument = (Document)SelectedDocument;

                    btnDeleteDocument.Enabled = Global.Permissions.Contains("Delete Document");

                    lblStatus.Text = "Idle";
                }
                else
                {
                    // No corresponding database entry
                    _SelectedDocument = null;
                    lblStatus.Text = "No corresponding database entry for the selected Document";
                    lblStatus.Refresh();

                    btnDeleteDocument.Enabled = false;
                }
            }
            else
            {
                _SelectedDocument = null;
                _SelectedDocumentEntry = null;

                btnViewDocument.Enabled = false;
                btnInfo.Enabled = false;
                btnDeleteDocument.Enabled = false;

                lblStatus.Text = "Idle";
            }

            //lblStatus.Text = "Idle";
        }

        private void OpenDocument(Document Doc)
        {
            // Check if the document is already present
            string LocalFolder = Application.UserAppDataPath;
            string Filename = Doc.FileName;
            string LocalFilename = System.IO.Path.Combine(LocalFolder, Filename);
            bool FilePresent = false; //  File.Exists(LocalFilename);  // Updated 13/11/2013

            Cursor.Current = Cursors.WaitCursor;

            if (!FilePresent)
            {
                FTP Ftp = new FTP();
                Ftp.UseCompression = false;

                Ftp.RemoteHost = Properties.Settings.Default.FTPHost;
                Ftp.RemoteUsername = Properties.Settings.Default.FTPUsername;
                Ftp.RemotePassword = Properties.Settings.Default.FTPPassword;

                try
                {
                    Ftp.Login();
                    Ftp.Download(Doc.Path + "/" + Filename, LocalFilename);

                }
                catch (Exception ex)
                {
                    Global.Common.Logging.WriteErrorEvent(String.Format("Linked Documents form (OpenDocument) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                }
            }

            // Downloaded or not, we can now open it
            Global.OpenDocument(LocalFilename);

            Cursor.Current = Cursors.Default;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDocument();
        }

        //private void PerformNHSConditionSearch(string Term)
        //{
        //    ProcessStartInfo ProcessInfo = new ProcessStartInfo();

        //    ProcessInfo.FileName = "http://www.nhs.uk/medicine-guides/pages/MedicineForCondition.aspx?condition=" + Term;
        //    ProcessInfo.UseShellExecute = true;

        //    System.Diagnostics.Process.Start(ProcessInfo);
        //}

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDocumentInformation();
        }

        private void radViewDetails_CheckedChanged(object sender, EventArgs e)
        {
            lvwDocuments.View = View.Details;
        }

        private void radViewLarge_CheckedChanged(object sender, EventArgs e)
        {
            lvwDocuments.View = View.LargeIcon;
        }

        private void radViewList_CheckedChanged(object sender, EventArgs e)
        {
            lvwDocuments.View = View.List;
        }

        private void radViewSmall_CheckedChanged(object sender, EventArgs e)
        {
            lvwDocuments.View = View.SmallIcon;
        }

        private void RefreshFileList(string SearchTerm)
        {
            List<Document> Entries = null;

            Cursor.Current = Cursors.WaitCursor;

            if (_SelectedTreeNode != null)
            {
                //int ImageIndex = 0;    
                lblStatus.Text = "Loading file list...";
                    this.Refresh();
                    lvwDocuments.Items.Clear();

                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();

                    if (ManageMode) // Get list of documents from FTP server
                    {
                        Entries = Global.GetDocumentsFromPath(true, "/" + _SelectedTreeNode.Name, Global.FileOrFolderSelection.File);
                    }
                    else            // Get list of documents from database
                    {
                        Entries = Global.GetDocumentsFromDatabase("/" + _SelectedTreeNode.Name, Global.FileOrFolderSelection.File);
                    }

                    Cursor.Current = Cursors.Default;

                    if (SearchTerm != "") lblStatus.Text = "Searching Documents...";
                    this.Refresh();

                    lvwDocuments.BeginUpdate();

                    foreach (Document ThisDocument in Entries)
                    {
                        ListViewItem ListViewDocument = new ListViewItem();
                        bool AddDocument = false;

                        ListViewDocument.Text = ThisDocument.FileName;
                        ListViewDocument.ImageIndex = 2; // ImageIndex
                        ListViewDocument.Tag = ThisDocument;
                        
                        // Get corresponding Document information
                        var SelectedDocument = (from Document d in _Documents
                                                where (d.FileName.ToLower() == ThisDocument.FileName.ToLower() && d.Path.ToLower() == ThisDocument.Path.ToLower())
                                                select d).FirstOrDefault();

                        if (SearchTerm != "" && SelectedDocument != null)
                        {
                            lblStatus.Text = "Looking through keywords: " + SelectedDocument.Keywords;
                            this.Refresh();

                            // Perform search on Database info
                            if (
                                SelectedDocument.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                                SelectedDocument.Keywords.ToLower().Contains(SearchTerm.ToLower())
                               )
                            {
                                AddDocument = true;
                            }

                            //var MatchingConditions = from c in SelectedDocument.Conditions where c.Name.ToLower().Contains(SearchTerm.ToLower()) select c;

                            //if (MatchingConditions.Count() > 0)
                            //{
                            //    AddDocument = true;
                            //}
                        }

                        if (SearchTerm != "")
                        {
                            if (ThisDocument.FileName.ToLower().Contains(SearchTerm.ToLower()))
                            {
                                AddDocument = true;
                            }
                        }
                        else
                        {
                            AddDocument = true;
                        }

                        if (AddDocument)
                        {
                            //ListViewDocument.SubItems.Add(SelectedDocument.Name);
                            if (SelectedDocument != null)
                            {
                                ListViewDocument.SubItems.Add(SelectedDocument.Name);
                            }
                            else
                            {
                                ListViewDocument.SubItems.Add("");
                            }

                            if (SelectedDocument != null)
                            {
                                ListViewDocument.SubItems.Add(SelectedDocument.Public.ToString());
                                ListViewDocument.SubItems.Add(SelectedDocument.FreeService.ToString());
                                ListViewDocument.SubItems.Add(SelectedDocument.Keywords);
                            }

                            lvwDocuments.Items.Add(ListViewDocument);
                        }
                    }

                    lvwDocuments.EndUpdate();
                //}
                lblStatus.Text = "Idle";
                Cursor.Current = Cursors.Default;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSearch(txtSearch.Text);
        }

        //private void Worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    //AddNodeToTreeview(null, "documents", "Documents", 0, 0);
        //    //_SelectedDocumentEntry = new Document();
        //    //_SelectedDocumentEntry.Path = "/documents";
        //    //_SelectedDocumentEntry.IsFolder = true;

        //    //tvwFolders.Nodes[0].Tag = _SelectedDocumentEntry;

        //    //tvwFolders.ExpandAll();

        //    //_Documents = Global.GetAllDocuments(false, "", Global.FileOrFolderSelection.Folder);

        //    //lblStatus.Text = "Idle";
        //}

        //private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //Cursor.Current = Cursors.Default;

        //    //tvwFolders.ExpandAll();

        //    //_Documents = Global.GetAllDocuments(false,"", Global.FileOrFolderSelection.Folder);

        //    //lblStatus.Text = "Idle";
        //}

        private void tvwFolders_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }

        private void tvwFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Console.WriteLine("tvwFolders_AfterSelect()");

            ClickTreeNode();
        }

        private void tvwFolders_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("tvwFolders_MouseClick()");

            if (_SelectedTreeNode != null)
            {
                btnDeleteFolder.Enabled = ManageMode && Global.Permissions.Contains("Delete Document Folder");
            }
            else
            {
                btnDeleteFolder.Enabled = false;
            }
        }

        private void tvwFolders_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("tvwFolders_MouseUp()");

            TreeNode SelectedNode = tvwFolders.GetNodeAt(e.Location);
            if (SelectedNode != null)
            {
                _SelectedTreeNode = SelectedNode;
                tvwFolders.SelectedNode = _SelectedTreeNode;

                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    addFolderToolStripMenuItem.Enabled = ManageMode && Global.Permissions.Contains("Create Document Folder");

                    if (_SelectedTreeNode != null)
                    {
                        deleteFolderToolStripMenuItem.Enabled = ManageMode && Global.Permissions.Contains("Delete Document Folder");
                    }
                    else
                    {
                        deleteFolderToolStripMenuItem.Enabled = false;
                    }

                    cmsRightClickFolderList.Show(tvwFolders, e.Location);
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }
            else
            {
                txtSearch.SelectAll();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                DoSearch(txtSearch.Text);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") txtSearch.Text = "Search";
        }
    }
}
