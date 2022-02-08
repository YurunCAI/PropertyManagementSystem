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
    public class AddOwnerController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: AddOwner
        public ActionResult Index()
        {
            return View(db.w_owners.ToList());
        }

        // POST: AddOwner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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
