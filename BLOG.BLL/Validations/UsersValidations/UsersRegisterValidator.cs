using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Validations.UsersValidations
{
   public class UsersRegisterValidator:AbstractValidator<Users>
    {
        private readonly IUnitofWork _uow;
        public UsersRegisterValidator(IUnitofWork uow)
        {
            _uow = uow;
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş geçilemez")
                .Must(UniqEmailCheck).WithMessage("Böyle bir kullanıcı zaten mevcut!!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola boş geçilemez")
                .Equal(x=> x.PasswordConfirm).WithMessage("Parola aynı değil");
            RuleFor(x => x.PasswordConfirm)
                .NotEmpty().WithMessage("Bu alan boş geçilemez");
               
          
        }

        public bool UniqEmailCheck(string mail)
        {
            var data = _uow.GetRepo<Users>().Where(x => x.Email == mail).FirstOrDefault();
            if (data == null)
            {
                return true;
            }
            return false;
        }
        
    }
}
