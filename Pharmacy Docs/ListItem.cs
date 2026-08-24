using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PharmacyAssist
{
    public class ListItem : Object
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Color BackColour { get; set; }
        public Color ForeColour { get; set; }
        public object Tag { get; set; }
        
        public ListItem()
        { }

        public ListItem(int ItemID, string ItemName)
        {
            ID = ItemID;
            Name = ItemName;
            BackColour = Color.White;
            ForeColour = Color.Black;
        }

        public ListItem(int ItemID, string ItemName, Color BackgroundColour, Color ForegroundColour)
        {
            ID = ItemID;
            Name = ItemName;
            BackColour = BackgroundColour;
            ForeColour = ForegroundColour;
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToString(bool ID)
        {
            if (ID)
            { 
                return ID.ToString(); 
            }
            else
            {
                return Name.ToString();
            }
        }

        // Provide a test for the equals (=) operator to allow the ListItem to be compared for Value equality
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            ListItem Comparison = (ListItem)obj;

            // Check Name only for equality as this is the only thing seen in the listbox
            return (Comparison.Name == this.Name);
        }

        // Should be over-ridden by Value-types
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ ID;
        }
    }
}
