using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Models.Models;
using ShoppingList.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace ShoppingList.Data.Repositories
{
    public class UserProductRepository : BaseRepository<UserProduct>, IUserProductRepository
    {
        public UserProductRepository(ShoppingDbContext DbContext) : base(DbContext)
        {
        }
        public async Task<ICollection<UserProduct>> GetAllAsync(Guid UserId, int page)
        {
            IQueryable<UserProduct> query = _dbContext.Set<UserProduct>().Include(t => t.Product).Where(t => t.ProductList.UserId == UserId).Skip(50 * page).Take(50).AsNoTrackingWithIdentityResolution();

            return await query.ToListAsync();
        }
        public async Task<UserProduct> GetByIdAsync(Guid UserId, Guid id)
        {
            return await _dbContext.Set<UserProduct>().Include(t => t.Product).Where(t => t.ProductList.UserId == UserId).SingleOrDefaultAsync(t => t.Id == id);
        }
    }

}
