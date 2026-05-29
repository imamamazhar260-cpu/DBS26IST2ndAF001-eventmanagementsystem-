using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EventManagementSystem.Models
{
    public class Logs
    {
        public int LogID { get; set; }

        public string ErrorMessage { get; set; }

        public DateTime LogDate { get; set; }

        public int UserID { get; set; }
    }
}