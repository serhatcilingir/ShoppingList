using System.Threading.Tasks;
using ShoppingList.Models.Models;
using ShoppingList.Service.Response;

namespace ShoppingList.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService tokenService;

        public AuthService(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        public async Task<TokenDto> LoginUserAsync(User user, TokenDto response)
        {
            // User kontrolü ekleniyor
            if (user == null || user.Id == Guid.Empty || string.IsNullOrEmpty(user.Role))
            {
                throw new ArgumentNullException("User bilgileri eksik!");
            }

            var generatedTokenInformation = await tokenService.GenerateToken(new GenerateTokenRequest
            {
                UserId = user.Id,
                Role = user.Role
            });

            response.AuthToken = generatedTokenInformation.Token;
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;

            return response;
        }
    }
}
