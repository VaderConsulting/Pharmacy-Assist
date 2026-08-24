using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyAssist
{
    public class Helper
    {
        public enum ItemType
        {
            None = -1,
            ActiveIngredient = 0,
            Brand = 1,
            Category = 2,
            Certificate = 3,
            Condition = 4,
            Document = 5,
            EndUse = 6,
            Event = 7,
            EventType = 8,
            Permission = 9,
            Presenter = 10,
            Role = 11,
            Schedule = 12,
            Store = 13,
            UnitOfMeasure = 14,
            UserAccount = 15,
            Product = 16,
            Task = 17,
            Catalog = 18
        }

        public static string ItemTypeName(int ItemTypeID)
        {
            string Value = "";

            switch (ItemTypeID)
            {
                case -1:
                    Value = "";
                    break;
                case 0:
                    Value = "Active Ingredient";
                    break;
                case 1:
                    Value = "Brand";
                    break;
                case 2:
                    Value = "Category";
                    break;
                case 3:
                    Value = "Certificate";
                    break;
                case 4:
                    Value = "Condition";
                    break;
                case 5:
                    Value = "Document";
                    break;
                case 6:
                    Value = "End Use";
                    break;
                case 7:
                    Value = "Event";
                    break;
                case 8:
                    Value = "Event Type";
                    break;
                case 9:
                    Value = "Permission";
                    break;
                case 10:
                    Value = "Presenter";
                    break;
                case 11:
                    Value = "Role";
                    break;
                case 12:
                    Value = "Schedule";
                    break;
                case 13:
                    Value = "Store";
                    break;
                case 14:
                    Value = "Unit Of Measure";
                    break;
                case 15:
                    Value = "User Account";
                    break;
                case 16:
                    Value = "Product";
                    break;
                case 17:
                    Value = "Task";
                    break;
                case 18:
                    Value = "Catalog";
                    break;
            }

            return Value;
        }

    }
}
