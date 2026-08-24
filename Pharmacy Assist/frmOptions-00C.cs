using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmOptions : Form
    {
        private int _ColourThemeNumber = Properties.Settings.Default.SearchColourThemeNumber;
        private bool _FormLoaded = false;
        private bool _OriginalAuditSetting = Properties.Settings.Default.FullAudit;
        private bool _OriginalMDISetting = Properties.Settings.Default.MultiDocumentInterface;
        private bool _OriginalSDISetting = Properties.Settings.Default.SingleDocumentInterface;
        private bool _OriginalToolbarSetting = Properties.Settings.Default.ToolbarInterface;
        private int _UserStartPage = 0;

        public frmOptions()
        {
            InitializeComponent();

            // The DataGridView control needs Double-buffering to speed up the redraw!!!
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvColours,
                new object[] { true });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int PageID = 0;
            string Query = "";

            Properties.Settings.Default.MultiDocumentInterface = radMDI.Checked;
            Properties.Settings.Default.AlwaysDownloadImages = chkAlwaysDownloadImages.Checked;
            Properties.Settings.Default.SaveConditionsAgainstActiveIngredientOnly = chkSaveConditionsAgainstActiveIngredientOnly.Checked;
            Properties.Settings.Default.FullAudit = chkAlwaysAudit.Checked;
            Properties.Settings.Default.AutoSearch = chkSearchAutomatically.Checked;
            Properties.Settings.Default.EnableRecordPaging = chkEnableRecordPaging.Checked;
            Properties.Settings.Default.EnableSpellCheck = chkEnableSpellCheck.Checked;
            Properties.Settings.Default.ShowLinkedItemCount = chkShowLinkedItemCount.Checked;
            Properties.Settings.Default.ToolbarOnTop = chkToolbarOnTop.Checked;
            Properties.Settings.Default.ShowCompletedTasks = chkShowCompletedTasks.Checked;
            Properties.Settings.Default.ShowTaskStoreName = chkShowTaskStoreName.Checked;
            Properties.Settings.Default.LoadTaskDataOnDemand = chkLoadTaskDataOnDemand.Checked;
            Properties.Settings.Default.SortMyTasksAlphabetically = chkSortMyTasksAlphabetically.Checked;
            Properties.Settings.Default.EventDuration = Convert.ToInt32(txtEventDuration.Text);
            Properties.Settings.Default.EventWarningPeriod = Convert.ToInt32(txtEventNotification.Text);
            Properties.Settings.Default.TaskWarningPeriod = Convert.ToInt32(txtTaskNotificationPeriod.Text);
            Properties.Settings.Default.TaskDisplayPeriod = Convert.ToInt32(txtTaskListPeriodDays.Text);
            Properties.Settings.Default.SearchColourThemeNumber = _ColourThemeNumber;
            
            switch (cmbRecordsPerPage.SelectedItem.ToString())
            {
                case "10":
                    Properties.Settings.Default.DataPageSize = 10;
                    break;
                case "20":
                    Properties.Settings.Default.DataPageSize = 20;
                    break;
                case "50":
                    Properties.Settings.Default.DataPageSize = 50;
                    break;
                case "100":
                    Properties.Settings.Default.DataPageSize = 100;
                    break;
                case "200":
                    Properties.Settings.Default.DataPageSize = 200;
                    break;
                case "500":
                    Properties.Settings.Default.DataPageSize = 500;
                    break;
                case "1000":
                    Properties.Settings.Default.DataPageSize = 1000;
                    break;
                case "2000":
                    Properties.Settings.Default.DataPageSize = 2000;
                    break;
                case "5000":
                    Properties.Settings.Default.DataPageSize = 5000;
                    break;
                case "10000":
                    Properties.Settings.Default.DataPageSize = 10000;
                    break;
                default:
                    string PageSize = Microsoft.VisualBasic.Interaction.InputBox("Enter the number of records to return", "Records per page", Properties.Settings.Default.DataPageSize.ToString());

                    if (Microsoft.VisualBasic.Information.IsNumeric(PageSize.Trim()))
                    {
                        Properties.Settings.Default.DataPageSize = Convert.ToInt32(PageSize.Trim());
                        cmbRecordsPerPage.Text = "Custom";
                    }
                    else
                    {
                        MessageBox.Show("A numeric result was expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    break;
            }

            // Turn off all the search options
            Properties.Settings.Default.SearchBrandName = false;
            Properties.Settings.Default.SearchCategoryName = false;
            Properties.Settings.Default.SearchConditionName = false;
            Properties.Settings.Default.SearchIngredientName = false;
            Properties.Settings.Default.SearchProductDescription = false;
            Properties.Settings.Default.SearchProductName = false;
            Properties.Settings.Default.SearchProductUPI = false;
            Properties.Settings.Default.SearchScheduleName = false;
            Properties.Settings.Default.SearchEndUse = false;

            // Work out what Product fields to search on, and turn each one on
            foreach (string SelectedItemName in clbSearchOptions.CheckedItems)
            {
                if (SelectedItemName == "Brand Name") Properties.Settings.Default.SearchBrandName = true;
                if (SelectedItemName == "Category Name") Properties.Settings.Default.SearchCategoryName = true;
                if (SelectedItemName == "Condition Name") Properties.Settings.Default.SearchConditionName = true;
                if (SelectedItemName == "Ingredient Name") Properties.Settings.Default.SearchIngredientName = true;
                if (SelectedItemName == "Product Description") Properties.Settings.Default.SearchProductDescription = true;
                if (SelectedItemName == "Product name") Properties.Settings.Default.SearchProductName = true;
                if (SelectedItemName == "Product UPI") Properties.Settings.Default.SearchProductUPI = true;
                if (SelectedItemName == "Schedule Name") Properties.Settings.Default.SearchScheduleName = true;
                if (SelectedItemName == "End Use Name") Properties.Settings.Default.SearchEndUse = true;
            }
            
            Properties.Settings.Default.Save();

            // Determine which page to use for the start page
            if (cmbStartPage.SelectedItem != null)
            {
                PageID = (int)((ListItem)cmbStartPage.SelectedItem).ID;
            }

            try
            {
                // Save the updated details
                Cursor.Current = Cursors.WaitCursor;
                Query = string.Format("UPDATE UserAccount SET StartPageID = {0} WHERE ID = {1}", PageID, Global.UserID);
                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);
                Cursor.Current = Cursors.Default;
                this.Close();
            }
            catch
            {

            }

            Global.DataPageSize = Properties.Settings.Default.DataPageSize;

            if (_OriginalAuditSetting != Properties.Settings.Default.FullAudit)
            {
                Global.Audit("Full Auditing", "", "", 0, Global.Username, _OriginalAuditSetting.ToString(), (Properties.Settings.Default.FullAudit).ToString(), Application.ProductName, true);
            }

            if (radSDI.Checked != _OriginalSDISetting || radMDI.Checked != _OriginalMDISetting || radToolbar.Checked != _OriginalToolbarSetting)
            {
                DialogResult result = MessageBox.Show("Changing the Interface setting requires an application restart.\nIt is suggested you restart now.", "Confirmation required", MessageBoxButtons.YesNo);

                Properties.Settings.Default.MultiDocumentInterface = radMDI.Checked;
                Properties.Settings.Default.SingleDocumentInterface = radSDI.Checked;
                Properties.Settings.Default.ToolbarInterface = radToolbar.Checked;

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Global.RestartRequired = true;
                }
            }

            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            LoadSettings();
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SearchColourThemeNumber = _ColourThemeNumber;
            
            frmTheme015 ThemesWindow = new frmTheme015();

            ThemesWindow.ShowDialog();  // The SearchColourThemeColour may be set here

            _ColourThemeNumber = Properties.Settings.Default.SearchColourThemeNumber;

            dgvColours.Rows[_ColourThemeNumber].Selected = true;

            gpTitle.GradientStartColor = Global.Theme[17];
        }

        private void chkEnableRecordPaging_CheckedChanged(object sender, EventArgs e)
        {
            cmbRecordsPerPage.Enabled = (chkEnableRecordPaging.Checked);
        }

        private void dgvColours_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _ColourThemeNumber = dgvColours.CurrentCellAddress.Y;
        }

        private void dgvColours_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            gpTitle.Image = Properties.Resources.realvista_general_gear_256;
            this.Icon = Properties.Resources.realvista_general_gear;
            gpTitle.GradientStartColor = Global.Theme[17];

            LoadSettings();
            
            _FormLoaded = true;
        }

        private void LoadPages()
        {
            string Query = "";
            DataSet Data = null;

            cmbStartPage.Items.Clear();

            // Get page list from SQL
            Query = "SELECT ID, ISNULL(Name,'') AS Name FROM Page";
            Cursor.Current = Cursors.WaitCursor;
            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            ListItem Item = new ListItem(0,"");

            cmbStartPage.Items.Add(Item);  // Add an empty start page

            // Place the pages into the combobox
            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                Item = new ListItem();

                Item.ID = (int)Row["ID"];
                Item.Name = (string)Row["Name"];

                cmbStartPage.Items.Add(Item);

                if (Item.ID == _UserStartPage) cmbStartPage.SelectedItem = Item;
            }
        }

        private void LoadSettings()
        {
            clbSearchOptions.Items.Clear();
            
            clbSearchOptions.Items.Add("Brand Name", Properties.Settings.Default.SearchBrandName);
            clbSearchOptions.Items.Add("Category Name", Properties.Settings.Default.SearchCategoryName);
            clbSearchOptions.Items.Add("Condition Name", Properties.Settings.Default.SearchConditionName);
            clbSearchOptions.Items.Add("Custom Fields", Properties.Settings.Default.SearchCustomFields);
            clbSearchOptions.Items.Add("End Use Name", Properties.Settings.Default.SearchEndUse);
            clbSearchOptions.Items.Add("Ingredient Name", Properties.Settings.Default.SearchIngredientName);
            clbSearchOptions.Items.Add("Product Description", Properties.Settings.Default.SearchProductDescription);
            clbSearchOptions.Items.Add("Product name", Properties.Settings.Default.SearchProductName);
            clbSearchOptions.Items.Add("Product UPI", Properties.Settings.Default.SearchProductUPI);
            clbSearchOptions.Items.Add("Schedule Name", Properties.Settings.Default.SearchScheduleName);

            cmbRecordsPerPage.Items.Add("10");
            cmbRecordsPerPage.Items.Add("20");
            cmbRecordsPerPage.Items.Add("50");
            cmbRecordsPerPage.Items.Add("100");
            cmbRecordsPerPage.Items.Add("200");
            cmbRecordsPerPage.Items.Add("500");
            cmbRecordsPerPage.Items.Add("1000");
            cmbRecordsPerPage.Items.Add("2000");
            cmbRecordsPerPage.Items.Add("5000");
            cmbRecordsPerPage.Items.Add("10000");
            cmbRecordsPerPage.Items.Add("Custom");

            SetThemeColours();

            // Select the saved theme
            _ColourThemeNumber = Properties.Settings.Default.SearchColourThemeNumber;

            dgvColours.Rows[_ColourThemeNumber].Selected = true;

            switch (Properties.Settings.Default.DataPageSize)
            {
                case 10:
                    cmbRecordsPerPage.Text = "10";
                    break;
                case 20:
                    cmbRecordsPerPage.Text = "20";
                    break;
                case 50:
                    cmbRecordsPerPage.Text = "50";
                    break;
                case 100:
                    cmbRecordsPerPage.Text = "100";
                    break;
                case 200:
                    cmbRecordsPerPage.Text = "200";
                    break;
                case 500:
                    cmbRecordsPerPage.Text = "500";
                    break;
                case 1000:
                    cmbRecordsPerPage.Text = "1000";
                    break;
                case 2000:
                    cmbRecordsPerPage.Text = "2000";
                    break;
                case 5000:
                    cmbRecordsPerPage.Text = "5000";
                    break;
                case 10000:
                    cmbRecordsPerPage.Text = "10000";
                    break;
                default:
                    cmbRecordsPerPage.Text = "Custom";
                    break;
            }

            chkEnableRecordPaging.Checked = Properties.Settings.Default.EnableRecordPaging;
            chkAlwaysDownloadImages.Checked = Properties.Settings.Default.AlwaysDownloadImages;
            chkToolbarOnTop.Checked = Properties.Settings.Default.ToolbarOnTop;
            chkShowTaskStoreName.Checked = Properties.Settings.Default.ShowTaskStoreName;
            chkLoadTaskDataOnDemand.Checked = Properties.Settings.Default.LoadTaskDataOnDemand;
            chkSortMyTasksAlphabetically.Checked = Properties.Settings.Default.SortMyTasksAlphabetically;

            if (Properties.Settings.Default.MultiDocumentInterface)
            {
                radMDI.Checked = true;
            }
            else if (Properties.Settings.Default.SingleDocumentInterface)
            {
                radSDI.Checked = true;
            }
            else if (Properties.Settings.Default.ToolbarInterface)
            {
                radToolbar.Checked = true;
            }

            chkSaveConditionsAgainstActiveIngredientOnly.Checked = Properties.Settings.Default.SaveConditionsAgainstActiveIngredientOnly;
            chkSearchAutomatically.Checked = Properties.Settings.Default.AutoSearch;
            chkAlwaysAudit.Checked = Properties.Settings.Default.FullAudit;
            chkShowLinkedItemCount.Checked = Properties.Settings.Default.ShowLinkedItemCount;
            chkEnableSpellCheck.Checked = Properties.Settings.Default.EnableSpellCheck;
            chkShowCompletedTasks.Checked = Properties.Settings.Default.ShowCompletedTasks;

            txtEventDuration.Text = Properties.Settings.Default.EventDuration.ToString();
            txtEventNotification.Text = Properties.Settings.Default.EventWarningPeriod.ToString();
            txtTaskNotificationPeriod.Text = Properties.Settings.Default.TaskWarningPeriod.ToString();
            txtTaskListPeriodDays.Text = Properties.Settings.Default.TaskDisplayPeriod.ToString();

            LoadUserDetails();
            LoadPages();
        }

        private void LoadUserDetails()
        {
            string Query = "";
            DataSet Data = null;

            // Get user details from SQL
            Query = "SELECT ID, Username, FirstName, LastName, Title, Email, StoreID, StartPageID FROM UserAccount WHERE ID = " + Global.UserID;
            Cursor.Current = Cursors.WaitCursor;
            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            try
            {
                _UserStartPage = (int)Data.Tables[0].Rows[0]["StartPageID"];

            }
            catch { }
        }

        private void SetThemeColours()
        {
            dgvColours.Rows.Clear();
            // Set Theme colours
            for (int i = 0; i < 10; i++)  // 10 themes
            {
                dgvColours.Rows.Add();
                Color Backcolor = Global.LoadTheme(i)[30];
                Color AlternateBackcolor = Global.LoadTheme(i)[31];
                dgvColours.Rows[i].Cells[0].Style.BackColor = Backcolor; dgvColours.Rows[i].Cells[2].Style.BackColor = AlternateBackcolor;
            }
        }
    }
}
