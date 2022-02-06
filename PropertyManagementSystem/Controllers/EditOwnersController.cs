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
    public class EditOwnersController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: EditOwners
        public ActionResult Index()
        {
            return View(db.w_owners.ToList());
        }

        // GET: EditOwners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_owners w_owners = db.w_owners.Find(id);
            if (w_owners == null)
            {
                return HttpNotFound();
            }
            return View(w_owners);
        }

        // GET: EditOwners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,phone,email,password")] w_owners w_owners)
        {
            if (ModelState.IsValid)
            {
                db.w_owners.Add(w_owners);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(w_owners);
        }

        // GET: EditOwners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_owners w_owners = db.w_owners.Find(id);
            if (w_owners == null)
            {
                return HttpNotFound();
            }
            return View(w_owners);
        }

        // POST: EditOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,phone,email,password")] w_owners w_owners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_owners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_owners);
        }

        // GET: EditOwners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_owners w_owners = db.w_owners.Find(id);
            if (w_owners == null)
            {
                return HttpNotFound();
            }
            return View(w_owners);
        }

        // POST: EditOwners/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            w_owners w_owners = db.w_owners.Find(id);
            db.w_owners.Remove(w_owners);
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
