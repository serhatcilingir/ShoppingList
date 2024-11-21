﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Models.Models;
using ShoppingList.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace ShoppingList.Data.Repositories
{
    public class ProductListRepository : BaseRepository<ProductList>, IProductListRepository
    {
        public ProductListRepository(ShoppingDbContext DbContext) : base(DbContext)
        {
        }
        public async Task<ICollection<ProductList>> GetAllAsync(Guid UserId, int page)
        {
            var query = _dbContext.Set<ProductList>().Include(t => t.UserProducts).Where(t => t.UserId == UserId).Skip(50 * page).Take(50).AsNoTrackingWithIdentityResolution();

            return await query.ToListAsync();
        }
        public async Task<ProductList> GetByIdAsync(Guid UserId, Guid id)
        {
            return await _dbContext.Set<ProductList>().Include(t => t.UserProducts).Where(t => t.UserId == UserId).SingleOrDefaultAsync(t => t.Id == id);
        }
    }

}
