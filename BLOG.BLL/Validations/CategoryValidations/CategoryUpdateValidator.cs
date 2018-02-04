using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Validations.CategoryValidations
{
  public  class CategoryUpdateValidator:AbstractValidator<Category>
    {
        private readonly IUnitofWork _uow;
        public CategoryUpdateValidator(IUnitofWork uow)
        {
            _uow = uow;
            RuleFor(x => x.Name).NotNull().WithMessage("Kategori alanı boş geçiilemez").
                MaximumLength(20).WithMessage("20 karakterden fazla girilemez");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("100 karakterden fazla girilemez");
        }
    }
}
