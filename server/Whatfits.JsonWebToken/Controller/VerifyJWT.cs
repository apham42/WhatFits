using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
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
        /// <summary>
        /// Verifies token with verified token
        /// </summary>
        /// <param name="token">jwt string</param>
        /// <returns>principal of jwt</returns>
        public ClaimsPrincipal VerifyToken(string token)
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                Token = token
            };

            ResponseDTO<Boolean> responseDTO = new LoginGateway().CheckIfTokenOnBlackList(loginDTO);

            if (responseDTO.IsSuccessful == false)
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
            } else
            {
                throw new Exception();
            }
        }


    }
}
