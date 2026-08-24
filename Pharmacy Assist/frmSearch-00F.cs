using i00SpellCheck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmSearch : Form
    {
        
        private System.Timers.Timer _AutoTimer = new System.Timers.Timer();
        private int _CountdownCount = 0;
        private int _CurrentPageRecordFinish = 0;
        private int _CurrentPageRecordStart = 1;
        private int _DataPageNumber = 1;
        private frmMain _MainForm = null;
        private int _RecordCount = 0;
        private int _SearchCounter = 0;

        public frmSearch(frmMain MainForm)
        {
            InitializeComponent();

            _MainForm = MainForm;

            // The DataGridView control needs Double-buffering to speed up the redraw!!!
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvProducts,
                new object[] { true });

            if (Properties.Settings.Default.EnableSpellCheck) this.EnableControlExtensions();

            _AutoTimer.AutoReset = false;
            _AutoTimer.SynchronizingObject = this;
            _AutoTimer.Elapsed += new ElapsedEventHandler(_AutoTimer_Elapsed);

        }

        #region Toolstrip

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
                    _MainForm.toolStripDisconnectDatabase.Enabled = false;
                    _MainForm.toolStripConnectDatabase.Enabled = true;

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
                toolStripSearchTextbox.Enabled = true;
                toolStripSearchButton.Enabled = true;

                _DataPageNumber = 1;

                DoSearch(toolStripSearchTextbox.Text.Trim());

                //SetupPagingButtons(EnablePaging);

                toolStripSearchTextbox.Focus();
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

        private void frmSearch_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);
            
            //Global.GetThemeColours(Properties.Settings.Default.SearchColourThemeNumber, ref BackColor, ref AlternateBackColor);

            dgvProducts.DefaultCellStyle.BackColor = Global.Theme[30];
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Global.Theme[31];

            // Note:  There is no bounds checking in the following code, 
            // so if the form is positioned on a monitor that is
            // subsequently removed, the form will not be accessible
            if (Properties.Settings.Default.SearchFormSize.X != 0)
            {
                this.Width = Properties.Settings.Default.SearchFormSize.X;
                this.Height = Properties.Settings.Default.SearchFormSize.Y;
            }

            if (Properties.Settings.Default.SearchFormPosition.X != 0)
            {
                this.Left = Properties.Settings.Default.SearchFormPosition.X;
                this.Top = Properties.Settings.Default.SearchFormPosition.Y;
            }
            
            this.Show();
            this.Refresh();

            ConnectionStatus.Image = imlMain.Images[0];

            Global.DataPageSize = Properties.Settings.Default.DataPageSize;

            // If running in the development environment, assume connection to developer database
            if (Debugger.IsAttached)
            {
                _MainForm.UseDevConnectionToolStripMenuItem.Checked = true;
                SelectDeveloperMenuItem();
            }
            else
            {
                ConnectToDatabase(Properties.Settings.Default.EnableRecordPaging);
            }
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
                    _MainForm.toolStripConnectDatabase.Enabled = false;

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

                frmProductDetail f = new frmProductDetail(ID: ID, Parent: null);

                f.Show();

                StatusLabel.Text = "Idle";
            }

            Cursor.Current = Cursors.Default;
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

                if (_MainForm.yesToolStripMenuItem.Checked && _MainForm.noToolStripMenuItem.Checked)
                {
                    // Exclude nothing

                    OutsideWhereClause.Append("Approved = 1");
                    OutsideWhereClause.Append(" OR Approved = 0");
                }

                #endregion

                #region Approved = Yes

                else if (_MainForm.yesToolStripMenuItem.Checked)
                {
                    OutsideWhereClause.Append("Approved = 1");
                }

                #endregion

                #region Approved = No

                else if (_MainForm.noToolStripMenuItem.Checked)
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

                if (_MainForm.yesToolStripMenuItem.Checked && _MainForm.noToolStripMenuItem.Checked)
                {
                    // Exclude nothing
                    OutsideWhereClause.Append("Approved = 1"); //Inner = Inner.Or(p => p.Approved == true);
                    OutsideWhereClause.Append(" OR Approved = 0"); //Inner = Inner.Or(p => p.Approved == false);
                }

                #endregion

                #region Approved = Yes

                else if (_MainForm.yesToolStripMenuItem.Checked)
                {
                    OutsideWhereClause.Append("Approved = 1"); //product_predicate = product_predicate.And(p => p.Approved == true);
                }

                #endregion

                #region Approved = No

                else if (_MainForm.noToolStripMenuItem.Checked)
                {
                    OutsideWhereClause.Append("Approved = 0"); //product_predicate = product_predicate.And(p => p.Approved == false);
                }

                #endregion

                #endregion

                // Put together the final predicate
            }

            #endregion

            // Core Product view option
            if (_MainForm.coreProductsOnlyToolStripMenuItem.Checked) OutsideWhereClause.Append(" AND CoreProduct = 1");

            if (Properties.Settings.Default.SearchProductName) InsideWhereClause.Append("Product.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchProductUPI) InsideWhereClause.Append("Product.UPI like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchBrandName) InsideWhereClause.Append("Brand.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchCategoryName) InsideWhereClause.Append("Category.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchScheduleName) InsideWhereClause.Append("Schedule.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchConditionName) InsideWhereClause.Append("Condition.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchConditionName) InsideWhereClause.Append("ConditionLinkedWithIngredient.Name like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchProductDescription) InsideWhereClause.Append("Product.Description like '%" + SearchString + "%' OR ");
            if (Properties.Settings.Default.SearchEndUse) InsideWhereClause.Append("EndUse.Name like '%" + SearchString + "%' OR ");

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
                this.Refresh();
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
                this.Refresh();
            }

            this.Refresh();

            Cursor.Current = Cursors.Default;
        }

        private void SelectDeveloperMenuItem()
        {
            if (_MainForm.UseDevConnectionToolStripMenuItem.Checked)
            {
                Global.SqlConnectionString = Properties.Settings.Default.DevDataConnection;

                //this.Text = Application.ProductName + " (Developer Connection)";
            }
            else
            {
                Global.SqlConnectionString = Properties.Settings.Default.DataConnectionString;

                //this.Text = Application.ProductName;
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
                toolStripFirstButton.Visible = true;
                toolStripNextButton.Visible = true;
                toolStripPreviousButton.Visible = true;
                toolStripLastButton.Visible = true;
                toolStripRecordInfo.Visible = true;
                toolStripSeparator3.Visible = true;

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
                toolStripFirstButton.Visible = false;
                toolStripNextButton.Visible = false;
                toolStripPreviousButton.Visible = false;
                toolStripLastButton.Visible = false;
                toolStripRecordInfo.Visible = false;
                toolStripSeparator3.Visible = false;
            }
        }

        private void toolStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SearchFormPosition = new Point(this.Left, this.Top);
            Properties.Settings.Default.SearchFormSize = new Point(this.Width, this.Height);
            Properties.Settings.Default.Save();

            Global.RemoveFormFromList(this);
        }

        private void toolStripSearchTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DoSearch(toolStripSearchTextbox.Text.Trim());
            }
        }
    }
}
