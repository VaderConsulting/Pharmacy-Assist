using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPM_Import
{
    public class RPMProduct
    {
        public int RPMID { get; set; }
        public int ProductID { get; set; }
        public int UPI { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldRecommendedPrice { get; set; }
        public decimal NewRecommendedPrice { get; set; }
        public string Name { get; set; }
        public bool CoreProduct { get; set; }
        public int UpdateType { get; set; }
        public RPMProduct()
        {
            RPMID = 0;
            ProductID = 0;
            UPI = 0;
            OldPrice = 0.0M;
            NewPrice = 0.0M;
            OldRecommendedPrice = 0.0M;
            NewRecommendedPrice = 0.0M;
            Name = "";
            CoreProduct = false;
            UpdateType = 0;
        }
    }
}
