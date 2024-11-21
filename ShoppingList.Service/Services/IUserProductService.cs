using ShoppingList.Models.Models;
using ShoppingList.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Services
{
    public interface IUserProductService
    {
        public Task<UserProductDto> Create(Guid UserId, UserProductResponse res);
        public Task<BaseDto> Delete(Guid UserId, Guid Id);
        public Task<UserProductListDto> GetAll(Guid UserId, int page);
        public Task<UserProductDto> Get(Guid UserId, Guid Id);
        public Task<UserProductDto> Update(Guid UserId, Guid Id, UserProductUpdateResponse res);

    }

}
