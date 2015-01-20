using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduateManagement.Models;
using GraduateManagement.Attributes;

namespace GraduateManagement.Controllers
{
    [AuthorityFilter]
    public class AcademyController : Controller
    {
        SqlDbContext db = new SqlDbContext();

        // GET: Academy
        public ActionResult Index()    //学生进展列表、审核结果
        {
            int id = Convert.ToInt32(Request.Cookies["userID"].Value);
            List<AcademyStudentViewModel> model = new List<AcademyStudentViewModel>();
            var a = db.user_table.First(c => c.ID == id);
            var student = (from p in db.user_table
                           where p.academy == a.academy && p.roleID == 4
                           select p).ToArray();
            for (int i = 0; i < student.Length; i++)
            {
                AcademyStudentViewModel m = new AcademyStudentViewModel();
                int progress = student[i].progress;
                var pn = db.progress_table.Single(c => c.ID == progress);
                m.stuID = student[i].ID;
                m.stuname = student[i].name;
                m.progressName = pn.progressName;
                m.stuAccountNum = student[i].accountNum;
                m.score = student[i].score;
                m.tutorAlloc = student[i].tutorAlloc;
                m.replyAlloc = student[i].replyAlloc;
                model.Add(m);
            }
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var student = db.user_table.Single(c => c.ID == id);
            var pn = db.progress_table.Single(o => o.ID == student.progress);

            return View();
        }

        public bool DoneDirect(int id)  //院教务处审核通过
        {
            users u = db.user_table.First(c => c.ID == id);
            if (u.progress == 4)
            {
                u.progress = 6;     //修改进度为“院教务处审核通过,等待校教务处审核”
                db.SaveChanges();
            }
            return true;
        }

        public ActionResult tutorAlloc(int id)   //指导老师分配
        {
            var a = db.user_table.First(c => c.ID == id);
            if (a.tutorAlloc == false)  //未分配，选择页面
            {
                List<AllocViewModel> model = new List<AllocViewModel>();
                var student = (from p in db.user_table
                               where p.academy == a.academy && p.roleID == 0
                               select p).ToArray();
                var Teacher = (from p in db.user_table
                               where p.academy == a.academy && p.roleID == 1
                               select p).ToArray();
                for (int i = 0; i < student.Length; i++)
                {
                    model[i].stuID = student[i].ID;
                    model[i].stuname = student[i].name;
                    for (int j = 0; j < Teacher.Length; j++)
                    {
                        model[i].teachers[j].teacherID = Teacher[j].ID;
                        model[i].teachers[j].teachername = Teacher[j].name;
                    }
                }
                return View(model);
            }
            return tutorAllocResult(id);    //已分配，显示结果       
        }

        public ActionResult DoTutorAlloc(int id)   //提交指导老师分配
        {
            var a = db.user_table.First(c => c.ID == id);
            var student = (from p in db.user_table
                           where p.academy == a.academy && p.roleID == 0
                           select p).ToArray();
            for (int i = 0; i < student.Length; i++)
            {
                var str = student[i].ID.ToString();
                string[] values = Request.Form.GetValues(str);  //????假定每个学生对应的复选框组名称为学号
                for (int j = 0; j < values.Count(); j++)
                {
                    directs d = new directs();
                    d.stuID = student[i].ID;
                    //var u = db.user_table.First(c => c.name == values[i]);  //复选框值为老师姓名
                    //d.teacherID = u.ID;
                    d.teacherID = int.Parse(values[i]);      //复选框值为老师工号
                    db.direct_table.Add(d);
                    db.SaveChanges();
                }
            }
            return tutorAllocResult(id);    //显示结果
        }

