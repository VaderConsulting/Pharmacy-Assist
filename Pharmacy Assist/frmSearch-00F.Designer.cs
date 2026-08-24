namespace PharmacyAssist
{
    partial class frmSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSearchTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripClearSearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFirstButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripPreviousButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripRecordInfo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripNextButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLastButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.ConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SearchCountdown = new System.Windows.Forms.ToolStripProgressBar();
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.stsStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripSearchTextbox,
            this.toolStripClearSearchButton,
            this.toolStripSearchButton,
            this.toolStripSeparator1,
            this.toolStripFirstButton,
            this.toolStripPreviousButton,
            this.toolStripRecordInfo,
            this.toolStripNextButton,
            this.toolStripLastButton,
            this.toolStripSeparator3});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1273, 39);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMain_ItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSearchTextbox
            // 
            this.toolStripSearchTextbox.AcceptsReturn = true;
            this.toolStripSearchTextbox.AutoSize = false;
            this.toolStripSearchTextbox.Enabled = false;
            this.toolStripSearchTextbox.Name = "toolStripSearchTextbox";
            this.toolStripSearchTextbox.Size = new System.Drawing.Size(150, 25);
            this.toolStripSearchTextbox.ToolTipText = "Search string";
            this.toolStripSearchTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripSearchTextbox_KeyDown);
            this.toolStripSearchTextbox.TextChanged += new System.EventHandler(this.toolStripSearchTextbox_TextChanged);
            // 
            // toolStripClearSearchButton
            // 
            this.toolStripClearSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripClearSearchButton.Enabled = false;
            this.toolStripClearSearchButton.Image = global::PharmacyAssist.Properties.Resources.realvista_general_cross_32;
            this.toolStripClearSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClearSearchButton.Name = "toolStripClearSearchButton";
            this.toolStripClearSearchButton.Size = new System.Drawing.Size(36, 36);
            this.toolStripClearSearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripClearSearchButton.ToolTipText = "Clear search";
            this.toolStripClearSearchButton.Click += new System.EventHandler(this.toolStripClearSearchButton_Click);
            // 
            // toolStripSearchButton
            // 
            this.toolStripSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSearchButton.Enabled = false;
            this.toolStripSearchButton.Image = global::PharmacyAssist.Properties.Resources.realvista_general_zoom_32;
            this.toolStripSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSearchButton.Name = "toolStripSearchButton";
            this.toolStripSearchButton.Size = new System.Drawing.Size(36, 36);
            this.toolStripSearchButton.Text = "Search";
            this.toolStripSearchButton.Click += new System.EventHandler(this.toolStripSearchButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripFirstButton
            // 
            this.toolStripFirstButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFirstButton.Enabled = false;
            this.toolStripFirstButton.Image = global::PharmacyAssist.Properties.Resources.realvista_general_first_32;
            this.toolStripFirstButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFirstButton.Name = "toolStripFirstButton";
            this.toolStripFirstButton.Size = new System.Drawing.Size(36, 36);
            this.toolStripFirstButton.Text = "toolStripButton1";
            this.toolStripFirstButton.ToolTipText = "First page";
            this.toolStripFirstButton.Click += new System.EventHandler(this.toolStripFirstButton_Click);
            // 
            // toolStripPreviousButton
            // 
            this.toolStripPreviousButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPreviousButton.Enabled = false;
            this.toolStripPreviousButton.Image = global::PharmacyAssist.Properties.Resources.realvista_general_rewinding_32;
            this.toolStripPreviousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPreviousButton.Name = "toolStripPreviousButton";
            this.toolStripPreviousButton.Size = new System.Drawing.Size(36, 36);
            this.toolStripPreviousButton.Text = "toolStripButton1";
            this.toolStripPreviousButton.ToolTipText = "Previous page";
            this.toolStripPreviousButton.Click += new System.EventHandler(this.toolStripPreviousButton_Click);
            // 
            // toolStripRecordInfo
            // 
            this.toolStripRecordInfo.AutoSize = false;
            this.toolStripRecordInfo.Name = "toolStripRecordInfo";
            this.toolStripRecordInfo.Size = new System.Drawing.Size(120, 22);
            this.toolStripRecordInfo.Text = "No records";
            // 
            // toolStripNextButton
            // 
            this.toolStripNextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripNextButton.Enabled = false;
            this.toolStripNextButton.Image = global::PharmacyAssist.Properties.Resources.realvista_general_fast_forward_32;
            this.toolStripNextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNextButton.Name = "toolStripNextButton";
            this.toolStripNextButton.Size = new System.Drawing.Size(36, 36);
            this.toolStripNextButton.Text = "toolStripButton1";
            this.toolStripNextButton.ToolTipText = "Next page";
            this.toolStripNextButton.Click += new System.EventHandler(this.toolStripNextButton_Click);
            // 
            // toolStripLastButton
            // 
            this.toolStripLastButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLastButton.Enabled = false;
            this.toolStripLastButton.Image = global::PharmacyAssist.Properties.Resources.realvista_general_last_32;
            this.toolStripLastButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLastButton.Name = "toolStripLastButton";
            this.toolStripLastButton.Size = new System.Drawing.Size(36, 36);
            this.toolStripLastButton.Text = "toolStripButton1";
            this.toolStripLastButton.ToolTipText = "Last page";
            this.toolStripLastButton.Click += new System.EventHandler(this.toolStripLastButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToOrderColumns = true;
            this.dgvProducts.AllowUserToResizeColumns = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.Location = new System.Drawing.Point(12, 42);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(1249, 450);
            this.dgvProducts.TabIndex = 3;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            this.dgvProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellEndEdit);
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionStatus,
            this.StatusLabel,
            this.SearchCountdown});
            this.stsStatus.Location = new System.Drawing.Point(0, 495);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(1273, 22);
            this.stsStatus.TabIndex = 4;
            this.stsStatus.Text = "Status";
            // 
            // ConnectionStatus
            // 
            this.ConnectionStatus.AutoSize = false;
            this.ConnectionStatus.Name = "ConnectionStatus";
            this.ConnectionStatus.Size = new System.Drawing.Size(120, 17);
            this.ConnectionStatus.Text = "Disconnected";
            this.ConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = false;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(250, 17);
            this.StatusLabel.Text = "Idle";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchCountdown
            // 
            this.SearchCountdown.Name = "SearchCountdown";
            this.SearchCountdown.Size = new System.Drawing.Size(100, 16);
            this.SearchCountdown.Visible = false;
            // 
            // imlMain
            // 
            this.imlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMain.ImageStream")));
            this.imlMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMain.Images.SetKeyName(0, "disconnect.png");
            this.imlMain.Images.SetKeyName(1, "connect.png");
            this.imlMain.Images.SetKeyName(2, "control_start_blue.png");
            this.imlMain.Images.SetKeyName(3, "control_rewind_blue.png");
            this.imlMain.Images.SetKeyName(4, "control_fastforward_blue.png");
            this.imlMain.Images.SetKeyName(5, "control_end_blue.png");
            this.imlMain.Images.SetKeyName(6, "wrench.png");
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 517);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearch";
            this.Text = "Product Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearch_FormClosing);
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripSearchTextbox;
        private System.Windows.Forms.ToolStripButton toolStripClearSearchButton;
        private System.Windows.Forms.ToolStripButton toolStripSearchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripFirstButton;
        private System.Windows.Forms.ToolStripButton toolStripPreviousButton;
        private System.Windows.Forms.ToolStripLabel toolStripRecordInfo;
        private System.Windows.Forms.ToolStripButton toolStripNextButton;
        private System.Windows.Forms.ToolStripButton toolStripLastButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar SearchCountdown;
        private System.Windows.Forms.ImageList imlMain;
    }
}