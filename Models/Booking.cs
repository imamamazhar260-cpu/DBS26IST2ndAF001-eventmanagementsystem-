using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventManagementSystem.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int CustomerID { get; set; }

        public int EventID { get; set; }

        public DateTime BookingDate { get; set; }

        public int NumberOfTickets { get; set; }

        public string BookingStatus { get; set; }
    }
}