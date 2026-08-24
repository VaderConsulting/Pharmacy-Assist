namespace PharmacyAssist
{
    partial class frmDocumentInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentInfo));
            this.tabInfo = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.chkFreeService = new System.Windows.Forms.CheckBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.btnCreateDocument = new System.Windows.Forms.Button();
            this.lblNoDocument = new System.Windows.Forms.Label();
            this.picNoDocument = new System.Windows.Forms.PictureBox();
            this.lblPathValue = new System.Windows.Forms.Label();
            this.chkPublic = new System.Windows.Forms.CheckBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtDocumentName = new System.Windows.Forms.TextBox();
            this.picDocument = new System.Windows.Forms.PictureBox();
            this.tabConditions = new System.Windows.Forms.TabPage();
            this.btnRemoveCondition = new System.Windows.Forms.Button();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.lstSourceConditions = new System.Windows.Forms.ListBox();
            this.lstExistingConditions = new System.Windows.Forms.ListBox();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.btnRemoveEvent = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.lstSourceEvents = new System.Windows.Forms.ListBox();
            this.lstExistingEvents = new System.Windows.Forms.ListBox();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.lstSourceTasks = new System.Windows.Forms.ListBox();
            this.lstExistingTasks = new System.Windows.Forms.ListBox();
            this.btnAcceptEdits = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabInfo.SuspendLayout();
            this.tabDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).BeginInit();
            this.tabConditions.SuspendLayout();
            this.tabEvents.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabInfo
            // 
            this.tabInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabInfo.Controls.Add(this.tabDetails);
            this.tabInfo.Controls.Add(this.tabConditions);
            this.tabInfo.Controls.Add(this.tabEvents);
            this.tabInfo.Controls.Add(this.tabTasks);
            this.tabInfo.Location = new System.Drawing.Point(12, 12);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedIndex = 0;
            this.tabInfo.Size = new System.Drawing.Size(353, 257);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.SelectedIndexChanged += new System.EventHandler(this.tabInfo_SelectedIndexChanged);
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.chkFreeService);
            this.tabDetails.Controls.Add(this.txtKeywords);
            this.tabDetails.Controls.Add(this.lblKeywords);
            this.tabDetails.Controls.Add(this.btnCreateDocument);
            this.tabDetails.Controls.Add(this.lblNoDocument);
            this.tabDetails.Controls.Add(this.picNoDocument);
            this.tabDetails.Controls.Add(this.lblPathValue);
            this.tabDetails.Controls.Add(this.chkPublic);
            this.tabDetails.Controls.Add(this.lblPath);
            this.tabDetails.Controls.Add(this.txtDocumentName);
            this.tabDetails.Controls.Add(this.picDocument);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(345, 231);
            this.tabDetails.TabIndex = 1;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // chkFreeService
            // 
            this.chkFreeService.AutoSize = true;
            this.chkFreeService.Enabled = false;
            this.chkFreeService.Location = new System.Drawing.Point(9, 89);
            this.chkFreeService.Name = "chkFreeService";
            this.chkFreeService.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFreeService.Size = new System.Drawing.Size(86, 17);
            this.chkFreeService.TabIndex = 16;
            this.chkFreeService.Text = "Free Service";
            this.chkFreeService.UseVisualStyleBackColor = true;
            // 
            // txtKeywords
            // 
            this.txtKeywords.AcceptsReturn = true;
            this.txtKeywords.Location = new System.Drawing.Point(81, 112);
            this.txtKeywords.Multiline = true;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.ReadOnly = true;
            this.txtKeywords.Size = new System.Drawing.Size(257, 86);
            this.txtKeywords.TabIndex = 15;
            // 
            // lblKeywords
            // 
            this.lblKeywords.Location = new System.Drawing.Point(12, 112);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(58, 18);
            this.lblKeywords.TabIndex = 14;
            this.lblKeywords.Text = "Keywords";
            // 
            // btnCreateDocument
            // 
            this.btnCreateDocument.Image = global::PharmacyAssist.Properties.Resources.database_add;
            this.btnCreateDocument.Location = new System.Drawing.Point(314, 204);
            this.btnCreateDocument.Name = "btnCreateDocument";
            this.btnCreateDocument.Size = new System.Drawing.Size(24, 24);
            this.btnCreateDocument.TabIndex = 13;
            this.toolTips.SetToolTip(this.btnCreateDocument, "Create Database Entry");
            this.btnCreateDocument.UseVisualStyleBackColor = true;
            this.btnCreateDocument.Visible = false;
            this.btnCreateDocument.Click += new System.EventHandler(this.btnCreateDocument_Click);
            // 
            // lblNoDocument
            // 
            this.lblNoDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDocument.ForeColor = System.Drawing.Color.Red;
            this.lblNoDocument.Location = new System.Drawing.Point(81, 210);
            this.lblNoDocument.Name = "lblNoDocument";
            this.lblNoDocument.Size = new System.Drawing.Size(227, 18);
            this.lblNoDocument.TabIndex = 12;
            this.lblNoDocument.Text = "There is no database entry for this file.";
            this.lblNoDocument.Visible = false;
            // 
            // picNoDocument
            // 
            this.picNoDocument.Image = global::PharmacyAssist.Properties.Resources.warning;
            this.picNoDocument.Location = new System.Drawing.Point(22, 26);
            this.picNoDocument.Name = "picNoDocument";
            this.picNoDocument.Size = new System.Drawing.Size(16, 16);
            this.picNoDocument.TabIndex = 11;
            this.picNoDocument.TabStop = false;
            // 
            // lblPathValue
            // 
            this.lblPathValue.Location = new System.Drawing.Point(68, 45);
            this.lblPathValue.Name = "lblPathValue";
            this.lblPathValue.Size = new System.Drawing.Size(270, 18);
            this.lblPathValue.TabIndex = 10;
            // 
            // chkPublic
            // 
            this.chkPublic.AutoSize = true;
            this.chkPublic.Enabled = false;
            this.chkPublic.Location = new System.Drawing.Point(40, 66);
            this.chkPublic.Name = "chkPublic";
            this.chkPublic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPublic.Size = new System.Drawing.Size(55, 17);
            this.chkPublic.TabIndex = 9;
            this.chkPublic.Text = "Public";
            this.chkPublic.UseVisualStyleBackColor = true;
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(6, 45);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(64, 18);
            this.lblPath.TabIndex = 8;
            this.lblPath.Text = "Path:";
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentName.Location = new System.Drawing.Point(81, 18);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.ReadOnly = true;
            this.txtDocumentName.Size = new System.Drawing.Size(257, 20);
            this.txtDocumentName.TabIndex = 7;
            // 
            // picDocument
            // 
            this.picDocument.Image = global::PharmacyAssist.Properties.Resources.supervista_general_book_32;
            this.picDocument.Location = new System.Drawing.Point(6, 6);
            this.picDocument.Name = "picDocument";
            this.picDocument.Size = new System.Drawing.Size(32, 32);
            this.picDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDocument.TabIndex = 6;
            this.picDocument.TabStop = false;
            // 
            // tabConditions
            // 
            this.tabConditions.Controls.Add(this.btnRemoveCondition);
            this.tabConditions.Controls.Add(this.btnAddCondition);
            this.tabConditions.Controls.Add(this.lstSourceConditions);
            this.tabConditions.Controls.Add(this.lstExistingConditions);
            this.tabConditions.Location = new System.Drawing.Point(4, 22);
            this.tabConditions.Name = "tabConditions";
            this.tabConditions.Size = new System.Drawing.Size(345, 231);
            this.tabConditions.TabIndex = 2;
            this.tabConditions.Text = "Conditions";
            this.tabConditions.UseVisualStyleBackColor = true;
            // 
            // btnRemoveCondition
            // 
            this.btnRemoveCondition.Enabled = false;
            this.btnRemoveCondition.Image = global::PharmacyAssist.Properties.Resources.arrow_left;
            this.btnRemoveCondition.Location = new System.Drawing.Point(160, 33);
            this.btnRemoveCondition.Name = "btnRemoveCondition";
            this.btnRemoveCondition.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveCondition.TabIndex = 6;
            this.btnRemoveCondition.UseVisualStyleBackColor = true;
            this.btnRemoveCondition.Click += new System.EventHandler(this.btnRemoveCondition_Click);
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Enabled = false;
            this.btnAddCondition.Image = global::PharmacyAssist.Properties.Resources.arrow_right;
            this.btnAddCondition.Location = new System.Drawing.Point(160, 3);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(24, 24);
            this.btnAddCondition.TabIndex = 5;
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // lstSourceConditions
            // 
            this.lstSourceConditions.FormattingEnabled = true;
            this.lstSourceConditions.Location = new System.Drawing.Point(3, 3);
            this.lstSourceConditions.Name = "lstSourceConditions";
            this.lstSourceConditions.Size = new System.Drawing.Size(151, 225);
            this.lstSourceConditions.Sorted = true;
            this.lstSourceConditions.TabIndex = 1;
            this.lstSourceConditions.SelectedIndexChanged += new System.EventHandler(this.lstSourceConditions_SelectedIndexChanged);
            this.lstSourceConditions.DoubleClick += new System.EventHandler(this.lstSourceConditions_DoubleClick);
            // 
            // lstExistingConditions
            // 
            this.lstExistingConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstExistingConditions.FormattingEnabled = true;
            this.lstExistingConditions.Location = new System.Drawing.Point(190, 3);
            this.lstExistingConditions.Name = "lstExistingConditions";
            this.lstExistingConditions.Size = new System.Drawing.Size(151, 225);
            this.lstExistingConditions.Sorted = true;
            this.lstExistingConditions.TabIndex = 0;
            this.lstExistingConditions.SelectedIndexChanged += new System.EventHandler(this.lstExistingConditions_SelectedIndexChanged);
            this.lstExistingConditions.DoubleClick += new System.EventHandler(this.lstExistingConditions_DoubleClick);
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.btnRemoveEvent);
            this.tabEvents.Controls.Add(this.btnAddEvent);
            this.tabEvents.Controls.Add(this.lstSourceEvents);
            this.tabEvents.Controls.Add(this.lstExistingEvents);
            this.tabEvents.Location = new System.Drawing.Point(4, 22);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Size = new System.Drawing.Size(345, 231);
            this.tabEvents.TabIndex = 3;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // btnRemoveEvent
            // 
            this.btnRemoveEvent.Enabled = false;
            this.btnRemoveEvent.Image = global::PharmacyAssist.Properties.Resources.arrow_left;
            this.btnRemoveEvent.Location = new System.Drawing.Point(160, 33);
            this.btnRemoveEvent.Name = "btnRemoveEvent";
            this.btnRemoveEvent.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveEvent.TabIndex = 8;
            this.btnRemoveEvent.UseVisualStyleBackColor = true;
            this.btnRemoveEvent.Click += new System.EventHandler(this.btnRemoveEvent_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Enabled = false;
            this.btnAddEvent.Image = global::PharmacyAssist.Properties.Resources.arrow_right;
            this.btnAddEvent.Location = new System.Drawing.Point(160, 3);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(24, 24);
            this.btnAddEvent.TabIndex = 7;
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // lstSourceEvents
            // 
            this.lstSourceEvents.FormattingEnabled = true;
            this.lstSourceEvents.Location = new System.Drawing.Point(3, 3);
            this.lstSourceEvents.Name = "lstSourceEvents";
            this.lstSourceEvents.Size = new System.Drawing.Size(151, 225);
            this.lstSourceEvents.Sorted = true;
            this.lstSourceEvents.TabIndex = 2;
            this.lstSourceEvents.SelectedIndexChanged += new System.EventHandler(this.lstSourceEvents_SelectedIndexChanged);
            this.lstSourceEvents.DoubleClick += new System.EventHandler(this.lstSourceEvents_DoubleClick);
            // 
            // lstExistingEvents
            // 
            this.lstExistingEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstExistingEvents.FormattingEnabled = true;
            this.lstExistingEvents.Location = new System.Drawing.Point(190, 3);
            this.lstExistingEvents.Name = "lstExistingEvents";
            this.lstExistingEvents.Size = new System.Drawing.Size(151, 225);
            this.lstExistingEvents.Sorted = true;
            this.lstExistingEvents.TabIndex = 1;
            this.lstExistingEvents.SelectedIndexChanged += new System.EventHandler(this.lstExistingEvents_SelectedIndexChanged);
            this.lstExistingEvents.DoubleClick += new System.EventHandler(this.lstExistingEvents_DoubleClick);
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.btnRemoveTask);
            this.tabTasks.Controls.Add(this.btnAddTask);
            this.tabTasks.Controls.Add(this.lstSourceTasks);
            this.tabTasks.Controls.Add(this.lstExistingTasks);
            this.tabTasks.Location = new System.Drawing.Point(4, 22);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Size = new System.Drawing.Size(345, 231);
            this.tabTasks.TabIndex = 4;
            this.tabTasks.Text = "Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Enabled = false;
            this.btnRemoveTask.Image = global::PharmacyAssist.Properties.Resources.arrow_left;
            this.btnRemoveTask.Location = new System.Drawing.Point(160, 33);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveTask.TabIndex = 8;
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Enabled = false;
            this.btnAddTask.Image = global::PharmacyAssist.Properties.Resources.arrow_right;
            this.btnAddTask.Location = new System.Drawing.Point(160, 3);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(24, 24);
            this.btnAddTask.TabIndex = 7;
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // lstSourceTasks
            // 
            this.lstSourceTasks.FormattingEnabled = true;
            this.lstSourceTasks.Location = new System.Drawing.Point(3, 3);
            this.lstSourceTasks.Name = "lstSourceTasks";
            this.lstSourceTasks.Size = new System.Drawing.Size(151, 225);
            this.lstSourceTasks.Sorted = true;
            this.lstSourceTasks.TabIndex = 2;
            this.lstSourceTasks.SelectedIndexChanged += new System.EventHandler(this.lstSourceTasks_SelectedIndexChanged);
            this.lstSourceTasks.DoubleClick += new System.EventHandler(this.lstSourceTasks_DoubleClick);
            // 
            // lstExistingTasks
            // 
            this.lstExistingTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstExistingTasks.FormattingEnabled = true;
            this.lstExistingTasks.Location = new System.Drawing.Point(190, 3);
            this.lstExistingTasks.Name = "lstExistingTasks";
            this.lstExistingTasks.Size = new System.Drawing.Size(151, 225);
            this.lstExistingTasks.Sorted = true;
            this.lstExistingTasks.TabIndex = 1;
            this.lstExistingTasks.SelectedIndexChanged += new System.EventHandler(this.lstExistingTasks_SelectedIndexChanged);
            this.lstExistingTasks.DoubleClick += new System.EventHandler(this.lstExistingTasks_DoubleClick);
            // 
            // btnAcceptEdits
            // 
            this.btnAcceptEdits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptEdits.Enabled = false;
            this.btnAcceptEdits.Image = global::PharmacyAssist.Properties.Resources.yes;
            this.btnAcceptEdits.Location = new System.Drawing.Point(206, 275);
            this.btnAcceptEdits.Name = "btnAcceptEdits";
            this.btnAcceptEdits.Size = new System.Drawing.Size(75, 24);
            this.btnAcceptEdits.TabIndex = 18;
            this.btnAcceptEdits.UseVisualStyleBackColor = true;
            this.btnAcceptEdits.Click += new System.EventHandler(this.btnAcceptEdits_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelEdit.Image = global::PharmacyAssist.Properties.Resources.no;
            this.btnCancelEdit.Location = new System.Drawing.Point(290, 275);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(75, 24);
            this.btnCancelEdit.TabIndex = 19;
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(176, 275);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 285);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(158, 23);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Idle";
            // 
            // frmDocumentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 311);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAcceptEdits);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.tabInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(393, 350);
            this.Name = "frmDocumentInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Information";
            this.Load += new System.EventHandler(this.frmDocumentInfo_Load);
            this.tabInfo.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).EndInit();
            this.tabConditions.ResumeLayout(false);
            this.tabEvents.ResumeLayout(false);
            this.tabTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabInfo;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabConditions;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.Label lblPathValue;
        private System.Windows.Forms.CheckBox chkPublic;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtDocumentName;
        private System.Windows.Forms.PictureBox picDocument;
        private System.Windows.Forms.Button btnAcceptEdits;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.ListBox lstExistingConditions;
        private System.Windows.Forms.ListBox lstExistingEvents;
        private System.Windows.Forms.ListBox lstExistingTasks;
        private System.Windows.Forms.ListBox lstSourceConditions;
        private System.Windows.Forms.Button btnRemoveCondition;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Button btnRemoveEvent;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.ListBox lstSourceEvents;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ListBox lstSourceTasks;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox picNoDocument;
        private System.Windows.Forms.Button btnCreateDocument;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Label lblNoDocument;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.CheckBox chkFreeService;
        private System.Windows.Forms.Label lblStatus;
    }
}