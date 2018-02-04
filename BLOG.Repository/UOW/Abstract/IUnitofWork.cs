using BLOG.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Repository.UOW.Abstract
{
   public interface IUnitofWork:IDisposable
    {
        int Commit();
        IRepository<T> GetRepo<T>() where T : class, new();
        void Dispose(bool disposing);
    }
}
