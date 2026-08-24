using i00SpellCheck;
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
    public partial class frmManageLinkedItems00A : Form
    {
        public string ExistingItemsQuery { get; set; }
        public string ItemType { get; set; }
        public int LinkedItemID { get; set; }
        public Helper.ItemType ParentItemType { get; set; }
        public string SelectText { get; set; }
        public string SourceListQuery { get; set; }
        public string SourceTable { get; set; }

        public frmManageLinkedItems00A()
        {
            InitializeComponent();

            ParentItemType = Helper.ItemType.None;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstItems.BeginUpdate();
            lstSelection.BeginUpdate();

            for (int i = lstItems.SelectedIndices.Count - 1; i >= 0; i--)
            {
                ListItem Item = (ListItem)lstItems.Items[lstItems.SelectedIndices[i]];
                lstSelection.Items.Add(Item);
                lstItems.Items.RemoveAt(lstItems.SelectedIndices[i]);
            }

            lstItems.EndUpdate();
            lstSelection.EndUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Get the ID's of each selected item, and save against the appropriate linking table
            // Supports Condition and Ingredient linking

            Cursor.Current = Cursors.WaitCursor;

            string Query = "";

            switch (ItemType)
            {
                case "Condition":
                case "Conditions":
                    {
                        int RecordID = 0;

                        // LinkedItemID refers to the Ingredient!

                        // AUDITING
                        Query = "SELECT ID, ConditionID, IngredientID FROM ConditionIngredient WHERE IngredientID = " + LinkedItemID;
                        DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                        if (Data.Tables.Count == 1)
                        {
                            foreach (DataRow Row in Data.Tables[0].Rows)
                            {
                                Global.Audit("Delete", "ConditionIngredient", "ID", (int)Row["ID"], Global.Username, Row["ID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "ConditionIngredient", "ConditionID", (int)Row["ID"], Global.Username, Row["ConditionID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "ConditionIngredient", "IngredientID", (int)Row["ID"], Global.Username, Row["IngredientID"].ToString(), "", Application.ProductName, false);
                            }
                        }

                        // Delete all existing linking for this linked ItemID
                        Query = "DELETE FROM ConditionIngredient WHERE IngredientID = " + LinkedItemID;

                        Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                        // Write the selected linking for this linked ItemID
                        foreach (ListItem Item in lstSelection.Items)
                        {
                            Query = "INSERT INTO ConditionIngredient (ConditionID, IngredientID) VALUES (" + Item.ID + "," + LinkedItemID + ");SELECT SCOPE_IDENTITY()";

                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                            RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                            // AUDITING
                            Global.Audit("Insert", "ConditionIngredient", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "ConditionIngredient", "ConditionID", RecordID, Global.Username.Replace("'", "''"), "", LinkedItemID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "ConditionIngredient", "IngredientID", RecordID, Global.Username.Replace("'", "''"), "", Item.ID.ToString(), Application.ProductName, false);
                        }
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        int RecordID = 0;

                        // AUDITING
                        Query = "SELECT ID, ConditionID, DocumentID FROM ConditionDocument WHERE DocumentID = " + LinkedItemID;
                        DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                        if (Data.Tables.Count == 1)
                        {
                            foreach (DataRow Row in Data.Tables[0].Rows)
                            {
                                Global.Audit("Delete", "ConditionDocument", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "ConditionDocument", "ConditionID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ConditionID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "ConditionDocument", "DocumentID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["DocumentID"].ToString(), "", Application.ProductName, false);
                            }
                        }

                        // Delete all existing linking for this linked ItemID
                        Query = "DELETE FROM ConditionDocument WHERE ConditionID = " + LinkedItemID;

                        Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                        // Write the selected linking for this linked ItemID
                        foreach (ListItem Item in lstSelection.Items)
                        {
                            Query = "INSERT INTO ConditionDocument (DocumentID, ConditionID) VALUES (" + Item.ID + "," + LinkedItemID + ");SELECT SCOPE_IDENTITY()";

                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                            RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                            // AUDITING
                            Global.Audit("Insert", "ConditionDocument", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "ConditionDocument", "DocumentID", RecordID, Global.Username.Replace("'", "''"), "", Item.ID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "ConditionDocument", "ConditionID", RecordID, Global.Username.Replace("'", "''"), "", LinkedItemID.ToString(), Application.ProductName, false);
                        }
                        break;
                    }
                case "Event":
                case "Events":
                    {
                        // AUDITING
                        if (lstSelection.Items.Count == 0)
                        {
                            Query = "SELECT ID, Name, TypeID FROM Event WHERE ID = " + LinkedItemID;
                            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            if (Data != null)
                            {
                                foreach (DataRow Row in Data.Tables[0].Rows)
                                {
                                    Global.Audit("Delete", "Event", "TypeID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["CertificateID"].ToString(), "", Application.ProductName, false);
                                }
                            }

                            // set all events with that EventType to not have an EventType
                            Query = "UPDATE Event SET TypeID = 0 WHERE TypeID = " + LinkedItemID;

                            Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);
                        }
                        else
                        {
                            // Write the selected CertificateID for this Event
                            foreach (ListItem Item in lstSelection.Items)
                            {
                                Query = "UPDATE Event SET TypeID = " + LinkedItemID + " WHERE ID = " + Item.ID.ToString();

                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                                // AUDITING
                                Global.Audit("Update", "Event", "TypeID", LinkedItemID, Global.Username.Replace("'", "''"), "", LinkedItemID.ToString(), Application.ProductName, false);
                            }
                        }
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        // AUDITING
                        if (lstSelection.Items.Count == 0)
                        {
                            Query = "SELECT ID, TypeID FROM Event WHERE ID = " + LinkedItemID;
                            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                            if (Data != null)
                            {
                                foreach (DataRow Row in Data.Tables[0].Rows)
                                {
                                    Global.Audit("Delete", "Event", "TypeID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["TypeID"].ToString(), "", Application.ProductName, false);
                                }
                            }

                            // Delete the current CertificateID for this Event
                            Query = "UPDATE Event SET TypeID = 0 WHERE ID = " + LinkedItemID;

                            Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);
                        }
                        else
                        {
                            // Write the selected CertificateID for this Event
                            foreach (ListItem Item in lstSelection.Items)
                            {
                                Query = "UPDATE Event SET TypeID = " + LinkedItemID + " WHERE ID = " + Item.ID.ToString();

                                DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                                // AUDITING
                                Global.Audit("Update", "Event", "TypeID", LinkedItemID, Global.Username.Replace("'", "''"), "", LinkedItemID.ToString(), Application.ProductName, false);
                            }
                        }
                        break;
                    }
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        int RecordID = 0;

                        // AUDITING
                        Query = "SELECT ID, ConditionID, IngredientID FROM ConditionIngredient WHERE IngredientID = " + LinkedItemID;
                        DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                        if (Data.Tables.Count == 1)
                        {
                            foreach (DataRow Row in Data.Tables[0].Rows)
                            {
                                Global.Audit("Delete", "ConditionIngredient", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "ConditionIngredient", "ConditionID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ConditionID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "ConditionIngredient", "IngredientID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["IngredientID"].ToString(), "", Application.ProductName, false);
                            }
                        }

                        // Delete all existing linking for this linked ItemID
                        Query = "DELETE FROM ConditionIngredient WHERE IngredientID = " + LinkedItemID;

                        Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                        // Write the selected linking for this linked ItemID
                        foreach (ListItem Item in lstSelection.Items)
                        {
                            Query = "INSERT INTO ConditionIngredient (ConditionID, IngredientID) VALUES (" + Item.ID + "," + LinkedItemID + ");SELECT SCOPE_IDENTITY()";

                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                            RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                            // AUDITING
                            Global.Audit("Insert", "ConditionIngredient", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "ConditionIngredient", "ConditionID", RecordID, Global.Username.Replace("'", "''"), "", Item.ID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "ConditionIngredient", "IngredientID", RecordID, Global.Username.Replace("'", "''"), "", LinkedItemID.ToString(), Application.ProductName, false);
                        }
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        int RecordID = 0;

                        // AUDITING
                        Query = "SELECT ID, RoleID, PermissionID FROM RolePermission WHERE RoleID = " + LinkedItemID;
                        DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                        if (Data.Tables.Count == 1)
                        {
                            foreach (DataRow Row in Data.Tables[0].Rows)
                            {
                                Global.Audit("Delete", "RolePermission", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "RolePermission", "RoleID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["RoleID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "RolePermission", "PermissionID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["PermissionID"].ToString(), "", Application.ProductName, false);
                            }
                        }

                        // Delete all existing linking for this linked ItemID
                        Query = "DELETE FROM RolePermission WHERE RoleID = " + LinkedItemID;

                        Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                        // Write the selected Permissions (Item.ID) for this Role (LinkedItemID)
                        foreach (ListItem Item in lstSelection.Items)
                        {
                            Query = "INSERT INTO RolePermission (RoleID, PermissionID) VALUES (" + LinkedItemID + "," + Item.ID + ");SELECT SCOPE_IDENTITY()";

                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                            RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                            // AUDITING
                            Global.Audit("Insert", "RolePermission", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "RolePermission", "RoleID", RecordID, Global.Username.Replace("'", "''"), "", Item.ID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "RolePermission", "PermissionID", RecordID, Global.Username.Replace("'", "''"), "", LinkedItemID.ToString(), Application.ProductName, false);
                        }
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        int RecordID = 0;

                        // AUDITING
                        Query = "SELECT ID, RoleID, PermissionID FROM RolePermission WHERE PermissionID = " + LinkedItemID;
                        DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                        if (Data.Tables.Count == 1)
                        {
                            foreach (DataRow Row in Data.Tables[0].Rows)
                            {
                                Global.Audit("Delete", "RolePermission", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "RolePermission", "RoleID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["RoleID"].ToString(), "", Application.ProductName, false);
                                Global.Audit("Delete", "RolePermission", "PermissionID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["PermissionID"].ToString(), "", Application.ProductName, false);
                            }
                        }

                        // Delete all existing linking for this linked ItemID
                        Query = "DELETE FROM RolePermission WHERE PermissionID = " + LinkedItemID;

                        Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                        // Write the selected linking for this linked ItemID
                        foreach (ListItem Item in lstSelection.Items)
                        {
                            Query = "INSERT INTO RolePermission (PermissionID, RoleID) VALUES (" + LinkedItemID + "," + Item.ID + ");SELECT SCOPE_IDENTITY()";

                            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                            RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                            // AUDITING
                            Global.Audit("Insert", "RolePermission", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "RolePermission", "RoleID", RecordID, Global.Username.Replace("'", "''"), "", Item.ID.ToString(), Application.ProductName, false);
                            Global.Audit("Insert", "RolePermission", "PermissionID", RecordID, Global.Username.Replace("'", "''"), "", LinkedItemID.ToString(), Application.ProductName, false);
                        }
                        break;
                    }
            }
            Cursor.Current = Cursors.Default;

            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetSourceItems();
            GetExistingItems();
            RemoveItemsInSelectionListFromItemList();

            txtFilter.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
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

        private void EnableButtonDueToPermissions(string ItemTypeName, Button TheButton)
        {
            //MessageBox.Show("Checking if this user has the following permission: " + "Write " + ItemTypeName);
            if (Global.Permissions.Contains("Write " + ItemTypeName))
            {
                TheButton.Enabled = true;
            }
        }

        private void frmManageLinkedItems_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);

            if (Properties.Settings.Default.EnableSpellCheck) txtFilter.EnableSpellCheck();

            switch (ItemType)
            {
                case "Ingredient":
                case "Ingredients":
                case "Active Ingredient":
                case "Active Ingredients":
                    {
                        gpTitle.Image = Properties.Resources.vista_medical_laboratory_256;
                        this.Icon = Properties.Resources.vista_medical_laboratory;
                        gpTitle.GradientStartColor = Global.Theme[0];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Brand":
                case "Brands":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_business_brand_256;
                        this.Icon = Properties.Resources.vista_business_brand;
                        gpTitle.GradientStartColor = Global.Theme[1];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Catalog":
                case "Catalogs":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.clean_business_catalog_256;
                        this.Icon = Properties.Resources.clean_business_catalog;
                        gpTitle.GradientStartColor = Global.Theme[18];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Category":
                case "Categories":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_accounting_inventory_categories_256;
                        this.Icon = Properties.Resources.vista_accounting_inventory_categories;
                        gpTitle.GradientStartColor = Global.Theme[2];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Certificate":
                case "Certificates":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_mobile_certificate_management_256;
                        this.Icon = Properties.Resources.realvista_mobile_certificate_management;
                        gpTitle.GradientStartColor = Global.Theme[3];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Condition":
                case "Conditions":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_medical_diagnostic_256;
                        this.Icon = PharmacyAssist.Properties.Resources.realvista_medical_diagnostic;
                        gpTitle.GradientStartColor = Global.Theme[4];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Document":
                case "Documents":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_general_book_256;
                        this.Icon = Properties.Resources.supervista_general_book;
                        gpTitle.GradientStartColor = Global.Theme[5];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "End Use":
                case "End Uses":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_medical_patient_information_256;
                        this.Icon = PharmacyAssist.Properties.Resources.supervista_medical_patient_information;
                        gpTitle.GradientStartColor = Global.Theme[6];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Event":
                case "Events":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_business_meeting_256;
                        this.Icon = Properties.Resources.vista_business_meeting;
                        gpTitle.GradientStartColor = Global.Theme[7];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Event Type":
                case "Event Types":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_general_stats_256;
                        this.Icon = Properties.Resources.supervista_general_stats;
                        gpTitle.GradientStartColor = Global.Theme[8];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Permission":
                case "Permissions":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.supervista_security_application_modules_256;
                        this.Icon = Properties.Resources.supervista_security_application_modules;
                        gpTitle.GradientStartColor = Global.Theme[9];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Presenter":
                case "Presenters":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.windows7_general_group_256;
                        this.Icon = Properties.Resources.windows7_general_group;
                        gpTitle.GradientStartColor = Global.Theme[10];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Role":
                case "Roles":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_networking_role_256;
                        this.Icon = Properties.Resources.vista_networking_role;
                        gpTitle.GradientStartColor = Global.Theme[11];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Schedule":
                case "Schedules":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.vista_communications_skin_256;
                        this.Icon = Properties.Resources.vista_communications_skin;
                        gpTitle.GradientStartColor = Global.Theme[12];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Store":
                case "Stores":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.realvista_realestate_drugstore_256;
                        this.Icon = Properties.Resources.realvista_realestate_drugstore;
                        gpTitle.GradientStartColor = Global.Theme[13];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "Unit Of Measure":
                case "Units Of Measure":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.plasticxp_medical_allergy_vials_256;
                        this.Icon = Properties.Resources.plasticxp_medical_allergy_vials;
                        gpTitle.GradientStartColor = Global.Theme[14];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
                case "User Account":
                case "User Accounts":
                    {
                        gpTitle.Image = PharmacyAssist.Properties.Resources.windows7_general_group_256;
                        this.Icon = Properties.Resources.windows7_general_group;
                        gpTitle.GradientStartColor = Global.Theme[15];
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
                        //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
                        break;
                    }
            }

            if (SelectText != null)
            {
                this.Text = SelectText.Replace("&", "&&");
            }

            this.Show();
            this.Refresh();

            GetSourceItems();
            GetExistingItems();
            RemoveItemsInSelectionListFromItemList();

            //EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnOK);

            btnOK.Enabled = true;

            txtFilter.Focus();

        }

        private void frmManageLinkedItems00A_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void GetExistingItems()
        {
            Cursor.Current = Cursors.WaitCursor;

            DataSet Data = Core.SQL.Functions.Execute(ExistingItemsQuery, Global.SqlConnectionString);

            lstSelection.Items.Clear();
            lstSelection.BeginUpdate();

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem Item = new ListItem((int)Row[0], (string)Row[1]);

                lstSelection.Items.Add(Item);
            }

            lstSelection.EndUpdate();

            Cursor.Current = Cursors.Default;
        }

        private void GetSourceItems()
        {
            Cursor.Current = Cursors.WaitCursor;

            DataSet Data = Core.SQL.Functions.Execute(SourceListQuery, Global.SqlConnectionString);

            lstItems.Items.Clear();
            lstItems.BeginUpdate();

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem Item = new ListItem((int)Row[0], (string)Row[1]);

                lstItems.Items.Add(Item);
            }

            lstItems.EndUpdate();

            Cursor.Current = Cursors.Default;
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {

        }

        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            if (Global.WriteAllowed(ItemType))
            {
                lstItems.BeginUpdate();
                lstSelection.BeginUpdate();

                for (int i = lstItems.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    ListItem Item = (ListItem)lstItems.Items[lstItems.SelectedIndices[i]];
                    lstSelection.Items.Add(Item);
                    lstItems.Items.RemoveAt(lstItems.SelectedIndices[i]);
                }

                lstItems.EndUpdate();
                lstSelection.EndUpdate();
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex != -1)
            {
                //btnAdd.Enabled = true;
                EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnAdd);
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private void lstSelection_DoubleClick(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Write " + SourceTable))
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

        private void lstSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelection.SelectedIndex != -1)
            {
                //btnRemove.Enabled = true;
                EnableButtonDueToPermissions(Helper.ItemTypeName((int)ParentItemType), btnRemove);
            }
            else
            {
                btnRemove.Enabled = false;
            }
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
    }
}
