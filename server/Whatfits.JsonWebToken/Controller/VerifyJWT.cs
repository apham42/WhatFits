using System;
using System.Text;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;
using Whatfits.JsonWebToken.Constant;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Whatfits.JsonWebToken.Controller
{
    public static class VerifyJWT
    {
        public static string VerifyToken(string token, byte[] secret)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            Microsoft.IdentityModel.Tokens.SecurityToken validatedToken;

            TokenValidationParameters validationParameters =
                new TokenValidationParameters
                {
                    ValidIssuer = "https://www.Whatfits.social/",
                    ValidAudience = "user",
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Key.secret)
                };

            var user = handler.ValidateToken(token, validationParameters, out validatedToken);

            return user.Claims.ToString();
        }
    }
}
