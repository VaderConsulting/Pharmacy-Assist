namespace PharmacyAssist
{
    partial class frmCatalogs002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatalogs002));
            this.lstCatalogs = new System.Windows.Forms.ListBox();
            this.lblSelectACatalog = new System.Windows.Forms.Label();
            this.imlCatalogs = new System.Windows.Forms.ImageList(this.components);
            this.tips = new System.Windows.Forms.ToolTip(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSelectProducts = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteCatalog = new System.Windows.Forms.Button();
            this.btnAddCatalog = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveCatalog = new System.Windows.Forms.Button();
            this.datEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.datStart = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpCatalogDetails = new System.Windows.Forms.GroupBox();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.grpCatalogDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCatalogs
            // 
            this.lstCatalogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCatalogs.FormattingEnabled = true;
            this.lstCatalogs.Location = new System.Drawing.Point(12, 35);
            this.lstCatalogs.Name = "lstCatalogs";
            this.lstCatalogs.Size = new System.Drawing.Size(267, 147);
            this.lstCatalogs.TabIndex = 0;
            this.lstCatalogs.SelectedIndexChanged += new System.EventHandler(this.lstCatalogs_SelectedIndexChanged);
            // 
            // lblSelectACatalog
            // 
            this.lblSelectACatalog.Location = new System.Drawing.Point(12, 9);
            this.lblSelectACatalog.Name = "lblSelectACatalog";
            this.lblSelectACatalog.Size = new System.Drawing.Size(267, 23);
            this.lblSelectACatalog.TabIndex = 1;
            this.lblSelectACatalog.Text = "Select an existing catalog, or import one from RPM.";
            // 
            // imlCatalogs
            // 
            this.imlCatalogs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCatalogs.ImageStream")));
            this.imlCatalogs.TransparentColor = System.Drawing.Color.Transparent;
            this.imlCatalogs.Images.SetKeyName(0, "newspaper_go.png");
            this.imlCatalogs.Images.SetKeyName(1, "newspaper_add.png");
            this.imlCatalogs.Images.SetKeyName(2, "newspaper_delete.png");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(460, 197);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 13;
            this.tips.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSelectProducts
            // 
            this.btnSelectProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectProducts.Image = global::PharmacyAssist.Properties.Resources.supervista_business_benchmarking_16;
            this.btnSelectProducts.Location = new System.Drawing.Point(192, 117);
            this.btnSelectProducts.Name = "btnSelectProducts";
            this.btnSelectProducts.Size = new System.Drawing.Size(75, 24);
            this.btnSelectProducts.TabIndex = 13;
            this.tips.SetToolTip(this.btnSelectProducts, "Select products");
            this.btnSelectProducts.UseVisualStyleBackColor = true;
            this.btnSelectProducts.Click += new System.EventHandler(this.btnSelectProducts_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::PharmacyAssist.Properties.Resources.door_out;
            this.btnClose.Location = new System.Drawing.Point(490, 197);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 5;
            this.tips.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteCatalog
            // 
            this.btnDeleteCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteCatalog.Enabled = false;
            this.btnDeleteCatalog.ImageIndex = 2;
            this.btnDeleteCatalog.ImageList = this.imlCatalogs;
            this.btnDeleteCatalog.Location = new System.Drawing.Point(42, 197);
            this.btnDeleteCatalog.Name = "btnDeleteCatalog";
            this.btnDeleteCatalog.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteCatalog.TabIndex = 3;
            this.tips.SetToolTip(this.btnDeleteCatalog, "Delete Catalog");
            this.btnDeleteCatalog.UseVisualStyleBackColor = true;
            this.btnDeleteCatalog.Visible = false;
            this.btnDeleteCatalog.Click += new System.EventHandler(this.btnDeleteCatalog_Click);
            // 
            // btnAddCatalog
            // 
            this.btnAddCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCatalog.ImageIndex = 1;
            this.btnAddCatalog.ImageList = this.imlCatalogs;
            this.btnAddCatalog.Location = new System.Drawing.Point(12, 197);
            this.btnAddCatalog.Name = "btnAddCatalog";
            this.btnAddCatalog.Size = new System.Drawing.Size(24, 24);
            this.btnAddCatalog.TabIndex = 2;
            this.tips.SetToolTip(this.btnAddCatalog, "Import Catalog from RPM");
            this.btnAddCatalog.UseVisualStyleBackColor = true;
            this.btnAddCatalog.Click += new System.EventHandler(this.btnAddCatalog_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::PharmacyAssist.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(132, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(24, 24);
            this.btnCancel.TabIndex = 14;
            this.tips.SetToolTip(this.btnCancel, "Cancel");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveCatalog
            // 
            this.btnSaveCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCatalog.Image = global::PharmacyAssist.Properties.Resources.yes;
            this.btnSaveCatalog.Location = new System.Drawing.Point(162, 117);
            this.btnSaveCatalog.Name = "btnSaveCatalog";
            this.btnSaveCatalog.Size = new System.Drawing.Size(24, 24);
            this.btnSaveCatalog.TabIndex = 2;
            this.tips.SetToolTip(this.btnSaveCatalog, "OK");
            this.btnSaveCatalog.UseVisualStyleBackColor = true;
            this.btnSaveCatalog.Visible = false;
            this.btnSaveCatalog.Click += new System.EventHandler(this.btnSaveCatalog_Click);
            // 
            // datEnd
            // 
            this.datEnd.Enabled = false;
            this.datEnd.Location = new System.Drawing.Point(67, 71);
            this.datEnd.Name = "datEnd";
            this.datEnd.Size = new System.Drawing.Size(200, 20);
            this.datEnd.TabIndex = 11;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(6, 74);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(63, 23);
            this.lblEndDate.TabIndex = 10;
            this.lblEndDate.Text = "End Date";
            // 
            // datStart
            // 
            this.datStart.Enabled = false;
            this.datStart.Location = new System.Drawing.Point(67, 45);
            this.datStart.Name = "datStart";
            this.datStart.Size = new System.Drawing.Size(200, 20);
            this.datStart.TabIndex = 9;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(6, 51);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 23);
            this.lblStartDate.TabIndex = 8;
            this.lblStartDate.Text = "Start Date";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(66, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(201, 20);
            this.txtName.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 18);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // grpCatalogDetails
            // 
            this.grpCatalogDetails.Controls.Add(this.lblProductCount);
            this.grpCatalogDetails.Controls.Add(this.btnCancel);
            this.grpCatalogDetails.Controls.Add(this.btnSelectProducts);
            this.grpCatalogDetails.Controls.Add(this.lblName);
            this.grpCatalogDetails.Controls.Add(this.datEnd);
            this.grpCatalogDetails.Controls.Add(this.btnSaveCatalog);
            this.grpCatalogDetails.Controls.Add(this.txtName);
            this.grpCatalogDetails.Controls.Add(this.lblEndDate);
            this.grpCatalogDetails.Controls.Add(this.lblStartDate);
            this.grpCatalogDetails.Controls.Add(this.datStart);
            this.grpCatalogDetails.Enabled = false;
            this.grpCatalogDetails.Location = new System.Drawing.Point(285, 35);
            this.grpCatalogDetails.Name = "grpCatalogDetails";
            this.grpCatalogDetails.Size = new System.Drawing.Size(280, 147);
            this.grpCatalogDetails.TabIndex = 12;
            this.grpCatalogDetails.TabStop = false;
            this.grpCatalogDetails.Text = "Catalog Details";
            // 
            // lblProductCount
            // 
            this.lblProductCount.Location = new System.Drawing.Point(9, 98);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(258, 16);
            this.lblProductCount.TabIndex = 15;
            // 
            // frmCatalogs002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 233);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpCatalogDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteCatalog);
            this.Controls.Add(this.btnAddCatalog);
            this.Controls.Add(this.lblSelectACatalog);
            this.Controls.Add(this.lstCatalogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(270, 244);
            this.Name = "frmCatalogs002";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCatalogs002_FormClosing);
            this.Load += new System.EventHandler(this.frmCatalogs_Load);
            this.grpCatalogDetails.ResumeLayout(false);
            this.grpCatalogDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCatalogs;
        private System.Windows.Forms.Label lblSelectACatalog;
        private System.Windows.Forms.Button btnAddCatalog;
        private System.Windows.Forms.ImageList imlCatalogs;
        private System.Windows.Forms.Button btnDeleteCatalog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip tips;
        private System.Windows.Forms.DateTimePicker datEnd;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker datStart;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpCatalogDetails;
        private System.Windows.Forms.Button btnSelectProducts;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveCatalog;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblProductCount;
    }
}