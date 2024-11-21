﻿using ShoppingList.Models.Models;
using ShoppingList.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Services
{
    public interface IProductService
    {
        public Task<ProductDto> Create(ProductResponse res);
        public Task<BaseDto> Delete(Guid Id);
        public Task<ProductAllDto> GetAll(int page, Guid? categoryid, string keyword);
        public Task<ProductDto> Get(Guid Id);
        public Task<ProductDto> Update(Guid Id, ProductUpdateResponse res);

    }

}
