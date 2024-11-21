using ShoppingList.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace ShoppingList.Service.Services
{
    public class PasswordService : IPasswordService
    {
        PasswordHasher<User> hasher = new();
        public string HashPassword(User user, string password)
        {
            return hasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string hashPassword, string providerPassword)
        {
            var result = hasher.VerifyHashedPassword(user, hashPassword, providerPassword);
            return result == PasswordVerificationResult.Success;
        }
    }

}
