using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.JsonWebToken.Constant;

namespace Whatfits.JsonWebToken.Service
{
    /// <summary>
    /// Create the jwt token
    /// Header
    /// payload
    /// </summary>
    public class Create
    {
        /// <summary>
        /// Create header of jwt
        /// contains: signingCredentials
        /// </summary>
        /// <returns>JwtHeader</returns>
        public JwtHeader CreateHeader(byte[] secret)
        {
            // algorithm being used 
            const string alg = "HS256";
            // create security key with secret to make it readable for SigingCredentials()
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(secret);
            // sign credentials with security key and hs256
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                                        securityKey,
                                        alg);

            // return header with signingCredentials
            return new JwtHeader(signingCredentials);
        }

        /// <summary>
        /// create payload of jwt
        /// contains: iss, aud, iat, nbf, exp, viewclaims, username
        /// </summary>
        /// <param name="username">username of user</param>
        /// <param name="exptime">experation time of token</param>
        /// <param name="type">user type, either admin or general</param>
        /// <returns></returns>
        public JwtPayload CreatePayload(string username) // , int exptime = 1)//, string type, int exptime = 1)
        {
            // get current time
            DateTime currenttime = DateTime.UtcNow;

            // convert time to unixtime
            long currentunixTime = ((DateTimeOffset)currenttime).ToUnixTimeSeconds();

            // get 1 hour from current time
            // long hrunixtime = ((DateTimeOffset)currenttime.AddHours(exptime)).ToUnixTimeSeconds();

            // Get view claims
            List<Claim> ViewClaim = GetViewClaims(username);

            // create payload of jwt
            JwtPayload payload = new JwtPayload()
            {
                { "iss", "https://www.Whatfits.social/" },
                // { "aud", type },
                { "iat", currentunixTime.ToString() },
                { "nbf", currentunixTime.ToString() },
                // { "exp", hrunixtime.ToString() }
            };

            // add username to jwt
            payload.Add("UserName", username);

            // add view claims to payload
            payload.AddClaims(ViewClaim);

            // return payload
            return payload;
        }

        /// <summary>
        /// get view claims from db
        /// </summary>
        /// <returns>view page claims</returns>
        private List<Claim>  GetViewClaims(string username)
        {
            // list a view claims
            List<Claim> listViewClaims = new List<Claim>();

            // user access dto that stores username, will be passed into gateway
            UserAccessDTO userAccessDTO = new UserAccessDTO()
            {
                UserName = username
            };
            
            // gets all user's claims
            List<Claim> allClaims = new UserAccessControlGateway().GetUserClaims(userAccessDTO).Data;

            // Gets all view claims from list
            listViewClaims = allClaims.FindAll(claim => claim.Type == "VIEW_PAGE");

            // returns just view page claims
            return listViewClaims;
        }
    }
}
