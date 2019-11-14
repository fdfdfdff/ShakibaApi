
using System;
using System.Collections.Generic;

namespace RCNClinicApp
{
    public interface IRepository < TEntity > where TEntity : class
    {
        List<TEntity> GetAll();
        List<TEntity> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int? id);
        TEntity Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity model);
        TEntity Update(TEntity model);
        void Delete(int id);
    }
}
