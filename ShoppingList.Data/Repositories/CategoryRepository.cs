using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Data.Context;

using ShoppingList.Models.Models;

namespace ShoppingList.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShoppingDbContext DbContext) : base(DbContext)
        {
        }
    }

}
