using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GraduateManagement.Models
{
    public class DirectViewModel
    {
        public int stuID { get; set; }
        [Display(Name = "����")]
        public string stuname { get; set; }
        [Display(Name = "ѧ��")]
        public string stuAccountNum { get; set; }
        [Display(Name = "���ճɼ�")]
        public double score { get; set; }
        [Display(Name = "����")]
        public string progressName { get; set; }
    }

    public class ReplyViewModel
    {
        public int stuID { get; set; }
        [Display(Name = "����")]
        public string stuname { get; set; }
        [Display(Name = "ѧ��")]
        public string stuAccountNum { get; set; }
        [Display(Name = "���ճɼ�")]
        public double score { get; set; }
        [Display(Name = "����")]
        public string progressName { get; set; }
    }

    public class directStudentViewModel
    {
        public directStudentViewModel() { }
        public directStudentViewModel(int stuID, string stuname, string accountNum, double score, string attachmentName, string attachmentAddr, string progressName, int progress)
        {
            this.stuID = stuID;
            this.stuname = stuname;
            this.score = score;
            this.attachmentName = attachmentName;
            this.attachmentAddr = attachmentAddr;
            this.progressName = progressName;
            this.progress = progress;
            this.stuAccountNum = accountNum;
        }
        public int stuID { get; set; }
        [Display(Name = "����")]
        public string stuname { get; set; }
        [Display(Name = "ѧ��")]
        public string stuAccountNum { get; set; }
        [Display(Name = "���ճɼ�")]
        public double score { get; set; }
        public string attachmentName { get; set; }
        [Display(Name = "����")]
        public string attachmentAddr { get; set; }
        [Display(Name = "����")]
        public string progressName { get; set; }
        public int progress { get; set; }
    }

    public class replyStudentViewModel
    {
        public replyStudentViewModel() { }
        public replyStudentViewModel(double myScore, int stuID, string stuname, string accountNum, double score, string attachmentName, string attachmentAddr, string progressName, int progress)
        {
            this.stuID = stuID;
            this.stuname = stuname;
            this.score = score;
            this.myScore = myScore;
            this.attachmentName = attachmentName;
            this.attachmentAddr = attachmentAddr;
            this.progressName = progressName;
            this.progress = progress;
            this.stuAccountNum = accountNum;
        }
        public int stuID { get; set; }
        [Display(Name = "����")]
        public string stuname { get; set; }
        [Display(Name = "ѧ��")]
        public string stuAccountNum { get; set; }
        [Display(Name = "���ճɼ�")]
        public double score { get; set; }
        public string attachmentName { get; set; }
        [Display(Name = "����")]
        public string attachmentAddr { get; set; }
        [Display(Name = "����")]
        public string progressName { get; set; }
        public int progress { get; set; }
        [Display(Name = "�ҵĸ���")]
        public double myScore { get; set; }
    }

    public class doneReplyViewModel
    {
        public double score { get; set; }
    }
}