using Core.FileTransfer;
using i00SpellCheck;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmListEdit007 : Form
    {
        private System.Collections.Generic.List<DatabaseColumn> _Columns = new List<DatabaseColumn>();
        private DatabaseColumn _CurrentColumn = null;
        private DataSet _CurrentDataset = null;
        private DataRow _CurrentRecord = null;
        private bool _FilterInProgress = false;
        private int _ItemID = 0;
        private string _ItemName = "";

        public string ListDisplayName { get; set; }

        public frmListEdit007(string DisplayName)
        {
            InitializeComponent();

            // The Listbox control needs Double-buffering to speed up the redraw!!!
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                lstItems,
                new object[] { true });

            this.Text = DisplayName;

            ListDisplayName = DisplayName;

            //this.EnableControlExtensions();

        }

        private void AddColumnsFromQuery(string Query)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (Query != "")
            {
                _CurrentDataset = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                if (_CurrentDataset.Tables[0].Rows.Count > 0) // Will only ever equal 1 or 0
                {
                    _CurrentRecord = _CurrentDataset.Tables[0].Rows[0];
                    _Columns.Clear();

                    int ColumnCounter = 0;
                    List<DatabaseColumn> Columns = new List<DatabaseColumn>();

                    foreach (DataColumn Column in _CurrentDataset.Tables[0].Columns)
                    {
                        DatabaseColumn DbColumn = new DatabaseColumn();

                        DbColumn.Index = ColumnCounter;
                        DbColumn.Name = _CurrentDataset.Tables[0].Columns[ColumnCounter].ColumnName;
                        DbColumn.Value = _CurrentDataset.Tables[0].Rows[0][ColumnCounter];
                        DbColumn.DataType = _CurrentDataset.Tables[0].Columns[ColumnCounter].DataType;

                        Columns.Add(DbColumn);

                        ColumnCounter++;
                    }

                    AddColumnsToListbox(Columns);
                }
            }
            else
            {
                MessageBox.Show("Mismatch:  No query for this Item type.  Contact Development support");
            }
            Cursor.Current = Cursors.Default;
        }

        private void AddColumnsToListbox(List<DatabaseColumn> Columns)
        {
            int ColumnCount = 0;
            Document Doc = new Document();

            lstColumns.Items.Clear();

            foreach (DatabaseColumn Column in Columns)
            {
                _Columns.Add(Column);
                _CurrentColumn = Column;

                if (Column.Name.ToLower() != "id") // Don't add the ID column to the list as it makes no sense to the user
                {
                    lstColumns.Items.Add(Column);
                }

                // Documents are treated differently
                if (ListDisplayName == "Documents")
                {
                    switch (Column.Name)
                    {
                        case "ID":
                            {
                                Doc.ID = (int)Column.Value;
                                break;
                            }
                        case "Path":
                            {
                                Doc.Path = (string)Column.Value;
                                break;
                            }
                        case "Filename":
                            {
                                Doc.FileName = (string)Column.Value;
                                break;
                            }
                        case "Name":
                            {
                                Doc.Name = (string)Column.Value;
                                break;
                            }
                        case "PublicAccess":
                            {
                                Doc.Public = (bool)Column.Value;
                                break;
                            }
                    }
                }

                ColumnCount++;
            }

            btnViewDocument.Tag = Doc;
        }

        private void ApplyPermissions()
        {

        }

        private void btnAcceptEdits_Click(object sender, EventArgs e)
        {
            bool Success = true;
            // DataRow _CurrentRecord contains the details of the selected record
            // int _ItemID is the ID of the selected item
            // List<DatabaseColumn> _Columns contains all the columns of the current record
            // DatabaseColumn _CurrentColumn contains the current column

            // Copy values to the listbox
            switch (_CurrentColumn.DataType.ToString())
            {
                case ("System.String"):
                    txtValue.Visible = true;
                    chkValue.Visible = false;

                    _CurrentColumn.Value = txtValue.Text;
                    break;
                case ("System.Int32"):
                    txtValue.Visible = true;
                    chkValue.Visible = false;

                    if (Microsoft.VisualBasic.Information.IsNumeric(txtValue.Text))
                    {
                        _CurrentColumn.Value = Convert.ToInt32(txtValue.Text);
                    }
                    else
                    {
                        Success = false;
                    }
                    break;
                case ("System.DateTime"):
                    txtValue.Visible = true;
                    chkValue.Visible = false;

                    if (Microsoft.VisualBasic.Information.IsDate(txtValue.Text))
                    {
                        _CurrentColumn.Value = Convert.ToDateTime(txtValue.Text);
                    }
                    else
                    {
                        Success = false;
                    }
                    break;
                case ("System.Decimal"):
                    txtValue.Visible = true;
                    chkValue.Visible = false;

                    if (Microsoft.VisualBasic.Information.IsNumeric(txtValue.Text))
                    {
                        _CurrentColumn.Value = Convert.ToDecimal(txtValue.Text);
                    }
                    else
                    {
                        Success = false;
                    }
                    break;
                case ("System.Boolean"):
                    txtValue.Visible = false;
                    chkValue.Visible = true;

                    _CurrentColumn.Value = chkValue.Checked;
                    break;
            }

            if (Success)
            {
                int ColumnCounter = 0;
                List<DatabaseColumn> Columns = new List<DatabaseColumn>();

                if (_ItemID != 0) // UPDATES
                {
                    foreach (DataColumn Column in _CurrentRecord.Table.Columns)
                    {
                        DatabaseColumn DbColumn = new DatabaseColumn();

                        if (ColumnCounter == _CurrentColumn.Index)
                        {
                            // Replace the value of the stored column with the new value
                            if (Column.DataType == typeof(System.Boolean))
                            {
                                DbColumn.Value = chkValue.Checked;
                                _CurrentDataset.Tables[0].Rows[0][ColumnCounter] = chkValue.Checked;
                            }
                            else
                            {
                                DbColumn.Value = txtValue.Text;
                                _CurrentDataset.Tables[0].Rows[0][ColumnCounter] = txtValue.Text;
                            }
                        }
                        else
                        {
                            DbColumn.Value = _CurrentDataset.Tables[0].Rows[0][ColumnCounter];
                        }

                        DbColumn.Index = ColumnCounter;
                        DbColumn.Name = Column.ColumnName;
                        DbColumn.DataType = Column.DataType;

                        Columns.Add(DbColumn);

                        ColumnCounter++;
                    }
                }
                else // INSERT
                {
                    foreach (DatabaseColumn Column in lstColumns.Items)
                    {
                        DatabaseColumn DbColumn = new DatabaseColumn();

                        DbColumn.Value = Column.Value;
                        DbColumn.Index = Column.Index;
                        DbColumn.Name = Column.Name;
                        DbColumn.DataType = Column.DataType;

                        Columns.Add(DbColumn);
                    }
                }

                AddColumnsToListbox(Columns);

                // Now setup the GUI for the next edit
                btnSaveEdit.Enabled = true;
                btnCancelEdit.Enabled = true;
                btnAcceptEdits.Enabled = false;

                txtValue.Enabled = false;
                chkValue.Enabled = false;
            }
            else
            {
                txtValue.Text = "";
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            _ItemID = 0;

            lblLinkInfo.Text = "";
            lblDocumentInfo.Text = "";
            chkValue.Checked = false;
            txtPropertyName.Text = "";

            btnAddItem.Enabled = false;
            btnRemoveItem.Enabled = false;

            List<DatabaseColumn> Fields = GetFields();

            AddColumnsToListbox(Fields);
            lstColumns.SelectedIndex = 0;

            //lstColumns.SelectedItem = null;

            txtValue.Focus();
            txtValue.Text = "";
            txtValue.Enabled = true;
            chkValue.Enabled = true;  // Not visible yet so it should not matter that it is enabled

        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            LoadLists();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            //frmListEdit007 LinkedDocuments = new frmListEdit007("Documents");

            //LinkedDocuments.Show();

            switch (ListDisplayName)
            {
                case "Event":
                case "Events":
                    {
                        string AllItemsQuery = "SELECT ID, Name, Filename, Path FROM Document";
                        string ExistingItemsQuery = "SELECT d.ID, d.Name, d.Filename, d.Path FROM Document d LEFT JOIN EventDocument ed ON ed.DocumentID = d.ID LEFT JOIN Event e ON e.ID = ed.EventID WHERE e.ID = " + _ItemID;

                        frmManageLinkedItems00A LinkedDocuments = new frmManageLinkedItems00A();

                        LinkedDocuments.SourceListQuery = AllItemsQuery;
                        LinkedDocuments.ExistingItemsQuery = ExistingItemsQuery;
                        LinkedDocuments.SourceTable = "Document";
                        LinkedDocuments.ItemType = "Document";
                        LinkedDocuments.LinkedItemID = _ItemID;
                        LinkedDocuments.ParentItemType = Helper.ItemType.Event;
                        LinkedDocuments.SelectText = "Documents for " + lstItems.SelectedItem.ToString() + " (Event)";

                        LinkedDocuments.Show();
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        string AllItemsQuery = "SELECT ID, Name, Filename, Path FROM Document";
                        string ExistingItemsQuery = "SELECT d.ID, d.Name, d.Filename, d.Path FROM Document d LEFT JOIN ConditionDocument cd ON cd.DocumentID = d.ID LEFT JOIN Condition c ON c.ID = cd.ConditionID WHERE c.ID = " + _ItemID;

                        frmManageLinkedItems00A LinkedDocuments = new frmManageLinkedItems00A();

                        LinkedDocuments.SourceListQuery = AllItemsQuery;
                        LinkedDocuments.ExistingItemsQuery = ExistingItemsQuery;
                        LinkedDocuments.SourceTable = "Document";
                        LinkedDocuments.ItemType = "Document";
                        LinkedDocuments.LinkedItemID = _ItemID;
                        LinkedDocuments.ParentItemType = Helper.ItemType.Condition;
                        LinkedDocuments.SelectText = "Documents for " + lstItems.SelectedItem.ToString() + " (Condition)";

                        LinkedDocuments.Show();
                        break;
                    }
            }
        }

        private void btnLinkItems_Click(object sender, EventArgs e)
        {
            // This will NOT show products.
            switch (ListDisplayName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        // Show linked Conditions

                        frmManageLinkedItems00A LinkedItems = new frmManageLinkedItems00A();

                        LinkedItems.SourceListQuery = "SELECT ID, Name, Description, CustomString1, CustomString2, CustomString3, CustomString4 FROM Condition";
                        LinkedItems.ExistingItemsQuery = "SELECT Condition.ID, Condition.Name FROM Condition INNER JOIN ConditionIngredient ON Condition.ID = ConditionIngredient.ConditionID WHERE ConditionIngredient.IngredientID = " + _ItemID;
                        LinkedItems.SelectText = "Conditions for " + lstItems.SelectedItem.ToString() + " (Active Ingredient)";
                        LinkedItems.SourceTable = "Condition";
                        LinkedItems.LinkedItemID = _ItemID;
                        LinkedItems.ItemType = "Condition";
                        LinkedItems.ParentItemType = Helper.ItemType.ActiveIngredient;
                        LinkedItems.Show();
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        // Show linked Events

                        frmManageLinkedItems00A LinkedItems = new frmManageLinkedItems00A();

                        LinkedItems.SourceListQuery = "SELECT ID, Name, Description, StartDate, Duration, OwnerUserAccountID, AllowTask, TypeID, CertificateID, WarningPeriod, Recurrance, PresenterID, Enabled FROM Event";
                        LinkedItems.ExistingItemsQuery = "SELECT DISTINCT e.ID, e.Name FROM Event e LEFT JOIN Certificate c ON e.CertificateID = c.ID WHERE c.ID = " + _ItemID;
                        LinkedItems.SelectText = "Events for " + lstItems.SelectedItem.ToString() + " (Certificate)";
                        LinkedItems.SourceTable = "Event";
                        LinkedItems.LinkedItemID = _ItemID;
                        LinkedItems.ItemType = "Event";
                        LinkedItems.ParentItemType = Helper.ItemType.Certificate;
                        LinkedItems.Show();
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        // Show linked Ingredients

                        frmManageLinkedItems00A LinkedItems = new frmManageLinkedItems00A();

                        LinkedItems.SourceListQuery = "SELECT ID, Name, Description, CustomString1, CustomString2, CustomString3, CustomString4 FROM Ingredient";
                        LinkedItems.ExistingItemsQuery = "SELECT Ingredient.ID, Ingredient.Name FROM Ingredient INNER JOIN ConditionIngredient ON Ingredient.ID = ConditionIngredient.IngredientID INNER JOIN Condition ON ConditionIngredient.ConditionID = Condition.ID WHERE Condition.ID = " + _ItemID;
                        LinkedItems.SelectText = "Ingredients for " + lstItems.SelectedItem.ToString() + " (Condition)";
                        LinkedItems.SourceTable = "Ingredient";
                        LinkedItems.LinkedItemID = _ItemID;
                        LinkedItems.ItemType = "Ingredient";
                        LinkedItems.ParentItemType = Helper.ItemType.Condition;
                        LinkedItems.Show();
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        // Show linked Conditions

                        frmManageLinkedItems00A LinkedItems = new frmManageLinkedItems00A();

                        LinkedItems.SourceListQuery = "SELECT ID, Name, Description, CustomString1, CustomString2, CustomString3, CustomString4 FROM Condition";
                        LinkedItems.ExistingItemsQuery = "SELECT c.ID, c.Name from dbo.Condition c INNER JOIN dbo.ConditionDocument cd ON cd.ConditionId = c.ID INNER JOIN dbo.Document d ON cd.DocumentID = d.ID WHERE d.ID = " + _ItemID;
                        LinkedItems.SelectText = "Conditions for " + lstItems.SelectedItem.ToString() + " (Document)";
                        LinkedItems.SourceTable = "Condition";
                        LinkedItems.LinkedItemID = _ItemID;
                        LinkedItems.ItemType = "Condition";
                        LinkedItems.ParentItemType = Helper.ItemType.Document;
                        LinkedItems.Show();
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        // Show linked Events

                        frmManageLinkedItems00A LinkedItems = new frmManageLinkedItems00A();

                        LinkedItems.SourceListQuery = "SELECT ID, Name, Description, StartDate, Duration, OwnerUserAccountID, AllowTask, TypeID, CertificateID, WarningPeriod, Recurrance, PresenterID, Enabled FROM Event";
                        LinkedItems.ExistingItemsQuery = "SELECT e.ID, e.Name FROM EVENT e LEFT JOIN EventType et ON e.TypeID = et.ID WHERE e.TypeID = " + _ItemID;
                        LinkedItems.SelectText = "Events for " + lstItems.SelectedItem.ToString() + " (Event Type)";
                        LinkedItems.SourceTable = "Event";
                        LinkedItems.LinkedItemID = _ItemID;
                        LinkedItems.ItemType = "Event";
                        LinkedItems.ParentItemType = Helper.ItemType.EventType;
                        LinkedItems.Show();
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        // Show linked Roles

                        frmManageLinkedItems00A LinkedItems = new frmManageLinkedItems00A();

                        LinkedItems.SourceListQuery = "SELECT ID, Name, Description FROM Role";
                        LinkedItems.ExistingItemsQuery = "SELECT r.ID, r.Name FROM dbo.Role r LEFT JOIN dbo.RolePermission rp ON rp.RoleID = r.ID LEFT JOIN dbo.Permission p ON rp.PermissionID = p.ID WHERE p.ID = " + _ItemID;
                        LinkedItems.SelectText = "Roles for " + lstItems.SelectedItem.ToString() + " (Permission)";
                        LinkedItems.SourceTable = "Role";
                        LinkedItems.LinkedItemID = _ItemID;
                        LinkedItems.ItemType = "Role";
                        LinkedItems.ParentItemType = Helper.ItemType.Permission;
                        LinkedItems.Show();
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        // Show linked Permissions

                        frmManageLinkedItems00A LinkedItems = new frmManageLinkedItems00A();

                        LinkedItems.SourceListQuery = "SELECT ID, Name, Description FROM Permission";
                        LinkedItems.ExistingItemsQuery = "SELECT p.ID, p.Name FROM dbo.Permission p INNER JOIN dbo.RolePermission rp ON rp.PermissionID = p.ID INNER JOIN dbo.Role r ON rp.RoleID = r.ID WHERE r.ID = " + _ItemID;
                        LinkedItems.SelectText = "Permissions for " + lstItems.SelectedItem.ToString() + " (Role)";
                        LinkedItems.SourceTable = "Permission";
                        LinkedItems.LinkedItemID = _ItemID;
                        LinkedItems.ItemType = "Permission";
                        LinkedItems.ParentItemType = Helper.ItemType.Role;
                        LinkedItems.Show();
                        break;
                    }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProductLinking_Click(object sender, EventArgs e)
        {
            string SelectQuery = "";

            // Open a list of products using this item

            Cursor.Current = Cursors.WaitCursor;

            switch (ListDisplayName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        // Build list of Products using this ingredient
                        //SelectQuery = "SELECT DISTINCT Product.ID, Product.Name FROM Product INNER JOIN ProductIngredient ON Product.ID = ProductIngredient.ProductID INNER JOIN Ingredient ON ProductIngredient.IngredientID = Ingredient.ID WHERE ProductIngredient.IngredientID = " + _ItemID;

                        SelectQuery = "SELECT DISTINCT Product.ID, Product.Name FROM Product WHERE Product.IngredientID = " + _ItemID;

                        //int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (ProductRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                        LinkedProducts.ProductSelectQuery = SelectQuery;
                        LinkedProducts.ItemName = "Product";

                        LinkedProducts.Show();
                        //}

                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        // Build list of Products with this Brand
                        SelectQuery = "SELECT DISTINCT Product.ID, Product.Name FROM Product WHERE Product.BrandID = " + _ItemID;

                        //int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (ProductRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                        LinkedProducts.ProductSelectQuery = SelectQuery;
                        LinkedProducts.ItemName = "Product";

                        LinkedProducts.Show();
                        //}

                        break;
                    }
                case "Catalog":
                case "Catalogs":
                    {
                        // Build list of Products in this Catalog
                        SelectQuery = "SELECT DISTINCT p.ID, p.Name + ' ($' + CAST(pc.Price AS VARCHAR) + ')' AS Name FROM Catalog c LEFT JOIN ProductCatalog pc ON c.RPMID = pc.CatalogID LEFT JOIN Product p ON pc.ProductID = p.ID WHERE c.RPMID =" + _ItemID;

                        //int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (ProductRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                        LinkedProducts.ProductSelectQuery = SelectQuery;
                        LinkedProducts.ItemName = "Product";

                        LinkedProducts.Show();
                        //}

                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        // Build list of Products in this Category
                        SelectQuery = "SELECT DISTINCT Product.ID, Product.Name FROM Product INNER JOIN ProductCategory ON ProductCategory.ProductID = Product.ID WHERE ProductCategory.CategoryID = " + _ItemID;

                        //int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (ProductRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                        LinkedProducts.ProductSelectQuery = SelectQuery;
                        LinkedProducts.ItemName = "Product";

                        LinkedProducts.Show();
                        //}

                        break;
                    }
                case "Conditions":
                    {
                        // Build list of Products that treat this Condition 
                        SelectQuery = "SELECT DISTINCT Product.ID, Product.Name FROM Product INNER JOIN ProductCondition ON Product.ID = ProductCondition.ProductID INNER JOIN Condition ON ProductCondition.ConditionID = Condition.ID WHERE Condition.ID = " + _ItemID;

                        //int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (ProductRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                        LinkedProducts.ProductSelectQuery = SelectQuery;
                        LinkedProducts.ItemName = "Product";

                        LinkedProducts.Show();
                        //}

                        // Build list of ingredients that treat this condition
                        SelectQuery = "SELECT DISTINCT Ingredient.ID, Ingredient.Name FROM Ingredient INNER JOIN ConditionIngredient ON Ingredient.ID = ConditionIngredient.IngredientID INNER JOIN Condition ON ConditionIngredient.ConditionID = Condition.ID WHERE Condition.ID = " + _ItemID;

                        //int IngredientRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (IngredientRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedConditions = new frmLinkedItems006();

                        LinkedConditions.ProductSelectQuery = SelectQuery;
                        LinkedConditions.ItemName = "Ingredient";

                        LinkedConditions.Show();
                        //}

                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        // Nothing done for Document.  Products can't be linked to documents
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        // Build list of Products with this Schedule
                        SelectQuery = "SELECT DISTINCT Product.ID, Product.Name FROM Product WHERE Product.ScheduleID = " + _ItemID;

                        //int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (ProductRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                        LinkedProducts.ProductSelectQuery = SelectQuery;
                        LinkedProducts.ItemName = "Product";

                        LinkedProducts.Show();
                        //}

                        break;
                    }
                case "Stores":
                    {
                        // Update stock levels to reflect the store change

                        MessageBox.Show("Function not currently enabled.");
                        break;
                    }
                case "End Uses":
                    {
                        // Build list of Products with this End Use
                        SelectQuery = "SELECT DISTINCT Product.ID, Product.Name FROM Product INNER JOIN ProductEndUse ON Product.ID = ProductEndUse.ProductID INNER JOIN EndUse ON ProductEndUse.EndUseID = EndUse.ID WHERE EndUse.ID = " + _ItemID;

                        //int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (ProductRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                        LinkedProducts.ProductSelectQuery = SelectQuery;
                        LinkedProducts.ItemName = "Product";

                        LinkedProducts.Show();
                        //}

                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        // Build list of Products with this Unit Of Measure
                        SelectQuery = "SELECT DISTINCT Product.ID, Product.Name FROM Product WHERE Product.MeasureID = " + _ItemID;

                        //int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        //if (ProductRecordCount > 0)
                        //{
                        frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                        LinkedProducts.ProductSelectQuery = SelectQuery;
                        LinkedProducts.ItemName = "Product";

                        LinkedProducts.Show();
                        //}

                        break;
                    }
            }

            Cursor.Current = Cursors.Default;

            //LoadLists();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ListItem SelectedItem = null;

            if (lstItems.SelectedItem != null) SelectedItem = (ListItem)lstItems.SelectedItem;

            LoadLists();

            if (SelectedItem != null) lstItems.SelectedItem = SelectedItem;

        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            string SelectQuery = "";
            string DeleteQuery = "";

            // Tell the user how many linked items are using this item

            Cursor.Current = Cursors.WaitCursor;

            // Depending on what type of item this is, we may have to delete joining records
            switch (ListDisplayName)
            {
                #region Active Ingredient

                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        // Build list of Products using this ingredient
                        //SelectQuery = "SELECT Product.UPI, Product.Name FROM Product INNER JOIN ProductIngredient ON Product.ID = ProductIngredient.ProductID INNER JOIN Ingredient ON ProductIngredient.IngredientID = Ingredient.ID WHERE ProductIngredient.IngredientID = " + _ItemID;
                        SelectQuery = "SELECT Product.UPI, Product.Name FROM Product INNER JOIN Ingredient ON Product.IngredientID = Ingredient.ID = Ingredient.ID WHERE Product.IngredientID = " + _ItemID;
                        DeleteQuery = "DELETE FROM ProductIngredient WHERE IngredientID = " + _ItemID;

                        int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        lblLinkInfo.Text = ProductRecordCount + " Products linked.";

                        if (ProductRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                            LinkedProducts.ProductSelectQuery = SelectQuery;
                            LinkedProducts.ProductDeleteQuery = DeleteQuery;
                            LinkedProducts.ItemName = "Products";

                            LinkedProducts.Show();
                        }

                        // Build list of conditions this ingredient is used for
                        SelectQuery = "SELECT Condition.ID, Condition.Name FROM Condition INNER JOIN ConditionIngredient ON Condition.ID = ConditionIngredient.ConditionID WHERE ConditionIngredient.IngredientID = " + _ItemID;
                        DeleteQuery = "DELETE FROM ConditionIngredient WHERE IngredientID = " + _ItemID;

                        int ConditionRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ConditionRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedConditions = new frmLinkedItems006();

                            LinkedConditions.ProductSelectQuery = SelectQuery;
                            LinkedConditions.ProductDeleteQuery = DeleteQuery;
                            LinkedConditions.ItemName = "Conditions";

                            LinkedConditions.Show();
                        }

                        if (ProductRecordCount == 0 && ConditionRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }

                        break;
                    }

                #endregion

                #region Brand

                case "Brand":
                case "Brands":
                    {
                        // Build list of Products with this Brand
                        SelectQuery = "SELECT Product.UPI, Product.Name FROM Product WHERE Product.BrandID = " + _ItemID;
                        DeleteQuery = "DELETE FROM Brand WHERE ID = " + _ItemID;

                        int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ProductRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                            LinkedProducts.ProductSelectQuery = SelectQuery;
                            LinkedProducts.ProductDeleteQuery = DeleteQuery;
                            LinkedProducts.ItemName = "Brands";

                            LinkedProducts.Show();
                        }

                        if (ProductRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }
                        break;
                    }

                #endregion

                #region Category

                case "Category":
                case "Categories":
                    {
                        // Build list of Products in this Category
                        SelectQuery = "SELECT Product.UPI, Product.Name FROM Product INNER JOIN ProductCategory ON ProductCategory.ProductID = Product.ID WHERE ProductCategory.CategoryID = " + _ItemID;
                        DeleteQuery = "DELETE FROM ProductCategory WHERE CategoryID = " + _ItemID;

                        int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ProductRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                            LinkedProducts.ProductSelectQuery = SelectQuery;
                            LinkedProducts.ProductDeleteQuery = DeleteQuery;
                            LinkedProducts.ItemName = "Categories";

                            LinkedProducts.Show();
                        }

                        if (ProductRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }
                        break;
                    }

                #endregion

                #region Certificate

                case "Certificate":
                case "Certificates":
                    {
                        // Build list of Events with this Certificate
                        SelectQuery = "SELECT e.ID, e.Name FROM Event e LEFT JOIN EventCertificate ec ON ec.EventID = e.ID LEFT JOIN Certificate c ON ec.CertificateID = ec.CertificateID WHERE e.ID = " + _ItemID;
                        DeleteQuery = "DELETE FROM Event WHERE ID = " + _ItemID;

                        int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ProductRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                            LinkedProducts.ProductSelectQuery = SelectQuery;
                            LinkedProducts.ProductDeleteQuery = DeleteQuery;
                            LinkedProducts.ItemName = "Event";

                            LinkedProducts.Show();
                        }

                        if (ProductRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }
                        break;
                    }

                #endregion

                #region Condition

                case "Condition":
                case "Conditions":
                    {
                        // Build list of Products that treat this Condition 
                        SelectQuery = "SELECT Product.UPI, Product.Name FROM Product INNER JOIN ProductCondition ON Product.ID = ProductCondition.ProductID INNER JOIN Condition ON ProductCondition.ConditionID = Condition.ID WHERE Condition.ID = " + _ItemID;
                        DeleteQuery = "DELETE FROM ProductCondition WHERE ConditionID = " + _ItemID;

                        int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ProductRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                            LinkedProducts.ProductSelectQuery = SelectQuery;
                            LinkedProducts.ProductDeleteQuery = DeleteQuery;
                            LinkedProducts.ItemName = "Products";

                            LinkedProducts.Show();
                        }

                        // Build list of ingredients that treat this condition
                        SelectQuery = "SELECT Ingredient.ID, Ingredient.Name FROM Ingredient INNER JOIN ConditionIngredient ON Ingredient.ID = ConditionIngredient.IngredientID INNER JOIN Condition ON ConditionIngredient.ConditionID = Condition.ID WHERE Condition.ID = " + _ItemID;
                        DeleteQuery = "DELETE FROM ConditionIngredient WHERE IngredientID = " + _ItemID;

                        int IngredientRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (IngredientRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedConditions = new frmLinkedItems006();

                            LinkedConditions.ProductSelectQuery = SelectQuery;
                            LinkedConditions.ProductDeleteQuery = DeleteQuery;
                            LinkedConditions.ItemName = "Ingredients";

                            LinkedConditions.Show();
                        }

                        if (ProductRecordCount == 0 && IngredientRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }

                        break;
                    }

                #endregion

                #region Document

                case "Document":
                case "Documents":
                    {
                        // Build list of conditions this document is linked to
                        SelectQuery = "SELECT Condition.ID, Condition.Name FROM Condition INNER JOIN ConditionDocument ON Condition.ID = ConditionDocument.ConditionID WHERE ConditionDocument.DocumentID = " + _ItemID;
                        DeleteQuery = "DELETE FROM ConditionDocument WHERE DocumentID = " + _ItemID;

                        int ConditionRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ConditionRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedConditions = new frmLinkedItems006();

                            LinkedConditions.ProductSelectQuery = SelectQuery;
                            LinkedConditions.ProductDeleteQuery = DeleteQuery;
                            LinkedConditions.ItemName = "Conditions";

                            LinkedConditions.Show();
                        }

                        if (ConditionRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }
                        break;
                    }

                #endregion

                #region End Use

                case "End Use":
                case "End Uses":
                    {
                        // Build list of Products with this End Use
                        SelectQuery = "SELECT Product.UPI, Product.Name FROM Product INNER JOIN ProductEndUse ON Product.ID = ProductEndUse.ProductID INNER JOIN EndUse ON ProductEndUse.EndUseID = EndUse.ID WHERE EndUse.ID = " + _ItemID;
                        DeleteQuery = "DELETE FROM ProductEndUse WHERE EndUseID = " + _ItemID;

                        int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ProductRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                            LinkedProducts.ProductSelectQuery = SelectQuery;
                            LinkedProducts.ProductDeleteQuery = DeleteQuery;
                            LinkedProducts.ItemName = "Categories";

                            LinkedProducts.Show();
                        }

                        if (ProductRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }

                        break;
                    }
                #endregion

                #region Event

                case "Event":
                case "Events":
                    {
                        // Delete this item
                        DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                        Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                        LoadLists();

                        break;
                    }
                #endregion

                #region Event Type

                case "Event Type":
                case "Event Types":
                    {
                        // Delete this item
                        DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                        Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                        LoadLists();

                        break;
                    }
                #endregion

                // Permission

                #region Product

                case "Product":
                case "Products":
                    {
                        // Delete this item
                        DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                        Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                        LoadLists();

                        break;
                    }
                #endregion

                #region Role

                case "Role":
                case "Roles":
                    {
                        // Delete this item
                        DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                        Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                        LoadLists();

                        break;
                    }
                #endregion

                #region Schedule

                case "Schedule":
                case "Schedules":
                    {
                        // Build list of Products with this Schedule
                        SelectQuery = "SELECT Product.UPI, Product.Name FROM Product WHERE Product.ScheduleID = " + _ItemID;
                        DeleteQuery = "DELETE FROM Schedule WHERE ID = " + _ItemID;

                        int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ProductRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                            LinkedProducts.ProductSelectQuery = SelectQuery;
                            LinkedProducts.ProductDeleteQuery = DeleteQuery;
                            LinkedProducts.ItemName = "Schedules";

                            LinkedProducts.Show();
                        }

                        if (ProductRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }
                        break;
                    }

                #endregion

                #region Store

                case "Store":
                case "Stores":
                    {
                        // Update stock levels to reflect the store change

                        MessageBox.Show("Delete of stores is not currently enabled.");
                        break;
                    }

                #endregion

                #region Unit Of Measure

                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        // Build list of Products with this Unit Of Measure
                        SelectQuery = "SELECT Product.UPI, Product.Name FROM Product WHERE Product.MeasureID = " + _ItemID;
                        DeleteQuery = "DELETE FROM UnitOfMeasure WHERE ID = " + _ItemID;

                        int ProductRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

                        if (ProductRecordCount > 0)
                        {
                            frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                            LinkedProducts.ProductSelectQuery = SelectQuery;
                            LinkedProducts.ProductDeleteQuery = DeleteQuery;
                            LinkedProducts.ItemName = "Units Of Measure";

                            LinkedProducts.Show();
                        }

                        if (ProductRecordCount == 0)
                        {
                            // Delete this item
                            DeleteQuery = "DELETE FROM " + GetTableName() + " WHERE ID = " + _ItemID;
                            Core.SQL.Functions.ExecuteNonQuery(DeleteQuery.ToString(), Global.SqlConnectionString);

                            LoadLists();
                        }
                        break;
                    }

                #endregion

                // User Account
            }

            Cursor.Current = Cursors.Default;

            LoadLists();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            string TableName = GetTableName();
            StringBuilder Query = new StringBuilder();

            if (_ItemID != 0) // UPDATE
            {
                Query.Append("UPDATE " + TableName + " SET ");

                // Save the user's changes
                for (int i = 0; i < _CurrentRecord.ItemArray.Count(); i++)
                {
                    string ColumnName = _CurrentDataset.Tables[0].Columns[i].ColumnName;

                    if (ColumnName.ToLower() != "id") // ID can't be written
                    {
                        Query.Append(ColumnName);
                        Query.Append(" = ");

                        if (_CurrentDataset.Tables[0].Columns[i].DataType.ToString() == "System.String") Query.Append("'");

                        if (_CurrentDataset.Tables[0].Columns[i].DataType.ToString() == "System.Boolean")
                        {
                            if (_CurrentRecord.ItemArray.GetValue(i).ToString() == "True")
                            {
                                Query.Append("1");
                            }
                            else
                            {
                                Query.Append("0");
                            }
                        }
                        else if (_CurrentDataset.Tables[0].Columns[i].DataType.ToString() == "System.Int32")
                        {
                            if (_CurrentRecord.ItemArray.GetValue(i).ToString() == "")
                            {
                                Query.Append("0");
                            }
                            else
                            {
                                Query.Append(_CurrentRecord.ItemArray.GetValue(i).ToString().Replace("'", "''"));
                            }
                        }
                        else
                        {
                            Query.Append(_CurrentRecord.ItemArray.GetValue(i).ToString().Replace("'", "''"));
                        }

                        if (_CurrentDataset.Tables[0].Columns[i].DataType.ToString() == "System.String") Query.Append("'");

                        if (i < _CurrentRecord.ItemArray.Count() - 1) Query.Append(",");

                        // AUDITING
                        string AuditQuery = "SELECT " + ColumnName + " FROM " + TableName + " WHERE ID = " + _ItemID;
                        DataSet Data = Core.SQL.Functions.Execute(AuditQuery, Global.SqlConnectionString);

                        string OldValue = Convert.ToString(Data.Tables[0].Rows[0][0]);

                        Global.Audit("Update", TableName, ColumnName, (int)_ItemID, Global.Username, OldValue, _CurrentRecord.ItemArray.GetValue(i).ToString(), Application.ProductName, false);
                    }
                }

                Query.Append(" WHERE ID = " + _ItemID);
            }
            else // INSERT
            {
                Query.Append("INSERT INTO " + TableName + " (");

                // Save the user's changes
                for (int i = 0; i < lstColumns.Items.Count; i++)
                {
                    string ColumnName = ((DatabaseColumn)lstColumns.Items[i]).Name;

                    if (ColumnName.ToLower() != "id") // ID can't be written
                    {
                        Query.Append(ColumnName);

                        if (i < lstColumns.Items.Count - 1) Query.Append(",");
                    }
                }

                Query.Append(") ");

                Query.Append("VALUES ( ");

                for (int i = 0; i < lstColumns.Items.Count; i++)
                {
                    string ColumnName = ((DatabaseColumn)lstColumns.Items[i]).Name;

                    if (ColumnName.ToLower() != "id") // ID can't be written
                    {
                        if (((DatabaseColumn)lstColumns.Items[i]).DataType.ToString() == "System.String") Query.Append("'");

                        //if (((DatabaseColumn)lstColumns.Items[i]).DataType.ToString() == "System.Boolean")
                        //{
                        //    if (((DatabaseColumn)lstColumns.Items[i]).Value.ToString() == "True")
                        //    {
                        //        Query.Append("1");
                        //    }
                        //    else
                        //    {
                        //        Query.Append("0");
                        //    }
                        //}
                        //else
                        //{
                        //    Query.Append(((DatabaseColumn)lstColumns.Items[i]).Value.ToString().Replace("'", "''"));
                        //}

                        if (((DatabaseColumn)lstColumns.Items[i]).DataType.ToString() == "System.Boolean")
                        {
                            if (((DatabaseColumn)lstColumns.Items[i]).Value.ToString() == "True")
                            {
                                Query.Append("1");
                            }
                            else
                            {
                                Query.Append("0");
                            }
                        }
                        else if (((DatabaseColumn)lstColumns.Items[i]).DataType.ToString() == "System.Int32")
                        {
                            if (((DatabaseColumn)lstColumns.Items[i]).Value.ToString() == "")
                            {
                                Query.Append("0");
                            }
                            else
                            {
                                Query.Append(((DatabaseColumn)lstColumns.Items[i]).Value.ToString().Replace("'", "''"));
                            }
                        }
                        else
                        {
                            Query.Append(((DatabaseColumn)lstColumns.Items[i]).Value.ToString().Replace("'", "''"));
                        }

                        if (((DatabaseColumn)lstColumns.Items[i]).DataType.ToString() == "System.String") Query.Append("'");

                        if (i < lstColumns.Items.Count - 1) Query.Append(",");
                    }

                    // AUDITING
                    Global.Audit("Insert", TableName, ColumnName, (int)_ItemID, Global.Username.Replace("'", "''"), "", ((DatabaseColumn)lstColumns.Items[i]).Value.ToString().Replace("'", "''"), Application.ProductName, false);
                }

                Query.Append(") ");

            }

            Cursor.Current = Cursors.WaitCursor;

            Core.SQL.Functions.ExecuteNonQuery(Query.ToString(), Global.SqlConnectionString);

            Cursor.Current = Cursors.Default;

            LoadLists();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog Browse = new OpenFileDialog();

            using (Browse)
            {
                Browse.AutoUpgradeEnabled = true;
                Browse.Filter = "Word files (*.doc, *.docx)|*.doc;*.docx;|Excel files (*.xls, *.xlsx)|*.xls;*.xlsx|PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";

                Browse.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string SourceFilename = "";
                string SourceFolder = "";
                string Extension = "";

                DialogResult Result = Browse.ShowDialog();

                if (Result == System.Windows.Forms.DialogResult.OK)
                {
                    SourceFolder = System.IO.Path.GetDirectoryName(Browse.FileName);
                    SourceFilename = System.IO.Path.GetFileNameWithoutExtension(Browse.SafeFileName);
                    Extension = System.IO.Path.GetExtension(Browse.SafeFileName);
                    StartUpload(SourceFolder, SourceFilename, Extension, "/documents/FactCards");
                }
            }
        }

        private void btnUserAccounts_Click(object sender, EventArgs e)
        {
            switch (ListDisplayName)
            {
                case "Role":
                case "Roles":
                    {
                        // Show linked User Accounts

                        string AllItemsQuery = "SELECT ID, Fullname = CASE FirstName + ' ' + LastName WHEN ' ' THEN '(' + UserName + ')' ELSE FirstName + ' ' + LastName END FROM UserAccount";
                        string ExistingItemsQuery = "SELECT DISTINCT u.ID AS ID, u.FirstName + ' ' + u.LastName As Fullname FROM RolePermission AS rp RIGHT OUTER JOIN Role AS r ON rp.RoleID = r.ID LEFT OUTER JOIN Permission AS p ON p.ID = rp.PermissionID RIGHT OUTER JOIN UserAccount AS u LEFT OUTER JOIN UserAccountRole AS ur ON u.ID = ur.UserAccountID ON r.ID = ur.RoleID WHERE r.ID = " + _ItemID;

                        //frmLinkedItems006 LinkedUserAccounts = new frmLinkedItems006();

                        //LinkedUserAccounts.ProductSelectQuery = SelectQuery;
                        //LinkedUserAccounts.ItemName = "User Account";

                        //LinkedUserAccounts.Show();

                        frmManageLinkedItems00A LinkedUserAccounts = new frmManageLinkedItems00A();

                        LinkedUserAccounts.SourceListQuery = AllItemsQuery;
                        LinkedUserAccounts.ExistingItemsQuery = ExistingItemsQuery;
                        LinkedUserAccounts.SourceTable = "UserAccount";
                        LinkedUserAccounts.ItemType = "User Account";
                        LinkedUserAccounts.LinkedItemID = _ItemID;
                        LinkedUserAccounts.SelectText = "User Accounts for " + lstItems.SelectedItem.ToString() + " (Role)";

                        LinkedUserAccounts.Show();
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        // Show linked User Accounts

                        string AllItemsQuery = "SELECT ID, Fullname = CASE FirstName + ' ' + LastName WHEN ' ' THEN '(' + UserName + ')' ELSE FirstName + ' ' + LastName END FROM UserAccount";
                        string ExistingItemsQuery = "SELECT DISTINCT u.ID AS ID, u.FirstName + ' ' + u.LastName As Fullname FROM RolePermission AS rp RIGHT OUTER JOIN Role AS r ON rp.RoleID = r.ID LEFT OUTER JOIN Permission AS p ON p.ID = rp.PermissionID RIGHT OUTER JOIN UserAccount AS u LEFT OUTER JOIN UserAccountRole AS ur ON u.ID = ur.UserAccountID ON r.ID = ur.RoleID WHERE p.ID = " + _ItemID;

                        //frmLinkedItems006 LinkedUserAccounts = new frmLinkedItems006();

                        //LinkedUserAccounts.ProductSelectQuery = SelectQuery;
                        //LinkedUserAccounts.ItemName = "User Account";

                        //LinkedUserAccounts.Show();

                        frmManageLinkedItems00A LinkedUserAccounts = new frmManageLinkedItems00A();

                        LinkedUserAccounts.SourceListQuery = AllItemsQuery;
                        LinkedUserAccounts.ExistingItemsQuery = ExistingItemsQuery;
                        LinkedUserAccounts.SourceTable = "UserAccount";
                        LinkedUserAccounts.ItemType = "User Account";
                        LinkedUserAccounts.LinkedItemID = _ItemID;
                        LinkedUserAccounts.SelectText = "User Accounts for " + lstItems.SelectedItem.ToString() + " (Permission)";

                        LinkedUserAccounts.Show();
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        // Show linked Events

                        string AllItemsQuery = "SELECT ID, Name FROM Event";
                        string ExistingItemsQuery = "SELECT DISTINCT e.ID, e.Name FROM Event e LEFT JOIN Certificate c ON e.CertificateID = c.ID WHERE c.ID = " + _ItemID;

                        //frmLinkedItems006 LinkedUserAccounts = new frmLinkedItems006();

                        //LinkedUserAccounts.ProductSelectQuery = SelectQuery;
                        //LinkedUserAccounts.ItemName = "User Account";

                        //LinkedUserAccounts.Show();

                        frmManageLinkedItems00A LinkedEvents = new frmManageLinkedItems00A();

                        LinkedEvents.SourceListQuery = AllItemsQuery;
                        LinkedEvents.ExistingItemsQuery = ExistingItemsQuery;
                        LinkedEvents.SourceTable = "Event";
                        LinkedEvents.ItemType = "Event";
                        LinkedEvents.LinkedItemID = _ItemID;
                        LinkedEvents.SelectText = "Events for " + lstItems.SelectedItem.ToString() + " (Certificate)";

                        LinkedEvents.Show();
                        break;
                    }
            }
        }

        private void btnViewDocument_Click(object sender, EventArgs e)
        {
            // The openDocument method originally came from another form that tracked
            // the current document.  We don't do that in this form, so as a workaround
            // the Document has been saved in the Tag Property of the button itself.
            // This happens when the columns are populated
            OpenDocument((Document)btnViewDocument.Tag);
        }

        private void chkValue_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveEdit.Enabled = false;
            btnCancelEdit.Enabled = false;

            switch (ListDisplayName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        if (Global.Permissions.Contains("Write Active Ingredient")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        if (Global.Permissions.Contains("Write Brand")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        if (Global.Permissions.Contains("Write Category")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        if (Global.Permissions.Contains("Write Certificate")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        if (Global.Permissions.Contains("Write Condition")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        if (Global.Permissions.Contains("Write Document")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "End Use":
                case "End Uses":
                    {
                        if (Global.Permissions.Contains("Write End Use")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Event":
                case "Events":
                    {
                        if (Global.Permissions.Contains("Write Event")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        if (Global.Permissions.Contains("Write Event Type")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        if (Global.Permissions.Contains("Write Permission")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Presenter":
                case "Presenters":
                    {
                        if (Global.Permissions.Contains("Write User")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        if (Global.Permissions.Contains("Write Role")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        if (Global.Permissions.Contains("Write Schedule")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        if (Global.Permissions.Contains("Write Store")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        if (Global.Permissions.Contains("Write Unit Of Measure")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "User Account":
                case "User Accounts":
                    {
                        if (Global.Permissions.Contains("Write User")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Product":
                case "Products":
                    {
                        if (Global.Permissions.Contains("Write Product")) btnAcceptEdits.Enabled = true;
                        break;
                    }
            }
        }

        private void frmListEdit_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            switch (ListDisplayName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        gpTitle.Image = Properties.Resources.vista_medical_laboratory_256;
                        this.Icon = Properties.Resources.vista_medical_laboratory;
                        gpTitle.GradientStartColor = Global.Theme[0];
                        btnLinkItems.Image = Properties.Resources.realvista_medical_diagnostic_16;
                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_business_brand_256;
                        this.Icon = Properties.Resources.vista_business_brand;
                        gpTitle.GradientStartColor = Global.Theme[1];
                        break;
                    }
                case "Catalog":
                case "Catalogs":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.clean_business_catalog_256;
                        this.Icon = Properties.Resources.clean_business_catalog;
                        gpTitle.GradientStartColor = Global.Theme[18];
                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_accounting_inventory_categories_256;
                        this.Icon = Properties.Resources.vista_accounting_inventory_categories;
                        gpTitle.GradientStartColor = Global.Theme[2];
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_mobile_certificate_management_256;
                        this.Icon = Properties.Resources.realvista_mobile_certificate_management;
                        gpTitle.GradientStartColor = Global.Theme[3];
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_medical_diagnostic_256;
                        this.Icon = PharmacyAssist.Properties.Resources.realvista_medical_diagnostic;
                        gpTitle.GradientStartColor = Global.Theme[4];
                        btnLinkItems.Image = Properties.Resources.vista_medical_laboratory_16;
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_general_book_256;
                        this.Icon = Properties.Resources.supervista_general_book;
                        gpTitle.GradientStartColor = Global.Theme[5];
                        btnLinkItems.Image = Properties.Resources.realvista_medical_diagnostic_16;
                        break;
                    }
                case "End Use":
                case "End Uses":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_medical_patient_information_256;
                        this.Icon = PharmacyAssist.Properties.Resources.supervista_medical_patient_information;
                        gpTitle.GradientStartColor = Global.Theme[6];
                        break;
                    }
                case "Event":
                case "Events":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_business_meeting_256;
                        this.Icon = Properties.Resources.vista_business_meeting;
                        gpTitle.GradientStartColor = Global.Theme[7];
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_general_stats_256;
                        this.Icon = Properties.Resources.supervista_general_stats;
                        gpTitle.GradientStartColor = Global.Theme[8];
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_security_application_modules_256;
                        this.Icon = Properties.Resources.supervista_security_application_modules;
                        gpTitle.GradientStartColor = Global.Theme[9];
                        btnLinkItems.Image = Properties.Resources.vista_networking_role_16;
                        break;
                    }
                case "Presenter":
                case "Presenters":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.windows7_general_group_256;
                        this.Icon = Properties.Resources.windows7_general_group;
                        gpTitle.GradientStartColor = Global.Theme[10];
                        break;
                    }
                case "Product":
                case "Products":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_business_benchmarking_256;
                        this.Icon = Properties.Resources.supervista_business_benchmarking;
                        gpTitle.GradientStartColor = Global.Theme[16];
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_networking_role_256;
                        this.Icon = Properties.Resources.vista_networking_role;
                        gpTitle.GradientStartColor = Global.Theme[11];
                        btnLinkItems.Image = Properties.Resources.supervista_security_application_modules_16;
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_communications_skin_256;
                        this.Icon = Properties.Resources.vista_communications_skin;
                        gpTitle.GradientStartColor = Global.Theme[12];
                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_realestate_drugstore_256;
                        this.Icon = Properties.Resources.realvista_realestate_drugstore;
                        gpTitle.GradientStartColor = Global.Theme[13];
                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.plasticxp_medical_allergy_vials_256;
                        this.Icon = Properties.Resources.plasticxp_medical_allergy_vials;
                        gpTitle.GradientStartColor = Global.Theme[14];
                        break;
                    }
                case "User Account":
                case "User Accounts":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.windows7_general_group_256;
                        this.Icon = Properties.Resources.windows7_general_group;
                        gpTitle.GradientStartColor = Global.Theme[15];
                        break;
                    }
            }

            this.Show();
            this.Refresh();

            LoadLists();
        }

        private void frmListEdit007_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private List<DatabaseColumn> GetFields()
        {
            List<DatabaseColumn> Fields = new List<DatabaseColumn>();

            switch (ListDisplayName)
            {
                #region Active Ingredient

                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Description";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "CustomString1";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "CustomString2";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "CustomString3";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 6;
                        Column.Name = "CustomString4";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }
                #endregion

                #region Brand

                case "Brand":
                case "Brands":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "CustomString1";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "CustomString2";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "CustomString3";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "CustomString4";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }
                #endregion

                #region Category

                case "Category":
                case "Categories":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "ParentID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "Headline";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "Image";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "Saving";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 6;
                        Column.Name = "SortOrder";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 7;
                        Column.Name = "CustomString1";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 8;
                        Column.Name = "CustomString2";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 9;
                        Column.Name = "CustomString3";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 10;
                        Column.Name = "CustomString4";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Certificate

                case "Certificate":
                case "Certificates":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Description";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Condition

                case "Condition":
                case "Conditions":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Description";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "CustomString1";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "CustomString2";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "CustomString3";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 6;
                        Column.Name = "CustomString4";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Document

                case "Document":
                case "Documents":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Filename";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "Path";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "PublicAccess";
                        Column.Value = false;
                        Column.DataType = typeof(System.Boolean);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region End Use

                case "End Use":
                case "End Uses":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "CustomString1";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "CustomString2";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "CustomString3";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "CustomString4";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Event Type

                case "Event Type":
                case "Event Types":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Description";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "CustomString1";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "CustomString2";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "CustomString3";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 6;
                        Column.Name = "CustomString4";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Permission

                case "Permission":  // READ ONLY
                case "Permissions":  // READ ONLY
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Description";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Product

                case "Product":
                case "Products":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "UPI";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "Description";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "Image";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "Recommended";
                        Column.Value = false;
                        Column.DataType = typeof(System.Boolean);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 6;
                        Column.Name = "ScheduleID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 7;
                        Column.Name = "Approved";
                        Column.Value = false;
                        Column.DataType = typeof(System.Boolean);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 8;
                        Column.Name = "PrivateLabelUPI";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 9;
                        Column.Name = "Price";
                        Column.Value = 0.0;
                        Column.DataType = typeof(System.Double);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 10;
                        Column.Name = "RecommendedPrice";
                        Column.Value = 0.0;
                        Column.DataType = typeof(System.Double);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 11;
                        Column.Name = "InStoreOnly";
                        Column.Value = true;
                        Column.DataType = typeof(System.Boolean);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 12;
                        Column.Name = "Limit";
                        Column.Value = 3;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 13;
                        Column.Name = "ShelfTalker";
                        Column.Value = false;
                        Column.DataType = typeof(System.Boolean);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 14;
                        Column.Name = "BrandID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 15;
                        Column.Name = "Thumbnail";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 16;
                        Column.Name = "MeasureID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 17;
                        Column.Name = "MeasureValue";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 18;
                        Column.Name = "IngredientID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 19;
                        Column.Name = "Rank";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 20;
                        Column.Name = "CoreProduct";
                        Column.Value = false;
                        Column.DataType = typeof(System.Boolean);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 21;
                        Column.Name = "Comment";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 22;
                        Column.Name = "CustomString1";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 23;
                        Column.Name = "CustomString2";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 24;
                        Column.Name = "CustomString3";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 25;
                        Column.Name = "CustomString4";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        //Column = new DatabaseColumn();

                        //Column.Index = 3;
                        //Column.Name = "RPMID";
                        //Column.Value = "";
                        //Column.DataType = typeof(System.Int32);
                        //Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Role

                case "Role":
                case "Roles":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Description";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Schedule

                case "Schedule":
                case "Schedules":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Number";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Store

                case "Store":
                case "Stores":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "RPMName";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "Address";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "Town";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "State";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 6;
                        Column.Name = "Postcode";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 7;
                        Column.Name = "Phone";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 8;
                        Column.Name = "Fax";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 9;
                        Column.Name = "Email";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 10;
                        Column.Name = "Contact";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 11;
                        Column.Name = "MapURL";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 12;
                        Column.Name = "OpenMonday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 13;
                        Column.Name = "CloseMonday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 14;
                        Column.Name = "OpenTuesday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 15;
                        Column.Name = "CloseTuesday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 16;
                        Column.Name = "OpenWednesday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 17;
                        Column.Name = "CloseWednesday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 18;
                        Column.Name = "OpenThursday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 19;
                        Column.Name = "CloseThursday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 20;
                        Column.Name = "OpenFriday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 21;
                        Column.Name = "CloseFriday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 22;
                        Column.Name = "OpenSaturday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 23;
                        Column.Name = "CloseSaturday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 24;
                        Column.Name = "OpenSunday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 25;
                        Column.Name = "CloseSunday";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 26;
                        Column.Name = "OpenPublicHolidays";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 27;
                        Column.Name = "ClosePublicHolidays";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 28;
                        Column.Name = "ShowOnWebsite";
                        Column.Value = false;
                        Column.DataType = typeof(System.Boolean);
                        Fields.Add(Column);

                        break;
                    }

                #endregion

                #region Unit Of Measure

                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        DatabaseColumn Column = new DatabaseColumn();

                        Column.Index = 0;
                        Column.Name = "ID";
                        Column.Value = 0;
                        Column.DataType = typeof(System.Int32);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 1;
                        Column.Name = "Name";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 2;
                        Column.Name = "CustomString1";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 3;
                        Column.Name = "CustomString2";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 4;
                        Column.Name = "CustomString3";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        Column = new DatabaseColumn();

                        Column.Index = 5;
                        Column.Name = "CustomString4";
                        Column.Value = "";
                        Column.DataType = typeof(System.String);
                        Fields.Add(Column);

                        break;
                    }

                #endregion
            }

            return Fields;
        }

        private void GetListItemData(string Query, ListBox ItemlistBox)
        {
            DataSet Data = null;

            ItemlistBox.Items.Clear();

            ItemlistBox.BeginUpdate();

            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem Item = new ListItem((int)Row[0], (string)Row[1]);
                if (ItemlistBox.Items.Contains(Item))
                    lblDuplicates.Visible = true;
                ItemlistBox.Items.Add(Item);
            }

            ItemlistBox.EndUpdate();
        }

        private string GetTableName()
        {
            string Value = "";

            switch (ListDisplayName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        Value = "Ingredient";
                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        Value = "Brand";
                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        Value = "Category";
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        Value = "Certificate";
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        Value = "Condition";
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        Value = "Document";
                        break;
                    }
                case "End Use":
                case "End Uses":
                    {
                        Value = "EndUse";
                        break;
                    }
                case "Event":
                case "Events":
                    {
                        Value = "Event";
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        Value = "EventType";
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        Value = "Permission";
                        break;
                    }
                case "Product":
                case "Products":
                    {
                        Value = "Product";
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        Value = "Role";
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        Value = "Schedule";
                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        Value = "Store";
                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        Value = "UnitOfMeasure";
                        break;
                    }
            }

            return Value;
        }

        private void LoadLists()
        {
            ResetForm();

            Cursor.Current = Cursors.WaitCursor;

            switch (ListDisplayName)
            {
                #region Active Ingredient

                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        Global.GetAllIngredients(lstItems);
                        break;
                    }

                #endregion

                #region Brand

                case "Brand":
                case "Brands":
                    {
                        Global.GetAllBrands(lstItems);
                        break;
                    }

                #endregion

                #region Catalog

                case "Catalog":
                case "Catalogs":
                    {
                        Global.GetAllCatalogs(lstItems);
                        break;
                    }

                #endregion

                #region Category

                case "Category":
                case "Categories":
                    {
                        Global.GetAllCategories(lstItems);
                        break;
                    }

                #endregion

                #region Certificate

                case "Certificate":
                case "Certificates":
                    {
                        Global.GetAllCertificates(lstItems);
                        break;
                    }

                #endregion

                #region Condition

                case "Condition":
                case "Conditions":
                    {
                        Global.GetAllConditions(lstItems);
                        break;
                    }

                #endregion

                #region Document

                case "Document":
                case "Documents":
                    {
                        Global.GetAllDocuments(lstItems);
                        break;
                    }

                #endregion

                #region End Use

                case "End Use":
                case "End Uses":
                    {
                        Global.GetAllEndUses(lstItems);
                        break;
                    }

                #endregion

                #region Event Type

                case "Event Type":
                case "Event Types":
                    {
                        Global.GetAllEventTypes(lstItems);
                        break;
                    }

                #endregion

                #region Permission

                case "Permission":
                case "Permissions":
                    {
                        Global.GetAllPermissions(lstItems);
                        break;
                    }

                #endregion

                #region Product

                case "Product":
                case "Products":
                    {
                        Global.GetAllProducts(lstItems);
                        break;
                    }

                #endregion

                #region Presenter

                case "Presenter":
                case "Presenters":
                    {
                        Global.GetAllUserAccounts(lstItems);
                        break;
                    }

                #endregion

                #region Role

                case "Role":
                case "Roles":
                    {
                        Global.GetAllRoles(lstItems);
                        break;
                    }

                #endregion

                #region Schedule

                case "Schedule":
                case "Schedules":
                    {
                        Global.GetAllSchedules(lstItems);
                        break;
                    }

                #endregion

                #region Store

                case "Store":
                case "Stores":
                    {
                        Global.GetAllStores(lstItems);
                        break;
                    }

                #endregion

                #region Unit Of Measure

                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        Global.GetAllUnitsOfMeasure(lstItems);
                        break;
                    }

                #endregion

                #region User Account

                case "User Account":
                case "User Accounts":
                    {
                        Global.GetAllUserAccounts(lstItems);
                        break;
                    }

                #endregion
            }

            Cursor.Current = Cursors.Default;
        }

        private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstColumns.SelectedItem != null)
            {
                _CurrentColumn = (DatabaseColumn)lstColumns.SelectedItem;

                txtPropertyName.Text = _CurrentColumn.Name;

                switch (_CurrentColumn.DataType.ToString())
                {
                    case ("System.String"):
                    case ("System.Int32"):
                    case ("System.DateTime"):
                    case ("System.Decimal"):
                        txtValue.Visible = true;
                        chkValue.Visible = false;

                        txtValue.Enabled = true;
                        chkValue.Enabled = false;

                        txtValue.Text = _CurrentColumn.Value.ToString();
                        break;
                    case ("System.Boolean"):
                        txtValue.Visible = false;
                        chkValue.Visible = true;

                        txtValue.Enabled = false;
                        chkValue.Enabled = true;

                        chkValue.Checked = (_CurrentColumn.Value.ToString().ToLower() == "true");
                        break;
                }

                if (_CurrentColumn.Name.ToLower() == "filename" || _CurrentColumn.Name.ToLower() == "path")
                {
                    if (Global.Permissions.Contains("Write Document")) btnUpload.Enabled = true;
                }
                else
                {
                    btnUpload.Enabled = false;
                }

            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnProductLinking.Enabled = false;
            btnLinkItems.Enabled = false;
            btnDocuments.Enabled = false;

            if (!_FilterInProgress)
            {
                string Query = "";

                btnSaveEdit.Enabled = false;
                btnCancelEdit.Enabled = false;
                btnAcceptEdits.Enabled = false;

                if (Properties.Settings.Default.ShowLinkedItemCount == true)
                {
                    switch (ListDisplayName)
                    {
                        case "Ingredient":
                        case "Ingredients":
                        case "Active Ingredient":
                        case "Active Ingredients":
                            {
                                lblLinkInfo.Text = "No Products linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Brand":
                        case "Brands":
                            {
                                lblLinkInfo.Text = "No Products linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Catalog":
                        case "Catalogs":
                            {
                                lblLinkInfo.Text = "No Products linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Category":
                        case "Categories":
                            {
                                lblLinkInfo.Text = "No Products linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Certificate":
                        case "Certificates":
                            {
                                lblLinkInfo.Text = "No Events linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Condition":
                        case "Conditions":
                            {
                                lblLinkInfo.Text = "No Ingredients or Products linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "No Documents linked";
                                break;
                            }
                        case "Document":
                        case "Documents":
                            {
                                lblLinkInfo.Text = "No Conditions linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "End Use":
                        case "End Uses":
                            {
                                lblLinkInfo.Text = "No Products linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Event":
                        case "Events":
                            {
                                lblLinkInfo.Text = "No Event Types linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "No Documents linked";
                                break;
                            }
                        case "Event Type":
                        case "Event Types":
                            {
                                lblLinkInfo.Text = "No Events linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Permission":
                        case "Permissions":
                            {
                                lblLinkInfo.Text = "No Roles linked";
                                lblUserAccountInfo.Text = "No User Accounts linked";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Presenter":
                        case "Presenters":
                            {
                                lblLinkInfo.Text = "No links";
                                lblUserAccountInfo.Text = "No User Accounts linked"; // Manager ?
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Product":
                        case "Products":
                            {
                                lblLinkInfo.Text = "No linking shown";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Role":
                        case "Roles":
                            {
                                lblLinkInfo.Text = "No Permissions linked";
                                lblUserAccountInfo.Text = "No User Accounts linked";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Schedule":
                        case "Schedules":
                            {
                                lblLinkInfo.Text = "No Products linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Store":
                        case "Stores":
                            {
                                lblLinkInfo.Text = "No links";
                                lblUserAccountInfo.Text = "No User Accounts linked";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "Unit Of Measure":
                        case "Units Of Measure":
                            {
                                lblLinkInfo.Text = "No Products linked";
                                lblUserAccountInfo.Text = "";
                                lblDocumentInfo.Text = "";
                                break;
                            }
                        case "User Account":
                        case "User Accounts":
                            {
                                lblLinkInfo.Text = "No links";
                                lblUserAccountInfo.Text = "No User Accounts linked"; // Manager ?
                                lblDocumentInfo.Text = "";
                                break;
                            }
                    }
                }
                else
                {
                    // Link counts disabled
                    lblLinkInfo.Text = "";
                    lblUserAccountInfo.Text = "";
                    lblDocumentInfo.Text = "";
                }

                txtValue.Text = "";
                txtValue.Visible = true;
                chkValue.Visible = false;

                // Get the ID of the selected item
                if (lstItems.SelectedItem != null)
                {
                    ListItem Item = (ListItem)lstItems.SelectedItem;

                    _ItemID = Item.ID;
                    _ItemName = Item.Name;

                    switch (ListDisplayName)
                    {
                        case "Ingredient":
                        case "Ingredients":
                        case "Active Ingredient":
                        case "Active Ingredients":
                            {
                                if (Global.Permissions.Contains("Delete Active Ingredient")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Brand":
                        case "Brands":
                            {
                                if (Global.Permissions.Contains("Delete Brand")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Catalog":
                        case "Catalogs":
                            {
                                // Catalogs should not be deleted
                                // if (Global.Permissions.Contains("Delete Catalog")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Category":
                        case "Categories":
                            {
                                if (Global.Permissions.Contains("Delete Category")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Certificate":
                        case "Certificates":
                            {
                                if (Global.Permissions.Contains("Delete Certificate")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Condition":
                        case "Conditions":
                            {
                                if (Global.Permissions.Contains("Delete Condition")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Document":
                        case "Documents":
                            {
                                if (Global.Permissions.Contains("Delete Document")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "End Use":
                        case "End Uses":
                            {
                                if (Global.Permissions.Contains("Delete End Use")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Event":
                        case "Events":
                            {
                                if (Global.Permissions.Contains("Delete Event")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Event Type":
                        case "Event Types":
                            {
                                if (Global.Permissions.Contains("Delete Event Type")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Permission":
                        case "Permissions":
                            {
                                // Permissions cannot be removed
                                //if (Global.Permissions.Contains("Delete Permission")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Presenter":
                        case "Presenters":
                            {
                                if (Global.Permissions.Contains("Delete User")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Product":
                        case "Products":
                            {
                                if (Global.Permissions.Contains("Delete Product")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Role":
                        case "Roles":
                            {
                                if (Global.Permissions.Contains("Delete Role")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Schedule":
                        case "Schedules":
                            {
                                if (Global.Permissions.Contains("Delete Schedule")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Store":
                        case "Stores":
                            {
                                if (Global.Permissions.Contains("Delete Store")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "Unit Of Measure":
                        case "Units Of Measure":
                            {
                                if (Global.Permissions.Contains("Delete Unit Of Measure")) btnRemoveItem.Enabled = true;
                                break;
                            }
                        case "User Account":
                        case "User Accounts":
                            {
                                if (Global.Permissions.Contains("Delete User")) btnRemoveItem.Enabled = true;
                                break;
                            }
                    }

                    #region Enable and disable buttons for this list item type

                    #region Link Items button

                    if (ListDisplayName == "Active Ingredient" || ListDisplayName == "Active Ingredients")
                    {
                        btnLinkItems.Enabled = Global.Permissions.Contains("Read Condition");
                        ToolTips.SetToolTip(btnLinkItems, "Show Conditions");
                    }
                    else if (ListDisplayName == "Condition" || ListDisplayName == "Conditions")
                    {
                        btnLinkItems.Enabled = Global.Permissions.Contains("Read Active Ingredient");
                        ToolTips.SetToolTip(btnLinkItems, "Show Active Ingredients");
                    }
                    else if (ListDisplayName == "Document" || ListDisplayName == "Documents")
                    {
                        btnLinkItems.Enabled = true;
                        // Events or Conditions - What is the context here ????
                        ToolTips.SetToolTip(btnLinkItems, "Show Conditions");
                        // ToolTips.SetToolTip(btnLinkItems, "Show Events");
                    }
                    else if (ListDisplayName == "Permission" || ListDisplayName == "Permissions")
                    {
                        btnLinkItems.Enabled = Global.Permissions.Contains("Read Role");
                        ToolTips.SetToolTip(btnLinkItems, "Show Roles");
                    }
                    else if (ListDisplayName == "Role" || ListDisplayName == "Roles")
                    {
                        btnLinkItems.Enabled = Global.Permissions.Contains("Read Permission");
                        ToolTips.SetToolTip(btnLinkItems, "Show Permissions");
                    }
                    else
                    {
                        btnLinkItems.Enabled = false;
                    }

                    #endregion

                    #region Documents button

                    if (ListDisplayName == "Condition" || ListDisplayName == "Conditions")
                    {
                        btnDocuments.Enabled = Global.Permissions.Contains("Read Document");
                    }
                    else
                    {
                        btnDocuments.Enabled = false;
                    }

                    if (ListDisplayName == "Document" || ListDisplayName == "Documents")
                    {
                        btnViewDocument.Enabled = Global.Permissions.Contains("Read Document");
                    }
                    else
                    {
                        btnViewDocument.Enabled = false;
                    }

                    #endregion

                    #region User Accounts button

                    if (ListDisplayName == "Permission" || ListDisplayName == "Permissions")
                    {
                        if (Global.Permissions.Contains("Read Permission")) btnUserAccounts.Enabled = true;
                    }
                    else if (ListDisplayName == "Role" || ListDisplayName == "Roles")
                    {
                        btnUserAccounts.Enabled = Global.Permissions.Contains("Read Role");
                    }
                    else
                    {
                        btnUserAccounts.Enabled = false;
                    }

                    #endregion

                    #endregion
                }
                else
                {
                    btnRemoveItem.Enabled = false;
                    btnLinkItems.Enabled = false;
                }

                lstColumns.Items.Clear();

                if (_ItemID != 0)
                {
                    // Compose queries to display items, get record count, get linked item count

                    switch (ListDisplayName)
                    {
                        #region Active Ingredient

                        case "Ingredient":
                        case "Ingredients":
                        case "Active Ingredient":
                        case "Active Ingredients":
                            {
                                Query = "SELECT ID, Name, Description, CustomString1, CustomString2, CustomString3, CustomString4 FROM Ingredient WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    //int ProductCount = Global.GetRecordCount("Product INNER JOIN ProductIngredient ON Product.ID = ProductIngredient.ProductID INNER JOIN Ingredient ON ProductIngredient.IngredientID = Ingredient.ID WHERE ProductIngredient.IngredientID = " + _ItemID);
                                    int ProductCount = Global.GetRecordCount("Product INNER JOIN Ingredient ON Product.IngredientID = Ingredient.ID WHERE Product.IngredientID = " + _ItemID);
                                    int ConditionCount = Global.GetRecordCount("Condition INNER JOIN ConditionIngredient ON Condition.ID = ConditionIngredient.ConditionID WHERE ConditionIngredient.IngredientID = " + _ItemID);

                                    if (ProductCount > 0 && ConditionCount == 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                    if (ProductCount == 0 && ConditionCount > 0) lblLinkInfo.Text = ConditionCount + " Condition(s) linked";
                                    if (ProductCount > 0 && ConditionCount > 0) lblLinkInfo.Text = ConditionCount + " Condition(s) and " + ProductCount + " Product(s) linked";
                                    //if (ProductCount > 0) btnProductLinking.Enabled = true;
                                }
                                break;
                            }

                        #endregion

                        #region Brand

                        case "Brand":
                        case "Brands":
                            {
                                Query = "SELECT ID, Name, CustomString1, CustomString2, CustomString3, CustomString4 FROM Brand WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ProductCount = Global.GetRecordCount("Product WHERE Product.BrandID = " + _ItemID);

                                    if (ProductCount > 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                    //if (ProductCount > 0) btnProductLinking.Enabled = true;
                                }

                                break;
                            }

                        #endregion

                        #region Catalog

                        case "Catalog":
                        case "Catalogs":
                            {
                                int RPMID = 0;
                                //Query = "SELECT ID, Name, RPMID FROM Catalog WHERE ID = " + _ItemID.ToString();
                                Query = "SELECT DISTINCT p.ID, p.Name,c.RPMID, pc.StartDate, pc.EndDate FROM Catalog c LEFT JOIN ProductCatalog pc ON c.RPMID = pc.CatalogID LEFT JOIN Product p ON pc.ProductID = p.ID WHERE c.ID = " + _ItemID.ToString();

                                RPMID = Convert.ToInt32(Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 2));

                                ////////////////////////////////////
                                //    DEPARTURE FROM THE NORM
                                //    USE RPMID INSTEAD OF ID     //
                                ////////////////////////////////////

                                _ItemID = RPMID;

                                ////////////////////////////////////

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ProductCount = Global.GetRecordCount("from (SELECT DISTINCT p.ID, p.Name FROM Catalog c INNER JOIN ProductCatalog pc ON c.RPMID = pc.CatalogID LEFT JOIN Product p ON pc.ProductID = p.ID WHERE c.RPMID = " + RPMID + ") p");

                                    if (ProductCount > 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                    //if (ProductCount > 0) btnProductLinking.Enabled = true;
                                }
                                break;
                            }

                        #endregion

                        #region Category

                        case "Category":
                        case "Categories":
                            {
                                Query = "SELECT ID, Name, ParentID, Headline, Image, Saving, SortOrder, CustomString1, CustomString2, CustomString3, CustomString4 FROM Category WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ProductCount = Global.GetRecordCount("from (SELECT DISTINCT p.ID FROM product p inner join productcategory pc on p.id = pc.ProductID inner join category c on c.id = pc.CategoryID where c.id = " + _ItemID + ") c");

                                    if (ProductCount > 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                    //if (ProductCount > 0) btnProductLinking.Enabled = true;
                                }
                                break;
                            }

                        #endregion

                        #region Certificate

                        case "Certificate":
                        case "Certificates":
                            {
                                Query = "SELECT ID, Name, Description FROM Certificate WHERE ID = " + _ItemID.ToString();

                                btnLinkItems.Enabled = Global.Permissions.Contains("Read Event");
                                ToolTips.SetToolTip(btnLinkItems, "Show Events");
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int EventCount = Global.GetRecordCount("Event e LEFT JOIN Certificate c ON e.CertificateID = c.ID WHERE c.ID = " + _ItemID);

                                    if (EventCount > 0) lblLinkInfo.Text = EventCount + " Event(s) linked";
                                }
                                break;
                            }

                        #endregion

                        #region Condition

                        case "Conditions":
                            {
                                Query = "SELECT ID, Name, Description, CustomString1, CustomString2, CustomString3, CustomString4 FROM Condition WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ProductCount = Global.GetRecordCount("Product INNER JOIN ProductCondition ON Product.ID = ProductCondition.ProductID INNER JOIN Condition ON ProductCondition.ConditionID = Condition.ID WHERE Condition.ID = " + _ItemID);
                                    int IngredientCount = Global.GetRecordCount("Ingredient INNER JOIN ConditionIngredient ON Ingredient.ID = ConditionIngredient.IngredientID INNER JOIN Condition ON ConditionIngredient.ConditionID = Condition.ID WHERE Condition.ID = " + _ItemID);
                                    int DocumentCount = Global.GetRecordCount("Document d INNER JOIN ConditionDocument cd ON d.ID = cd.DocumentID INNER JOIN Condition c ON c.ID = cd.ConditionID WHERE c.id = " + _ItemID);

                                    if (ProductCount > 0 && IngredientCount == 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                    if (ProductCount == 0 && IngredientCount > 0) lblLinkInfo.Text = IngredientCount + " Ingredient(s) linked";
                                    if (ProductCount > 0 && IngredientCount > 0) lblLinkInfo.Text = IngredientCount + " Ingredient(s) and " + ProductCount + " Product(s) linked";
                                    //if (ProductCount > 0) btnProductLinking.Enabled = true;

                                    if (DocumentCount > 0)
                                    {
                                        lblDocumentInfo.Text = DocumentCount + " Document(s) linked";
                                    }
                                    else
                                    {
                                        lblDocumentInfo.Text = "0 Documents linked";
                                    }
                                }

                                break;
                            }

                        #endregion

                        #region Document

                        case "Document":
                        case "Documents":
                            {
                                Query = "SELECT ID, Name, Filename, Path, PublicAccess FROM Document WHERE ID = " + _ItemID.ToString();

                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ConditionCount = Global.GetRecordCount("from dbo.Condition c INNER JOIN dbo.ConditionDocument cd ON cd.ConditionId = c.ID INNER JOIN dbo.Document d ON cd.DocumentID = d.ID WHERE d.ID = " + _ItemID);

                                    if (ConditionCount > 0) lblLinkInfo.Text = ConditionCount + " Condition(s) linked";
                                }
                                break;
                            }

                        #endregion

                        #region Event Type

                        case "Event Type":
                        case "Event Types":
                            {
                                Query = "SELECT ID, Name, Description, CustomString1, CustomString2, CustomString3 FROM EventType WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = false;
                                btnLinkItems.Enabled = (Global.Permissions.Contains("Read Event Type"));
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int EventCount = Global.GetRecordCount("FROM Event where TypeID = " + _ItemID);

                                    if (EventCount > 0) lblLinkInfo.Text = EventCount + " Event(s) linked";
                                }
                                break;
                            }

                        #endregion

                        #region End Use

                        case "End Uses":
                            {
                                Query = "SELECT ID, Name, CustomString1, CustomString2, CustomString3, CustomString4 FROM EndUse WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ProductCount = Global.GetRecordCount("FROM product p inner join ProductEnduse pe on pe.ProductID = p.ID INNER JOIN enduse e on e.ID = pe.EndUseID where e.ID = " + _ItemID);

                                    if (ProductCount > 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                }
                                break;
                            }

                        #endregion

                        #region Permission

                        case "Permission":
                        case "Permissions":
                            {
                                Query = "SELECT ID, Name, Description FROM Permission WHERE ID = " + _ItemID.ToString();

                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int RoleCount = Global.GetRecordCount("from dbo.Role r INNER JOIN dbo.RolePermission rp ON rp.RoleID = r.ID INNER JOIN dbo.Permission p ON rp.PermissionID = p.ID WHERE p.ID = " + _ItemID);

                                    if (RoleCount > 0) lblLinkInfo.Text = RoleCount + " Role(s) linked";

                                    int UserAccountCount = Global.GetRecordCount("FROM (SELECT DISTINCT u.ID FROM UserAccount u INNER JOIN UserAccountRole ur ON u.ID = ur.UserAccountID INNER JOIN Role r ON ur.RoleID = r.ID INNER JOIN RolePermission rp ON r.ID = rp.RoleID INNER JOIN Permission p ON p.ID = rp.PermissionID WHERE p.ID = " + _ItemID + ") c");

                                    if (UserAccountCount > 0) lblUserAccountInfo.Text = UserAccountCount + " User Account(s) linked";
                                }
                                break;
                            }

                        #endregion

                        #region Product

                        case "Product":
                        case "Products":
                            {
                                Query = "SELECT ID, UPI, Name, Description, Recommended, ScheduleID, Approved, PrivateLabelUPI, Price, RecommendedPrice, InStoreOnly, Limit, ShelfTalker, BrandID, Thumbnail, MeasureID, MeasureValue, IngredientID, Rank, CoreProduct, Comment, CustomString1, CustomString2, CustomString3, CustomString4 FROM Product WHERE ID = " + _ItemID.ToString();

                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    //int ConditionCount = Global.GetRecordCount("from dbo.Role r INNER JOIN dbo.RolePermission rp ON rp.RoleID = r.ID INNER JOIN dbo.Permission p ON rp.PermissionID = p.ID WHERE p.ID = " + _ItemID);

                                    //if (ConditionCount > 0) lblLinkInfo.Text = ConditionCount + " Role(s) linked";

                                    //int UserAccountCount = Global.GetRecordCount("FROM (SELECT DISTINCT u.ID FROM UserAccount u INNER JOIN UserAccountRole ur ON u.ID = ur.UserAccountID INNER JOIN Role r ON ur.RoleID = r.ID INNER JOIN RolePermission rp ON r.ID = rp.RoleID INNER JOIN Permission p ON p.ID = rp.PermissionID WHERE p.ID = " + _ItemID + ") c");

                                    //if (UserAccountCount > 0) lblUserAccountInfo.Text = UserAccountCount + " User Account(s) linked";
                                }
                                break;
                            }

                        #endregion

                        #region Role

                        case "Role":
                        case "Roles":
                            {
                                Query = "SELECT ID, Name, Description FROM Role WHERE ID = " + _ItemID.ToString();

                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ConditionCount = Global.GetRecordCount("from dbo.Permission p INNER JOIN dbo.RolePermission rp ON rp.PermissionID = p.ID INNER JOIN dbo.Role r ON rp.RoleID = r.ID WHERE r.ID = " + _ItemID);

                                    if (ConditionCount > 0) lblLinkInfo.Text = ConditionCount + " Permission(s) linked";

                                    int UserAccountCount = Global.GetRecordCount("FROM (SELECT DISTINCT u.ID AS ID FROM RolePermission AS rp RIGHT OUTER JOIN Role AS r ON rp.RoleID = r.ID LEFT OUTER JOIN Permission AS p ON p.ID = rp.PermissionID RIGHT OUTER JOIN UserAccount AS u LEFT OUTER JOIN UserAccountRole AS ur ON u.ID = ur.UserAccountID ON r.ID = ur.RoleID WHERE (r.ID = " + _ItemID + ")) c");

                                    if (UserAccountCount > 0) lblUserAccountInfo.Text = UserAccountCount + " User Account(s) linked";
                                }
                                break;
                            }

                        #endregion

                        #region Schedule

                        case "Schedule":
                        case "Schedules":
                            {
                                Query = "SELECT ID, Number, Name FROM Schedule WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ProductCount = Global.GetRecordCount("Product WHERE Product.ScheduleID = " + _ItemID);

                                    if (ProductCount > 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                    //if (ProductCount > 0) btnProductLinking.Enabled = true;
                                }
                                break;
                            }

                        #endregion

                        #region Store

                        case "Stores":
                            {
                                Query = "SELECT ID, Name, RPMName, Address, Town, State, Postcode, Phone, Fax, Email, Contact, MapURL, OpenMonday, CloseMonday, OpenTuesday, CloseTuesday, OpenWednesday, CloseWednesday, OpenThursday, CloseThursday, OpenFriday, CloseFriday, OpenSaturday, CloseSaturday, OpenSunday, CloseSunday, OpenPublicHolidays, ClosePublicHolidays, ShowOnWebsite FROM Store WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    //int ProductCount = Global.GetRecordCount("Product WHERE Product.BrandID = " + _ItemID);

                                    //if (ProductCount > 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                    //if (ProductCount > 0) btnProductLinking.Enabled = true;
                                }
                                break;
                            }

                        #endregion

                        #region Unit Of Measure

                        case "Unit Of Measure":
                        case "Units Of Measure":
                            {
                                Query = "SELECT ID, Name, CustomString1, CustomString2, CustomString3, CustomString4 FROM UnitOfMeasure WHERE ID = " + _ItemID.ToString();

                                btnProductLinking.Enabled = (Global.Permissions.Contains("Read Product")); //true;;
                                if (Properties.Settings.Default.ShowLinkedItemCount)
                                {
                                    int ProductCount = Global.GetRecordCount("Product WHERE Product.MeasureID = " + _ItemID);

                                    if (ProductCount > 0) lblLinkInfo.Text = ProductCount + " Product(s) linked";
                                    //if (ProductCount > 0) btnProductLinking.Enabled = true;
                                }
                                break;
                            }

                        #endregion
                    }
                    AddColumnsFromQuery(Query);
                }
            }
        }

        private void OpenDocument(Document Doc)
        {
            // Check if the document is already present
            string LocalFolder = Application.UserAppDataPath;
            string Filename = Doc.FileName;
            string LocalFilename = System.IO.Path.Combine(LocalFolder, Filename);
            bool FilePresent = File.Exists(LocalFilename);

            Cursor.Current = Cursors.WaitCursor;

            if (!FilePresent)
            {
                FTP Ftp = new FTP();
                Ftp.UseCompression = false;

                Ftp.RemoteHost = Properties.Settings.Default.FTPHost;
                Ftp.RemoteUsername = Properties.Settings.Default.FTPUsername;
                Ftp.RemotePassword = Properties.Settings.Default.FTPPassword;

                try
                {
                    Ftp.Login();
                    Ftp.Download(Doc.Path + "/" + Filename, LocalFilename);

                }
                catch (Exception ex)
                {
                    Global.Common.Logging.WriteErrorEvent(String.Format("Linked Documents form (OpenDocument) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                }
            }

            // Downloaded or not, we can now open it
            Global.OpenDocument(LocalFilename);

            Cursor.Current = Cursors.Default;
        }

        private void ResetForm()
        {
            lstColumns.Items.Clear();
            txtPropertyName.Text = "";
            txtValue.Text = "";
            txtValue.Visible = true;
            chkValue.Visible = false;
            lblDuplicates.Visible = false;
            lblLinkInfo.Text = "";

            chkValue.Enabled = false;
            txtValue.Enabled = false;

            btnCancelEdit.Enabled = false;
            btnSaveEdit.Enabled = false;
            btnAcceptEdits.Enabled = false;
            btnRemoveItem.Enabled = false;
            btnDocuments.Enabled = false;
            btnLinkItems.Enabled = false;
            btnUpload.Enabled = false;

            switch (ListDisplayName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        if (Global.Permissions.Contains("Create Active Ingredient")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        if (Global.Permissions.Contains("Create Brand")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        if (Global.Permissions.Contains("Create Category")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        if (Global.Permissions.Contains("Create Certificate")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        if (Global.Permissions.Contains("Create Condition")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        if (Global.Permissions.Contains("Create Document")) btnAddItem.Enabled = true;
                        break;
                    }
                case "End Use":
                case "End Uses":
                    {
                        if (Global.Permissions.Contains("Create End Use")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Event":
                case "Events":
                    {
                        if (Global.Permissions.Contains("Create Event")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        if (Global.Permissions.Contains("Create Event Type")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        // Permissions cannot be created
                        //if (Global.Permissions.Contains("Create Permission")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Presenter":
                case "Presenters":
                    {
                        if (Global.Permissions.Contains("Create User")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        if (Global.Permissions.Contains("Create Role")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        if (Global.Permissions.Contains("Create Schedule")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        if (Global.Permissions.Contains("Create Store")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        if (Global.Permissions.Contains("Create Unit Of Measure")) btnAddItem.Enabled = true;
                        break;
                    }
                case "User Account":
                case "User Accounts":
                    {
                        if (Global.Permissions.Contains("Create User")) btnAddItem.Enabled = true;
                        break;
                    }
                case "Product":
                case "Products":
                    {
                        if (Global.Permissions.Contains("Create Product")) btnAddItem.Enabled = true;
                        break;
                    }
            }
        }

        private void StartUpload(string LocalFolderName, string FileName, string Extension, string RemoteFolderName)
        {
            string RemoteFilename = FileName;
            List<DatabaseColumn> Columns = new List<DatabaseColumn>();

            DatabaseColumn DbColumn = new DatabaseColumn();

            UploadFile(LocalFolderName, FileName + Extension, RemoteFolderName, RemoteFilename + Extension);

            Global.Audit("Document upload", "Document", "", 0, Global.Username, "", "", Application.ProductName, false);

            foreach (DatabaseColumn Column in lstColumns.Items)
            {
                if (Column.Name.ToLower() == "name" && Column.Value.ToString().Trim() == "")
                {
                    Column.Value = RemoteFilename + Extension;
                }

                if (Column.Name.ToLower() == "filename")
                {
                    Column.Value = RemoteFilename + Extension;
                }

                if (Column.Name.ToLower() == "path")
                {
                    Column.Value = RemoteFolderName;
                }

                Columns.Add(Column);
            }

            AddColumnsToListbox(Columns);

            btnAcceptEdits.Enabled = false;
            btnCancelEdit.Enabled = false;
            btnSaveEdit.Enabled = true;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            // _ItemID contains the ID of this row
            btnSaveEdit.Enabled = false;
            btnCancelEdit.Enabled = false;

            switch (ListDisplayName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        if (Global.Permissions.Contains("Write Active Ingredient") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        if (Global.Permissions.Contains("Write Brand") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        if (Global.Permissions.Contains("Write Category") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        if (Global.Permissions.Contains("Write Certificate") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        if (Global.Permissions.Contains("Write Condition") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        if (Global.Permissions.Contains("Write Document") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "End Use":
                case "End Uses":
                    {
                        if (Global.Permissions.Contains("Write End Use") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Event":
                case "Events":
                    {
                        if (Global.Permissions.Contains("Write Event") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        if (Global.Permissions.Contains("Write Event Type") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        // Permissions cannot be changed
                        //if (Global.Permissions.Contains("Write Permission")) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Presenter":
                case "Presenters":
                    {
                        if (Global.Permissions.Contains("Write User") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        if (Global.Permissions.Contains("Write Role") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        if (Global.Permissions.Contains("Write Schedule") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        if (Global.Permissions.Contains("Write Store") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        if (Global.Permissions.Contains("Write Unit Of Measure") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "User Account":
                case "User Accounts":
                    {
                        if (Global.Permissions.Contains("Write User") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
                case "Product":
                case "Products":
                    {
                        if (Global.Permissions.Contains("Write Product") || _ItemID == 0) btnAcceptEdits.Enabled = true;
                        break;
                    }
            }
        }

        private bool UploadFile(string LocalFoldername, string LocalFilename, string DestinationFoldername, string DestinationFilename)
        {
            bool Result = false;

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Properties.Settings.Default.FTPHost + "/" + DestinationFoldername + "/" + DestinationFilename);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(Properties.Settings.Default.FTPUsername, Properties.Settings.Default.FTPPassword);

            // Copy the contents of the file to the request stream.
            // http://msdn.microsoft.com/en-us/library/ms229715(v=vs.90).aspx
            // AND
            // http://stackoverflow.com/questions/221925/creating-a-byte-array-from-a-stream

            StreamReader sourceStream = new StreamReader(LocalFoldername + @"\" + LocalFilename);
            byte[] fileContents = Global.ReadFully(sourceStream.BaseStream);
            sourceStream.Close();

            FtpWebResponse response = null;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                response = (FtpWebResponse)request.GetResponse();

                Result = true;
            }
            catch (Exception ex)
            {
                Global.Common.Logging.WriteErrorEvent(String.Format("Product detail form (UploadFile) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                Result = false;
            }

            response.Close();

            Cursor.Current = Cursors.Default;

            return Result;
        }
    }
}
