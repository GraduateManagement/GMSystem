using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GraduateManagement.Models;

namespace GraduateManagement.Controllers
{
    public class SuperAdminController : Controller
    {
        private SqlDbContext db = new SqlDbContext();

        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View(db.user_table.ToList());
        }

        // GET: SuperAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.user_table.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: SuperAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,accountNum,password,name,academy,roleID,attachmentName,attachmentAddr,progress,score,replyAlloc,tutorAlloc")] users users)
        {
            if (ModelState.IsValid)
            {
                db.user_table.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: SuperAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.user_table.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: SuperAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,accountNum,password,name,academy,roleID,attachmentName,attachmentAddr,progress,score,replyAlloc,tutorAlloc")] users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: SuperAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.user_table.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: SuperAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users users = db.user_table.Find(id);
            db.user_table.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
