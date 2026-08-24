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
    public partial class frmCatalogDetail001 : Form
    {
        //private int _CurrentPageRecordFinish = 0;
        private int _CurrentPageRecordStart = 1;
        private int _DataPageNumber = 0;
        private int _DataPageSize = 0;
        private int _RecordCount = 0;

        public int CatalogID { get; set; }
        
        public frmCatalogDetail001()
        {
            InitializeComponent();
        }

        private void frmCatalogDetail_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);
            
            GetCatalogProducts();
        }

        private void GetCatalogProducts()
        {
            // Get the list of products that are already in this catalog

            lblStatus.Text = "Loading catalog items...";
            this.Refresh();

            string Query = "select product.UPI, product.Name, productcatalog.price AS CatalogPrice, product.price as EverydayPrice, product.RecommendedPrice from productcatalog inner join product on product.id = productcatalog.productid where catalogid = " + CatalogID;

            Cursor.Current = Cursors.WaitCursor;

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            dgvSelection.DataSource = Data;

            lblStatus.Text = Data.Tables[0].Rows.Count.ToString() +  " products in this catalog.";
            this.Refresh();

            Cursor.Current = Cursors.Default;
        }

        private void PageData(string SearchString)
        {
            StringBuilder OutsideWhereClause = new StringBuilder();
            StringBuilder InsideWhereClause = new StringBuilder();
            string[] OrderByFieldNames = { "Product.Name" };
            StringBuilder Joins = new StringBuilder();
            bool EnablePaging = false;

            //Console.WriteLine("Reading data... (page {0})", _DataPageNumber.ToString());

            lblStatus.Text = string.Format("Reading data... (page {0})", _DataPageNumber.ToString());
            this.Refresh();

            #region Compose SQL statement

            string[] Fields = { 
                               "Product.ID", "Product.UPI", "Product.Name", 
                               "Image = CASE ISNULL(Product.Image,'') WHEN '' THEN CAST(0 As Bit) ELSE CAST (1 as Bit) END", 
                               "Description = CASE ISNULL(Product.Description,'') WHEN '' THEN CAST(0 As Bit) ELSE CAST (1 as Bit) END",
                               "Product.Recommended", "Schedule.Name AS ScheduleName", 
                               "Product.Approved AS Active", "Product.PrivateLabelUPI", "Product.Price", 
                               "Product.RecommendedPrice", "Product.InStoreOnly", "Product.Limit", "Product.ShelfTalker"
                               //"Brand.Name AS BrandName", "Category.Name AS CategoryName", "EndUse.Name as EndUseName","Ingredient.Name AS IngredientName",
                               //"Condition.Name AS ConditionName"
                              };

            #endregion

            // Different behaviour depending upon search or not

            #region Not searching

            if (SearchString.Trim().Length == 0)
            {
                #region Handle approval

                // Allow the user to specify Active as 3 states (yes, no and both)

                //#region BOTH Approved Yes and No (ie all)

                //if (yesToolStripMenuItem.Checked && noToolStripMenuItem.Checked)
                //{
                //    // Exclude nothing

                    OutsideWhereClause.Append("Approved = 1");
                    OutsideWhereClause.Append(" OR Approved = 0");
                //}

                //#endregion

                //#region Approved = Yes

                //else if (yesToolStripMenuItem.Checked)
                //{
                //    OutsideWhereClause.Append("Approved = 1");
                //}

                //#endregion

                //#region Approved = No

                //else if (noToolStripMenuItem.Checked)
                //{
                //    OutsideWhereClause.Append("Approved = 0");
                //}
                //#endregion

                #endregion
            }

            #endregion

            #region Searching

            else
            {

                #region Set predicate default values

                // Searching - display nothing by default

                #endregion

                #region Handle approval

                // Allow the user to specify Approved as 3 states (yes, no and both)

                //#region BOTH Approved Yes and No (ie all)

                //if (yesToolStripMenuItem.Checked && noToolStripMenuItem.Checked)
                //{
                //    // Exclude nothing
                    OutsideWhereClause.Append("Approved = 1"); //Inner = Inner.Or(p => p.Approved == true);
                    OutsideWhereClause.Append(" OR Approved = 0"); //Inner = Inner.Or(p => p.Approved == false);
                //}

                //#endregion

                //#region Approved = Yes

                //else if (yesToolStripMenuItem.Checked)
                //{
                //    OutsideWhereClause.Append("Approved = 1"); //product_predicate = product_predicate.And(p => p.Approved == true);
                //}

                //#endregion

                //#region Approved = No

                //else if (noToolStripMenuItem.Checked)
                //{
                //    OutsideWhereClause.Append("Approved = 0"); //product_predicate = product_predicate.And(p => p.Approved == false);
                //}

                //#endregion

                #endregion

                // Put together the final predicate
            }

            #endregion

            InsideWhereClause.Append("Product.Name like '%" + SearchString + "%' OR ");
            InsideWhereClause.Append("Product.UPI like '%" + SearchString + "%' OR ");
            InsideWhereClause.Append("Brand.Name like '%" + SearchString + "%' OR ");
            InsideWhereClause.Append("Category.Name like '%" + SearchString + "%' OR ");
            InsideWhereClause.Append("Schedule.Name like '%" + SearchString + "%' OR ");
            InsideWhereClause.Append("Condition.Name like '%" + SearchString + "%' OR ");
            InsideWhereClause.Append("Product.Description like '%" + SearchString + "%' OR ");
            InsideWhereClause.Append("Ingredient.Name like '%" + SearchString + "%'");

            // Joins...
            // Brand
            Joins.Append("LEFT OUTER JOIN Brand ON Product.BrandID = Brand.ID ");

            //Category
            Joins.Append("LEFT OUTER JOIN ProductCategory ON Product.ID = ProductCategory.ProductID ");
            Joins.Append("LEFT OUTER JOIN Category ON ProductCategory.CategoryID = Category.ID ");

            // End Use
            Joins.Append("LEFT OUTER JOIN ProductEndUse ON Product.ID = ProductEndUse.ProductID ");
            Joins.Append("LEFT OUTER JOIN EndUse ON ProductEndUse.EndUseID = EndUse.ID ");

            // Ingredient
            Joins.Append("LEFT OUTER JOIN ProductIngredient ON Product.ID = ProductIngredient.ProductID ");
            Joins.Append("LEFT OUTER JOIN Ingredient ON ProductIngredient.IngredientID = Ingredient.ID ");

            // Schedule
            Joins.Append("LEFT OUTER JOIN Schedule ON Product.ScheduleID = Schedule.ID ");

            // Condition
            Joins.Append("LEFT OUTER JOIN ProductCondition ON Product.ID = ProductCondition.ProductID ");
            Joins.Append("LEFT OUTER JOIN Condition ON ProductCondition.ConditionID = Condition.ID ");

            Cursor.Current = Cursors.WaitCursor;

            // Build query
            string InsideClause = InsideWhereClause.ToString();
            if (InsideClause.EndsWith(" OR "))
            {
                InsideClause = InsideClause.Substring(0, InsideClause.Length - 3);
            }
            string Query = Core.SQL.Functions.BuildQuery("Product", Fields, OrderByFieldNames, OutsideWhereClause.ToString(), InsideClause, Joins.ToString(), EnablePaging);

            // Get the total record count
            try
            {
                _RecordCount = Core.SQL.Functions.Count(Query, Global.SqlConnectionString);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error reading data";
                Global.Common.Logging.WriteErrorEvent(String.Format("Main form (PageData) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                this.Refresh();
            }

            Global.Common.Logging.WriteDebugEvent(String.Format("Main Page Query: {0} {1}", "SELECT TOP (100) PERCENT", Query));

            // Now get data
            try
            {
                DataTable Products = Core.SQL.Functions.PageData("Products", Query, _CurrentPageRecordStart, _DataPageSize, Global.SqlConnectionString).Tables[0];

                if (Products.Rows.Count > 0)
                {
                    dgvProducts.DataSource = Products;
                    SetDataGridViewColumnSizes();
                    //EnablePagingButtons();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error reading data";
                Global.Common.Logging.WriteErrorEvent(String.Format("Main form (PageData) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                this.Refresh();
            }

            lblStatus.Text = "Idle";
            this.Refresh();

            Cursor.Current = Cursors.Default;
        }

        private void SetDataGridViewColumnSizes()
        {
            dgvProducts.Columns[0].Width = 50; // ID
            dgvProducts.Columns[1].Width = 50; // UPI
            dgvProducts.Columns[2].Width = 370; // Name
            dgvProducts.Columns[3].Width = 50; // Image
            dgvProducts.Columns[4].Width = 50; // Description
            dgvProducts.Columns[5].Width = 50; // Recommended
            dgvProducts.Columns[6].Width = 150; // Schedule
            dgvProducts.Columns[7].Width = 50; // Approved
            dgvProducts.Columns[8].Width = 50; // Private Label UPI
            dgvProducts.Columns[9].Width = 50; // Price
            dgvProducts.Columns[10].Width = 50; // Recommended Price
            dgvProducts.Columns[11].Width = 50; // Store Only
            dgvProducts.Columns[12].Width = 30; // Limit
            dgvProducts.Columns[13].Width = 50; // Shelf Talker

            //dgvProducts.Columns[14].Width = 80; // Brand Name
            //dgvProducts.Columns[15].Width = 80; // Category Name
            //dgvProducts.Columns[16].Width = 80; // End Use Name
            //dgvProducts.Columns[17].Width = 80; // Ingredient Name
            //dgvProducts.Columns[18].Width = 80; // Condition Name
            //dgvProducts.Columns[19].Width = 30; // Row number

            // Set first and last Columns as not visible
            dgvProducts.Columns[0].Visible = false;
            dgvProducts.Columns[dgvProducts.Columns.Count - 1].Visible = false;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //string Query = "";
            
            //if (CatalogID > 0)
            //{
            //    Query = "UPDATE catalog SET Name = '" + txtName.Text.Replace("'", "''") + "', StartDate = '" + datStart.Value.ToString("yyyyMMdd") + "', EndDate = '" + datEnd.Value.ToString("yyyyMMdd") + "' WHERE ID = " + CatalogID.ToString();
            //}
            //else
            //{
            //    Query = "INSERT INTO catalog (Name, StartDate, EndDate) VALUES ('" + txtName.Text.Replace("'", "''") + "','" + datStart.Value.ToString("yyyyMMdd") + "', '" + datEnd.Value.ToString("yyyyMMdd") + "')";
            //}

            //Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCatalogDetail001_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }
    }
}
