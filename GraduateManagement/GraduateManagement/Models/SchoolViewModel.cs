using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GraduateManagement.Models
{
    public class NewsReleaseViewModel
    {
        [Required]
        [Display(Name = "新闻很重要")]
        public bool vital { get; set; }
        [Required]
        [Display(Name = "标题")]
        public string title { get; set; }
        [Required]
        [Display(Name = "内容")]
        public string content { get; set; }
        [Required]
        [Display(Name = "附件")]
        public string attachmentName { get; set; }
    }
}