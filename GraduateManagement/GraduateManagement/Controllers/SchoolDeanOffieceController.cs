using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduateManagement.Controllers
{
    public class SchoolDeanOffieceController : Controller
    {
        // GET: SchoolDeanOffiece
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult writeNews()  //写通知公告
        {
            return View();
        }
        public ActionResult releaseNews()  //发布通知公告
        {
            return RedirectToAction("/Home/Index");
        }
    }
}