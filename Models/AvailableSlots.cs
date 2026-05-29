using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Models
{
    public class AvailableSlot
    {
        public int SlotID { get; set; }

        public int EventID { get; set; }

        public int AvailableSeats { get; set; }
    }
}
