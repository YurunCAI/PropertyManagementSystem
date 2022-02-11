using PropertyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagementSystem.Controllers
{
    public class MyInfoController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: MyInfo
        public ActionResult Index(string email)
        {
            w_owners owner = db.w_owners.FirstOrDefault(p => p.email == email);
            ViewBag.Email = email;
            ViewBag.Phone = owner.phone;
            ViewBag.Name = owner.name;
            return View();
        }
    }
}