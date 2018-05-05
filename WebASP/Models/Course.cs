using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public int  TypeCourseID { get; set; }
        public string  Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int NumofLesson { get; set; }
        public string UrlImg { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateFinish { get; set; }
        public int SaleID { get; set; }
        public int Availeable { get; set; }
        public string Introduce { get; set; }

        public virtual TypeCourse TypeCourses { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}