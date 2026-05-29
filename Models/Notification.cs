using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EventManagementSystem.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }

        public int UserID { get; set; }

        public string Message { get; set; }

        public DateTime NotificationDate { get; set; }
    }
}