namespace PharmacyAssist
{
    partial class frmMyTasks
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
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMyTasks));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnCompleted = new System.Windows.Forms.Button();
            this.btnViewDocument = new System.Windows.Forms.Button();
            this.imlTasks = new System.Windows.Forms.ImageList(this.components);
            this.tabTasks = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabCurrentView = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.calTasks = new System.Windows.Forms.Calendar.Calendar();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lvwTasks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTaskCompleted = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblEventStart = new System.Windows.Forms.Label();
            this.lblEventDescription = new System.Windows.Forms.Label();
            this.txtTaskCertificate = new System.Windows.Forms.TextBox();
            this.lblEventCertificate = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.dtpTaskStart = new System.Windows.Forms.DateTimePicker();
            this.txtNextDate = new System.Windows.Forms.TextBox();
            this.lblDocuments = new System.Windows.Forms.Label();
            this.lblNextDate = new System.Windows.Forms.Label();
            this.lstDocuments = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lvwCompleteTasks = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabTasks.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabCurrentView.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::PharmacyAssist.Properties.Resources.door_out;
            this.btnClose.Location = new System.Drawing.Point(1040, 555);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(1010, 555);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gpTitle
            // 
            this.gpTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpTitle.BorderColor = System.Drawing.Color.Transparent;
            this.gpTitle.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gpTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gpTitle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gpTitle.Image = global::PharmacyAssist.Properties.Resources.realvista_projectmanagment_project_schedule_256;
            this.gpTitle.ImageLocation = new System.Drawing.Point(2, 2);
            this.gpTitle.ImageSize = new System.Drawing.Point(64, 64);
            this.gpTitle.ImageSizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.gpTitle.Location = new System.Drawing.Point(12, 12);
            this.gpTitle.Name = "gpTitle";
            this.gpTitle.ShadowOffSet = 0;
            this.gpTitle.Size = new System.Drawing.Size(1106, 67);
            this.gpTitle.TabIndex = 41;
            // 
            // btnCompleted
            // 
            this.btnCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompleted.Enabled = false;
            this.btnCompleted.Image = global::PharmacyAssist.Properties.Resources.realvista_general_check_mark_16;
            this.btnCompleted.Location = new System.Drawing.Point(129, 386);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(24, 24);
            this.btnCompleted.TabIndex = 125;
            this.toolTips.SetToolTip(this.btnCompleted, "Set Task as completed");
            this.btnCompleted.UseVisualStyleBackColor = true;
            this.btnCompleted.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // btnViewDocument
            // 
            this.btnViewDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewDocument.Enabled = false;
            this.btnViewDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDocument.Image = global::PharmacyAssist.Properties.Resources.book_open;
            this.btnViewDocument.Location = new System.Drawing.Point(673, 387);
            this.btnViewDocument.Name = "btnViewDocument";
            this.btnViewDocument.Size = new System.Drawing.Size(25, 24);
            this.btnViewDocument.TabIndex = 124;
            this.toolTips.SetToolTip(this.btnViewDocument, "View Document");
            this.btnViewDocument.UseVisualStyleBackColor = true;
            this.btnViewDocument.Click += new System.EventHandler(this.btnViewDocument_Click);
            // 
            // imlTasks
            // 
            this.imlTasks.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlTasks.ImageSize = new System.Drawing.Size(16, 16);
            this.imlTasks.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabTasks
            // 
            this.tabTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTasks.Controls.Add(this.tabPage1);
            this.tabTasks.Controls.Add(this.tabPage2);
            this.tabTasks.Location = new System.Drawing.Point(12, 85);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.SelectedIndex = 0;
            this.tabTasks.Size = new System.Drawing.Size(1106, 464);
            this.tabTasks.TabIndex = 114;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1098, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Current";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(9, 6);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabCurrentView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lblTaskCompleted);
            this.splitContainer.Panel2.Controls.Add(this.txtTaskName);
            this.splitContainer.Panel2.Controls.Add(this.lblEventName);
            this.splitContainer.Panel2.Controls.Add(this.lblEventStart);
            this.splitContainer.Panel2.Controls.Add(this.lblEventDescription);
            this.splitContainer.Panel2.Controls.Add(this.txtTaskCertificate);
            this.splitContainer.Panel2.Controls.Add(this.btnCompleted);
            this.splitContainer.Panel2.Controls.Add(this.btnViewDocument);
            this.splitContainer.Panel2.Controls.Add(this.lblEventCertificate);
            this.splitContainer.Panel2.Controls.Add(this.txtTaskDescription);
            this.splitContainer.Panel2.Controls.Add(this.dtpTaskStart);
            this.splitContainer.Panel2.Controls.Add(this.txtNextDate);
            this.splitContainer.Panel2.Controls.Add(this.lblDocuments);
            this.splitContainer.Panel2.Controls.Add(this.lblNextDate);
            this.splitContainer.Panel2.Controls.Add(this.lstDocuments);
            this.splitContainer.Size = new System.Drawing.Size(1087, 414);
            this.splitContainer.SplitterDistance = 379;
            this.splitContainer.TabIndex = 115;
            // 
            // tabCurrentView
            // 
            this.tabCurrentView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCurrentView.Controls.Add(this.tabPage3);
            this.tabCurrentView.Controls.Add(this.tabPage4);
            this.tabCurrentView.Location = new System.Drawing.Point(3, 4);
            this.tabCurrentView.Name = "tabCurrentView";
            this.tabCurrentView.SelectedIndex = 0;
            this.tabCurrentView.Size = new System.Drawing.Size(373, 406);
            this.tabCurrentView.TabIndex = 113;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.calTasks);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(365, 380);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Calendar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // calTasks
            // 
            this.calTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calTasks.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calTasks.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calTasks.Location = new System.Drawing.Point(6, 7);
            this.calTasks.MaximumViewDays = 35;
            this.calTasks.Name = "calTasks";
            this.calTasks.Size = new System.Drawing.Size(353, 367);
            this.calTasks.TabIndex = 0;
            this.calTasks.Text = "calendar1";
            this.calTasks.ItemClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calTasks_ItemClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lvwTasks);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(365, 380);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "List";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lvwTasks
            // 
            this.lvwTasks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvwTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lvwTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTasks.FullRowSelect = true;
            this.lvwTasks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwTasks.HideSelection = false;
            this.lvwTasks.Location = new System.Drawing.Point(6, 3);
            this.lvwTasks.MultiSelect = false;
            this.lvwTasks.Name = "lvwTasks";
            this.lvwTasks.Size = new System.Drawing.Size(356, 374);
            this.lvwTasks.TabIndex = 112;
            this.lvwTasks.UseCompatibleStateImageBehavior = false;
            this.lvwTasks.View = System.Windows.Forms.View.Details;
            this.lvwTasks.SelectedIndexChanged += new System.EventHandler(this.lvwTasks_SelectedIndexChanged);
            this.lvwTasks.Resize += new System.EventHandler(this.lvwTasks_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 355;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Due Date";
            this.columnHeader3.Width = 100;
            // 
            // lblTaskCompleted
            // 
            this.lblTaskCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTaskCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskCompleted.Location = new System.Drawing.Point(6, 387);
            this.lblTaskCompleted.Name = "lblTaskCompleted";
            this.lblTaskCompleted.Size = new System.Drawing.Size(117, 23);
            this.lblTaskCompleted.TabIndex = 128;
            this.lblTaskCompleted.Text = "Task Completed";
            this.lblTaskCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskName.Location = new System.Drawing.Point(129, 3);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.ReadOnly = true;
            this.txtTaskName.Size = new System.Drawing.Size(569, 24);
            this.txtTaskName.TabIndex = 115;
            // 
            // lblEventName
            // 
            this.lblEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.Location = new System.Drawing.Point(21, 4);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(102, 23);
            this.lblEventName.TabIndex = 114;
            this.lblEventName.Text = "Name";
            this.lblEventName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEventStart
            // 
            this.lblEventStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventStart.Location = new System.Drawing.Point(18, 228);
            this.lblEventStart.Name = "lblEventStart";
            this.lblEventStart.Size = new System.Drawing.Size(102, 23);
            this.lblEventStart.TabIndex = 119;
            this.lblEventStart.Text = "Due";
            this.lblEventStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEventDescription
            // 
            this.lblEventDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDescription.Location = new System.Drawing.Point(18, 33);
            this.lblEventDescription.Name = "lblEventDescription";
            this.lblEventDescription.Size = new System.Drawing.Size(102, 23);
            this.lblEventDescription.TabIndex = 116;
            this.lblEventDescription.Text = "Description";
            this.lblEventDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaskCertificate
            // 
            this.txtTaskCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskCertificate.Location = new System.Drawing.Point(129, 257);
            this.txtTaskCertificate.Name = "txtTaskCertificate";
            this.txtTaskCertificate.ReadOnly = true;
            this.txtTaskCertificate.Size = new System.Drawing.Size(569, 24);
            this.txtTaskCertificate.TabIndex = 121;
            // 
            // lblEventCertificate
            // 
            this.lblEventCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventCertificate.Location = new System.Drawing.Point(21, 257);
            this.lblEventCertificate.Name = "lblEventCertificate";
            this.lblEventCertificate.Size = new System.Drawing.Size(99, 23);
            this.lblEventCertificate.TabIndex = 120;
            this.lblEventCertificate.Text = "Certificate";
            this.lblEventCertificate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskDescription.Location = new System.Drawing.Point(129, 33);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.ReadOnly = true;
            this.txtTaskDescription.Size = new System.Drawing.Size(569, 188);
            this.txtTaskDescription.TabIndex = 117;
            // 
            // dtpTaskStart
            // 
            this.dtpTaskStart.Enabled = false;
            this.dtpTaskStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTaskStart.Location = new System.Drawing.Point(129, 226);
            this.dtpTaskStart.Name = "dtpTaskStart";
            this.dtpTaskStart.Size = new System.Drawing.Size(258, 24);
            this.dtpTaskStart.TabIndex = 118;
            // 
            // txtNextDate
            // 
            this.txtNextDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNextDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNextDate.Location = new System.Drawing.Point(440, 226);
            this.txtNextDate.Name = "txtNextDate";
            this.txtNextDate.ReadOnly = true;
            this.txtNextDate.Size = new System.Drawing.Size(258, 24);
            this.txtNextDate.TabIndex = 126;
            // 
            // lblDocuments
            // 
            this.lblDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocuments.Location = new System.Drawing.Point(21, 287);
            this.lblDocuments.Name = "lblDocuments";
            this.lblDocuments.Size = new System.Drawing.Size(99, 23);
            this.lblDocuments.TabIndex = 122;
            this.lblDocuments.Text = "Documents";
            this.lblDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNextDate
            // 
            this.lblNextDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDate.Location = new System.Drawing.Point(373, 227);
            this.lblNextDate.Name = "lblNextDate";
            this.lblNextDate.Size = new System.Drawing.Size(61, 23);
            this.lblNextDate.TabIndex = 127;
            this.lblNextDate.Text = "Next";
            this.lblNextDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstDocuments
            // 
            this.lstDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDocuments.FormattingEnabled = true;
            this.lstDocuments.ItemHeight = 18;
            this.lstDocuments.Location = new System.Drawing.Point(129, 287);
            this.lstDocuments.Name = "lstDocuments";
            this.lstDocuments.Size = new System.Drawing.Size(569, 94);
            this.lstDocuments.TabIndex = 123;
            this.lstDocuments.SelectedIndexChanged += new System.EventHandler(this.lstDocuments_SelectedIndexChanged);
            this.lstDocuments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstDocuments_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnApplyFilter);
            this.tabPage2.Controls.Add(this.chkFilter);
            this.tabPage2.Controls.Add(this.dtpTo);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblFrom);
            this.tabPage2.Controls.Add(this.dtpFrom);
            this.tabPage2.Controls.Add(this.lvwCompleteTasks);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1098, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Image = global::PharmacyAssist.Properties.Resources.yes;
            this.btnApplyFilter.Location = new System.Drawing.Point(578, 6);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(24, 24);
            this.btnApplyFilter.TabIndex = 124;
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // chkFilter
            // 
            this.chkFilter.AutoSize = true;
            this.chkFilter.Location = new System.Drawing.Point(9, 12);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(48, 17);
            this.chkFilter.TabIndex = 123;
            this.chkFilter.Text = "Filter";
            this.chkFilter.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(378, 8);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(194, 20);
            this.dtpTo.TabIndex = 122;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(351, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 121;
            this.label1.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(76, 12);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(45, 16);
            this.lblFrom.TabIndex = 120;
            this.lblFrom.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Location = new System.Drawing.Point(127, 8);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(194, 20);
            this.dtpFrom.TabIndex = 119;
            // 
            // lvwCompleteTasks
            // 
            this.lvwCompleteTasks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvwCompleteTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCompleteTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvwCompleteTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCompleteTasks.FullRowSelect = true;
            this.lvwCompleteTasks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCompleteTasks.HideSelection = false;
            this.lvwCompleteTasks.Location = new System.Drawing.Point(9, 45);
            this.lvwCompleteTasks.MultiSelect = false;
            this.lvwCompleteTasks.Name = "lvwCompleteTasks";
            this.lvwCompleteTasks.Size = new System.Drawing.Size(1077, 387);
            this.lvwCompleteTasks.TabIndex = 113;
            this.lvwCompleteTasks.UseCompatibleStateImageBehavior = false;
            this.lvwCompleteTasks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 125;
            // 
            // frmMyTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 591);
            this.Controls.Add(this.tabTasks);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(990, 576);
            this.Name = "frmMyTasks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Tasks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMyTasks_FormClosing);
            this.Load += new System.EventHandler(this.frmMyTasks_Load);
            this.tabTasks.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.tabCurrentView.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.ListView lvwTasks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imlTasks;
        private System.Windows.Forms.TabControl tabTasks;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblTaskCompleted;
        private System.Windows.Forms.Button btnCompleted;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.TextBox txtNextDate;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.TextBox txtTaskCertificate;
        private System.Windows.Forms.Label lblNextDate;
        private System.Windows.Forms.Label lblEventCertificate;
        private System.Windows.Forms.Label lblEventDescription;
        private System.Windows.Forms.Label lblDocuments;
        private System.Windows.Forms.TextBox txtTaskDescription;
        private System.Windows.Forms.Label lblEventStart;
        private System.Windows.Forms.Button btnViewDocument;
        private System.Windows.Forms.ListBox lstDocuments;
        private System.Windows.Forms.DateTimePicker dtpTaskStart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvwCompleteTasks;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.CheckBox chkFilter;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabControl tabCurrentView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Calendar.Calendar calTasks;

    }
}