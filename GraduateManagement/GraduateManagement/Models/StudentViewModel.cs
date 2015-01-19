using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GraduateManagement.Models
{
    public class StudentViewModel
    {
        [Display(Name = "学号")]
        public string accountNum { get; set; }
        [Display(Name = "姓名")]
        public string name { get; set; }
        [Display(Name = "学院")]
        public string academy { get; set; }
        [Display(Name = "进度")]
        public string progress { get; set; }
        [Display(Name = "附件")]
        public string attachmentAddr { get; set; }
        public string attachmentName { get; set; }

    }
}