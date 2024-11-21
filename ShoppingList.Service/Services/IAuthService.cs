using ShoppingList.Models.Models;
using ShoppingList.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Services
{
    public interface IAuthService
    {
        public Task<TokenDto> LoginUserAsync(User user, TokenDto response);
    }

}
