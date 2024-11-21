using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ShoppingList.Models.Models;
using ShoppingList.Data.Repositories;
using ShoppingList.Data.Context;

namespace ShoppingList.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ShoppingDbContext DbContext) : base(DbContext)
        {
        }

        public async Task<User> GetByEmailAsync(string Email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(t => t.Email == Email);
        }
    }

}
