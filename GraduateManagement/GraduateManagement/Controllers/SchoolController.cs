using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduateManagement.Models;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
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
            return View(db.academy_table.ToList());
        }

        public ActionResult writeNews()  //写通知公告
        {
            return View();
        }

        public ActionResult releaseNews(NewsReleaseViewModel model)  //发布通知公告
        {
            notices newnotices = new notices();

            newnotices.userID = Convert.ToInt32(Request.Cookies["userID"].Value);
            newnotices.vital = model.vital;
            newnotices.title = model.title;
            newnotices.time = DateTime.Now;
            newnotices.content = model.content;

            //Word.Document doc = null; //一会要记录word打开的文档
            Stream fileStream = Request.Files["upload-doc"].InputStream;

            if (fileStream.Length > 0)
            {
                string fileName = DateTime.Now.ToString().Replace("/", ".").Replace(":", ".") + Path.GetFileName(Request.Files["upload-doc"].FileName);
                int fileLength = Request.Files["upload-doc"].ContentLength;
                //本地存放路径
                string path = AppDomain.CurrentDomain.BaseDirectory + "schoolUploads/";
                //将文件以文件名filename存放在path路径中
                Request.Files["upload-doc"].SaveAs(Path.Combine(path, fileName));
                newnotices.attachmentAddr = path + fileName;
                newnotices.attachmentName = Request.Files["upload-doc"].FileName;
            }
            else
            {
                newnotices.attachmentAddr = "";
                newnotices.attachmentName = "";
            }
            db.notice_table.Add(newnotices);
            db.SaveChanges();
            return RedirectToAction("/Home/Index");
        }

        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}