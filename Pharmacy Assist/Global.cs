using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PharmacyAssist
{
    public static class Global
    {
        public enum FileOrFolderSelection : int
        {
            File = 1,
            Folder
        }

        public static Core.Common.Singleton Common;
        public static SqlConnection Connection = new SqlConnection();
        public static int DataPageSize = Properties.Settings.Default.DataPageSize;
        public static int LastCatalogID = 0;
        public static List<Form> OpenForms = new List<Form>();
        public static List<string> Permissions = new List<string>();
        public static bool RestartRequired = false;
        public static string SqlConnectionString = Properties.Settings.Default.DataConnectionString;
        public static List<Color> Theme = new List<Color>();
        public static bool UseDeveloperSettings = false;
        public static string UserFullname = "";
        public static int UserID = 0;

        public static string Username = "";
        public static int UserStartPageID = 0;
        public static int UserStoreID = 0;

        public static void AddFormToList(Form form)
        {
            OpenForms.Add(form);
        }

        public static void Audit(string Description, string TableName, string FieldName, int RecordID, string Username, string PreviousValue, string NewValue, string ApplicationName, bool OverrideOptions)
        {
            if (Properties.Settings.Default.FullAudit || OverrideOptions)
            {
                string Query = "INSERT INTO audit (Description, TableName, FieldName, RecordID, Username, PreviousValue, NewValue, ApplicationName) VALUES ('" + Description + "', '" + TableName + "', '" + FieldName + "'," + RecordID + ",'" + Username + "','" + PreviousValue + "','" + NewValue + "','" + ApplicationName + "' )";

                if (NewValue != PreviousValue) Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            }
        }

        private static FtpWebRequest CreateRequest(string uri, string method)
        {
            var r = (FtpWebRequest)WebRequest.Create(uri);

            r.Credentials = new NetworkCredential(Properties.Settings.Default.FTPUsername, Properties.Settings.Default.FTPPassword);
            r.Method = method;

            return r;
        }

        #region GetAll[Property]

        public static void GetAllBrands(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT ID, Name FROM Brand", ItemListBox);
        }

        internal static void GetAllCatalogs(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT ID, Name FROM Catalog", ItemListBox);
        }

        public static void GetAllCategories(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT id, Name FROM category", ItemListBox);
        }

        public static void GetAllCertificates(ListBox ItemListBox)
        {
            GetListItemData("SELECT ID, Name FROM Certificate", ItemListBox);
        }

        public static void GetAllConditions(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT id, Name FROM condition", ItemListBox);
        }

        public static List<Document> GetAllDocuments(bool IncludeConditions, string Path, FileOrFolderSelection Selection)
        {
            List<Document> Documents = new List<Document>();
            Document ThisDocument = new Document();

            string Query = "SELECT ID, ISNULL(Name,'') AS Name, ISNULL(Filename,'') AS Filename, ISNULL(Path,'') AS Path, ISNULL(PublicAccess,0) AS PublicAccess, ISNULL(Keywords,'') AS Keywords, ISNULL(FreeService, CAST(0 AS Bit)) AS FreeService FROM Document";

            if (Path.Trim().Length > 0)
            {
                if (Selection == FileOrFolderSelection.File)
                {
                    Query += string.Format(" WHERE Path LIKE '{0}'", Path.Replace("'", "''"));
                }
                else
                {
                    Query += string.Format(" WHERE Path LIKE '{0}'", Path.Replace("'", "''"));
                }
            }

            Query += string.Format(" ORDER BY Path, Filename");

            DataSet Data = Core.SQL.Functions.Execute(Query, SqlConnectionString);

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ThisDocument = new Document();

                if (Selection == FileOrFolderSelection.File)
                {
                    ThisDocument.ID = (int)Row["ID"];
                    ThisDocument.FileName = (string)Row["Filename"];
                    ThisDocument.Name = (string)Row["Name"];
                    ThisDocument.Path = (string)Row["Path"];
                    ThisDocument.Public = (bool)Row["PublicAccess"];
                    ThisDocument.FreeService = (bool)Row["FreeService"];
                    ThisDocument.Keywords = (string)(Row["Keywords"] + "");

                    if (IncludeConditions)
                    {
                        // Get associated Conditions
                        Query = "select DISTINCT c.ID, c.Name FROM Condition c LEFT JOIN ConditionDocument cd ON cd.ConditionID = c.ID WHERE cd.DocumentID = " + ThisDocument.ID;
                        DataSet ConditionData = Core.SQL.Functions.Execute(Query, SqlConnectionString);

                        List<Condition> Conditions = new List<Condition>();

                        foreach (DataRow ConditionRow in ConditionData.Tables[0].Rows)
                        {
                            Condition ThisCondition = new Condition();

                            ThisCondition.ID = (int)ConditionRow["ID"];
                            ThisCondition.Name = (string)ConditionRow["Name"];

                            Conditions.Add(ThisCondition);
                        }

                        ThisDocument.Conditions = Conditions;
                    }
                }
                else
                {
                    ThisDocument.ID = (int)Row["ID"];
                    ThisDocument.FileName = (string)Row["Filename"];  //OriginalPath.Substring(OriginalPath.LastIndexOf("/") + 1);
                    ThisDocument.Name = (string)Row["Name"];
                    ThisDocument.Path = (string)Row["Path"]; //OriginalPath.Substring(0, OriginalPath.LastIndexOf("/"));
                    ThisDocument.Public = (bool)Row["PublicAccess"];
                    ThisDocument.FreeService = (bool)Row["FreeService"];
                    ThisDocument.Keywords = (string)(Row["Keywords"] + "");
                    ThisDocument.IsFolder = true;
                }

                if (!Documents.Contains(ThisDocument))
                {
                    Documents.Add(ThisDocument);
                }

            }
            return Documents;
        }

        public static void GetAllDocuments(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT id, Name FROM Document", ItemListBox);
        }

        public static void GetAllEndUses(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT id, Name FROM enduse", ItemListBox);
        }

        public static void GetAllEvents(ListBox ItemListBox)
        {
            GetListItemData("SELECT ID, Name FROM Event", ItemListBox);
        }

        public static void GetAllEventTypes(ListBox ItemListBox)
        {
            GetListItemData("SELECT ID, Name FROM EventType", ItemListBox);
        }

        public static void GetAllIngredients(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT id, Name FROM ingredient", ItemListBox);
        }

        public static void GetAllPermissions(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT ID, Name FROM Permission", ItemListBox);
        }

        internal static void GetAllProducts(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT ID, Name FROM Product", ItemListBox);
        }

        internal static void GetAllRoles(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT ID, Name FROM Role", ItemListBox);
        }

        public static void GetAllSchedules(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT id, Name FROM schedule", ItemListBox);
        }

        public static void GetAllStores(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT id, Name FROM store", ItemListBox);
        }

        public static List<Task> GetAllTasks(bool IncludeComplete, bool LoadTaskDataOnDemand)
        {
            List<Task> Tasks = new List<Task>();
            DataSet TaskData = null;
            List<Role> Roles = new List<Role>();
            List<Document> Documents = new List<Document>();
            List<Store> Stores = new List<Store>();
            string Query = "SELECT t.ID, t.Name, t.description, t.Complete, t.CreateDate, t.CompletionDate, t.CertificateID, t.WarningPeriod, t.Recurrance, t.Enabled, t.DueDate, t.Mandatory, ISNULL(c.Name, '') AS CertificateName, ISNULL(u.FirstName + ' ' + u.LastName,'') AS CompletedBy FROM Task t LEFT JOIN Certificate c ON t.CertificateID = c.ID LEFT JOIN UserAccount u ON t.CompletedBy = u.ID";

            if (!IncludeComplete) Query += " WHERE t.Complete = 0";

            Query += " ORDER BY t.DueDate ASC";

            Global.Common.Logging.WriteDebugEvent("Tasks Query: " + Query);

            TaskData = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            // Loop through these Rows, creating a Task to represent each one.  At the same time, get the roles for each
            if (TaskData.Tables[0] != null)
            {
                foreach (DataRow Row in TaskData.Tables[0].Rows)
                {
                    int TaskID = (int)Row["ID"];

                    if (!LoadTaskDataOnDemand)
                    {

                        ///////////////////////////////////////// Get Roles
                        string RoleQuery = "SELECT r.ID, r.Name, ISNULL(r.Description,'') AS Description, r.System FROM TaskRole tr LEFT JOIN Role r ON tr.RoleID = r.ID WHERE TaskID = " + TaskID.ToString();
                        

                        Cursor.Current = Cursors.WaitCursor;
                        DataSet TaskRoleData = Core.SQL.Functions.Execute(RoleQuery, Global.SqlConnectionString);
                        Cursor.Current = Cursors.Default;

                        foreach (DataRow TaskRoleRow in TaskRoleData.Tables[0].Rows)
                        {
                            Role ThisRole = new Role();

                            ThisRole.ID = (int)TaskRoleRow["ID"];
                            ThisRole.Name = (string)TaskRoleRow["Name"];
                            ThisRole.Description = (string)TaskRoleRow["Description"];
                            ThisRole.System = (bool)TaskRoleRow["System"];

                            Roles.Add(ThisRole);
                        }

                        ////////////////////////////////////////// Get Documents
                        string DocumentQuery = "SELECT ISNULL(d.ID, 0) AS ID, d.Name, d.FileName, d.Path, ISNULL(d.PublicAccess,0) AS PublicAccess FROM Task t LEFT JOIN TaskDocument td ON t.ID = td.TaskID LEFT JOIN Document d ON d.ID = td.DocumentID WHERE t.ID = " + TaskID.ToString();
                        

                        Cursor.Current = Cursors.WaitCursor;
                        DataSet TaskDocumentData = Core.SQL.Functions.Execute(DocumentQuery, Global.SqlConnectionString);
                        Cursor.Current = Cursors.Default;

                        if (TaskDocumentData.Tables[0] != null)
                        {
                            foreach (DataRow TaskDocumentRow in TaskDocumentData.Tables[0].Rows)
                            {
                                Document TaskDocument = new Document();

                                if ((int)TaskDocumentRow["ID"] > 0)
                                {
                                    TaskDocument.FileName = (string)TaskDocumentRow["Filename"];
                                    TaskDocument.ID = (int)TaskDocumentRow["ID"];
                                    TaskDocument.Name = (string)TaskDocumentRow["Name"];
                                    TaskDocument.Path = (string)TaskDocumentRow["Path"];
                                    if ((bool)TaskDocumentRow["PublicAccess"] == true)
                                    {
                                        TaskDocument.Public = true;  //TaskDocument.Public = (bool)TaskDocumentRow["PublicAccess"];
                                    }

                                    Documents.Add(TaskDocument);
                                }
                            }
                        }

                        ////////////////////////////////////////// Get Stores
                        string StoreQuery = "SELECT s.ID, ISNULL(s.Name,'') AS Name, ISNULL(s.RPMName,'') AS RPMName, ISNULL(s.Address,'') AS Address, ISNULL(s.Town,'') AS Town, ISNULL(s.State,'') AS State, ISNULL(s.Postcode,'') AS Postcode, ISNULL(s.Phone,'') AS Phone, ISNULL(s.Fax,'') AS Fax, ISNULL(s.Email,'') AS Email, ISNULL(s.Contact,'') AS Contact, ISNULL(s.MapURL,'') AS MapURL, ISNULL(s.OpenMonday,'') AS OpenMonday, ISNULL(s.CloseMonday,'') AS CloseMonday, ISNULL(s.OpenTuesday,'') AS OpenTuesday, ISNULL(s.CloseTuesday,'') AS CloseTuesday, ISNULL(s.OpenWednesday,'') AS OpenWednesday, ISNULL(s.CloseWednesday,'') AS CloseWednesday, ISNULL(s.OpenThursday,'') AS OpenThursday, ISNULL(s.CloseThursday,'') AS CloseThursday, ISNULL(s.OpenFriday,'') AS OpenFriday, ISNULL(s.CloseFriday,'') AS CloseFriday, ISNULL(s.OpenSaturday,'') AS OpenSaturday, ISNULL(s.CloseSaturday,'') AS CloseSaturday, ISNULL(s.OpenSunday,'') AS OpenSunday, ISNULL(s.CloseSunday,'') AS CloseSunday, ISNULL(s.OpenPublicHolidays,'') AS OpenPublicHolidays, ISNULL(s.ClosePublicHolidays,'') AS ClosePublicHolidays, ISNULL(s.ShowOnWebsite,'') AS ShowOnWebsite FROM TaskStore ts LEFT OUTER JOIN Store s ON ts.StoreID = s.ID WHERE ts.TaskID = " + TaskID.ToString();
                        

                        Cursor.Current = Cursors.WaitCursor;
                        DataSet TaskStoreData = Core.SQL.Functions.Execute(StoreQuery, Global.SqlConnectionString);
                        Cursor.Current = Cursors.Default;

                        if (TaskStoreData.Tables[0] != null)
                        {
                            foreach (DataRow TaskStoreRow in TaskStoreData.Tables[0].Rows)
                            {
                                Store TaskStore = new Store();

                                if ((int)TaskStoreRow["ID"] > 0)
                                {
                                    TaskStore.ID = (int)TaskStoreRow["ID"];
                                    TaskStore.Name = (string)TaskStoreRow["Name"];
                                    TaskStore.RPMName = (string)TaskStoreRow["RPMName"];
                                    TaskStore.Address = (string)TaskStoreRow["Address"];
                                    TaskStore.Town = (string)TaskStoreRow["Town"];
                                    TaskStore.State = (string)TaskStoreRow["State"];
                                    TaskStore.Postcode = (string)TaskStoreRow["Postcode"];
                                    TaskStore.Phone = (string)TaskStoreRow["Phone"];
                                    TaskStore.Fax = (string)TaskStoreRow["Fax"];
                                    TaskStore.Email = (string)TaskStoreRow["Email"];
                                    TaskStore.Contact = (string)TaskStoreRow["Contact"];
                                    TaskStore.MapURL = (string)TaskStoreRow["MapURL"];
                                    TaskStore.OpenMonday = (string)TaskStoreRow["OpenMonday"];
                                    TaskStore.CloseMonday = (string)TaskStoreRow["CloseMonday"];
                                    TaskStore.OpenTuesday = (string)TaskStoreRow["OpenTuesday"];
                                    TaskStore.CloseTuesday = (string)TaskStoreRow["CloseTuesday"];
                                    TaskStore.OpenWednesday = (string)TaskStoreRow["OpenWednesday"];
                                    TaskStore.CloseWednesday = (string)TaskStoreRow["CloseWednesday"];
                                    TaskStore.OpenThursday = (string)TaskStoreRow["OpenThursday"];
                                    TaskStore.CloseThursday = (string)TaskStoreRow["CloseThursday"];
                                    TaskStore.OpenFriday = (string)TaskStoreRow["OpenFriday"];
                                    TaskStore.CloseFriday = (string)TaskStoreRow["CloseFriday"];
                                    TaskStore.OpenSaturday = (string)TaskStoreRow["OpenSaturday"];
                                    TaskStore.CloseSaturday = (string)TaskStoreRow["CloseSaturday"];
                                    TaskStore.OpenSunday = (string)TaskStoreRow["OpenSunday"];
                                    TaskStore.CloseSunday = (string)TaskStoreRow["CloseSunday"];
                                    TaskStore.OpenPublicHolidays = (string)TaskStoreRow["OpenPublicHolidays"];
                                    TaskStore.ClosePublicHolidays = (string)TaskStoreRow["ClosePublicHolidays"];
                                    TaskStore.ShowOnWebsite = (bool)TaskStoreRow["ShowOnWebsite"];

                                    Stores.Add(TaskStore);
                                }
                            }
                        }
                    }
                    Task ThisTask = new Task();

                    ThisTask.CertificateID = (int)Row["CertificateID"];
                    ThisTask.CertificateName = (string)Row["CertificateName"];
                    ThisTask.Complete = (bool)Row["Complete"];
                    ThisTask.CreateDate = (DateTime)Row["CreateDate"];
                    ThisTask.Description = (string)Row["Description"];
                    ThisTask.DueDate = (DateTime)Row["DueDate"];
                    ThisTask.Enabled = (bool)Row["Enabled"];
                    ThisTask.ID = (int)Row["ID"];
                    ThisTask.Mandatory = (bool)Row["Mandatory"];
                    ThisTask.Name = (string)Row["Name"];
                    ThisTask.Recurrance = (string)Row["Recurrance"];
                    ThisTask.CompletedBy = (string)Row["CompletedBy"];
                    ThisTask.WarningPeriod = (int)Row["WarningPeriod"];

                    ThisTask.Roles = Roles;
                    ThisTask.Documents = Documents;
                    ThisTask.Stores = Stores;

                    Tasks.Add(ThisTask);
                }
            }

            return Tasks;
        }

        public static void GetAllTasks(ListBox ItemListBox)
        {
            GetListItemData("SELECT ID, Name FROM Task ORDER BY DueDate ASC", ItemListBox);
        }

        public static void GetIncompleteTasks(ListBox ItemListBox)
        {
            GetListItemData("SELECT ID, Name FROM Task WHERE Complete = 0 ORDER BY DueDate ASC", ItemListBox);
        }

        public static void GetAllTasks(ListView ItemListView)
        {
            GetListViewData("SELECT ID, Name FROM Task ORDER BY DueDate ASC", ItemListView);
        }

        public static void GetIncompleteTasks(ListView ItemListView)
        {
            GetListViewData("SELECT ID, Name FROM Task WHERE Complete = 0 ORDER BY DueDate ASC", ItemListView);
        }

        public static void GetAllUnitsOfMeasure(ListBox ItemListBox)
        {
            GetListItemData("SELECT DISTINCT id, Name FROM unitofmeasure", ItemListBox);
        }

        public static void GetAllUserAccounts(ListBox ItemListBox)
        {
            //GetListItemData("SELECT ID, FirstName + ' ' + LastName AS FullName FROM UserAccount", ItemListBox);
            GetListItemData("SELECT ID, Fullname = CASE FirstName + ' ' + LastName WHEN ' ' THEN '(' + UserName + ')' ELSE FirstName + ' ' + LastName END FROM UserAccount", ItemListBox);
        }

        #endregion

        public static Task GetTaskData(int TaskID)
        {
            //List<Task> Tasks = new List<Task>();
            Task ThisTask = new Task();
            DataSet TaskData = null;
            string Query = "SELECT t.ID, t.Name, t.description, t.Complete, t.CreateDate, t.CompletionDate, t.CertificateID, t.WarningPeriod, t.Recurrance, t.Enabled, t.DueDate, t.Mandatory, ISNULL(c.Name, '') AS CertificateName, ISNULL(u.FirstName + ' ' + u.LastName,'') AS CompletedBy FROM Task t LEFT JOIN Certificate c ON t.CertificateID = c.ID LEFT JOIN UserAccount u ON t.CompletedBy = u.ID WHERE t.ID = " + TaskID.ToString();

            Query += " ORDER BY t.DueDate ASC";

            TaskData = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            // Loop through these Rows, creating a Task to represent each one.  At the same time, get the roles for each
            if (TaskData.Tables[0] != null)
            {
                DataRow Row = TaskData.Tables[0].Rows[0];
                //foreach (DataRow Row in TaskData.Tables[0].Rows)
                //{
                    ///////////////////////////////////////// Get Roles
                    string RoleQuery = "SELECT r.ID, r.Name, ISNULL(r.Description,'') AS Description, r.System FROM TaskRole tr LEFT JOIN Role r ON tr.RoleID = r.ID WHERE TaskID = " + TaskID.ToString();
                    List<Role> Roles = new List<Role>();

                    Cursor.Current = Cursors.WaitCursor;
                    DataSet TaskRoleData = Core.SQL.Functions.Execute(RoleQuery, Global.SqlConnectionString);
                    Cursor.Current = Cursors.Default;

                    foreach (DataRow TaskRoleRow in TaskRoleData.Tables[0].Rows)
                    {
                        Role ThisRole = new Role();

                        ThisRole.ID = (int)TaskRoleRow["ID"];
                        ThisRole.Name = (string)TaskRoleRow["Name"];
                        ThisRole.Description = (string)TaskRoleRow["Description"];
                        ThisRole.System = (bool)TaskRoleRow["System"];

                        Roles.Add(ThisRole);
                    }

                    ////////////////////////////////////////// Get Documents
                    string DocumentQuery = "SELECT ISNULL(d.ID, 0) AS ID, d.Name, d.FileName, d.Path, ISNULL(d.PublicAccess,0) AS PublicAccess FROM Task t LEFT JOIN TaskDocument td ON t.ID = td.TaskID LEFT JOIN Document d ON d.ID = td.DocumentID WHERE t.ID = " + TaskID.ToString();
                    List<Document> Documents = new List<Document>();

                    Cursor.Current = Cursors.WaitCursor;
                    DataSet TaskDocumentData = Core.SQL.Functions.Execute(DocumentQuery, Global.SqlConnectionString);
                    Cursor.Current = Cursors.Default;

                    if (TaskDocumentData.Tables[0] != null)
                    {
                        foreach (DataRow TaskDocumentRow in TaskDocumentData.Tables[0].Rows)
                        {
                            Document TaskDocument = new Document();

                            if ((int)TaskDocumentRow["ID"] > 0)
                            {
                                TaskDocument.FileName = (string)TaskDocumentRow["Filename"];
                                TaskDocument.ID = (int)TaskDocumentRow["ID"];
                                TaskDocument.Name = (string)TaskDocumentRow["Name"];
                                TaskDocument.Path = (string)TaskDocumentRow["Path"];
                                if ((bool)TaskDocumentRow["PublicAccess"] == true)
                                {
                                    TaskDocument.Public = true;  //TaskDocument.Public = (bool)TaskDocumentRow["PublicAccess"];
                                }

                                Documents.Add(TaskDocument);
                            }
                        }
                    }

                    ////////////////////////////////////////// Get Stores
                    string StoreQuery = "SELECT s.ID, ISNULL(s.Name,'') AS Name, ISNULL(s.RPMName,'') AS RPMName, ISNULL(s.Address,'') AS Address, ISNULL(s.Town,'') AS Town, ISNULL(s.State,'') AS State, ISNULL(s.Postcode,'') AS Postcode, ISNULL(s.Phone,'') AS Phone, ISNULL(s.Fax,'') AS Fax, ISNULL(s.Email,'') AS Email, ISNULL(s.Contact,'') AS Contact, ISNULL(s.MapURL,'') AS MapURL, ISNULL(s.OpenMonday,'') AS OpenMonday, ISNULL(s.CloseMonday,'') AS CloseMonday, ISNULL(s.OpenTuesday,'') AS OpenTuesday, ISNULL(s.CloseTuesday,'') AS CloseTuesday, ISNULL(s.OpenWednesday,'') AS OpenWednesday, ISNULL(s.CloseWednesday,'') AS CloseWednesday, ISNULL(s.OpenThursday,'') AS OpenThursday, ISNULL(s.CloseThursday,'') AS CloseThursday, ISNULL(s.OpenFriday,'') AS OpenFriday, ISNULL(s.CloseFriday,'') AS CloseFriday, ISNULL(s.OpenSaturday,'') AS OpenSaturday, ISNULL(s.CloseSaturday,'') AS CloseSaturday, ISNULL(s.OpenSunday,'') AS OpenSunday, ISNULL(s.CloseSunday,'') AS CloseSunday, ISNULL(s.OpenPublicHolidays,'') AS OpenPublicHolidays, ISNULL(s.ClosePublicHolidays,'') AS ClosePublicHolidays, ISNULL(s.ShowOnWebsite,'') AS ShowOnWebsite FROM TaskStore ts LEFT OUTER JOIN Store s ON ts.StoreID = s.ID WHERE ts.TaskID = " + TaskID.ToString();
                    List<Store> Stores = new List<Store>();

                    Cursor.Current = Cursors.WaitCursor;
                    DataSet TaskStoreData = Core.SQL.Functions.Execute(StoreQuery, Global.SqlConnectionString);
                    Cursor.Current = Cursors.Default;

                    if (TaskStoreData.Tables[0] != null)
                    {
                        foreach (DataRow TaskStoreRow in TaskStoreData.Tables[0].Rows)
                        {
                            Store TaskStore = new Store();

                            if ((int)TaskStoreRow["ID"] > 0)
                            {
                                TaskStore.ID = (int)TaskStoreRow["ID"];
                                TaskStore.Name = (string)TaskStoreRow["Name"];
                                TaskStore.RPMName = (string)TaskStoreRow["RPMName"];
                                TaskStore.Address = (string)TaskStoreRow["Address"];
                                TaskStore.Town = (string)TaskStoreRow["Town"];
                                TaskStore.State = (string)TaskStoreRow["State"];
                                TaskStore.Postcode = (string)TaskStoreRow["Postcode"];
                                TaskStore.Phone = (string)TaskStoreRow["Phone"];
                                TaskStore.Fax = (string)TaskStoreRow["Fax"];
                                TaskStore.Email = (string)TaskStoreRow["Email"];
                                TaskStore.Contact = (string)TaskStoreRow["Contact"];
                                TaskStore.MapURL = (string)TaskStoreRow["MapURL"];
                                TaskStore.OpenMonday = (string)TaskStoreRow["OpenMonday"];
                                TaskStore.CloseMonday = (string)TaskStoreRow["CloseMonday"];
                                TaskStore.OpenTuesday = (string)TaskStoreRow["OpenTuesday"];
                                TaskStore.CloseTuesday = (string)TaskStoreRow["CloseTuesday"];
                                TaskStore.OpenWednesday = (string)TaskStoreRow["OpenWednesday"];
                                TaskStore.CloseWednesday = (string)TaskStoreRow["CloseWednesday"];
                                TaskStore.OpenThursday = (string)TaskStoreRow["OpenThursday"];
                                TaskStore.CloseThursday = (string)TaskStoreRow["CloseThursday"];
                                TaskStore.OpenFriday = (string)TaskStoreRow["OpenFriday"];
                                TaskStore.CloseFriday = (string)TaskStoreRow["CloseFriday"];
                                TaskStore.OpenSaturday = (string)TaskStoreRow["OpenSaturday"];
                                TaskStore.CloseSaturday = (string)TaskStoreRow["CloseSaturday"];
                                TaskStore.OpenSunday = (string)TaskStoreRow["OpenSunday"];
                                TaskStore.CloseSunday = (string)TaskStoreRow["CloseSunday"];
                                TaskStore.OpenPublicHolidays = (string)TaskStoreRow["OpenPublicHolidays"];
                                TaskStore.ClosePublicHolidays = (string)TaskStoreRow["ClosePublicHolidays"];
                                TaskStore.ShowOnWebsite = (bool)TaskStoreRow["ShowOnWebsite"];

                                Stores.Add(TaskStore);
                            }
                        }
                    }

                    

                    ThisTask.CertificateID = (int)Row["CertificateID"];
                    ThisTask.CertificateName = (string)Row["CertificateName"];
                    ThisTask.Complete = (bool)Row["Complete"];
                    ThisTask.CreateDate = (DateTime)Row["CreateDate"];
                    ThisTask.Description = (string)Row["Description"];
                    ThisTask.DueDate = (DateTime)Row["DueDate"];
                    ThisTask.Enabled = (bool)Row["Enabled"];
                    ThisTask.ID = (int)Row["ID"];
                    ThisTask.Mandatory = (bool)Row["Mandatory"];
                    ThisTask.Name = (string)Row["Name"];
                    ThisTask.Recurrance = (string)Row["Recurrance"];
                    ThisTask.CompletedBy = (string)Row["CompletedBy"];
                    ThisTask.WarningPeriod = (int)Row["WarningPeriod"];

                    ThisTask.Roles = Roles;
                    ThisTask.Documents = Documents;
                    ThisTask.Stores = Stores;

                    //Tasks.Add(ThisTask);
            }

            return ThisTask;
        }

        ////// FTP stuff
        public static List<Document> GetDocumentsFromPath(bool Detailed, string Path, FileOrFolderSelection Selection)
        {
            Cursor.Current = Cursors.WaitCursor;

            List<Document> Entries = new List<Document>();

            FtpWebRequest Request = null;

            if (Detailed)
            {
                Request = CreateRequest("ftp://" + Properties.Settings.Default.FTPHost + Path, WebRequestMethods.Ftp.ListDirectoryDetails);
            }
            else
            {
                Request = CreateRequest("ftp://" + Properties.Settings.Default.FTPHost + Path, WebRequestMethods.Ftp.ListDirectory);
            }

            #region Example results

            // Detailed:
            //
            // 08-15-13  06:20PM       <DIR>          AutoUpdate
            // 06-17-13  11:42PM       <DIR>          bin
            // 06-18-13  12:06AM       <DIR>          Data
            // 02-18-09  05:35PM                 6016 discountasp.index.htm
            // 07-17-13  09:15PM       <DIR>          documents
            // 06-20-13  06:05PM                 6651 index.htm
            // 08-21-13  12:24AM       <DIR>          productimages
            // 08-13-13  05:09AM       <DIR>          _database

            // !Detailed:
            //
            // AutoUpdate
            // bin
            // Data
            // discountasp.index.htm
            // documents
            // index.htm
            // productimages
            // _database

            #endregion

            try
            {
                using (var response = (FtpWebResponse)Request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, true))
                        {
                            while (!reader.EndOfStream)
                            {
                                string DirectoryEntry = reader.ReadLine();

                                Document Entry = new Document(Path, DirectoryEntry);

                                if (
                                    (Selection == FileOrFolderSelection.File && !Entry.IsFolder) ||
                                    (Selection == FileOrFolderSelection.Folder && Entry.IsFolder)
                                   )
                                {
                                    Entries.Add(Entry);
                                }

                                Application.DoEvents();
                            }
                        }
                    }
                }
            }
            catch { }


            Cursor.Current = Cursors.Default;

            return Entries;
        }

        public static List<Document> GetDocumentsFromDatabase(string Path, FileOrFolderSelection Selection)
        {
            Cursor.Current = Cursors.WaitCursor;

            List<Document> Entries = new List<Document>();

            Entries = GetAllDocuments(false, Path, Selection);

            Cursor.Current = Cursors.Default;

            return Entries;
        }

        public static void GetListItemData(string Query, ListBox ItemListBox)
        {
            DataSet Data = null;

            ItemListBox.BeginUpdate();
            ItemListBox.Items.Clear();

            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            if (Data.Tables[0].Rows.Count > 0 && Data.Tables[0].Rows[0][0].ToString() != "")
            {
                foreach (DataRow Row in Data.Tables[0].Rows)
                {
                    ListItem Item = new ListItem((int)Row[0], (string)Row[1]);

                    if (Data.Tables[0].Columns.Contains("Path")) // Supports documents
                    {
                        Document ItemDocument = new Document();

                        ItemDocument.ID = (int)Row[0];
                        ItemDocument.Name = (string)Row[1];
                        ItemDocument.FileName = (string)Row[2];
                        ItemDocument.Path = (string)Row[3];
                        Item.Tag = ItemDocument;
                    }

                    ItemListBox.Items.Add(Item);

                }
            }

            ItemListBox.EndUpdate();
        }

        public static void GetListViewData(string Query, ListView ItemListView)
        {
            DataSet Data = null;

            ItemListView.BeginUpdate();
            ItemListView.Items.Clear();

            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            if (Data.Tables[0].Rows.Count > 0 && Data.Tables[0].Rows[0][0].ToString() != "")
            {
                foreach (DataRow Row in Data.Tables[0].Rows)
                {
                    ListViewItem Item = new ListViewItem();

                    Task task = new Task();

                    task.ID = (int)Row[0];
                    task.Name = (string)Row[1];

                    Item.Tag = task;

                    Item.SubItems.Add((string)Row[1]);

                    ItemListView.Items.Add(Item);

                }
            }

            ItemListView.EndUpdate();
        }

        public static int GetRecordCount(string Query)
        {
            int Result = 0;

            // Example usage:  int IngredientRecordCount = Global.GetRecordCount(SelectQuery.Substring(SelectQuery.IndexOf(" FROM") + 6));

            Cursor.Current = Cursors.WaitCursor;

            if (Query.Trim().ToUpper().StartsWith("FROM"))
            {
                Result = (int)Core.SQL.Functions.Execute("SELECT COUNT (*) " + Query, Global.SqlConnectionString).Tables[0].Rows[0][0];
            }
            else
            {
                Result = (int)Core.SQL.Functions.Execute("SELECT COUNT (*) FROM " + Query, Global.SqlConnectionString).Tables[0].Rows[0][0];
            }

            Cursor.Current = Cursors.Default;

            return Result;
        }

        public static List<Task> GetUserTasks(int DaysAhead, int SelectedUserID, bool SortAlphabetically)
        {
            List<Task> Tasks = new List<Task>();
            string Query = "";
            string SortOrder = "t.DueDate ASC";

            if (SortAlphabetically) SortOrder = "t.Name ASC";

            if (DaysAhead >= 0)
            {
                Query = string.Format("SELECT DISTINCT t.ID, t.Name, t.Description, t.Complete, t.CreateDate, t.CertificateID, ISNULL(c.Name,'') as CertificateName, t.WarningPeriod, t.Recurrance, t.Enabled, t.DueDate, ISNULL(t.CompletionDate, CAST('9999/12/31' AS date)) AS CompletionDate, t.Mandatory, ISNULL(u2.FirstName + ' ' + u2.LastName,'') AS FullName, ISNULL(s2.Name,'') AS StoreName FROM Task t " +
                                      "INNER JOIN TaskRole tr ON tr.TaskID = t.ID " +
                                      "INNER JOIN Role r ON r.ID = tr.RoleID " +
                                      "INNER JOIN UserAccountRole ur ON r.ID = tr.RoleID " +
                                      "INNER JOIN UserAccount u ON u.ID = ur.UserAccountID " +
                                      "LEFT JOIN UserAccount u2 ON u2.ID = t.CompletedBy " +
                                      "LEFT JOIN TaskStore ts ON t.ID = ts.TaskID " +
                                      "LEFT JOIN Store s ON ts.StoreID = s.ID " +
                                      "LEFT JOIN Store s2 ON s2.ID = u2.StoreID " +
                                      "LEFT JOIN Certificate c ON c.ID = t.CertificateID " +
                                      "WHERE u.ID = {0} AND DATEDIFF(d, GETDATE(), t.DueDate) <= " + DaysAhead + " AND " +
                                      "t.Complete = 0 AND " +
                                      "t.Enabled = 1 AND " +
                                      "r.ID IN (SELECT r.ID FROM Role r " +
                                               "LEFT JOIN UserAccountRole ur ON r.ID = ur.RoleID " +
                                               "LEFT JOIN UserAccount u ON u.ID = ur.UserAccountID " +
                                               "WHERE u.ID = {1}) AND (u.StoreID = s.ID OR ts.StoreID IS NULL OR u.StoreID IS NULL or u.StoreID = 0) " +
                                               "ORDER BY " + SortOrder
                                       , SelectedUserID, SelectedUserID);
            }
            else
            {
                Query = string.Format("SELECT DISTINCT t.ID, t.Name, t.Description, t.Complete, t.CreateDate, t.CertificateID, ISNULL(c.Name,'') as CertificateName, t.WarningPeriod, t.Recurrance, t.Enabled, t.DueDate, ISNULL(t.CompletionDate, CAST('9999/12/31' AS date)) AS CompletionDate, t.Mandatory, ISNULL(u2.FirstName + ' ' + u2.LastName,'') AS FullName, ISNULL(s2.Name,'') AS StoreName FROM Task t " +
                                      "INNER JOIN TaskRole tr ON tr.TaskID = t.ID " +
                                      "INNER JOIN Role r ON r.ID = tr.RoleID " +
                                      "INNER JOIN UserAccountRole ur ON r.ID = tr.RoleID " +
                                      "INNER JOIN UserAccount u ON u.ID = ur.UserAccountID " +
                                      "LEFT JOIN UserAccount u2 ON u2.ID = t.CompletedBy " +
                                      "LEFT JOIN TaskStore ts ON t.ID = ts.TaskID " +
                                      "LEFT JOIN Store s ON ts.StoreID = s.ID " +
                                      "LEFT JOIN Store s2 ON s2.ID = u2.StoreID " +
                                      "LEFT JOIN Certificate c ON c.ID = t.CertificateID " +
                                      "WHERE u.ID = {0} AND " +
                                      "t.Complete = 1 AND " +
                                      "r.ID IN (SELECT r.ID " +
                                                "FROM Role r " +
                                                "LEFT JOIN UserAccountRole ur ON r.ID = ur.RoleID " +
                                                "LEFT JOIN UserAccount u ON u.ID = ur.UserAccountID " +
                                                "WHERE u.ID = {1}) AND (u.StoreID = s.ID OR ts.StoreID IS NULL OR u.StoreID IS NULL or u.StoreID = 0) " +
                                                "ORDER BY " + SortOrder
                                       , SelectedUserID, SelectedUserID);
            }

            Cursor.Current = Cursors.WaitCursor;
            DataSet TaskData = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            // Loop through these Rows, creating a Task to represent each one.  At the same time, get the roles for each
            if (TaskData.Tables[0] != null)
            {
                foreach (DataRow Row in TaskData.Tables[0].Rows)
                {
                    int TaskID = (int)Row["ID"];

                    ///////////////////////////////////////// Get Roles
                    string RoleQuery = "SELECT r.ID, ISNULL(r.Name, '') AS Name, ISNULL(r.Description, '') As Description, r.System FROM TaskRole  tr LEFT JOIN Role r ON tr.RoleID = r.ID WHERE TaskID = " + TaskID.ToString();
                    List<Role> Roles = new List<Role>();

                    Cursor.Current = Cursors.WaitCursor;
                    DataSet TaskRoleData = Core.SQL.Functions.Execute(RoleQuery, Global.SqlConnectionString);
                    Cursor.Current = Cursors.Default;

                    foreach (DataRow TaskRoleRow in TaskRoleData.Tables[0].Rows)
                    {
                        Role ThisRole = new Role();

                        ThisRole.ID = (int)TaskRoleRow["ID"];
                        ThisRole.Name = (string)TaskRoleRow["Name"];
                        ThisRole.Description = (string)TaskRoleRow["Description"];
                        ThisRole.System = (bool)TaskRoleRow["System"];

                        Roles.Add(ThisRole);
                    }

                    ////////////////////////////////////////// Get Documents
                    string DocumentQuery = "SELECT ISNULL(d.ID, 0) AS ID, d.Name, d.FileName, d.Path, ISNULL(d.PublicAccess, 1) AS PublicAccess FROM Task t LEFT JOIN TaskDocument td ON t.ID = td.TaskID LEFT JOIN Document d ON d.ID = td.DocumentID WHERE t.ID = " + TaskID.ToString();
                    List<Document> Documents = new List<Document>();

                    Cursor.Current = Cursors.WaitCursor;
                    DataSet TaskDocumentData = Core.SQL.Functions.Execute(DocumentQuery, Global.SqlConnectionString);
                    Cursor.Current = Cursors.Default;

                    if (TaskDocumentData.Tables[0] != null)
                    {
                        foreach (DataRow TaskDocumentRow in TaskDocumentData.Tables[0].Rows)
                        {
                            Document TaskDocument = new Document();

                            if ((int)TaskDocumentRow["ID"] > 0)
                            {
                                TaskDocument.FileName = (string)TaskDocumentRow["Filename"];
                                TaskDocument.ID = (int)TaskDocumentRow["ID"];
                                TaskDocument.Name = (string)TaskDocumentRow["Name"];
                                TaskDocument.Path = (string)TaskDocumentRow["Path"];
                                TaskDocument.Public = (bool)TaskDocumentRow["PublicAccess"];

                                Documents.Add(TaskDocument);
                            }
                        }
                    }

                    ////////////////////////////////////////// Get Stores
                    string StoreQuery = "SELECT s.ID, ISNULL(s.Name,'') AS Name, ISNULL(s.RPMName,'') AS RPMName, ISNULL(s.Address,'') AS Address, ISNULL(s.Town,'') AS Town, ISNULL(s.State,'') AS State, ISNULL(s.Postcode,'') AS Postcode, ISNULL(s.Phone,'') AS Phone, ISNULL(s.Fax,'') AS Fax, ISNULL(s.Email,'') AS Email, ISNULL(s.Contact,'') AS Contact, ISNULL(s.MapURL,'') AS MapURL, ISNULL(s.OpenMonday,'') AS OpenMonday, ISNULL(s.CloseMonday,'') AS CloseMonday, ISNULL(s.OpenTuesday,'') AS OpenTuesday, ISNULL(s.CloseTuesday,'') AS CloseTuesday, ISNULL(s.OpenWednesday,'') AS OpenWednesday, ISNULL(s.CloseWednesday,'') AS CloseWednesday, ISNULL(s.OpenThursday,'') AS OpenThursday, ISNULL(s.CloseThursday,'') AS CloseThursday, ISNULL(s.OpenFriday,'') AS OpenFriday, ISNULL(s.CloseFriday,'') AS CloseFriday, ISNULL(s.OpenSaturday,'') AS OpenSaturday, ISNULL(s.CloseSaturday,'') AS CloseSaturday, ISNULL(s.OpenSunday,'') AS OpenSunday, ISNULL(s.CloseSunday,'') AS CloseSunday, ISNULL(s.OpenPublicHolidays,'') AS OpenPublicHolidays, ISNULL(s.ClosePublicHolidays,'') AS ClosePublicHolidays, ISNULL(s.ShowOnWebsite,'') AS ShowOnWebsite FROM TaskStore ts LEFT OUTER JOIN Store s ON ts.StoreID = s.ID WHERE ts.TaskID = " + TaskID.ToString();
                    List<Store> Stores = new List<Store>();

                    Cursor.Current = Cursors.WaitCursor;
                    DataSet TaskStoreData = Core.SQL.Functions.Execute(StoreQuery, Global.SqlConnectionString);
                    Cursor.Current = Cursors.Default;

                    if (TaskStoreData.Tables[0] != null)
                    {
                        foreach (DataRow TaskStoreRow in TaskStoreData.Tables[0].Rows)
                        {
                            Store TaskStore = new Store();

                            if ((int)TaskStoreRow["ID"] > 0)
                            {
                                TaskStore.ID = (int)TaskStoreRow["ID"];
                                TaskStore.Name = (string)TaskStoreRow["Name"];
                                TaskStore.RPMName = (string)TaskStoreRow["RPMName"];
                                TaskStore.Address = (string)TaskStoreRow["Address"];
                                TaskStore.Town = (string)TaskStoreRow["Town"];
                                TaskStore.State = (string)TaskStoreRow["State"];
                                TaskStore.Postcode = (string)TaskStoreRow["Postcode"];
                                TaskStore.Phone = (string)TaskStoreRow["Phone"];
                                TaskStore.Fax = (string)TaskStoreRow["Fax"];
                                TaskStore.Email = (string)TaskStoreRow["Email"];
                                TaskStore.Contact = (string)TaskStoreRow["Contact"];
                                TaskStore.MapURL = (string)TaskStoreRow["MapURL"];
                                TaskStore.OpenMonday = (string)TaskStoreRow["OpenMonday"];
                                TaskStore.CloseMonday = (string)TaskStoreRow["CloseMonday"];
                                TaskStore.OpenTuesday = (string)TaskStoreRow["OpenTuesday"];
                                TaskStore.CloseTuesday = (string)TaskStoreRow["CloseTuesday"];
                                TaskStore.OpenWednesday = (string)TaskStoreRow["OpenWednesday"];
                                TaskStore.CloseWednesday = (string)TaskStoreRow["CloseWednesday"];
                                TaskStore.OpenThursday = (string)TaskStoreRow["OpenThursday"];
                                TaskStore.CloseThursday = (string)TaskStoreRow["CloseThursday"];
                                TaskStore.OpenFriday = (string)TaskStoreRow["OpenFriday"];
                                TaskStore.CloseFriday = (string)TaskStoreRow["CloseFriday"];
                                TaskStore.OpenSaturday = (string)TaskStoreRow["OpenSaturday"];
                                TaskStore.CloseSaturday = (string)TaskStoreRow["CloseSaturday"];
                                TaskStore.OpenSunday = (string)TaskStoreRow["OpenSunday"];
                                TaskStore.CloseSunday = (string)TaskStoreRow["CloseSunday"];
                                TaskStore.OpenPublicHolidays = (string)TaskStoreRow["OpenPublicHolidays"];
                                TaskStore.ClosePublicHolidays = (string)TaskStoreRow["ClosePublicHolidays"];
                                TaskStore.ShowOnWebsite = (bool)TaskStoreRow["ShowOnWebsite"];

                                Stores.Add(TaskStore);
                            }
                        }
                    }

                    Task ThisTask = new Task();

                    ThisTask.CertificateID = (int)Row["CertificateID"];
                    ThisTask.CertificateName = (string)Row["CertificateName"];
                    ThisTask.Complete = (bool)Row["Complete"];
                    ThisTask.CreateDate = (DateTime)Row["CreateDate"];
                    ThisTask.CompletionDate = (DateTime)Row["CompletionDate"];
                    ThisTask.CompletedBy = (string)Row["FullName"];
                    ThisTask.CompletedStoreName = (string)Row["StoreName"];
                    ThisTask.Description = (string)Row["Description"];
                    ThisTask.DueDate = (DateTime)Row["DueDate"];
                    ThisTask.Enabled = (bool)Row["Enabled"];
                    ThisTask.ID = (int)Row["ID"];
                    ThisTask.Mandatory = (bool)Row["Mandatory"];
                    ThisTask.Name = (string)Row["Name"];
                    ThisTask.Recurrance = (string)Row["Recurrance"];
                    ThisTask.WarningPeriod = (int)Row["WarningPeriod"];

                    ThisTask.Documents = Documents;
                    ThisTask.Roles = Roles;
                    ThisTask.Stores = Stores;

                    Tasks.Add(ThisTask);
                }
            }

            TaskData.Dispose();

            return Tasks;
        }

        public static Color InvertColor(Color ColorToInvert)
        {
            return Color.FromArgb(255 - ColorToInvert.R, 255 - ColorToInvert.G, 255 - ColorToInvert.B);
        }

        public static List<Color> LoadTheme(int ThemeNumber)
        {
            List<Color> Theme = new List<Color>();
            string Filename = System.IO.Path.Combine(Application.StartupPath, "Colours.xml");

            XDocument document = XDocument.Load(Filename);

            var theme = (from t in document.Elements("Themes").Elements("Theme").Elements("Colour")
                         where t.Parent.Attribute("ID").Value.ToString() == (ThemeNumber + 1).ToString()
                         select Color.FromArgb(red: Convert.ToInt32(t.Element("Red").FirstAttribute.Value),
                                           green: Convert.ToInt32(t.Element("Green").FirstAttribute.Value),
                                           blue: Convert.ToInt32(t.Element("Blue").FirstAttribute.Value))
                        ).ToList();

            return (List<Color>)theme;
        }

        public static void OpenDocument(string Filename)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = Filename;
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        public static void PerformGoogleImageSearch(string Term)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = "http://www.google.com/search?tbm=isch&q=" + Term;
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        public static void PerformGoogleWebSearch(string Term)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = "http://www.google.com/search?as_q=" + Term;
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        public static void PerformWebMDSearch(string Term)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = "http://www.webmd.com/search/search_results/default.aspx?query=" + Term;
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        public static void PerformWikipediaWebSearch(string Term)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = "http://en.wikipedia.org/wiki/" + Term.Replace(" ", "_");
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static void RemoveFormFromList(Form form)
        {
            OpenForms.Remove(form);
        }

        public static bool WriteAllowed(string WritePermissionName)
        {
            return Global.Permissions.Contains("Write " + WritePermissionName);
        }
    }
}
