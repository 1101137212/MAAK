using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MAAK.Models;

namespace MAAK.Controllers
{
    public class MediaReportsController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: MediaReports
        public ActionResult Index()
        {
            var mediaReports = db.MediaReports.Include(m => m.Member);
            return View(mediaReports.ToList());
        }

        // GET: MediaReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaReports mediaReports = db.MediaReports.Find(id);
            if (mediaReports == null)
            {
                return HttpNotFound();
            }
            return View(mediaReports);
        }

        // GET: MediaReports/Create
        public ActionResult Create()
        {
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: MediaReports/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MediaReports_ID,MediaReports_Title,MediaReports_Date,MediaReports_Detail,MediaReports_Picture,MediaReports_Modifier,MediaReports_ModificationTime,MediaReports_ModificationDate,Member_ID")] MediaReports mediaReports)
        {
            if (ModelState.IsValid)
            {
                db.MediaReports.Add(mediaReports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", mediaReports.Member_ID);
            return View(mediaReports);
        }

        // GET: MediaReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaReports mediaReports = db.MediaReports.Find(id);
            if (mediaReports == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", mediaReports.Member_ID);
            return View(mediaReports);
        }

        // POST: MediaReports/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MediaReports_ID,MediaReports_Title,MediaReports_Date,MediaReports_Detail,MediaReports_Picture,MediaReports_Modifier,MediaReports_ModificationTime,MediaReports_ModificationDate,Member_ID")] MediaReports mediaReports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaReports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", mediaReports.Member_ID);
            return View(mediaReports);
        }

        // GET: MediaReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaReports mediaReports = db.MediaReports.Find(id);
            if (mediaReports == null)
            {
                return HttpNotFound();
            }
            return View(mediaReports);
        }

        // POST: MediaReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaReports mediaReports = db.MediaReports.Find(id);
            db.MediaReports.Remove(mediaReports);
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
