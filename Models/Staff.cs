using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Models
{
    public class Staff
    {
        public int StaffID { get; set; }

        public int UserID { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }
    }
}