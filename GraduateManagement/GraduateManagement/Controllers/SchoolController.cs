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
    public class SchoolController : Controller
    {
        private SqlDbContext db = new SqlDbContext();
        // GET: SchoolDeanOffiece
        public ActionResult Index()      //各学院进展列表
        {
            return View();
        }
        public ActionResult writeNews()  //写通知公告
        {
            return View();
        }
        public ActionResult releaseNews(NewsReleaseViewModel model)  //发布通知公告
        {
            return RedirectToAction("/Home/Index");
        }
    }
}