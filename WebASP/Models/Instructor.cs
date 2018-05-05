using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirt { get; set; }
        public decimal Gender { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public int Relative { get; set; }
        public string UrlImg { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}