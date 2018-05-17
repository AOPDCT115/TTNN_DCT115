using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class ProvinceModel
    {
        public int ID { set; get; }
        [Display(Name = "Tỉnh/Thành phố")]
        public string Name { set; get; }
    }
}