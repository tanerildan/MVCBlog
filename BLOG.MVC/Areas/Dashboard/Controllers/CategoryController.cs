using BLOG.BLL.Validations.CategoryValidations;
using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.MVC.Areas.Dashboard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitofWork _uow;
        public CategoryController(IUnitofWork uow)
        {
            _uow = uow;
        }
        [Authorize]
        // GET: Dashboard/Category
        public ActionResult Category(Category model)
        {
            var data = _uow.GetRepo<Category>().GetList();
            return View(data);
        }
        [Authorize]
        public ActionResult CategoryUpdate(int id)
        {
            var model = _uow.GetRepo<Category>().GetObject(x => x.Id == id);
            return View(model);
        }
        [HttpPost] [ValidateAntiForgeryToken][Authorize]
        public ActionResult CategoryUpdate(Category model)
        {
            var validator = new CategoryUpdateValidator(_uow).Validate(model);
            if (validator.IsValid)
            {
                _uow.GetRepo<Category>().Update(model);
                if (_uow.Commit()>0)
                {
                    ViewBag.Msg = "Başarıyla kaydedildi.";
                    return RedirectToAction("Category", "Category");
                }
                return View();
            }
            else
            {
                validator.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }
            return View();
        }
        [Authorize]
        public ActionResult Sil(int id)
        {
            _uow.GetRepo<Category>().Delete(id);
            _uow.Commit();
            ViewBag.Mesg = "Başarıyla silindi";
            return RedirectToAction("Category", "Category");
        }
        [Authorize]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost][ValidateAntiForgeryToken][Authorize]
        public ActionResult CategoryAdd(Category model)
        {
            var validator = new CategoryAddValidator(_uow).Validate(model);
            if (validator.IsValid)
            {
                model.PostCount = 0;
                _uow.GetRepo<Category>().Add(model);
                _uow.Commit();
                ViewBag.Msg = "Yeni kategori ekleme işlemi başarıyla gerçekleştirildi";
                return RedirectToAction("Category", "Category");
            }
            else
            {
                validator.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }
            return View();
        }
    }
}