using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.MVC.SiteController
{
    public class SiteHomeController : Controller
    {
        private readonly IUnitofWork _uow;
        public SiteHomeController(IUnitofWork uow)
        {
            _uow = uow;
        }
        // GET: SiteHome
        public ActionResult Home()
        {
            var data = _uow.GetRepo<Post>().GetList().OrderBy(x => x.PostDate);
            return View(data);
        }
        public ActionResult PostView()
        {
            return View();
        }
    }
}