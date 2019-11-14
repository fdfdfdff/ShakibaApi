using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCNClinicApp
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly ContextDb _context;
        public RepositoryAsync(ContextDb context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAll(string[] includetbl = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includetbl != null)
            {
                foreach (var item in includetbl)
                    query = query.Include(item);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, string[] includetbl = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);
            if (includetbl != null)
            {
                foreach (var item in includetbl)
                    query = query.Include(item);
            }

            return await query.ToListAsync();
        }


        public async Task<TEntity> Get(object id)
        {

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {

            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> Add(TEntity TblCategory)
        {
            _context.Set<TEntity>().Add(TblCategory);
            await _context.SaveChangesAsync();
            return TblCategory;
        }
        public async Task<TEntity> Update(TEntity TblCategory)
        {
            _context.Update(TblCategory);
            await _context.SaveChangesAsync();
            return TblCategory;
        }
        public async Task Delete(object id)
        {
            var TblCategory = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(TblCategory);
            await _context.SaveChangesAsync();
        }

    }
}
