using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    [Table("Special_TypeCourse")]
    public class Special_TypeCourse
    {
        [Key]
        public int SpecialID { get; set; }
        public int TypeCourseID { get; set; }
        public string SpecialName { get; set; }
        public string Content { get; set; }
        public string UrlImg { get; set; }

        public virtual TypeCourse TypeCourses { get; set; }
    }
}