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
   public class CategoryAddValidator:AbstractValidator<Category>
    {
        private readonly IUnitofWork _uow;
        public CategoryAddValidator(IUnitofWork uow)
        {
            _uow = uow;
            RuleFor(x => x.Name).NotNull().WithMessage("Kategori adı boş geçilemez").
                MaximumLength(20).WithMessage("Karakter kullanımı aşımı. Daha fazla karakter giremezsiniz").
                Must(UniqCategoryCheck).WithMessage("Böyle bir kullanıcı zaten mevcut!!");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage(" Karakter kullanımı aşımı. Daha fazla karakter giremezsiniz");
        }

        public bool UniqCategoryCheck(string name)
        {
            var data = _uow.GetRepo<Category>().Where(x => x.Name == name).FirstOrDefault();
            if (data == null)
            {
                return true;
            }
            return false;
        }
    }
}
