namespace PharmacyAssist
{
    partial class frmDocuments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocuments));
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewDocument = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.radViewSmall = new System.Windows.Forms.RadioButton();
            this.radViewLarge = new System.Windows.Forms.RadioButton();
            this.radViewList = new System.Windows.Forms.RadioButton();
            this.radViewDetails = new System.Windows.Forms.RadioButton();
            this.btnDeleteDocument = new System.Windows.Forms.Button();
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.tvwFolders = new System.Windows.Forms.TreeView();
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.lvwDocuments = new System.Windows.Forms.ListView();
            this.imlLarge = new System.Windows.Forms.ImageList(this.components);
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmsRightClickDocumentList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmsRightClickFolderList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddDocument = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnDeleteFolder = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.cmsRightClickDocumentList.SuspendLayout();
            this.cmsRightClickFolderList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::PharmacyAssist.Properties.Resources.door_out;
            this.btnClose.Location = new System.Drawing.Point(921, 525);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 16;
            this.toolTips.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnViewDocument
            // 
            this.btnViewDocument.Enabled = false;
            this.btnViewDocument.Image = global::PharmacyAssist.Properties.Resources.book_open;
            this.btnViewDocument.Location = new System.Drawing.Point(559, 85);
            this.btnViewDocument.Name = "btnViewDocument";
            this.btnViewDocument.Size = new System.Drawing.Size(25, 24);
            this.btnViewDocument.TabIndex = 18;
            this.toolTips.SetToolTip(this.btnViewDocument, "View Document");
            this.btnViewDocument.UseVisualStyleBackColor = true;
            this.btnViewDocument.Click += new System.EventHandler(this.btnViewDocument_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::PharmacyAssist.Properties.Resources.realvista_general_zoom_16;
            this.btnSearch.Location = new System.Drawing.Point(972, 113);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 24);
            this.btnSearch.TabIndex = 21;
            this.toolTips.SetToolTip(this.btnSearch, "Start Search");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Enabled = false;
            this.btnInfo.Image = global::PharmacyAssist.Properties.Resources.information;
            this.btnInfo.Location = new System.Drawing.Point(529, 85);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(24, 24);
            this.btnInfo.TabIndex = 23;
            this.toolTips.SetToolTip(this.btnInfo, "Document Information");
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClearSearch.Image = global::PharmacyAssist.Properties.Resources.cross;
            this.btnClearSearch.Location = new System.Drawing.Point(942, 114);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(22, 22);
            this.btnClearSearch.TabIndex = 24;
            this.toolTips.SetToolTip(this.btnClearSearch, "Clear search term");
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // radViewSmall
            // 
            this.radViewSmall.Appearance = System.Windows.Forms.Appearance.Button;
            this.radViewSmall.Image = global::PharmacyAssist.Properties.Resources.application_view_icons;
            this.radViewSmall.Location = new System.Drawing.Point(348, 85);
            this.radViewSmall.Name = "radViewSmall";
            this.radViewSmall.Size = new System.Drawing.Size(24, 24);
            this.radViewSmall.TabIndex = 25;
            this.toolTips.SetToolTip(this.radViewSmall, "Small Icons");
            this.radViewSmall.UseVisualStyleBackColor = true;
            this.radViewSmall.CheckedChanged += new System.EventHandler(this.radViewSmall_CheckedChanged);
            // 
            // radViewLarge
            // 
            this.radViewLarge.Appearance = System.Windows.Forms.Appearance.Button;
            this.radViewLarge.Image = global::PharmacyAssist.Properties.Resources.application_view_tile;
            this.radViewLarge.Location = new System.Drawing.Point(378, 85);
            this.radViewLarge.Name = "radViewLarge";
            this.radViewLarge.Size = new System.Drawing.Size(24, 24);
            this.radViewLarge.TabIndex = 26;
            this.toolTips.SetToolTip(this.radViewLarge, "Large Icons");
            this.radViewLarge.UseVisualStyleBackColor = true;
            this.radViewLarge.CheckedChanged += new System.EventHandler(this.radViewLarge_CheckedChanged);
            // 
            // radViewList
            // 
            this.radViewList.Appearance = System.Windows.Forms.Appearance.Button;
            this.radViewList.Image = global::PharmacyAssist.Properties.Resources.application_view_list;
            this.radViewList.Location = new System.Drawing.Point(408, 85);
            this.radViewList.Name = "radViewList";
            this.radViewList.Size = new System.Drawing.Size(24, 24);
            this.radViewList.TabIndex = 27;
            this.toolTips.SetToolTip(this.radViewList, "List");
            this.radViewList.UseVisualStyleBackColor = true;
            this.radViewList.CheckedChanged += new System.EventHandler(this.radViewList_CheckedChanged);
            // 
            // radViewDetails
            // 
            this.radViewDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.radViewDetails.Checked = true;
            this.radViewDetails.Image = global::PharmacyAssist.Properties.Resources.application_view_detail;
            this.radViewDetails.Location = new System.Drawing.Point(318, 85);
            this.radViewDetails.Name = "radViewDetails";
            this.radViewDetails.Size = new System.Drawing.Size(24, 24);
            this.radViewDetails.TabIndex = 28;
            this.radViewDetails.TabStop = true;
            this.toolTips.SetToolTip(this.radViewDetails, "Details");
            this.radViewDetails.UseVisualStyleBackColor = true;
            this.radViewDetails.CheckedChanged += new System.EventHandler(this.radViewDetails_CheckedChanged);
            // 
            // btnDeleteDocument
            // 
            this.btnDeleteDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDocument.Enabled = false;
            this.btnDeleteDocument.Image = global::PharmacyAssist.Properties.Resources.book_delete;
            this.btnDeleteDocument.Location = new System.Drawing.Point(942, 85);
            this.btnDeleteDocument.Name = "btnDeleteDocument";
            this.btnDeleteDocument.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteDocument.TabIndex = 30;
            this.toolTips.SetToolTip(this.btnDeleteDocument, "Delete Document");
            this.btnDeleteDocument.UseVisualStyleBackColor = true;
            this.btnDeleteDocument.Click += new System.EventHandler(this.btnDeleteDocument_Click);
            // 
            // gpTitle
            // 
            this.gpTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpTitle.BorderColor = System.Drawing.Color.Transparent;
            this.gpTitle.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gpTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gpTitle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gpTitle.Image = null;
            this.gpTitle.ImageLocation = new System.Drawing.Point(2, 2);
            this.gpTitle.ImageSize = new System.Drawing.Point(64, 64);
            this.gpTitle.ImageSizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.gpTitle.Location = new System.Drawing.Point(12, 12);
            this.gpTitle.Name = "gpTitle";
            this.gpTitle.ShadowOffSet = 0;
            this.gpTitle.Size = new System.Drawing.Size(984, 67);
            this.gpTitle.TabIndex = 0;
            // 
            // tvwFolders
            // 
            this.tvwFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwFolders.HotTracking = true;
            this.tvwFolders.ImageIndex = 0;
            this.tvwFolders.ImageList = this.imlSmall;
            this.tvwFolders.Location = new System.Drawing.Point(12, 85);
            this.tvwFolders.Name = "tvwFolders";
            this.tvwFolders.SelectedImageIndex = 0;
            this.tvwFolders.Size = new System.Drawing.Size(300, 434);
            this.tvwFolders.TabIndex = 2;
            this.tvwFolders.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvwFolders_AfterExpand);
            this.tvwFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwFolders_AfterSelect);
            this.tvwFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvwFolders_MouseClick);
            this.tvwFolders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvwFolders_MouseUp);
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "vista_networking_server_16.png");
            this.imlSmall.Images.SetKeyName(1, "vista_general_folder_16.png");
            this.imlSmall.Images.SetKeyName(2, "supervista_general_book_16.png");
            this.imlSmall.Images.SetKeyName(3, "File_PowerPoint.png");
            this.imlSmall.Images.SetKeyName(4, "File_Pdf.png");
            this.imlSmall.Images.SetKeyName(5, "Word.png");
            this.imlSmall.Images.SetKeyName(6, "File.png");
            // 
            // lvwDocuments
            // 
            this.lvwDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDocuments.LargeImageList = this.imlLarge;
            this.lvwDocuments.Location = new System.Drawing.Point(318, 142);
            this.lvwDocuments.Name = "lvwDocuments";
            this.lvwDocuments.Size = new System.Drawing.Size(678, 377);
            this.lvwDocuments.SmallImageList = this.imlSmall;
            this.lvwDocuments.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwDocuments.TabIndex = 17;
            this.lvwDocuments.UseCompatibleStateImageBehavior = false;
            this.lvwDocuments.View = System.Windows.Forms.View.Details;
            this.lvwDocuments.SelectedIndexChanged += new System.EventHandler(this.lvwDocuments_SelectedIndexChanged);
            this.lvwDocuments.Leave += new System.EventHandler(this.lvwDocuments_Leave);
            this.lvwDocuments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwDocuments_MouseDoubleClick);
            this.lvwDocuments.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwDocuments_MouseUp);
            // 
            // imlLarge
            // 
            this.imlLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLarge.ImageStream")));
            this.imlLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLarge.Images.SetKeyName(0, "vista_networking_server_32.png");
            this.imlLarge.Images.SetKeyName(1, "vista_general_folder_32.png");
            this.imlLarge.Images.SetKeyName(2, "supervista_general_book_32.png");
            this.imlLarge.Images.SetKeyName(3, "File_PowerPoint.png");
            this.imlLarge.Images.SetKeyName(4, "File_Pdf.png");
            this.imlLarge.Images.SetKeyName(5, "Word.png");
            this.imlLarge.Images.SetKeyName(6, "File.png");
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(318, 115);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(537, 20);
            this.txtPath.TabIndex = 19;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSearch.Location = new System.Drawing.Point(861, 115);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(81, 20);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.Text = "Search";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // cmsRightClickDocumentList
            // 
            this.cmsRightClickDocumentList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.cmsRightClickDocumentList.Name = "cmsRightClick";
            this.cmsRightClickDocumentList.Size = new System.Drawing.Size(197, 120);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::PharmacyAssist.Properties.Resources.book_add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.addToolStripMenuItem.Text = "Add Document";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PharmacyAssist.Properties.Resources.book_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.deleteToolStripMenuItem.Text = "Delete Document";
            this.deleteToolStripMenuItem.Visible = false;
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::PharmacyAssist.Properties.Resources.information;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.propertiesToolStripMenuItem.Text = "Document Information";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openToolStripMenuItem.Image = global::PharmacyAssist.Properties.Resources.book_open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openToolStripMenuItem.Text = "Open Document";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(12, 525);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(903, 24);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "Idle";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmsRightClickFolderList
            // 
            this.cmsRightClickFolderList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem,
            this.deleteFolderToolStripMenuItem});
            this.cmsRightClickFolderList.Name = "cmsRightClickFolderList";
            this.cmsRightClickFolderList.Size = new System.Drawing.Size(144, 48);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::PharmacyAssist.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // deleteFolderToolStripMenuItem
            // 
            this.deleteFolderToolStripMenuItem.Image = global::PharmacyAssist.Properties.Resources.folder_delete;
            this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteFolderToolStripMenuItem.Text = "Delete Folder";
            this.deleteFolderToolStripMenuItem.Visible = false;
            this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteFolderToolStripMenuItem_Click);
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.Enabled = false;
            this.btnAddDocument.Image = global::PharmacyAssist.Properties.Resources.book_add;
            this.btnAddDocument.Location = new System.Drawing.Point(499, 85);
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(24, 24);
            this.btnAddDocument.TabIndex = 29;
            this.btnAddDocument.UseVisualStyleBackColor = true;
            this.btnAddDocument.Click += new System.EventHandler(this.btnAddDocument_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Enabled = false;
            this.btnAddFolder.Image = global::PharmacyAssist.Properties.Resources.folder_add;
            this.btnAddFolder.Location = new System.Drawing.Point(469, 85);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(24, 24);
            this.btnAddFolder.TabIndex = 31;
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnDeleteFolder
            // 
            this.btnDeleteFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFolder.Enabled = false;
            this.btnDeleteFolder.Image = global::PharmacyAssist.Properties.Resources.folder_delete;
            this.btnDeleteFolder.Location = new System.Drawing.Point(912, 85);
            this.btnDeleteFolder.Name = "btnDeleteFolder";
            this.btnDeleteFolder.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteFolder.TabIndex = 32;
            this.btnDeleteFolder.UseVisualStyleBackColor = true;
            this.btnDeleteFolder.Visible = false;
            this.btnDeleteFolder.Click += new System.EventHandler(this.btnDeleteFolder_Click);
            // 
            // btnManage
            // 
            this.btnManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManage.Enabled = false;
            this.btnManage.Image = global::PharmacyAssist.Properties.Resources.edit;
            this.btnManage.Location = new System.Drawing.Point(972, 85);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(24, 24);
            this.btnManage.TabIndex = 33;
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // frmDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnDeleteFolder);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.btnDeleteDocument);
            this.Controls.Add(this.btnAddDocument);
            this.Controls.Add(this.radViewDetails);
            this.Controls.Add(this.radViewList);
            this.Controls.Add(this.radViewLarge);
            this.Controls.Add(this.radViewSmall);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnViewDocument);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lvwDocuments);
            this.Controls.Add(this.tvwFolders);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(705, 394);
            this.Name = "frmDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documents";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDocuments_FormClosing);
            this.Load += new System.EventHandler(this.frmDocuments_Load);
            this.cmsRightClickDocumentList.ResumeLayout(false);
            this.cmsRightClickFolderList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Button btnClose;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.TreeView tvwFolders;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ListView lvwDocuments;
        private System.Windows.Forms.ImageList imlLarge;
        private System.Windows.Forms.Button btnViewDocument;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip cmsRightClickDocumentList;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsRightClickFolderList;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.RadioButton radViewSmall;
        private System.Windows.Forms.RadioButton radViewLarge;
        private System.Windows.Forms.RadioButton radViewList;
        private System.Windows.Forms.RadioButton radViewDetails;
        private System.Windows.Forms.Button btnAddDocument;
        private System.Windows.Forms.Button btnDeleteDocument;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnDeleteFolder;
        private System.Windows.Forms.Button btnManage;
    }
}