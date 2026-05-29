using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EventManagementSystem.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }

        public int CustomerID { get; set; }

        public int EventID { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

        public DateTime FeedbackDate { get; set; }
    }
}