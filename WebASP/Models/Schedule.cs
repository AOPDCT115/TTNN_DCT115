using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP.Models
{
    public class Schedule
    {
        [Display(Name = "Mã lịch học")]
        public int ScheduleID { get; set; }
        [Display(Name = "Mã lớp")]
        public int ClassID { get; set; }
        [Display(Name = "Số tuần học")]
        public int Week { get; set; }
        [Display(Name = "Ngày học")]
        public string Day { get; set; }
        [Display(Name = "Ngày bắt đầu học")]
        public string Dates { get; set; }
        [Display(Name = "Thời gian học")]
        public string Times { get; set; }
        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }
        

        public virtual Class Classes { get; set; }
    }
}