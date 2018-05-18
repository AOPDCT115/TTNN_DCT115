using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        public int FeedbackID { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
        [Display(Name = "Nội dung")]
        public string Text { get; set; }
        [Display(Name = "nội dung trả lời")]
        public string Reply { get; set; }

        public bool Status { get; set; }
    }
}
