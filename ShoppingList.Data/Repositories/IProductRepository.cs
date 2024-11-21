using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Models.Models;

namespace ShoppingList.Data.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<ICollection<Product>> GetAllAsync(int page, Guid? categoryid, string keyword);
    }

}
