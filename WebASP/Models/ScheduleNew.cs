using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class ScheduleNew
    {
        public int ScheduleID { get; set; }
        public int ClassID { get; set; }
        public int Week { get; set; }
        public string Day { get; set; }
        public string Dates { get; set; }
        public string Times { get; set; }
        public string Status { get; set; }
    }
}