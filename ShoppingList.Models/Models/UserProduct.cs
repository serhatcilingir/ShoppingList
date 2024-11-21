﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models.Models
{
    public class UserProduct : BaseModel
    {
        public string Comment { get; set; }
        public bool IsTake { get; set; }
        public Guid ProductListId { get; set; }
        public ProductList ProductList { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }

}
