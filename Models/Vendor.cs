using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Models
{
    public class Vendor
    {
        public int VendorID { get; set; }

        public string VendorName { get; set; }

        public string ServiceType { get; set; }

        public string ContactNumber { get; set; }
    }
}