using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduateManagement.Attributes;
using GraduateManagement.Models;

namespace GraduateManagement.Controllers
{
    [AuthorityFilter]
    public class TeacherController : Controller
    {
        SqlDbContext db = new SqlDbContext();

        // GET: Teacher
        public ActionResult Index()
        {
            return RedirectToAction("Direct");
        }

        public ActionResult Direct()  //指导的学生列表
        {
            int id = Convert.ToInt32(Request.Cookies["userID"].Value);
            var student = (from o in db.direct_table
                           where o.teacherID == id
                           select new { o.stuID }).ToArray();
            List<DirectViewModel> model = new List<DirectViewModel>();
            for (int i = 0; i < student.Length; i++)
            {
                var stu = db.user_table.Single(o => o.ID == student[i].stuID);
                var pn = db.progress_table.Single(o => o.ID == stu.progress);
                model[i].stuID = stu.ID;
                model[i].stuname = stu.name;
                model[i].stuAccountNum = stu.accountNum;
                model[i].score = stu.score;
                model[i].progressName = pn.progressName;
            }
            return View(model);
        }

        public ActionResult Reply()   //答辩的学生列表
        {
            int id = Convert.ToInt32(Request.Cookies["userID"].Value);
            var student = (from o in db.reply_table
                           where o.teacherID == id
                           select new { o.stuID, o.score }).ToArray();
            List<ReplyViewModel> model = new List<ReplyViewModel>();
            for (int i = 0; i < student.Length; i++)
            {
                var stu = db.user_table.Single(o => o.ID == student[i].stuID);
                var pn = db.progress_table.Single(o => o.ID == stu.progress);
                model[i].stuID = stu.ID;
                model[i].stuname = stu.name;
                model[i].stuAccountNum = stu.accountNum;
                model[i].score = student[i].score;
                model[i].progressName = pn.progressName;
            }
            return View(model);
        }

        public ActionResult directStudent(int id)   //某个具体的指导学生的界面
        {
            var student = db.user_table.Single(c => c.ID == id);
            var pn = db.progress_table.Single(o => o.ID == student.progress);
            directStudentViewModel model = new 
                directStudentViewModel(student.ID,student.name,
                student.accountNum,student.score,student.attachmentName,
                student.attachmentAddr, pn.progressName, student.progress);
            return View(model);
        }

        public ActionResult replyStudent(int id)    //某个具体的答辩学生的界面
        {
            int tid = Convert.ToInt32(Request.Cookies["userID"].Value);
            var student = db.user_table.First(c => c.ID == id);
            var re = db.reply_table.First(c => c.stuID == id && c.teacherID == tid);
            var pn = db.progress_table.First(o => o.ID == student.progress);
            replyStudentViewModel model = new 
                replyStudentViewModel(re.score,student.ID,student.name,
                student.accountNum,student.score,student.attachmentName,
                student.attachmentAddr,pn.progressName,student.progress);
            return View(model);
        }

        public ActionResult DoneDirect(int id)  //指导老师审核通过
        {
            users u = db.user_table.Single(c => c.ID == id);
            u.progress = 4;     //修改进度为"导师审核通过,等待学院答辩审核"
            db.SaveChanges();
            return RedirectToAction("Direct");
        }

        public ActionResult DoneReply(int id)  //答辩给分
        {
            int tid = Convert.ToInt32(Request.Cookies["userID"].Value);
            directs d = db.direct_table.Single(c => c.teacherID == tid && c.stuID == id);
            reply r = db.reply_table.Single(c => c.teacherID == tid && c.stuID == id);
            r.score = Convert.ToDouble(Request.Form["myScore"].ToString());
            db.SaveChanges();
            return RedirectToAction("Reply");
        }
          /*  var R = from o in db.reply_table
                    where (o.stuID == id && o.score == null)
                    select o;
            if (R != null)
            {
                var rr = (from p in db.reply_table
                          where p.stuID == id
                          select p).Average(o => o.score);
                db.reply_table.First(c => c.teacherID == tid && c.stuID == tid);
                users u = db.user_table.First(c => c.ID == id);
                u.progress = 6;         //修改进度为“答辩老师评分完成，等待学院审核”
                u.score = rr;
                db.SaveChanges();
            }
           */        
    }
}