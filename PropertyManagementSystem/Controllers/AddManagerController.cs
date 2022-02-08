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
    public class AddManagerController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: AddManager
        public ActionResult Index()
        {
            return View(db.w_managers.ToList());
        }

        // GET: AddManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_managers w_managers = db.w_managers.Find(id);
            if (w_managers == null)
            {
                return HttpNotFound();
            }
            return View(w_managers);
        }

        // GET: AddManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,account,password,name,phone,email")] w_managers w_managers)
        {
            if (ModelState.IsValid)
            {
                db.w_managers.Add(w_managers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(w_managers);
        }

        // GET: AddManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_managers w_managers = db.w_managers.Find(id);
            if (w_managers == null)
            {
                return HttpNotFound();
            }
            return View(w_managers);
        }

        // POST: AddManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,account,password,name,phone,email")] w_managers w_managers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_managers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_managers);
        }

        // GET: AddManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_managers w_managers = db.w_managers.Find(id);
            if (w_managers == null)
            {
                return HttpNotFound();
            }
            return View(w_managers);
        }

        // POST: AddManager/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            w_managers w_managers = db.w_managers.Find(id);
            db.w_managers.Remove(w_managers);
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
