using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GraduateManagement.Models
{
    public class AcademyStudentViewModel
    {
        public int stuID { get; set; }
        [Display(Name = "姓名")]
        public string stuname { get; set; }
        [Display(Name = "学号")]
        public string stuAccountNum { get; set; }
        [Display(Name = "进度")]
        public string progressName { get; set; }
        [Display(Name = "最终成绩")]
        public double score { get; set; }
        [Display(Name = "导师分配")]
        public bool tutorAlloc { get; set; }
        [Display(Name = "答辩分配")]
        public bool replyAlloc { get; set; }
        //public List<replies> replyScores { get; set; }
    }

    public class DetailViewModel
    {
        public int stuID { get; set; }
        [Display(Name = "姓名")]
        public string stuname { get; set; }
        [Display(Name = "学号")]
        public string stuAccountNum { get; set; }
        [Display(Name = "进度")]
        public string progressName { get; set; }
        [Display(Name = "最终成绩")]
        public double score { get; set; }
    }

    public class replies
    {
        public string teachername { get; set; }
        public double score { get; set; }
    }
    public class AllocViewModel
    {
        public AllocViewModel() { }
        public AllocViewModel(int stuID, string stuname, List<teacher> teachers)
        {
            this.stuID = stuID;
            this.stuname = stuname;
        }
        public int stuID { get; set; }
        public string stuname { get; set; }
        public List<teacher> teachers { get; set; }
    }

    public class teacher
    {
        public int teacherID { get; set; }
        public string teachername { get; set; }

    }
}