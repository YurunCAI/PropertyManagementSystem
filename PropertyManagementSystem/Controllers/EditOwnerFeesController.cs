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
    public class EditOwnerFeesController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: EditOwnerFees
        public ActionResult Index()
        {
            return View(db.w_ownerfees.ToList());
        }

        // GET: EditOwnerFees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_ownerfees w_ownerfees = db.w_ownerfees.Find(id);
            if (w_ownerfees == null)
            {
                return HttpNotFound();
            }
            return View(w_ownerfees);
        }


        // GET: EditOwnerFees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_ownerfees w_ownerfees = db.w_ownerfees.Find(id);
            if (w_ownerfees == null)
            {
                return HttpNotFound();
            }
            return View(w_ownerfees);
        }

        // POST: EditOwnerFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,name,email,amount,create_time,due_time")] w_ownerfees w_ownerfees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_ownerfees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_ownerfees);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            w_ownerfees w_ownerfees = db.w_ownerfees.Find(id);
            db.w_ownerfees.Remove(w_ownerfees);
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
