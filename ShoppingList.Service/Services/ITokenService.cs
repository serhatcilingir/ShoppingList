using System.Threading.Tasks;
using ShoppingList.Service.Response;

namespace ShoppingList.Service.Services
{
    public interface ITokenService
    {
        Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
