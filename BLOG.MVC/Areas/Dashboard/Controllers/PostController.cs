using BLOG.BLL.Validations.PostValidations;
using BLOG.DAL.Entities;
using BLOG.MVC.Areas.Dashboard.Models;
using BLOG.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.MVC.Areas.Dashboard.Controllers
{
    public class PostController : Controller
    {
        private readonly IUnitofWork _uow;
        public PostController(IUnitofWork uow)
        {
            _uow = uow;
        }
        // GET: Dashboard/Post
        public ActionResult Post()
        {
            var data = _uow.GetRepo<Post>().GetList();
            return View(data);
        }
        public ActionResult PostAdd()
        {
            var categories = _uow.GetRepo<Category>().GetList().ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostAdd(PostViewModel model)
        {

            var validator = new PostAddValidator(_uow).Validate(model.Post);
            if (validator.IsValid)
            {
                if (model.PostedPicture != null)
                {
                    string dosyaYolu = Path.GetFileName(model.PostedPicture.FileName);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/Images"), dosyaYolu);
                    model.PostedPicture.SaveAs(yuklemeYeri);
                    model.Post.PostPic = dosyaYolu;
                }
                
                model.Post.PostDate = DateTime.Now;
                model.Post.LikeCount = 0;
                model.Post.DislikeCount = 0;
                model.Post.UserId = 1;
                _uow.GetRepo<Post>().Add(model.Post);

                var cat = _uow.GetRepo<Category>().GetById(model.Post.CategoryId);
                cat.PostCount = cat.PostCount + 1;
                _uow.GetRepo<Category>().Update(cat);
                _uow.Commit();
                ViewBag.Msg = "Gönderi başarılı bir şekilde kaydedildi";
                return RedirectToAction("Post", "Post");
            }
            else
            {
                validator.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }
            ViewBag.Msg = "İşlem gerçekleştirilemedi";
            return View();
        }

       public ActionResult PostUpdate(int id)
        {
            var model = new PostViewModel
            {
                Post = _uow.GetRepo<Post>().GetObject(x => x.Id == id)
            };
            return View(model);
        }
        [HttpPost] [ValidateAntiForgeryToken]
       public ActionResult PostUpdate(PostViewModel model)
        {
            var validator = new PostUpdateValidator(_uow).Validate(model.Post);
            if (validator.IsValid)
            {
                if (model.PostedPicture != null)
                {
                    string dosyaYolu = Path.GetFileName(model.PostedPicture.FileName);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/Images"), dosyaYolu);
                    model.PostedPicture.SaveAs(yuklemeYeri);
                    model.Post.PostPic = dosyaYolu;
                }
                _uow.GetRepo<Post>().Update(model.Post);
                _uow.Commit();
                ViewBag.Msg = "Değişiklikler başarıyla kaydedildi.";
                return RedirectToAction("Post", "Post");
            }
            else
            {
                validator.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }
            ViewBag.Msg = "İşlem gerçekleştirilemedi";
            return View();
        }

        public ActionResult Sil()
        {
            return View();
        }
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Sil(int id)
        {
            _uow.GetRepo<Post>().Delete(id);
            ViewBag.Msg = "Gönderi silinmiştir";
            var cat = _uow.GetRepo<Category>().GetById(id);
            cat.PostCount = cat.PostCount - 1;
            _uow.GetRepo<Category>().Update(cat);
            _uow.Commit();
            return RedirectToAction("Post", "Post");
        }
    }
}