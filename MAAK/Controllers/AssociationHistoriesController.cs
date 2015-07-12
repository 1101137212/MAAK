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
    public class AssociationHistoriesController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: AssociationHistories
        public ActionResult Index()
        {
            var associationHistory = db.AssociationHistory.Include(a => a.Member);
            return View(associationHistory.ToList());
        }

        // GET: AssociationHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationHistory associationHistory = db.AssociationHistory.Find(id);
            if (associationHistory == null)
            {
                return HttpNotFound();
            }
            return View(associationHistory);
        }

        // GET: AssociationHistories/Create
        public ActionResult Create()
        {
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: AssociationHistories/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssociationHistory_ID,AssociationHistory_Detail,AssociationHistory_Modifier,AssociationHistory_ModificationTime,AssociationHistory_ModificationDate,Member_ID")] AssociationHistory associationHistory)
        {
            if (ModelState.IsValid)
            {
                db.AssociationHistory.Add(associationHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationHistory.Member_ID);
            return View(associationHistory);
        }

        // GET: AssociationHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationHistory associationHistory = db.AssociationHistory.Find(id);
            if (associationHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationHistory.Member_ID);
            return View(associationHistory);
        }

        // POST: AssociationHistories/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssociationHistory_ID,AssociationHistory_Detail,AssociationHistory_Modifier,AssociationHistory_ModificationTime,AssociationHistory_ModificationDate,Member_ID")] AssociationHistory associationHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associationHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationHistory.Member_ID);
            return View(associationHistory);
        }

        // GET: AssociationHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationHistory associationHistory = db.AssociationHistory.Find(id);
            if (associationHistory == null)
            {
                return HttpNotFound();
            }
            return View(associationHistory);
        }

        // POST: AssociationHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociationHistory associationHistory = db.AssociationHistory.Find(id);
            db.AssociationHistory.Remove(associationHistory);
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
