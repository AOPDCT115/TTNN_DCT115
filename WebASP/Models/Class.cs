using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Class
    {
        [Display(Name = "Mã lớp")]
        public int ClassID { get; set; }
        [Display(Name = "Khoá học")]
        public int CourseID { get; set; }
        [Display(Name = "Sĩ số")]
        public int NumOfMem { get; set; }
        [Display(Name = "Còn lại")]
        public int CurrentMem { get; set; }
        [Display(Name = "Giới thiệu")]
        public string Introduce { get; set; }
        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual Course Courses { get; set; }
        public virtual Instructor Instructors { get; set; }
    }
}