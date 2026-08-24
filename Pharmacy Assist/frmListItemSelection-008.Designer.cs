namespace PharmacyAssist
{
    partial class frmListItemSelection008
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListItemSelection008));
            this.lblSelection = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.tips = new System.Windows.Forms.ToolTip(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lstSelection = new System.Windows.Forms.ListBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblDuplicates = new System.Windows.Forms.Label();
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.gpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelection
            // 
            this.lblSelection.BackColor = System.Drawing.Color.Transparent;
            this.lblSelection.Location = new System.Drawing.Point(70, 26);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(567, 18);
            this.lblSelection.TabIndex = 1;
            this.lblSelection.Text = "Select...";
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(12, 98);
            this.lstItems.Name = "lstItems";
            this.lstItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstItems.Size = new System.Drawing.Size(303, 186);
            this.lstItems.Sorted = true;
            this.lstItems.TabIndex = 2;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            this.lstItems.DoubleClick += new System.EventHandler(this.lstItems_DoubleClick);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = global::PharmacyAssist.Properties.Resources.yes;
            this.btnOK.Location = new System.Drawing.Point(496, 319);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 9;
            this.tips.SetToolTip(this.btnOK, "OK");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::PharmacyAssist.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(577, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 10;
            this.tips.SetToolTip(this.btnCancel, "Cancel");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(466, 319);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 11;
            this.tips.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = global::PharmacyAssist.Properties.Resources.arrow_left;
            this.btnRemove.Location = new System.Drawing.Point(321, 128);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 24);
            this.btnRemove.TabIndex = 4;
            this.tips.SetToolTip(this.btnRemove, "Edit");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = global::PharmacyAssist.Properties.Resources.arrow_right;
            this.btnAdd.Location = new System.Drawing.Point(321, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 3;
            this.tips.SetToolTip(this.btnAdd, "Edit");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Image = global::PharmacyAssist.Properties.Resources.edit;
            this.btnEdit.Location = new System.Drawing.Point(15, 322);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(24, 24);
            this.btnEdit.TabIndex = 7;
            this.tips.SetToolTip(this.btnEdit, "Edit list");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lstSelection
            // 
            this.lstSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelection.FormattingEnabled = true;
            this.lstSelection.Location = new System.Drawing.Point(351, 98);
            this.lstSelection.Name = "lstSelection";
            this.lstSelection.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelection.Size = new System.Drawing.Size(301, 212);
            this.lstSelection.Sorted = true;
            this.lstSelection.TabIndex = 6;
            this.lstSelection.SelectedIndexChanged += new System.EventHandler(this.lstSelection_SelectedIndexChanged);
            this.lstSelection.DoubleClick += new System.EventHandler(this.lstSelection_DoubleClick);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilter.Location = new System.Drawing.Point(47, 291);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(268, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 294);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 5;
            this.lblFilter.Text = "Filter";
            // 
            // lblDuplicates
            // 
            this.lblDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuplicates.ForeColor = System.Drawing.Color.Red;
            this.lblDuplicates.Location = new System.Drawing.Point(45, 328);
            this.lblDuplicates.Name = "lblDuplicates";
            this.lblDuplicates.Size = new System.Drawing.Size(316, 18);
            this.lblDuplicates.TabIndex = 8;
            this.lblDuplicates.Text = "The selection list contains duplicates!  Edit the list to correct this.";
            this.lblDuplicates.Visible = false;
            // 
            // gpTitle
            // 
            this.gpTitle.BorderColor = System.Drawing.Color.Transparent;
            this.gpTitle.Controls.Add(this.lblSelection);
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
            this.gpTitle.TabIndex = 12;
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelected.Location = new System.Drawing.Point(351, 79);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(301, 16);
            this.lblSelected.TabIndex = 17;
            this.lblSelected.Text = "Selected";
            this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(12, 79);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(303, 16);
            this.lblSource.TabIndex = 16;
            this.lblSource.Text = "Source";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmListItemSelection008
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(664, 355);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblDuplicates);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstSelection);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(680, 1024);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 352);
            this.Name = "frmListItemSelection008";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Item Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListItemSelection008_FormClosing);
            this.Load += new System.EventHandler(this.frmListItemSelection_Load);
            this.gpTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ToolTip tips;
        private System.Windows.Forms.ListBox lstSelection;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblDuplicates;
        private System.Windows.Forms.Button btnRefresh;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblSource;
    }
}