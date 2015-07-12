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
    public class AssociationRulesController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: AssociationRules
        public ActionResult Index()
        {
            var associationRule = db.AssociationRule.Include(a => a.Member);
            return View(associationRule.ToList());
        }

        // GET: AssociationRules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationRule associationRule = db.AssociationRule.Find(id);
            if (associationRule == null)
            {
                return HttpNotFound();
            }
            return View(associationRule);
        }

        // GET: AssociationRules/Create
        public ActionResult Create()
        {
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: AssociationRules/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssociationRule_ID,AssociationRule_Title,AssociationRule_Detail,AssociationRule_Modifier,AssociationRule_ModificationTime,AssociationRule_ModificationDate,Member_ID")] AssociationRule associationRule)
        {
            if (ModelState.IsValid)
            {
                db.AssociationRule.Add(associationRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationRule.Member_ID);
            return View(associationRule);
        }

        // GET: AssociationRules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationRule associationRule = db.AssociationRule.Find(id);
            if (associationRule == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationRule.Member_ID);
            return View(associationRule);
        }

        // POST: AssociationRules/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssociationRule_ID,AssociationRule_Title,AssociationRule_Detail,AssociationRule_Modifier,AssociationRule_ModificationTime,AssociationRule_ModificationDate,Member_ID")] AssociationRule associationRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associationRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", associationRule.Member_ID);
            return View(associationRule);
        }

        // GET: AssociationRules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationRule associationRule = db.AssociationRule.Find(id);
            if (associationRule == null)
            {
                return HttpNotFound();
            }
            return View(associationRule);
        }

        // POST: AssociationRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociationRule associationRule = db.AssociationRule.Find(id);
            db.AssociationRule.Remove(associationRule);
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
