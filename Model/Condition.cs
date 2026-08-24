using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Condition
    {
        public int ID {get; set;}
        public string Name { get; set; }

        public Condition()
        {
            ID = 0;
            Name = "";
        }
    }
}
