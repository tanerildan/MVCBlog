using BLOG.Core.Abstracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Validations.BaseValidator
{
   public abstract class BaseValidator<T>:AbstractValidator<T> where T:class,new()
    {
        protected IRepository<T> _baseRepo;
        public BaseValidator(IRepository<T> baseRepo)
        {
            _baseRepo = baseRepo;
            InitConfig();
        }
        public abstract void InitConfig();
    }
}
