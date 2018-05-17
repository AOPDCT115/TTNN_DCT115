using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Register
    {
        public int RegisterID { get; set; }
        [Display(Name = "Mã học viên")]
        public int StudentID { get; set; }
        [Display(Name = "Mã lớp")]
        public int ClassID { get; set; }
        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }

        public virtual Student Students { get; set; }
        public virtual Class Classes { get; set; }
    }
}