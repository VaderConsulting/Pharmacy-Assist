namespace PharmacyAssist
{
    partial class frmTasks010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTasks010));
            this.lblEventName = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblEventDescription = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.dtpTaskDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblEventDue = new System.Windows.Forms.Label();
            this.lblEventCertificate = new System.Windows.Forms.Label();
            this.txtTaskCertificate = new System.Windows.Forms.TextBox();
            this.lblWarningPeriodDays = new System.Windows.Forms.Label();
            this.txtWarningPeriod = new System.Windows.Forms.TextBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnDocuments = new System.Windows.Forms.Button();
            this.btnCertificate = new System.Windows.Forms.Button();
            this.btnStores = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnEditFrequency = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.chkMandatory = new System.Windows.Forms.CheckBox();
            this.chkComplete = new System.Windows.Forms.CheckBox();
            this.btnCopyTask = new System.Windows.Forms.Button();
            this.lblDocuments = new System.Windows.Forms.Label();
            this.txtNextDate = new System.Windows.Forms.TextBox();
            this.lblNextDate = new System.Windows.Forms.Label();
            this.radOnce = new System.Windows.Forms.RadioButton();
            this.radRecurring = new System.Windows.Forms.RadioButton();
            this.grpRecurring = new System.Windows.Forms.GroupBox();
            this.lblStores = new System.Windows.Forms.Label();
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.lstDocuments = new System.Windows.Forms.ListBox();
            this.lblRoles = new System.Windows.Forms.Label();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.txtCompletedBy = new System.Windows.Forms.TextBox();
            this.chkShowCompletedTasks = new System.Windows.Forms.CheckBox();
            this.lvwItems = new System.Windows.Forms.ListView();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.grpRecurring.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEventName
            // 
            this.lblEventName.Location = new System.Drawing.Point(5, 5);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(63, 23);
            this.lblEventName.TabIndex = 25;
            this.lblEventName.Text = "Name";
            this.lblEventName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskName.Enabled = false;
            this.txtTaskName.Location = new System.Drawing.Point(74, 5);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(249, 20);
            this.txtTaskName.TabIndex = 26;
            // 
            // lblEventDescription
            // 
            this.lblEventDescription.Location = new System.Drawing.Point(5, 33);
            this.lblEventDescription.Name = "lblEventDescription";
            this.lblEventDescription.Size = new System.Drawing.Size(63, 23);
            this.lblEventDescription.TabIndex = 27;
            this.lblEventDescription.Text = "Description";
            this.lblEventDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskDescription.Enabled = false;
            this.txtTaskDescription.Location = new System.Drawing.Point(74, 32);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(249, 337);
            this.txtTaskDescription.TabIndex = 28;
            // 
            // dtpTaskDueDate
            // 
            this.dtpTaskDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTaskDueDate.Enabled = false;
            this.dtpTaskDueDate.Location = new System.Drawing.Point(401, 188);
            this.dtpTaskDueDate.Name = "dtpTaskDueDate";
            this.dtpTaskDueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpTaskDueDate.TabIndex = 29;
            // 
            // lblEventDue
            // 
            this.lblEventDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventDue.Location = new System.Drawing.Point(333, 187);
            this.lblEventDue.Name = "lblEventDue";
            this.lblEventDue.Size = new System.Drawing.Size(63, 23);
            this.lblEventDue.TabIndex = 31;
            this.lblEventDue.Text = "Due";
            this.lblEventDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEventCertificate
            // 
            this.lblEventCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventCertificate.Location = new System.Drawing.Point(333, 4);
            this.lblEventCertificate.Name = "lblEventCertificate";
            this.lblEventCertificate.Size = new System.Drawing.Size(63, 23);
            this.lblEventCertificate.TabIndex = 37;
            this.lblEventCertificate.Text = "Certificate";
            this.lblEventCertificate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaskCertificate
            // 
            this.txtTaskCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskCertificate.Enabled = false;
            this.txtTaskCertificate.Location = new System.Drawing.Point(402, 6);
            this.txtTaskCertificate.Name = "txtTaskCertificate";
            this.txtTaskCertificate.ReadOnly = true;
            this.txtTaskCertificate.Size = new System.Drawing.Size(170, 20);
            this.txtTaskCertificate.TabIndex = 38;
            // 
            // lblWarningPeriodDays
            // 
            this.lblWarningPeriodDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarningPeriodDays.Location = new System.Drawing.Point(331, 214);
            this.lblWarningPeriodDays.Name = "lblWarningPeriodDays";
            this.lblWarningPeriodDays.Size = new System.Drawing.Size(65, 20);
            this.lblWarningPeriodDays.TabIndex = 39;
            this.lblWarningPeriodDays.Text = "Notification";
            this.lblWarningPeriodDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWarningPeriod
            // 
            this.txtWarningPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarningPeriod.Enabled = false;
            this.txtWarningPeriod.Location = new System.Drawing.Point(402, 214);
            this.txtWarningPeriod.Name = "txtWarningPeriod";
            this.txtWarningPeriod.Size = new System.Drawing.Size(28, 20);
            this.txtWarningPeriod.TabIndex = 40;
            this.txtWarningPeriod.Text = "14";
            // 
            // lblDays
            // 
            this.lblDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDays.Location = new System.Drawing.Point(436, 213);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(36, 21);
            this.lblDays.TabIndex = 41;
            this.lblDays.Text = "Days";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFrequency
            // 
            this.lblFrequency.Location = new System.Drawing.Point(6, 21);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(82, 20);
            this.lblFrequency.TabIndex = 42;
            this.lblFrequency.Text = "Frequency";
            this.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.Enabled = false;
            this.chkEnabled.Location = new System.Drawing.Point(346, 346);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEnabled.Size = new System.Drawing.Size(68, 24);
            this.chkEnabled.TabIndex = 44;
            this.chkEnabled.Text = "Enabled";
            this.toolTips.SetToolTip(this.chkEnabled, "Enable this Task");
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // btnDocuments
            // 
            this.btnDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocuments.Enabled = false;
            this.btnDocuments.Image = global::PharmacyAssist.Properties.Resources.supervista_general_book_16;
            this.btnDocuments.Location = new System.Drawing.Point(578, 126);
            this.btnDocuments.Name = "btnDocuments";
            this.btnDocuments.Size = new System.Drawing.Size(24, 24);
            this.btnDocuments.TabIndex = 47;
            this.toolTips.SetToolTip(this.btnDocuments, "Select Documents");
            this.btnDocuments.UseVisualStyleBackColor = true;
            this.btnDocuments.Click += new System.EventHandler(this.btnDocuments_Click);
            // 
            // btnCertificate
            // 
            this.btnCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCertificate.Enabled = false;
            this.btnCertificate.Image = global::PharmacyAssist.Properties.Resources.realvista_mobile_certificate_management_16;
            this.btnCertificate.Location = new System.Drawing.Point(578, 5);
            this.btnCertificate.Name = "btnCertificate";
            this.btnCertificate.Size = new System.Drawing.Size(24, 24);
            this.btnCertificate.TabIndex = 47;
            this.toolTips.SetToolTip(this.btnCertificate, "Select Certificate");
            this.btnCertificate.UseVisualStyleBackColor = true;
            this.btnCertificate.Click += new System.EventHandler(this.btnCertificate_Click);
            // 
            // btnStores
            // 
            this.btnStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStores.Enabled = false;
            this.btnStores.Image = global::PharmacyAssist.Properties.Resources.realvista_realestate_drugstore_16;
            this.btnStores.Location = new System.Drawing.Point(577, 96);
            this.btnStores.Name = "btnStores";
            this.btnStores.Size = new System.Drawing.Size(24, 24);
            this.btnStores.TabIndex = 68;
            this.toolTips.SetToolTip(this.btnStores, "Select Stores");
            this.btnStores.UseVisualStyleBackColor = true;
            this.btnStores.Click += new System.EventHandler(this.btnStores_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoles.Enabled = false;
            this.btnRoles.Image = global::PharmacyAssist.Properties.Resources.vista_networking_role_16;
            this.btnRoles.Location = new System.Drawing.Point(578, 33);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(24, 24);
            this.btnRoles.TabIndex = 74;
            this.toolTips.SetToolTip(this.btnRoles, "Select Roles");
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnEditFrequency
            // 
            this.btnEditFrequency.Image = global::PharmacyAssist.Properties.Resources.supervista_general_clock_16;
            this.btnEditFrequency.Location = new System.Drawing.Point(131, 15);
            this.btnEditFrequency.Name = "btnEditFrequency";
            this.btnEditFrequency.Size = new System.Drawing.Size(24, 24);
            this.btnEditFrequency.TabIndex = 52;
            this.toolTips.SetToolTip(this.btnEditFrequency, "Open Recurrance Screen");
            this.btnEditFrequency.UseVisualStyleBackColor = true;
            this.btnEditFrequency.Click += new System.EventHandler(this.btnEditFrequency_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(810, 465);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 24;
            this.toolTips.SetToolTip(this.btnRefresh, "Refresh Tasks");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::PharmacyAssist.Properties.Resources.door_out;
            this.btnClose.Location = new System.Drawing.Point(870, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 8;
            this.toolTips.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::PharmacyAssist.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(840, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.TabIndex = 60;
            this.toolTips.SetToolTip(this.btnSave, "Save the selected Task");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateTask.Enabled = false;
            this.btnCreateTask.Image = global::PharmacyAssist.Properties.Resources.add;
            this.btnCreateTask.Location = new System.Drawing.Point(8, 345);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(24, 24);
            this.btnCreateTask.TabIndex = 64;
            this.toolTips.SetToolTip(this.btnCreateTask, "Create Task");
            this.btnCreateTask.UseVisualStyleBackColor = true;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteTask.Enabled = false;
            this.btnDeleteTask.Image = global::PharmacyAssist.Properties.Resources.minus;
            this.btnDeleteTask.Location = new System.Drawing.Point(38, 345);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteTask.TabIndex = 65;
            this.toolTips.SetToolTip(this.btnDeleteTask, "Delete Task");
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // chkMandatory
            // 
            this.chkMandatory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMandatory.Enabled = false;
            this.chkMandatory.Location = new System.Drawing.Point(489, 345);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMandatory.Size = new System.Drawing.Size(84, 24);
            this.chkMandatory.TabIndex = 75;
            this.chkMandatory.Text = "Mandatory";
            this.toolTips.SetToolTip(this.chkMandatory, "Set this Task as Mandatory");
            this.chkMandatory.UseVisualStyleBackColor = true;
            this.chkMandatory.Visible = false;
            // 
            // chkComplete
            // 
            this.chkComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkComplete.Enabled = false;
            this.chkComplete.Location = new System.Drawing.Point(333, 316);
            this.chkComplete.Name = "chkComplete";
            this.chkComplete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkComplete.Size = new System.Drawing.Size(81, 24);
            this.chkComplete.TabIndex = 76;
            this.chkComplete.Text = "Complete";
            this.toolTips.SetToolTip(this.chkComplete, "If ticked, this Task is Complete");
            this.chkComplete.UseVisualStyleBackColor = true;
            // 
            // btnCopyTask
            // 
            this.btnCopyTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyTask.Enabled = false;
            this.btnCopyTask.Image = global::PharmacyAssist.Properties.Resources.page_copy;
            this.btnCopyTask.Location = new System.Drawing.Point(8, 315);
            this.btnCopyTask.Name = "btnCopyTask";
            this.btnCopyTask.Size = new System.Drawing.Size(24, 24);
            this.btnCopyTask.TabIndex = 77;
            this.toolTips.SetToolTip(this.btnCopyTask, "Copy Task");
            this.btnCopyTask.UseVisualStyleBackColor = true;
            this.btnCopyTask.Click += new System.EventHandler(this.btnCopyTask_Click);
            // 
            // lblDocuments
            // 
            this.lblDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocuments.Location = new System.Drawing.Point(330, 120);
            this.lblDocuments.Name = "lblDocuments";
            this.lblDocuments.Size = new System.Drawing.Size(66, 23);
            this.lblDocuments.TabIndex = 51;
            this.lblDocuments.Text = "Documents";
            this.lblDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNextDate
            // 
            this.txtNextDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNextDate.Location = new System.Drawing.Point(53, 47);
            this.txtNextDate.Name = "txtNextDate";
            this.txtNextDate.Size = new System.Drawing.Size(104, 20);
            this.txtNextDate.TabIndex = 53;
            // 
            // lblNextDate
            // 
            this.lblNextDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextDate.Location = new System.Drawing.Point(6, 45);
            this.lblNextDate.Name = "lblNextDate";
            this.lblNextDate.Size = new System.Drawing.Size(44, 23);
            this.lblNextDate.TabIndex = 54;
            this.lblNextDate.Text = "Next";
            this.lblNextDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radOnce
            // 
            this.radOnce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radOnce.Checked = true;
            this.radOnce.Enabled = false;
            this.radOnce.Location = new System.Drawing.Point(341, 237);
            this.radOnce.Name = "radOnce";
            this.radOnce.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radOnce.Size = new System.Drawing.Size(55, 24);
            this.radOnce.TabIndex = 57;
            this.radOnce.TabStop = true;
            this.radOnce.Text = "Once";
            this.radOnce.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radOnce.UseVisualStyleBackColor = true;
            this.radOnce.CheckedChanged += new System.EventHandler(this.radOnce_CheckedChanged);
            // 
            // radRecurring
            // 
            this.radRecurring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radRecurring.Enabled = false;
            this.radRecurring.Location = new System.Drawing.Point(408, 237);
            this.radRecurring.Name = "radRecurring";
            this.radRecurring.Size = new System.Drawing.Size(78, 24);
            this.radRecurring.TabIndex = 58;
            this.radRecurring.Text = "Recurring";
            this.radRecurring.UseVisualStyleBackColor = true;
            this.radRecurring.CheckedChanged += new System.EventHandler(this.radRecurring_CheckedChanged);
            // 
            // grpRecurring
            // 
            this.grpRecurring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRecurring.Controls.Add(this.lblFrequency);
            this.grpRecurring.Controls.Add(this.btnEditFrequency);
            this.grpRecurring.Controls.Add(this.txtNextDate);
            this.grpRecurring.Controls.Add(this.lblNextDate);
            this.grpRecurring.Enabled = false;
            this.grpRecurring.Location = new System.Drawing.Point(402, 239);
            this.grpRecurring.Name = "grpRecurring";
            this.grpRecurring.Size = new System.Drawing.Size(170, 73);
            this.grpRecurring.TabIndex = 59;
            this.grpRecurring.TabStop = false;
            // 
            // lblStores
            // 
            this.lblStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStores.Location = new System.Drawing.Point(329, 97);
            this.lblStores.Name = "lblStores";
            this.lblStores.Size = new System.Drawing.Size(66, 23);
            this.lblStores.TabIndex = 67;
            this.lblStores.Text = "Store";
            this.lblStores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.gpTitle.Size = new System.Drawing.Size(932, 67);
            this.gpTitle.TabIndex = 70;
            // 
            // lstDocuments
            // 
            this.lstDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDocuments.Enabled = false;
            this.lstDocuments.FormattingEnabled = true;
            this.lstDocuments.Location = new System.Drawing.Point(402, 126);
            this.lstDocuments.Name = "lstDocuments";
            this.lstDocuments.Size = new System.Drawing.Size(170, 56);
            this.lstDocuments.TabIndex = 71;
            // 
            // lblRoles
            // 
            this.lblRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoles.Location = new System.Drawing.Point(330, 33);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(66, 18);
            this.lblRoles.TabIndex = 73;
            this.lblRoles.Text = "Roles";
            this.lblRoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstRoles
            // 
            this.lstRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRoles.Enabled = false;
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(401, 33);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(171, 56);
            this.lstRoles.TabIndex = 71;
            // 
            // txtCompletedBy
            // 
            this.txtCompletedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompletedBy.Location = new System.Drawing.Point(420, 318);
            this.txtCompletedBy.Name = "txtCompletedBy";
            this.txtCompletedBy.ReadOnly = true;
            this.txtCompletedBy.Size = new System.Drawing.Size(152, 20);
            this.txtCompletedBy.TabIndex = 78;
            // 
            // chkShowCompletedTasks
            // 
            this.chkShowCompletedTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowCompletedTasks.AutoSize = true;
            this.chkShowCompletedTasks.Location = new System.Drawing.Point(12, 472);
            this.chkShowCompletedTasks.Name = "chkShowCompletedTasks";
            this.chkShowCompletedTasks.Size = new System.Drawing.Size(138, 17);
            this.chkShowCompletedTasks.TabIndex = 79;
            this.chkShowCompletedTasks.Text = "Show Completed Tasks";
            this.chkShowCompletedTasks.UseVisualStyleBackColor = true;
            this.chkShowCompletedTasks.CheckedChanged += new System.EventHandler(this.chkShowCompletedTasks_CheckedChanged);
            // 
            // lvwItems
            // 
            this.lvwItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvwItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwItems.Location = new System.Drawing.Point(12, 85);
            this.lvwItems.MultiSelect = false;
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(321, 372);
            this.lvwItems.TabIndex = 80;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.Controls.Add(this.txtStore);
            this.pnlInfo.Controls.Add(this.lblEventName);
            this.pnlInfo.Controls.Add(this.txtTaskName);
            this.pnlInfo.Controls.Add(this.lblEventDescription);
            this.pnlInfo.Controls.Add(this.txtCompletedBy);
            this.pnlInfo.Controls.Add(this.radRecurring);
            this.pnlInfo.Controls.Add(this.txtTaskDescription);
            this.pnlInfo.Controls.Add(this.btnCopyTask);
            this.pnlInfo.Controls.Add(this.dtpTaskDueDate);
            this.pnlInfo.Controls.Add(this.chkComplete);
            this.pnlInfo.Controls.Add(this.lblEventDue);
            this.pnlInfo.Controls.Add(this.chkMandatory);
            this.pnlInfo.Controls.Add(this.lblEventCertificate);
            this.pnlInfo.Controls.Add(this.btnRoles);
            this.pnlInfo.Controls.Add(this.txtTaskCertificate);
            this.pnlInfo.Controls.Add(this.lblRoles);
            this.pnlInfo.Controls.Add(this.lblWarningPeriodDays);
            this.pnlInfo.Controls.Add(this.txtWarningPeriod);
            this.pnlInfo.Controls.Add(this.lstRoles);
            this.pnlInfo.Controls.Add(this.lblDays);
            this.pnlInfo.Controls.Add(this.lstDocuments);
            this.pnlInfo.Controls.Add(this.chkEnabled);
            this.pnlInfo.Controls.Add(this.btnCertificate);
            this.pnlInfo.Controls.Add(this.btnStores);
            this.pnlInfo.Controls.Add(this.btnDocuments);
            this.pnlInfo.Controls.Add(this.lblStores);
            this.pnlInfo.Controls.Add(this.lblDocuments);
            this.pnlInfo.Controls.Add(this.btnDeleteTask);
            this.pnlInfo.Controls.Add(this.radOnce);
            this.pnlInfo.Controls.Add(this.btnCreateTask);
            this.pnlInfo.Controls.Add(this.grpRecurring);
            this.pnlInfo.Location = new System.Drawing.Point(339, 85);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(605, 372);
            this.pnlInfo.TabIndex = 81;
            // 
            // txtStore
            // 
            this.txtStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStore.Enabled = false;
            this.txtStore.Location = new System.Drawing.Point(402, 98);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(170, 20);
            this.txtStore.TabIndex = 79;
            // 
            // frmTasks010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 501);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.lvwItems);
            this.Controls.Add(this.chkShowCompletedTasks);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 540);
            this.Name = "frmTasks010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tasks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTasks010_FormClosing);
            this.Load += new System.EventHandler(this.frmTasks010_Load);
            this.grpRecurring.ResumeLayout(false);
            this.grpRecurring.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblEventDescription;
        private System.Windows.Forms.TextBox txtTaskDescription;
        private System.Windows.Forms.DateTimePicker dtpTaskDueDate;
        private System.Windows.Forms.Label lblEventDue;
        private System.Windows.Forms.Label lblEventCertificate;
        private System.Windows.Forms.TextBox txtTaskCertificate;
        private System.Windows.Forms.Label lblWarningPeriodDays;
        private System.Windows.Forms.TextBox txtWarningPeriod;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button btnCertificate;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Label lblDocuments;
        private System.Windows.Forms.Button btnEditFrequency;
        private System.Windows.Forms.TextBox txtNextDate;
        private System.Windows.Forms.Label lblNextDate;
        private System.Windows.Forms.RadioButton radOnce;
        private System.Windows.Forms.RadioButton radRecurring;
        private System.Windows.Forms.GroupBox grpRecurring;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Label lblStores;
        private System.Windows.Forms.Button btnStores;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.ListBox lstDocuments;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.CheckBox chkMandatory;
        private System.Windows.Forms.CheckBox chkComplete;
        private System.Windows.Forms.Button btnCopyTask;
        private System.Windows.Forms.TextBox txtCompletedBy;
        private System.Windows.Forms.CheckBox chkShowCompletedTasks;
        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtStore;
    }
}