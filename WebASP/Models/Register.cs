using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Register
    {
        public int RegisterID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }


        public virtual Student Students { get; set; }
        public virtual Class Classes { get; set; }
    }
}