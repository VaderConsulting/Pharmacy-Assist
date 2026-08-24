using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyAssist
{
    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
        public DateTime CreateDate {get; set;}
        public DateTime CompletionDate {get; set;}
        public int CertificateID { get; set; }
        public string CertificateName { get; set; }
        public int WarningPeriod { get; set; }
        public string Recurrance { get; set; }
        public string CompletedBy { get; set; }
        public string CompletedStoreName { get; set; }
        public bool Enabled { get; set; }
        public DateTime DueDate { get; set; }
        public List<Role> Roles { get; set; }
        public List<Document> Documents { get; set; }
        public List<Store> Stores { get; set; }
        public bool Mandatory { get; set; }

        public Task()
        {
            ID = 0;
            Name = "";
            Description = "";
            Complete = false;
            CreateDate = DateTime.MinValue;
            CompletionDate = DateTime.MaxValue;
            CertificateID = 0;
            CertificateName = "";
            WarningPeriod = 0;
            Recurrance = "";
            CompletedBy = "";
            CompletedStoreName = "";
            Enabled = false;
            DueDate = DateTime.MaxValue;
            Roles = new List<Role>();
            Documents = new List<Document>();
            Stores = new List<Store>();
            Mandatory = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
