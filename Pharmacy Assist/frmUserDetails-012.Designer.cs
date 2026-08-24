namespace PharmacyAssist
{
    partial class frmUserDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserDetails));
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lstPermissions = new System.Windows.Forms.ListBox();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.cmbStartPage = new System.Windows.Forms.ComboBox();
            this.lblStartPage = new System.Windows.Forms.Label();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.grpPermissions = new System.Windows.Forms.GroupBox();
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.grpDetails.SuspendLayout();
            this.grpPermissions.SuspendLayout();
            this.gpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(6, 22);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 23);
            this.lblUsername.TabIndex = 9;
            this.lblUsername.Text = "Username";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(6, 48);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(84, 23);
            this.lblFirstName.TabIndex = 10;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(6, 74);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(84, 23);
            this.lblLastName.TabIndex = 11;
            this.lblLastName.Text = "Last Name";
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(6, 100);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 23);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Title";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(96, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(170, 20);
            this.txtUsername.TabIndex = 13;
            // 
            // txtFirstname
            // 
            this.txtFirstname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstname.Enabled = false;
            this.txtFirstname.Location = new System.Drawing.Point(96, 45);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(170, 20);
            this.txtFirstname.TabIndex = 14;
            // 
            // txtLastname
            // 
            this.txtLastname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastname.Enabled = false;
            this.txtLastname.Location = new System.Drawing.Point(96, 71);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(170, 20);
            this.txtLastname.TabIndex = 15;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(96, 97);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(170, 20);
            this.txtTitle.TabIndex = 16;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailAddress.Enabled = false;
            this.txtEmailAddress.Location = new System.Drawing.Point(96, 126);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(170, 20);
            this.txtEmailAddress.TabIndex = 17;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.Location = new System.Drawing.Point(6, 129);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(84, 23);
            this.lblEmailAddress.TabIndex = 18;
            this.lblEmailAddress.Text = "Email Address";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::PharmacyAssist.Properties.Resources.no;
            this.btnCancel.Location = new System.Drawing.Point(215, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Image = global::PharmacyAssist.Properties.Resources.yes;
            this.btnOK.Location = new System.Drawing.Point(134, 305);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 7;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(97, 25);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(180, 42);
            this.lblMessage.TabIndex = 19;
            // 
            // lstPermissions
            // 
            this.lstPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPermissions.FormattingEnabled = true;
            this.lstPermissions.Location = new System.Drawing.Point(6, 18);
            this.lstPermissions.Name = "lstPermissions";
            this.lstPermissions.Size = new System.Drawing.Size(188, 160);
            this.lstPermissions.Sorted = true;
            this.lstPermissions.TabIndex = 20;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.cmbStartPage);
            this.grpDetails.Controls.Add(this.lblStartPage);
            this.grpDetails.Controls.Add(this.cmbStore);
            this.grpDetails.Controls.Add(this.lblStore);
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
            this.grpDetails.Location = new System.Drawing.Point(12, 85);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(276, 212);
            this.grpDetails.TabIndex = 21;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Details";
            // 
            // cmbStartPage
            // 
            this.cmbStartPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartPage.Enabled = false;
            this.cmbStartPage.FormattingEnabled = true;
            this.cmbStartPage.Location = new System.Drawing.Point(96, 180);
            this.cmbStartPage.Name = "cmbStartPage";
            this.cmbStartPage.Size = new System.Drawing.Size(170, 21);
            this.cmbStartPage.TabIndex = 22;
            // 
            // lblStartPage
            // 
            this.lblStartPage.Location = new System.Drawing.Point(6, 183);
            this.lblStartPage.Name = "lblStartPage";
            this.lblStartPage.Size = new System.Drawing.Size(84, 23);
            this.lblStartPage.TabIndex = 21;
            this.lblStartPage.Text = "Start Page";
            // 
            // cmbStore
            // 
            this.cmbStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.Enabled = false;
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Location = new System.Drawing.Point(96, 152);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(170, 21);
            this.cmbStore.TabIndex = 20;
            // 
            // lblStore
            // 
            this.lblStore.Location = new System.Drawing.Point(6, 155);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(84, 23);
            this.lblStore.TabIndex = 19;
            this.lblStore.Text = "Store";
            // 
            // grpPermissions
            // 
            this.grpPermissions.Controls.Add(this.lstPermissions);
            this.grpPermissions.Location = new System.Drawing.Point(402, 59);
            this.grpPermissions.Name = "grpPermissions";
            this.grpPermissions.Size = new System.Drawing.Size(200, 188);
            this.grpPermissions.TabIndex = 22;
            this.grpPermissions.TabStop = false;
            this.grpPermissions.Text = "Permissions";
            // 
            // gpTitle
            // 
            this.gpTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpTitle.BorderColor = System.Drawing.Color.Transparent;
            this.gpTitle.Controls.Add(this.lblMessage);
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
            this.gpTitle.Size = new System.Drawing.Size(280, 67);
            this.gpTitle.TabIndex = 32;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 341);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.grpPermissions);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Account Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUserDetails_FormClosing);
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpPermissions.ResumeLayout(false);
            this.gpTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ListBox lstPermissions;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.GroupBox grpPermissions;
        private System.Windows.Forms.ComboBox cmbStore;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.ComboBox cmbStartPage;
        private System.Windows.Forms.Label lblStartPage;
        private Owf.Controls.GradientPanel gpTitle;
    }
}