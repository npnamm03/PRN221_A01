﻿using Microsoft.IdentityModel.Tokens;

namespace DataAccess.Util
{
    public class ValidationLogin
    {
        public static (bool isValid, string message) ValidateData(string email, string password)
        {
            if (email.IsNullOrEmpty())
            {
                return (false, "Email cannot be blank");
            }
            if (email.Trim() == " ")
            {
                return (false, "Email cannot contain whitespace in between");
            }
            if (password.Trim() == " ")
            {
                return (false, "Password cannot contain whitespace in between" );
            }
            return (true, "All field validate");
        }
    }
}
