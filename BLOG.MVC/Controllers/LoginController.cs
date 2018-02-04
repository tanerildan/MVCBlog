using BLOG.BLL.Validations.UsersValidations;
using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLOG.BLL.Services.Concretes;
using BLOG.BLL.Services.Abstracts;
using System.IO;

namespace BLOG.MVC.Controllers
{

    public class LoginController : Controller
    {

        private readonly IUnitofWork _uow;
        IMessageService _msgService;

        // GET: Login

        public LoginController(IUnitofWork uow, IMessageService msgService)
        {
            _uow = uow;
            _msgService = msgService;
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Users model)
        {
            var validator = new UsersValidator().Validate(model);
            if (validator.IsValid)
            {
                var result = _uow.GetRepo<Users>().Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if (result != null)
                {
                    return Redirect("/Dashboard/Admin/Home");

                }
                else
                {
                    ViewBag.msg = "Böyle bir kullanıcı mevcut değildir.";
                    return View();
                }
            }
            else
            {
                validator.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ForgotPassword(Users model)
        {
            string _kod;
            string url;
            var modeluser = _uow.GetRepo<Users>().Where(x => x.Email == model.Email).FirstOrDefault();
            if (modeluser != null)
            {
                _kod = Guid.NewGuid().ToString();
                url = Path.Combine("http://localhost:1403/Login/PasswordConfirm", "?kod=" + _kod);
                modeluser.Code = _kod;
                _uow.GetRepo<Users>().Update(modeluser);
                if (_uow.Commit() > 0)
                {
                    string msgString = "<a href=" + url + ">Parolamı değiştir</a>";
                    var msg = (MessageService)_msgService;
                    msg.To = model.Email;
                    bool Ok = msg.SendMessage("Subject", msgString);
                    if (Ok)
                    {
                        ViewBag.Msg = "Mail adresinize parola sıfırlama linki gönderilmiştir.";
                        return View();
                    }
                }
            }
            return View();
        }

        
        public ActionResult PasswordConfirm(string kod)
        {
            var model = _uow.GetRepo<Users>().Where(x => x.Code == kod).FirstOrDefault();
            ViewBag.UserMail = model.Email;
            return View(model);
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult PasswordConfirm(Users model)
        {
            if (ModelState.IsValid)
            {
                var user = _uow.GetRepo<Users>().Where(x => x.Code == model.Code).FirstOrDefault();
                user.Password = model.Password;
                user.PasswordConfirm = model.Password;
                _uow.GetRepo<Users>().Update(user);
                if (_uow.Commit() > 0)
                {
                    ViewBag.Message = "Parolanız başarıyla değiştirildi.";
                    return View(model);
                }
            }
            
            return View();
        }
    }
}