using BLOG.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BLOG.Core.Concretes
{
   public class EFRepositoryBase<T,Tcontext>:IRepository<T>,IDisposable
        where T:class,new()
       where Tcontext:DbContext
    {
        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;

        public EFRepositoryBase(DbContext Context)
        {
            _dbContext = Context;
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T model)
        {
            _dbSet.Add(model);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_disposed == false)
                {
                    Dispose();
                    _disposed = true;
                }
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();

            GC.SuppressFinalize(this);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return _dbSet.ToList();
        }

        public void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> lambda)
        {
            return _dbSet.Where(lambda).ToList();
        }

        public IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lambda)
        {
            return _dbSet.Where(lambda).AsQueryable<T>();
        }

        public T GetObject(Expression<Func<T, bool>> lamda)
        {
            return _dbSet.FirstOrDefault(lamda);
        }
    }
}
