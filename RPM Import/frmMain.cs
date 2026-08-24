using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.SQL;

namespace RPM_Import
{
    public partial class frmMain : Form
    {
        private string _RPMConnectionString = Properties.Settings.Default.RPMConnectionString;
        private string _PAConnectionString = Properties.Settings.Default.DestinationPAConnectionString;
        private List<RPMProduct> _UpdatedProducts = new List<RPMProduct>();
        private List<RPMProduct> _UnalteredProducts = new List<RPMProduct>();
        private List<RPMProduct> _NewProducts = new List<RPMProduct>();
        private List<RPMProduct> _NewAndUpdatedProducts = new List<RPMProduct>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                _RPMConnectionString = Properties.Settings.Default.DevRPMConnectionString;
                _PAConnectionString = Properties.Settings.Default.DestinationPADevConnectionString;
            }

            txtSourceConnectionString.Text = _RPMConnectionString;
            txtDestinationConnectionString.Text = _PAConnectionString;
            txtImportQuery.Text = Properties.Settings.Default.ProductImportQuery;

            string[] Args = Environment.GetCommandLineArgs();

            if (Args.Length > 1)
            {
                this.Show();
                this.Refresh();

                tabPages.SelectedIndex = 1;

                try
                {
                    DoImport(false);
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    Environment.Exit(1);
                }

            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DoImport(true);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DoImport(false);
        }

