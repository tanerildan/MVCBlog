using BLOG.DAL.Entities;
using BLOG.Repository.UOW.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Validations.CommentsValidations
{
   public class CommentValidator:AbstractValidator<Comments>
    {
        private readonly IUnitofWork _uow;
        public CommentValidator(IUnitofWork uow)
        {
            _uow = uow;
        }
    }
}
