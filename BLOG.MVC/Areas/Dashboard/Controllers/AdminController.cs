using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.MVC.Areas.Dashboard.Controllers
{
    public class AdminController : Controller
    {
        // GET: Dashboard/Admin
        public ActionResult Home()
        {
            return View();
        }
    }
}