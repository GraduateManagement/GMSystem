using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduateManagement.Models;
using GraduateManagement.Attributes;
using System.Web.Security;

namespace GraduateManagement.Controllers
{
    public class HomeController : Controller
    {
        private SqlDbContext db = new SqlDbContext();

        public ActionResult Index()    //补充：处理通知公告的部分
        {
            var notices = (from o in db.notice_table
                         select new { o.ID, o.vital, o.title, o.time }).ToArray();
            List<NoticesViewModel> model = new List<NoticesViewModel>();
            for (int i = 0; i < notices.Length; i++)
            {
                NoticesViewModel m = new NoticesViewModel();
                m.newsID = notices[i].ID;
                m.vital = notices[i].vital;
                m.title = notices[i].title;
                m.time = notices[i].time;
                model.Add(m);
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "毕业生服务平台，专业为您提供优质的毕业设计(论文)及答辩等信息服务，是为您解决毕业前最后一公里的得力助手！";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "欢迎联系我们，南师大官方联系方式如下:";

            return View();
        }

        public ActionResult News(int id)   //新闻的具体界面，要处理自然段分段
        {
            var New = (from o in db.notice_table
                       where o.ID == id
                       select new { o.title, o.time, o.content, o.attachmentAddr, o.attachmentName }).ToArray();
            NewsViewModel model = new NewsViewModel();
            model.title = New[0].title;
            model.time = New[0].time;
            model.content = New[0].content;
            model.attachmentAddr = New[0].attachmentAddr;
            model.attachmentName = New[0].attachmentName;
            return View(model);
        }

        public ActionResult Error()
        {
            return View();
        }     //权限不足的错误提示界面
    }
}