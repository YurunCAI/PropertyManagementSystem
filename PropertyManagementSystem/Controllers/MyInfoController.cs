using PropertyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagementSystem.Controllers
{
    public class MyInfoController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: MyInfo
        public ActionResult Index()
        {
            var email = Session["email"].ToString();

            IEnumerable<w_buildings> buildings = db.w_buildings;
            if (!string.IsNullOrEmpty(email))
            {
                buildings = buildings.Where(p => p.email == email);
            }
            return View(buildings.ToList());
        }

        // GET: EditOwners/Edit/5
        public ActionResult ChangePassword()
        {
            var email = Session["email"].ToString();
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_owners owner = db.w_owners.FirstOrDefault(p => p.email == email);
            if (owner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Email = owner.email;
            ViewBag.Id = owner.id;
            ViewBag.Phone = owner.phone;
            return View(owner);
        }

        // POST: EditOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "id,name,phone,email,password")] w_owners owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owner).State = EntityState.Modified;
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                Session["name"] = owner.name;
                Session["phone"] = owner.phone;
                Session["email"] = owner.email;
                return Redirect("/OwnerHome/Index");
            }
            return View();
        }
    }
}