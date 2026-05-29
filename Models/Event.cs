using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EventManagementSystem.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public string EventTitle { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public decimal TicketPrice { get; set; }

        public int TotalSeats { get; set; }

        public int VenueID { get; set; }

        public int CategoryID { get; set; }

        public int OrganizerID { get; set; }
    }
}