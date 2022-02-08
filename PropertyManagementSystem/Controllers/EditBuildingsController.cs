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
    public class EditBuildingsController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: EditBuildings
        public ActionResult Index()
        {
            return View(db.w_buildings.ToList());
        }

        // GET: EditBuildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_buildings w_buildings = db.w_buildings.Find(id);
            if (w_buildings == null)
            {
                return HttpNotFound();
            }
            return View(w_buildings);
        }


        // GET: EditBuildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_buildings w_buildings = db.w_buildings.Find(id);
            if (w_buildings == null)
            {
                return HttpNotFound();
            }
            return View(w_buildings);
        }

        // POST: EditBuildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,address,type,owner,phone,email,rooms,building_area,land_area")] w_buildings w_buildings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_buildings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_buildings);
        }

        // POST: EditBuildings/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            w_buildings w_buildings = db.w_buildings.Find(id);
            db.w_buildings.Remove(w_buildings);
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
