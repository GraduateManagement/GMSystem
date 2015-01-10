using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduateManagement.Controllers
{
    public class AcademyDeanController : Controller
    {
        // GET: Academy
        public ActionResult Index()    //学生进展列表、审核结果
        {
            return View();
        }
        public ActionResult tutorAlloc()   //指导老师分配
        {
            return View();
        }
        public ActionResult replyTeacherAlloc()   //答辩老师分配
        {
            return View();
        }
    }
}