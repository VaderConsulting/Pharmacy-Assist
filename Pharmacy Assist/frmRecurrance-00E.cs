using RecurrenceGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmRecurrance : Form
    {
        public int ParentID { get; set; }

        public string ParentType { get; set; }

        public string RecurranceValue { get; set; }

        
        public frmRecurrance()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenDates_Click(object sender, EventArgs e)
        {
            GenerateDates();
        }

        private void btnGetNextDate_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                DateItem dt = (DateItem)lstResults.SelectedItem;
                txtNextDate.Text = RecurrenceHelper.GetNextDate(dt.Value, txtSeriesInfo.Text).ToString("d MMM, yyyy");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string Query = "";
            bool OkToContinue = false;

            if (txtSeriesInfo.Text == "")
            {
                OkToContinue = GenerateDates();
            }
            else
            {
                OkToContinue = true;
            }

            if (OkToContinue)
            {

                Cursor.Current = Cursors.WaitCursor;

                Query = String.Format("UPDATE " + ParentType + " SET Recurrance = '" + txtSeriesInfo.Text + "' WHERE ID = " + ParentID.ToString());
                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                RecurranceValue = txtSeriesInfo.Text;

                Cursor.Current = Cursors.Default;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
            
        }

        private void cboYearEveryMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void chkFriday_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void chkMonday_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void chkSaturday_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void chkSunday_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void chkThursday_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void chkTuesday_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void chkWednesday_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            radEndBy.Checked = true;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void frmRecurrance_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void frmRecurrance_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            this.Show();
            this.Refresh();

            tabRecurrance.SelectedIndex = 2;  // Set Monthly as the default
            
            switch (RecurranceValue)
            {
                case "":
                    {
                        dtpStartDate.Value = DateTime.Today;
                        dtpEndDate.Value = DateTime.Today.AddYears(10);

                        // Monthly
                        textBox4.Text = DateTime.Today.Day.ToString();
                        MonthlySelection1.SelectedIndex = 0;
                        MonthlySelection2.SelectedIndex = 0;

                        // Yearly
                        cboYearEveryMonth.SelectedIndex = DateTime.Today.Month - 1;
                        txtYearEvery.Text = DateTime.Today.Day.ToString();
                        YearlySelection1.SelectedIndex = 0;
                        YearlySelection2.SelectedIndex = 0;
                        YearlySelection3.SelectedIndex = DateTime.Today.Month - 1;

                        switch (DateTime.Today.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                chkSunday.Checked = true;
                                break;
                            case DayOfWeek.Monday:
                                chkMonday.Checked = true;
                                break;
                            case DayOfWeek.Tuesday:
                                chkTuesday.Checked = true;
                                break;
                            case DayOfWeek.Wednesday:
                                chkWednesday.Checked = true;
                                break;
                            case DayOfWeek.Thursday:
                                chkThursday.Checked = true;
                                break;
                            case DayOfWeek.Friday:
                                chkFriday.Checked = true;
                                break;
                            case DayOfWeek.Saturday:
                                chkSaturday.Checked = true;
                                break;
                        }
                        
                        break;
                    }
                default:
                    {
                        if (ParentID > 0) // We have to load the tasks current values and setup the GUI appropriately
                        {
                            RecurrenceInfo Info = RecurrenceHelper.GetFriendlySeriesInfo(RecurranceValue);

                            // Start Date
                            dtpStartDate.Value = Info.StartDate;

                            // End Date
                            switch (Info.EndDateType)
                            {
                                case EndDateType.NumberOfOccurrences:
                                    {
                                        radOccurrences.Checked = true;
                                        txtOccurrences.Text = Info.NumberOfOccurrences.ToString();
                                        break;
                                    }
                                case EndDateType.SpecificDate:
                                    {
                                        radEndBy.Checked = true;
                                        dtpEndDate.Value = Info.EndDate.Value;
                                        break;
                                    }
                                case EndDateType.NoEndDate:
                                    {
                                        radNoEnd.Checked = true;
                                        break;
                                    }
                            }

                            // Recurrence Type
                            switch (Info.RecurrenceType)
                            {
                                case RecurrenceType.Daily:
                                    {
                                        tabRecurrance.SelectedIndex = 0;
                                        if (Info.DailyRegenType == DailyRegenType.OnEveryWeekday)
                                        {
                                            radEveryWeekday.Checked = true;
                                        }
                                        else
                                        {
                                            radEveryXDays.Checked = true;
                                            textBox1.Text = Info.DailyRegenEveryXDays.ToString();
                                        }
                                        break;
                                    }
                                case RecurrenceType.Weekly:
                                    {
                                        tabRecurrance.SelectedIndex = 1;
                                        txtWeeklyRegenXWeeks.Text = Info.WeeklyRegenEveryXWeeks.ToString();
                                        chkMonday.Checked = Info.WeeklySelectedDays.Monday;
                                        chkTuesday.Checked = Info.WeeklySelectedDays.Tuesday;
                                        chkWednesday.Checked = Info.WeeklySelectedDays.Wednesday;
                                        chkThursday.Checked = Info.WeeklySelectedDays.Thursday;
                                        chkFriday.Checked = Info.WeeklySelectedDays.Friday;
                                        chkSaturday.Checked = Info.WeeklySelectedDays.Saturday;
                                        chkSunday.Checked = Info.WeeklySelectedDays.Sunday;
                                        break;
                                    }
                                case RecurrenceType.Monthly:
                                    {
                                        tabRecurrance.SelectedIndex = 2;
                                        switch (Info.MonthlyRegenType)
                                        {
                                            case MonthlyRegenType.OnSpecificDayOfMonth:
                                                {
                                                    radEveryXMonths.Checked = true;
                                                    textBox4.Text = Info.MonthlyRegenerateOnSpecificDateDayValue.ToString();
                                                    textBox2.Text = Info.MonthlyRegenEveryXMonths.ToString();
                                                    break;
                                                }
                                            case MonthlyRegenType.OnCustomDateFormat:
                                                {
                                                    radRecurranceMonths.Checked = true;
                                                    MonthlySelection1.Text = Info.MonthlySpecificDatePartOne.ToString();
                                                    
                                                    switch (Info.MonthlySpecificDatePartTwo)
                                                    {
                                                        case MonthlySpecificDatePartTwo.WeekendDay:
                                                            {
                                                                MonthlySelection2.Text = "weekend day";
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                MonthlySelection2.Text = Info.MonthlySpecificDatePartTwo.ToString();
                                                                break;
                                                            }
                                                    }
                                                    textBox3.Text = Info.MonthlyRegenEveryXMonths.ToString();
                                                    txtMonthlyAdjustedValue.Text = Info.AdjustmentValue.ToString();
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case RecurrenceType.Yearly:
                                    {
                                        tabRecurrance.SelectedIndex = 3;

                                        switch (Info.YearlyRegenType)
                                        {
                                            case YearlyRegenType.OnCustomDateFormat:
                                                {
                                                    radRecurranceYears.Checked = true;
                                                    YearlySelection1.Text = Info.YearlySpecificDatePartOne.ToString();
                                                    YearlySelection2.Text = Info.YearlySpecificDatePartTwo.ToString();
                                                    YearlySelection3.Text = Info.YearlySpecificDatePartThree.ToString();
                                                    txtYearlyAdjustedValue.Text = Info.AdjustmentValue.ToString();
                                                    break;
                                                }
                                            case YearlyRegenType.OnSpecificDayOfYear:
                                                {
                                                    radEveryXYears.Checked = true;
                                                    cboYearEveryMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[Info.SpecificDateMonthValue - 1];
                                                    txtYearEvery.Text = Info.SpecificDateDayValue.ToString(); 
                                                    
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }

            gpTitle.Image = Properties.Resources.supervista_general_clock_256;
            this.Icon = Properties.Resources.supervista_general_clock;
            gpTitle.GradientStartColor = Global.Theme[20];

        }

        private bool GenerateDates()
        {
            // NOTE:  The never-ending date used here is 31-12-2100.

            bool EntryOk = false;
            
            RecurrenceValues values = null;

            switch (tabRecurrance.SelectedIndex)
            {
                case 0: // Daily
                    Console.WriteLine("Daily recurrance");

                    EntryOk = true;

                    DailyRecurrenceSettings da;
                    if (radOccurrences.Checked)
                        da = new DailyRecurrenceSettings(dtpStartDate.Value, Convert.ToInt32(txtOccurrences.Text));
                    else if (radEndBy.Checked) // End By xxx/xxx/xxxx
                        da = new DailyRecurrenceSettings(dtpStartDate.Value, dtpEndDate.Value);
                    else // Never end
                        da = new DailyRecurrenceSettings(dtpStartDate.Value, new DateTime(2100,12,31));

                    if (radEveryXDays.Checked)
                        values = da.GetValues(int.Parse(textBox1.Text));
                    else
                        values = da.GetValues(1, DailyRegenType.OnEveryWeekday);
                    break;

                case 1: // Weekly
                    Console.WriteLine("Weekly recurrance");

                    WeeklyRecurrenceSettings we;
                    SelectedDayOfWeekValues selectedValues = new SelectedDayOfWeekValues();

                    if (radOccurrences.Checked)
                        we = new WeeklyRecurrenceSettings(dtpStartDate.Value, Convert.ToInt32(txtOccurrences.Text));
                    else if (radEndBy.Checked) // End By xxx/xxx/xxxx
                        we = new WeeklyRecurrenceSettings(dtpStartDate.Value, dtpEndDate.Value);
                    else // Never end
                        we = new WeeklyRecurrenceSettings(dtpStartDate.Value, new DateTime(2100, 12, 31));

                    EntryOk = chkSunday.Checked | chkMonday.Checked | chkTuesday.Checked | chkWednesday.Checked | chkThursday.Checked | chkFriday.Checked | chkSaturday.Checked;

                    selectedValues.Sunday = chkSunday.Checked;
                    selectedValues.Monday = chkMonday.Checked;
                    selectedValues.Tuesday = chkTuesday.Checked;
                    selectedValues.Wednesday = chkWednesday.Checked;
                    selectedValues.Thursday = chkThursday.Checked;
                    selectedValues.Friday = chkFriday.Checked;
                    selectedValues.Saturday = chkSaturday.Checked;

                    if (EntryOk)
                    {
                        errorProvider.SetError(lblWeeksOn, "");
                        values = we.GetValues(int.Parse(txtWeeklyRegenXWeeks.Text), selectedValues);
                    }
                    else
                    {
                        errorProvider.SetError(lblWeeksOn, "At least one day must be selected");
                    }
                    break;

                case 2: // Monthly
                    Console.WriteLine("Monthly recurrance");

                    EntryOk = true;

                    MonthlyRecurrenceSettings mo;
                    if (radOccurrences.Checked)
                        mo = new MonthlyRecurrenceSettings(dtpStartDate.Value, Convert.ToInt32(txtOccurrences.Text));
                    else if (radEndBy.Checked) // End By xxx/xxx/xxxx
                        mo = new MonthlyRecurrenceSettings(dtpStartDate.Value, dtpEndDate.Value);
                    else // Never end
                        mo = new MonthlyRecurrenceSettings(dtpStartDate.Value, new DateTime(2100, 12, 31));

                    if (radEveryXMonths.Checked)
                        values = mo.GetValues(int.Parse(textBox4.Text), Convert.ToInt32(textBox2.Text));
                    else
                    {
                        // Get the adjusted values
                        mo.AdjustmentValue = int.Parse(txtMonthlyAdjustedValue.Text);
                        values = mo.GetValues((MonthlySpecificDatePartOne)MonthlySelection1.SelectedIndex, (MonthlySpecificDatePartTwo)MonthlySelection2.SelectedIndex, int.Parse(textBox3.Text));
                    }
                    break;

                case 3: // Yearly
                    Console.WriteLine("Yearly recurrance");

                    EntryOk = true;

                    YearlyRecurrenceSettings yr;
                    if (radOccurrences.Checked)
                        yr = new YearlyRecurrenceSettings(dtpStartDate.Value, Convert.ToInt32(txtOccurrences.Text));
                    else if (radEndBy.Checked) // End By xxx/xxx/xxxx
                        yr = new YearlyRecurrenceSettings(dtpStartDate.Value, dtpEndDate.Value);
                    else // Never end
                        yr = new YearlyRecurrenceSettings(dtpStartDate.Value, new DateTime(2100, 12, 31));

                    if (radEveryXYears.Checked)
                        values = yr.GetValues(int.Parse(txtYearEvery.Text), cboYearEveryMonth.SelectedIndex + 1);
                    else
                    {
                        // Get the adjusted value
                        yr.AdjustmentValue = int.Parse(txtYearlyAdjustedValue.Text);
                        values = yr.GetValues((YearlySpecificDatePartOne)YearlySelection1.SelectedIndex, (YearlySpecificDatePartTwo)YearlySelection2.SelectedIndex, (YearlySpecificDatePartThree)(YearlySelection3.SelectedIndex + 1));
                    }
                    break;
            }

            if (EntryOk)
            {
                txtSeriesInfo.Text = values.GetSeriesInfo();

                lstResults.Items.Clear();
                DateTime[] bolded = new DateTime[values.Values.Count];
                int counter = 0;
                foreach (DateTime dt in values.Values)
                {
                    bolded[counter] = dt;
                    lstResults.Items.Add(new DateItem(dt));
                    counter++;
                }
                monthCalendar1.BoldedDates = bolded;

                if (lstResults.Items.Count > 0)
                    lstResults.SelectedIndex = 0;

                txtTotal.Text = lstResults.Items.Count.ToString();
                txtEndDate.Text = values.EndDate.ToShortDateString();
                txtStartDate.Text = values.StartDate.ToShortDateString();
                btnGetNextDate.Enabled = lstResults.Items.Count > 0;
                txtNextDate.Text = string.Empty;
                tabDates.SelectedTab = tabValues;
            }
            else
            {
                // Something is wrong - probably with Weekly settings
            }

            return EntryOk;
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateItem dt = (DateItem)lstResults.SelectedItem;
            monthCalendar1.SetDate(dt.Value);
        }

        private void MonthlySelection1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = ""; 
            
            radRecurranceMonths.Checked = true;
        }

        private void MonthlySelection2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = ""; 
            
            radRecurranceMonths.Checked = true;
        }

        private void radEndBy_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void radEveryWeekday_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void radEveryXDays_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void radEveryXMonths_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void radEveryXYears_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void radNoEnd_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void radOccurrences_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void radRecurranceMonths_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void radRecurranceYears_CheckedChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void tabRecurrance_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";

            radEveryXMonths.Checked = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";

            radEveryXMonths.Checked = true;
        }

        private void txtMonthlyAdjustedValue_TextChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void txtWeeklyRegenXWeeks_TextChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void txtYearEvery_TextChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void txtYearlyAdjustedValue_TextChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void YearlySelection1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void YearlySelection2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }

        private void YearlySelection3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeriesInfo.Text = "";
        }
    }
}
