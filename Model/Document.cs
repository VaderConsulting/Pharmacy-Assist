using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Document
    {   
        public int ID { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Keywords { get; set; }
        public bool Public { get; set; }
        public bool IsFolder { get; set; }
        public bool FreeService { get; set; }
        public List<Condition> Conditions { get; set; }
        
        public Document()
        {
            New();
        }

        public Document(string ParentPath, string RawData)
        {
            New();

            if (RawData.Length > 38) // Minimum length to contain a single character entry name is 39
            {
                // 08-13-13  05:09AM       <DIR>          _database

                // Get Date
                //string Month = RawData.Substring(0, 2);
                //string Day = RawData.Substring(3, 2);
                //string Year = RawData.Substring(6, 2);

                // Get Time
                //string Hour = RawData.Substring(10, 2);
                //string Minute = RawData.Substring(13, 2);
                //string AMPM = RawData.Substring(15, 2);

                string Dir = RawData.Substring(24, 5);

                IsFolder = (Dir == "<DIR>");

                FileName = RawData.Substring(39); // remainder of string is filename

                if (IsFolder)
                {
                    Path = ParentPath + "/" + FileName;
                }
                else
                {
                    Path = ParentPath;
                }
                
            }
        }

        public override string ToString()
        {
            return Name;
        }

        private void New()
        {
            ID = 0;
            FileName = "";
            Name = "";
            Path = "";
            Keywords = "";
            Public = false;
            IsFolder = false;
            FreeService = false;
            Conditions = new List<Condition>();
        }

        // Provide a test for the equals (=) operator to allow the Document to be compared for Value equality
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            Document Comparison = (Document)obj;

            // Check Name only for equality as this is the only thing seen in the listbox
            return (Comparison.Path.ToLower() + Comparison.FileName.ToLower() == this.Path.ToLower() + this.FileName.ToLower());
        }

        // Should be over-ridden by Value-types
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ ID;
        }
    }
}
