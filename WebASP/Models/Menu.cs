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
        public int ID { get; set; }
        [StringLength(250)]
        public string Link { get; set; }
        [StringLength(50)]
        public string Target { get; set; }
        public string ControllerMenu { get; set; }
        public int Child { get; set; }
    }
}