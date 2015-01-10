using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduateManagement.Models
{
    public class NoticesViewModel
    {
        public int newsID { get; set; }
        public bool vital { get; set; }
        public string title { get; set; }
        public DateTime time { get; set; }
    }
    public class NewsViewModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public DateTime time { get; set; }
    }
}