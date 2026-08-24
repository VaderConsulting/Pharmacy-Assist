using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyAssist
{
    public class DatabaseColumn
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public Type DataType { get; set; }
        public int Index { get; set; }

        public override string ToString()
        {
            return "{" + Name.ToString() + "} " + Value.ToString();
        }
    }
}
