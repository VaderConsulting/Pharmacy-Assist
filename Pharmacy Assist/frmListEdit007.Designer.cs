namespace PharmacyAssist
{
    partial class frmListEdit007
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListEdit007));
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnViewDocument = new System.Windows.Forms.Button();
            this.btnDocuments = new System.Windows.Forms.Button();
            this.btnProductLinking = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLinkItems = new System.Windows.Forms.Button();
            this.btnAcceptEdits = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnUserAccounts = new System.Windows.Forms.Button();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.lblDuplicates = new System.Windows.Forms.Label();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.chkValue = new System.Windows.Forms.CheckBox();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.lblLinkInfo = new System.Windows.Forms.Label();
            this.lblDocumentInfo = new System.Windows.Forms.Label();
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.lblUserAccountInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Enabled = false;
            this.btnUpload.Image = global::PharmacyAssist.Properties.Resources.realvista_general_up_16;
            this.btnUpload.Location = new System.Drawing.Point(626, 173);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(24, 24);
            this.btnUpload.TabIndex = 6;
            this.ToolTips.SetToolTip(this.btnUpload, "Upload Document");
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnViewDocument
            // 
            this.btnViewDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewDocument.Enabled = false;
            this.btnViewDocument.Image = global::PharmacyAssist.Properties.Resources.book_open;
            this.btnViewDocument.Location = new System.Drawing.Point(338, 233);
            this.btnViewDocument.Name = "btnViewDocument";
            this.btnViewDocument.Size = new System.Drawing.Size(25, 24);
            this.btnViewDocument.TabIndex = 15;
            this.ToolTips.SetToolTip(this.btnViewDocument, "View Document");
            this.btnViewDocument.UseVisualStyleBackColor = true;
            this.btnViewDocument.Click += new System.EventHandler(this.btnViewDocument_Click);
            // 
            // btnDocuments
            // 
            this.btnDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocuments.Enabled = false;
            this.btnDocuments.Image = global::PharmacyAssist.Properties.Resources.supervista_general_book_16;
            this.btnDocuments.Location = new System.Drawing.Point(308, 233);
            this.btnDocuments.Name = "btnDocuments";
            this.btnDocuments.Size = new System.Drawing.Size(24, 24);
            this.btnDocuments.TabIndex = 14;
            this.ToolTips.SetToolTip(this.btnDocuments, "Show Documents");
            this.btnDocuments.UseVisualStyleBackColor = true;
            this.btnDocuments.Click += new System.EventHandler(this.btnDocuments_Click);
            // 
            // btnProductLinking
            // 
            this.btnProductLinking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProductLinking.Enabled = false;
            this.btnProductLinking.Image = global::PharmacyAssist.Properties.Resources.supervista_business_benchmarking_16;
            this.btnProductLinking.Location = new System.Drawing.Point(338, 203);
            this.btnProductLinking.Name = "btnProductLinking";
            this.btnProductLinking.Size = new System.Drawing.Size(24, 24);
            this.btnProductLinking.TabIndex = 10;
            this.ToolTips.SetToolTip(this.btnProductLinking, "Show linked products");
            this.btnProductLinking.UseVisualStyleBackColor = true;
            this.btnProductLinking.Click += new System.EventHandler(this.btnProductLinking_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(547, 319);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 22;
            this.ToolTips.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLinkItems
            // 
            this.btnLinkItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkItems.Enabled = false;
            this.btnLinkItems.Image = global::PharmacyAssist.Properties.Resources.supervista_networking_link_16;
            this.btnLinkItems.Location = new System.Drawing.Point(308, 203);
            this.btnLinkItems.Name = "btnLinkItems";
            this.btnLinkItems.Size = new System.Drawing.Size(24, 24);
            this.btnLinkItems.TabIndex = 9;
            this.ToolTips.SetToolTip(this.btnLinkItems, "Show other links");
            this.btnLinkItems.UseVisualStyleBackColor = true;
            this.btnLinkItems.Click += new System.EventHandler(this.btnLinkItems_Click);
            // 
            // btnAcceptEdits
            // 
            this.btnAcceptEdits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptEdits.Enabled = false;
            this.btnAcceptEdits.Image = global::PharmacyAssist.Properties.Resources.yes;
            this.btnAcceptEdits.Location = new System.Drawing.Point(596, 203);
            this.btnAcceptEdits.Name = "btnAcceptEdits";
            this.btnAcceptEdits.Size = new System.Drawing.Size(24, 24);
            this.btnAcceptEdits.TabIndex = 11;
            this.ToolTips.SetToolTip(this.btnAcceptEdits, "Accept changes");
            this.btnAcceptEdits.UseVisualStyleBackColor = true;
            this.btnAcceptEdits.Click += new System.EventHandler(this.btnAcceptEdits_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::PharmacyAssist.Properties.Resources.door_out;
            this.btnClose.Location = new System.Drawing.Point(577, 319);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 23;
            this.ToolTips.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelEdit.Enabled = false;
            this.btnCancelEdit.Image = global::PharmacyAssist.Properties.Resources.no;
            this.btnCancelEdit.Location = new System.Drawing.Point(626, 203);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(24, 24);
            this.btnCancelEdit.TabIndex = 12;
            this.ToolTips.SetToolTip(this.btnCancelEdit, "Cancel Edit");
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEdit.Enabled = false;
            this.btnSaveEdit.Image = global::PharmacyAssist.Properties.Resources.save;
            this.btnSaveEdit.Location = new System.Drawing.Point(626, 233);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(24, 24);
            this.btnSaveEdit.TabIndex = 16;
            this.ToolTips.SetToolTip(this.btnSaveEdit, "Save Edit");
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveItem.Enabled = false;
            this.btnRemoveItem.Image = global::PharmacyAssist.Properties.Resources.minus;
            this.btnRemoveItem.Location = new System.Drawing.Point(338, 295);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveItem.TabIndex = 21;
            this.ToolTips.SetToolTip(this.btnRemoveItem, "Remove linked Items and delete this item");
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Enabled = false;
            this.btnAddItem.Image = global::PharmacyAssist.Properties.Resources.add;
            this.btnAddItem.Location = new System.Drawing.Point(308, 295);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(24, 24);
            this.btnAddItem.TabIndex = 20;
            this.ToolTips.SetToolTip(this.btnAddItem, "Add");
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnUserAccounts
            // 
            this.btnUserAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserAccounts.Enabled = false;
            this.btnUserAccounts.Image = global::PharmacyAssist.Properties.Resources.windows7_general_group_16;
            this.btnUserAccounts.Location = new System.Drawing.Point(308, 264);
            this.btnUserAccounts.Name = "btnUserAccounts";
            this.btnUserAccounts.Size = new System.Drawing.Size(24, 24);
            this.btnUserAccounts.TabIndex = 18;
            this.ToolTips.SetToolTip(this.btnUserAccounts, "Show Linked User Accounts");
            this.btnUserAccounts.UseVisualStyleBackColor = true;
            this.btnUserAccounts.Click += new System.EventHandler(this.btnUserAccounts_Click);
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(12, 90);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(285, 225);
            this.lstItems.Sorted = true;
            this.lstItems.TabIndex = 1;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // lstColumns
            // 
            this.lstColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.Location = new System.Drawing.Point(310, 90);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(342, 56);
            this.lstColumns.TabIndex = 2;
            this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
            // 
            // lblDuplicates
            // 
            this.lblDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuplicates.ForeColor = System.Drawing.Color.Red;
            this.lblDuplicates.Location = new System.Drawing.Point(12, 331);
            this.lblDuplicates.Name = "lblDuplicates";
            this.lblDuplicates.Size = new System.Drawing.Size(529, 22);
            this.lblDuplicates.TabIndex = 24;
            this.lblDuplicates.Text = "The selection list contains duplicates!  Remove duplicates, ensuring linking is a" +
    "lso corrected.";
            this.lblDuplicates.Visible = false;
            // 
            // lblProperty
            // 
            this.lblProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProperty.Location = new System.Drawing.Point(307, 149);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(57, 22);
            this.lblProperty.TabIndex = 4;
            this.lblProperty.Text = "Property";
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.Location = new System.Drawing.Point(307, 178);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(42, 22);
            this.lblValue.TabIndex = 7;
            this.lblValue.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Enabled = false;
            this.txtValue.Location = new System.Drawing.Point(373, 175);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(247, 20);
            this.txtValue.TabIndex = 5;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // chkValue
            // 
            this.chkValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkValue.AutoSize = true;
            this.chkValue.Enabled = false;
            this.chkValue.Location = new System.Drawing.Point(373, 178);
            this.chkValue.Name = "chkValue";
            this.chkValue.Size = new System.Drawing.Size(15, 14);
            this.chkValue.TabIndex = 8;
            this.chkValue.UseVisualStyleBackColor = true;
            this.chkValue.Visible = false;
            this.chkValue.CheckedChanged += new System.EventHandler(this.chkValue_CheckedChanged);
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertyName.Location = new System.Drawing.Point(373, 148);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.ReadOnly = true;
            this.txtPropertyName.Size = new System.Drawing.Size(247, 20);
            this.txtPropertyName.TabIndex = 3;
            // 
            // lblLinkInfo
            // 
            this.lblLinkInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinkInfo.Location = new System.Drawing.Point(373, 209);
            this.lblLinkInfo.Name = "lblLinkInfo";
            this.lblLinkInfo.Size = new System.Drawing.Size(217, 23);
            this.lblLinkInfo.TabIndex = 13;
            // 
            // lblDocumentInfo
            // 
            this.lblDocumentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocumentInfo.Location = new System.Drawing.Point(373, 239);
            this.lblDocumentInfo.Name = "lblDocumentInfo";
            this.lblDocumentInfo.Size = new System.Drawing.Size(217, 23);
            this.lblDocumentInfo.TabIndex = 17;
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
            this.gpTitle.Size = new System.Drawing.Size(640, 67);
            this.gpTitle.TabIndex = 0;
            // 
            // lblUserAccountInfo
            // 
            this.lblUserAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserAccountInfo.Location = new System.Drawing.Point(373, 270);
            this.lblUserAccountInfo.Name = "lblUserAccountInfo";
            this.lblUserAccountInfo.Size = new System.Drawing.Size(217, 23);
            this.lblUserAccountInfo.TabIndex = 19;
            // 
            // frmListEdit007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 355);
            this.Controls.Add(this.lblUserAccountInfo);
            this.Controls.Add(this.btnUserAccounts);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnViewDocument);
            this.Controls.Add(this.lblDocumentInfo);
            this.Controls.Add(this.btnDocuments);
            this.Controls.Add(this.btnProductLinking);
            this.Controls.Add(this.lblLinkInfo);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLinkItems);
            this.Controls.Add(this.txtPropertyName);
            this.Controls.Add(this.btnAcceptEdits);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.btnSaveEdit);
            this.Controls.Add(this.chkValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblDuplicates);
            this.Controls.Add(this.lstColumns);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(595, 377);
            this.Name = "frmListEdit007";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Edit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListEdit007_FormClosing);
            this.Load += new System.EventHandler(this.frmListEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.Label lblDuplicates;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.CheckBox chkValue;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAcceptEdits;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Button btnLinkItems;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblLinkInfo;
        private System.Windows.Forms.Button btnProductLinking;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Label lblDocumentInfo;
        private System.Windows.Forms.Button btnViewDocument;
        private System.Windows.Forms.Button btnUpload;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.Button btnUserAccounts;
        private System.Windows.Forms.Label lblUserAccountInfo;
    }
}