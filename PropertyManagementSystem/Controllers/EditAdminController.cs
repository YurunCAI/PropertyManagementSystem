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
    public class EditAdminController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: EditAdmin
        public ActionResult Index()
        {
            return View(db.w_admin.ToList());
        }

        // GET: EditAdmin/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    w_admin w_admin = db.w_admin.Find(id);
        //    if (w_admin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(w_admin);
        //}

        // GET: EditAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,username,password,nickname,permission,createtime")] w_admin w_admin)
        {
            if (ModelState.IsValid)
            {
                db.w_admin.Add(w_admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(w_admin);
        }

        // GET: EditAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_admin w_admin = db.w_admin.Find(id);
            if (w_admin == null)
            {
                return HttpNotFound();
            }
            return View(w_admin);
        }

        // POST: EditAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,username,password,nickname,permission,createtime")] w_admin w_admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_admin);
        }

        //// GET: EditAdmin/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    w_admin w_admin = db.w_admin.Find(id);
        //    if (w_admin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(w_admin);
        //}

        // POST: EditAdmin/Delete/5
        // CHANGE - using GET to delete
        public ActionResult DeleteConfirmed(int id)
        {
            w_admin w_admin = db.w_admin.Find(id);
            db.w_admin.Remove(w_admin);
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
