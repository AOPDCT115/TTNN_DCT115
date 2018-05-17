using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class NewsEvents
    {
        public int NewsEventsID { get; set; }
        [Display(Name = "Kiểu bản tin")]
        public int Type { get; set; }
        [Display(Name = "Tên bản tin")]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Chương trình đào tạo")]
        public int TypeCourseID { get; set; }
        [Display(Name = "Hình ảnh")]
        public string UrlImg { get; set; }
        [Display(Name = "Ngày đăng")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(250)]
        [Display(Name = "Từ khoá")]
        public string MetaKeywords { get; set; }
        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }

        public virtual ICollection<TypeCourse> TypeCourses { get; set; }
    }
}