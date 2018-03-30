using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.JsonWebToken.Constant;

namespace Whatfits.JsonWebToken.Service
{
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
        /// <returns></returns>
        public JwtPayload CreatePayload(string username, int exptime = 1)
        {
            // get current time
            DateTime currenttime = DateTime.UtcNow;

            // convert time to unixtime
            long currentunixTime = ((DateTimeOffset)currenttime).ToUnixTimeSeconds();

            // get 1 hour from current time
            long hrunixtime = ((DateTimeOffset)currenttime.AddHours(exptime)).ToUnixTimeSeconds();

            // Get view claims
            List<Claim> ViewClaim = GetViewClaims(username);

            // create payload of jwt
            JwtPayload payload = new JwtPayload()
            {
                { "iss", "https://www.Whatfits.social/" },
                { "aud", "General" },
                { "iat", currentunixTime.ToString() },
                { "nbf", currentunixTime.ToString() },
                { "exp", hrunixtime.ToString() }
            };

            // add username to jwt
            payload.Add("username", username);

            // add view claims to payload
            payload.AddClaims(ViewClaim);

            // return payload
            return payload;
        }

        public void AddTokenToDB(string username, string jwt, byte[] secret)
        {
            LoginGateway loginGateway = new LoginGateway();
            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = username,
                Token = jwt,
                Salt = Convert.ToBase64String(secret)
            };

            loginGateway.AddToTokenList(loginDTO);
        }

        /// <summary>
        /// get view claims from db
        /// </summary>
        /// <returns>view claims</returns>
        private List<Claim>  GetViewClaims(string username)
        {
            return new List<Claim>()
            {
                new Claim("Workout", "add workout"),
                new Claim("Event", "add event"),
                new Claim("Friends", "you have friends, congrats."),
                new Claim("Sup", "yo")
            };
        }
    }
}
