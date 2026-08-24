namespace PharmacyAssist
{
    partial class frmRecurrance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecurrance));
            this.tabRecurrance = new System.Windows.Forms.TabControl();
            this.tabDaily = new System.Windows.Forms.TabPage();
            this.radEveryWeekday = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radEveryXDays = new System.Windows.Forms.RadioButton();
            this.tabWeekly = new System.Windows.Forms.TabPage();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.lblWeeksOn = new System.Windows.Forms.Label();
            this.txtWeeklyRegenXWeeks = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabMonthly = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMonthlyAdjustedValue = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.MonthlySelection2 = new System.Windows.Forms.ComboBox();
            this.MonthlySelection1 = new System.Windows.Forms.ComboBox();
            this.radRecurranceMonths = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.radEveryXMonths = new System.Windows.Forms.RadioButton();
            this.tabYearly = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.txtYearlyAdjustedValue = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.YearlySelection3 = new System.Windows.Forms.ComboBox();
            this.YearlySelection2 = new System.Windows.Forms.ComboBox();
            this.YearlySelection1 = new System.Windows.Forms.ComboBox();
            this.radRecurranceYears = new System.Windows.Forms.RadioButton();
            this.cboYearEveryMonth = new System.Windows.Forms.ComboBox();
            this.txtYearEvery = new System.Windows.Forms.TextBox();
            this.radEveryXYears = new System.Windows.Forms.RadioButton();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.radOccurrences = new System.Windows.Forms.RadioButton();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtOccurrences = new System.Windows.Forms.TextBox();
            this.radEndBy = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGenDates = new System.Windows.Forms.Button();
            this.tabDates = new System.Windows.Forms.TabControl();
            this.tabDefinition = new System.Windows.Forms.TabPage();
            this.radNoEnd = new System.Windows.Forms.RadioButton();
            this.tabValues = new System.Windows.Forms.TabPage();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtNextDate = new System.Windows.Forms.TextBox();
            this.btnGetNextDate = new System.Windows.Forms.Button();
            this.txtSeriesInfo = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.gpTitle = new Owf.Controls.GradientPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabRecurrance.SuspendLayout();
            this.tabDaily.SuspendLayout();
            this.tabWeekly.SuspendLayout();
            this.tabMonthly.SuspendLayout();
            this.tabYearly.SuspendLayout();
            this.tabDates.SuspendLayout();
            this.tabDefinition.SuspendLayout();
            this.tabValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabRecurrance
            // 
            this.tabRecurrance.Controls.Add(this.tabDaily);
            this.tabRecurrance.Controls.Add(this.tabWeekly);
            this.tabRecurrance.Controls.Add(this.tabMonthly);
            this.tabRecurrance.Controls.Add(this.tabYearly);
            this.tabRecurrance.Location = new System.Drawing.Point(6, 6);
            this.tabRecurrance.Name = "tabRecurrance";
            this.tabRecurrance.SelectedIndex = 0;
            this.tabRecurrance.Size = new System.Drawing.Size(480, 124);
            this.tabRecurrance.TabIndex = 4;
            this.tabRecurrance.SelectedIndexChanged += new System.EventHandler(this.tabRecurrance_SelectedIndexChanged);
            // 
            // tabDaily
            // 
            this.tabDaily.Controls.Add(this.radEveryWeekday);
            this.tabDaily.Controls.Add(this.label2);
            this.tabDaily.Controls.Add(this.textBox1);
            this.tabDaily.Controls.Add(this.radEveryXDays);
            this.tabDaily.Location = new System.Drawing.Point(4, 22);
            this.tabDaily.Name = "tabDaily";
            this.tabDaily.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaily.Size = new System.Drawing.Size(472, 98);
            this.tabDaily.TabIndex = 0;
            this.tabDaily.Text = "Daily";
            this.tabDaily.UseVisualStyleBackColor = true;
            // 
            // radEveryWeekday
            // 
            this.radEveryWeekday.AutoSize = true;
            this.radEveryWeekday.Location = new System.Drawing.Point(6, 42);
            this.radEveryWeekday.Name = "radEveryWeekday";
            this.radEveryWeekday.Size = new System.Drawing.Size(101, 17);
            this.radEveryWeekday.TabIndex = 3;
            this.radEveryWeekday.Text = "Every Weekday";
            this.radEveryWeekday.UseVisualStyleBackColor = true;
            this.radEveryWeekday.CheckedChanged += new System.EventHandler(this.radEveryWeekday_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "day(s)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radEveryXDays
            // 
            this.radEveryXDays.AutoSize = true;
            this.radEveryXDays.Checked = true;
            this.radEveryXDays.Location = new System.Drawing.Point(6, 9);
            this.radEveryXDays.Name = "radEveryXDays";
            this.radEveryXDays.Size = new System.Drawing.Size(52, 17);
            this.radEveryXDays.TabIndex = 0;
            this.radEveryXDays.TabStop = true;
            this.radEveryXDays.Text = "Every";
            this.radEveryXDays.UseVisualStyleBackColor = true;
            this.radEveryXDays.CheckedChanged += new System.EventHandler(this.radEveryXDays_CheckedChanged);
            // 
            // tabWeekly
            // 
            this.tabWeekly.Controls.Add(this.chkSaturday);
            this.tabWeekly.Controls.Add(this.chkFriday);
            this.tabWeekly.Controls.Add(this.chkThursday);
            this.tabWeekly.Controls.Add(this.chkWednesday);
            this.tabWeekly.Controls.Add(this.chkTuesday);
            this.tabWeekly.Controls.Add(this.chkMonday);
            this.tabWeekly.Controls.Add(this.chkSunday);
            this.tabWeekly.Controls.Add(this.lblWeeksOn);
            this.tabWeekly.Controls.Add(this.txtWeeklyRegenXWeeks);
            this.tabWeekly.Controls.Add(this.label13);
            this.tabWeekly.Location = new System.Drawing.Point(4, 22);
            this.tabWeekly.Name = "tabWeekly";
            this.tabWeekly.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeekly.Size = new System.Drawing.Size(472, 98);
            this.tabWeekly.TabIndex = 1;
            this.tabWeekly.Text = "Weekly";
            this.tabWeekly.UseVisualStyleBackColor = true;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.ForeColor = System.Drawing.Color.Red;
            this.chkSaturday.Location = new System.Drawing.Point(159, 53);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(68, 17);
            this.chkSaturday.TabIndex = 3;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            this.chkSaturday.CheckedChanged += new System.EventHandler(this.chkSaturday_CheckedChanged);
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(86, 53);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(54, 17);
            this.chkFriday.TabIndex = 3;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            this.chkFriday.CheckedChanged += new System.EventHandler(this.chkFriday_CheckedChanged);
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(10, 53);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(70, 17);
            this.chkThursday.TabIndex = 3;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            this.chkThursday.CheckedChanged += new System.EventHandler(this.chkThursday_CheckedChanged);
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(159, 30);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(83, 17);
            this.chkWednesday.TabIndex = 3;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            this.chkWednesday.CheckedChanged += new System.EventHandler(this.chkWednesday_CheckedChanged);
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(86, 30);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(67, 17);
            this.chkTuesday.TabIndex = 3;
            this.chkTuesday.Text = "Tuesday";
            this.chkTuesday.UseVisualStyleBackColor = true;
            this.chkTuesday.CheckedChanged += new System.EventHandler(this.chkTuesday_CheckedChanged);
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(10, 30);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(64, 17);
            this.chkMonday.TabIndex = 3;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            this.chkMonday.CheckedChanged += new System.EventHandler(this.chkMonday_CheckedChanged);
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.ForeColor = System.Drawing.Color.Red;
            this.chkSunday.Location = new System.Drawing.Point(247, 53);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(62, 17);
            this.chkSunday.TabIndex = 3;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            this.chkSunday.CheckedChanged += new System.EventHandler(this.chkSunday_CheckedChanged);
            // 
            // lblWeeksOn
            // 
            this.lblWeeksOn.AutoSize = true;
            this.lblWeeksOn.Location = new System.Drawing.Point(116, 7);
            this.lblWeeksOn.Name = "lblWeeksOn";
            this.lblWeeksOn.Size = new System.Drawing.Size(62, 13);
            this.lblWeeksOn.TabIndex = 2;
            this.lblWeeksOn.Text = "week(s) on:";
            // 
            // txtWeeklyRegenXWeeks
            // 
            this.txtWeeklyRegenXWeeks.Location = new System.Drawing.Point(78, 4);
            this.txtWeeklyRegenXWeeks.Name = "txtWeeklyRegenXWeeks";
            this.txtWeeklyRegenXWeeks.Size = new System.Drawing.Size(32, 20);
            this.txtWeeklyRegenXWeeks.TabIndex = 1;
            this.txtWeeklyRegenXWeeks.Text = "1";
            this.txtWeeklyRegenXWeeks.TextChanged += new System.EventHandler(this.txtWeeklyRegenXWeeks_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Recur every";
            // 
            // tabMonthly
            // 
            this.tabMonthly.Controls.Add(this.label17);
            this.tabMonthly.Controls.Add(this.txtMonthlyAdjustedValue);
            this.tabMonthly.Controls.Add(this.label18);
            this.tabMonthly.Controls.Add(this.label6);
            this.tabMonthly.Controls.Add(this.textBox4);
            this.tabMonthly.Controls.Add(this.label5);
            this.tabMonthly.Controls.Add(this.textBox3);
            this.tabMonthly.Controls.Add(this.MonthlySelection2);
            this.tabMonthly.Controls.Add(this.MonthlySelection1);
            this.tabMonthly.Controls.Add(this.radRecurranceMonths);
            this.tabMonthly.Controls.Add(this.label4);
            this.tabMonthly.Controls.Add(this.label3);
            this.tabMonthly.Controls.Add(this.textBox2);
            this.tabMonthly.Controls.Add(this.radEveryXMonths);
            this.tabMonthly.Location = new System.Drawing.Point(4, 22);
            this.tabMonthly.Name = "tabMonthly";
            this.tabMonthly.Size = new System.Drawing.Size(472, 98);
            this.tabMonthly.TabIndex = 2;
            this.tabMonthly.Text = "Monthly";
            this.tabMonthly.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(238, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Days";
            // 
            // txtMonthlyAdjustedValue
            // 
            this.txtMonthlyAdjustedValue.Location = new System.Drawing.Point(190, 66);
            this.txtMonthlyAdjustedValue.Name = "txtMonthlyAdjustedValue";
            this.txtMonthlyAdjustedValue.Size = new System.Drawing.Size(42, 20);
            this.txtMonthlyAdjustedValue.TabIndex = 18;
            this.txtMonthlyAdjustedValue.Text = "0";
            this.txtMonthlyAdjustedValue.TextChanged += new System.EventHandler(this.txtMonthlyAdjustedValue_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(126, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Plus/Minus";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "of every";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(53, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 20);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "1";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "month(s)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(289, 40);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(42, 20);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "1";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // MonthlySelection2
            // 
            this.MonthlySelection2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthlySelection2.FormattingEnabled = true;
            this.MonthlySelection2.Items.AddRange(new object[] {
            "day",
            "weekday",
            "weekend day",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.MonthlySelection2.Location = new System.Drawing.Point(137, 39);
            this.MonthlySelection2.Name = "MonthlySelection2";
            this.MonthlySelection2.Size = new System.Drawing.Size(95, 21);
            this.MonthlySelection2.TabIndex = 7;
            this.MonthlySelection2.SelectedIndexChanged += new System.EventHandler(this.MonthlySelection2_SelectedIndexChanged);
            // 
            // MonthlySelection1
            // 
            this.MonthlySelection1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthlySelection1.FormattingEnabled = true;
            this.MonthlySelection1.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Last"});
            this.MonthlySelection1.Location = new System.Drawing.Point(53, 39);
            this.MonthlySelection1.Name = "MonthlySelection1";
            this.MonthlySelection1.Size = new System.Drawing.Size(78, 21);
            this.MonthlySelection1.TabIndex = 6;
            this.MonthlySelection1.SelectedIndexChanged += new System.EventHandler(this.MonthlySelection1_SelectedIndexChanged);
            // 
            // radRecurranceMonths
            // 
            this.radRecurranceMonths.AutoSize = true;
            this.radRecurranceMonths.Location = new System.Drawing.Point(3, 40);
            this.radRecurranceMonths.Name = "radRecurranceMonths";
            this.radRecurranceMonths.Size = new System.Drawing.Size(44, 17);
            this.radRecurranceMonths.TabIndex = 5;
            this.radRecurranceMonths.Text = "The";
            this.radRecurranceMonths.UseVisualStyleBackColor = true;
            this.radRecurranceMonths.CheckedChanged += new System.EventHandler(this.radRecurranceMonths_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "month(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "of every";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(152, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(34, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "1";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // radEveryXMonths
            // 
            this.radEveryXMonths.AutoSize = true;
            this.radEveryXMonths.Checked = true;
            this.radEveryXMonths.Location = new System.Drawing.Point(3, 7);
            this.radEveryXMonths.Name = "radEveryXMonths";
            this.radEveryXMonths.Size = new System.Drawing.Size(44, 17);
            this.radEveryXMonths.TabIndex = 0;
            this.radEveryXMonths.TabStop = true;
            this.radEveryXMonths.Text = "Day";
            this.radEveryXMonths.UseVisualStyleBackColor = true;
            this.radEveryXMonths.CheckedChanged += new System.EventHandler(this.radEveryXMonths_CheckedChanged);
            // 
            // tabYearly
            // 
            this.tabYearly.Controls.Add(this.label16);
            this.tabYearly.Controls.Add(this.txtYearlyAdjustedValue);
            this.tabYearly.Controls.Add(this.label15);
            this.tabYearly.Controls.Add(this.label7);
            this.tabYearly.Controls.Add(this.YearlySelection3);
            this.tabYearly.Controls.Add(this.YearlySelection2);
            this.tabYearly.Controls.Add(this.YearlySelection1);
            this.tabYearly.Controls.Add(this.radRecurranceYears);
            this.tabYearly.Controls.Add(this.cboYearEveryMonth);
            this.tabYearly.Controls.Add(this.txtYearEvery);
            this.tabYearly.Controls.Add(this.radEveryXYears);
            this.tabYearly.Location = new System.Drawing.Point(4, 22);
            this.tabYearly.Name = "tabYearly";
            this.tabYearly.Size = new System.Drawing.Size(472, 98);
            this.tabYearly.TabIndex = 3;
            this.tabYearly.Text = "Yearly";
            this.tabYearly.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(265, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Days";
            // 
            // txtYearlyAdjustedValue
            // 
            this.txtYearlyAdjustedValue.Location = new System.Drawing.Point(206, 69);
            this.txtYearlyAdjustedValue.Name = "txtYearlyAdjustedValue";
            this.txtYearlyAdjustedValue.Size = new System.Drawing.Size(34, 20);
            this.txtYearlyAdjustedValue.TabIndex = 15;
            this.txtYearlyAdjustedValue.Text = "0";
            this.txtYearlyAdjustedValue.TextChanged += new System.EventHandler(this.txtYearlyAdjustedValue_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(142, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Plus/Minus";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "of";
            // 
            // YearlySelection3
            // 
            this.YearlySelection3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearlySelection3.FormattingEnabled = true;
            this.YearlySelection3.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.YearlySelection3.Location = new System.Drawing.Point(268, 43);
            this.YearlySelection3.Name = "YearlySelection3";
            this.YearlySelection3.Size = new System.Drawing.Size(95, 21);
            this.YearlySelection3.TabIndex = 12;
            this.YearlySelection3.SelectedIndexChanged += new System.EventHandler(this.YearlySelection3_SelectedIndexChanged);
            // 
            // YearlySelection2
            // 
            this.YearlySelection2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearlySelection2.FormattingEnabled = true;
            this.YearlySelection2.Items.AddRange(new object[] {
            "day",
            "weekday",
            "weekend day",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.YearlySelection2.Location = new System.Drawing.Point(145, 43);
            this.YearlySelection2.Name = "YearlySelection2";
            this.YearlySelection2.Size = new System.Drawing.Size(95, 21);
            this.YearlySelection2.TabIndex = 11;
            this.YearlySelection2.SelectedIndexChanged += new System.EventHandler(this.YearlySelection2_SelectedIndexChanged);
            // 
            // YearlySelection1
            // 
            this.YearlySelection1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearlySelection1.FormattingEnabled = true;
            this.YearlySelection1.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Last"});
            this.YearlySelection1.Location = new System.Drawing.Point(61, 43);
            this.YearlySelection1.Name = "YearlySelection1";
            this.YearlySelection1.Size = new System.Drawing.Size(78, 21);
            this.YearlySelection1.TabIndex = 10;
            this.YearlySelection1.SelectedIndexChanged += new System.EventHandler(this.YearlySelection1_SelectedIndexChanged);
            // 
            // radRecurranceYears
            // 
            this.radRecurranceYears.AutoSize = true;
            this.radRecurranceYears.Location = new System.Drawing.Point(3, 47);
            this.radRecurranceYears.Name = "radRecurranceYears";
            this.radRecurranceYears.Size = new System.Drawing.Size(44, 17);
            this.radRecurranceYears.TabIndex = 9;
            this.radRecurranceYears.TabStop = true;
            this.radRecurranceYears.Text = "The";
            this.radRecurranceYears.UseVisualStyleBackColor = true;
            this.radRecurranceYears.CheckedChanged += new System.EventHandler(this.radRecurranceYears_CheckedChanged);
            // 
            // cboYearEveryMonth
            // 
            this.cboYearEveryMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearEveryMonth.FormattingEnabled = true;
            this.cboYearEveryMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboYearEveryMonth.Location = new System.Drawing.Point(62, 7);
            this.cboYearEveryMonth.Name = "cboYearEveryMonth";
            this.cboYearEveryMonth.Size = new System.Drawing.Size(95, 21);
            this.cboYearEveryMonth.TabIndex = 8;
            this.cboYearEveryMonth.SelectedIndexChanged += new System.EventHandler(this.cboYearEveryMonth_SelectedIndexChanged);
            // 
            // txtYearEvery
            // 
            this.txtYearEvery.Location = new System.Drawing.Point(162, 7);
            this.txtYearEvery.Name = "txtYearEvery";
            this.txtYearEvery.Size = new System.Drawing.Size(42, 20);
            this.txtYearEvery.TabIndex = 3;
            this.txtYearEvery.TextChanged += new System.EventHandler(this.txtYearEvery_TextChanged);
            // 
            // radEveryXYears
            // 
            this.radEveryXYears.AutoSize = true;
            this.radEveryXYears.Checked = true;
            this.radEveryXYears.Location = new System.Drawing.Point(3, 7);
            this.radEveryXYears.Name = "radEveryXYears";
            this.radEveryXYears.Size = new System.Drawing.Size(52, 17);
            this.radEveryXYears.TabIndex = 0;
            this.radEveryXYears.TabStop = true;
            this.radEveryXYears.Text = "Every";
            this.radEveryXYears.UseVisualStyleBackColor = true;
            this.radEveryXYears.CheckedChanged += new System.EventHandler(this.radEveryXYears_CheckedChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(104, 136);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(113, 20);
            this.dtpStartDate.TabIndex = 11;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Start Date:";
            // 
            // radOccurrences
            // 
            this.radOccurrences.AutoSize = true;
            this.radOccurrences.Checked = true;
            this.radOccurrences.Location = new System.Drawing.Point(248, 138);
            this.radOccurrences.Name = "radOccurrences";
            this.radOccurrences.Size = new System.Drawing.Size(71, 17);
            this.radOccurrences.TabIndex = 13;
            this.radOccurrences.TabStop = true;
            this.radOccurrences.Text = "End after:";
            this.radOccurrences.UseVisualStyleBackColor = true;
            this.radOccurrences.CheckedChanged += new System.EventHandler(this.radOccurrences_CheckedChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(322, 163);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(113, 20);
            this.dtpEndDate.TabIndex = 17;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // txtOccurrences
            // 
            this.txtOccurrences.Location = new System.Drawing.Point(322, 137);
            this.txtOccurrences.Name = "txtOccurrences";
            this.txtOccurrences.Size = new System.Drawing.Size(42, 20);
            this.txtOccurrences.TabIndex = 14;
            this.txtOccurrences.Text = "10";
            // 
            // radEndBy
            // 
            this.radEndBy.AutoSize = true;
            this.radEndBy.Location = new System.Drawing.Point(248, 165);
            this.radEndBy.Name = "radEndBy";
            this.radEndBy.Size = new System.Drawing.Size(62, 17);
            this.radEndBy.TabIndex = 16;
            this.radEndBy.Text = "End By:";
            this.radEndBy.UseVisualStyleBackColor = true;
            this.radEndBy.CheckedChanged += new System.EventHandler(this.radEndBy_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(370, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "occurrences";
            // 
            // btnGenDates
            // 
            this.btnGenDates.Location = new System.Drawing.Point(322, 225);
            this.btnGenDates.Name = "btnGenDates";
            this.btnGenDates.Size = new System.Drawing.Size(116, 23);
            this.btnGenDates.TabIndex = 18;
            this.btnGenDates.Text = "Generate Dates";
            this.btnGenDates.UseVisualStyleBackColor = true;
            this.btnGenDates.Click += new System.EventHandler(this.btnGenDates_Click);
            // 
            // tabDates
            // 
            this.tabDates.Controls.Add(this.tabDefinition);
            this.tabDates.Controls.Add(this.tabValues);
            this.tabDates.Location = new System.Drawing.Point(12, 85);
            this.tabDates.Name = "tabDates";
            this.tabDates.SelectedIndex = 0;
            this.tabDates.Size = new System.Drawing.Size(500, 295);
            this.tabDates.TabIndex = 19;
            // 
            // tabDefinition
            // 
            this.tabDefinition.Controls.Add(this.radNoEnd);
            this.tabDefinition.Controls.Add(this.tabRecurrance);
            this.tabDefinition.Controls.Add(this.btnGenDates);
            this.tabDefinition.Controls.Add(this.label9);
            this.tabDefinition.Controls.Add(this.dtpStartDate);
            this.tabDefinition.Controls.Add(this.radEndBy);
            this.tabDefinition.Controls.Add(this.label8);
            this.tabDefinition.Controls.Add(this.txtOccurrences);
            this.tabDefinition.Controls.Add(this.radOccurrences);
            this.tabDefinition.Controls.Add(this.dtpEndDate);
            this.tabDefinition.Location = new System.Drawing.Point(4, 22);
            this.tabDefinition.Name = "tabDefinition";
            this.tabDefinition.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefinition.Size = new System.Drawing.Size(492, 269);
            this.tabDefinition.TabIndex = 0;
            this.tabDefinition.Text = "Definition";
            this.tabDefinition.UseVisualStyleBackColor = true;
            // 
            // radNoEnd
            // 
            this.radNoEnd.AutoSize = true;
            this.radNoEnd.Location = new System.Drawing.Point(248, 191);
            this.radNoEnd.Name = "radNoEnd";
            this.radNoEnd.Size = new System.Drawing.Size(60, 17);
            this.radNoEnd.TabIndex = 19;
            this.radNoEnd.Text = "No end";
            this.radNoEnd.UseVisualStyleBackColor = true;
            this.radNoEnd.CheckedChanged += new System.EventHandler(this.radNoEnd_CheckedChanged);
            // 
            // tabValues
            // 
            this.tabValues.Controls.Add(this.monthCalendar1);
            this.tabValues.Controls.Add(this.txtNextDate);
            this.tabValues.Controls.Add(this.btnGetNextDate);
            this.tabValues.Controls.Add(this.txtSeriesInfo);
            this.tabValues.Controls.Add(this.txtTotal);
            this.tabValues.Controls.Add(this.lstResults);
            this.tabValues.Controls.Add(this.label10);
            this.tabValues.Controls.Add(this.label1);
            this.tabValues.Controls.Add(this.txtEndDate);
            this.tabValues.Controls.Add(this.label12);
            this.tabValues.Controls.Add(this.label11);
            this.tabValues.Controls.Add(this.txtStartDate);
            this.tabValues.Location = new System.Drawing.Point(4, 22);
            this.tabValues.Name = "tabValues";
            this.tabValues.Padding = new System.Windows.Forms.Padding(3);
            this.tabValues.Size = new System.Drawing.Size(492, 269);
            this.tabValues.TabIndex = 1;
            this.tabValues.Text = "Values";
            this.tabValues.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(256, 6);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(3);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 23;
            // 
            // txtNextDate
            // 
            this.txtNextDate.Location = new System.Drawing.Point(256, 203);
            this.txtNextDate.Name = "txtNextDate";
            this.txtNextDate.ReadOnly = true;
            this.txtNextDate.Size = new System.Drawing.Size(227, 20);
            this.txtNextDate.TabIndex = 22;
            // 
            // btnGetNextDate
            // 
            this.btnGetNextDate.Enabled = false;
            this.btnGetNextDate.Location = new System.Drawing.Point(412, 174);
            this.btnGetNextDate.Name = "btnGetNextDate";
            this.btnGetNextDate.Size = new System.Drawing.Size(71, 23);
            this.btnGetNextDate.TabIndex = 21;
            this.btnGetNextDate.Text = "Next Date";
            this.btnGetNextDate.UseVisualStyleBackColor = true;
            this.btnGetNextDate.Click += new System.EventHandler(this.btnGetNextDate_Click);
            // 
            // txtSeriesInfo
            // 
            this.txtSeriesInfo.Location = new System.Drawing.Point(256, 229);
            this.txtSeriesInfo.Name = "txtSeriesInfo";
            this.txtSeriesInfo.ReadOnly = true;
            this.txtSeriesInfo.Size = new System.Drawing.Size(227, 20);
            this.txtSeriesInfo.TabIndex = 20;
            this.txtSeriesInfo.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(163, 143);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(87, 20);
            this.txtTotal.TabIndex = 12;
            // 
            // lstResults
            // 
            this.lstResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(9, 19);
            this.lstResults.Name = "lstResults";
            this.lstResults.ScrollAlwaysVisible = true;
            this.lstResults.Size = new System.Drawing.Size(148, 147);
            this.lstResults.TabIndex = 2;
            this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Total Generated:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select item to view in calendar";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(163, 74);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(87, 20);
            this.txtEndDate.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(163, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Last Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(163, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "First Date:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(163, 35);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(87, 20);
            this.txtStartDate.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::PharmacyAssist.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(433, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 20;
            this.toolTips.SetToolTip(this.btnCancel, "Close");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = global::PharmacyAssist.Properties.Resources.yes;
            this.btnOK.Location = new System.Drawing.Point(352, 387);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 21;
            this.toolTips.SetToolTip(this.btnOK, "Save");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gpTitle
            // 
            this.gpTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpTitle.BorderColor = System.Drawing.Color.Transparent;
            this.gpTitle.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gpTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gpTitle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gpTitle.Image = global::PharmacyAssist.Properties.Resources.supervista_general_clock_256;
            this.gpTitle.ImageLocation = new System.Drawing.Point(2, 2);
            this.gpTitle.ImageSize = new System.Drawing.Point(64, 64);
            this.gpTitle.ImageSizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.gpTitle.Location = new System.Drawing.Point(12, 12);
            this.gpTitle.Name = "gpTitle";
            this.gpTitle.ShadowOffSet = 0;
            this.gpTitle.Size = new System.Drawing.Size(500, 67);
            this.gpTitle.TabIndex = 38;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmRecurrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 423);
            this.Controls.Add(this.gpTitle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabDates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecurrance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recurring dates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRecurrance_FormClosing);
            this.Load += new System.EventHandler(this.frmRecurrance_Load);
            this.tabRecurrance.ResumeLayout(false);
            this.tabDaily.ResumeLayout(false);
            this.tabDaily.PerformLayout();
            this.tabWeekly.ResumeLayout(false);
            this.tabWeekly.PerformLayout();
            this.tabMonthly.ResumeLayout(false);
            this.tabMonthly.PerformLayout();
            this.tabYearly.ResumeLayout(false);
            this.tabYearly.PerformLayout();
            this.tabDates.ResumeLayout(false);
            this.tabDefinition.ResumeLayout(false);
            this.tabDefinition.PerformLayout();
            this.tabValues.ResumeLayout(false);
            this.tabValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRecurrance;
        private System.Windows.Forms.TabPage tabDaily;
        private System.Windows.Forms.RadioButton radEveryWeekday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radEveryXDays;
        private System.Windows.Forms.TabPage tabWeekly;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.Label lblWeeksOn;
        private System.Windows.Forms.TextBox txtWeeklyRegenXWeeks;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabMonthly;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMonthlyAdjustedValue;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox MonthlySelection2;
        private System.Windows.Forms.ComboBox MonthlySelection1;
        private System.Windows.Forms.RadioButton radRecurranceMonths;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radEveryXMonths;
        private System.Windows.Forms.TabPage tabYearly;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtYearlyAdjustedValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox YearlySelection3;
        private System.Windows.Forms.ComboBox YearlySelection2;
        private System.Windows.Forms.ComboBox YearlySelection1;
        private System.Windows.Forms.RadioButton radRecurranceYears;
        private System.Windows.Forms.ComboBox cboYearEveryMonth;
        private System.Windows.Forms.TextBox txtYearEvery;
        private System.Windows.Forms.RadioButton radEveryXYears;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radOccurrences;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtOccurrences;
        private System.Windows.Forms.RadioButton radEndBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGenDates;
        private System.Windows.Forms.TabControl tabDates;
        private System.Windows.Forms.TabPage tabDefinition;
        private System.Windows.Forms.TabPage tabValues;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox txtNextDate;
        private System.Windows.Forms.Button btnGetNextDate;
        private System.Windows.Forms.TextBox txtSeriesInfo;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolTip toolTips;
        private Owf.Controls.GradientPanel gpTitle;
        private System.Windows.Forms.RadioButton radNoEnd;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}