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

        [AllowAnonymous]
        public ActionResult addStudent()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult addStudent(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}