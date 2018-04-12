using Microsoft.IdentityModel.Tokens;
using System;
using Whatfits.JsonWebToken.Service;

namespace Whatfits.JsonWebToken.Constant
{
    public class Verify
    {
        /// <summary>
        /// Get Valid parameters to verify Token
        /// Get salt/secret from db to verify token
        /// </summary>
        /// <param name="username">string username to get jwt secret</param>
        /// <returns>Valid parameters to validate token</returns>
        public TokenValidationParameters ValidateToken(string username)
        {
            // get secret from db
            string secret = new GetSecret().UsersSecret(username);

            // convert to base 64
            byte[] SecurityKey = Convert.FromBase64String(secret);

            // validation Parameters
            TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidIssuers = new[] { "https://www.Whatfits.social/" },
                    ValidAudiences = new[] { "admin", "general" },
                    IssuerSigningKey = new SymmetricSecurityKey(SecurityKey),
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true
                };

            // return valid parameters
            return validationParameters;
        }

    }
}
