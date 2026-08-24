namespace RPM_Import
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblSourceConnectionString = new System.Windows.Forms.Label();
            this.txtSourceConnectionString = new System.Windows.Forms.TextBox();
            this.lblDestinationConnectionString = new System.Windows.Forms.Label();
            this.txtDestinationConnectionString = new System.Windows.Forms.TextBox();
            this.lblImportQuery = new System.Windows.Forms.Label();
            this.txtImportQuery = new System.Windows.Forms.TextBox();
            this.tabPages = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBarUnaltered = new System.Windows.Forms.ProgressBar();
            this.progressBarNew = new System.Windows.Forms.ProgressBar();
            this.progressBarUpdates = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUnalteredCount = new System.Windows.Forms.Label();
            this.lblUnaltered = new System.Windows.Forms.Label();
            this.lstUnaltered = new System.Windows.Forms.ListBox();
            this.lblNewCount = new System.Windows.Forms.Label();
            this.lblUpdateCount = new System.Windows.Forms.Label();
            this.lblNewProducts = new System.Windows.Forms.Label();
            this.lblUpdates = new System.Windows.Forms.Label();
            this.lstNew = new System.Windows.Forms.ListBox();
            this.lstUpdates = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.tabPages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSourceConnectionString
            // 
            this.lblSourceConnectionString.Location = new System.Drawing.Point(6, 3);
            this.lblSourceConnectionString.Name = "lblSourceConnectionString";
            this.lblSourceConnectionString.Size = new System.Drawing.Size(131, 18);
            this.lblSourceConnectionString.TabIndex = 0;
            this.lblSourceConnectionString.Text = "Source Connection String";
            this.lblSourceConnectionString.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtSourceConnectionString
            // 
            this.txtSourceConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceConnectionString.Location = new System.Drawing.Point(5, 24);
            this.txtSourceConnectionString.Name = "txtSourceConnectionString";
            this.txtSourceConnectionString.Size = new System.Drawing.Size(481, 20);
            this.txtSourceConnectionString.TabIndex = 1;
            // 
            // lblDestinationConnectionString
            // 
            this.lblDestinationConnectionString.Location = new System.Drawing.Point(5, 47);
            this.lblDestinationConnectionString.Name = "lblDestinationConnectionString";
            this.lblDestinationConnectionString.Size = new System.Drawing.Size(151, 23);
            this.lblDestinationConnectionString.TabIndex = 2;
            this.lblDestinationConnectionString.Text = "Destination Connection String";
            this.lblDestinationConnectionString.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDestinationConnectionString
            // 
            this.txtDestinationConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationConnectionString.Location = new System.Drawing.Point(9, 73);
            this.txtDestinationConnectionString.Name = "txtDestinationConnectionString";
            this.txtDestinationConnectionString.Size = new System.Drawing.Size(477, 20);
            this.txtDestinationConnectionString.TabIndex = 3;
            // 
            // lblImportQuery
            // 
            this.lblImportQuery.Location = new System.Drawing.Point(6, 96);
            this.lblImportQuery.Name = "lblImportQuery";
            this.lblImportQuery.Size = new System.Drawing.Size(100, 23);
            this.lblImportQuery.TabIndex = 4;
            this.lblImportQuery.Text = "Import Query";
            this.lblImportQuery.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtImportQuery
            // 
            this.txtImportQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportQuery.Location = new System.Drawing.Point(6, 123);
            this.txtImportQuery.Multiline = true;
            this.txtImportQuery.Name = "txtImportQuery";
            this.txtImportQuery.Size = new System.Drawing.Size(480, 226);
            this.txtImportQuery.TabIndex = 5;
            // 
            // tabPages
            // 
            this.tabPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPages.Controls.Add(this.tabPage1);
            this.tabPages.Controls.Add(this.tabPage2);
            this.tabPages.Location = new System.Drawing.Point(12, 12);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(500, 381);
            this.tabPages.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblSourceConnectionString);
            this.tabPage1.Controls.Add(this.txtImportQuery);
            this.tabPage1.Controls.Add(this.txtSourceConnectionString);
            this.tabPage1.Controls.Add(this.lblImportQuery);
            this.tabPage1.Controls.Add(this.lblDestinationConnectionString);
            this.tabPage1.Controls.Add(this.txtDestinationConnectionString);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.progressBarUnaltered);
            this.tabPage2.Controls.Add(this.progressBarNew);
            this.tabPage2.Controls.Add(this.progressBarUpdates);
            this.tabPage2.Controls.Add(this.lblStatus);
            this.tabPage2.Controls.Add(this.lblUnalteredCount);
            this.tabPage2.Controls.Add(this.lblUnaltered);
            this.tabPage2.Controls.Add(this.lstUnaltered);
            this.tabPage2.Controls.Add(this.lblNewCount);
            this.tabPage2.Controls.Add(this.lblUpdateCount);
            this.tabPage2.Controls.Add(this.lblNewProducts);
            this.tabPage2.Controls.Add(this.lblUpdates);
            this.tabPage2.Controls.Add(this.lstNew);
            this.tabPage2.Controls.Add(this.lstUpdates);
            this.tabPage2.Controls.Add(this.progressBar);
            this.tabPage2.Controls.Add(this.btnImport);
            this.tabPage2.Controls.Add(this.btnPreview);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Results";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // progressBarUnaltered
            // 
            this.progressBarUnaltered.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarUnaltered.Location = new System.Drawing.Point(7, 85);
            this.progressBarUnaltered.Name = "progressBarUnaltered";
            this.progressBarUnaltered.Size = new System.Drawing.Size(479, 10);
            this.progressBarUnaltered.TabIndex = 15;
            // 
            // progressBarNew
            // 
            this.progressBarNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarNew.Location = new System.Drawing.Point(7, 69);
            this.progressBarNew.Name = "progressBarNew";
            this.progressBarNew.Size = new System.Drawing.Size(479, 10);
            this.progressBarNew.TabIndex = 14;
            // 
            // progressBarUpdates
            // 
            this.progressBarUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarUpdates.Location = new System.Drawing.Point(7, 53);
            this.progressBarUpdates.Name = "progressBarUpdates";
            this.progressBarUpdates.Size = new System.Drawing.Size(479, 10);
            this.progressBarUpdates.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(7, 329);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(477, 23);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Idle";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnalteredCount
            // 
            this.lblUnalteredCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUnalteredCount.Location = new System.Drawing.Point(329, 305);
            this.lblUnalteredCount.Name = "lblUnalteredCount";
            this.lblUnalteredCount.Size = new System.Drawing.Size(155, 23);
            this.lblUnalteredCount.TabIndex = 11;
            // 
            // lblUnaltered
            // 
            this.lblUnaltered.Location = new System.Drawing.Point(329, 92);
            this.lblUnaltered.Name = "lblUnaltered";
            this.lblUnaltered.Size = new System.Drawing.Size(155, 23);
            this.lblUnaltered.TabIndex = 10;
            this.lblUnaltered.Text = "Unaltered Products";
            this.lblUnaltered.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lstUnaltered
            // 
            this.lstUnaltered.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstUnaltered.FormattingEnabled = true;
            this.lstUnaltered.Location = new System.Drawing.Point(329, 118);
            this.lstUnaltered.Name = "lstUnaltered";
            this.lstUnaltered.Size = new System.Drawing.Size(155, 173);
            this.lstUnaltered.TabIndex = 9;
            // 
            // lblNewCount
            // 
            this.lblNewCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNewCount.Location = new System.Drawing.Point(168, 305);
            this.lblNewCount.Name = "lblNewCount";
            this.lblNewCount.Size = new System.Drawing.Size(155, 23);
            this.lblNewCount.TabIndex = 8;
            // 
            // lblUpdateCount
            // 
            this.lblUpdateCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUpdateCount.Location = new System.Drawing.Point(7, 306);
            this.lblUpdateCount.Name = "lblUpdateCount";
            this.lblUpdateCount.Size = new System.Drawing.Size(155, 23);
            this.lblUpdateCount.TabIndex = 7;
            // 
            // lblNewProducts
            // 
            this.lblNewProducts.Location = new System.Drawing.Point(168, 92);
            this.lblNewProducts.Name = "lblNewProducts";
            this.lblNewProducts.Size = new System.Drawing.Size(155, 23);
            this.lblNewProducts.TabIndex = 6;
            this.lblNewProducts.Text = "New Products";
            this.lblNewProducts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblUpdates
            // 
            this.lblUpdates.Location = new System.Drawing.Point(6, 92);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.Size = new System.Drawing.Size(156, 23);
            this.lblUpdates.TabIndex = 5;
            this.lblUpdates.Text = "Updates";
            this.lblUpdates.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lstNew
            // 
            this.lstNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstNew.FormattingEnabled = true;
            this.lstNew.Location = new System.Drawing.Point(168, 118);
            this.lstNew.Name = "lstNew";
            this.lstNew.Size = new System.Drawing.Size(155, 173);
            this.lstNew.TabIndex = 4;
            // 
            // lstUpdates
            // 
            this.lstUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstUpdates.FormattingEnabled = true;
            this.lstUpdates.Location = new System.Drawing.Point(7, 118);
            this.lstUpdates.Name = "lstUpdates";
            this.lstUpdates.Size = new System.Drawing.Size(155, 173);
            this.lstUpdates.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(7, 37);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(479, 10);
            this.progressBar.TabIndex = 2;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(87, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 24);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(6, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 24);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 404);
            this.Controls.Add(this.tabPages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPM Import";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabPages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSourceConnectionString;
        private System.Windows.Forms.TextBox txtSourceConnectionString;
        private System.Windows.Forms.Label lblDestinationConnectionString;
        private System.Windows.Forms.TextBox txtDestinationConnectionString;
        private System.Windows.Forms.Label lblImportQuery;
        private System.Windows.Forms.TextBox txtImportQuery;
        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblNewProducts;
        private System.Windows.Forms.Label lblUpdates;
        private System.Windows.Forms.ListBox lstNew;
        private System.Windows.Forms.ListBox lstUpdates;
        private System.Windows.Forms.Label lblNewCount;
        private System.Windows.Forms.Label lblUpdateCount;
        private System.Windows.Forms.Label lblUnalteredCount;
        private System.Windows.Forms.Label lblUnaltered;
        private System.Windows.Forms.ListBox lstUnaltered;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBarUnaltered;
        private System.Windows.Forms.ProgressBar progressBarNew;
        private System.Windows.Forms.ProgressBar progressBarUpdates;
    }
}

