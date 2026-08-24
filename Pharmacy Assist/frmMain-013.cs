using AutoUpdaterDotNET;
using i00SpellCheck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmMain : Form
    {
        
        private System.Timers.Timer _AutoTimer = new System.Timers.Timer();
        private int _CountdownCount = 0;
        private int _CurrentPageRecordFinish = 0;
        private int _CurrentPageRecordStart = 1;
        private int _DataPageNumber = 1;
        private int _RecordCount = 0;
        private int _SearchCounter = 0;
        internal bool RestartRequired = false;

        public frmMain()
        {
            InitializeComponent();

            // The DataGridView control needs Double-buffering to speed up the redraw!!!
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvProducts,
                new object[] { true });

            if (Properties.Settings.Default.EnableSpellCheck) this.EnableControlExtensions();

            // Upgrade User settings if required (which will only happen upon an App version change)
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false; // Set to false so this upgrade happens once only
            }

            _AutoTimer.AutoReset = false;
            _AutoTimer.SynchronizingObject = this;
            _AutoTimer.Elapsed += new ElapsedEventHandler(_AutoTimer_Elapsed);

            Global.SqlConnectionString = Properties.Settings.Default.DataConnectionString;

            // Setup logging
            Global.Common = Core.Common.Singleton.GetSingleton();
            Global.Common.Logging.LogLevel = Core.Logging.Functions.LOGGING_LEVEL.DEBUGGING;

            Global.Common.Logging.LogfileRetentionTimeDays = 7;
            Global.Common.Logging.CleanupOldFiles();

            if (Debugger.IsAttached) UseDevConnectionToolStripMenuItem.Visible = true;

            //Global.UseDeveloperSettings = true;

        }

        #region Toolstrip

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            frmAbout AboutForm = new frmAbout();

            AboutForm.ShowDialog();
        }

        private void ActiveIngredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Active Ingredient")) OpenItemEditForm("Active Ingredient");
        }

        private void BrandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Brand")) OpenItemEditForm("Brands");
        }

        private void catalogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            //if (Global.Permissions.Contains("Read Catalog")) OpenCatalogForm();
            if (Global.Permissions.Contains("Read Catalog")) OpenItemEditForm("Catalogs");
        }

        private void CategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Category")) OpenItemEditForm("Categories");
        }

        private void CertificatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Certificate")) OpenItemEditForm("Certificates");
        }

        private void ConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Condition")) OpenItemEditForm("Conditions");
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectToDatabase(Properties.Settings.Default.EnableRecordPaging);
        }

        private void coreProductsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            Properties.Settings.Default.CoreProductsOnly = coreProductsOnlyToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            DoSearch(toolStripSearchTextbox.Text.Trim());
            //PageData(toolStripSearchTextbox.Text);
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseDatabaseConnection();
        }

        private void DocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            OpenNewDocumentsWindow();
        }

        private void EditActiveIngredientsToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Active Ingredient")) OpenItemEditForm("Active Ingredients");
        }

        private void EditBrandsToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Brand")) OpenItemEditForm("Brands");
        }

        private void EditCatalogToolStripButton_Click(object sender, EventArgs e)
        {
            //if (Global.Permissions.Contains("Read Catalog")) OpenCatalogForm();
            if (Global.Permissions.Contains("Read Catalog")) OpenItemEditForm("Catalogs");
        }

        private void EditCategoriesToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Category")) OpenItemEditForm("Categories");
        }

        private void EditCertificatesToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Certificate")) OpenItemEditForm("Certificates");
        }

        private void EditConditionsToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Condition")) OpenItemEditForm("Conditions");
        }

        private void EditDocumentsToolStripButton_Click(object sender, EventArgs e)
        {
            OpenNewDocumentsWindow();
        }

        private void EditEndUsesToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read End Use")) OpenItemEditForm("End Uses");
        }

        private void EditEventTypesToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Event Type")) OpenItemEditForm("Event Types");
        }

        private void EditProductsToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Product")) OpenItemEditForm("Products");
        }

        private void EditSchedulesToolStripButton5_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Schedule")) OpenItemEditForm("Schedules");
        }

        private void EditStoresToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Store")) OpenItemEditForm("Stores");
        }

        private void EditUnitsOfMeasureToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Unit Of Measure")) OpenItemEditForm("Units Of Measure");
        }

        private void EditUserAccountsToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read User")) EditUserAccounts();
        }

        private void EndUsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read End Use")) OpenItemEditForm("End Uses");
        }

        private void EventsToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Event")) OpenEvents();
        }

        private void EventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Event")) OpenEvents();
        }

        private void EventTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Event Type")) OpenItemEditForm("Event Types");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();

            // Turn off RememberUsername
            Properties.Settings.Default.RememberUsername = false;

            // Close all open forms except this
            for (int i = 0; i < Global.OpenForms.Count; i++)
            {
                if (Global.OpenForms[i] != this)
                {
                    Global.OpenForms[i].Close();
                    try
                    {
                        Global.OpenForms[i].Dispose();
                    }
                    catch { }
                }
            }

            // Remove all existing permissions
            Global.Permissions.Clear();

            this.Hide();
            frmLogon LogonForm = new frmLogon();

            LogonForm.ShowDialog();

            DoStartup();

        }

        private void MyTasksToolStripButton_Click(object sender, EventArgs e)
        {
            OpenMyTasks();
        }

        private void myTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            OpenMyTasks();
        }

        private void NewSearchToolStripButton_Click(object sender, EventArgs e)
        {
            OpenNewSearchWindow();
        }

        private void NewSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            OpenNewSearchWindow();
        }

        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            // If the other is already unchecked, don't allow this to also be unchecked
            if (!noToolStripMenuItem.Checked)
            {
                if (!yesToolStripMenuItem.Checked)
                    noToolStripMenuItem.Checked = true;
            }

            _DataPageNumber = 1;
            DoSearch(toolStripSearchTextbox.Text.Trim());
            //PageData(toolStripSearchTextbox.Text.Trim());
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            frmOptions OptionsForm = new frmOptions();

            OptionsForm.ShowDialog();

            if (Global.RestartRequired)
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
        }

        private void PermissionsToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Permission")) OpenItemEditForm("Permissions");  //OpenPermissions();
        }

        private void PermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Permission")) OpenItemEditForm("Permissions");  //OpenPermissions();
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Product")) OpenItemEditForm("Products");  //OpenPermissions();
        }

        private void RolesToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Role")) OpenItemEditForm("Roles");
        }

        private void RolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Role")) OpenItemEditForm("Roles");
        }

        private void SchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Schedule")) OpenItemEditForm("Schedules");
        }

        private void StoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Store")) OpenItemEditForm("Stores");
        }

        private void TasksToolStripButton_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Task")) OpenTasks();
        }

        private void TasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Task")) OpenTasks();
        }

        private void toolStripClearSearchButton_Click(object sender, EventArgs e)
        {
            toolStripSearchTextbox.Text = "";
            toolStripSearchTextbox.Focus();
        }

        private void toolStripConnectDatabase_Click(object sender, EventArgs e)
        {
            ConnectToDatabase(Properties.Settings.Default.EnableRecordPaging);
        }

        private void toolStripDisconnectDatabase_Click(object sender, EventArgs e)
        {
            CloseDatabaseConnection();
        }

        private void toolStripFirstButton_Click(object sender, EventArgs e)
        {
            _DataPageNumber = 1;

            DoSearch(toolStripSearchTextbox.Text.Trim());

            SetupPagingButtons(Properties.Settings.Default.EnableRecordPaging);
        }

        private void toolStripLastButton_Click(object sender, EventArgs e)
        {
            _DataPageNumber = (_RecordCount / Global.DataPageSize) + 1;

            DoSearch(toolStripSearchTextbox.Text.Trim());

            SetupPagingButtons(Properties.Settings.Default.EnableRecordPaging);
        }

        private void toolStripNextButton_Click(object sender, EventArgs e)
        {
            _DataPageNumber += 1;

            DoSearch(toolStripSearchTextbox.Text.Trim());

            SetupPagingButtons(Properties.Settings.Default.EnableRecordPaging);
        }

        private void toolStripPreviousButton_Click(object sender, EventArgs e)
        {
            _DataPageNumber -= 1;

            DoSearch(toolStripSearchTextbox.Text.Trim());

            SetupPagingButtons(Properties.Settings.Default.EnableRecordPaging);

        }

        private void toolStripSearchButton_Click(object sender, EventArgs e)
        {
            DoSearch(toolStripSearchTextbox.Text.Trim());
        }

        private void toolStripSearchTextbox_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSearchTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                DoSearch(toolStripSearchTextbox.Text.Trim());
            }
        }

        private void toolStripSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            bool Enable = (toolStripSearchTextbox.Text.Trim().Length > 0);

            toolStripClearSearchButton.Enabled = Enable;

            if (Properties.Settings.Default.AutoSearch)
            {
                _AutoTimer.Enabled = false;
                _CountdownCount = 0;
                SearchCountdown.Visible = true;
                _AutoTimer.Enabled = true;
            }
            else
            {
                //_CountdownCount = 0;
                //SearchCountdown.Visible = false;
            }
        }

        private void unitsOfMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Unit Of Measure")) OpenItemEditForm("Units Of Measure");
        }

        private void UnitsOfMeasureToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read Unit Of Measure")) OpenItemEditForm("Units Of Measure");
        }

        private void UseDevConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            Global.UseDeveloperSettings = UseDevConnectionToolStripMenuItem.Checked;
            SelectDeveloperMenuItem();
        }

        private void userAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            if (Global.Permissions.Contains("Read User")) EditUserAccounts();
        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            frmUserDetails UserDetailsForm = new frmUserDetails(Global.UserID, "The following information is saved as your details", false);

            UserDetailsForm.ShowDialog();
        }

        private void yesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            // If the other is already unchecked, don't allow this to also be unchecked
            if (!yesToolStripMenuItem.Checked)
            {
                if (!noToolStripMenuItem.Checked)
                    yesToolStripMenuItem.Checked = true;
            }

            _DataPageNumber = 1;
            DoSearch(toolStripSearchTextbox.Text.Trim());
            //PageData(toolStripSearchTextbox.Text.Trim());
        }

        #endregion

        private void _AutoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _CountdownCount += 1;

            SearchCountdown.Value = 100 - ((100 / 12) * _CountdownCount);

            SearchCountdown.Visible = true;

            if (_CountdownCount == 12)
            {
                _AutoTimer.Enabled = false;
                SearchCountdown.Visible = false;
                _CountdownCount = 0;
                SearchCountdown.Value = 100;
                SearchCountdown.Visible = false;

                DoSearch(this.toolStripSearchTextbox.Text);
            }
            else
            {
                _AutoTimer.Enabled = true;
            }
        }

        private void CalculatePagingDetails()
        {
            StatusLabel.Text = "Calculating Paging Details..."; this.Refresh();

            _CurrentPageRecordStart = ((_DataPageNumber - 1) * Global.DataPageSize) + 1;
            _CurrentPageRecordFinish = (_CurrentPageRecordStart - 1) + Global.DataPageSize;

            if (_CurrentPageRecordFinish > _RecordCount) _CurrentPageRecordFinish = _RecordCount;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMenuBar();
            frmChangePassword ChangePasswordForm = new frmChangePassword("");

            ChangePasswordForm.ShowDialog();
        }

        private void Cleanup()
        {
            CloseDatabaseConnection();
            SavePageSize();

            Global.Common.Logging.WriteInformationEvent("Logging off");
        }

        private bool CloseDatabaseConnection()
        {
            bool Result = false;

            if (Global.Connection == null) Global.Connection = new System.Data.SqlClient.SqlConnection(Global.SqlConnectionString);

            if (Global.Connection.State == ConnectionState.Open)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    StatusLabel.Text = "Disconnecting";
                    this.Refresh();

                    Global.Connection.Close();
                    Global.Connection.Dispose();

                    StatusLabel.Text = "Idle";
                    toolStripDisconnectDatabase.Enabled = false;
                    toolStripConnectDatabase.Enabled = true;

                    toolStripSearchTextbox.Enabled = false;
                    toolStripSearchButton.Enabled = false;

                    Result = true;

                    ConnectionStatus.Image = imlMain.Images[0];
                    ConnectionStatus.Text = "Disconnected";

                    toolStripRecordInfo.Text = "No records";

                    this.Refresh();
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Disconnection error";
                    Global.Common.Logging.WriteErrorEvent(String.Format("Main form (CloseDatabaseConnection) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                    Console.WriteLine(ex.Message);
                    this.Refresh();
                }
                Cursor.Current = Cursors.Default;
            }
            return Result;
        }

        private void ConnectToDatabase(bool EnablePaging)
        {
            if (OpenDatabaseConnection())
            {
                if (Global.Permissions.Contains("Read Product"))
                {
                    toolStripSearchTextbox.Enabled = true;
                    toolStripSearchButton.Enabled = true;

                    _DataPageNumber = 1;

                    DoSearch(toolStripSearchTextbox.Text.Trim());
                }
                //SetupPagingButtons(EnablePaging);

                //toolStripSearchTextbox.Focus();
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenProductDetails();
        }

        private void dgvProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //_Context.SaveChanges();
        }

        private void dgvProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Global.Common.Logging.WriteErrorEvent(String.Format("Error retrieving data for DataGridView (frmMain) {0}", e.Exception));
            e.Cancel = true;
        }

        private void dgvProducts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                OpenProductDetails();
            }
        }

        private void DoSearch(string Searchtext)
        {
            _SearchCounter += 1;

            PageData(Searchtext);
        }

        private void DoStartup()
        {
            ConnectionStatus.Image = imlMain.Images[0];

            ///////////////////////////////////// TESTING ////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////

            Global.DataPageSize = Properties.Settings.Default.DataPageSize;

            dgvProducts.DefaultCellStyle.BackColor = Global.Theme[30];
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Global.Theme[31];

            // Developer ONLY
            if (Global.UseDeveloperSettings)
            {
                SelectDeveloperMenuItem();
                UseDevConnectionToolStripMenuItem.Checked = true;
            }

            // Everyone

            #region MDI

            if (Properties.Settings.Default.MultiDocumentInterface)
            {
                toolStripSearchTextbox.Visible = false;
                toolStripSearchButton.Visible = false;
                toolStripClearSearchButton.Visible = false;
                toolStripFirstButton.Visible = false;
                toolStripPreviousButton.Visible = false;
                toolStripRecordInfo.Visible = false;
                toolStripNextButton.Visible = false;
                toolStripLastButton.Visible = false;
                toolStripSeparator3.Visible = false;
                toolStripSeparator2.Visible = false;
                dgvProducts.Visible = false;
                stsStatus.Visible = false;

                this.IsMdiContainer = true;

                switch (Global.UserStartPageID)
                {
                    case 0: // No start page
                        break;
                    case 1: // Task List (default)
                        OpenNewTaskWindow();
                        break;
                    case 2: // Search
                        if (Global.Permissions.Contains("Read Product")) OpenNewSearchWindow();
                        break;
                    case 3: // Documents
                        if (Global.Permissions.Contains("Read Document")) OpenNewDocumentsWindow();
                        break;
                }
            }

            #endregion

            #region SDI

            if (Properties.Settings.Default.SingleDocumentInterface)
            {
                ConnectToDatabase(Properties.Settings.Default.EnableRecordPaging);  // For non-MDI operation

                switch (Global.UserStartPageID)
                {
                    case 0: // No start page
                        break;
                    case 1: // Task List (default)
                        OpenNewTaskWindow();
                        break;
                    case 2: // Search 
                        if (Global.Permissions.Contains("Read Product")) OpenNewSearchWindow();
                        break;
                    case 3: // Documents
                        if (Global.Permissions.Contains("Read Document")) OpenNewDocumentsWindow();
                        break;
                }
            }

            #endregion

            #region Toolbar Interface

            if (Properties.Settings.Default.ToolbarInterface)
            {
                mnuMain.Visible = false;
                toolStripSearchTextbox.Visible = false;
                toolStripSearchButton.Visible = false;
                toolStripClearSearchButton.Visible = false;
                toolStripFirstButton.Visible = false;
                toolStripPreviousButton.Visible = false;
                toolStripRecordInfo.Visible = false;
                toolStripNextButton.Visible = false;
                toolStripLastButton.Visible = false;
                toolStripSeparator3.Visible = false;
                toolStripSeparator2.Visible = false;
                //lblReference.Visible = false;
                dgvProducts.Visible = false;
                stsStatus.Visible = false;
                toolStripSeparator2.Visible = false;

                this.IsMdiContainer = false;

                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.TopMost = Properties.Settings.Default.ToolbarOnTop;
                this.Dock = DockStyle.Fill;

                this.Width = 760;
                this.Height = 76;
                //this.Top = 0;
                //this.Left = 0;

                switch (Global.UserStartPageID)
                {
                    case 0: // No start page
                        break;
                    case 1: // Task List (default)
                        OpenNewTaskWindow();
                        break;
                    case 2: // Search
                        if (Global.Permissions.Contains("Read Product")) OpenNewSearchWindow();
                        break;
                    case 3: // Documents
                        if (Global.Permissions.Contains("Read Document")) OpenNewDocumentsWindow();
                        break;
                }
            }
            #endregion

            #region Permissions

            if (Global.Permissions.Contains("Read Active Ingredient"))
            {
                ActiveIngredientsToolStripMenuItem.Enabled = true;
                EditActiveIngredientsToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Brand"))
            {
                BrandsToolStripMenuItem.Enabled = true;
                EditBrandsToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Catalog"))
            {
                catalogsToolStripMenuItem.Enabled = true;
                EditCatalogToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Category"))
            {
                CategoriesToolStripMenuItem.Enabled = true;
                EditCategoriesToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Certificate"))
            {
                CertificatesToolStripMenuItem.Enabled = true;
                EditCertificatesToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Condition"))
            {
                ConditionsToolStripMenuItem.Enabled = true;
                EditConditionsToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Document"))
            {
                DocumentsToolStripMenuItem.Enabled = true;
                EditDocumentsToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read End Use"))
            {
                EndUsesToolStripMenuItem.Enabled = true;
                EditEndUsesToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Event Type"))
            {
                EventTypesToolStripMenuItem.Enabled = true;
                EditEventTypesToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Event"))
            {
                EventsToolStripMenuItem.Enabled = true;
                EditEventsToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Permission"))
            {
                PermissionsToolStripMenuItem.Enabled = true;
                EditPermissionsToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Product"))
            {
                ProductsToolStripMenuItem.Enabled = true;
                EditProductsToolStripButton.Enabled = true;
                NewSearchToolStripButton.Enabled = true;
                NewSearchToolStripMenuItem.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Role"))
            {
                RolesToolStripMenuItem.Enabled = true;
                EditRolesToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Schedule"))
            {
                SchedulesToolStripMenuItem.Enabled = true;
                EditSchedulesToolStripButton5.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Store"))
            {
                StoresToolStripMenuItem.Enabled = true;
                EditStoresToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Task"))
            {
                TasksToolStripMenuItem.Enabled = true;
                EditTasksToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Unit Of Measure"))
            {
                UnitsOfMeasureToolStripMenuItem.Enabled = true;
                EditUnitsOfMeasureToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Read User"))
            {
                userAccountsToolStripMenuItem.Enabled = true;
                EditUserAccountsToolStripButton.Enabled = true;
            }

            if (Global.Permissions.Contains("Write Password"))
            {
                changePasswordToolStripMenuItem.Enabled = true;
            }

            #endregion

            // Determine last Catalog for pricing reasons
            Global.LastCatalogID = Convert.ToInt32(Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute("SELECT TOP 1 ID, RPMID, Name FROM Catalog ORDER BY RPMID DESC", Global.SqlConnectionString), 0, 0), 0));

            this.Show();
            this.Refresh();
        }

        private void EditUserAccounts()
        {
            frmUserAccounts UserAccountForm = new frmUserAccounts();

            UserAccountForm.Show();
        }

        private void ExitApplication()
        {
            Global.Common.Logging.WriteInformationEvent("Shutting down");

            Environment.Exit(0);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MainFormPosition = new Point(this.Left, this.Top);
            if (!Properties.Settings.Default.ToolbarInterface) Properties.Settings.Default.MainFormSize = new Point(this.Width, this.Height);
            Properties.Settings.Default.Save();

            Global.RemoveFormFromList(this);

            Cleanup();
            ExitApplication();
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (Properties.Settings.Default.ToolbarInterface)
            {
                if (e.KeyCode == Keys.Menu)
                {
                    mnuMain.Visible = !mnuMain.Visible;
                    toolStripMain.Visible = !mnuMain.Visible;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            /* AutoUpdater.Start function takes the following Arguments
            * 1. url of the appcast xml file that specifies download url, changelog url, application Version and title
            * 2. If you want user to select remind later interval then set lateUserSelectRemindLater as true. If you select true third and fourth arguments will be ignored.
            * 3. reminderLaterTime is a remind later timespan value if user choose Remind Later.
            * 4. reminderLaterTimeFormat is a time format enum that specifies if you want to take remind later time span value as minutes, hours or days.
            * AutoUpdater.Start(string appcastURL, bool lateUserSelectRemindLater, int reminderLaterTime, int reminderLaterTimeFormat)
           */

            coreProductsOnlyToolStripMenuItem.Checked = Properties.Settings.Default.CoreProductsOnly;

            AutoUpdater.Start("http://logonengine.com/autoupdate/PharmacyAssist.xml");

            // Note:  There is no bounds checking in the following code, 
            // so if the form is positioned on a monitor that is
            // subsequently removed, the form will not be accessible
            if (Properties.Settings.Default.MainFormSize.X != 0)
            {
                this.Width = Properties.Settings.Default.MainFormSize.X;
                this.Height = Properties.Settings.Default.MainFormSize.Y;
            }

            if (Properties.Settings.Default.MainFormPosition.X != 0)
            {
                this.Left = Properties.Settings.Default.MainFormPosition.X;
                this.Top = Properties.Settings.Default.MainFormPosition.Y;
            }

            Global.Theme = Global.LoadTheme(Properties.Settings.Default.SearchColourThemeNumber);

            frmLogon LogonForm = new frmLogon();

            LogonForm.ShowDialog();

            logoffToolStripMenuItem.Text = "Logoff " + Global.Username;

            DoStartup();

        }

        private void HideMenuBar()
        {
            if (Properties.Settings.Default.ToolbarInterface)
            {
                mnuMain.Visible = false;
                toolStripMain.Visible = !mnuMain.Visible;
            }
        }

        private void OpenCatalogForm()
        {
            frmCatalogs002 CatalogForm = new frmCatalogs002();

            if (Properties.Settings.Default.MultiDocumentInterface) CatalogForm.MdiParent = this;

            CatalogForm.Show();
        }

        private bool OpenDatabaseConnection()
        {
            bool Result = false;

            Global.Connection = new System.Data.SqlClient.SqlConnection(Global.SqlConnectionString);

            if (Global.Connection.State == ConnectionState.Closed)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    StatusLabel.Text = "Connecting";
                    this.Refresh();

                    Global.Connection.Open();

                    //Global.Binding.DataSource = Global.SQLConn;

                    StatusLabel.Text = "Idle";
                    toolStripConnectDatabase.Enabled = false;

                    Result = true;

                    SetConnectedImage();

                    this.Refresh();
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Connection error";
                    Global.Common.Logging.WriteErrorEvent(String.Format("Main form (OpenDatabaseConnection) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                    Console.WriteLine(ex.Message);
                    this.Refresh();
                }
                Cursor.Current = Cursors.Default;
            }

            return Result;
        }

        private void OpenEvents()
        {
            frmEvents005 EventsForm = new frmEvents005();

            if (Properties.Settings.Default.MultiDocumentInterface) EventsForm.MdiParent = this;

            EventsForm.Show();
        }

        private void OpenItemEditForm(string ListDisplayName)
        {
            frmListEdit007 ItemEditForm = new frmListEdit007(DisplayName: ListDisplayName);

            if (Properties.Settings.Default.MultiDocumentInterface) ItemEditForm.MdiParent = this;

            ItemEditForm.Show();

        }

        private void OpenMyTasks()
        {
            frmMyTasks MyTasksForm = new frmMyTasks();

            if (Properties.Settings.Default.MultiDocumentInterface) MyTasksForm.MdiParent = this;

            MyTasksForm.Show();
        }

        private void OpenNewDocumentsWindow()
        {
            if (Global.Permissions.Contains("Read Document"))
            {
                //OpenItemEditForm("Documents");

                frmDocuments DocumentForm = new frmDocuments();

                if (Properties.Settings.Default.MultiDocumentInterface) DocumentForm.MdiParent = this;

                DocumentForm.Show();
            }
        }

        private void OpenNewSearchWindow()
        {
            frmSearch SearchForm = new frmSearch(this);

            if (Properties.Settings.Default.MultiDocumentInterface) SearchForm.MdiParent = this;
            SearchForm.Show();

            SearchForm.Refresh();
            SearchForm.Focus();
        }

        private void OpenNewTaskWindow()
        {
            frmMyTasks TaskForm = new frmMyTasks();

            if (Properties.Settings.Default.MultiDocumentInterface) TaskForm.MdiParent = this;
            TaskForm.Show();

            TaskForm.TopMost = true;
            TaskForm.Refresh();
            TaskForm.Focus();
        }

        //private void OpenPermissions()
        //{
        //    frmListItemSelection PermissionsForm = new frmListItemSelection(null);

        //    PermissionsForm.ListIsReadOnly = true;
        //    PermissionsForm.ListDisplayName = "Permissions";
        //    PermissionsForm.SingleItemConstraint = false;

        //    if (Properties.Settings.Default.MultiDocumentInterface) PermissionsForm.MdiParent = this;

        //    PermissionsForm.Show();
        //}

        private void OpenProductDetails()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Get the selected rows
            DataGridViewSelectedRowCollection Rows = dgvProducts.SelectedRows;

            // Go through the collection of rows and open a new details form for each selected product
            foreach (DataGridViewRow Row in Rows)
            {
                // Determine the ID of this product
                int ID = Convert.ToInt32(Row.Cells["ID"].Value);
                int UPI = Convert.ToInt32(Row.Cells["UPI"].Value);

                StatusLabel.Text = "Opening details for UPI " + UPI.ToString();

                frmProductDetail ProductDetails = new frmProductDetail(ID: ID, Parent: this);

                if (Properties.Settings.Default.MultiDocumentInterface) ProductDetails.MdiParent = this;

                ProductDetails.Show();

                StatusLabel.Text = "Idle";
            }

            Cursor.Current = Cursors.Default;
        }

        private void OpenTasks()
        {
            frmTasks010 TasksForm = new frmTasks010();

            if (Properties.Settings.Default.MultiDocumentInterface) TasksForm.MdiParent = this;

            TasksForm.Show();
        }

        private void PageData(string SearchString)
        {
            StringBuilder OutsideWhereClause = new StringBuilder();
            StringBuilder InsideWhereClause = new StringBuilder();
            string[] OrderByFieldNames = { "Product.Name" };
            StringBuilder Joins = new StringBuilder();
            bool EnablePaging = Properties.Settings.Default.EnableRecordPaging;

            Console.WriteLine(string.Format("Current page: {0}", _DataPageNumber));

            if (EnablePaging)
            {
                StatusLabel.Text = string.Format("Paging data... (page {0})", _DataPageNumber.ToString());
            }
            else
            {
                StatusLabel.Text = "Reading data...";
            }

            this.Refresh();

            #region Compose SQL statement

            string[] Fields = { 
                               "Product.ID", "Product.UPI", "Product.Name", 
                               "Image = CASE ISNULL(Product.Image,'') WHEN '' THEN CAST(0 As Bit) ELSE CAST (1 as Bit) END", 
                               "Description = CASE ISNULL(Product.Description,'') WHEN '' THEN CAST(0 As Bit) ELSE CAST (1 as Bit) END",
                               "Product.Recommended", "Schedule.Name AS ScheduleName", "Category.Name AS CategoryName",
                               "Product.Approved AS Active", "Product.PrivateLabelUPI", "Product.Price", 
                               "Product.RecommendedPrice", "Product.InStoreOnly", "Product.Limit", "Product.ShelfTalker"
                              };

            #endregion

            // Different behaviour depending upon search or not

            #region Not searching

            if (SearchString.Trim().Length == 0)
            {
                #region Handle approval

                // Allow the user to specify Active as 3 states (yes, no and both)

                #region BOTH Approved Yes and No (ie all)

                if (yesToolStripMenuItem.Checked && noToolStripMenuItem.Checked)
                {
                    // Exclude nothing

                    OutsideWhereClause.Append("Approved = 1");
                    OutsideWhereClause.Append(" OR Approved = 0");
                }

                #endregion

                #region Approved = Yes

                else if (yesToolStripMenuItem.Checked)
                {
                    OutsideWhereClause.Append("Approved = 1");
                }

                #endregion

                #region Approved = No

                else if (noToolStripMenuItem.Checked)
                {
                    OutsideWhereClause.Append("Approved = 0");
                }
                #endregion

                #endregion
            }

            #endregion

            #region Searching

            else
            {

                #region Handle approval

                // Allow the user to specify Approved as 3 states (yes, no and both)

                #region BOTH Approved Yes and No (ie all)

                if (yesToolStripMenuItem.Checked && noToolStripMenuItem.Checked)
                {
                    // Exclude nothing
                    OutsideWhereClause.Append("Approved = 1"); //Inner = Inner.Or(p => p.Approved == true);
                    OutsideWhereClause.Append(" OR Approved = 0"); //Inner = Inner.Or(p => p.Approved == false);
                }

                #endregion

                #region Approved = Yes

                else if (yesToolStripMenuItem.Checked)
                {
                    OutsideWhereClause.Append("Approved = 1"); //product_predicate = product_predicate.And(p => p.Approved == true);
                }

                #endregion

                #region Approved = No

                else if (noToolStripMenuItem.Checked)
                {
                    OutsideWhereClause.Append("Approved = 0"); //product_predicate = product_predicate.And(p => p.Approved == false);
                }

                #endregion

                #endregion

                // Put together the final predicate
            }

            #endregion

            // Core Product view option
            if (coreProductsOnlyToolStripMenuItem.Checked) OutsideWhereClause.Append(" AND CoreProduct = 1");

            if (Properties.Settings.Default.SearchProductName) InsideWhereClause.Append("Product.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchProductUPI) InsideWhereClause.Append("Product.UPI like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchBrandName) InsideWhereClause.Append("Brand.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchCategoryName) InsideWhereClause.Append("Category.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchScheduleName) InsideWhereClause.Append("Schedule.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchConditionName) InsideWhereClause.Append("Condition.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchConditionName) InsideWhereClause.Append("ConditionLinkedWithIngredient.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchEndUse) InsideWhereClause.Append("EndUse.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchProductDescription) InsideWhereClause.Append("Product.Description like '%" + SearchString + "%' OR ");
            
            if (Properties.Settings.Default.SearchScheduleName)
            {
                InsideWhereClause.Append("Product.CustomString1 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString2 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString3 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString4 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString5 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString6 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString7 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString8 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString9 like '%" + SearchString + "%' OR ");
                InsideWhereClause.Append("Product.CustomString10 like '%" + SearchString + "%' OR ");
            }

            if (Properties.Settings.Default.SearchIngredientName) InsideWhereClause.Append("Ingredient.Name like '%" + SearchString + "%'");

            #region Joins...
            // Brand
            Joins.Append("LEFT OUTER JOIN Brand ON Product.BrandID = Brand.ID ");

            //Category
            Joins.Append("LEFT OUTER JOIN ProductCategory ON Product.ID = ProductCategory.ProductID ");
            Joins.Append("LEFT OUTER JOIN Category ON ProductCategory.CategoryID = Category.ID ");

            // End Use
            Joins.Append("LEFT OUTER JOIN ProductEndUse ON Product.ID = ProductEndUse.ProductID ");
            Joins.Append("LEFT OUTER JOIN EndUse ON ProductEndUse.EndUseID = EndUse.ID ");

            // Ingredient
            //Joins.Append("LEFT OUTER JOIN ProductIngredient ON Product.ID = ProductIngredient.ProductID ");
            //Joins.Append("LEFT OUTER JOIN Ingredient ON ProductIngredient.IngredientID = Ingredient.ID ");
            Joins.Append("LEFT OUTER JOIN Ingredient ON Product.IngredientID = Ingredient.ID ");

            // Conditions (related to ingredient)
            Joins.Append("LEFT OUTER JOIN ConditionIngredient AS CI ON Ingredient.ID = CI.IngredientID ");
            Joins.Append("LEFT OUTER JOIN Condition AS ConditionLinkedWithIngredient ON ConditionLinkedWithIngredient.ID = CI.ConditionID ");

            // Schedule
            Joins.Append("LEFT OUTER JOIN Schedule ON Product.ScheduleID = Schedule.ID ");

            // Condition
            Joins.Append("LEFT OUTER JOIN ProductCondition ON Product.ID = ProductCondition.ProductID ");
            Joins.Append("LEFT OUTER JOIN Condition ON ProductCondition.ConditionID = Condition.ID ");
            #endregion

            Cursor.Current = Cursors.WaitCursor;

            // Build query
            string InsideClause = InsideWhereClause.ToString();
            if (InsideClause.EndsWith(" OR "))
            {
                InsideClause = InsideClause.Substring(0, InsideClause.Length - 3);
            }

            StatusLabel.Text = "Building query..."; this.Refresh();
            string Query = Core.SQL.Functions.BuildQuery("Product", Fields, OrderByFieldNames, OutsideWhereClause.ToString(), InsideClause, Joins.ToString(), EnablePaging);

            // Get the total record count
            try
            {
                if (EnablePaging)
                {
                    if (_SearchCounter / 5 == Math.Round(_SearchCounter / 10M, 0))  // Every 10th search calculate the record count
                    {
                        // Get the total (i.e. non-paged) record count
                        StatusLabel.Text = "Reading record count..."; this.Refresh();
                        string CountQuery = Core.SQL.Functions.BuildCountQuery("Product", Fields, null, OutsideWhereClause.ToString(), InsideClause, Joins.ToString(), false);
                        Global.Common.Logging.WriteDebugEvent(String.Format("Main Page Count Query: {0}", CountQuery));
                        _RecordCount = Core.SQL.Functions.Count(CountQuery, Global.SqlConnectionString);
                    }
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Error reading data";
                Global.Common.Logging.WriteErrorEvent(String.Format("Main form (PageData) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
            }

            CalculatePagingDetails();
            UpdatePageRecordStatus(EnablePaging);
            SetupPagingButtons(EnablePaging);

            // Now get data
            try
            {
                DataTable Products = null;
                if (EnablePaging)
                {
                    StatusLabel.Text = "Reading paged Data..."; this.Refresh();
                    Global.Common.Logging.WriteDebugEvent(String.Format("Main Page Query: {0} {1}", "SELECT DISTINCT TOP (100) PERCENT", Query));
                    Products = Core.SQL.Functions.PageData("Products", Query, _CurrentPageRecordStart, Global.DataPageSize, Global.SqlConnectionString).Tables[0];
                }
                else
                {
                    StatusLabel.Text = "Reading Data..."; this.Refresh();
                    Global.Common.Logging.WriteDebugEvent(String.Format("Main Page Query: {0} {1}", "SELECT DISTINCT TOP (100) PERCENT ", Query));
                    Products = Core.SQL.Functions.Execute("SELECT DISTINCT TOP (100) PERCENT " + Query, Global.SqlConnectionString).Tables[0];
                }
                dgvProducts.DataSource = Products;

                if (Products.Rows.Count > 0)
                {
                    SetDataGridViewColumnSizes();
                }

                StatusLabel.Text = "Idle - " + Products.Rows.Count + " records found.";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Error reading data";
                Global.Common.Logging.WriteErrorEvent(String.Format("Main form (PageData) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
            }

            this.Refresh();

            Cursor.Current = Cursors.Default;
        }

        public void RefreshData()
        {
            //_DataPageNumber = 1;
            PageData(toolStripSearchTextbox.Text);
        }

        private void SavePageSize()
        {
            Properties.Settings.Default.DataPageSize = Global.DataPageSize;
            Properties.Settings.Default.Save();
        }

        private void SelectDeveloperMenuItem()
        {
            if (Global.UseDeveloperSettings)
            {
                Global.SqlConnectionString = Properties.Settings.Default.DevDataConnection;

                this.Text = Application.ProductName + " (Developer Connection)";
            }
            else
            {
                Global.SqlConnectionString = Properties.Settings.Default.DataConnectionString;

                this.Text = Application.ProductName;
            }

            CloseDatabaseConnection();
            ConnectToDatabase(Properties.Settings.Default.EnableRecordPaging);

            //SetConnectedImage();
        }

        private void SetConnectedImage()
        {
            if (Global.SqlConnectionString == Properties.Settings.Default.DataConnectionString)
            {
                ConnectionStatus.Image = imlMain.Images[1];
                ConnectionStatus.Text = "Connected";
            }
            else
            {
                ConnectionStatus.Image = imlMain.Images[6];
                ConnectionStatus.Text = "Dev Connected";
            }
        }

        private void SetDataGridViewColumnSizes()
        {
            dgvProducts.Columns[0].Width = 50; // ID
            dgvProducts.Columns[1].Width = 70; // UPI
            dgvProducts.Columns[2].Width = 370; // Name
            dgvProducts.Columns[3].Width = 50; // Image
            dgvProducts.Columns[4].Width = 50; // Description
            dgvProducts.Columns[5].Width = 50; // Recommended
            dgvProducts.Columns[6].Width = 180; // Schedule
            dgvProducts.Columns[7].Width = 90; // Category
            dgvProducts.Columns[8].Width = 50; // Approved
            dgvProducts.Columns[9].Width = 50; // Private Label UPI
            dgvProducts.Columns[10].Width = 50; // Price
            dgvProducts.Columns[11].Width = 50; // Recommended Price
            dgvProducts.Columns[12].Width = 50; // Store Only
            dgvProducts.Columns[13].Width = 30; // Limit
            dgvProducts.Columns[14].Width = 50; // Shelf Talker

            // Set first and last Columns as not visible
            dgvProducts.Columns[0].Visible = false;
            //dgvProducts.Columns[dgvProducts.Columns.Count - 1].Visible = false;

        }

        private void SetupPagingButtons(bool PagingEnabled)
        {
            StatusLabel.Text = "Setting up Paging buttons..."; this.Refresh();

            if (PagingEnabled)
            {
                if (_RecordCount > _CurrentPageRecordFinish)
                {
                    toolStripNextButton.Enabled = true;
                    toolStripLastButton.Enabled = true;
                }
                else
                {
                    toolStripNextButton.Enabled = false;
                    toolStripLastButton.Enabled = false;
                }

                if (_DataPageNumber > 1)
                {
                    toolStripPreviousButton.Enabled = true;
                    toolStripFirstButton.Enabled = true;
                }
                else
                {
                    toolStripPreviousButton.Enabled = false;
                    toolStripFirstButton.Enabled = false;
                }
            }
            else
            {
                toolStripFirstButton.Enabled = false;
                toolStripNextButton.Enabled = false;
                toolStripPreviousButton.Enabled = false;
                toolStripLastButton.Enabled = false;
            }
        }

        private void UpdatePageRecordStatus(bool PagingEnabled)
        {
            StatusLabel.Text = "Updating Page Record Status..."; this.Refresh();

            if (PagingEnabled)
            {
                if (_RecordCount > 0)
                {
                    toolStripRecordInfo.Text = string.Format("{0} - {1} of {2}", _CurrentPageRecordStart, _CurrentPageRecordFinish, _RecordCount);
                }
                else
                {
                    toolStripRecordInfo.Text = string.Format("No records");
                }
            }
            else
            {
                toolStripRecordInfo.Text = string.Format("No paging");
            }
        }
    }
}
