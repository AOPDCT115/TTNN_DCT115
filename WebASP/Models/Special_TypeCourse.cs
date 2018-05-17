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
        [Display(Name = "Mã đặc điểm")]
        public int SpecialID { get; set; }
        [Display(Name = "Chương trình đào tạo")]
        public int TypeCourseID { get; set; }
        [Display(Name = "Tên đặc điểm")]
        public string SpecialName { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Tình trạng")]
        public string UrlImg { get; set; }

        public virtual TypeCourse TypeCourses { get; set; }
    }
}