        public ActionResult replyTeacherAlloc(int id)   //答辩老师分配
        {
            var a = db.user_table.First(c => c.ID == id);
            if (a.replyAlloc == false)  //未分配，选择页面
            {
                List<AllocViewModel> model = new List<AllocViewModel>();
                var student = (from p in db.user_table
                               where p.academy == a.academy && p.roleID == 0
                               select p).ToArray();
                var Teacher = (from p in db.user_table
                               where p.academy == a.academy && p.roleID == 1
                               select p).ToArray();
                for (int i = 0; i < student.Length; i++)
                {
                    model[i].stuID = student[i].ID;
                    model[i].stuname = student[i].name;
                    for (int j = 0; j < Teacher.Length; j++)
                    {
                        model[i].teachers[j].teacherID = Teacher[j].ID;
                        model[i].teachers[j].teachername = Teacher[j].name;
                    }
                }
                return View(model);
            }
            return replyTeacherAllocResult(id);    //已分配，显示结果 
        }

        public ActionResult DoReplyTeacherAlloc(int id)   //提交答辩老师分配
        {
            var a = db.user_table.First(c => c.ID == id);
            var student = (from p in db.user_table
                           where p.academy == a.academy && p.roleID == 0
                           select p).ToArray();
            for (int i = 0; i < student.Length; i++)
            {
                var str = student[i].ID.ToString();
                string[] values = Request.Form.GetValues(str);  //????假定每个学生对应的复选框组名称为学号
                for (int j = 0; j < values.Count(); j++)
                {
                    reply r = new reply();
                    r.stuID = student[i].ID;
                    //var u = db.user_table.First(c => c.name == values[i]);  //复选框值为老师姓名
                    //r.teacherID = u.ID;
                    r.teacherID = int.Parse(values[i]);      //复选框值为老师工号
                    db.reply_table.Add(r);
                    db.SaveChanges();
                }
            }
            return replyTeacherAllocResult(id);    //显示结果
        }

        public ActionResult tutorAllocResult(int id)   //指导老师分配结果
        {
            var a = db.user_table.First(c => c.ID == id);
            List<AllocViewModel> model = new List<AllocViewModel>();
            var student = (from p in db.user_table
                           where p.academy == a.academy && p.roleID == 0
                           select p).ToArray();
            for (int i = 0; i < student.Length; i++)
            {
                model[i].stuID = student[i].ID;
                model[i].stuname = student[i].name;
                var Teacher = (from p in db.direct_table
                               where p.stuID == student[i].ID
                               select p).ToArray();
                for (int j = 0; j < Teacher.Length; j++)
                {
                    var u = db.user_table.First(c => c.ID == Teacher[j].teacherID);
                    model[i].teachers[j].teacherID = Teacher[j].teacherID;
                    model[i].teachers[j].teachername = u.name;
                }
            }
            return View(model);
        }

        public ActionResult replyTeacherAllocResult(int id)   //答辩老师分配结果
        {
            var a = db.user_table.First(c => c.ID == id);
            List<AllocViewModel> model = new List<AllocViewModel>();
            var student = (from p in db.user_table
                           where p.academy == a.academy && p.roleID == 0
                           select p).ToArray();
            for (int i = 0; i < student.Length; i++)
            {
                model[i].stuID = student[i].ID;
                model[i].stuname = student[i].name;
                var Teacher = (from p in db.reply_table
                               where p.stuID == student[i].ID
                               select p).ToArray();
                for (int j = 0; j < Teacher.Length; j++)
                {
                    var u = db.user_table.First(c => c.ID == Teacher[j].teacherID);
                    model[i].teachers[j].teacherID = Teacher[j].teacherID;
                    model[i].teachers[j].teachername = u.name;
                }
            }
            return View(model);
        }

        public ActionResult addStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addStudent(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Request.Cookies["userID"].Value);
                int academy = db.user_table.Single(u => u.ID == id).academy;
                users user = new users();
                user.name = model.name;
                user.accountNum = model.accountNum;
                user.password = model.password;
                user.academy = academy;
                user.roleID = 4;
                user.progress = 1;
                user.tutorAlloc = false;
                user.replyAlloc = false;
                db.user_table.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}