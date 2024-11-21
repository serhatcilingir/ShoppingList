using ShoppingList.Models.Models;
using ShoppingList.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Services

{
    public interface IProductListService
    {
        Task<ProductListDto> Create(Guid UserId, ProductListResponse res);
        Task<BaseDto> Delete(Guid UserId, Guid Id);
        Task<ProdutAllListDto> GetAll(Guid UserId, int page);
        Task<ProductListDto> Get(Guid UserId, Guid Id);
        Task<BaseDto> Update(Guid UserId, Guid Id, bool IsComplete);
    }
}