        private void DoImport(bool Preview)
        {
            int SourceRowCount = 0;
            int Progress = 0;
            string ExistingProductSelectQuery = Properties.Settings.Default.ExistingProductSelectQuery; // "SELECT ID, UPI, Price FROM Product";
            string CatalogueSelectQuery = "";
            string CheckedQuery = Properties.Settings.Default.SetCheckedQuery;
            // Get the last catalogue ID in the system
            string LastCatalogueQuery = Properties.Settings.Default.LastCatalogueQuery; // "SELECT TOP 1 AutoSpecialsID AS ID, AutoSpecialsName AS Name FROM AutoSpecials ORDER BY AutoSpecialsID DESC";
            string LastKnownCatalogueQuery = Properties.Settings.Default.LastKnownCatalogueQuery; // "SELECT TOP 1 ID, RPMID, Name FROM Catalog ORDER BY RPMID DESC";
            bool NewCatalogue = false;
            int NewCatalogueID = 0;
            int Counter = 0;
            string AuditStatement = "";

            System.Data.SqlClient.SqlConnection RPMConnection = null;
            System.Data.SqlClient.SqlConnection PAConnection = null; // Pharmacy Assist connection

            System.Data.SqlClient.SqlDataAdapter CatalogueDataAdapter = null;
            System.Data.SqlClient.SqlDataAdapter RPMDataAdapter = null;
            System.Data.SqlClient.SqlDataAdapter ExistingProductsDataAdapter = null;

            // TODO:
            // Stock on hand

            // Deleted products.  ie, when not in RPM, Price = 0, Core = 0, Active = 0, SOH = 0
            //                    Needs a new field against product (Checked) CustomString1 is also used

            #region Setup

            // Clear the lists
            _NewAndUpdatedProducts.Clear();
            _NewProducts.Clear();
            _UnalteredProducts.Clear();
            _UpdatedProducts.Clear();

            lstNew.Items.Clear();
            lstUnaltered.Items.Clear();
            lstUpdates.Items.Clear();

            System.Data.DataSet LocalRPMDataSet = new DataSet("Products");
            System.Data.DataSet LocalPADataSet = new DataSet("Products");
            System.Data.DataSet LocalCatalogueDataSet = new DataSet("Products");

            DataTable LocalDestinationTable = null;
            DataTable LocalCatalogueTable = null;

            #endregion

            Cursor.Current = Cursors.WaitCursor;

            this.Refresh();

            #region Determine most recent vs most recent known Catalogue

            DataRow LastCatalogue = Functions.GetDataRowFromDataset(Functions.Execute(LastCatalogueQuery, txtSourceConnectionString.Text), 0, 0);
            DataRow LastKnownCatalogue = Functions.GetDataRowFromDataset(Functions.Execute(LastKnownCatalogueQuery, txtDestinationConnectionString.Text), 0, 0);

            if (Convert.ToInt32(LastCatalogue["ID"]) != Convert.ToInt32(LastKnownCatalogue["RPMID"]))
            {
                // There is a new catalogue since the last runtime
                lblStatus.Text = "Found a new catalogue: " + LastCatalogue["ID"].ToString(); lblStatus.Refresh();

                NewCatalogue = true;
                NewCatalogueID = (int)LastCatalogue["ID"];

                CatalogueSelectQuery = "SELECT s.AutoSpecialsName AS CatalogueName, a.StartDate, a.LastDate, p.CosmosUPI AS UPI, CAST(a.OrigRetailPrice AS float) / 100 AS SavemorPrice, CAST(a.AutoSpecialsRetail AS float) / 100 AS CatalogPrice, CAST(a.SpecialPrice AS float) / 100 AS CostPrice, CAST(CAST(a.AutoSpecialsRetail AS float) / 100 - CAST(a.SpecialPrice AS float) / 100 AS float) AS NormalSavings, CAST(CAST(a.OrigRetailPrice AS float) / 100 - CAST(a.SpecialPrice AS float) / 100 AS float) AS RetailSaving FROM AutoSpecialsItems AS a LEFT OUTER JOIN Product AS p ON p.ProductID = a.ProductID LEFT OUTER JOIN AutoSpecials AS s ON s.AutoSpecialsID = a.AutoSpecialsID WHERE a.StoreID = 2 AND a.AutoSpecialsID = " + NewCatalogueID.ToString();
            }

            #endregion

            try
            {
                #region Create and open Connections

                lblStatus.Text = "Creating and opening connection to RPM Database"; lblStatus.Refresh();
                // Create and open connection to source database (RPM)
                RPMConnection = new System.Data.SqlClient.SqlConnection(txtSourceConnectionString.Text);
                RPMConnection.Open();

                lblStatus.Text = "Creating and opening connection to Pharmacy Assist Database"; lblStatus.Refresh();
                // Create and open connection to destination database (Pharmacy Assist Database)
                PAConnection = new System.Data.SqlClient.SqlConnection(txtDestinationConnectionString.Text);
                PAConnection.Open();

                lblStatus.Text = "Creating Data Adapters"; lblStatus.Refresh();
                // Create data adapters
                RPMDataAdapter = new System.Data.SqlClient.SqlDataAdapter(txtImportQuery.Text, RPMConnection);
                ExistingProductsDataAdapter = new System.Data.SqlClient.SqlDataAdapter(ExistingProductSelectQuery, PAConnection);
                if (NewCatalogue) CatalogueDataAdapter = new System.Data.SqlClient.SqlDataAdapter(CatalogueSelectQuery, RPMConnection);

                lblStatus.Text = "Filling RPM data"; lblStatus.Refresh();
                // Fill table from Source
                RPMDataAdapter.Fill(LocalRPMDataSet, "RPMProducts");
                SourceRowCount = LocalRPMDataSet.Tables[0].Rows.Count;

                lblStatus.Text = "Filling existing data"; lblStatus.Refresh();
                // Fill table from existing data
                ExistingProductsDataAdapter.Fill(LocalPADataSet, "ExistingProducts");

                LocalDestinationTable = LocalPADataSet.Tables["ExistingProducts"];

                #endregion

                #region Update Catalogue data

                if (NewCatalogue)
                {
                    lblStatus.Text = "Filling catalogue data"; lblStatus.Refresh();
                    CatalogueDataAdapter.Fill(LocalCatalogueDataSet, "CatalogueProducts");

                    LocalCatalogueTable = LocalCatalogueDataSet.Tables["CatalogueProducts"];

                    // Before we can go any further, we need to get the product ID's for each of the catalogue records we want to import by doing a join
                    // across the two DataTables.  The product ID's are in LocalDestinationTable, the rest is in LocalCatalogueTable

                    var results = from CatalogueTable in LocalCatalogueTable.AsEnumerable()
                                  join ProductsTable in LocalDestinationTable.AsEnumerable() on (int)CatalogueTable["UPI"] equals (int)ProductsTable["UPI"]
                                  select new
                                  {
                                      CatalogPrice = Convert.ToDouble(CatalogueTable["CatalogPrice"]),
                                      CatalogID = (int)NewCatalogueID,
                                      ProductID = Convert.ToInt32(ProductsTable["ID"]),
                                      StartDate = Convert.ToDateTime(CatalogueTable["StartDate"]),
                                      LastDate = Convert.ToDateTime(CatalogueTable["LastDate"])
                                  };

                    results = results.AsEnumerable();

                    // Now to add each of these to the ProductCatalog table
                    foreach (var Row in results)
                    {
                        Counter++;
                        lblStatus.Text = string.Format("Loading catalogue pricing ({0} of {1})", Counter, LocalCatalogueTable.Rows.Count); lblStatus.Refresh();
                        string INSERTQuery = string.Format("INSERT INTO ProductCatalog (Price, CatalogID, ProductID, StartDate, EndDate) VALUES ({0},{1},{2},'{3}','{4}')", Row.CatalogPrice, Row.CatalogID, Row.ProductID, Row.StartDate.Date.ToString("yyyyMMdd"), Row.LastDate.Date.ToString("yyyyMMdd"));

                        Functions.ExecuteNonQuery(INSERTQuery, txtDestinationConnectionString.Text);
                    }

                    // Finally, add the RPM Catalog ID to the Catalog table so that we know about it
                    lblStatus.Text = string.Format("Inserting catalogue data)"); lblStatus.Refresh();
                    string CatalogINSERTQuery = string.Format("INSERT INTO Catalog (RPMID, Name) VALUES ({0},'{1}')", LastCatalogue["ID"], LastCatalogue["Name"].ToString().Replace("'", "''"));

                    Functions.ExecuteNonQuery(CatalogINSERTQuery, txtDestinationConnectionString.Text);
                }

                #endregion

                #region Determine new and updated products

                progressBar.Value = 0;
                progressBarNew.Value = 0;
                progressBarUpdates.Value = 0;
                progressBarUnaltered.Value = 0;

                progressBar.Maximum = SourceRowCount;
                progressBarNew.Maximum = SourceRowCount;
                progressBarUpdates.Maximum = SourceRowCount;
                progressBarUnaltered.Maximum = SourceRowCount;

                lblStatus.Text = "Looping through Source data"; lblStatus.Refresh();
                // Loop through each row in the source data
                foreach (DataRow Row in LocalRPMDataSet.Tables[0].Rows)
                {
                    int RPMID = (int)Row["ProductID"];  // This is the RPM ProductID
                    decimal NewPrice = Convert.ToDecimal(Row["Price"]);
                    decimal NewRecommendedPrice = Convert.ToDecimal(Row["RecommendedPrice"]);
                    Int32 UPI = (Int32)Row["UPI"];
                    string Name = (string)Row["Name"];
                    bool Deleted = (bool)Row["Deleted"];
                    int UpdateType = 0;

                    // Search for corresponding row in existing data
                    string SearchQuery = "SELECT ID, ISNULL(Price,CAST(0.00 AS float)) AS Price, ISNULL(RecommendedPrice,CAST(0.00 AS float)) AS RecommendedPrice FROM ExistingProducts WHERE UPI = " + UPI;

                    // Use Linq to find the data we need
                    var ExistingDataRow = from p in LocalDestinationTable.AsEnumerable()
                                          where p.Field<int>("UPI") == UPI
                                          select p;

                    if (ExistingDataRow.Count() > 0) // EXISTING product
                    {
                        DataRow ExistingProduct = (DataRow)ExistingDataRow.Single();

                        // SELECT ID, UPI, Price, RecommendedPrice FROM Product
                        // ID                = 0
                        // UPI               = 1
                        // Price             = 2
                        // Recommended Price = 3

                        int ExistingProductID = Convert.ToInt32(ExistingProduct.ItemArray[0]); // RPM Product ID
                        decimal ExistingPrice = Convert.ToDecimal(ExistingProduct.ItemArray[2]);
                        decimal ExistingRecommendedPrice = Convert.ToDecimal(ExistingProduct.ItemArray[3]);

                        if (ExistingPrice == NewPrice && (ExistingRecommendedPrice == NewRecommendedPrice && NewRecommendedPrice > 0)) // NO change
                        {
                            lstUnaltered.Items.Add(UPI.ToString());

                            RPMProduct Unaltered = new RPMProduct();
                            Unaltered.UPI = UPI;
                            Unaltered.OldPrice = ExistingPrice;
                            Unaltered.OldRecommendedPrice = ExistingRecommendedPrice;

                            _UnalteredProducts.Add(Unaltered);

                            progressBarUnaltered.Value += 1;

                            lblUnalteredCount.Text = _UnalteredProducts.Count.ToString();
                        }
                        else // UPDATED Product
                        {
                            // Work out what kind of update occurred
                            if (ExistingPrice != NewPrice) UpdateType = 1;                                                    // Price changed
                            if (ExistingRecommendedPrice != NewRecommendedPrice) UpdateType = 2;                              // Recommended price changed
                            if (ExistingPrice != NewPrice && ExistingRecommendedPrice != NewRecommendedPrice) UpdateType = 3; // Both prices changed

                            lstUpdates.Items.Add(UPI.ToString());

                            RPMProduct Updated = new RPMProduct();
                            Updated.UPI = UPI;
                            Updated.NewPrice = NewPrice;
                            Updated.NewRecommendedPrice = NewRecommendedPrice;
                            Updated.OldPrice = ExistingPrice;
                            Updated.OldRecommendedPrice = ExistingRecommendedPrice;
                            //Updated.ProductID = ExistingProductID; << Not required to set Product ID as it is never written to the Db (and this code is wrong anyway)
                            Updated.UpdateType = UpdateType;

                            _UpdatedProducts.Add(Updated);
                            _NewAndUpdatedProducts.Add(Updated);

                            progressBarUpdates.Value += 1;

                            lblUpdateCount.Text = _UpdatedProducts.Count.ToString();
                        }
                    }
                    else  // NEW product
                    {
                        lstNew.Items.Add(UPI.ToString());

                        RPMProduct NewProduct = new RPMProduct();
                        NewProduct.UPI = UPI;
                        NewProduct.NewPrice = NewPrice;
                        NewProduct.NewRecommendedPrice = NewRecommendedPrice;
                        NewProduct.OldPrice = 0;
                        // NewProduct.Name = Name + " (NEW)"; // UPDATED 13/11/2013
                        if (!NewProduct.Name.EndsWith(" (NEW)")) NewProduct.Name = Name + " (NEW)"; // UPDATED 16/11/2013
                        NewProduct.ProductID = 0;
                        NewProduct.RPMID = RPMID;

                        _NewProducts.Add(NewProduct);
                        _NewAndUpdatedProducts.Add(NewProduct);

                        progressBarNew.Value += 1;

                        lblNewCount.Text = _NewProducts.Count.ToString();
                    }

                    Progress += 1;
                    progressBar.Value = Progress;

                    Application.DoEvents();

                    #region Ignore

                    //using (System.Data.SqlClient.SqlDataAdapter DestinationDataAdapter = new System.Data.SqlClient.SqlDataAdapter(SearchQuery, DestinationConnection))
                    //{
                    //    DataSet QueryDataSet = new DataSet();
                    //    DestinationDataAdapter.Fill(QueryDataSet, "Product");
                    //    string Audit = "";


                    //    if (QueryDataSet.Tables[0].Rows.Count > 0)  // Found corresponding row
                    //    {
                    //        double CurrentPrice = Convert.ToDouble(QueryDataSet.Tables[0].Rows[0]["Price"]);
                    //        if (CurrentPrice != NewPrice)
                    //        {
                    //            lstUpdates.Items.Add(UPI.ToString());

                    //            lblUpdateCount.Text = lstUpdates.Items.Count.ToString();
                    //            //Console.WriteLine("UPI " + UPI.ToString() + " has a price update.");

                    //            string UpdateQuery = "UPDATE Product SET Price = " + NewPrice.ToString() + " WHERE ID = " + QueryDataSet.Tables[0].Rows[0]["ID"];

                    //            if (Preview)  // Don't actually change anything
                    //            {

                    //            }
                    //            else  // Update existing Product
                    //            {
                    //                //Core.SQL.Functions.ExecuteNonQuery(UpdateQuery, _DestinationConnectionString);
                    //            }

                    //            Audit = "";
                    //        }
                    //        else  // Unaltered
                    //        {
                    //            lstUnaltered.Items.Add(UPI.ToString());

                    //            lblUnalteredCount.Text = lstUnaltered.Items.Count.ToString();
                    //        }
                    //    }
                    //    else  // No corresponding row
                    //    {
                    //        lstNew.Items.Add(UPI.ToString());

                    //        lblNewCount.Text = lstNew.Items.Count.ToString();

                    //        string InsertQuery = "INSERT INTO Product () VALUES ()";

                    //        Audit = "";

                    //        if (Preview) // Don't actually change anything
                    //        {

                    //        }
                    //        else // Insert NEW Product
                    //        {

                    //        }


                    //    }

                    //    Progress += 1;
                    //    progressBar.Value = Progress;
                    //    //this.Refresh();
                    //    Application.DoEvents();
                    //}
                    #endregion
                }

                #endregion

                #region Create temporary table to store product data prior to insert/update

                lblStatus.Text = "Creating Temporary Table"; lblStatus.Refresh();

                // For speed, we now do a Bulk upsert.
                //Make a temp table in sql server that matches our production table
                string TemporaryTableCreateStatement = "CREATE TABLE #RPMImportProducts([UPI] [int] NULL,[Name] [nvarchar](max) NULL,[Price] [decimal](18, 2) NULL,[RecommendedPrice] [decimal](18, 2) NULL,[CoreProduct] [bit] NULL,[CustomString1] [nvarchar](max) NULL, [UpdateType] [int] NULL)";

                //Create a datatable that matches the temp table exactly. (WARNING: order of columns must match the order in the table)
                DataTable TemporaryTable = new DataTable();
                TemporaryTable.Columns.Add(new DataColumn("UPI", typeof(Int32)));
                TemporaryTable.Columns.Add(new DataColumn("Name", typeof(string)));
                TemporaryTable.Columns.Add(new DataColumn("Price", typeof(Decimal)));
                TemporaryTable.Columns.Add(new DataColumn("RecommendedPrice", typeof(Decimal)));
                TemporaryTable.Columns.Add(new DataColumn("CoreProduct", typeof(bool)));
                TemporaryTable.Columns.Add(new DataColumn("CustomString1", typeof(string)));
                TemporaryTable.Columns.Add(new DataColumn("UpdateType", typeof(Int32)));

                lblStatus.Text = "Adding new and updated products to Temporary Table"; lblStatus.Refresh();

                //Add prices in our list to our DataTable
                foreach (RPMProduct product in _NewAndUpdatedProducts)
                {
                    DataRow row = TemporaryTable.NewRow();
                    row["UPI"] = product.UPI.ToString();
                    row["Name"] = product.Name;
                    row["Price"] = product.NewPrice.ToString();
                    row["RecommendedPrice"] = product.NewRecommendedPrice.ToString();
                    row["CoreProduct"] = product.CoreProduct;
                    row["CustomString1"] = product.RPMID.ToString();
                    row["UpdateType"] = product.UpdateType.ToString();

                    TemporaryTable.Rows.Add(row);
                }

                #endregion

                #region Insert/update data

                lblStatus.Text = "Connecting to Pharmacy Assist database"; lblStatus.Refresh();
                //Connect to DB
                string conString = _PAConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();

                    lblStatus.Text = "Writing Temporary Table to database"; lblStatus.Refresh();
                    //Execute the command to make a temp table
                    SqlCommand cmd = new SqlCommand(TemporaryTableCreateStatement, con);
                    cmd.ExecuteNonQuery();

                    //BulkCopy the data in the DataTable to the temp table
                    using (SqlBulkCopy bulk = new SqlBulkCopy(con))
                    {
                        bulk.DestinationTableName = "#RPMImportProducts";
                        bulk.WriteToServer(TemporaryTable);
                    }

                    // Merging/deleting of products
                    // TODO:  When a match is found, update CustomString1 with the RPM ID

                    if (!Preview)
                    {
                        lblStatus.Text = "Merging Temporary Table into Products"; lblStatus.Refresh();
                        //Now use the merge command to upsert from the temp table to the production table
                        string MergeSqlStatement = "MERGE INTO Product AS Target " +
                                                   "USING #RPMImportProducts AS Source " +
                                                   "ON " +
                                                   "Target.UPI=Source.UPI " +
                                                   "WHEN MATCHED THEN " +
                                                   "UPDATE SET Target.Price=Source.Price, Target.RecommendedPrice=Source.RecommendedPrice, Target.CustomString1 =  Source.CustomString1 " +
                                                   "WHEN NOT MATCHED THEN " +
                                                   "INSERT (UPI,Price,RecommendedPrice,Name,CoreProduct,CustomString1) VALUES (Source.UPI,Source.Price,Source.RecommendedPrice,Source.Name,0,Source.CustomString1);";

                        cmd.CommandText = MergeSqlStatement;
                        cmd.ExecuteNonQuery();
                    }

                    lblStatus.Text = "Removing Temporary Table"; lblStatus.Refresh();
                    //Clean up the temp table
                    cmd.CommandText = "drop table #RPMImportProducts";
                    cmd.ExecuteNonQuery();

                    // Auditing

                    lblStatus.Text = "Creating Temporary Table (Audit)"; lblStatus.Refresh();

                    // For speed, we now do a Bulk upsert.
                    //Make a temp table in sql server that matches our production table
                    string TemporaryAuditTableCreateStatement = "CREATE TABLE #RPMImportAudit([Description] [nvarchar](max) NULL,[TableName] [nvarchar](max) NULL,[FieldName] [nvarchar](max) NULL, [RecordID] [int] NULL, [Username] [nvarchar](max) NULL, [PreviousValue] [nvarchar](max) NULL, [NewValue] [nvarchar](max) NULL, [ApplicationName] [nvarchar](max) NULL)";

                    //Create a datatable that matches the temp table exactly. (WARNING: order of columns must match the order in the table)
                    DataTable TemporaryAuditTable = new DataTable();
                    TemporaryAuditTable.Columns.Add(new DataColumn("Description", typeof(string)));
                    TemporaryAuditTable.Columns.Add(new DataColumn("TableName", typeof(string)));
                    TemporaryAuditTable.Columns.Add(new DataColumn("FieldName", typeof(string)));
                    TemporaryAuditTable.Columns.Add(new DataColumn("RecordID", typeof(Int32)));
                    TemporaryAuditTable.Columns.Add(new DataColumn("Username", typeof(string)));
                    TemporaryAuditTable.Columns.Add(new DataColumn("PreviousValue", typeof(string)));
                    TemporaryAuditTable.Columns.Add(new DataColumn("NewValue", typeof(string)));
                    TemporaryAuditTable.Columns.Add(new DataColumn("ApplicationName", typeof(string)));

                    lblStatus.Text = "Adding Audit data to Temporary Table"; lblStatus.Refresh();

                    //Add prices in our list to our DataTable
                    foreach (RPMProduct product in _NewAndUpdatedProducts)
                    {
                        DataRow row = TemporaryAuditTable.NewRow();
                        if (product.OldPrice == 0.00M || product.OldPrice == 0M)
                        {
                            row["Description"] = "Import product from RPM";
                        }
                        else
                        {
                            switch (product.UpdateType)
                            {
                                case 1:
                                    row["Description"] = "Update price from RPM";
                                    row["FieldName"] = "Price";
                                    break;
                                case 2:
                                    row["Description"] = "Update recommended price from RPM";
                                    row["FieldName"] = "RecommendedPrice";
                                    break;
                                case 3:
                                    row["Description"] = "Update price and recommended price from RPM";
                                    row["FieldName"] = "Price";
                                    break;
                                default:
                                    break;
                            }
                            
                        }
                        row["TableName"] = "Product";
                        
                        row["RecordID"] = product.ProductID;
                        row["Username"] = "-";
                        row["PreviousValue"] = product.OldPrice;
                        row["NewValue"] = product.NewPrice;
                        row["ApplicationName"] = Application.ProductName;

                        TemporaryAuditTable.Rows.Add(row);
                    }

                    lblStatus.Text = "Connecting to Auditing database"; lblStatus.Refresh();
                    //Connect to DB
                    conString = txtDestinationConnectionString.Text;
                    using (SqlConnection AuditConnection = new SqlConnection(conString))
                    {
                        AuditConnection.Open();

                        lblStatus.Text = "Writing Temporary Table to database"; lblStatus.Refresh();
                        //Execute the command to make a temp table
                        SqlCommand AuditCmd = new SqlCommand(TemporaryAuditTableCreateStatement, AuditConnection);
                        AuditCmd.ExecuteNonQuery();

                        //BulkCopy the data in the DataTable to the temp table
                        using (SqlBulkCopy bulk = new SqlBulkCopy(AuditConnection))
                        {
                            bulk.DestinationTableName = "#RPMImportAudit";
                            bulk.WriteToServer(TemporaryAuditTable);
                        }

                        if (!Preview)
                        {
                            lblStatus.Text = "Merging Temporary Table into Audit"; lblStatus.Refresh();
                            //Now use the merge command to upsert from the temp table to the production table
                            string MergeSqlStatement = "MERGE INTO Audit AS Target " +
                                                       "USING #RPMImportAudit AS Source " +
                                                       "ON " +
                                                       "Target.RecordID=-1 " + // Force it to always insert
                                                       "WHEN MATCHED THEN " +
                                                       "UPDATE SET Target.Username='' " +
                                                       "WHEN NOT MATCHED THEN " +
                                                       "INSERT (Description,TableName,FieldName,RecordID,Username,PreviousValue,NewValue,ApplicationName) VALUES (Source.Description,Source.TableName,Source.FieldName,Source.RecordID,Source.Username,Source.PreviousValue,Source.NewValue,Source.ApplicationName);";

                            AuditCmd.CommandText = MergeSqlStatement;
                            AuditCmd.ExecuteNonQuery();
                        }

                        lblStatus.Text = "Removing Temporary Audit Table"; lblStatus.Refresh();
                        //Clean up the temp table
                        AuditCmd.CommandText = "drop table #RPMImportAudit";
                        AuditCmd.ExecuteNonQuery();
                    }


                    lblStatus.Text = "Cleaning up"; lblStatus.Refresh();
                    // =================================================================================
                    // Cleanup
                    RPMDataAdapter.Dispose();

                    RPMConnection.Close();
                    RPMConnection.Dispose();

                    PAConnection.Close();
                    PAConnection.Dispose();

                    lblStatus.Text = "Idle"; lblStatus.Refresh();
                }

                #endregion

                #region Finding deleted products

                // Set Checked to false for all products
                //lblStatus.Text = "Setting Checked = false for all existing products"; lblStatus.Refresh();
                //Functions.ExecuteNonQuery(CheckedQuery, _PAConnectionString);

                // Get the UPI's for all products
                lblStatus.Text = "Retrieving all Active Core Pharmacy Assist UPI's"; lblStatus.Refresh();
                DataSet AllPAProducts = Functions.Execute("SELECT DISTINCT UPI, Price, ID, Name FROM Product WHERE Approved = 1 AND CoreProduct = 1", txtDestinationConnectionString.Text);

                // Get the corresponding RPM products
                lblStatus.Text = "Retrieving all RPM UPI's"; lblStatus.Refresh();
                DataSet AllRPMProducts = Functions.Execute("SELECT DISTINCT ISNULL(p.CosmosUPI,0) AS UPI FROM Product p INNER JOIN [Product].[PricingCurrent] pp ON p.ProductID = pp.ProductID LEFT JOIN StoreProducts s ON s.ProductID = p.ProductID WHERE pp.zoneid = 17 AND (s.SOH >0 OR s.SOO >0 OR datediff(day,cast(lastsold as date), getdate()) < 365) ORDER BY UPI", txtSourceConnectionString.Text);

                // Finally get the list of all missing products
                // This is the list of products not in RPM, which can be 'deleted'
                lblStatus.Text = "Finding missing products"; lblStatus.Refresh();
                //var MatchedProducts = from PharmacyAssistTable in AllPAProducts.Tables[0].AsEnumerable()
                //                      join RPMTable in AllRPMProducts.Tables[0].AsEnumerable() 
                //                          on (int)PharmacyAssistTable["UPI"] equals (int)RPMTable["UPI"]
                //                      select PharmacyAssistTable["UPI"];

                //MatchedProducts = MatchedProducts.AsEnumerable();


                var MissingProducts = from PharmacyAssistTable in AllPAProducts.Tables[0].AsEnumerable()
                                      join RPMTable in AllRPMProducts.Tables[0].AsEnumerable()
                                          on (int)PharmacyAssistTable["UPI"] equals (int)RPMTable["UPI"] into Missing
                                      from Check in Missing.DefaultIfEmpty()
                                      where Check == null
                                      select new
                                      {
                                          UPI = PharmacyAssistTable["UPI"],
                                          OldPrice = PharmacyAssistTable["Price"],
                                          //OldRecommendedPrice = PharmacyAssistTable["RecommendedPrice"],
                                          ID = PharmacyAssistTable["ID"],
                                          Name = PharmacyAssistTable["Name"]
                                      };

                MissingProducts = MissingProducts.AsEnumerable();

                StringBuilder UPIList = new StringBuilder();

                foreach (var Row in MissingProducts)
                {
                    UPIList.Append(Row.UPI.ToString() + ", ");

                    // Build the statements for the audit table

                    if (Row.OldPrice.ToString() != "0.00")
                    {
                        AuditStatement = string.Format("INSERT INTO Audit (Description, TableName, FieldName, RecordID, Username, PreviousValue, NewValue, ApplicationName) VALUES ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}')"
                                                  , "Update price or recommended price from RPM", "Product", "Price", Row.ID, "-", Row.OldPrice, "0.00", "RPM Import"
                                                  );
                        Functions.ExecuteNonQuery(AuditStatement, txtDestinationConnectionString.Text);
                    }

                    AuditStatement = string.Format("INSERT INTO Audit (Description, TableName, FieldName, RecordID, Username, PreviousValue, NewValue, ApplicationName) VALUES ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}')"
                                              , "Deactivate", "Product", "Approved", Row.ID, "-", "1", "0", "RPM Import"
                                              );
                    Functions.ExecuteNonQuery(AuditStatement, txtDestinationConnectionString.Text);

                    AuditStatement = string.Format("INSERT INTO Audit (Description, TableName, FieldName, RecordID, Username, PreviousValue, NewValue, ApplicationName) VALUES ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}')"
                                              , "Reset Core", "Product", "CoreProduct", Row.ID, "-", "1", "0", "RPM Import"
                                              );
                    Functions.ExecuteNonQuery(AuditStatement, txtDestinationConnectionString.Text);

                    AuditStatement = string.Format("INSERT INTO Audit (Description, TableName, FieldName, RecordID, Username, PreviousValue, NewValue, ApplicationName) VALUES ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}')"
                                              , "Modified Name", "Product", "Name", Row.ID, "-", Row.Name.ToString().Replace("'", "''"), Row.Name.ToString().Replace("'", "''") + " (DELETED)", "RPM Import"
                                              );
                    Functions.ExecuteNonQuery(AuditStatement, txtDestinationConnectionString.Text);
                }

                string List = UPIList.ToString();

                // If there are any deleted items...
                if (List.Length > 0)
                {
                    List = List.Substring(0, List.Length - 2);

                    string UpdateQuery = "UPDATE Product SET Price = 0.00, RecommendedPrice = 0.00, CoreProduct=0, Approved = 0, Name = Name + ' (DELETED)' WHERE UPI IN (" + List + ")";

                    // Update each product not in RPM, setting active, core, price and RecommendedPrice = 0
                    lblStatus.Text = "Updating all missing RPM products to 'DELETED'"; lblStatus.Refresh();
                    Functions.ExecuteNonQuery(UpdateQuery, txtDestinationConnectionString.Text);
                }
                #endregion

            }
            catch (Exception ex)
            {
                Console.Write("Error! " + ex.Message);
            }

            lblStatus.Text = "Idle"; lblStatus.Refresh();

            Cursor.Current = Cursors.Default;
        }

        private void Audit(string Description, string TableName, string FieldName, int RecordID, string Username, string PreviousValue, string NewValue, string ApplicationName, bool OverrideOptions)
        {

            string Query = "INSERT INTO audit (Description, TableName, FieldName, RecordID, Username, PreviousValue, NewValue, ApplicationName) VALUES ('" + Description + "', '" + TableName + "', '" + FieldName + "'," + RecordID + ",'" + Username + "','" + PreviousValue + "','" + NewValue + "','" + ApplicationName + "' )";

            if (NewValue != PreviousValue) Core.SQL.Functions.Execute(Query, _PAConnectionString);
        }
    }
}
