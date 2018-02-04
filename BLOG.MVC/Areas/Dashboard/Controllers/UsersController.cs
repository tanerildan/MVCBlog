using BLOG.BLL.Validations.UsersValidations;
using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.MVC.Areas.Dashboard.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitofWork _uow;
        public UsersController(IUnitofWork uow)
        {
            _uow = uow;
        }
        // GET: Dashboard/Users
        public ActionResult Users(Users model)
        {
            var data = _uow.GetRepo<Users>().GetList();
            return View(data);
        }

        public ActionResult UsersUpdate(int id)
        {
            var model = _uow.GetRepo<Users>().GetObject(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsersUpdate(Users model)
        {
            var validator = new UsersUpdateValidator(_uow).Validate(model);
            if (validator.IsValid)
            {
                _uow.GetRepo<Users>().Update(model);
                if (_uow.Commit() > 0)
                {
                    ViewBag.Msg="Başarıyla kaydedildi.";
                    return RedirectToAction("Users", "Users");
                }
                return View();


            }
            else
            {
                validator.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }
            return View();
        }

        public ActionResult Sil(int id)
        {
            _uow.GetRepo<Users>().Delete(id);
            _uow.Commit();
            ViewBag.Mesg = "Kullanıcı silindi";
            return RedirectToAction("Users","Users");
        }

    }
}