using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string UserName { get; set; }
        [StringLength(32)]
        public string PassWord { get; set; }
        [StringLength(20)]
        public string GroupID { set; get; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirt { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Gender { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string  Phone { get; set; }
        public int Relative { get; set; }
        public string UrlImg { get; set; }
        public int? ProvinceID { set; get; }
        public int? DistrictID { set; get; }
        public bool Status { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
    }
}