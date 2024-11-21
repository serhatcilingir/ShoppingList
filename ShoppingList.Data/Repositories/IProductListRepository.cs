using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Models.Models;

namespace ShoppingList.Data.Repositories
{
    public interface IProductListRepository : IBaseRepository<ProductList>
    {
        public Task<ICollection<ProductList>> GetAllAsync(Guid UserId, int page);

        public Task<ProductList> GetByIdAsync(Guid UserId, Guid id);

    }

}
