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
   public class PostAddValidator:AbstractValidator<Post>
    {
        private readonly IUnitofWork _uow;
        public PostAddValidator(IUnitofWork uow)
        {
            _uow = uow;
            RuleFor(x => x.Title).NotNull().WithMessage("Başlık boş geçilemez").
                MaximumLength(100).WithMessage("Karakter kullanımı aşıldı, daha fazla karakter giremezssiniz.");
            RuleFor(x => x.Tag).MaximumLength(20).WithMessage("Karakter kullanımı aşıldı, daha fazla karakter giremezssiniz.");
            RuleFor(x => x.PostDate).NotNull().WithMessage("Tarih boş geçilemez");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("Kategori alanı boş geçilemez");
        }
    }
}
