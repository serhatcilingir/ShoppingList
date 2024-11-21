using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Data.Context;
using Microsoft.EntityFrameworkCore;



using ShoppingList.Models.Models;


namespace ShoppingList.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ShoppingDbContext _dbContext;

        public BaseRepository(ShoppingDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                return false;
            }

            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<TEntity>> GetAllAsync(int page)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().Skip(50 * page).Take(50).AsNoTrackingWithIdentityResolution();

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Guid id, TEntity ent)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(ent);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}
