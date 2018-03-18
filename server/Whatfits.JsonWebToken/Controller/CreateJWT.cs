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

        public static string CreateToken()
        {
            // creates jwt
            var jwt = new JwtSecurityToken(CreateHeader(), CreatePayload());
            // create handler for jwt
            var handler = new JwtSecurityTokenHandler();
            // converts JwtSecurityToken into serialized format
            return handler.WriteToken(jwt);
        }

        private static JwtHeader CreateHeader()
        {
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Key.secret);
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                                        securityKey,
                                        "HS256");

            return new JwtHeader(signingCredentials);
        }

        private static JwtPayload CreatePayload()
        {
            JwtPayload payload = new JwtPayload();

            DateTime currenttime = DateTime.Now;

            payload.Add("Iss", "https://www.Whatfits.social/");
            payload.Add("Iat", currenttime.ToString());
            payload.Add("Exp", currenttime.AddHours(1).ToString());
            


            return payload;
        }
    }
}
