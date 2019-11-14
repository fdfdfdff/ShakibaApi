using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCNClinicApp
{
    public interface IRepositoryAsync<TEntity> where TEntity : class
    {
       

        Task<IEnumerable<TEntity>> GetAll(string[] includetbl = null);
        Task<IEnumerable<TEntity>> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, string[] includetbl = null);

        Task<TEntity> Get(object id);
        Task<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Add(TEntity model);
        Task<TEntity> Update(TEntity model);
        Task Delete(object id);
    }
}
