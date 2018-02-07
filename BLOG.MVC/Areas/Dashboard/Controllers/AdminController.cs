using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BLOG.MVC.Areas.Dashboard.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        // GET: Dashboard/Admin
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}