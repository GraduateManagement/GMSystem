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
        public string keyhash { get; set; }
        public string name { get; set; }
        public int acdemy { get; set; }
        public int role { get; set; }
        public string paperAddr { get; set; }
        public string attachmentAddr { get; set; }
        public int progress { get; set; }
        public double score { get; set; }
    }
    public class notices
    {
        [Key]
        public int ID { get; set; }
        public int userID { get; set; }
        public string title { get; set; }
        public DateTime time { get; set; }
        public string content { get; set; }
        public string attachmentAddr { get; set; }
    }
    public class authority
    {
        [Key]
        [Column(Order = 0)]
        public int role { get; set; }
        [Key]
        [Column(Order = 1)]
        public int userID { get; set; }
    }
    public class directs
    {
        [Key]
        [Column(Order = 0)]
        public int teacherID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int stuID { get; set; }
        public bool canplea { get; set; }
    }
    public class pleas
    {
        [Key]
        [Column(Order = 0)]
        public int teacherID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int stuID { get; set; }
        public int score { get; set; }
    }
    public class progress
    {
        [Key]
        public int ID { get; set; }
        public string progressName { get; set; }
    }
}