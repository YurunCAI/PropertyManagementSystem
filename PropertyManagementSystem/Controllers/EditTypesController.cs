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
    public class EditTypesController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: EditTypes
        public ActionResult Index()
        {
            return View(db.w_feetypes.ToList());
        }

        // GET: EditTypes/Details/5
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

        // GET: EditTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: EditTypes/Edit/5
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

        // POST: EditTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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

        // GET: EditTypes/Delete/5
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

        // POST: EditTypes/Delete/5
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
