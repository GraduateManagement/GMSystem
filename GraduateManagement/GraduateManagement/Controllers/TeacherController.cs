using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduateManagement.Attributes;

namespace GraduateManagement.Controllers
{
    [AuthorityFilter]
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Direct()  //自己指导的学生列表
        {
            return View();
        }
        public ActionResult Reply()   //答辩的学生列表
        {
            return View();
        }
        public ActionResult directStudent(int id)   //某个具体的指导学生的界面
        {
            return View();
        }
        public ActionResult replyStudent(int id)    //某个具体的答辩学生的界面
        {
            return View();
        }
    }
}