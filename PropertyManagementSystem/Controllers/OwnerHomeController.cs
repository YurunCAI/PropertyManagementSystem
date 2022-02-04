using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagementSystem.Controllers
{
    public class OwnerHomeController : Controller
    {
        // GET: OwnerHome
        public ActionResult Index()
        {
            return View();
        }
    }
}