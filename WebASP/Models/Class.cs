using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public int CourseID { get; set; }
        public int NumOfMem { get; set; }
        public string Introduce { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual Course Courses { get; set; }
        public virtual Instructor Instructors { get; set; }
    }
}