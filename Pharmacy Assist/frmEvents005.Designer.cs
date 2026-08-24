namespace PharmacyAssist
{
    partial class frmEvents005
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvents005));
            this.lstItems = new System.Windows.Forms.ListBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.lblEventDescription = new System.Windows.Forms.Label();
            this.txtEventDescription = new System.Windows.Forms.TextBox();
            this.dtpEventStart = new System.Windows.Forms.DateTimePicker();
            this.lblEventStart = new System.Windows.Forms.Label();
            this.lblEventDuration = new System.Windows.Forms.Label();
            this.lblEventOwner = new System.Windows.Forms.Label();
            this.txtEventOwner = new System.Windows.Forms.TextBox();
            this.lblEventType = new System.Windows.Forms.Label();
            this.txtEventType = new System.Windows.Forms.TextBox();
            this.lblEventCertificate = new System.Windows.Forms.Label();
            this.txtEventCertificate = new System.Windows.Forms.TextBox();
            this.lblWarningPeriodDays = new System.Windows.Forms.Label();
            this.txtWarningPeriod = new System.Windows.Forms.TextBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnDocuments = new System.Windows.Forms.Button();
            this.btnCertificate = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.btnOwner = new System.Windows.Forms.Button();
            this.btnEditPresenter = new System.Windows.Forms.Button();
            this.btnStores = new System.Windows.Forms.Button();
            this.btnEditFrequency = new System.Windows.Forms.Button();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.lblDocuments = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtNextDate = new System.Windows.Forms.TextBox();
            this.lblNextDate = new System.Windows.Forms.Label();
            this.txtEventDuration = new System.Windows.Forms.TextBox();
            this.lblDurationDays = new System.Windows.Forms.Label();
            this.radOnce = new System.Windows.Forms.RadioButton();
            this.radRecurring = new System.Windows.Forms.RadioButton();
            this.grpRecurring = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPresenter = new System.Windows.Forms.Label();
            this.txtEventPresenter = new System.Windows.Forms.TextBox();
            this.chkAllowTasks = new System.Windows.Forms.CheckBox();
            this.lblStores = new System.Windows.Forms.Label();
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.lstDocuments = new System.Windows.Forms.ListBox();
            this.lstStores = new System.Windows.Forms.ListBox();
            this.grpRecurring.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(12, 85);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(192, 290);
            this.lstItems.Sorted = true;
            this.lstItems.TabIndex = 10;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // lblEventName
            // 
            this.lblEventName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventName.Location = new System.Drawing.Point(211, 88);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(63, 23);
            this.lblEventName.TabIndex = 25;
            this.lblEventName.Text = "Name";
            this.lblEventName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEventName
            // 
            this.txtEventName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventName.Location = new System.Drawing.Point(280, 88);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(200, 20);
            this.txtEventName.TabIndex = 26;
            // 
            // lblEventDescription
            // 
            this.lblEventDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventDescription.Location = new System.Drawing.Point(211, 114);
            this.lblEventDescription.Name = "lblEventDescription";
            this.lblEventDescription.Size = new System.Drawing.Size(63, 23);
            this.lblEventDescription.TabIndex = 27;
            this.lblEventDescription.Text = "Description";
            this.lblEventDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEventDescription
            // 
            this.txtEventDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventDescription.Location = new System.Drawing.Point(280, 114);
            this.txtEventDescription.Multiline = true;
            this.txtEventDescription.Name = "txtEventDescription";
            this.txtEventDescription.Size = new System.Drawing.Size(200, 114);
            this.txtEventDescription.TabIndex = 28;
            // 
            // dtpEventStart
            // 
            this.dtpEventStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEventStart.Location = new System.Drawing.Point(279, 234);
            this.dtpEventStart.Name = "dtpEventStart";
            this.dtpEventStart.Size = new System.Drawing.Size(200, 20);
            this.dtpEventStart.TabIndex = 29;
            // 
            // lblEventStart
            // 
            this.lblEventStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventStart.Location = new System.Drawing.Point(211, 231);
            this.lblEventStart.Name = "lblEventStart";
            this.lblEventStart.Size = new System.Drawing.Size(63, 23);
            this.lblEventStart.TabIndex = 31;
            this.lblEventStart.Text = "Start";
            this.lblEventStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEventDuration
            // 
            this.lblEventDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventDuration.Location = new System.Drawing.Point(343, 264);
            this.lblEventDuration.Name = "lblEventDuration";
            this.lblEventDuration.Size = new System.Drawing.Size(63, 20);
            this.lblEventDuration.TabIndex = 32;
            this.lblEventDuration.Text = "Duration";
            this.lblEventDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEventOwner
            // 
            this.lblEventOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventOwner.Location = new System.Drawing.Point(501, 86);
            this.lblEventOwner.Name = "lblEventOwner";
            this.lblEventOwner.Size = new System.Drawing.Size(63, 23);
            this.lblEventOwner.TabIndex = 33;
            this.lblEventOwner.Text = "Owner";
            this.lblEventOwner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEventOwner
            // 
            this.txtEventOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventOwner.Location = new System.Drawing.Point(570, 88);
            this.txtEventOwner.Name = "txtEventOwner";
            this.txtEventOwner.ReadOnly = true;
            this.txtEventOwner.Size = new System.Drawing.Size(170, 20);
            this.txtEventOwner.TabIndex = 34;
            // 
            // lblEventType
            // 
            this.lblEventType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventType.Location = new System.Drawing.Point(501, 146);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(63, 23);
            this.lblEventType.TabIndex = 35;
            this.lblEventType.Text = "Type";
            this.lblEventType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEventType
            // 
            this.txtEventType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventType.Location = new System.Drawing.Point(570, 148);
            this.txtEventType.Name = "txtEventType";
            this.txtEventType.ReadOnly = true;
            this.txtEventType.Size = new System.Drawing.Size(170, 20);
            this.txtEventType.TabIndex = 36;
            // 
            // lblEventCertificate
            // 
            this.lblEventCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventCertificate.Location = new System.Drawing.Point(501, 176);
            this.lblEventCertificate.Name = "lblEventCertificate";
            this.lblEventCertificate.Size = new System.Drawing.Size(63, 23);
            this.lblEventCertificate.TabIndex = 37;
            this.lblEventCertificate.Text = "Certificate";
            this.lblEventCertificate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEventCertificate
            // 
            this.txtEventCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventCertificate.Location = new System.Drawing.Point(570, 178);
            this.txtEventCertificate.Name = "txtEventCertificate";
            this.txtEventCertificate.ReadOnly = true;
            this.txtEventCertificate.Size = new System.Drawing.Size(170, 20);
            this.txtEventCertificate.TabIndex = 38;
            // 
            // lblWarningPeriodDays
            // 
            this.lblWarningPeriodDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarningPeriodDays.Location = new System.Drawing.Point(209, 262);
            this.lblWarningPeriodDays.Name = "lblWarningPeriodDays";
            this.lblWarningPeriodDays.Size = new System.Drawing.Size(65, 20);
            this.lblWarningPeriodDays.TabIndex = 39;
            this.lblWarningPeriodDays.Text = "Notification";
            this.lblWarningPeriodDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWarningPeriod
            // 
            this.txtWarningPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarningPeriod.Location = new System.Drawing.Point(280, 264);
            this.txtWarningPeriod.Name = "txtWarningPeriod";
            this.txtWarningPeriod.Size = new System.Drawing.Size(28, 20);
            this.txtWarningPeriod.TabIndex = 40;
            this.txtWarningPeriod.Text = "14";
            // 
            // lblDays
            // 
            this.lblDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDays.Location = new System.Drawing.Point(314, 262);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(36, 21);
            this.lblDays.TabIndex = 41;
            this.lblDays.Text = "Days";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFrequency
            // 
            this.lblFrequency.Location = new System.Drawing.Point(6, 16);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(82, 23);
            this.lblFrequency.TabIndex = 42;
            this.lblFrequency.Text = "Frequency";
            this.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.Location = new System.Drawing.Point(515, 355);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEnabled.Size = new System.Drawing.Size(68, 24);
            this.chkEnabled.TabIndex = 44;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // btnDocuments
            // 
            this.btnDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocuments.Enabled = false;
            this.btnDocuments.Image = global::PharmacyAssist.Properties.Resources.supervista_general_book_16;
            this.btnDocuments.Location = new System.Drawing.Point(747, 280);
            this.btnDocuments.Name = "btnDocuments";
            this.btnDocuments.Size = new System.Drawing.Size(24, 24);
            this.btnDocuments.TabIndex = 47;
            this.toolTips.SetToolTip(this.btnDocuments, "Select Documents");
            this.btnDocuments.UseVisualStyleBackColor = true;
            this.btnDocuments.Click += new System.EventHandler(this.btnDocuments_Click);
            // 
            // btnCertificate
            // 
            this.btnCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCertificate.Enabled = false;
            this.btnCertificate.Image = global::PharmacyAssist.Properties.Resources.realvista_mobile_certificate_management_16;
            this.btnCertificate.Location = new System.Drawing.Point(746, 175);
            this.btnCertificate.Name = "btnCertificate";
            this.btnCertificate.Size = new System.Drawing.Size(24, 24);
            this.btnCertificate.TabIndex = 47;
            this.toolTips.SetToolTip(this.btnCertificate, "Select Certificate");
            this.btnCertificate.UseVisualStyleBackColor = true;
            this.btnCertificate.Click += new System.EventHandler(this.btnCertificate_Click);
            // 
            // btnType
            // 
            this.btnType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnType.Enabled = false;
            this.btnType.Image = global::PharmacyAssist.Properties.Resources.supervista_general_stats_16;
            this.btnType.Location = new System.Drawing.Point(746, 145);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(24, 24);
            this.btnType.TabIndex = 46;
            this.toolTips.SetToolTip(this.btnType, "Select Type");
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btnOwner
            // 
            this.btnOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOwner.Enabled = false;
            this.btnOwner.Image = global::PharmacyAssist.Properties.Resources.windows7_general_group_16;
            this.btnOwner.Location = new System.Drawing.Point(746, 85);
            this.btnOwner.Name = "btnOwner";
            this.btnOwner.Size = new System.Drawing.Size(24, 24);
            this.btnOwner.TabIndex = 45;
            this.toolTips.SetToolTip(this.btnOwner, "Select Owner");
            this.btnOwner.UseVisualStyleBackColor = true;
            this.btnOwner.Click += new System.EventHandler(this.btnOwner_Click);
            // 
            // btnEditPresenter
            // 
            this.btnEditPresenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPresenter.Image = global::PharmacyAssist.Properties.Resources.windows7_general_group_16;
            this.btnEditPresenter.Location = new System.Drawing.Point(746, 115);
            this.btnEditPresenter.Name = "btnEditPresenter";
            this.btnEditPresenter.Size = new System.Drawing.Size(24, 24);
            this.btnEditPresenter.TabIndex = 63;
            this.toolTips.SetToolTip(this.btnEditPresenter, "Select Presenter");
            this.btnEditPresenter.UseVisualStyleBackColor = true;
            this.btnEditPresenter.Click += new System.EventHandler(this.btnEditPresenter_Click);
            // 
            // btnStores
            // 
            this.btnStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStores.Enabled = false;
            this.btnStores.Image = global::PharmacyAssist.Properties.Resources.realvista_realestate_drugstore_16;
            this.btnStores.Location = new System.Drawing.Point(746, 205);
            this.btnStores.Name = "btnStores";
            this.btnStores.Size = new System.Drawing.Size(24, 24);
            this.btnStores.TabIndex = 68;
            this.toolTips.SetToolTip(this.btnStores, "Select Stores");
            this.btnStores.UseVisualStyleBackColor = true;
            this.btnStores.Click += new System.EventHandler(this.btnStores_Click);
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
            // btnCreateEvent
            // 
            this.btnCreateEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateEvent.Image = global::PharmacyAssist.Properties.Resources.add;
            this.btnCreateEvent.Location = new System.Drawing.Point(214, 349);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(24, 24);
            this.btnCreateEvent.TabIndex = 64;
            this.toolTips.SetToolTip(this.btnCreateEvent, "Create Event");
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteEvent.Enabled = false;
            this.btnDeleteEvent.Image = global::PharmacyAssist.Properties.Resources.minus;
            this.btnDeleteEvent.Location = new System.Drawing.Point(244, 349);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteEvent.TabIndex = 65;
            this.toolTips.SetToolTip(this.btnDeleteEvent, "Delete Event");
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // lblDocuments
            // 
            this.lblDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocuments.Location = new System.Drawing.Point(498, 280);
            this.lblDocuments.Name = "lblDocuments";
            this.lblDocuments.Size = new System.Drawing.Size(66, 23);
            this.lblDocuments.TabIndex = 51;
            this.lblDocuments.Text = "Documents";
            this.lblDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(632, 387);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::PharmacyAssist.Properties.Resources.door_out;
            this.btnClose.Location = new System.Drawing.Point(692, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNextDate
            // 
            this.txtNextDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNextDate.Location = new System.Drawing.Point(51, 47);
            this.txtNextDate.Name = "txtNextDate";
            this.txtNextDate.Size = new System.Drawing.Size(104, 20);
            this.txtNextDate.TabIndex = 53;
            // 
            // lblNextDate
            // 
            this.lblNextDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextDate.Location = new System.Drawing.Point(6, 45);
            this.lblNextDate.Name = "lblNextDate";
            this.lblNextDate.Size = new System.Drawing.Size(42, 23);
            this.lblNextDate.TabIndex = 54;
            this.lblNextDate.Text = "Next";
            this.lblNextDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEventDuration
            // 
            this.txtEventDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventDuration.Location = new System.Drawing.Point(412, 265);
            this.txtEventDuration.Name = "txtEventDuration";
            this.txtEventDuration.Size = new System.Drawing.Size(28, 20);
            this.txtEventDuration.TabIndex = 55;
            this.txtEventDuration.Text = "1";
            // 
            // lblDurationDays
            // 
            this.lblDurationDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDurationDays.Location = new System.Drawing.Point(446, 264);
            this.lblDurationDays.Name = "lblDurationDays";
            this.lblDurationDays.Size = new System.Drawing.Size(33, 20);
            this.lblDurationDays.TabIndex = 56;
            this.lblDurationDays.Text = "Days";
            this.lblDurationDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radOnce
            // 
            this.radOnce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radOnce.Checked = true;
            this.radOnce.Location = new System.Drawing.Point(238, 294);
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
            this.radRecurring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radRecurring.Location = new System.Drawing.Point(307, 294);
            this.radRecurring.Name = "radRecurring";
            this.radRecurring.Size = new System.Drawing.Size(78, 24);
            this.radRecurring.TabIndex = 58;
            this.radRecurring.Text = "Recurring";
            this.radRecurring.UseVisualStyleBackColor = true;
            this.radRecurring.CheckedChanged += new System.EventHandler(this.radRecurring_CheckedChanged);
            // 
            // grpRecurring
            // 
            this.grpRecurring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRecurring.Controls.Add(this.lblFrequency);
            this.grpRecurring.Controls.Add(this.btnEditFrequency);
            this.grpRecurring.Controls.Add(this.txtNextDate);
            this.grpRecurring.Controls.Add(this.lblNextDate);
            this.grpRecurring.Enabled = false;
            this.grpRecurring.Location = new System.Drawing.Point(311, 302);
            this.grpRecurring.Name = "grpRecurring";
            this.grpRecurring.Size = new System.Drawing.Size(168, 73);
            this.grpRecurring.TabIndex = 59;
            this.grpRecurring.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::PharmacyAssist.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(662, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.TabIndex = 60;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPresenter
            // 
            this.lblPresenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPresenter.Location = new System.Drawing.Point(501, 116);
            this.lblPresenter.Name = "lblPresenter";
            this.lblPresenter.Size = new System.Drawing.Size(63, 23);
            this.lblPresenter.TabIndex = 61;
            this.lblPresenter.Text = "Presenter";
            this.lblPresenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEventPresenter
            // 
            this.txtEventPresenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventPresenter.Location = new System.Drawing.Point(570, 118);
            this.txtEventPresenter.Name = "txtEventPresenter";
            this.txtEventPresenter.ReadOnly = true;
            this.txtEventPresenter.Size = new System.Drawing.Size(170, 20);
            this.txtEventPresenter.TabIndex = 62;
            // 
            // chkAllowTasks
            // 
            this.chkAllowTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAllowTasks.Location = new System.Drawing.Point(657, 359);
            this.chkAllowTasks.Name = "chkAllowTasks";
            this.chkAllowTasks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAllowTasks.Size = new System.Drawing.Size(83, 17);
            this.chkAllowTasks.TabIndex = 66;
            this.chkAllowTasks.Text = "Allow Tasks";
            this.chkAllowTasks.UseVisualStyleBackColor = true;
            this.chkAllowTasks.Visible = false;
            // 
            // lblStores
            // 
            this.lblStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStores.Location = new System.Drawing.Point(498, 205);
            this.lblStores.Name = "lblStores";
            this.lblStores.Size = new System.Drawing.Size(66, 23);
            this.lblStores.TabIndex = 67;
            this.lblStores.Text = "Stores";
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
            this.gpTitle.Size = new System.Drawing.Size(757, 67);
            this.gpTitle.TabIndex = 70;
            // 
            // lstDocuments
            // 
            this.lstDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDocuments.FormattingEnabled = true;
            this.lstDocuments.Location = new System.Drawing.Point(570, 282);
            this.lstDocuments.Name = "lstDocuments";
            this.lstDocuments.Size = new System.Drawing.Size(170, 69);
            this.lstDocuments.TabIndex = 71;
            // 
            // lstStores
            // 
            this.lstStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStores.FormattingEnabled = true;
            this.lstStores.Location = new System.Drawing.Point(570, 207);
            this.lstStores.Name = "lstStores";
            this.lstStores.Size = new System.Drawing.Size(170, 69);
            this.lstStores.TabIndex = 72;
            // 
            // frmEvents005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 420);
            this.Controls.Add(this.lstStores);
            this.Controls.Add(this.lstDocuments);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.btnStores);
            this.Controls.Add(this.lblStores);
            this.Controls.Add(this.chkAllowTasks);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.btnCreateEvent);
            this.Controls.Add(this.btnEditPresenter);
            this.Controls.Add(this.txtEventPresenter);
            this.Controls.Add(this.lblPresenter);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radRecurring);
            this.Controls.Add(this.grpRecurring);
            this.Controls.Add(this.radOnce);
            this.Controls.Add(this.lblDurationDays);
            this.Controls.Add(this.txtEventDuration);
            this.Controls.Add(this.lblDocuments);
            this.Controls.Add(this.btnDocuments);
            this.Controls.Add(this.btnCertificate);
            this.Controls.Add(this.btnType);
            this.Controls.Add(this.btnOwner);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.txtWarningPeriod);
            this.Controls.Add(this.lblWarningPeriodDays);
            this.Controls.Add(this.txtEventCertificate);
            this.Controls.Add(this.lblEventCertificate);
            this.Controls.Add(this.txtEventType);
            this.Controls.Add(this.lblEventType);
            this.Controls.Add(this.txtEventOwner);
            this.Controls.Add(this.lblEventOwner);
            this.Controls.Add(this.lblEventDuration);
            this.Controls.Add(this.lblEventStart);
            this.Controls.Add(this.dtpEventStart);
            this.Controls.Add(this.txtEventDescription);
            this.Controls.Add(this.lblEventDescription);
            this.Controls.Add(this.txtEventName);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 1024);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(798, 400);
            this.Name = "frmEvents005";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Events";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEvents005_FormClosing);
            this.Load += new System.EventHandler(this.frmEvents_Load);
            this.grpRecurring.ResumeLayout(false);
            this.grpRecurring.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label lblEventDescription;
        private System.Windows.Forms.TextBox txtEventDescription;
        private System.Windows.Forms.DateTimePicker dtpEventStart;
        private System.Windows.Forms.Label lblEventStart;
        private System.Windows.Forms.Label lblEventDuration;
        private System.Windows.Forms.Label lblEventOwner;
        private System.Windows.Forms.TextBox txtEventOwner;
        private System.Windows.Forms.Label lblEventType;
        private System.Windows.Forms.TextBox txtEventType;
        private System.Windows.Forms.Label lblEventCertificate;
        private System.Windows.Forms.TextBox txtEventCertificate;
        private System.Windows.Forms.Label lblWarningPeriodDays;
        private System.Windows.Forms.TextBox txtWarningPeriod;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button btnOwner;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnCertificate;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Label lblDocuments;
        private System.Windows.Forms.Button btnEditFrequency;
        private System.Windows.Forms.TextBox txtNextDate;
        private System.Windows.Forms.Label lblNextDate;
        private System.Windows.Forms.TextBox txtEventDuration;
        private System.Windows.Forms.Label lblDurationDays;
        private System.Windows.Forms.RadioButton radOnce;
        private System.Windows.Forms.RadioButton radRecurring;
        private System.Windows.Forms.GroupBox grpRecurring;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPresenter;
        private System.Windows.Forms.TextBox txtEventPresenter;
        private System.Windows.Forms.Button btnEditPresenter;
        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.CheckBox chkAllowTasks;
        private System.Windows.Forms.Label lblStores;
        private System.Windows.Forms.Button btnStores;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.ListBox lstDocuments;
        private System.Windows.Forms.ListBox lstStores;
    }
}