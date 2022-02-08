using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Controllers
{
    public class AddTypesController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: AddTypes
        public ActionResult Index()
        {
            return View(db.w_feetypes.ToList());
        }

        // GET: AddTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_feetypes w_feetypes = db.w_feetypes.Find(id);
            if (w_feetypes == null)
            {
                return HttpNotFound();
            }
            return View(w_feetypes);
        }

        // GET: AddTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,type")] w_feetypes w_feetypes)
        {
            if (ModelState.IsValid)
            {
                db.w_feetypes.Add(w_feetypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(w_feetypes);
        }

        // GET: AddTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_feetypes w_feetypes = db.w_feetypes.Find(id);
            if (w_feetypes == null)
            {
                return HttpNotFound();
            }
            return View(w_feetypes);
        }

        // POST: AddTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type")] w_feetypes w_feetypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_feetypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_feetypes);
        }

        // GET: AddTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_feetypes w_feetypes = db.w_feetypes.Find(id);
            if (w_feetypes == null)
            {
                return HttpNotFound();
            }
            return View(w_feetypes);
        }

        // POST: AddTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            w_feetypes w_feetypes = db.w_feetypes.Find(id);
            db.w_feetypes.Remove(w_feetypes);
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
