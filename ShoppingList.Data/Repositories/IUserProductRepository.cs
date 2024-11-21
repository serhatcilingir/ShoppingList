using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Models.Models;
namespace ShoppingList.Data.Repositories
{
    public interface IUserProductRepository : IBaseRepository<UserProduct>
    {
        public Task<ICollection<UserProduct>> GetAllAsync(Guid UserId, int page);
        public Task<UserProduct> GetByIdAsync(Guid UserId, Guid id);
    }

}
