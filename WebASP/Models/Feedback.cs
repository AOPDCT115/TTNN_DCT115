using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Status { get; set; }
    }
}
