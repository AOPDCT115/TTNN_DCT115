using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Menu
    {
        [Display(Name = "Mã menu")]
        public int ID { get; set; }
        [StringLength(250)]
        [Display(Name = "Link liên kết")]
        public string Link { get; set; }
        [StringLength(50)]
        [Display(Name = "Tên hiển thị")]
        public string Target { get; set; }
        public string ControllerMenu { get; set; }
        [Display(Name = "Số menu 2")]
        public int Child { get; set; }
    }
}