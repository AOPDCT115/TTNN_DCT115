using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Course
    {
        [Display(Name = "Mã khoá học")]
        [Key]
        public int CourseID { get; set; }
        [Display(Name = "Chương trình đào tạo")]
        public int TypeCourseID { get; set; }
        [Display(Name = "Tên khoá học")]
        public string Name { get; set; }
        [Display(Name = "Học phí")]
        public Nullable<decimal> Price { get; set; }
        [Display(Name = "Số bài học")]
        public int NumofLesson { get; set; }
        [Display(Name = "Hình ảnh")]
        public string UrlImg { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public DateTime DateStart { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime DateFinish { get; set; }
        [Display(Name = "Mã giảm giá")]
        public int SaleID { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Available { get; set; }
        [Display(Name = "Giới thiệu")]
        public string Introduce { get; set; }

        public virtual TypeCourse TypeCourses { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}