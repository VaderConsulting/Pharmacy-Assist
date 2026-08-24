using RecurrenceGenerator;
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
    public partial class frmEvents005 : Form
    {
        private List<int> _Certificates = new List<int>();
        private int _CurrentEventID = 0;
        private string _CurrentRecurranceValue = "";
        private List<int> _Documents = new List<int>();
        private int _EventCertificateID = 0;
        private int _EventPresenterID = 0;
        private int _EventTypeID = 0;
        private List<int> _EventTypes = new List<int>();
        private List<int> _Owners = new List<int>();
        private int _OwnerUserAccountID = 0;
        private List<int> _Presenters = new List<int>();

        public frmEvents005()
        {
            InitializeComponent();
        }

        private void btnCertificate_Click(object sender, EventArgs e)
        {
            ChooseListItem("Certificate");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            ResetForm();

            txtEventDuration.Text = Properties.Settings.Default.EventDuration.ToString();
            txtWarningPeriod.Text = Properties.Settings.Default.EventWarningPeriod.ToString();

            btnCertificate.Enabled = true;
            btnDocuments.Enabled = true;
            btnEditPresenter.Enabled = true;
            btnOwner.Enabled = true;
            btnType.Enabled = true;
            btnSave.Enabled = true;

            txtEventName.Focus();
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (_CurrentEventID != 0)
            {
                string Query = "DELETE FROM Event WHERE ID = " + _CurrentEventID;

                Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                Global.GetAllEvents(lstItems);
                ResetForm();
            }
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            if (_CurrentEventID == 0)
            {
                MessageBox.Show("Please save the Event first", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmListItemSelection008 LinkedDocuments = new frmListItemSelection008(null, Helper.ItemType.Event);

                LinkedDocuments.ListDisplayName = "Documents";
                LinkedDocuments.SingleItemConstraint = false;
                LinkedDocuments.ParentObjectID = _CurrentEventID;
                LinkedDocuments.ReturnListOnly = false;

                LinkedDocuments.ShowDialog();
            }
        }

        private void btnEditFrequency_Click(object sender, EventArgs e)
        {
            frmRecurrance RecurranceForm = new frmRecurrance();

            RecurranceForm.ParentID = _CurrentEventID;
            RecurranceForm.ParentType = "Event";

            _CurrentRecurranceValue = "D" + dtpEventStart.Value.ToString("yyyyMMdd") + dtpEventStart.Value.AddDays(Convert.ToDouble(txtEventDuration.Text)).ToString("yyyyMMdd") + "000001001";

            // Give a recurrance value to build up from
            RecurranceForm.RecurranceValue = _CurrentRecurranceValue;

            RecurranceForm.ShowDialog();

            // Get the final recurrance value
            string Query = "SELECT Recurrance FROM Event WHERE ID = " + _CurrentEventID;

            DataSet Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);
            _CurrentRecurranceValue = Convert.ToString(Core.SQL.Functions.GetFieldFromDataRow(Core.SQL.Functions.GetDataRowFromDataset(Data, 0, 0), 0));   //RecurranceForm.RecurranceValue;

            //txtNextDate.Text = RecurrenceHelper.GetNextDate(DateTime.Now, _CurrentRecurranceValue).ToString("d MMM, yyyy");
            txtNextDate.Text = RecurrenceHelper.GetNextDate(dtpEventStart.Value, _CurrentRecurranceValue).ToString("d MMM, yyyy");

            radRecurring.Checked = true;

            switch (_CurrentRecurranceValue.Substring(0, 1))
            {
                case "D":
                    {
                        lblFrequency.Text = "Daily";
                        break;
                    }
                case "W":
                    {
                        lblFrequency.Text = "Weekly";
                        break;
                    }
                case "M":
                    {
                        lblFrequency.Text = "Monthly";
                        break;
                    }
                case "Y":
                    {
                        lblFrequency.Text = "Yearly";
                        break;
                    }
            }
        }

        private void btnEditPresenter_Click(object sender, EventArgs e)
        {
            ChooseListItem("Presenter");
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            ChooseListItem("User Account");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Global.GetAllEvents(lstItems);
            ResetForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ListItem SelectedItem = null;
            string Recurrance = "";
            string Query = "";
            string AllowTasks = "0";
            string EventEnabled = "0";

            if (chkAllowTasks.Checked) AllowTasks = "1";
            if (chkEnabled.Checked) EventEnabled = "1";

            // Build recurrance value
            if (radOnce.Checked)
            {
                // If we stored the single occurance the same way as multiples, it would be...
                //Recurrance = "D" + dtpEventStart.Value.ToString("yyyyMMdd") + dtpEventStart.Value.ToString("yyyyMMdd") + "000001001";
                Recurrance = dtpEventStart.Value.ToString();
            }
            else
            {
                Recurrance = _CurrentRecurranceValue;
            }

            if (_CurrentEventID == 0) // New event
            {
                Query = string.Format("INSERT INTO Event (" + 
                                      "Name, Description, StartDate, Duration, OwnerUserAccountID, AllowTask, TypeID, CertificateID, WarningPeriod, Recurrance, PresenterID, Enabled) " + 
                                      "VALUES (" +
                                      "'{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},'{9}',{10},{11}" +
                                      ")", 
                                      txtEventName.Text.Replace("'","''"),
                                      txtEventDescription.Text.Replace("'", "''"),
                                      dtpEventStart.Value.ToString("yyyyMMdd"),
                                      txtEventDuration.Text.Replace("'", "''"),
                                      _OwnerUserAccountID.ToString(),
                                      AllowTasks,
                                      _EventTypeID.ToString(),
                                      _EventCertificateID.ToString(),
                                      txtWarningPeriod.Text.Replace("'", "''"),
                                      Recurrance,
                                      _EventPresenterID.ToString(),
                                      EventEnabled
                                      );
            }
            else // Updated event
            {
                Query = string.Format("UPDATE Event SET Name='{0}', Description='{1}', StartDate='{2}', Duration={3}, OwnerUserAccountID={4}, AllowTask={5}, TypeID={6}, CertificateID={7}, WarningPeriod={8}, Recurrance='{9}', PresenterID={10}, Enabled={11} WHERE ID={12}",
                                      txtEventName.Text.Replace("'", "''"),
                                      txtEventDescription.Text.Replace("'", "''"),
                                      dtpEventStart.Value.ToString("yyyyMMdd"),
                                      txtEventDuration.Text.Replace("'", "''"),
                                      _OwnerUserAccountID.ToString(),
                                      AllowTasks,
                                      _EventTypeID.ToString(),
                                      _EventCertificateID.ToString(),
                                      txtWarningPeriod.Text.Replace("'", "''"),
                                      Recurrance,
                                      _EventPresenterID.ToString(),
                                      EventEnabled,
                                      _CurrentEventID.ToString()
                                     );
            }

            Cursor.Current = Cursors.WaitCursor;
            Core.SQL.Functions.ExecuteNonQuery(Query, Global.SqlConnectionString);
            Cursor.Current = Cursors.Default;

            if (lstItems.SelectedItem != null) SelectedItem = (ListItem)lstItems.SelectedItem;

            Global.GetAllEvents(lstItems);

            if (SelectedItem != null) lstItems.SelectedItem = SelectedItem;
            
        }

        private void btnStores_Click(object sender, EventArgs e)
        {
            if (_CurrentEventID == 0)
            {
                MessageBox.Show("Please save the Event first", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmListItemSelection008 SelectStoreForm = new frmListItemSelection008(null, Helper.ItemType.Event);

                SelectStoreForm.ListDisplayName = "Stores";
                SelectStoreForm.SingleItemConstraint = false;
                SelectStoreForm.ParentObjectID = _CurrentEventID;
                SelectStoreForm.ReturnListOnly = false;

                SelectStoreForm.ShowDialog();
            }
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            ChooseListItem("Event Type");
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChooseListItem(string ItemType)
        {
            frmListItemSelection008 ItemSelection = new frmListItemSelection008(null, Helper.ItemType.Event);
            ItemSelection.ListDisplayName = ItemType;
            ItemSelection.ParentObjectID = _CurrentEventID;
            ItemSelection.SingleItemConstraint = true;
            ItemSelection.ReturnListOnly = true;

            ItemSelection.ShowDialog();

            switch (ItemType)
            {
                case "Certificate":
                    {
                        _Certificates = ItemSelection.SelectedIDList;

                        if (_Certificates.Count > 0)
                        {
                            _EventCertificateID = _Certificates[0];
                            txtEventCertificate.Text = (string)Core.SQL.Functions.GetFieldFromDataRow(
                                                         Core.SQL.Functions.GetDataRowFromDataset(
                                                         Core.SQL.Functions.Execute(
                                                         "SELECT Name FROM Certificate WHERE ID = " + _EventCertificateID.ToString(),
                                                         Global.SqlConnectionString), 0, 0), 0);
                        }
                        else
                        { 
                            _EventCertificateID = 0;
                            txtEventCertificate.Text = "";
                        }
                        break;
                    }
                case "Presenter":
                    {
                        _Presenters = ItemSelection.SelectedIDList;

                        if (_Presenters.Count > 0)
                        {
                            _EventPresenterID = _Presenters[0];
                            txtEventPresenter.Text = (string)Core.SQL.Functions.GetFieldFromDataRow(
                                                         Core.SQL.Functions.GetDataRowFromDataset(
                                                         Core.SQL.Functions.Execute(
                                                         "SELECT FirstName + ' ' + LastName AS Fullname FROM UserAccount WHERE ID = " + _EventPresenterID.ToString(),
                                                         Global.SqlConnectionString), 0, 0), 0);
                        }
                        else
                        {
                            _EventPresenterID = 0;
                            txtEventPresenter.Text = "";
                        }
                        break;
                    }
                case "User Account":
                    {
                        _Owners = ItemSelection.SelectedIDList;

                        if (_Owners.Count > 0)
                        {
                            _OwnerUserAccountID = _Owners[0];
                            txtEventOwner.Text = (string)Core.SQL.Functions.GetFieldFromDataRow(
                                                         Core.SQL.Functions.GetDataRowFromDataset(
                                                         Core.SQL.Functions.Execute(
                                                         "SELECT FirstName + ' ' + LastName AS Fullname FROM UserAccount WHERE ID = " + _OwnerUserAccountID.ToString(),
                                                         Global.SqlConnectionString), 0, 0), 0);
                        }
                        else
                        {
                            _OwnerUserAccountID = 0;
                            txtEventOwner.Text = "";
                        }
                        break;
                    }
                case "Event Type":
                    {
                        _EventTypes = ItemSelection.SelectedIDList;

                        if (_EventTypes.Count > 0)
                        {
                            _EventTypeID = _EventTypes[0];
                            txtEventType.Text = (string)Core.SQL.Functions.GetFieldFromDataRow(
                                                         Core.SQL.Functions.GetDataRowFromDataset(
                                                         Core.SQL.Functions.Execute(
                                                         "SELECT Name FROM EventType WHERE ID = " + _EventTypeID.ToString(),
                                                         Global.SqlConnectionString), 0, 0), 0);
                        }
                        else
                        {
                            _EventTypeID = 0;
                            txtEventType.Text = "";
                        }

                        break;
                    }
            }
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            gpTitle.Image = PharmacyAssist.Properties.Resources.vista_business_meeting_256;
            gpTitle.GradientStartColor = Global.Theme[7];
            
            Global.AddFormToList(this);

            Global.GetAllEvents(lstItems);

            ResetForm();
        }

        private void frmEvents005_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.RemoveFormFromList(this);
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem != null)
            {
                string Query = "";
                string Recurrance = "";
                DataSet Data = null;

                ResetForm();

                _CurrentEventID = ((ListItem)(lstItems.SelectedItem)).ID;

                Query = "SELECT e.ID, ISNULL(e.Name,'') AS EventName, ISNULL(e.Description,'') As EventDescription, StartDate, Duration, AllowTask, WarningPeriod, ISNULL(uu.Firstname + ' ' + uu.lastname,'') AS PresenterName, e.Enabled AS EventEnabled, ISNULL(et.Name,'') AS EventType, ISNULL(u.Firstname + ' ' + u.lastname,'') AS OwnerName, ISNULL(c.Name,'') As CertificateName, Recurrance, e.OwnerUserAccountID, e.CertificateID, e.PresenterID, e.TypeID FROM Event e left join EventType et on e.TypeID = et.ID left join useraccount u on u.ID = e.OwneruserAccountID left join certificate c on c.ID = e.CertificateID left join useraccount uu on uu.ID = e.PresenterID WHERE e.ID = " + _CurrentEventID;

                Data = Core.SQL.Functions.Execute(Query, Global.SqlConnectionString);

                txtEventName.Text = (string)Data.Tables[0].Rows[0]["EventName"];
                txtEventDescription.Text = (string)Data.Tables[0].Rows[0]["EventDescription"];
                dtpEventStart.Value = (DateTime)Data.Tables[0].Rows[0]["StartDate"];
                txtEventDuration.Text = Convert.ToInt32(Data.Tables[0].Rows[0]["Duration"]).ToString();
                chkEnabled.Checked = ((bool)Data.Tables[0].Rows[0]["EventEnabled"]);
                chkAllowTasks.Checked = ((bool)Data.Tables[0].Rows[0]["AllowTask"]);
                txtEventOwner.Text = (string)Data.Tables[0].Rows[0]["OwnerName"];
                txtEventPresenter.Text = (string)Data.Tables[0].Rows[0]["PresenterName"];
                txtEventCertificate.Text = (string)Data.Tables[0].Rows[0]["CertificateName"];
                txtEventType.Text = (string)Data.Tables[0].Rows[0]["EventType"];
                txtWarningPeriod.Text = ((int)Data.Tables[0].Rows[0]["WarningPeriod"]).ToString();
                _OwnerUserAccountID = ((int)Data.Tables[0].Rows[0]["OwnerUserAccountID"]);
                _EventCertificateID = ((int)Data.Tables[0].Rows[0]["CertificateID"]);
                _EventPresenterID = ((int)Data.Tables[0].Rows[0]["PresenterID"]);
                _EventTypeID = ((int)Data.Tables[0].Rows[0]["TypeID"]);

                if (Data.Tables[0].Rows[0]["Recurrance"] != null && Data.Tables[0].Rows[0]["Recurrance"].ToString().Trim() != "")
                {
                    Recurrance = (string)Data.Tables[0].Rows[0]["Recurrance"];

                    if (Microsoft.VisualBasic.Information.IsDate(Recurrance))
                    {
                        _CurrentRecurranceValue = Recurrance;
                        txtNextDate.Text = "";
                        radOnce.Checked = true;
                    }
                    else
                    {
                        _CurrentRecurranceValue = Recurrance;
                        txtNextDate.Text = RecurrenceHelper.GetNextDate(DateTime.Now, _CurrentRecurranceValue).ToString("d MMM, yyyy");
                        radRecurring.Checked = true;

                        switch (_CurrentRecurranceValue.Substring(0, 1))
                        {
                            case "D":
                                {
                                    lblFrequency.Text = "Daily";
                                    break;
                                }
                            case "W":
                                {
                                    lblFrequency.Text = "Weekly";
                                    break;
                                }
                            case "M":
                                {
                                    lblFrequency.Text = "Monthly";
                                    break;
                                }
                            case "Y":
                                {
                                    lblFrequency.Text = "Yearly";
                                    break;
                                }
                        }
                    }
                }
                
                btnCertificate.Enabled = true;
                btnDocuments.Enabled = true;
                btnOwner.Enabled = true;
                btnType.Enabled = true;
                btnEditFrequency.Enabled = true;
                btnEditPresenter.Enabled = true;
                btnDeleteEvent.Enabled = true;
                btnSave.Enabled = true;
                btnStores.Enabled = true;

                // Documents
                //int DocumentCount = Global.GetRecordCount("Document d INNER JOIN EventDocument ed ON d.ID = ed.DocumentID INNER JOIN Event e ON e.ID = ed.EventID WHERE e.id = " + _CurrentEventID);

                Global.GetListItemData("SELECT d.ID, d.Name FROM Document d INNER JOIN EventDocument ed ON ed.DocumentID = d.ID INNER JOIN Event e ON e.ID = ed.EventID WHERE e.ID = " + _CurrentEventID.ToString(), lstDocuments);

                // Stores
                //int StoreCount = Global.GetRecordCount("Store s INNER JOIN EventStore es ON s.ID = es.StoreID INNER JOIN Event e ON e.ID = es.EventID WHERE e.id = " + _CurrentEventID);

                Global.GetListItemData("SELECT s.ID, s.Name FROM Store s INNER JOIN EventStore es ON es.StoreID = s.ID INNER JOIN Event e ON e.ID = es.EventID WHERE e.ID =" + _CurrentEventID.ToString(), lstStores);
            }
        }

        private void radOnce_CheckedChanged(object sender, EventArgs e)
        {
            grpRecurring.Enabled = radRecurring.Enabled;
        }

        private void radRecurring_CheckedChanged(object sender, EventArgs e)
        {
            grpRecurring.Enabled = radRecurring.Enabled;
        }

        private void ResetForm()
        {
            txtEventCertificate.Text = "";
            txtEventDescription.Text = "";
            txtEventName.Text = "";
            txtEventOwner.Text = "";
            txtEventType.Text = "";
            txtNextDate.Text = "";
            txtWarningPeriod.Text = "";
            txtEventPresenter.Text = "";
            txtEventDuration.Text = "";

            lblFrequency.Text = "";

            chkEnabled.Checked = false;
            chkAllowTasks.Checked = false;
            
            dtpEventStart.Value = DateTime.Now;

            btnCertificate.Enabled = false;
            btnDocuments.Enabled = false;
            btnOwner.Enabled = false;
            btnEditPresenter.Enabled = false;
            btnType.Enabled = false;
            //btnEditFrequency.Enabled = false;
            btnDeleteEvent.Enabled = false;
            btnCreateEvent.Enabled = true;
            btnStores.Enabled = false;
            btnSave.Enabled = false;

            lstDocuments.Items.Clear();
            lstStores.Items.Clear();

            radOnce.Checked = false;
            radRecurring.Checked = false;

            _CurrentEventID = 0;
            _CurrentRecurranceValue = "";
            _EventCertificateID = 0;
            _EventPresenterID = 0;
            _EventTypeID = 0;
            _EventTypes.Clear();
            _Owners.Clear();
            _OwnerUserAccountID = 0;
            _Presenters.Clear();
            _Documents.Clear();
        }
    }
}
