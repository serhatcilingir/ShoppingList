using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Service.Response;
using ShoppingList.Service.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
        {
            // Yapılandırma değerlerini al
            var key = configuration["Jwt:Key"];
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];

            // Yapılandırma değerlerini kontrol et
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
            {
                throw new ArgumentNullException("Jwt yapılandırma değerleri eksik!");
            }

            // SymmetricSecurityKey oluştur
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var dateTimeNow = DateTime.UtcNow;

            // JWT token oluştur
            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, request.UserId.ToString()),
                    new Claim(ClaimTypes.Role, request.Role)
                },
                notBefore: dateTimeNow,
                expires: dateTimeNow.Add(TimeSpan.FromDays(1)),
                signingCredentials: signingCredentials
            );

            // Token oluştur ve döndür
            return Task.FromResult(new GenerateTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(500))
            });
        }
    }
}
