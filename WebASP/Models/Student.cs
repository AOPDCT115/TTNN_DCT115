using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Student
    {
        [Display(Name = "Mã học viên")]
        public int StudentID { get; set; }
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(32)]
        public string PassWord { get; set; }
        [StringLength(20)]
        public string GroupID { set; get; }
        [Display(Name = "Tên học viên")]
        public string Name { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirt { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Giới tính")]
        public decimal Gender { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Địa chỉ mail")]
        public string Mail { get; set; }
        [Display(Name = "Số điện thoại")]
        public string  Phone { get; set; }
        public int Relative { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string UrlImg { get; set; }
        public int? ProvinceID { set; get; }
        public int? DistrictID { set; get; }
        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
    }
}