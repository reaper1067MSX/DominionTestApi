using Dominion.Test.Infrastructure.Reposiroty.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dominion.Test.Infrastructure.Reposiroty.Service
{
    public abstract class GenericRepository<T, TEntity> : IGenericRepository<T> where T : class where TEntity : DominionContext
    {
        protected readonly TEntity _context;

        public GenericRepository(TEntity context)
        {
            _context = context;
        }

        void IGenericRepository<T>.Add(T entity)
        {
            try
            {
                //_context.Database.Log = s => Trace.WriteLine(s);                       
                _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IGenericRepository<T>.Delete(T entity)
        {
            try
            {
                var existing = _context.Set<T>().Find(entity);
                if (existing != null) _context.Set<T>().Remove(existing);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IGenericRepository<T>.Update(T entity)
        {
            try
            {
                var entry = _context.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.InnerException.ToString());
            }
        }
    }
}
