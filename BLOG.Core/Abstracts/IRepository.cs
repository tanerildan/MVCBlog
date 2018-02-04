using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Core.Abstracts
{
   public interface IRepository<T>
        where T:class,new()
    {
        void Add(T model);
        void Update(T model);
        void Delete(int id);
        IEnumerable<T> GetList();
        T GetById(int id);
        IEnumerable<T> Where(Expression<Func<T, bool>> lambda);
        IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lambda);

        T GetObject(Expression<Func<T, bool>> lamda);
    }
}
