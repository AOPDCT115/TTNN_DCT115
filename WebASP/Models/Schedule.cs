using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int ClassID { get; set; }
        public int Week { get; set; }
        public string Dates { get; set; }
        public string Times { get; set; }

        public virtual Class Classes { get; set; }
    }
}