using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RPMName { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string MapURL { get; set; }
        public string OpenMonday { get; set; }
        public string CloseMonday { get; set; }
        public string OpenTuesday { get; set; }
        public string CloseTuesday { get; set; }
        public string OpenWednesday { get; set; }
        public string CloseWednesday { get; set; }
        public string OpenThursday { get; set; }
        public string CloseThursday { get; set; }
        public string OpenFriday { get; set; }
        public string CloseFriday { get; set; }
        public string OpenSaturday { get; set; }
        public string CloseSaturday { get; set; }
        public string OpenSunday { get; set; }
        public string CloseSunday { get; set; }
        public string OpenPublicHolidays { get; set; }
        public string ClosePublicHolidays { get; set; }
        public bool ShowOnWebsite { get; set; }
    }
}
