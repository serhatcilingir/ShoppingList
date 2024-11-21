﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Response
{
    public class Verification
    {
        public static bool IsPasswordValid(string password)
        {
            int minLength = 8;
            bool hasDigit = password.Any(char.IsDigit);
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasSpecialChar = password.Any(c => char.IsPunctuation(c) || char.IsSymbol(c));

            return password.Length >= minLength && hasDigit && hasUpperCase && hasSpecialChar;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

}
