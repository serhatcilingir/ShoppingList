using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models.Models
{
    public class ProductList : BaseModel
    {

        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<UserProduct> UserProducts { get; set; }
        public bool IsCompleted { get; set; }
    }

}
