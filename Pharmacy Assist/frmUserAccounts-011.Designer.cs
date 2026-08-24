namespace PharmacyAssist
{
    partial class frmUserAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserAccounts));
            this.lstUserAccounts = new System.Windows.Forms.ListBox();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnCheckUsername = new System.Windows.Forms.Button();
            this.btnShowRoles = new System.Windows.Forms.Button();
            this.lstPermissions = new System.Windows.Forms.ListBox();
            this.cmbManager = new System.Windows.Forms.ComboBox();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.lblManager = new System.Windows.Forms.Label();
            this.lblStartPage = new System.Windows.Forms.Label();
            this.cmbStartPage = new System.Windows.Forms.ComboBox();
            this.lblLastLogon = new System.Windows.Forms.Label();
            this.txtLastLogon = new System.Windows.Forms.TextBox();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkMustResetPassword = new System.Windows.Forms.CheckBox();
            this.chkFirstLogon = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.lblRoles = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUserAccounts
            // 
            this.lstUserAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstUserAccounts.FormattingEnabled = true;
            this.lstUserAccounts.Location = new System.Drawing.Point(12, 90);
            this.lstUserAccounts.Name = "lstUserAccounts";
            this.lstUserAccounts.Size = new System.Drawing.Size(92, 446);
            this.lstUserAccounts.Sorted = true;
            this.lstUserAccounts.TabIndex = 0;
            this.lstUserAccounts.SelectedIndexChanged += new System.EventHandler(this.lstUserAccounts_SelectedIndexChanged);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblPassword);
            this.grpDetails.Controls.Add(this.txtPassword);
            this.grpDetails.Controls.Add(this.label1);
            this.grpDetails.Controls.Add(this.txtConfirmPassword);
            this.grpDetails.Controls.Add(this.btnCheckUsername);
            this.grpDetails.Controls.Add(this.btnShowRoles);
            this.grpDetails.Controls.Add(this.lstPermissions);
            this.grpDetails.Controls.Add(this.cmbManager);
            this.grpDetails.Controls.Add(this.lstRoles);
            this.grpDetails.Controls.Add(this.lblManager);
            this.grpDetails.Controls.Add(this.lblStartPage);
            this.grpDetails.Controls.Add(this.cmbStartPage);
            this.grpDetails.Controls.Add(this.lblLastLogon);
            this.grpDetails.Controls.Add(this.txtLastLogon);
            this.grpDetails.Controls.Add(this.cmbStore);
            this.grpDetails.Controls.Add(this.lblStore);
            this.grpDetails.Controls.Add(this.chkEnabled);
            this.grpDetails.Controls.Add(this.chkMustResetPassword);
            this.grpDetails.Controls.Add(this.chkFirstLogon);
            this.grpDetails.Controls.Add(this.btnSave);
            this.grpDetails.Controls.Add(this.lblPermissions);
            this.grpDetails.Controls.Add(this.lblRoles);
            this.grpDetails.Controls.Add(this.lblUsername);
            this.grpDetails.Controls.Add(this.lblFirstName);
            this.grpDetails.Controls.Add(this.lblLastName);
            this.grpDetails.Controls.Add(this.lblEmailAddress);
            this.grpDetails.Controls.Add(this.lblTitle);
            this.grpDetails.Controls.Add(this.txtEmailAddress);
            this.grpDetails.Controls.Add(this.txtUsername);
            this.grpDetails.Controls.Add(this.txtTitle);
            this.grpDetails.Controls.Add(this.txtFirstname);
            this.grpDetails.Controls.Add(this.txtLastname);
            this.grpDetails.Location = new System.Drawing.Point(110, 90);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(484, 402);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Details";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(6, 147);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(110, 23);
            this.lblPassword.TabIndex = 33;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(122, 149);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(162, 20);
            this.txtPassword.TabIndex = 34;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Confirm Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.Enabled = false;
            this.txtConfirmPassword.Location = new System.Drawing.Point(122, 175);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(162, 20);
            this.txtConfirmPassword.TabIndex = 32;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // btnCheckUsername
            // 
            this.btnCheckUsername.Enabled = false;
            this.btnCheckUsername.Image = global::PharmacyAssist.Properties.Resources.user;
            this.btnCheckUsername.Location = new System.Drawing.Point(260, 16);
            this.btnCheckUsername.Name = "btnCheckUsername";
            this.btnCheckUsername.Size = new System.Drawing.Size(24, 24);
            this.btnCheckUsername.TabIndex = 30;
            this.toolTips.SetToolTip(this.btnCheckUsername, "Check Username");
            this.btnCheckUsername.UseVisualStyleBackColor = true;
            this.btnCheckUsername.Click += new System.EventHandler(this.btnCheckUsername_Click);
            // 
            // btnShowRoles
            // 
            this.btnShowRoles.Enabled = false;
            this.btnShowRoles.Image = global::PharmacyAssist.Properties.Resources.vista_networking_role_16;
            this.btnShowRoles.Location = new System.Drawing.Point(454, 149);
            this.btnShowRoles.Name = "btnShowRoles";
            this.btnShowRoles.Size = new System.Drawing.Size(24, 24);
            this.btnShowRoles.TabIndex = 2;
            this.toolTips.SetToolTip(this.btnShowRoles, "Show Roles");
            this.btnShowRoles.UseVisualStyleBackColor = true;
            this.btnShowRoles.Click += new System.EventHandler(this.btnShowRoles_Click);
            // 
            // lstPermissions
            // 
            this.lstPermissions.FormattingEnabled = true;
            this.lstPermissions.Location = new System.Drawing.Point(290, 202);
            this.lstPermissions.Name = "lstPermissions";
            this.lstPermissions.Size = new System.Drawing.Size(188, 160);
            this.lstPermissions.Sorted = true;
            this.lstPermissions.TabIndex = 0;
            // 
            // cmbManager
            // 
            this.cmbManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManager.Enabled = false;
            this.cmbManager.FormattingEnabled = true;
            this.cmbManager.Location = new System.Drawing.Point(122, 281);
            this.cmbManager.Name = "cmbManager";
            this.cmbManager.Size = new System.Drawing.Size(162, 21);
            this.cmbManager.TabIndex = 29;
            // 
            // lstRoles
            // 
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(290, 45);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(188, 95);
            this.lstRoles.Sorted = true;
            this.lstRoles.TabIndex = 1;
            // 
            // lblManager
            // 
            this.lblManager.Location = new System.Drawing.Point(32, 279);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(84, 23);
            this.lblManager.TabIndex = 28;
            this.lblManager.Text = "Manager";
            this.lblManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartPage
            // 
            this.lblStartPage.Location = new System.Drawing.Point(32, 226);
            this.lblStartPage.Name = "lblStartPage";
            this.lblStartPage.Size = new System.Drawing.Size(84, 23);
            this.lblStartPage.TabIndex = 26;
            this.lblStartPage.Text = "Start Page";
            this.lblStartPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbStartPage
            // 
            this.cmbStartPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartPage.Enabled = false;
            this.cmbStartPage.FormattingEnabled = true;
            this.cmbStartPage.Location = new System.Drawing.Point(122, 228);
            this.cmbStartPage.Name = "cmbStartPage";
            this.cmbStartPage.Size = new System.Drawing.Size(162, 21);
            this.cmbStartPage.TabIndex = 25;
            // 
            // lblLastLogon
            // 
            this.lblLastLogon.Location = new System.Drawing.Point(32, 253);
            this.lblLastLogon.Name = "lblLastLogon";
            this.lblLastLogon.Size = new System.Drawing.Size(84, 23);
            this.lblLastLogon.TabIndex = 24;
            this.lblLastLogon.Text = "Last Logon";
            this.lblLastLogon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastLogon
            // 
            this.txtLastLogon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastLogon.Location = new System.Drawing.Point(122, 255);
            this.txtLastLogon.Name = "txtLastLogon";
            this.txtLastLogon.ReadOnly = true;
            this.txtLastLogon.Size = new System.Drawing.Size(162, 20);
            this.txtLastLogon.TabIndex = 23;
            // 
            // cmbStore
            // 
            this.cmbStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.Enabled = false;
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Location = new System.Drawing.Point(122, 201);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(162, 21);
            this.cmbStore.TabIndex = 22;
            // 
            // lblStore
            // 
            this.lblStore.Location = new System.Drawing.Point(32, 199);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(84, 23);
            this.lblStore.TabIndex = 21;
            this.lblStore.Text = "Store";
            this.lblStore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.Enabled = false;
            this.chkEnabled.Location = new System.Drawing.Point(5, 367);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEnabled.Size = new System.Drawing.Size(130, 24);
            this.chkEnabled.TabIndex = 12;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // chkMustResetPassword
            // 
            this.chkMustResetPassword.Enabled = false;
            this.chkMustResetPassword.Location = new System.Drawing.Point(5, 339);
            this.chkMustResetPassword.Name = "chkMustResetPassword";
            this.chkMustResetPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMustResetPassword.Size = new System.Drawing.Size(130, 24);
            this.chkMustResetPassword.TabIndex = 11;
            this.chkMustResetPassword.Text = "Must Reset Password";
            this.chkMustResetPassword.UseVisualStyleBackColor = true;
            // 
            // chkFirstLogon
            // 
            this.chkFirstLogon.Enabled = false;
            this.chkFirstLogon.Location = new System.Drawing.Point(5, 311);
            this.chkFirstLogon.Name = "chkFirstLogon";
            this.chkFirstLogon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFirstLogon.Size = new System.Drawing.Size(130, 24);
            this.chkFirstLogon.TabIndex = 10;
            this.chkFirstLogon.Text = "First Logon";
            this.chkFirstLogon.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::PharmacyAssist.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(454, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.TabIndex = 13;
            this.toolTips.SetToolTip(this.btnSave, "Save Account");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPermissions
            // 
            this.lblPermissions.Location = new System.Drawing.Point(290, 175);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(76, 23);
            this.lblPermissions.TabIndex = 0;
            this.lblPermissions.Text = "Permissions";
            this.lblPermissions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRoles
            // 
            this.lblRoles.Location = new System.Drawing.Point(290, 16);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(46, 23);
            this.lblRoles.TabIndex = 0;
            this.lblRoles.Text = "Roles";
            this.lblRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(6, 19);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(110, 23);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(6, 42);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(110, 23);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(6, 68);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(110, 23);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.Location = new System.Drawing.Point(6, 121);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(110, 23);
            this.lblEmailAddress.TabIndex = 8;
            this.lblEmailAddress.Text = "Email Address";
            this.lblEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(6, 94);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 23);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailAddress.Enabled = false;
            this.txtEmailAddress.Location = new System.Drawing.Point(122, 123);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(162, 20);
            this.txtEmailAddress.TabIndex = 9;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(122, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(132, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(122, 97);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(162, 20);
            this.txtTitle.TabIndex = 7;
            // 
            // txtFirstname
            // 
            this.txtFirstname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstname.Enabled = false;
            this.txtFirstname.Location = new System.Drawing.Point(122, 45);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(162, 20);
            this.txtFirstname.TabIndex = 3;
            // 
            // txtLastname
            // 
            this.txtLastname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastname.Enabled = false;
            this.txtLastname.Location = new System.Drawing.Point(122, 71);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(162, 20);
            this.txtLastname.TabIndex = 5;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateAccount.Enabled = false;
            this.btnCreateAccount.Image = global::PharmacyAssist.Properties.Resources.user_add;
            this.btnCreateAccount.Location = new System.Drawing.Point(140, 513);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(24, 24);
            this.btnCreateAccount.TabIndex = 4;
            this.toolTips.SetToolTip(this.btnCreateAccount, "Create Account");
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAccount.Enabled = false;
            this.btnDeleteAccount.Image = global::PharmacyAssist.Properties.Resources.user_delete;
            this.btnDeleteAccount.Location = new System.Drawing.Point(110, 513);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteAccount.TabIndex = 3;
            this.toolTips.SetToolTip(this.btnDeleteAccount, "Delete Account");
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::PharmacyAssist.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(490, 513);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 5;
            this.toolTips.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::PharmacyAssist.Properties.Resources.door_out;
            this.btnClose.Location = new System.Drawing.Point(520, 513);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 6;
            this.toolTips.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.gpTitle.Size = new System.Drawing.Size(583, 67);
            this.gpTitle.TabIndex = 31;
            // 
            // frmUserAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 549);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnDeleteAccount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.lstUserAccounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(338, 296);
            this.Name = "frmUserAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Accounts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUserAccounts_FormClosing);
            this.Load += new System.EventHandler(this.frmUserAccounts_Load);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUserAccounts;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.ListBox lstPermissions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkMustResetPassword;
        private System.Windows.Forms.CheckBox chkFirstLogon;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.ComboBox cmbStore;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Label lblLastLogon;
        private System.Windows.Forms.TextBox txtLastLogon;
        private System.Windows.Forms.Label lblStartPage;
        private System.Windows.Forms.ComboBox cmbStartPage;
        private System.Windows.Forms.ComboBox cmbManager;
        private System.Windows.Forms.Label lblManager;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.Button btnShowRoles;
        private System.Windows.Forms.Button btnCheckUsername;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
    }
}