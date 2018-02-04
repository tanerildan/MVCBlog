using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Validations.PostValidations
{
   public class PostUpdateValidator:AbstractValidator<Post>
    {
        private readonly IUnitofWork _uow;
        public PostUpdateValidator(IUnitofWork uow)
        {
            _uow = uow;
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez").
                MaximumLength(100).WithMessage("100 karakterden fazla girilrmez");
            RuleFor(x => x.Summary).MaximumLength(200).WithMessage("200 karakterden fazla giriş yapılamaz");

        }
    }
}
