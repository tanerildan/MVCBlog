using BLOG.DAL.Entities;
using BLOG.MVC.Models;
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
            PostCommentModel model = new PostCommentModel();
            model.Posts = _uow.GetRepo<Post>().GetList();
            return View(model);
        }

        public ActionResult PostView(int id)
        {
            PostCommentModel model = new PostCommentModel();
            var gonderi = _uow.GetRepo<Post>().Where(x => x.Id == id);
            model.Posts = gonderi;
            model.Gonderi = gonderi.FirstOrDefault();
            model.Yorumlar = _uow.GetRepo<Comments>().Where(x => x.PostId == id);
            return View(model); 
          
        }

        [HttpPost]
        public JsonResult Yorum(string Yorum, int postid)
        {
            CommentViewModel model = new CommentViewModel();
            model.CommentBody = Yorum;
           
            model.CommentDate = DateTime.Now.ToShortDateString();
            model.UserId = 1;
            model.PostId = postid;
            

            Comments c = new Comments();
            c.PostCommend = model.CommentBody;
            c.CommendDate = DateTime.Now;
            c.UserId = 1;
            c.IsDeleted = false;
            c.LikeCount = 0;
            c.DislikeCount = 0;
            c.PostId = model.PostId;

            _uow.GetRepo<Comments>().Add(c);
            _uow.Commit();

            return Json(model);
               
        }

    }
}
