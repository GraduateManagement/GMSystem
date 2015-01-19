using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace GraduateManagement.Models
{
    public class users
    {
        [Key]
        public int ID { get; set; }
        public string accountNum { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int academy { get; set; }
        public int roleID { get; set; }
        public string attachmentName { get; set; }
        public string attachmentAddr { get; set; }
        public int progress { get; set; }
        public double score { get; set; }
        public bool replyAlloc { get; set; }
        public bool tutorAlloc { get; set; }
    }
    public class academy
    {
        [Key]
        [Display(Name = "院系代号")]
        public int ID { get; set; }
        [Display(Name = "学院")]
        public string name { get; set; }
    }
    public class notices
    {
        [Key]
        public int ID { get; set; }
        public bool vital { get; set; }
        public int userID { get; set; }
        public string title { get; set; }
        public DateTime time { get; set; }
        public string content { get; set; }
        public string attachmentAddr { get; set; }
        public string attachmentName { get; set; }
    }
    public class role
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
    }
    public class authority
    {
        [Key]
        public int ID { get; set; }
        public string controllerName { get; set; }
    }
    public class AR
    {
        [Key]
        [Column(Order = 0)]
        public int roleID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int authorityID { get; set; }
    }
    public class directs
    {
        [Key]
        [Column(Order = 0)]
        public int teacherID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int stuID { get; set; }
    }
    public class reply
    {
        [Key]
        [Column(Order = 0)]
        public int teacherID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int stuID { get; set; }
        public double score { get; set; }
    }
    public class progress
    {
        [Key]
        public int ID { get; set; }
        public string progressName { get; set; }
    }
}