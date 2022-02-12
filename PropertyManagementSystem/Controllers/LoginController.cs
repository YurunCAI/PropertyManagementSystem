using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        //DB content
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Login function
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            //db search data (user)
            w_admin admin = db.w_admin.FirstOrDefault(p => p.username == username);
            if(admin == null)
            {
                ViewBag.notice = "No such User";
            }else if(admin.password != password)
            {
                ViewBag.notice = "Wrong password";
            }
            else
            {
                //login success, jump to back-end management page 
                return Redirect("/Admin/index");
            }

            return View();
        }

        // GET: Login
        public ActionResult OwnerIndex()
        {
            return View();
        }

        //Login function
        [HttpPost]
        public ActionResult OwnerIndex(string email, string password)
        {
            //db search data (user)
            w_owners owner = db.w_owners.FirstOrDefault(p => p.email == email);
            if (owner == null)
            {
                ViewBag.notice = "No such User";
            }
            else if (owner.password != password)
            {
                ViewBag.notice = "Wrong password";
            }
            else
            {
                //login success, jump to back-end owner management page 
                string url = "/OwnerHome/Index?email=" + email;
                return Redirect(url);
            }

            return View();
        }
    }
}