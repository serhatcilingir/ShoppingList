using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Response
{
    public class GenerateTokenRequest
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = string.Empty; // Boş değerler için varsayılan atama
    }

    public class GenerateTokenResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime TokenExpireDate { get; set; }
    }
}