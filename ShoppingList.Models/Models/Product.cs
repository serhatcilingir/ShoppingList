using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models.Models
{
    public class Product : BaseModel
    {

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<UserProduct> UserProducts { get; set; }
    }

}
