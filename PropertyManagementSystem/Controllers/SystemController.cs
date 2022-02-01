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
    public class SystemController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: System
        public ActionResult Index(string type="")
        {
            IEnumerable<w_system_params> list = db.w_system_params;
            //match searching params
            if (!string.IsNullOrEmpty(type))
            {
                list = list.Where(p => p.type == type);
            }
            return View(list.ToList());
        }

        //// GET: System/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    w_system_params w_system_params = db.w_system_params.Find(id);
        //    if (w_system_params == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(w_system_params);
        //}

        // GET: System/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: System/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create([Bind(Include = "id,code,name,type")] w_system_params w_system_params)
        {
            db.w_system_params.Add(w_system_params);       
            if (db.SaveChanges() > 0)
            {
                //Save success, junm to property basic info page
                return Content("<script>alert('Success Save System Params !'); window.location.href='/System/Index'; </script>");
            }
            else
            {
                ViewBag.notice = "Please Try Again";
            }
            return View(w_system_params);
        }

        // GET: System/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_system_params w_system_params = db.w_system_params.Find(id);
            if (w_system_params == null)
            {
                return HttpNotFound();
            }
            return View(w_system_params);
        }

        // POST: System/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name,type")] w_system_params w_system_params)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_system_params).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_system_params);
        }

        //// GET: System/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    w_system_params w_system_params = db.w_system_params.Find(id);
        //    if (w_system_params == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(w_system_params);
        //}

        // POST: System/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            w_system_params w_system_params = db.w_system_params.Find(id); //search in database
            db.w_system_params.Remove(w_system_params); //Remove data
            db.SaveChanges();//save database change
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
