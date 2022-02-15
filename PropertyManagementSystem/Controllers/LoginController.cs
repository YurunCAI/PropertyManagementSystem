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
            //if (Session["nickname"] == null) return Redirect("/Login/Index"); 
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
                //Session
                Session["username"] = admin.username;
                Session["nickname"] = admin.nickname;

                //login success, jump to back-end management page 
                return Redirect("/Admin/Index");
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
                //Session
                Session["id"] = owner.id;
                Session["email"] = owner.email;
                Session["name"] = owner.name;
                Session["phone"] = owner.phone;

                //login success, jump to back-end owner management page 
                return Redirect("/OwnerHome/Index");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            Session["nickname"] = null;
            return Redirect("/Login/index");
        }
        public ActionResult OwnerLogout()
        {
            Session["id"] = null;
            Session["email"] = null;
            Session["name"] = null;
            Session["phone"] = null;
            return Redirect("/Login/OwnerIndex");
        }
    }
}