using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        public int BookingID { get; set; }

        public string TicketNumber { get; set; }

        public string SeatNumber { get; set; }

        public string QRCode { get; set; }
    }
}