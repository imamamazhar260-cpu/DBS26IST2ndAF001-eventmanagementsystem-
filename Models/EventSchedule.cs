using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EventManagementSystem.Models
{
    public class EventSchedule
    {
        public int ScheduleID { get; set; }

        public int EventID { get; set; }

        public string ActivityName { get; set; }

        public TimeSpan ActivityTime { get; set; }
    }
}
