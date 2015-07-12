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
    public class AssociationEventsController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: AssociationEvents
        public ActionResult Index()
        {
            var associationEvent = db.AssociationEvent.Include(a => a.Member);
            return View(associationEvent.ToList());
        }

        // GET: AssociationEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationEvent associationEvent = db.AssociationEvent.Find(id);
            if (associationEvent == null)
            {
                return HttpNotFound();
            }
            return View(associationEvent);
        }

        // GET: AssociationEvents/Create
        public ActionResult Create()
        {
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: AssociationEvents/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssociationEvent_ID,AssociationEvent_Title,AssociationEvent_Detail,AssociationEvent_Year,AssociationEvent_Picture,AssociationEvent_Modifier,AssociationEvent_ModificationTime,AssociationEvent_ModificationDate,Member_ID")] AssociationEvent associationEvent)
        {
            if (ModelState.IsValid)
            {
                db.AssociationEvent.Add(associationEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationEvent.Member_ID);
            return View(associationEvent);
        }

        // GET: AssociationEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationEvent associationEvent = db.AssociationEvent.Find(id);
            if (associationEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationEvent.Member_ID);
            return View(associationEvent);
        }

        // POST: AssociationEvents/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssociationEvent_ID,AssociationEvent_Title,AssociationEvent_Detail,AssociationEvent_Year,AssociationEvent_Picture,AssociationEvent_Modifier,AssociationEvent_ModificationTime,AssociationEvent_ModificationDate,Member_ID")] AssociationEvent associationEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associationEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationEvent.Member_ID);
            return View(associationEvent);
        }

        // GET: AssociationEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationEvent associationEvent = db.AssociationEvent.Find(id);
            if (associationEvent == null)
            {
                return HttpNotFound();
            }
            return View(associationEvent);
        }

        // POST: AssociationEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociationEvent associationEvent = db.AssociationEvent.Find(id);
            db.AssociationEvent.Remove(associationEvent);
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
