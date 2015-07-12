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
    public class MeetingNewsController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: MeetingNews
        public ActionResult Index()
        {
            var meetingNews = db.MeetingNews.Include(m => m.Member);
            return View(meetingNews.ToList());
        }

        // GET: MeetingNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingNews meetingNews = db.MeetingNews.Find(id);
            if (meetingNews == null)
            {
                return HttpNotFound();
            }
            return View(meetingNews);
        }

        // GET: MeetingNews/Create
        public ActionResult Create()
        {
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: MeetingNews/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeetingNews_ID,MeetingNews_Title,MeetingNews_Detail,MeetingNews_Date,MeetingNews_Starttime,MeetingNews_Endtime,MeetingNews_Place,MeetingNews_Modifier,MeetingNews_ModificationTime,MeetingNews_ModificationDate,Member_ID")] MeetingNews meetingNews)
        {
            if (ModelState.IsValid)
            {
                db.MeetingNews.Add(meetingNews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", meetingNews.Member_ID);
            return View(meetingNews);
        }

        // GET: MeetingNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingNews meetingNews = db.MeetingNews.Find(id);
            if (meetingNews == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", meetingNews.Member_ID);
            return View(meetingNews);
        }

        // POST: MeetingNews/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetingNews_ID,MeetingNews_Title,MeetingNews_Detail,MeetingNews_Date,MeetingNews_Starttime,MeetingNews_Endtime,MeetingNews_Place,MeetingNews_Modifier,MeetingNews_ModificationTime,MeetingNews_ModificationDate,Member_ID")] MeetingNews meetingNews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingNews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", meetingNews.Member_ID);
            return View(meetingNews);
        }

        // GET: MeetingNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingNews meetingNews = db.MeetingNews.Find(id);
            if (meetingNews == null)
            {
                return HttpNotFound();
            }
            return View(meetingNews);
        }

        // POST: MeetingNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingNews meetingNews = db.MeetingNews.Find(id);
            db.MeetingNews.Remove(meetingNews);
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
