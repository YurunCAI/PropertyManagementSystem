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
    public class AddBuildingController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: AddBuilding
        public ActionResult Index()
        {
            return View(db.w_buildings.ToList());
        }

        // POST: AddBuilding/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,address,type,owner,phone,email,rooms,building_area,land_area")] w_buildings w_buildings)
        {
            if (ModelState.IsValid)
            {
                db.w_buildings.Add(w_buildings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(w_buildings);
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
