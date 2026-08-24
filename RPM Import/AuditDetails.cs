using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPM_Import
{
    public class AuditDetails
    {
        public string Description { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public int RecordID { get; set; }
        public string UserName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public string ApplicationName { get; set; }

        public AuditDetails()
        {
            Description = "";
            TableName = "";
            FieldName = "";
            RecordID = 0;
            UserName = "";
            PreviousValue = "";
            NewValue = "";
            ApplicationName = Application.ProductName;
        }
    }
}
