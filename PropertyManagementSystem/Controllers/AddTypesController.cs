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
