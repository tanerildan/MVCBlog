using BLOG.BLL.Validations.UsersValidations;
using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUnitofWork _uow;
        public static string _kod;
        public RegisterController(IUnitofWork uow)
        {
            _uow = uow;
        }
        // GET: Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost][ValidateAntiForgeryToken][AllowAnonymous]
        public ActionResult Register(Users model)
        {
            var valid = new UsersRegisterValidator(_uow).Validate(model);
            if (valid.IsValid)
            {
                model.RoleId = 2;    
                _uow.GetRepo<Users>().Add(model);
                _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
          
           
            else {
                valid.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
             
            }
            return View();
        }
    }
}