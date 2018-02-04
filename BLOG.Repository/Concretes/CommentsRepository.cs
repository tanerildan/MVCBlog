using BLOG.Core.Concretes;
using BLOG.DAL.Context;
using BLOG.DAL.Entities;
using BLOG.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Repository.Concretes
{
   public class CommentsRepository:EFRepositoryBase<Comments,ProjectContext>,ICommentsRepository
    {
        public CommentsRepository(DbContext Context):base(Context)
        {

        }
    }
}
