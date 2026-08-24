namespace PharmacyAssist
{
    partial class frmOptions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.chkAlwaysDownloadImages = new System.Windows.Forms.CheckBox();
            this.chkEnableRecordPaging = new System.Windows.Forms.CheckBox();
            this.chkSaveConditionsAgainstActiveIngredientOnly = new System.Windows.Forms.CheckBox();
            this.chkSearchAutomatically = new System.Windows.Forms.CheckBox();
            this.clbSearchOptions = new System.Windows.Forms.CheckedListBox();
            this.cmbRecordsPerPage = new System.Windows.Forms.ComboBox();
            this.chkAlwaysAudit = new System.Windows.Forms.CheckBox();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkShowLinkedItemCount = new System.Windows.Forms.CheckBox();
            this.chkEnableSpellCheck = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.chkLoadTaskDataOnDemand = new System.Windows.Forms.CheckBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cmbStartPage = new System.Windows.Forms.ComboBox();
            this.lblStartPage = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.grpEvents = new System.Windows.Forms.GroupBox();
            this.lblDurationDays = new System.Windows.Forms.Label();
            this.lblNotificationDays = new System.Windows.Forms.Label();
            this.txtEventNotification = new System.Windows.Forms.TextBox();
            this.txtEventDuration = new System.Windows.Forms.TextBox();
            this.lblEventNotification = new System.Windows.Forms.Label();
            this.lblEventDuration = new System.Windows.Forms.Label();
            this.grpColours = new System.Windows.Forms.GroupBox();
            this.lblTheme = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvColours = new System.Windows.Forms.DataGridView();
            this.BackColour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForeColour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectionBackColour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectionForeColour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.grpTasks = new System.Windows.Forms.GroupBox();
            this.chkShowTaskStoreName = new System.Windows.Forms.CheckBox();
            this.chkShowCompletedTasks = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaskListPeriodDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTaskNotificationDays = new System.Windows.Forms.Label();
            this.txtTaskNotificationPeriod = new System.Windows.Forms.TextBox();
            this.lblTaskNotification = new System.Windows.Forms.Label();
            this.grpInterface = new System.Windows.Forms.GroupBox();
            this.chkToolbarOnTop = new System.Windows.Forms.CheckBox();
            this.radToolbar = new System.Windows.Forms.RadioButton();
            this.radMDI = new System.Windows.Forms.RadioButton();
            this.radSDI = new System.Windows.Forms.RadioButton();
            this.chkSortMyTasksAlphabetically = new System.Windows.Forms.CheckBox();
            this.grpGeneral.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpEvents.SuspendLayout();
            this.grpColours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColours)).BeginInit();
            this.grpTasks.SuspendLayout();
            this.grpInterface.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAlwaysDownloadImages
            // 
            this.chkAlwaysDownloadImages.AutoSize = true;
            this.chkAlwaysDownloadImages.Location = new System.Drawing.Point(6, 19);
            this.chkAlwaysDownloadImages.Name = "chkAlwaysDownloadImages";
            this.chkAlwaysDownloadImages.Size = new System.Drawing.Size(147, 17);
            this.chkAlwaysDownloadImages.TabIndex = 0;
            this.chkAlwaysDownloadImages.Text = "Always Download Images";
            this.toolTips.SetToolTip(this.chkAlwaysDownloadImages, "Forces the download of images even if the file already exists");
            this.chkAlwaysDownloadImages.UseVisualStyleBackColor = true;
            // 
            // chkEnableRecordPaging
            // 
            this.chkEnableRecordPaging.AutoSize = true;
            this.chkEnableRecordPaging.Location = new System.Drawing.Point(6, 65);
            this.chkEnableRecordPaging.Name = "chkEnableRecordPaging";
            this.chkEnableRecordPaging.Size = new System.Drawing.Size(133, 17);
            this.chkEnableRecordPaging.TabIndex = 1;
            this.chkEnableRecordPaging.Text = "Enable Record Paging";
            this.toolTips.SetToolTip(this.chkEnableRecordPaging, "Provide a limited number of records at a time");
            this.chkEnableRecordPaging.UseVisualStyleBackColor = true;
            this.chkEnableRecordPaging.CheckedChanged += new System.EventHandler(this.chkEnableRecordPaging_CheckedChanged);
            // 
            // chkSaveConditionsAgainstActiveIngredientOnly
            // 
            this.chkSaveConditionsAgainstActiveIngredientOnly.AutoSize = true;
            this.chkSaveConditionsAgainstActiveIngredientOnly.Location = new System.Drawing.Point(6, 138);
            this.chkSaveConditionsAgainstActiveIngredientOnly.Name = "chkSaveConditionsAgainstActiveIngredientOnly";
            this.chkSaveConditionsAgainstActiveIngredientOnly.Size = new System.Drawing.Size(247, 17);
            this.chkSaveConditionsAgainstActiveIngredientOnly.TabIndex = 3;
            this.chkSaveConditionsAgainstActiveIngredientOnly.Text = "Save Conditions against Active Ingredient Only";
            this.toolTips.SetToolTip(this.chkSaveConditionsAgainstActiveIngredientOnly, "Allow or prevent Conditions to be saved against the Product");
            this.chkSaveConditionsAgainstActiveIngredientOnly.UseVisualStyleBackColor = true;
            // 
            // chkSearchAutomatically
            // 
            this.chkSearchAutomatically.AutoSize = true;
            this.chkSearchAutomatically.Location = new System.Drawing.Point(6, 161);
            this.chkSearchAutomatically.Name = "chkSearchAutomatically";
            this.chkSearchAutomatically.Size = new System.Drawing.Size(125, 17);
            this.chkSearchAutomatically.TabIndex = 4;
            this.chkSearchAutomatically.Text = "Search Automatically";
            this.toolTips.SetToolTip(this.chkSearchAutomatically, "Control automatic searching (after 2 second delay)");
            this.chkSearchAutomatically.UseVisualStyleBackColor = true;
            // 
            // clbSearchOptions
            // 
            this.clbSearchOptions.CheckOnClick = true;
            this.clbSearchOptions.FormattingEnabled = true;
            this.clbSearchOptions.Location = new System.Drawing.Point(6, 19);
            this.clbSearchOptions.Name = "clbSearchOptions";
            this.clbSearchOptions.ScrollAlwaysVisible = true;
            this.clbSearchOptions.Size = new System.Drawing.Size(147, 124);
            this.clbSearchOptions.Sorted = true;
            this.clbSearchOptions.TabIndex = 5;
            this.toolTips.SetToolTip(this.clbSearchOptions, "Control what fields are searched");
            // 
            // cmbRecordsPerPage
            // 
            this.cmbRecordsPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecordsPerPage.Enabled = false;
            this.cmbRecordsPerPage.FormattingEnabled = true;
            this.cmbRecordsPerPage.Location = new System.Drawing.Point(18, 88);
            this.cmbRecordsPerPage.Name = "cmbRecordsPerPage";
            this.cmbRecordsPerPage.Size = new System.Drawing.Size(121, 21);
            this.cmbRecordsPerPage.TabIndex = 6;
            // 
            // chkAlwaysAudit
            // 
            this.chkAlwaysAudit.AutoSize = true;
            this.chkAlwaysAudit.Location = new System.Drawing.Point(6, 42);
            this.chkAlwaysAudit.Name = "chkAlwaysAudit";
            this.chkAlwaysAudit.Size = new System.Drawing.Size(86, 17);
            this.chkAlwaysAudit.TabIndex = 10;
            this.chkAlwaysAudit.Text = "Always Audit";
            this.toolTips.SetToolTip(this.chkAlwaysAudit, "Audit all database writes, not just Product price updates");
            this.chkAlwaysAudit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::PharmacyAssist.Properties.Resources.no;
            this.btnCancel.Location = new System.Drawing.Point(487, 471);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 8;
            this.toolTips.SetToolTip(this.btnCancel, "Close");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = global::PharmacyAssist.Properties.Resources.yes;
            this.btnOK.Location = new System.Drawing.Point(406, 471);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 7;
            this.toolTips.SetToolTip(this.btnOK, "Save and close");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkShowLinkedItemCount
            // 
            this.chkShowLinkedItemCount.AutoSize = true;
            this.chkShowLinkedItemCount.Location = new System.Drawing.Point(6, 185);
            this.chkShowLinkedItemCount.Name = "chkShowLinkedItemCount";
            this.chkShowLinkedItemCount.Size = new System.Drawing.Size(142, 17);
            this.chkShowLinkedItemCount.TabIndex = 24;
            this.chkShowLinkedItemCount.Text = "Show Linked Item Count";
            this.toolTips.SetToolTip(this.chkShowLinkedItemCount, "Control automatic searching (after 2 second delay)");
            this.chkShowLinkedItemCount.UseVisualStyleBackColor = true;
            // 
            // chkEnableSpellCheck
            // 
            this.chkEnableSpellCheck.AutoSize = true;
            this.chkEnableSpellCheck.Location = new System.Drawing.Point(6, 115);
            this.chkEnableSpellCheck.Name = "chkEnableSpellCheck";
            this.chkEnableSpellCheck.Size = new System.Drawing.Size(119, 17);
            this.chkEnableSpellCheck.TabIndex = 25;
            this.chkEnableSpellCheck.Text = "Enable Spell Check";
            this.toolTips.SetToolTip(this.chkEnableSpellCheck, "Control automatic searching (after 2 second delay)");
            this.chkEnableSpellCheck.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Image = global::PharmacyAssist.Properties.Resources.xmac_general_refresh_16;
            this.btnReset.Location = new System.Drawing.Point(12, 471);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(24, 24);
            this.btnReset.TabIndex = 39;
            this.toolTips.SetToolTip(this.btnReset, "Reset settings to default");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTheme
            // 
            this.btnTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTheme.Image = global::PharmacyAssist.Properties.Resources.supervista_graphics_color_16;
            this.btnTheme.Location = new System.Drawing.Point(82, 264);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(24, 24);
            this.btnTheme.TabIndex = 2;
            this.toolTips.SetToolTip(this.btnTheme, "View and select full theme colours");
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // chkLoadTaskDataOnDemand
            // 
            this.chkLoadTaskDataOnDemand.AutoSize = true;
            this.chkLoadTaskDataOnDemand.Location = new System.Drawing.Point(6, 250);
            this.chkLoadTaskDataOnDemand.Name = "chkLoadTaskDataOnDemand";
            this.chkLoadTaskDataOnDemand.Size = new System.Drawing.Size(161, 17);
            this.chkLoadTaskDataOnDemand.TabIndex = 26;
            this.chkLoadTaskDataOnDemand.Text = "Load Task Data on Demand";
            this.toolTips.SetToolTip(this.chkLoadTaskDataOnDemand, "Control automatic searching (after 2 second delay)");
            this.chkLoadTaskDataOnDemand.UseVisualStyleBackColor = true;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.chkSortMyTasksAlphabetically);
            this.grpGeneral.Controls.Add(this.chkLoadTaskDataOnDemand);
            this.grpGeneral.Controls.Add(this.chkEnableSpellCheck);
            this.grpGeneral.Controls.Add(this.chkShowLinkedItemCount);
            this.grpGeneral.Controls.Add(this.cmbStartPage);
            this.grpGeneral.Controls.Add(this.lblStartPage);
            this.grpGeneral.Controls.Add(this.chkAlwaysDownloadImages);
            this.grpGeneral.Controls.Add(this.chkAlwaysAudit);
            this.grpGeneral.Controls.Add(this.chkEnableRecordPaging);
            this.grpGeneral.Controls.Add(this.chkSaveConditionsAgainstActiveIngredientOnly);
            this.grpGeneral.Controls.Add(this.chkSearchAutomatically);
            this.grpGeneral.Controls.Add(this.cmbRecordsPerPage);
            this.grpGeneral.Location = new System.Drawing.Point(12, 85);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(256, 303);
            this.grpGeneral.TabIndex = 11;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // cmbStartPage
            // 
            this.cmbStartPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartPage.FormattingEnabled = true;
            this.cmbStartPage.Location = new System.Drawing.Point(18, 223);
            this.cmbStartPage.Name = "cmbStartPage";
            this.cmbStartPage.Size = new System.Drawing.Size(170, 21);
            this.cmbStartPage.TabIndex = 23;
            // 
            // lblStartPage
            // 
            this.lblStartPage.Location = new System.Drawing.Point(6, 205);
            this.lblStartPage.Name = "lblStartPage";
            this.lblStartPage.Size = new System.Drawing.Size(68, 15);
            this.lblStartPage.TabIndex = 13;
            this.lblStartPage.Text = "Start Page";
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.clbSearchOptions);
            this.grpSearch.Location = new System.Drawing.Point(274, 85);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(166, 155);
            this.grpSearch.TabIndex = 12;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search for products on...";
            // 
            // grpEvents
            // 
            this.grpEvents.Controls.Add(this.lblDurationDays);
            this.grpEvents.Controls.Add(this.lblNotificationDays);
            this.grpEvents.Controls.Add(this.txtEventNotification);
            this.grpEvents.Controls.Add(this.txtEventDuration);
            this.grpEvents.Controls.Add(this.lblEventNotification);
            this.grpEvents.Controls.Add(this.lblEventDuration);
            this.grpEvents.Location = new System.Drawing.Point(274, 394);
            this.grpEvents.Name = "grpEvents";
            this.grpEvents.Size = new System.Drawing.Size(164, 67);
            this.grpEvents.TabIndex = 13;
            this.grpEvents.TabStop = false;
            this.grpEvents.Text = "Events";
            // 
            // lblDurationDays
            // 
            this.lblDurationDays.Location = new System.Drawing.Point(116, 16);
            this.lblDurationDays.Name = "lblDurationDays";
            this.lblDurationDays.Size = new System.Drawing.Size(34, 20);
            this.lblDurationDays.TabIndex = 5;
            this.lblDurationDays.Text = "Days";
            this.lblDurationDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotificationDays
            // 
            this.lblNotificationDays.Location = new System.Drawing.Point(116, 39);
            this.lblNotificationDays.Name = "lblNotificationDays";
            this.lblNotificationDays.Size = new System.Drawing.Size(34, 20);
            this.lblNotificationDays.TabIndex = 4;
            this.lblNotificationDays.Text = "Days";
            this.lblNotificationDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEventNotification
            // 
            this.txtEventNotification.Location = new System.Drawing.Point(72, 40);
            this.txtEventNotification.Name = "txtEventNotification";
            this.txtEventNotification.Size = new System.Drawing.Size(38, 20);
            this.txtEventNotification.TabIndex = 3;
            // 
            // txtEventDuration
            // 
            this.txtEventDuration.Location = new System.Drawing.Point(72, 17);
            this.txtEventDuration.Name = "txtEventDuration";
            this.txtEventDuration.Size = new System.Drawing.Size(38, 20);
            this.txtEventDuration.TabIndex = 2;
            // 
            // lblEventNotification
            // 
            this.lblEventNotification.Location = new System.Drawing.Point(6, 38);
            this.lblEventNotification.Name = "lblEventNotification";
            this.lblEventNotification.Size = new System.Drawing.Size(70, 20);
            this.lblEventNotification.TabIndex = 1;
            this.lblEventNotification.Text = "Notification";
            this.lblEventNotification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEventDuration
            // 
            this.lblEventDuration.Location = new System.Drawing.Point(6, 16);
            this.lblEventDuration.Name = "lblEventDuration";
            this.lblEventDuration.Size = new System.Drawing.Size(70, 20);
            this.lblEventDuration.TabIndex = 0;
            this.lblEventDuration.Text = "Duration";
            this.lblEventDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpColours
            // 
            this.grpColours.Controls.Add(this.lblTheme);
            this.grpColours.Controls.Add(this.btnTheme);
            this.grpColours.Controls.Add(this.lblSearch);
            this.grpColours.Controls.Add(this.dgvColours);
            this.grpColours.Location = new System.Drawing.Point(446, 85);
            this.grpColours.Name = "grpColours";
            this.grpColours.Size = new System.Drawing.Size(114, 294);
            this.grpColours.TabIndex = 14;
            this.grpColours.TabStop = false;
            this.grpColours.Text = "Colours";
            // 
            // lblTheme
            // 
            this.lblTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTheme.Location = new System.Drawing.Point(6, 265);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(51, 23);
            this.lblTheme.TabIndex = 3;
            this.lblTheme.Text = "Theme";
            this.lblTheme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(6, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(100, 16);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvColours
            // 
            this.dgvColours.AllowUserToAddRows = false;
            this.dgvColours.AllowUserToDeleteRows = false;
            this.dgvColours.AllowUserToOrderColumns = true;
            this.dgvColours.AllowUserToResizeColumns = false;
            this.dgvColours.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColours.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColours.ColumnHeadersVisible = false;
            this.dgvColours.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BackColour,
            this.ForeColour,
            this.SelectionBackColour,
            this.SelectionForeColour});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColours.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColours.Location = new System.Drawing.Point(6, 32);
            this.dgvColours.MultiSelect = false;
            this.dgvColours.Name = "dgvColours";
            this.dgvColours.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColours.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColours.RowHeadersWidth = 40;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Transparent;
            this.dgvColours.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvColours.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgvColours.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Transparent;
            this.dgvColours.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvColours.Size = new System.Drawing.Size(100, 225);
            this.dgvColours.TabIndex = 0;
            this.dgvColours.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColours_CellClick);
            this.dgvColours.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColours_CellContentClick);
            // 
            // BackColour
            // 
            this.BackColour.HeaderText = "BackColour";
            this.BackColour.Name = "BackColour";
            this.BackColour.ReadOnly = true;
            this.BackColour.Width = 15;
            // 
            // ForeColour
            // 
            this.ForeColour.HeaderText = "ForeColour";
            this.ForeColour.Name = "ForeColour";
            this.ForeColour.ReadOnly = true;
            this.ForeColour.Width = 15;
            // 
            // SelectionBackColour
            // 
            this.SelectionBackColour.HeaderText = "SelectionBackColour";
            this.SelectionBackColour.Name = "SelectionBackColour";
            this.SelectionBackColour.ReadOnly = true;
            this.SelectionBackColour.Width = 15;
            // 
            // SelectionForeColour
            // 
            this.SelectionForeColour.HeaderText = "SelectionForeColour";
            this.SelectionForeColour.Name = "SelectionForeColour";
            this.SelectionForeColour.ReadOnly = true;
            this.SelectionForeColour.Width = 15;
            // 
            // gpTitle
            // 
            this.gpTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpTitle.BorderColor = System.Drawing.Color.Transparent;
            this.gpTitle.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gpTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gpTitle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gpTitle.Image = global::PharmacyAssist.Properties.Resources.realvista_general_gear_256;
            this.gpTitle.ImageLocation = new System.Drawing.Point(2, 2);
            this.gpTitle.ImageSize = new System.Drawing.Point(64, 64);
            this.gpTitle.ImageSizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.gpTitle.Location = new System.Drawing.Point(12, 12);
            this.gpTitle.Name = "gpTitle";
            this.gpTitle.ShadowOffSet = 0;
            this.gpTitle.Size = new System.Drawing.Size(549, 67);
            this.gpTitle.TabIndex = 37;
            // 
            // grpTasks
            // 
            this.grpTasks.Controls.Add(this.chkShowTaskStoreName);
            this.grpTasks.Controls.Add(this.chkShowCompletedTasks);
            this.grpTasks.Controls.Add(this.label1);
            this.grpTasks.Controls.Add(this.txtTaskListPeriodDays);
            this.grpTasks.Controls.Add(this.label2);
            this.grpTasks.Controls.Add(this.lblTaskNotificationDays);
            this.grpTasks.Controls.Add(this.txtTaskNotificationPeriod);
            this.grpTasks.Controls.Add(this.lblTaskNotification);
            this.grpTasks.Location = new System.Drawing.Point(274, 246);
            this.grpTasks.Name = "grpTasks";
            this.grpTasks.Size = new System.Drawing.Size(164, 142);
            this.grpTasks.TabIndex = 14;
            this.grpTasks.TabStop = false;
            this.grpTasks.Text = "Tasks";
            // 
            // chkShowTaskStoreName
            // 
            this.chkShowTaskStoreName.AutoSize = true;
            this.chkShowTaskStoreName.Location = new System.Drawing.Point(6, 96);
            this.chkShowTaskStoreName.Name = "chkShowTaskStoreName";
            this.chkShowTaskStoreName.Size = new System.Drawing.Size(112, 17);
            this.chkShowTaskStoreName.TabIndex = 9;
            this.chkShowTaskStoreName.Text = "Show Store Name";
            this.chkShowTaskStoreName.UseVisualStyleBackColor = true;
            // 
            // chkShowCompletedTasks
            // 
            this.chkShowCompletedTasks.AutoSize = true;
            this.chkShowCompletedTasks.Location = new System.Drawing.Point(6, 73);
            this.chkShowCompletedTasks.Name = "chkShowCompletedTasks";
            this.chkShowCompletedTasks.Size = new System.Drawing.Size(138, 17);
            this.chkShowCompletedTasks.TabIndex = 8;
            this.chkShowCompletedTasks.Text = "Show Completed Tasks";
            this.chkShowCompletedTasks.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(116, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Days";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTaskListPeriodDays
            // 
            this.txtTaskListPeriodDays.Location = new System.Drawing.Point(72, 46);
            this.txtTaskListPeriodDays.Name = "txtTaskListPeriodDays";
            this.txtTaskListPeriodDays.Size = new System.Drawing.Size(38, 20);
            this.txtTaskListPeriodDays.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "List";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTaskNotificationDays
            // 
            this.lblTaskNotificationDays.Location = new System.Drawing.Point(116, 20);
            this.lblTaskNotificationDays.Name = "lblTaskNotificationDays";
            this.lblTaskNotificationDays.Size = new System.Drawing.Size(34, 20);
            this.lblTaskNotificationDays.TabIndex = 4;
            this.lblTaskNotificationDays.Text = "Days";
            this.lblTaskNotificationDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTaskNotificationPeriod
            // 
            this.txtTaskNotificationPeriod.Location = new System.Drawing.Point(72, 20);
            this.txtTaskNotificationPeriod.Name = "txtTaskNotificationPeriod";
            this.txtTaskNotificationPeriod.Size = new System.Drawing.Size(38, 20);
            this.txtTaskNotificationPeriod.TabIndex = 3;
            // 
            // lblTaskNotification
            // 
            this.lblTaskNotification.Location = new System.Drawing.Point(3, 20);
            this.lblTaskNotification.Name = "lblTaskNotification";
            this.lblTaskNotification.Size = new System.Drawing.Size(70, 20);
            this.lblTaskNotification.TabIndex = 1;
            this.lblTaskNotification.Text = "Notification";
            this.lblTaskNotification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpInterface
            // 
            this.grpInterface.Controls.Add(this.chkToolbarOnTop);
            this.grpInterface.Controls.Add(this.radToolbar);
            this.grpInterface.Controls.Add(this.radMDI);
            this.grpInterface.Controls.Add(this.radSDI);
            this.grpInterface.Location = new System.Drawing.Point(12, 394);
            this.grpInterface.Name = "grpInterface";
            this.grpInterface.Size = new System.Drawing.Size(256, 67);
            this.grpInterface.TabIndex = 38;
            this.grpInterface.TabStop = false;
            this.grpInterface.Text = "Interface";
            // 
            // chkToolbarOnTop
            // 
            this.chkToolbarOnTop.AutoSize = true;
            this.chkToolbarOnTop.Location = new System.Drawing.Point(180, 43);
            this.chkToolbarOnTop.Name = "chkToolbarOnTop";
            this.chkToolbarOnTop.Size = new System.Drawing.Size(62, 17);
            this.chkToolbarOnTop.TabIndex = 3;
            this.chkToolbarOnTop.Text = "On Top";
            this.chkToolbarOnTop.UseVisualStyleBackColor = true;
            // 
            // radToolbar
            // 
            this.radToolbar.AutoSize = true;
            this.radToolbar.Location = new System.Drawing.Point(180, 20);
            this.radToolbar.Name = "radToolbar";
            this.radToolbar.Size = new System.Drawing.Size(61, 17);
            this.radToolbar.TabIndex = 2;
            this.radToolbar.Text = "Toolbar";
            this.radToolbar.UseVisualStyleBackColor = true;
            // 
            // radMDI
            // 
            this.radMDI.AutoSize = true;
            this.radMDI.Location = new System.Drawing.Point(94, 20);
            this.radMDI.Name = "radMDI";
            this.radMDI.Size = new System.Drawing.Size(45, 17);
            this.radMDI.TabIndex = 1;
            this.radMDI.Text = "MDI";
            this.radMDI.UseVisualStyleBackColor = true;
            // 
            // radSDI
            // 
            this.radSDI.AutoSize = true;
            this.radSDI.Checked = true;
            this.radSDI.Location = new System.Drawing.Point(9, 20);
            this.radSDI.Name = "radSDI";
            this.radSDI.Size = new System.Drawing.Size(43, 17);
            this.radSDI.TabIndex = 0;
            this.radSDI.TabStop = true;
            this.radSDI.Text = "SDI";
            this.radSDI.UseVisualStyleBackColor = true;
            // 
            // chkSortMyTasksAlphabetically
            // 
            this.chkSortMyTasksAlphabetically.AutoSize = true;
            this.chkSortMyTasksAlphabetically.Location = new System.Drawing.Point(6, 273);
            this.chkSortMyTasksAlphabetically.Name = "chkSortMyTasksAlphabetically";
            this.chkSortMyTasksAlphabetically.Size = new System.Drawing.Size(162, 17);
            this.chkSortMyTasksAlphabetically.TabIndex = 10;
            this.chkSortMyTasksAlphabetically.Text = "Sort My Tasks Alphabetically";
            this.chkSortMyTasksAlphabetically.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 507);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.grpInterface);
            this.Controls.Add(this.grpTasks);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.grpColours);
            this.Controls.Add(this.grpEvents);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptions_FormClosing);
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpEvents.ResumeLayout(false);
            this.grpEvents.PerformLayout();
            this.grpColours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColours)).EndInit();
            this.grpTasks.ResumeLayout(false);
            this.grpTasks.PerformLayout();
            this.grpInterface.ResumeLayout(false);
            this.grpInterface.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAlwaysDownloadImages;
        private System.Windows.Forms.CheckBox chkEnableRecordPaging;
        private System.Windows.Forms.CheckBox chkSaveConditionsAgainstActiveIngredientOnly;
        private System.Windows.Forms.CheckBox chkSearchAutomatically;
        private System.Windows.Forms.CheckedListBox clbSearchOptions;
        private System.Windows.Forms.ComboBox cmbRecordsPerPage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkAlwaysAudit;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblStartPage;
        private System.Windows.Forms.ComboBox cmbStartPage;
        private System.Windows.Forms.GroupBox grpEvents;
        private System.Windows.Forms.Label lblDurationDays;
        private System.Windows.Forms.Label lblNotificationDays;
        private System.Windows.Forms.TextBox txtEventNotification;
        private System.Windows.Forms.TextBox txtEventDuration;
        private System.Windows.Forms.Label lblEventNotification;
        private System.Windows.Forms.Label lblEventDuration;
        private System.Windows.Forms.GroupBox grpColours;
        private System.Windows.Forms.DataGridView dgvColours;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackColour;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForeColour;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionBackColour;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionForeColour;
        private System.Windows.Forms.CheckBox chkShowLinkedItemCount;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.GroupBox grpTasks;
        private System.Windows.Forms.Label lblTaskNotificationDays;
        private System.Windows.Forms.TextBox txtTaskNotificationPeriod;
        private System.Windows.Forms.Label lblTaskNotification;
        private System.Windows.Forms.CheckBox chkEnableSpellCheck;
        private System.Windows.Forms.GroupBox grpInterface;
        private System.Windows.Forms.RadioButton radToolbar;
        private System.Windows.Forms.RadioButton radMDI;
        private System.Windows.Forms.RadioButton radSDI;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox chkToolbarOnTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaskListPeriodDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkShowCompletedTasks;
        private System.Windows.Forms.CheckBox chkShowTaskStoreName;
        private System.Windows.Forms.CheckBox chkLoadTaskDataOnDemand;
        private System.Windows.Forms.CheckBox chkSortMyTasksAlphabetically;
    }
}