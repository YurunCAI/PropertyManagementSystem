using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Controllers
{
    public class AddNewPublicController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: AddNewPublic
        public ActionResult Index(string type = "facilities")
        {
            AddNewPublicMixModel mixModel = new AddNewPublicMixModel();
            IEnumerable<w_system_params> paramsList = db.w_system_params;
            //match searching params
            if (!string.IsNullOrEmpty(type))
            {
                paramsList = paramsList.Where(p => p.type == type);
            }


            IEnumerable<w_facilities> facList = db.w_facilities;
            mixModel.Params = paramsList.ToList();
            mixModel.Facilities = facList;
            return View(mixModel);
        }

        // GET: AddNewPublic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_facilities w_facilities = db.w_facilities.Find(id);
            if (w_facilities == null)
            {
                return HttpNotFound();
            }
            return View(w_facilities);
        }

        // GET: AddNewPublic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddNewPublic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,name,type,contact_name,contact_phone,contact_email,introduction")] w_facilities w_facilities)
        {
            if (ModelState.IsValid)
            {
                db.w_facilities.Add(w_facilities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(w_facilities);
        }

        // GET: AddNewPublic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_facilities w_facilities = db.w_facilities.Find(id);
            if (w_facilities == null)
            {
                return HttpNotFound();
            }
            return View(w_facilities);
        }

        // POST: AddNewPublic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,name,type,contact_name,contact_phone,contact_email,introduction")] w_facilities w_facilities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_facilities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_facilities);
        }

        // GET: AddNewPublic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_facilities w_facilities = db.w_facilities.Find(id);
            if (w_facilities == null)
            {
                return HttpNotFound();
            }
            return View(w_facilities);
        }

        // POST: AddNewPublic/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            w_facilities w_facilities = db.w_facilities.Find(id);
            db.w_facilities.Remove(w_facilities);
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
