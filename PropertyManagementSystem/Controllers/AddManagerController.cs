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
