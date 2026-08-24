using Core.FileTransfer;
using i00SpellCheck;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace PharmacyAssist
{
    public partial class frmProductDetail : Form
    {
        private delegate void FormCloser();

        private bool _FormShown = false;
        private frmMain _ParentForm = null;
        private Product _Product = new Product();
        public int _ProductID = 0;
        private bool _ProductSaved = false;
        private BackgroundWorker _SaveWorker = new BackgroundWorker();
        private bool _SaveAndClose = false;

        public frmProductDetail(frmMain Parent, int ID)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvAudit,
                new object[] { true });

            _ProductID = ID;
            _ParentForm = Parent;

            // Enable spellcheck
            if (Properties.Settings.Default.EnableSpellCheck)
            {
                this.EnableControlExtensions();
                this.txtComment.EnableSpellCheck();
                this.txtCustomString1.EnableSpellCheck();
                this.txtCustomString2.EnableSpellCheck();
                this.txtCustomString3.EnableSpellCheck();
                this.txtCustomString4.EnableSpellCheck();
                this.txtName.EnableSpellCheck();
                this.txtUOM.EnableSpellCheck();
                this.lstBrand.EnableSpellCheck();
                this.lstCategories.EnableSpellCheck();
                this.lstConditions.EnableSpellCheck();
                this.lstEndUses.EnableSpellCheck();
                this.lstIngredient.EnableSpellCheck();
                this.HTMLEditor.EnableSpellCheck();
            }
        }

        private void BrowseAndUploadImage()
        {
            OpenFileDialog Browse = new OpenFileDialog();

            Browse.AutoUpgradeEnabled = true;
            Browse.Filter = "JPG files (*.jpg)|*.jpg|JPG files (*.jpeg)|*.jpeg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            Browse.FilterIndex = 1;
            Browse.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string SourceFilename = "";
            string SourceFolder = "";
            string Extension = "";

            if (Browse.ShowDialog() == DialogResult.OK)
            {
                SourceFolder = System.IO.Path.GetDirectoryName(Browse.FileName);
                SourceFilename = System.IO.Path.GetFileNameWithoutExtension(Browse.SafeFileName);
                Extension = System.IO.Path.GetExtension(Browse.SafeFileName);
                StartUpload(SourceFolder, SourceFilename, Extension, Properties.Settings.Default.AlwaysDownloadImages);
            }

            if (_Product.Image == null || Convert.ToString(_Product.Image).Trim().Length == 0)
            {
                tabImage.ImageIndex = 5;
            }
            else
            {
                tabImage.ImageIndex = -1;
                GetProductImage(Properties.Settings.Default.AlwaysDownloadImages);
            }
        }

        private void btnBrowseForImage_Click(object sender, EventArgs e)
        {
            BrowseAndUploadImage();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditBrand_Click(object sender, EventArgs e)
        {
            OpenItemSelectionForm(SingleItemSelection: true, ThisProduct: _Product, ListDisplayName: "Brand");
        }

        private void btnEditCatalogs_Click(object sender, EventArgs e)
        {
            if (Global.Permissions.Contains("Read Catalog"))
            {
                string SelectQuery = "SELECT DISTINCT p.ID, p.Name + ' ($' + CAST(pc.Price AS VARCHAR) + ')' AS Name FROM Catalog c LEFT JOIN ProductCatalog pc ON c.RPMID = pc.CatalogID LEFT JOIN Product p ON pc.ProductID = p.ID WHERE c.ID =" + Global.LastCatalogID;

                frmLinkedItems006 LinkedProducts = new frmLinkedItems006();

                LinkedProducts.ProductSelectQuery = SelectQuery;
                LinkedProducts.ItemName = "Product";

                LinkedProducts.Show();
            }
        }

        private void btnEditCategories_Click(object sender, EventArgs e)
        {
            OpenItemSelectionForm(SingleItemSelection: false, ThisProduct: _Product, ListDisplayName: "Categories");
        }

        private void btnEditConditions_Click(object sender, EventArgs e)
        {
            OpenItemSelectionForm(SingleItemSelection: false, ThisProduct: _Product, ListDisplayName: "Conditions");
        }

        private void btnEditEndUses_Click(object sender, EventArgs e)
        {
            OpenItemSelectionForm(SingleItemSelection: false, ThisProduct: _Product, ListDisplayName: "End Uses");
        }

        private void btnEditIngredient_Click(object sender, EventArgs e)
        {
            OpenItemSelectionForm(SingleItemSelection: true, ThisProduct: _Product, ListDisplayName: "Active Ingredient");
        }

        private void btnEditPackSize_Click(object sender, EventArgs e)
        {
            OpenItemSelectionForm(SingleItemSelection: true, ThisProduct: _Product, ListDisplayName: "Unit Of Measure");
        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            OpenItemSelectionForm(SingleItemSelection: true, ThisProduct: _Product, ListDisplayName: "Schedule");
        }

        private void btnGoogleSearch_Click(object sender, EventArgs e)
        {
            Global.PerformGoogleWebSearch(txtName.Text);
        }

        private void btnGoogleSearch2_Click(object sender, EventArgs e)
        {
            Global.PerformGoogleWebSearch(txtName.Text);
        }

        private void btnImageSearch_Click(object sender, EventArgs e)
        {
            Global.PerformGoogleImageSearch(txtName.Text);
        }

        private void btnLoadAuditTrail_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dgvAudit.Rows.Clear();

            string Query = "SELECT Timestamp, Username, FieldName AS Field, PreviousValue AS Previous, NewValue AS New, ApplicationName AS Application FROM Audit WHERE TableName = 'Product' AND RecordID = " + _ProductID + " ORDER BY Timestamp DESC";

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            if (Data.Tables[0].Rows.Count > 0)
            {
                dgvAudit.Columns.Clear();
                dgvAudit.AutoGenerateColumns = true;
                dgvAudit.DataSource = Data.Tables[0];

                dgvAudit.Columns[0].Width = 150;
                dgvAudit.Columns[1].Width = 80;
                dgvAudit.Columns[2].Width = 145;
                dgvAudit.Columns[3].Width = 55;
                dgvAudit.Columns[4].Width = 55;
                dgvAudit.Columns[5].Width = 120;
            }

            Cursor.Current = Cursors.Default;

        }

        private void btnNHS_Click(object sender, EventArgs e)
        {
            PerformNHSWebSearch(txtName.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProductDetails(true);
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            // Get local path variables
            string ImagePath = picProduct.ImageLocation;
            string ImageFolder = System.IO.Path.GetDirectoryName(ImagePath);
            string ImageFilename = System.IO.Path.GetFileNameWithoutExtension(ImagePath);
            string ImageExtension = System.IO.Path.GetExtension(ImagePath);

            // Upload
            StartUpload(ImageFolder, ImageFilename, ImageExtension, true);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveAndClose = true;
            
            SetProductValues();
            
            SaveProduct();
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            _SaveAndClose = false;
            
            SetProductValues();

            SaveProduct();
        }

        private void btnWebMDSearch_Click(object sender, EventArgs e)
        {
            Global.PerformWebMDSearch(lstIngredient.SelectedItem.ToString());
        }

        private void btnWebMDSearchCondition_Click(object sender, EventArgs e)
        {
            Global.PerformWebMDSearch(lstConditions.SelectedItem.ToString());
        }

        private void btnWikipediaSearch_Click(object sender, EventArgs e)
        {
            Global.PerformWikipediaWebSearch(txtName.Text);
        }

        private void CheckImageSize()
        {
            if (picProduct.Image != null)
            {
                lblImageNote.Visible = (picProduct.Image.Height > picProduct.Height || picProduct.Image.Width > picProduct.Width);
                picThumbnail.Visible = (picProduct.Image.Height > picProduct.Height || picProduct.Image.Width > picProduct.Width);
            }
        }

        private void DoClose()
        {
            if (_SaveAndClose)
            {
                if (this.InvokeRequired)
                {
                    Console.WriteLine("Invoke Required");
                    FormCloser f = new FormCloser(DoClose);
                    this.Invoke(f);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void DoSave()
        {
            Console.WriteLine("Saving Product");
            // This will be called from the BackgroundWorker thread
            
            Global.Audit("Update", "Product", "Approved", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Approved.Get(true).ToString(), _Product.Approved.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "BrandID", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.BrandID.Get(true).ToString(), _Product.BrandID.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Comment", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Comment.Get(true).ToString().Replace("'", "''"), _Product.Comment.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "CoreProduct", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.CoreProduct.Get(true).ToString().Replace("'", "''"), _Product.CoreProduct.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "CustomString1", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.CustomString1.Get(true).ToString().Replace("'", "''"), _Product.CustomString1.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "CustomString2", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.CustomString2.Get(true).ToString().Replace("'", "''"), _Product.CustomString2.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "CustomString3", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.CustomString3.Get(true).ToString().Replace("'", "''"), _Product.CustomString3.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "CustomString4", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.CustomString4.Get(true).ToString().Replace("'", "''"), _Product.CustomString4.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Description", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Description.Get(true).ToString().Replace("'", "''"), _Product.Description.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Image", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Image.Get(true).ToString().Replace("'", "''"), _Product.Image.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "IngredientID", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.IngredientID.Get(true).ToString().Replace("'", "''"), _Product.IngredientID.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "InStoreOnly", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.InStoreOnly.Get(true).ToString(), _Product.InStoreOnly.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Limit", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Limit.Get(true).ToString(), _Product.Limit.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "MeasureID", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.MeasureID.Get(true).ToString(), _Product.MeasureID.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "MeasureValue", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.MeasureValue.Get(true).ToString(), _Product.MeasureValue.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Name", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Name.Get(true).ToString().Replace("'", "''"), _Product.Name.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Price", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Price.Get(true).ToString(), _Product.Price.Get().ToString().Replace("'", "''"), Application.ProductName, true);
            Global.Audit("Update", "Product", "PrivateLabelUPI", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.PrivateLabelUPI.Get(true).ToString(), _Product.PrivateLabelUPI.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Rank", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Rank.Get(true).ToString(), _Product.Rank.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Recommended", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Recommended.Get(true).ToString(), _Product.Recommended.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "RecommendedPrice", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.RecommendedPrice.Get(true).ToString(), _Product.RecommendedPrice.Get().ToString().Replace("'", "''"), Application.ProductName, true);
            Global.Audit("Update", "Product", "ScheduleID", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.ScheduleID.Get(true).ToString(), _Product.ScheduleID.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "ShelfTalker", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.ShelfTalker.Get(true).ToString(), _Product.ShelfTalker.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "Thumbnail", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.Thumbnail.Get(true).ToString(), _Product.Thumbnail.Get().ToString().Replace("'", "''"), Application.ProductName, false);
            Global.Audit("Update", "Product", "UPI", (int)_Product.ID.Get(), Global.Username.Replace("'", "''"), _Product.UPI.Get(true).ToString(), _Product.UPI.Get().ToString().Replace("'", "''"), Application.ProductName, false);

            _Product.CurrentUsername.Set("");
            _Product.Save(Global.SqlConnectionString);

            _ProductSaved = true;

            Console.WriteLine("Product Saved");

            DoClose();
        }

        private void frmProductDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Form Closing");
            
            // If the user closes the window by clicking the window close button, clear the current username and save all details
            if (e.CloseReason == CloseReason.UserClosing)
            {
                try
                {                    
                    Properties.Settings.Default.ProductDetailPosition = new Point(this.Left, this.Top);
                    Properties.Settings.Default.ProductDetailSize = new Point(this.Width, this.Height);
                    Properties.Settings.Default.Save();

                    _SaveAndClose = true;

                    Cursor.Current = Cursors.WaitCursor;

                    if (!_ProductSaved) DoSave();
                    
                    //_Product.CurrentUsername.Set("");
                    //_Product.Save(Global.SqlConnectionString);

                    //if (_ParentForm != null) _ParentForm.RefreshData();
                    Cursor.Current = Cursors.Default;

                    Console.WriteLine("User Closing");
                }
                catch (Exception ex)
                {
                    Global.Common.Logging.WriteErrorEvent(String.Format("Product detail form (FormClosing) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                }
            }
            Global.RemoveFormFromList(this);
        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            Global.AddFormToList(this);
            
            // Note:  There is no bounds checking in the following code, 
            // so if the form is positioned on a monitor that is
            // subsequently removed, the form will not be accessible
            if (Properties.Settings.Default.ProductDetailSize.X != 0)
            {
                this.Width = Properties.Settings.Default.ProductDetailSize.X;
                this.Height = Properties.Settings.Default.ProductDetailSize.Y;
            }

            if (Properties.Settings.Default.ProductDetailPosition.X != 0)
            {
                this.Left = Properties.Settings.Default.ProductDetailPosition.X;
                this.Top = Properties.Settings.Default.ProductDetailPosition.Y;
            }

            if (Properties.Settings.Default.ProductDetailFormPanel2Width != 0)
                splitContainer.SplitterDistance = splitContainer.Width - Properties.Settings.Default.ProductDetailFormPanel2Width;

            this.Show();
            this.Refresh();
            
            LoadProductDetails(false);

            btnEditConditions.Enabled = (!Properties.Settings.Default.SaveConditionsAgainstActiveIngredientOnly && Global.Permissions.Contains("Write Product"));

            // Security
            if (Global.Permissions.Contains("Write Product Price"))
            {
                mtbOurPrice.Enabled = true;
            }

            if (Global.Permissions.Contains("Write Product RRP"))
            {
                mtbWhyPrice.Enabled = true;
            }

            if (Global.Permissions.Contains("Write Catalog Price"))
            {
                txtCatalogPrice.Enabled = true;
                btnEditCatalogs.Enabled = true;
            }

            if (Global.Permissions.Contains("Write Product"))
            {
                txtUPI.Enabled = true;
                txtPLUPI.Enabled = true;
                txtName.Enabled = true;
                txtUOM.Enabled = true;
                txtPackSize.Enabled = true;
                btnEditPackSize.Enabled = true;
                chkApproved.Enabled = true;
                btnEditPackSize.Enabled = true;
                btnEditSchedule.Enabled = true;
                txtLimit.Enabled = true;
                txtRank.Enabled = true;
                chkShelfTalker.Enabled = true;
                chkInStoreOnly.Enabled = true;
                chkRecommended.Enabled = true;
                txtComment.Enabled = true;
                txtCustomString1.Enabled = true;
                txtCustomString2.Enabled = true;
                txtCustomString3.Enabled = true;
                txtCustomString4.Enabled = true;
                chkCore.Enabled = true;
                lstSchedule.Enabled = true;
                lstIngredient.Enabled = true;
                btnEditIngredient.Enabled = true;
                lstBrand.Enabled = true;
                btnEditBrand.Enabled = true;
                lstCategories.Enabled = true;
                btnEditCategories.Enabled = true;
                lstConditions.Enabled = true;
                if (!Properties.Settings.Default.SaveConditionsAgainstActiveIngredientOnly) btnEditConditions.Enabled = true;
                lstEndUses.Enabled = true;
                btnEditEndUses.Enabled = true;
                //lstNotRecommendedFor.Enabled = true;
                //btnEditNotRecommendedFor.Enabled = true;
                btnBrowseForImage.Enabled = true;
                HTMLEditor.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Audit"))
            {
                btnLoadAuditTrail.Enabled = true;
            }
        }

        private void frmProductDetail_Shown(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.ProductDetailFormPanel2Width != 0)
            //    splitContainer.SplitterDistance = splitContainer.Width - Properties.Settings.Default.ProductDetailFormPanel2Width;

            _FormShown = true;
        }

        private void GetBrand(int BrandID)
        {
            lstBrand.Items.Clear();
            lstBrand.BeginUpdate();
            
            if (BrandID != 0)
            {
                string Query = "SELECT Brand.Name from Brand WHERE Brand.ID = " + BrandID.ToString();

                lstBrand.Items.Add((string)Core.SQL.Functions.GetFieldFromDataRow(
                                           Core.SQL.Functions.GetDataRowFromDataset(
                                           Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0));
            }

            lstBrand.EndUpdate();
        }

        private void GetCatalogPrice()
        {
            string Query = "select dbo.currentprice(" + _ProductID.ToString() + ") AS Price, dbo.currentpriceSource(" + _ProductID.ToString() + ") AS Source";
            DataRow Row = Core.SQL.Functions.GetDataRowFromDataset(Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0);

            if (Row != null)
            {
                if (Row[1].ToString() == "Catalog")
                {
                    txtCatalogPrice.Text = Convert.ToDecimal(Row[0]).ToString("F2");  // Fixed to 2 decimal digits
                    //txtCatalogPrice.Enabled = true;  // <<-- This is dependant upon security
                }
            }

        }

        private void GetCategories(int ProductID)
        {
            DataSet Data = null;

            lstCategories.Items.Clear();

            if (ProductID != 0)
            {
                string Query = "select DISTINCT category.name from category left join productcategory on productcategory.categoryid = category.id left join product on productcategory.productid = product.id where product.ID = " + ProductID.ToString();

                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            }

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                lstCategories.Items.Add(Row[0].ToString());
            }
        }

        private void GetConditions(int ProductID)
        {
            DataSet Data = null;

            lstConditions.Items.Clear();

            // Retrieve Conditions specifically for this Product

            if (ProductID != 0)
            {
                string Query = "select DISTINCT condition.name, condition.id from condition left join productcondition on productcondition.conditionid = condition.id left join product on productcondition.productid = product.id where product.ID = " + ProductID.ToString();

                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            }

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem Item = new ListItem();

                Item.ID = (int)Row[1];
                Item.Name = Row[0].ToString();

                lstConditions.Items.Add(Item);
            }

            // Retrieve Conditions the associated active ingredient will treat
            if ((int)_Product.IngredientID.Get() > 0)
            {
                int IngredientID = (int)_Product.IngredientID.Get();
                string Query = "SELECT DISTINCT Condition.Name AS ConditionName, Condition.ID AS ConditionID, Ingredient.Name AS IngredientName, Ingredient.ID AS IngredientID FROM Condition INNER JOIN ConditionIngredient ON ConditionIngredient.ConditionID = Condition.ID INNER JOIN Ingredient ON ConditionIngredient.IngredientID = Ingredient.ID WHERE ingredient.ID = " + IngredientID.ToString();

                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                foreach (DataRow Row in Data.Tables[0].Rows)
                {
                    ListItem Item = new ListItem();

                    Item.ID = (int)Row[1];
                    Item.Name = Row[0].ToString();

                    if (lstConditions.Items.Contains(Item))
                    {
                        Item.Name += (" (from Active Ingredient)");
                    }

                    lstConditions.Items.Add(Item);
                }
            }
        }

        private Product GetDetails(int ProductID)
        {
            Product ThisProduct = new Product();

            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                ThisProduct = ThisProduct.Load(ProductID, Global.SqlConnectionString);

                Cursor.Current = Cursors.Default;

                return ThisProduct;
            }
            catch (Exception ex)
            {
                Global.Common.Logging.WriteErrorEvent(String.Format("Error in GetDetails. ID = {0} (frmProductDetails): {1}.\nThe message is: {2}", ProductID.ToString(), ex.StackTrace, ex.Message));
            }

            return null;
        }

        private void GetEndUses(int ProductID)
        {
            DataSet Data = null;

            lstEndUses.Items.Clear();

            if (ProductID != 0)
            {
                string Query = "select DISTINCT enduse.name from enduse left join productenduse on productenduse.enduseid = enduse.id left join product on productenduse.productid = product.id where product.ID = " + ProductID.ToString();

                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            }

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                lstEndUses.Items.Add(Row[0].ToString());
            }
        }

        private void GetIngredient(int IngredientID)
        {
            lstIngredient.Items.Clear();

            if (IngredientID != 0)
            {
                string Query = "SELECT Ingredient.Name from Ingredient WHERE Ingredient.ID = " + IngredientID.ToString();

                lstIngredient.Items.Add((string)Core.SQL.Functions.GetFieldFromDataRow(
                                           Core.SQL.Functions.GetDataRowFromDataset(
                                           Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0));
            }
        }

        private void GetPacksize(int MeasureID)
        {
            txtPackSize.Text = "";

            if (MeasureID != 0)
            {
                string Query = "SELECT UnitOfMeasure.Name FROM UnitOfMeasure WHERE UnitOfMeasure.ID = " + MeasureID.ToString();

                txtPackSize.Text = (string)Core.SQL.Functions.GetFieldFromDataRow(
                                           Core.SQL.Functions.GetDataRowFromDataset(
                                           Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0);
            }
        }

        private void GetProductImage(bool OverwriteLocalImage)
        {
            // Check if the image is already present
            string LocalFolder = Application.UserAppDataPath;
            string Filename = Convert.ToString(_Product.Image).ToLower().Replace("..", "").Replace("/productimages/", "");
            bool FilePresent = File.Exists(System.IO.Path.Combine(LocalFolder, Filename));

            if (!FilePresent || OverwriteLocalImage)
            {
                BackgroundWorker Worker = new BackgroundWorker();

                Worker.DoWork += Worker_DoWork;
                Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

                Worker.RunWorkerAsync();
            }
            else
            {
                picProduct.ImageLocation = System.IO.Path.Combine(LocalFolder, Filename);
                picThumbnail.ImageLocation = System.IO.Path.Combine(LocalFolder, Filename);
            }
        }

        private void GetRemoteImage()
        {
            // Load remote image

            string LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            //TODO:  Get Product Image path
            string Filename = _Product.Image.Get().ToString().ToLower().Replace("..", "").Replace("/productimages/", "");
            FTP Ftp = new FTP();
            Ftp.UseCompression = false;

            Ftp.RemoteHost = Properties.Settings.Default.FTPHost;
            Ftp.RemoteUsername = Properties.Settings.Default.FTPUsername;
            Ftp.RemotePassword = Properties.Settings.Default.FTPPassword;

            try
            {
                Ftp.Login();
                Ftp.Download("/productimages/" + Filename, System.IO.Path.Combine(LocalFolder, Filename));

                picProduct.ImageLocation = System.IO.Path.Combine(LocalFolder, Filename);
                picThumbnail.ImageLocation = System.IO.Path.Combine(LocalFolder, Filename);
            }
            catch (Exception ex)
            {
                Global.Common.Logging.WriteErrorEvent(String.Format("Product detail form (GetRemoteImage) - {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
            }
        }

        private void GetSchedule(int ScheduleID)
        {
            lstSchedule.Items.Clear();

            if (ScheduleID != 0)
            {
                string Query = "SELECT Schedule.Name from Schedule WHERE Schedule.ID = " + ScheduleID.ToString();

                lstSchedule.Items.Add((string)Core.SQL.Functions.GetFieldFromDataRow(
                                           Core.SQL.Functions.GetDataRowFromDataset(
                                           Core.SQL.Functions.Execute(Query, Global.SqlConnectionString), 0, 0), 0));
            }
        }

        public void LoadProductDetails(bool IsRefresh)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.Show();
            this.Refresh();

            _Product = GetDetails(_ProductID);

            try
            {
                if (_Product != null)
                {
                    txtName.Text = Convert.ToString(_Product.Name.Get());
                    txtImagePath.Text = Convert.ToString(_Product.Image.Get());
                    txtLimit.Text = Convert.ToString(_Product.Limit.Get());
                    txtRank.Text = Convert.ToString(_Product.Rank.Get());
                    txtPLUPI.Text = Convert.ToString(_Product.PrivateLabelUPI.Get());
                    txtUPI.Text = Convert.ToString(_Product.UPI.Get());
                    txtUOM.Text = Convert.ToString(_Product.MeasureValue.Get());
                    txtComment.Text = Convert.ToString(_Product.Comment.Get());
                    txtCustomString1.Text = Convert.ToString(_Product.CustomString1.Get());
                    txtCustomString2.Text = Convert.ToString(_Product.CustomString2.Get());
                    txtCustomString3.Text = Convert.ToString(_Product.CustomString3.Get());
                    txtCustomString4.Text = Convert.ToString(_Product.CustomString4.Get());
                    mtbOurPrice.Text = Convert.ToString(_Product.Price.Get());
                    mtbWhyPrice.Text = Convert.ToString(_Product.RecommendedPrice.Get());
                    HTMLEditor.HtmlEditControl.DocumentText = Convert.ToString(_Product.Description.Get());

                    chkApproved.Checked = (bool)_Product.Approved.Get();
                    chkInStoreOnly.Checked = (bool)_Product.InStoreOnly.Get();
                    chkRecommended.Checked = (bool)_Product.Recommended.Get();
                    chkShelfTalker.Checked = (bool)_Product.ShelfTalker.Get();
                    chkCore.Checked = (bool)_Product.CoreProduct.Get();

                    if (_Product.MeasureID.Get() != null) GetPacksize((int)_Product.MeasureID.Get());
                    if (_Product.BrandID.Get() != null) GetBrand((int)_Product.BrandID.Get());
                    if (_Product.ID.Get() != null) GetCategories((int)_Product.ID.Get());
                    if (_Product.ID.Get() != null) GetConditions((int)_Product.ID.Get());
                    if (_Product.ID.Get() != null) GetEndUses((int)_Product.ID.Get());
                    if (_Product.IngredientID.Get() != null) GetIngredient((int)_Product.IngredientID.Get());
                    if (_Product.ScheduleID.Get() != null) GetSchedule((int)_Product.ScheduleID.Get());

                    this.Text = (_Product.Name + " Product Details").Trim();

                    GetCatalogPrice();

                    if (Convert.ToString(_Product.Description).Trim().Length < 5)
                    {
                        tabDescription.ImageIndex = 5;
                    }

                    if (_Product.Image == null || Convert.ToString(_Product.Image).Trim().Length == 0)
                    {
                        tabImage.ImageIndex = 5;
                        btnResize.Enabled = false;
                    }
                    else
                    {
                        GetProductImage(Properties.Settings.Default.AlwaysDownloadImages);
                        if (Global.Permissions.Contains("Write Product")) btnResize.Enabled = true;
                    }

                    if (_Product.CurrentUsername != null && Convert.ToString(_Product.CurrentUsername).Trim().Length > 0)
                    {
                        if (Convert.ToString(_Product.CurrentUsername) != Global.Username)
                        {
                            lblExistingUsername.Text = String.Format("Another user ({0}) already has this record open!", _Product.CurrentUsername);
                        }
                        else
                        {
                            if (!IsRefresh) lblExistingUsername.Text = "You already have this record open!";
                        }
                    }
                    else
                    {
                        // Update this product with the current username so other users know it is being viewed/edited
                        _Product.CurrentUsername.Set(Global.Username);
                        try
                        {
                            _Product.Save(Global.SqlConnectionString);
                        }
                        catch (Exception ex)
                        {
                            Global.Common.Logging.WriteErrorEvent(String.Format("Error Saving Current Username: {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Global.Common.Logging.WriteErrorEvent(String.Format("Error displaying Product Details: {0}.\nThe message is: {1}", ex.StackTrace, ex.Message));
            }

            Cursor.Current = Cursors.Default;

        }

        private void lstConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConditions.SelectedItem != null)
            {
                btnWebMDSearchCondition.Enabled = (lstConditions.SelectedItem.ToString().Trim() != "");
            }
        }

        private void lstIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstIngredient.SelectedItem != null)
            {
                btnWebMDSearch.Enabled = (lstIngredient.SelectedItem.ToString().Trim() != "");
            }
        }

        private void mtbOurPrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                // Set the error
                errValidation.SetError((TextBox)sender, "A value is required.");
            }
            else
            {
                // Clear the error
                errValidation.SetError((TextBox)sender, string.Empty);
            }
        }

        private void mtbWhyPrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                // Set the error
                errValidation.SetError((TextBox)sender, "A value is required.");
            }
            else
            {
                // Clear the error
                errValidation.SetError((TextBox)sender, string.Empty);
            }
        }

        private void OpenItemSelectionForm(bool SingleItemSelection, Product ThisProduct, string ListDisplayName)
        {
            // Save any modified values first...
            SetProductValues();

            Cursor.Current = Cursors.WaitCursor;
            _Product.Save(Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            switch (ListDisplayName)
            {
                case "Condition":
                case "Conditions":
                    {
                        if (Properties.Settings.Default.SaveConditionsAgainstActiveIngredientOnly)
                        {
                            frmListEdit007 ItemEditForm = new frmListEdit007(ListDisplayName);

                            ItemEditForm.Show();
                        }
                        else
                        {
                            frmListItemSelection008 ItemSelectionForm = new frmListItemSelection008(this, Helper.ItemType.Product);

                            ItemSelectionForm.ParentObjectID = (int)ThisProduct.ID.Get();
                            ItemSelectionForm.SingleItemConstraint = SingleItemSelection;
                            ItemSelectionForm.ListDisplayName = ListDisplayName;

                            ItemSelectionForm.Show();
                        }

                        break;
                    }
                default:
                    {
                        frmListItemSelection008 ItemSelectionForm = new frmListItemSelection008(this, Helper.ItemType.Product);

                        ItemSelectionForm.ParentObjectID = (int)ThisProduct.ID.Get();
                        ItemSelectionForm.SingleItemConstraint = SingleItemSelection;
                        ItemSelectionForm.ListDisplayName = ListDisplayName;

                        ItemSelectionForm.Show();
                        break;
                    }
            }
        }

        private void PerformNHSWebSearch(string Term)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = "http://www.nhs.uk/medicine-guides/pages/selectorshow.aspx?medicine=" + Term;
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        private void picProduct_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (picProduct.Image != null)
            {
                txtImageHeight.Text = picProduct.Image.Height.ToString();
                txtImageWidth.Text = picProduct.Image.Width.ToString();
                
                CheckImageSize();
            }
        }

        private void picProduct_SizeChanged(object sender, EventArgs e)
        {
            CheckImageSize();
        }

        public void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
        {
            System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

            // Prevent using images internal thumbnail
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            if (OnlyResizeIfWider)
            {
                if (FullsizeImage.Width <= NewWidth)
                {
                    NewWidth = FullsizeImage.Width;
                }
            }

            int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
            if (NewHeight > MaxHeight)
            {
                // Resize with height instead
                NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                NewHeight = MaxHeight;
            }

            System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

            // Clear handle to original file so that we can overwrite it if necessary

            FullsizeImage.Dispose();

            // Save resized picture
            NewImage.Save(NewFile);
        }

        private void SaveProduct()
        {
            // Add the event handler
            _SaveWorker.DoWork += new DoWorkEventHandler(Worker_DoSave);

            // Start the save
            _SaveWorker.RunWorkerAsync();

            if (_SaveAndClose) this.Hide();
        }

        private void SetAccessRule(string RemoteDirectoryName)
        {
            System.Security.AccessControl.DirectorySecurity sec = System.IO.Directory.GetAccessControl(RemoteDirectoryName);
            FileSystemAccessRule accRule = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow);

            sec.AddAccessRule(accRule);
        }

        private void SetProductValues()
        {
            _Product.Approved.Set(chkApproved.Checked == true);
            _Product.Comment.Set(txtComment.Text);
            _Product.CustomString1.Set(txtCustomString1.Text);
            _Product.CustomString2.Set(txtCustomString2.Text);
            _Product.CustomString3.Set(txtCustomString3.Text);
            _Product.CustomString4.Set(txtCustomString4.Text);
            _Product.Description.Set(HTMLEditor.HtmlEditControl.DocumentText);
            _Product.Image.Set(txtImagePath.Text);
            _Product.InStoreOnly.Set(chkInStoreOnly.Checked == true);
            _Product.Limit.Set(Core.SQL.Functions.SQLInteger(txtLimit.Text));
            _Product.MeasureValue.Set(Core.SQL.Functions.SQLFloat(txtUOM.Text));
            _Product.Name.Set(txtName.Text);
            _Product.Price.Set(Core.SQL.Functions.SQLDecimal(mtbOurPrice.Text));
            _Product.PrivateLabelUPI.Set(Core.SQL.Functions.SQLInteger(txtPLUPI.Text));
            _Product.Rank.Set(Core.SQL.Functions.SQLInteger(txtRank.Text));
            _Product.Recommended.Set(chkRecommended.Checked == true);
            _Product.RecommendedPrice.Set(Core.SQL.Functions.SQLDecimal(mtbWhyPrice.Text));
            _Product.ShelfTalker.Set(chkShelfTalker.Checked == true);
            _Product.CoreProduct.Set(chkCore.Checked == true);
            // Thumbnail
            _Product.UPI.Set(Core.SQL.Functions.SQLInteger(txtUPI.Text));
        }

        private void splitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            if (_FormShown)
            {
                Properties.Settings.Default.ProductDetailFormPanel2Width = splitContainer.Panel2.Width;
                Properties.Settings.Default.Save();
            }
        }

        private void StartUpload(string ImageFolderName, string ImageFileName, string Extension, bool OverwriteLocalImage)
        {
            string RemoteFilename = _Product.UPI.Get().ToString();
            string ResizedFilename = ImageFileName + "_Resized";

            // Resize the local file
            ResizeImage(System.IO.Path.Combine(ImageFolderName, ImageFileName + Extension), System.IO.Path.Combine(ImageFolderName, ResizedFilename + Extension), 200, 200, true);

            //UploadFile(SourceFolder, SourceFilename, "/productimages", RemoteFilename);
            UploadFile(ImageFolderName, ResizedFilename + Extension, "/productimages", RemoteFilename + Extension);

            _Product.Image.Set("../productimages/" + RemoteFilename + Extension);
            _Product.Save(Global.SqlConnectionString);

            txtImagePath.Text = Convert.ToString(_Product.Image.Get());

            tabImage.ImageIndex = -1;
            GetProductImage(OverwriteLocalImage);
        }

        private void tabDescriptionImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Removes the description warning icon if a description is entered
            bool PreviousIconIsWarning = (tabDescription.ImageIndex == 5);

            if (HTMLEditor.HtmlEditControl.DocumentText.Length > 15)
            {
                if (PreviousIconIsWarning)
                {
                    tabDescription.ImageIndex = -1;
                    tabDescription.Refresh();
                }
            }
            else
            {
                if (!PreviousIconIsWarning)
                {
                    tabDescription.ImageIndex = 5;
                    tabDescription.Refresh();
                }
            }
        }

        private void txtLimit_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                // Set the error
                errValidation.SetError((TextBox)sender, "A value is required.");
            }
            else
            {
                // Clear the error
                errValidation.SetError((TextBox)sender, string.Empty);
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                // Set the error
                errValidation.SetError((TextBox)sender, "A value is required.");
            }
            else
            {
                // Clear the error
                errValidation.SetError((TextBox)sender, string.Empty);
            }
        }

        private void txtPackSize_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                // Set the error
                errValidation.SetError((TextBox)sender, "A value is required.");
            }
            else
            {
                // Clear the error
                errValidation.SetError((TextBox)sender, string.Empty);
            }
        }

        private void txtRank_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                // Set the error
                errValidation.SetError((TextBox)sender, "A value is required.");
            }
            else
            {
                // Clear the error
                errValidation.SetError((TextBox)sender, string.Empty);
            }
        }

        private void txtUOM_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                // Set the error
                errValidation.SetError((TextBox)sender, "A value is required.");
            }
            else
            {
                // Clear the error
                errValidation.SetError((TextBox)sender, string.Empty);
            }
        }

        private void txtUPI_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
            {
                // Set the error
                errValidation.SetError((TextBox)sender, "A value is required.");
            }
            else
            {
                // Clear the error
                errValidation.SetError((TextBox)sender, string.Empty);
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

        private void Worker_DoSave(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Worker_DoSave");
            DoSave();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetRemoteImage();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            picThumbnail.Refresh();
            picProduct.Refresh();
        }

        private void btnShowStockLevels_Click(object sender, EventArgs e)
        {
            frmStockLevels01A StockForm = new frmStockLevels01A();

            //StockForm.ProductSelectQuery = SelectQuery;
            //StockForm.ItemName = "Product";

            StockForm.Show();
        }
    }
}
