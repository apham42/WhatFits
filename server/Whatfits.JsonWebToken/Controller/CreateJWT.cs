using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Whatfits.JsonWebToken.Constant;

namespace Whatfits.JsonWebToken.Controller
{
    public static class CreateJWT
    {
        public static string CreateJsonWebToken()
        {
            // convert to base 64
            var symmetricKey = Convert.FromBase64String(Key.secret);

            // create jwt handler
            var tokenHandler = new JwtSecurityTokenHandler();

            
            var now = DateTime.UtcNow;

            // in token
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                //identity in token
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "apham42"),
                    new Claim(ClaimTypes.Webpage, "Whatfits.social"),
                    new Claim("WORKOUT_ADD", "ADD")
                }),

                //Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                //signing credentials
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            // create the token from handler
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            // convert to string
            var token = tokenHandler.WriteToken(stoken);

            // return string jwt
            return token;
        }
    }
}
