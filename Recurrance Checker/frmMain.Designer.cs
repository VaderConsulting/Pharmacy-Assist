namespace Recurrance_Checker
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
            this.lblRecurranceValue = new System.Windows.Forms.Label();
            this.txtRecurranceValue = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.txtNextDate = new System.Windows.Forms.TextBox();
            this.lblFrequencyLabel = new System.Windows.Forms.Label();
            this.lblNextDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRecurranceValue
            // 
            this.lblRecurranceValue.Location = new System.Drawing.Point(13, 13);
            this.lblRecurranceValue.Name = "lblRecurranceValue";
            this.lblRecurranceValue.Size = new System.Drawing.Size(100, 17);
            this.lblRecurranceValue.TabIndex = 0;
            this.lblRecurranceValue.Text = "Recurrance Value";
            // 
            // txtRecurranceValue
            // 
            this.txtRecurranceValue.Location = new System.Drawing.Point(120, 13);
            this.txtRecurranceValue.Name = "txtRecurranceValue";
            this.txtRecurranceValue.Size = new System.Drawing.Size(225, 20);
            this.txtRecurranceValue.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(270, 39);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 24);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblFrequency
            // 
            this.lblFrequency.Location = new System.Drawing.Point(117, 111);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(101, 17);
            this.lblFrequency.TabIndex = 3;
            // 
            // txtNextDate
            // 
            this.txtNextDate.Location = new System.Drawing.Point(245, 108);
            this.txtNextDate.Name = "txtNextDate";
            this.txtNextDate.Size = new System.Drawing.Size(100, 20);
            this.txtNextDate.TabIndex = 4;
            // 
            // lblFrequencyLabel
            // 
            this.lblFrequencyLabel.Location = new System.Drawing.Point(117, 88);
            this.lblFrequencyLabel.Name = "lblFrequencyLabel";
            this.lblFrequencyLabel.Size = new System.Drawing.Size(75, 23);
            this.lblFrequencyLabel.TabIndex = 5;
            this.lblFrequencyLabel.Text = "Frequency";
            // 
            // lblNextDate
            // 
            this.lblNextDate.Location = new System.Drawing.Point(245, 88);
            this.lblNextDate.Name = "lblNextDate";
            this.lblNextDate.Size = new System.Drawing.Size(100, 18);
            this.lblNextDate.TabIndex = 6;
            this.lblNextDate.Text = "Next Date";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 140);
            this.Controls.Add(this.lblNextDate);
            this.Controls.Add(this.lblFrequencyLabel);
            this.Controls.Add(this.txtNextDate);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtRecurranceValue);
            this.Controls.Add(this.lblRecurranceValue);
            this.Name = "frmMain";
            this.Text = "Recurrance Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecurranceValue;
        private System.Windows.Forms.TextBox txtRecurranceValue;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.TextBox txtNextDate;
        private System.Windows.Forms.Label lblFrequencyLabel;
        private System.Windows.Forms.Label lblNextDate;
    }
}

