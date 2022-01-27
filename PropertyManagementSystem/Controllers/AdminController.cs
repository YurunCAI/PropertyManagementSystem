using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private PropertyManagementSystemEntities db = new PropertyManagementSystemEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Property Management
        //home page of property management
        public ActionResult PropertyIndex()
        {
            //get property information from db
            w_property_information info = db.w_property_information.FirstOrDefault();
            return View(info);
        }

        //Add new Property
        public ActionResult AddNewProperty()
        {
            return View();
        }

        //Add New Property Action
        [HttpPost]
        public ActionResult AddNewProperty(w_property_information info)
        {
            ViewBag.notice = "  ";
            db.w_property_information.Add(info);
            int result = db.SaveChanges();
            if (result > 0)
            {
                //Save success, junm to property basic info page
                return Content("<script>alert('Success Added !'); window.location.href='/Admin/PropertyIndex'; </script>");
            }
            else
            {
                ViewBag.notice = "Please Try Again";
            }
            return View();
        }

        //Edit Property
        public ActionResult EditProperty()
        {
            //get property information from db
            w_property_information info = db.w_property_information.FirstOrDefault();
            if (info == null)
            {
                return Content("<script>alert('Property Not Found, Please Add a New Property'); window.location.href='/Admin/AddNewProperty'; </script>");
            }
            return View(info);
        }
        //Edit Property Action
        [HttpPost]
        public ActionResult EditProperty(w_property_information info)
        {
            db.Entry(info).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                //Save success, junm to property basic info page
                return Content("<script>alert('Success Edit !'); window.location.href='/Admin/PropertyIndex'; </script>");
            }
            else
            {
                ViewBag.notice = "Please Try Again";
            }
            return View();
        }
    }
}