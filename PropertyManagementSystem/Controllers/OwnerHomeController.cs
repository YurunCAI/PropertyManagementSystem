using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Controllers
{
    public class OwnerHomeController : Controller
    {

        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();
        // GET: OwnerHome
        public ActionResult Index()
        {
            var email = Session["email"].ToString();
            w_owners owner = db.w_owners.FirstOrDefault(p => p.email == email);
            ViewBag.Email = owner.email;
            ViewBag.Phone = owner.phone;
            ViewBag.Name = owner.name;
            return View();
        }
    }
}