using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduateManagement.Attributes;

namespace GraduateManagement.Controllers
{
    [AuthorityFilter]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()   //学生提交论文、附件及查看进度
        {
            return View();
        }
    }
}