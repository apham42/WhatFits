using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Whatfits.JsonWebToken.Constant;

namespace Whatfits.JsonWebToken.Controller
{
    /// <summary>
    /// Verifies token with valid parameters
    /// VerifyToken(string, byte[]): verifies incomming token
    /// Exceptions will be caught in the AuthenticatedHttpMessageHandler
    /// </summary>
    public class VerifyJWT
    {
        /**
         * Verifies incoming string token
         * @param: string token, string format of jwt token.
         * @param: byte[] secret, secret in byte[] format
         * @return: true if valid token, false if not
         * */
        public ClaimsPrincipal VerifyToken(string token)
        {
            // create handler to verify token
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // convert string to token
            var jwt = handler.ReadToken(token) as JwtSecurityToken;

            // get username from token
            var username = jwt.Claims.First(claim => claim.Type == "UserName").Value;

            // if token is validated will set the securitytoken to this.
            SecurityToken validatedToken = null;


            // validates users 
            return handler.ValidateToken(token, new Verify().ValidateToken(username), out validatedToken);
        }
    }
}
