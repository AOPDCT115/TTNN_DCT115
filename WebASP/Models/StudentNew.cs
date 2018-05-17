using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class StudentNew
    {
        public int ClassID { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Gender { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
    }
}