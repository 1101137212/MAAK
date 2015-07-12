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
    public class AwardsController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: Awards
        public ActionResult Index()
        {
            var award = db.Award.Include(a => a.Member);
            return View(award.ToList());
        }

        // GET: Awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Award.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // GET: Awards/Create
        public ActionResult Create()
        {
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: Awards/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Award_ID,Award_Title,Award_Detail,Award_Date,Member_ID")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Award.Add(award);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", award.Member_ID);
            return View(award);
        }

        // GET: Awards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Award.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", award.Member_ID);
            return View(award);
        }

        // POST: Awards/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Award_ID,Award_Title,Award_Detail,Award_Date,Member_ID")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Entry(award).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", award.Member_ID);
            return View(award);
        }

        // GET: Awards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Award.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Award award = db.Award.Find(id);
            db.Award.Remove(award);
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
