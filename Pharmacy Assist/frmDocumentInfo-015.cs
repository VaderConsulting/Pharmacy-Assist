using BrendanGrant.Helpers.FileAssociation;
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
    public partial class frmDocumentInfo : Form
    {
        public Document ThisDocument { get; set; }
        public Document ThisFile { get; set; }

        public frmDocumentInfo()
        {
            InitializeComponent();
        }

        private void btnAcceptEdits_Click(object sender, EventArgs e)
        {
            int RecordID = 0;
            string Query = "";
            string Public = "0";
            string FreeService = "0";
            DataSet Data = null;
            
            #region Conditions

            if (Global.Permissions.Contains("Write Condition"))
            {
                lblStatus.Text = "Saving Conditions";
                this.Refresh();
                
                // AUDITING
                Query = "SELECT ID, ConditionID, DocumentID FROM ConditionDocument WHERE DocumentID = " + ThisDocument.ID;
                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
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
                Query = "DELETE FROM ConditionDocument WHERE DocumentID = " + ThisDocument.ID;

                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                // Go through the selected Conditions for this Document
                foreach (ListItem Condition in lstExistingConditions.Items)
                {
                    Query = "INSERT INTO ConditionDocument (ConditionID, DocumentID) VALUES (" + Condition.ID + "," + ThisDocument.ID + ");SELECT SCOPE_IDENTITY()";

                    Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                    RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                    // AUDITING
                    Global.Audit("Insert", "ConditionDocument", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "ConditionDocument", "DocumentID", RecordID, Global.Username.Replace("'", "''"), "", ThisDocument.ID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "ConditionDocument", "ConditionID", RecordID, Global.Username.Replace("'", "''"), "", Condition.ID.ToString(), Application.ProductName, false);
                }
            }

            #endregion

            #region Events

            if (Global.Permissions.Contains("Write Event"))
            {
                lblStatus.Text = "Saving Events";
                this.Refresh();
                
                // AUDITING
                Query = "SELECT ID, EventID, DocumentID FROM EventDocument WHERE DocumentID = " + ThisDocument.ID;
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

                // Delete all existing linking for this linked ItemID
                Query = "DELETE FROM EventDocument WHERE DocumentID = " + ThisDocument.ID;

                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                // Go through the selected Conditions for this Document
                foreach (ListItem Event in lstExistingEvents.Items)
                {
                    Query = "INSERT INTO EventDocument (EventID, DocumentID) VALUES (" + Event.ID + "," + ThisDocument.ID + ");SELECT SCOPE_IDENTITY()";

                    Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                    RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                    // AUDITING
                    Global.Audit("Insert", "EventDocument", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "EventDocument", "DocumentID", RecordID, Global.Username.Replace("'", "''"), "", ThisDocument.ID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "EventDocument", "EventID", RecordID, Global.Username.Replace("'", "''"), "", Event.ID.ToString(), Application.ProductName, false);
                }
            }

            #endregion

            #region Tasks

            if (Global.Permissions.Contains("Write Task"))
            {
                lblStatus.Text = "Saving Tasks";
                this.Refresh();
                
                // AUDITING
                Query = "SELECT ID, TaskID, DocumentID FROM TaskDocument WHERE DocumentID = " + ThisDocument.ID;
                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
                if (Data.Tables.Count == 1)
                {
                    foreach (DataRow Row in Data.Tables[0].Rows)
                    {
                        Global.Audit("Delete", "TaskDocument", "ID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["ID"].ToString(), "", Application.ProductName, false);
                        Global.Audit("Delete", "TaskDocument", "TaskID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["TaskID"].ToString(), "", Application.ProductName, false);
                        Global.Audit("Delete", "TaskDocument", "DocumentID", (int)Row["ID"], Global.Username.Replace("'", "''"), Row["DocumentID"].ToString(), "", Application.ProductName, false);
                    }
                }

                // Delete all existing linking for this linked ItemID
                Query = "DELETE FROM TaskDocument WHERE DocumentID = " + ThisDocument.ID;

                Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

                // Go through the selected Conditions for this Document
                foreach (ListItem Task in lstExistingTasks.Items)
                {
                    Query = "INSERT INTO TaskDocument (TaskID, DocumentID) VALUES (" + Task.ID + "," + ThisDocument.ID + ");SELECT SCOPE_IDENTITY()";

                    Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                    RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

                    // AUDITING
                    Global.Audit("Insert", "TaskDocument", "ID", RecordID, Global.Username.Replace("'", "''"), "", RecordID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "TaskDocument", "DocumentID", RecordID, Global.Username.Replace("'", "''"), "", ThisDocument.ID.ToString(), Application.ProductName, false);
                    Global.Audit("Insert", "TaskDocument", "TaskID", RecordID, Global.Username.Replace("'", "''"), "", Task.ID.ToString(), Application.ProductName, false);
                }
            }

            #endregion

            // General information
            lblStatus.Text = "Saving Document";
            this.Refresh();
            if (chkPublic.Checked) Public = "1";
            if (chkFreeService.Checked) FreeService = "1";
            Query = string.Format("UPDATE Document SET Name = '{0}', PublicAccess = {1}, FreeService = {2}, Keywords = '{3}' WHERE ID = {4}", txtDocumentName.Text.Replace("'", "''"), Public, FreeService, txtKeywords.Text.Replace("'", "''"), ThisDocument.ID);

            Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);

            // Keep GUI results so they can be picked up by the calling form
            ThisDocument.Name = txtDocumentName.Text;
            ThisDocument.Public = chkPublic.Checked;
            ThisDocument.FreeService = chkFreeService.Checked;
            ThisDocument.Keywords = txtKeywords.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstSourceConditions, lstExistingConditions, Helper.ItemType.Condition);
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstSourceEvents, lstExistingEvents, Helper.ItemType.Event);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstSourceTasks, lstExistingTasks, Helper.ItemType.Task);
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnCreateDocument_Click(object sender, EventArgs e)
        {
            string Query = "";
            DataSet Data = null;
            int RecordID = 0;
            ThisDocument = new Document();

            ThisDocument.ID = 0;
            ThisDocument.FileName = ThisFile.FileName;
            ThisDocument.Keywords = "";
            ThisDocument.Name = txtDocumentName.Text;
            ThisDocument.Path = ThisFile.Path;
            ThisDocument.Public = chkPublic.Checked;

            Query = string.Format("INSERT INTO Document (Name, Filename, Path) VALUES ('{0}','{1}','{2}');SELECT SCOPE_IDENTITY()", ThisDocument.Name.Replace("'", "''"), ThisDocument.FileName.Replace("'", "''"), ThisDocument.Path.Replace("'", "''"));

            Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            RecordID = Convert.ToInt32(Data.Tables[0].Rows[0][0]);

            ThisDocument.ID = RecordID;

            if (RecordID > 0)
            {
                picNoDocument.Visible = false;
                lblNoDocument.Visible = false;
                btnCreateDocument.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoStartup();
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstExistingConditions, lstSourceConditions, Helper.ItemType.Condition);
        }

        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstExistingEvents, lstSourceEvents, Helper.ItemType.Event);
        }

        private void DoStartup()
        {
            if (ThisDocument != null)
            {
                string Extension = System.IO.Path.GetExtension(ThisDocument.FileName);

                FileAssociationInfo fai = new FileAssociationInfo(Extension);
                ProgramAssociationInfo pai = new ProgramAssociationInfo(fai.ProgID);
                ProgramIcon icon = pai.DefaultIcon;

                if (icon.Path != "")
                {
                    if (icon.Path.Contains("%")) icon.Path = System.Environment.ExpandEnvironmentVariables(icon.Path);
                    picDocument.Image = System.Drawing.Icon.ExtractAssociatedIcon(icon.Path).ToBitmap();
                }
                else
                    picDocument.Image = Properties.Resources.supervista_general_book_32;

                this.Text = ThisDocument.FileName;
                chkPublic.Checked = ThisDocument.Public;
                chkFreeService.Checked = ThisDocument.FreeService;
                txtDocumentName.Text = ThisDocument.Name;
                txtKeywords.Text = ThisDocument.Keywords;
                lblPathValue.Text = ThisDocument.Path;

                picNoDocument.Visible = false;
                lblNoDocument.Visible = false;
                btnCreateDocument.Visible = false;
            }
            else
            {
                this.Text = ThisFile.FileName;
                txtDocumentName.Text = System.IO.Path.GetFileNameWithoutExtension(ThisFile.FileName);
                txtKeywords.Text = "";
                lblPathValue.Text = ThisFile.Path;

                picNoDocument.Visible = true;
                lblNoDocument.Visible = true;
                btnCreateDocument.Visible = Global.Permissions.Contains("Create Document");
            }

            if (Global.Permissions.Contains("Write Document"))
            {
                chkFreeService.Enabled = true;
                chkPublic.Enabled = true;
                txtDocumentName.ReadOnly = false;
                txtKeywords.ReadOnly = false;
            }
            else
            {
                chkFreeService.Enabled = false;
                chkPublic.Enabled = false;
                txtDocumentName.ReadOnly = true;
                txtKeywords.ReadOnly = true;
            }

            this.Show();
            this.Refresh(); ;

            PopulateListboxes();
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstExistingTasks, lstSourceTasks, Helper.ItemType.Task);
        }

        private void frmDocumentInfo_Load(object sender, EventArgs e)
        {
            DoStartup();
        }

        private void GetDocumentConditions()
        {
            string Query = "";
            lstExistingConditions.Items.Clear();
            
            Query = "SELECT c.ID, c.Name from dbo.Condition c INNER JOIN dbo.ConditionDocument cd ON cd.ConditionId = c.ID INNER JOIN dbo.Document d ON cd.DocumentID = d.ID WHERE d.ID = " + ThisDocument.ID;

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem Condition = new ListItem((int)Row["ID"], (string)Row["Name"]);

                lstExistingConditions.Items.Add(Condition);
            }
        }

        private void GetDocumentEvents()
        {
            string Query = "";
            lstExistingEvents.Items.Clear();

            Query = "SELECT e.ID, e.Name FROM Event e INNER JOIN EventDocument ed ON ed.EventId = e.ID INNER JOIN Document d ON ed.DocumentID = d.ID WHERE d.ID = " + ThisDocument.ID;

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem Condition = new ListItem((int)Row["ID"], (string)Row["Name"]);

                lstExistingEvents.Items.Add(Condition);
            }
        }

        private void GetDocumentTasks()
        {
            string Query = "";
            lstExistingTasks.Items.Clear();

            Query = "SELECT t.ID, t.Name FROM Task t INNER JOIN TaskDocument td ON td.TaskId = t.ID INNER JOIN Document d ON td.DocumentID = d.ID WHERE d.ID = " + ThisDocument.ID;

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

            foreach (DataRow Row in Data.Tables[0].Rows)
            {
                ListItem Condition = new ListItem((int)Row["ID"], (string)Row["Name"]);

                lstExistingTasks.Items.Add(Condition);
            }
        }

        private void lstExistingConditions_DoubleClick(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstExistingConditions, lstSourceConditions, Helper.ItemType.Condition);
        }

        private void lstExistingConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveCondition.Enabled = Global.Permissions.Contains("Write Document") && Global.Permissions.Contains("Write Condition") && lstExistingConditions.SelectedItem != null;
        }

        private void lstExistingEvents_DoubleClick(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstExistingEvents, lstSourceEvents, Helper.ItemType.Event);
        }

        private void lstExistingEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveEvent.Enabled = Global.Permissions.Contains("Write Document") && Global.Permissions.Contains("Write Event") && lstExistingEvents.SelectedItem != null;
        }

        private void lstExistingTasks_DoubleClick(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstExistingTasks, lstSourceTasks, Helper.ItemType.Task);
        }

        private void lstExistingTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveTask.Enabled = Global.Permissions.Contains("Write Document") && Global.Permissions.Contains("Write Task") && lstExistingTasks.SelectedItem != null;
        }

        private void lstSourceConditions_DoubleClick(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstSourceConditions, lstExistingConditions, Helper.ItemType.Condition);
        }

        private void lstSourceConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddCondition.Enabled = Global.Permissions.Contains("Write Document") && Global.Permissions.Contains("Write Condition") && lstSourceConditions.SelectedItem != null;
        }

        private void lstSourceEvents_DoubleClick(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstSourceEvents, lstExistingEvents, Helper.ItemType.Event);
        }

        private void lstSourceEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddEvent.Enabled = Global.Permissions.Contains("Write Document") && Global.Permissions.Contains("Write Event") && lstSourceEvents.SelectedItem != null;
        }

        private void lstSourceTasks_DoubleClick(object sender, EventArgs e)
        {
            MoveItemBetweenListboxes(lstSourceTasks, lstExistingTasks, Helper.ItemType.Task);
        }

        private void lstSourceTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddTask.Enabled = Global.Permissions.Contains("Write Document") && Global.Permissions.Contains("Write Task") && lstSourceTasks.SelectedItem != null;
        }

        private void MoveItemBetweenListboxes(ListBox Source, ListBox Destination, PharmacyAssist.Helper.ItemType ItemType)
        {
            if (Global.WriteAllowed(PharmacyAssist.Helper.ItemTypeName((int)ItemType)))
            {
                Source.BeginUpdate();
                Destination.BeginUpdate();

                for (int i = Source.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    ListItem Item = (ListItem)Source.Items[Source.SelectedIndices[i]];
                    Destination.Items.Add(Item);
                    Source.Items.RemoveAt(Source.SelectedIndices[i]);
                }

                Source.EndUpdate();
                Destination.EndUpdate();
            }
        }

        private void PopulateListboxes()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (Global.Permissions.Contains("Read Condition"))
            {
                lblStatus.Text = "Loading Conditions";
                this.Refresh();
                Global.GetAllConditions(lstSourceConditions);
                if (ThisDocument != null) GetDocumentConditions();
                RemoveItemsInSelectionListFromItemList(lstSourceConditions, lstExistingConditions);
                tabConditions.Enabled = true;
            }
            else
            {
                tabConditions.Enabled = true;
            }

            if (Global.Permissions.Contains("Read Event"))
            {
                lblStatus.Text = "Loading Events";
                this.Refresh();
                Global.GetAllEvents(lstSourceEvents);
                if (ThisDocument != null) GetDocumentEvents();
                RemoveItemsInSelectionListFromItemList(lstSourceEvents, lstExistingEvents);
                tabEvents.Enabled = true;
            }
            else
            {
                tabEvents.Enabled = false;
            }

            if (Global.Permissions.Contains("Read Task"))
            {
                lblStatus.Text = "Loading Tasks";
                this.Refresh();
                Global.GetIncompleteTasks(lstSourceTasks);
                if (ThisDocument != null) GetDocumentTasks();
                RemoveItemsInSelectionListFromItemList(lstSourceTasks, lstExistingTasks);
                tabTasks.Enabled = true;
            }
            else
            {
                tabTasks.Enabled = false;
            }

            btnAcceptEdits.Enabled = Global.Permissions.Contains("Write Document");

            lblStatus.Text = "Idle";
            this.Refresh();

            Cursor.Current = Cursors.Default;
        }

        private void RemoveItemsInSelectionListFromItemList(ListBox Source, ListBox Destination)
        {
            for (int i = 0; i < Destination.Items.Count; i++)
            {
                ListItem Item = (ListItem)Destination.Items[i];
                int ID = Item.ID;
                string Name = Item.Name;
                if (Source.Items.Contains(Item))
                {
                    Source.Items.Remove(Item);
                }

            }
        }

        private void tabInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        
    }
}
