﻿using BLOG.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLOG.Core.Abstracts;
using BLOG.Core.Concretes;

namespace BLOG.Repository.UOW.Concrete
{
   public class UnitofWork:IUnitofWork
    {
        protected DbContext _context;
        protected bool _disposed = false;

        public UnitofWork(DbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            int resultSet = 0;
            using (_context.Database.BeginTransaction())
            {
                try
                {
                    resultSet = _context.SaveChanges();
                    _context.Database.CurrentTransaction.Commit();
                }
                catch (Exception)
                {

                    _context.Database.CurrentTransaction.Rollback();
                    resultSet = 0;
                }
            }
            return resultSet;
        }
        public void Dispose(bool disposing)
        {
            if (_disposed == false)
            {
                Dispose();
                _disposed = true;
                _context = null;
            }
        }

        public void Dispose()
        {
            _context.Dispose();

            GC.SuppressFinalize(this);
        }

       

        public IRepository<T> GetRepo<T>() where T : class, new()
        {
            return new EFRepositoryBase<T, DbContext>(_context);
        }
    }
}
