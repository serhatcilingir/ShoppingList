using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models.Models
{
    public class User : BaseModel
    {

        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }
        public string Role { get; set; } = "User";
        public ICollection<ProductList> ProductLists { get; set; }
    }


}
