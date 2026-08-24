using i00SpellCheck;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmListItemSelection008 : Form
    {
        private int _ItemID = 0;
        private frmProductDetail _ParentForm = null;
        private Helper.ItemType _ParentType = Helper.ItemType.Product;

        public List<int> SelectedIDList = new List<int>();
        public List<ListItem> SelectedListItems = new List<ListItem>();
        public string ListDisplayName { get; set; }
        public bool SingleItemConstraint { get; set; }
        public int ParentObjectID { get; set; }
        public bool ReturnListOnly { get; set; }
        public bool ListIsReadOnly { get; set; }
        public Helper.ItemType ParentType { get; set; }

        public frmListItemSelection008(frmProductDetail ParentProductForm, Helper.ItemType ParentType)
        {
            InitializeComponent();

            _ParentForm = ParentProductForm;
            _ParentType = ParentType;

            if (Properties.Settings.Default.EnableSpellCheck) this.EnableControlExtensions();

            ReturnListOnly = false;

        }

        #region GetProduct[Property]

        private void GetProductBrands()
        {
            Global.GetListItemData("select distinct brand.id, brand.name from brand inner join product on product.brandid = brand.id where product.id = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetProductCategories()
        {
            Global.GetListItemData("select distinct category.id, category.name from category inner join productcategory on category.ID = productcategory.categoryID inner join product on productcategory.ProductID = product.ID where product.id = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetProductConditions()
        {
            Global.GetListItemData("select distinct condition.id, condition.name from condition inner join productcondition on condition.ID = productcondition.conditionID inner join product on productcondition.ProductID = product.ID where product.id = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetProductEndUses()
        {
            Global.GetListItemData("select distinct enduse.id, enduse.name from enduse inner join productenduse on enduse.ID = productenduse.EndUseID inner join product on productenduse.ProductID = product.ID where product.id = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetProductIngredients()
        {
            Global.GetListItemData("select distinct ingredient.id, ingredient.name from ingredient inner join product on product.ingredientid = ingredient.id where product.id = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetProductSchedules()
        {
            Global.GetListItemData("select distinct schedule.id, schedule.name from schedule inner join product on product.scheduleid = schedule.id where product.id = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetProductUnitsOfMeasure()
        {
            Global.GetListItemData("select distinct unitofmeasure.id, unitofmeasure.name from unitofmeasure inner join product on product.measureid = unitofmeasure.id where product.id = " + ParentObjectID.ToString(), lstSelection);
        }

        #endregion

        #region GetEvent[Property]

        private void GetEventUserAccounts()
        {
            Global.GetListItemData("SELECT u.ID, FirstName + ' ' + LastName AS FullName FROM UserAccount u INNER JOIN Event e ON e.OwnerUserAccountID = u.ID WHERE e.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetEventPresenterAccounts()
        {
            Global.GetListItemData("SELECT u.ID, FirstName + ' ' + LastName AS FullName FROM UserAccount u INNER JOIN Event e ON e.PresenterID = u.ID WHERE e.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetEventEventTypes()
        {
            Global.GetListItemData("SELECT et.ID, et.Name FROM Event e INNER JOIN EventType et ON e.TypeID = et.ID WHERE e.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetEventCertificates()
        {
            Global.GetListItemData("SELECT c.ID, c.Name FROM Certificate c INNER JOIN Event e ON e.CertificateID = c.ID WHERE e.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetEventDocuments()
        {
            Global.GetListItemData("SELECT d.ID, d.Name FROM Document d INNER JOIN EventDocument ed ON ed.DocumentID = d.ID INNER JOIN Event e ON e.ID = ed.EventID WHERE e.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetEventStores()
        {
            Global.GetListItemData("SELECT s.ID, s.Name FROM Store s INNER JOIN EventStore es ON es.StoreID = s.ID INNER JOIN Event e ON e.ID = es.EventID WHERE e.ID =" + ParentObjectID.ToString(), lstSelection);
        }

        #endregion

        #region GetPermission[Property]

        private void GetPermissionRoles()
        {
            Global.GetListItemData("SELECT u.ID, FirstName + ' ' + LastName AS FullName FROM UserAccount u INNER JOIN Event e ON e.OwnerUserAccountID = u.ID WHERE e.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        #endregion

        #region GetTask[Property]

        private void GetTaskRoles()
        {
            Global.GetListItemData("SELECT r.ID, r.Name FROM Role r LEFT JOIN TaskRole tr ON tr.RoleID  = r.ID LEFT JOIN Task t ON t.ID = tr.TaskID WHERE t.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetTaskDocuments()
        {
            Global.GetListItemData("SELECT d.ID, d.Name FROM Document d LEFT JOIN TaskDocument td ON td.DocumentID  = d.ID LEFT JOIN Task t ON t.ID = td.TaskID WHERE t.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetTaskStores()
        {
            Global.GetListItemData("SELECT s.ID, s.Name FROM Store s LEFT JOIN TaskStore ts ON ts.StoreID  = s.ID LEFT JOIN Task t ON t.ID = ts.TaskID WHERE t.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetTaskCertificates()
        {
            Global.GetListItemData("SELECT c.ID, c.Name FROM Certificate c LEFT JOIN Task t ON t.CertificateID  = c.ID WHERE t.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        #endregion

        #region GetUserAccount[Property]

        private void GetUserAccountRoles()
        {
            Global.GetListItemData("SELECT r.ID, r.Name FROM dbo.Role r LEFT JOIN dbo.UserAccountRole ur ON ur.RoleID = r.ID LEFT JOIN dbo.UserAccount u ON ur.UserAccountID = u.ID WHERE u.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        private void GetUserAccountPermissions()
        {
            Global.GetListItemData("SELECT u.ID, FirstName + ' ' + LastName AS FullName FROM UserAccount u INNER JOIN Event e ON e.OwnerUserAccountID = u.ID WHERE e.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        #endregion

        #region GetRole[Property]

        private void GetRolePermissions()
        {
            Global.GetListItemData("SELECT u.ID, FirstName + ' ' + LastName AS FullName FROM UserAccount u INNER JOIN Event e ON e.OwnerUserAccountID = u.ID WHERE e.ID = " + ParentObjectID.ToString(), lstSelection);
        }

        #endregion

        //private void GetListItemData(string Query, ListBox ItemlistBox)
        //{
        //    DataSet Data = null;

        //    ItemlistBox.Items.Clear();

        //    Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

        //    foreach (DataRow Row in Data.Tables[0].Rows)
        //    {
        //        ListItem Item = new ListItem((int)Row[0], (string)Row[1]);
        //        if (ItemlistBox.Items.Contains(Item))
        //            lblDuplicates.Visible = true;
        //        ItemlistBox.Items.Add(Item);
        //    }
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstSelection.BeginUpdate();
            
            for (int i = lstItems.SelectedIndices.Count - 1; i >= 0; i--)
            {
                ListItem Item = (ListItem)lstItems.Items[lstItems.SelectedIndices[i]];
                lstSelection.Items.Add(Item);
                lstItems.Items.RemoveAt(lstItems.SelectedIndices[i]);
            }

            lstSelection.EndUpdate();

            EnableDisableOKButton();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenItemEditForm(ListDisplayName);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Get the ID's of each selected item, and save against the Parent Item

            switch (ListDisplayName)
            {
                #region Active Ingredient

                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        string Query = "";
                        int ID = 0;
                        string Name = "";

                        if (lstSelection.Items.Count > 0)
                        {
                            ListItem Item = (ListItem)lstSelection.Items[0];
                            ID = Item.ID;
                            Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            // Ingredient is different - it uses both a Linking Table and a direct reference.
                            // Just 'because' - clean up later as required.
                            // Done.  Ingredients are now only listed as IngredientID of the Product

                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                //Query = "SELECT ID, ProductID, IngredientID FROM ProductIngredient WHERE ProductIngredient.ProductID = " + ParentObjectID;
                                //DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                //if (Data.Tables.Count == 1)
                                //{
                                //    foreach (DataRow Row in Data.Tables[0].Rows)
                                //    {
                                //        Global.Audit("Delete", "ProductIngredient", "ID", Convert.ToInt32(Row["ID"]), Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                //        Global.Audit("Delete", "ProductIngredient", "ProductID", Convert.ToInt32(Row["ID"]), Global.Username.Replace("'", "''"), Row["ProductID"].ToString(), "", Application.ProductName, false);
                                //        Global.Audit("Delete", "ProductIngredient", "IngredientID", Convert.ToInt32(Row["ID"]), Global.Username.Replace("'", "''"), Row["IngredientID"].ToString(), "", Application.ProductName, false);
                                //    }
                                //}

                                //// Remove any existing ingredients for this product
                                //Query = "DELETE FROM ProductIngredient WHERE ProductIngredient.ProductID = " + ParentObjectID;
                                //Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                //Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Ingredient).  Executed Query: {0}", Query));

                                //// Add a single entry for this product
                                //Query = String.Format("INSERT INTO ProductIngredient (IngredientID, ProductID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                                //Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                //Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Ingredient).  Executed Query: {0}", Query));

                                //// AUDITING
                                //if (Data.Tables[0].Rows[0][0] != null)
                                //{
                                //    Global.Audit("Insert", "ProductIngredient", "ID", Convert.ToInt32(Data.Tables[0].Rows[0][0]), Global.Username.Replace("'", "''"), "", Data.Tables[0].Rows[0][0].ToString(), Application.ProductName, false);
                                //    Global.Audit("Insert", "ProductIngredient", "ProductID", Convert.ToInt32(Data.Tables[0].Rows[0][0]), Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                                //    Global.Audit("Insert", "ProductIngredient", "IngredientID", Convert.ToInt32(Data.Tables[0].Rows[0][0]), Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                                //}
                                // AUDITING
                                Query = "SELECT ID, IngredientID FROM Product WHERE ID = " + ParentObjectID;
                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Product", "IngredientID", Convert.ToInt32(Row["ID"]), Global.Username.Replace("'", "''"), Row["IngredientID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Product SET IngredientID = " + ID.ToString() + " WHERE Product.ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Ingredient).  Executed Query: {0}", Query));
                            }
                        }
                        else
                        {
                            // *********** Ingredient is different - it uses both a Linking Table and a direct reference.
                            // *********** Just 'because' - clean up later as required.
                            // NOW ONLY USES DIRECT REFERENCE !!!

                            if (!ReturnListOnly)
                            {
                                Query = "SELECT ID, ProductID, IngredientID FROM ProductIngredient WHERE ProductIngredient.ProductID = " + ParentObjectID;
                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Delete", "ProductIngredient", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                        Global.Audit("Delete", "ProductIngredient", "ProductID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ProductID"].ToString(), "", Application.ProductName, false);
                                        Global.Audit("Delete", "ProductIngredient", "IngredientID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["IngredientID"].ToString(), "", Application.ProductName, false);
                                    }
                                }

                                // Remove any existing ingredients for this product
                                Query = "DELETE FROM ProductIngredient WHERE ProductIngredient.ProductID = " + ParentObjectID;
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Ingredient).  Executed Query: {0}", Query));

                                // AUDITING
                                Query = "SELECT ID, IngredientID FROM Product WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Product", "IngredientID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["IngredientID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Product SET IngredientID = 0 WHERE Product.ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Ingredient).  Executed Query: {0}", Query));
                            }
                        }

                        break;
                    }

                #endregion

                #region Brand

                case "Brand":
                case "Brands":
                    {
                        string Query = "";
                        int ID = 0;

                        if (lstSelection.Items.Count > 0)
                        {
                            ListItem Item = (ListItem)lstSelection.Items[0];
                            ID = Item.ID;
                            Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, BrandID FROM Product WHERE ID = " + ParentObjectID;
                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Product", "BrandID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["BrandID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Product SET BrandID = " + ID.ToString() + " WHERE Product.ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Brand).  Executed Query: {0}", Query));
                            }
                        }
                        else
                        {
                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, BrandID FROM Product WHERE ID = " + ParentObjectID;
                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Product", "BrandID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["BrandID"].ToString(), "0", Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Product SET BrandID = 0 WHERE Product.ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Brand).  Executed Query: {0}", Query));
                            }
                        }
                        break;
                    }

                #endregion

                #region Category

                case "Category":
                case "Categories":
                    {
                        string Query = "";
                        DataSet Data = null;

                        if (!ReturnListOnly)
                        {
                            // AUDITING
                            Query = "SELECT ID, ProductID, CategoryID FROM ProductCategory WHERE ProductCategory.ProductID = " + ParentObjectID;
                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            if (Data.Tables.Count == 1)
                            {
                                foreach (DataRow Row in Data.Tables[0].Rows)
                                {
                                    Global.Audit("Delete", "ProductCategory", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "ProductCategory", "ProductID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ProductID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "ProductCategory", "CategoryID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["CategoryID"].ToString(), "", Application.ProductName, false);
                                }
                            }
                        }

                        if (!ReturnListOnly)
                        {
                            // Remove any existing categories for this product
                            Query = "DELETE FROM ProductCategory WHERE ProductCategory.ProductID = " + ParentObjectID;
                            Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Category).  Executed Query: {0}", Query));
                        }

                        foreach (ListItem Item in lstSelection.Items)
                        {
                            int ID = Item.ID;
                            string Name = Item.Name;
                            int RecordID = 0;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // Add a single entry for this product
                                Query = String.Format("INSERT INTO ProductCategory (CategoryID, ProductID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Category).  Executed Query: {0}", Query));

                                RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                                // AUDITING
                                Global.Audit("Insert", "ProductCategory", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "ProductCategory", "ProductID", RecordID, Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "ProductCategory", "CategoryID", RecordID, Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                            }
                        }

                        break;
                    }

                #endregion

                #region Condition

                case "Condition":
                case "Conditions":
                    {
                        string Query = "";
                        DataSet Data = null;

                        if (!ReturnListOnly)
                        {
                            Query = "SELECT ID, ProductID, ConditionID FROM ProductCondition WHERE ProductCondition.ProductID = " + ParentObjectID;
                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            if (Data.Tables.Count == 1)
                            {
                                foreach (DataRow Row in Data.Tables[0].Rows)
                                {
                                    Global.Audit("Delete", "ProductCondition", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "ProductCondition", "ProductID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ProductID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "ProductCondition", "ConditionID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ConditionID"].ToString(), "", Application.ProductName, false);
                                }
                            }

                            // Remove any existing conditions for this product
                            Query = "DELETE FROM ProductCondition WHERE ProductCondition.ProductID = " + ParentObjectID;
                            Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Condition).  Executed Query: {0}", Query));
                        }

                        foreach (ListItem Item in lstSelection.Items)
                        {
                            int ID = Item.ID;
                            string Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // Add a single entry for this product
                                Query = String.Format("INSERT INTO ProductCondition (ConditionID, ProductID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Condition).  Executed Query: {0}", Query));

                                // AUDITING
                                Global.Audit("Insert", "ProductCondition", "ID", (int)Data.Tables[0].Rows[0][0], Global.Username.Replace("'", "''"), "", Data.Tables[0].Rows[0][0].ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "ProductCondition", "ProductID", (int)Data.Tables[0].Rows[0][0], Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "ProductCondition", "ConditionID", (int)Data.Tables[0].Rows[0][0], Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                            }
                        }

                        break;
                    }

                #endregion

                #region Certificate

                case "Certificate":
                case "Certificates":
                    {
                        string Query = "";
                        int ID = 0;
                        DataSet Data = null;

                        if (lstSelection.Items.Count > 0)  // One or more User Accounts selected
                        {
                            ListItem Item = (ListItem)lstSelection.Items[0];
                            ID = Item.ID;
                            Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, Name, CertificateID FROM Event WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Event", "CertificateID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["CertificateID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Event SET CertificateID = " + ID.ToString() + " WHERE ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Certificate).  Executed Query: {0}", Query));
                            }
                        }
                        else // Zero User Accounts selected
                        {
                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, Name, CertificateID FROM Event WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Event", "CertificateID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["CertificateID"].ToString(), "0", Application.ProductName, false);
                                    }
                                }

                                Query = String.Format("UPDATE Event SET CertificateID = 0 WHERE ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Certificate).  Executed Query: {0}", Query));
                            }
                        }
                        break;
                    }

                #endregion

                #region Document

                case "Document":
                case "Documents":
                    {
                        string Query = "";
                        DataSet Data = null;

                        if (!ReturnListOnly)
                        {
                            Query = "SELECT ID, EventID, DocumentID FROM EventDocument WHERE EventID = " + ParentObjectID;
                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            if (Data.Tables.Count == 1)
                            {
                                foreach (DataRow Row in Data.Tables[0].Rows)
                                {
                                    Global.Audit("Delete", "EventDocument", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "EventDocument", "EventID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["EventID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "EventDocument", "DocumentID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["DocumentID"].ToString(), "", Application.ProductName, false);
                                }
                            }

                            // Remove any existing conditions for this product
                            Query = "DELETE FROM EventDocument WHERE EventDocument.EventID = " + ParentObjectID;
                            Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Document).  Executed Query: {0}", Query));
                        }

                        foreach (ListItem Item in lstSelection.Items)
                        {
                            int ID = Item.ID;
                            string Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // Add a single entry for this product
                                Query = String.Format("INSERT INTO EventDocument (DocumentID, EventID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Document).  Executed Query: {0}", Query));

                                int Identity = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                                // AUDITING
                                Global.Audit("Insert", "EventDocument", "ID", Identity, Global.Username.Replace("'", "''"), "", Data.Tables[0].Rows[0][0].ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "EventDocument", "EventID", Identity, Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "EventDocument", "DocumentID", Identity, Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                            }
                        }
                        break;
                    }

                #endregion

                #region End Use

                case "End Use":
                case "End Uses":
                    {
                        string Query = "";
                        DataSet Data = null;

                        if (!ReturnListOnly)
                        {
                            // AUDITING
                            Query = "SELECT ID, ProductID, IngredientID FROM ProductEndUse WHERE ProductEndUse.ProductID = " + ParentObjectID;
                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            if (Data.Tables.Count == 1)
                            {
                                foreach (DataRow Row in Data.Tables[0].Rows)
                                {
                                    Global.Audit("Delete", "ProductEndUse", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "ProductEndUse", "ProductID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ProductID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "ProductEndUse", "EndUseID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["EndUseID"].ToString(), "", Application.ProductName, false);
                                }
                            }

                            // Remove any existing conditions for this product
                            Query = "DELETE FROM ProductEndUse WHERE ProductEndUse.ProductID = " + ParentObjectID;
                            Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (End Use).  Executed Query: {0}", Query));
                        }

                        foreach (ListItem Item in lstSelection.Items)
                        {
                            int ID = Item.ID;
                            string Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // Add a single entry for this product
                                Query = String.Format("INSERT INTO ProductEndUse (EndUseID, ProductID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (End Use).  Executed Query: {0}", Query));

                                int Identity = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                                // AUDITING
                                Global.Audit("Insert", "ProductEndUse", "ID", Identity, Global.Username.Replace("'", "''"), "", Identity.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "ProductEndUse", "ProductID", Identity, Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "ProductEndUse", "EndUseID", Identity, Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                            }
                        }

                        break;
                    }
                #endregion

                #region Event Type

                case "Event Type":
                case "Event Types":
                    {
                        string Query = "";
                        int ID = 0;

                        if (lstSelection.Items.Count > 0)  // One or more User Accounts selected
                        {
                            ListItem Item = (ListItem)lstSelection.Items[0];
                            ID = Item.ID;
                            Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, Name, TypeID FROM Event WHERE ID = " + ParentObjectID;
                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Event", "TypeID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["TypeID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Event SET TypeID = " + ID.ToString() + " WHERE ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Event Type).  Executed Query: {0}", Query));
                            }
                        }
                        else // Zero User Accounts selected
                        {
                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, Name, TypeID FROM Event WHERE ID = " + ParentObjectID;
                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Event", "TypeID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["TypeID"].ToString(), "0", Application.ProductName, false);
                                    }
                                }

                                Query = String.Format("UPDATE Event SET TypeID = 0 WHERE ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Event Type).  Executed Query: {0}", Query));
                            }
                        }
                        break;
                    }

                #endregion

                #region Schedule

                case "Schedule":
                case "Schedules":
                    {
                        string Query = "";
                        int ID = 0;
                        DataSet Data = null;

                        if (lstSelection.Items.Count > 0)
                        {
                            ListItem Item = (ListItem)lstSelection.Items[0];
                            ID = Item.ID;
                            Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, ScheduleID FROM Product WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Product", "ScheduleID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ScheduleID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Product SET ScheduleID = " + ID.ToString() + " WHERE Product.ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Schedule).  Executed Query: {0}", Query));
                            }
                        }
                        else
                        {
                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, ScheduleID FROM Product WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Product", "ScheduleID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ScheduleID"].ToString(), "0", Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Product SET ScheduleID = 0 WHERE Product.ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Schedule).  Executed Query: {0}", Query));
                            }
                        }
                        break;
                    }

                #endregion

                #region Store

                case "Store":
                case "Stores":
                    {
                        string Query = "";
                        DataSet Data = null;

                        if (!ReturnListOnly)
                        {
                            Query = "SELECT ID, EventID, StoreID FROM EventStore WHERE EventID = " + ParentObjectID;
                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            if (Data.Tables.Count == 1)
                            {
                                foreach (DataRow Row in Data.Tables[0].Rows)
                                {
                                    Global.Audit("Delete", "EventStore", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "EventStore", "EventID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["EventID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "EventStore", "StoreID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["StoreID"].ToString(), "", Application.ProductName, false);
                                }
                            }

                            // Remove any existing conditions for this product
                            Query = "DELETE FROM EventStore WHERE EventStore.EventID = " + ParentObjectID;
                            Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Store).  Executed Query: {0}", Query));
                        }

                        foreach (ListItem Item in lstSelection.Items)
                        {
                            int ID = Item.ID;
                            string Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // Add a single entry for this product
                                Query = String.Format("INSERT INTO EventStore (StoreID, EventID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Store).  Executed Query: {0}", Query));

                                int Identity = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                                // AUDITING
                                Global.Audit("Insert", "EventStore", "ID", Identity, Global.Username.Replace("'", "''"), "", Data.Tables[0].Rows[0][0].ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "EventStore", "EventID", Identity, Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "EventStore", "StoreID", Identity, Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                            }
                        }
                        break;
                    }

                #endregion

                #region Unit Of Measure

                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        string Query = "";
                        int ID = 0;
                        DataSet Data = null;

                        if (lstSelection.Items.Count > 0)
                        {
                            ListItem Item = (ListItem)lstSelection.Items[0];
                            ID = Item.ID;
                            Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, MeasureID FROM Product WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Product", "MeasureID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["MeasureID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Product SET MeasureID = " + ID.ToString() + " WHERE Product.ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Unit of Measure).  Executed Query: {0}", Query));
                            }
                        }
                        else
                        {
                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, MeasureID FROM Product WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Product", "MeasureID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["MeasureID"].ToString(), "0", Application.ProductName, false);
                                    }
                                }

                                Query = String.Format("UPDATE Product SET MeasureID = 0 WHERE Product.ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Unit of Measure).  Executed Query: {0}", Query));
                            }
                        }
                        break;
                    }

                #endregion

                #region User Account

                case "User Account":
                case "User Accounts":
                    {
                        string Query = "";
                        int ID = 0;

                        if (lstSelection.Items.Count > 0)  // One or more User Accounts selected
                        {
                            ListItem Item = (ListItem)lstSelection.Items[0];
                            ID = Item.ID;
                            Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            // For Events

                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, Name, OwnerUserAccountID FROM Event WHERE ID = " + ParentObjectID;
                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Event", "OwnerUserAccountID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["OwnerUserAccountID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Event SET OwnerUserAccountID = " + ID.ToString() + " WHERE ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (User Account).  Executed Query: {0}", Query));
                            }
                        }
                        else // Zero User Accounts selected
                        {
                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, Name, OwnerUserAccountID FROM Event WHERE ID = " + ParentObjectID;
                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Event", "OwnerUserAccountID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["OwnerUserAccountID"].ToString(), "0", Application.ProductName, false);
                                    }
                                }

                                Query = String.Format("UPDATE Event SET OwnerUserAccountID = 0 WHERE ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (User Account).  Executed Query: {0}", Query));
                            }
                        }
                        break;
                    }

                #endregion

                #region Presenter

                case "Presenter":
                case "Presenters":
                    {
                        string Query = "";
                        int ID = 0;
                        DataSet Data = null;

                        if (lstSelection.Items.Count > 0)  // One or more User Accounts selected
                        {
                            ListItem Item = (ListItem)lstSelection.Items[0];
                            ID = Item.ID;
                            Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            // For Events

                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, Name, PresenterID FROM Event WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Event", "PresenterID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["PresenterID"].ToString(), ID.ToString(), Application.ProductName, false);
                                    }
                                }

                                // Update Product
                                Query = String.Format("UPDATE Event SET PresenterID = " + ID.ToString() + " WHERE ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Presenter).  Executed Query: {0}", Query));
                            }
                        }
                        else // Zero User Accounts selected
                        {
                            if (!ReturnListOnly)
                            {
                                // AUDITING
                                Query = "SELECT ID, Name, PresenterID FROM Event WHERE ID = " + ParentObjectID;
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                if (Data.Tables.Count == 1)
                                {
                                    foreach (DataRow Row in Data.Tables[0].Rows)
                                    {
                                        Global.Audit("Update", "Event", "PresenterID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["PresenterID"].ToString(), "0", Application.ProductName, false);
                                    }
                                }

                                Query = String.Format("UPDATE Event SET PresenterID = 0 WHERE ID = " + ParentObjectID.ToString());
                                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Presenter).  Executed Query: {0}", Query));
                            }
                        }
                        break;
                    }

                #endregion

                #region Role

                case "Role":
                case "Roles":
                    {
                        string Query = "";
                        DataSet Data = null;

                        if (!ReturnListOnly)
                        {
                            // AUDITING
                            Query = "SELECT ID, UserAccountID, RoleID FROM UserAccountRole WHERE UserAccountID = " + ParentObjectID;
                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            if (Data.Tables.Count == 1)
                            {
                                foreach (DataRow Row in Data.Tables[0].Rows)
                                {
                                    Global.Audit("Delete", "UserAccountRole", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "UserAccountRole", "UserAccountID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["UserAccountID"].ToString(), "", Application.ProductName, false);
                                    Global.Audit("Delete", "UserAccountRole", "RoleID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["RoleID"].ToString(), "", Application.ProductName, false);
                                }
                            }

                            // Remove any existing roles for this UserAccount
                            Query = "DELETE FROM UserAccountRole WHERE UserAccountID = " + ParentObjectID;
                            Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Roles).  Executed Query: {0}", Query));
                        }

                        foreach (ListItem Item in lstSelection.Items)
                        {
                            int ID = Item.ID;
                            string Name = Item.Name;

                            SelectedIDList.Add(ID);
                            SelectedListItems.Add(Item);

                            if (!ReturnListOnly)
                            {
                                // Add a single entry for this product
                                Query = String.Format("INSERT INTO UserAccountRole (RoleID, UserAccountID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Roles).  Executed Query: {0}", Query));

                                int Identity = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                                // AUDITING
                                Global.Audit("Insert", "UserAccountRole", "ID", Identity, Global.Username.Replace("'", "''"), "", Identity.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "UserAccountRole", "UserAccountID", Identity, Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                                Global.Audit("Insert", "UserAccountRole", "RoleID", Identity, Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                            }
                        }

                        break;
                    }

                #endregion

                default:
                    {
                        MessageBox.Show("Could not save details.  Contact support.  Reference: 008-OK-" + ListDisplayName);
                        break;
                    }

                #region ***** TO DELETE *****

                //#region Certificate

                //case "Certificate":
                //case "Certificates":
                //    {
                //        string Query = "";
                //        int ID = 0;
                //        DataSet Data = null;

                //        if (lstSelection.Items.Count > 0)  // One or more User Accounts selected
                //        {
                //            ListItem Item = (ListItem)lstSelection.Items[0];
                //            ID = Item.ID;
                //            Name = Item.Name;

                //            SelectedIDList.Add(ID);
                //            SelectedListItems.Add(Item);

                //            if (!ReturnListOnly)
                //            {
                //                // AUDITING
                //                Query = "SELECT ID, Name, CertificateID FROM Event WHERE ID = " + ParentObjectID;
                //                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                if (Data.Tables.Count == 1)
                //                {
                //                    foreach (DataRow Row in Data.Tables[0].Rows)
                //                    {
                //                        Global.Audit("Update", "Event", "CertificateID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["CertificateID"].ToString(), ID.ToString(), Application.ProductName, false);
                //                    }
                //                }

                //                // Update Product
                //                Query = String.Format("UPDATE Event SET CertificateID = " + ID.ToString() + " WHERE ID = " + ParentObjectID.ToString());
                //                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Certificate).  Executed Query: {0}", Query));
                //            }
                //        }
                //        else // Zero User Accounts selected
                //        {
                //            if (!ReturnListOnly)
                //            {
                //                // AUDITING
                //                Query = "SELECT ID, Name, CertificateID FROM Event WHERE ID = " + ParentObjectID;
                //                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                if (Data.Tables.Count == 1)
                //                {
                //                    foreach (DataRow Row in Data.Tables[0].Rows)
                //                    {
                //                        Global.Audit("Update", "Event", "CertificateID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["CertificateID"].ToString(), "0", Application.ProductName, false);
                //                    }
                //                }

                //                Query = String.Format("UPDATE Event SET CertificateID = 0 WHERE ID = " + ParentObjectID.ToString());
                //                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Certificate).  Executed Query: {0}", Query));
                //            }
                //        }
                //        break;
                //    }

                //#endregion

                //#region Document

                //case "Document":
                //case "Documents":
                //    {
                //        string Query = "";
                //        DataSet Data = null;

                //        if (!ReturnListOnly)
                //        {
                //            Query = "SELECT ID, EventID, DocumentID FROM EventDocument WHERE EventID = " + ParentObjectID;
                //            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //            if (Data.Tables.Count == 1)
                //            {
                //                foreach (DataRow Row in Data.Tables[0].Rows)
                //                {
                //                    Global.Audit("Delete", "EventDocument", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                //                    Global.Audit("Delete", "EventDocument", "EventID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["EventID"].ToString(), "", Application.ProductName, false);
                //                    Global.Audit("Delete", "EventDocument", "DocumentID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["DocumentID"].ToString(), "", Application.ProductName, false);
                //                }
                //            }

                //            // Remove any existing conditions for this product
                //            Query = "DELETE FROM EventDocument WHERE EventDocument.EventID = " + ParentObjectID;
                //            Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //            Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Document).  Executed Query: {0}", Query));
                //        }

                //        foreach (ListItem Item in lstSelection.Items)
                //        {
                //            int ID = Item.ID;
                //            string Name = Item.Name;

                //            SelectedIDList.Add(ID);
                //            SelectedListItems.Add(Item);

                //            if (!ReturnListOnly)
                //            {
                //                // Add a single entry for this product
                //                Query = String.Format("INSERT INTO EventDocument (DocumentID, EventID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                //                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Document).  Executed Query: {0}", Query));

                //                int Identity = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                //                // AUDITING
                //                Global.Audit("Insert", "EventDocument", "ID", Identity, Global.Username.Replace("'", "''"), "", Data.Tables[0].Rows[0][0].ToString(), Application.ProductName, false);
                //                Global.Audit("Insert", "EventDocument", "EventID", Identity, Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                //                Global.Audit("Insert", "EventDocument", "DocumentID", Identity, Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                //            }
                //        }
                //        break;
                //    }

                //#endregion

                //#region End Use

                //case "End Use":
                //case "End Uses":
                //    {
                //        string Query = "";
                //        DataSet Data = null;

                //        if (!ReturnListOnly)
                //        {
                //            // AUDITING
                //            Query = "SELECT ID, ProductID, IngredientID FROM ProductEndUse WHERE ProductEndUse.ProductID = " + ParentObjectID;
                //            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //            if (Data.Tables.Count == 1)
                //            {
                //                foreach (DataRow Row in Data.Tables[0].Rows)
                //                {
                //                    Global.Audit("Delete", "ProductEndUse", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                //                    Global.Audit("Delete", "ProductEndUse", "ProductID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ProductID"].ToString(), "", Application.ProductName, false);
                //                    Global.Audit("Delete", "ProductEndUse", "EndUseID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["EndUseID"].ToString(), "", Application.ProductName, false);
                //                }
                //            }

                //            // Remove any existing conditions for this product
                //            Query = "DELETE FROM ProductEndUse WHERE ProductEndUse.ProductID = " + ParentObjectID;
                //            Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //            Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (End Use).  Executed Query: {0}", Query));
                //        }

                //        foreach (ListItem Item in lstSelection.Items)
                //        {
                //            int ID = Item.ID;
                //            string Name = Item.Name;

                //            SelectedIDList.Add(ID);
                //            SelectedListItems.Add(Item);

                //            if (!ReturnListOnly)
                //            {
                //                // Add a single entry for this product
                //                Query = String.Format("INSERT INTO ProductEndUse (EndUseID, ProductID) VALUES (" + ID.ToString() + "," + ParentObjectID.ToString() + ");SELECT SCOPE_IDENTITY()");
                //                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (End Use).  Executed Query: {0}", Query));

                //                int Identity = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                //                // AUDITING
                //                Global.Audit("Insert", "ProductEndUse", "ID", Identity, Global.Username.Replace("'", "''"), "", Identity.ToString(), Application.ProductName, false);
                //                Global.Audit("Insert", "ProductEndUse", "ProductID", Identity, Global.Username.Replace("'", "''"), "", ParentObjectID.ToString(), Application.ProductName, false);
                //                Global.Audit("Insert", "ProductEndUse", "EndUseID", Identity, Global.Username.Replace("'", "''"), "", ID.ToString(), Application.ProductName, false);
                //            }
                //        }

                //        break;
                //    }
                //#endregion

                //#region Event Type

                //case "Event Type":
                //case "Event Types":
                //    {
                //        string Query = "";
                //        int ID = 0;

                //        if (lstSelection.Items.Count > 0)  // One or more User Accounts selected
                //        {
                //            ListItem Item = (ListItem)lstSelection.Items[0];
                //            ID = Item.ID;
                //            Name = Item.Name;

                //            SelectedIDList.Add(ID);
                //            SelectedListItems.Add(Item);

                //            if (!ReturnListOnly)
                //            {
                //                // AUDITING
                //                Query = "SELECT ID, Name, TypeID FROM Event WHERE ID = " + ParentObjectID;
                //                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                if (Data.Tables.Count == 1)
                //                {
                //                    foreach (DataRow Row in Data.Tables[0].Rows)
                //                    {
                //                        Global.Audit("Update", "Event", "TypeID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["TypeID"].ToString(), ID.ToString(), Application.ProductName, false);
                //                    }
                //                }

                //                // Update Product
                //                Query = String.Format("UPDATE Event SET TypeID = " + ID.ToString() + " WHERE ID = " + ParentObjectID.ToString());
                //                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Event Type).  Executed Query: {0}", Query));
                //            }
                //        }
                //        else // Zero User Accounts selected
                //        {
                //            if (!ReturnListOnly)
                //            {
                //                // AUDITING
                //                Query = "SELECT ID, Name, TypeID FROM Event WHERE ID = " + ParentObjectID;
                //                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                if (Data.Tables.Count == 1)
                //                {
                //                    foreach (DataRow Row in Data.Tables[0].Rows)
                //                    {
                //                        Global.Audit("Update", "Event", "TypeID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["TypeID"].ToString(), "0", Application.ProductName, false);
                //                    }
                //                }

                //                Query = String.Format("UPDATE Event SET TypeID = 0 WHERE ID = " + ParentObjectID.ToString());
                //                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                //                Global.Common.Logging.WriteDebugEvent(String.Format("List Selection: (Event Type).  Executed Query: {0}", Query));
                //            }
                //        }
                //        break;
                //    }

                //#endregion

                #endregion
            }

            if (_ParentForm != null)
            {
                _ParentForm.LoadProductDetails(false);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedItems();
        }

        private void EnableDisableOKButton()
        {
            if (SingleItemConstraint)
            {
                btnOK.Enabled = lstSelection.Items.Count < 2;
            }
            else
            {
                //btnOK.Enabled = lstSelection.Items.Count > 0;
            }
        }

        private void frmListItemSelection_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);
            
            this.Text = ListDisplayName;

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
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_general_book_256;
                        this.Icon = Properties.Resources.supervista_general_book;
                        gpTitle.GradientStartColor = Global.Theme[5];
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
                case "Role":
                case "Roles":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_networking_role_256;
                        this.Icon = Properties.Resources.vista_networking_role;
                        gpTitle.GradientStartColor = Global.Theme[11];
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
                case "Product":
                case "Products":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_business_benchmarking_256;
                        this.Icon = Properties.Resources.supervista_business_benchmarking;
                        gpTitle.GradientStartColor = Global.Theme[16];
                        break;
                    }
            }

            if (SingleItemConstraint)
            {
                lblSelection.Text = string.Format("Select a single {0}.", ListDisplayName);
                lstItems.SelectionMode = SelectionMode.One;
            }
            else
            {
                lblSelection.Text = string.Format("Select one or more {0}.", ListDisplayName);
                lstItems.SelectionMode = SelectionMode.MultiExtended;
            }

            this.Show();
            this.Refresh();

            if (Properties.Settings.Default.EnableSpellCheck) txtFilter.EnableSpellCheck();

            LoadItems();

            btnEdit.Enabled = !ListIsReadOnly;

            txtFilter.Focus();
        }

        private void LoadItems()
        {
            switch (ListDisplayName)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        Global.GetAllIngredients(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Product:
                                {
                                    GetProductIngredients(); // Although naming suggests otherwise, it's only a single Ingredient            
                                    break;
                                }
                        }
                        
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        Global.GetAllBrands(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Product:
                                {
                                    GetProductBrands(); // Although naming suggests otherwise, it's only a single Brand
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Catalog":
                case "Catalogs":
                    {
                        Global.GetAllCatalogs(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Product:
                                {
                                    //GetProductBrands(); // Although naming suggests otherwise, it's only a single Brand
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        Global.GetAllCategories(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Product:
                                {
                                    GetProductCategories();
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        Global.GetAllCertificates(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Event:
                                {
                                    GetEventCertificates(); // Although naming suggests otherwise, it's only a single Certificate
                                    break;
                                }
                            case Helper.ItemType.Task:
                                {
                                    GetTaskCertificates(); // Although naming suggests otherwise, it's only a single Certificate
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        Global.GetAllConditions(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Product:
                                {
                                    GetProductConditions();
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Document":
                case "Documents":
                    Global.GetAllDocuments(lstItems);
                    switch (_ParentType)
                    {
                        case Helper.ItemType.Event:
                            {
                                GetEventDocuments();
                                break;
                            }
                        case Helper.ItemType.Task:
                            {
                                GetTaskDocuments();
                                break;
                            }
                    }
                    RemoveItemsInSelectionListFromItemList();
                    break;
                case "End Use":
                case "End Uses":
                    {
                        Global.GetAllEndUses(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Product:
                                {
                                    GetProductEndUses();
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        Global.GetAllEventTypes(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Event:
                                {
                                    GetEventEventTypes(); // Although naming suggests otherwise, it's only a single EventType
                                    break;
                                }
                        }
                        
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        Global.GetAllPermissions(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Role:
                                {
                                    GetRolePermissions();
                                    break;
                                }
                            case Helper.ItemType.UserAccount:
                                {
                                    GetUserAccountPermissions();
                                    break;
                                }
                        }
                        //GetEventDocuments();
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Presenter":
                case "Presenters":
                    {
                        Global.GetAllUserAccounts(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Event:
                                {
                                    GetEventPresenterAccounts(); // Although naming suggests otherwise, it's only a single Presenter
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        Global.GetAllRoles(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Permission:
                                {
                                    GetPermissionRoles();
                                    break;
                                }
                            case Helper.ItemType.Task:
                                {
                                    GetTaskRoles();
                                    break;
                                }
                            case Helper.ItemType.UserAccount:
                                {
                                    GetUserAccountRoles();
                                    break;
                                }
                        }
                        //GetEventDocuments();
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        Global.GetAllSchedules(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Product:
                                {
                                    GetProductSchedules(); // Although naming suggests otherwise, it's only a single Schedule
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        Global.GetAllStores(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Event:
                                {
                                    GetEventStores();
                                    break;
                                }
                            case Helper.ItemType.Task:
                                {
                                    GetTaskStores();
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        Global.GetAllUnitsOfMeasure(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Product:
                                {
                                    GetProductUnitsOfMeasure(); // Although naming suggests otherwise, it's only a single UOM
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
                case "User Account":
                case "User Accounts":
                    {
                        Global.GetAllUserAccounts(lstItems);
                        switch (_ParentType)
                        {
                            case Helper.ItemType.Event:
                                {
                                    GetEventUserAccounts(); // Although naming suggests otherwise, it's only a single User Account
                                    break;
                                }
                        }
                        RemoveItemsInSelectionListFromItemList();
                        break;
                    }
            }
        }

        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            lstSelection.BeginUpdate();
            
            for (int i = lstItems.SelectedIndices.Count - 1; i >= 0; i--)
            {
                ListItem Item = (ListItem)lstItems.Items[lstItems.SelectedIndices[i]];
                lstSelection.Items.Add(Item);
                lstItems.Items.RemoveAt(lstItems.SelectedIndices[i]);
            }

            lstSelection.EndUpdate();

            EnableDisableOKButton();
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = (lstItems.SelectedItems.Count > 0);

            if (lstItems.SelectedItem != null)
            {
                ListItem Item = (ListItem)lstItems.SelectedItem;

                _ItemID = Item.ID;
            }
        }

        private void lstSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = (lstSelection.SelectedItems.Count > 0);
        }

        private void OpenItemEditForm(string ListDisplayName)
        {
            frmListEdit007 ItemEditForm = new frmListEdit007(DisplayName: ListDisplayName);

            ItemEditForm.Show();
        }

        private void RemoveItemsInSelectionListFromItemList()
        {
            for (int i = 0; i < lstSelection.Items.Count; i++)
            {
                ListItem Item = (ListItem)lstSelection.Items[i];
                int ID = Item.ID;
                string Name = Item.Name;
                if (lstItems.Items.Contains(Item))
                {
                    lstItems.Items.Remove(Item);
                }

            }

            EnableDisableOKButton();
        }

        private void RemoveSelectedItems()
        {
            lstItems.BeginUpdate();
            lstSelection.BeginUpdate();
            
            for (int i = lstSelection.SelectedIndices.Count - 1; i >= 0; i--)
            {
                ListItem Item = (ListItem)lstSelection.Items[lstSelection.SelectedIndices[i]];
                lstItems.Items.Add(Item); //lstItems.Items.Add(lstSelection.Items[lstSelection.SelectedIndices[i]].ToString());
                lstSelection.Items.RemoveAt(lstSelection.SelectedIndices[i]);
            }

            lstItems.EndUpdate();
            lstSelection.EndUpdate();
            EnableDisableOKButton();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text == "")
            {
                lstItems.SelectedItems.Clear();
            }
            else
            {
                lstItems.SelectedItems.Clear();

                lstItems.BeginUpdate();

                for (int i = 0; i < lstItems.Items.Count; i++)
                {
                    string s = lstItems.Items[i].ToString();

                    if (s.ToString().ToLower().Contains(txtFilter.Text.ToLower()))
                    {
                        lstItems.SelectedItems.Add(lstItems.Items[i]);
                    }
                }

                lstItems.EndUpdate();
            }
        }

        private void frmListItemSelection008_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void lstSelection_DoubleClick(object sender, EventArgs e)
        {
            if (Global.WriteAllowed(ListDisplayName))
            {
                lstItems.BeginUpdate();
                lstSelection.BeginUpdate();

                for (int i = lstSelection.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    ListItem Item = (ListItem)lstSelection.Items[lstSelection.SelectedIndices[i]];
                    lstItems.Items.Add(Item);
                    lstSelection.Items.RemoveAt(lstSelection.SelectedIndices[i]);
                }

                lstItems.EndUpdate();
                lstSelection.EndUpdate();
            }
        }
    }
}
