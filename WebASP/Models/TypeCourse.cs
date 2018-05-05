using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class TypeCourse
    {
        public int TypeCourseID { get; set; }
        public string TypeName { get; set; }
        public string Introduce { get; set; }
        public string UrlImg { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Special_TypeCourse> Special_TypeCourses { get; set; }
    }
}