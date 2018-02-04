using BLOG.DAL.Entities;
using BLOG.Repository.Abstracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Validations.UsersValidations
{
    public class UsersValidator:AbstractValidator<Users>
    {
        
        public UsersValidator()
        {            
            InitConfig();
        }
        public virtual void InitConfig()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");

        }
    }
}
