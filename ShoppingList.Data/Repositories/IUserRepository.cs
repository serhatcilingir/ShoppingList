using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Models.Models;

namespace ShoppingList.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> GetByEmailAsync(string Email);
    }

}
