using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }

        public int UserID { get; set; }

        public string OrganizationName { get; set; }

        public int ExperienceYears { get; set; }
    }
}