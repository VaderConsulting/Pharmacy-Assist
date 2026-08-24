using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyAssist
{
    public class FileEntry
    {
        public string Filename { get; set; }
        //public long Size { get; set; }
        //public DateTime LastModified { get; set; }
        public bool IsFolder { get; set; }
        public string Path { get; set; }
        //public FTPEntry Parent { get; set; }
        //public List<FTPEntry> Children { get; set; }

        public FileEntry()
        {
            New();
        }

        public FileEntry(string ParentPath, string RawData)
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

                Filename = RawData.Substring(39); // remainder of string is filename
                Path = ParentPath;
            }
        }

        //public bool HasParent()
        //{
        //    if (Parent != null) return true;

        //    return false;
        //}

        //public bool HasChildren()
        //{
        //    if (Children.Count > 0) return true;

        //    return false;
        //}

        private void New()
        {
            Filename = "";
            //Size = 0;
            //LastModified = DateTime.MinValue;
            IsFolder = false;
            Path = "";
            //Parent = null;
            //Children = null;
        }

    }
}
