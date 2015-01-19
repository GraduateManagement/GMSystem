﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using GraduateManagement.Models;
using GraduateManagement.Attributes;

namespace GraduateManagement.Controllers
{
    [AuthorityFilter]
    public class StudentController : Controller
    {
        SqlDbContext db = new SqlDbContext();

        // GET: Student
        public ActionResult Index()   //学生查看页面
        {
            int ID = Convert.ToInt32(Request.Cookies["userID"].Value);
            StudentViewModel model = new StudentViewModel();

            var records = (from o in db.user_table
                           where o.ID == ID
                           select o).ToArray<users>();

            if (records.Length > 0)
            {
                model.attachmentAddr = records[0].attachmentAddr;
                model.attachmentName = records[0].attachmentName;
                int academy = records[0].academy;
                int progress = records[0].progress; //项目进展

                var tacademyname = (from o in db.academy_table
                                    where o.ID == academy
                                    select o.name).ToArray<string>();

                var tprogressname = (from o in db.progress_table
                                     where o.ID == progress
                                     select o.progressName).ToArray<string>();

                model.accountNum = records[0].accountNum;
                model.name = records[0].name;

                if (tacademyname.Length > 0)
                    model.academy = tacademyname[0];
                else
                    model.academy = "无";

                if (tprogressname.Length > 0)
                    model.progress = tprogressname[0];
                else
                    model.progress = "无";
            }
            return View(model);
        }

        public ActionResult Uploads() //学生上传论文
        {
            //Word.Document doc = null; //一会要记录word打开的文档
            Stream fileStream = Request.Files["upload-doc"].InputStream;

            //Stream fileStream = Request.Files[upload].InputStream;

            string fileName = DateTime.Now.ToString().Replace("/", ".").Replace(":", ".") + Path.GetFileName(Request.Files["upload-doc"].FileName);
            int fileLength = Request.Files["upload-doc"].ContentLength;
            //本地存放路径
            string path = AppDomain.CurrentDomain.BaseDirectory + "stuUploads/";
            //将文件以文件名filename存放在path路径中
            Request.Files["upload-doc"].SaveAs(Path.Combine(path, fileName));

            int ID = Convert.ToInt32(Request.Cookies["userID"].Value);

            var result = (from o in db.user_table
                          where o.ID == ID
                          select o).ToArray<users>();

            result[0].attachmentAddr = path + fileName;
            result[0].attachmentName = Request.Files["upload-doc"].FileName;
            result[0].progress = 2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}