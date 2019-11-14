
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCNClinicApp
{
    public class RepositoryContext<Context, TEntity> : IRepository<TEntity> where TEntity : class where Context : DbContext, new()
    {

        private readonly Context _context;
        public RepositoryContext(Context context)
        {
            _context = context;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Get(int? id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity Add(TEntity model)
        {
            _context.Set<TEntity>().Add(model);
            _context.SaveChanges();
            return model;
        }
        public TEntity Update(TEntity model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }
        public void Delete(int id)
        {
            var TblCategory = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(TblCategory);
            _context.SaveChanges();
        }
    }
}
