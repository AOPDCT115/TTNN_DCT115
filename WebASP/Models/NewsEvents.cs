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
        public int Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int TypeCourseID { get; set; }
        public string UrlImg { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(250)]
        public string MetaKeywords { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<TypeCourse> TypeCourses { get; set; }
    }
}