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
   public class UsersUpdateValidator:AbstractValidator<Users>
    {
        private readonly IUnitofWork _uow;
        public UsersUpdateValidator(IUnitofWork uow)
        {
            _uow = uow;
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez")
                .MaximumLength(50).WithMessage("Karakter aşımı, daha fazla karakter girilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim alanı boş geçilemez")
                .MaximumLength(50).WithMessage("Karakter aşımı, daha fazla karakter girilemez");
                
        }
    }
}
