using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Whatfits.JsonWebToken.Constant;
using Whatfits.UserAccessControl.Controller;

namespace Whatfits.JsonWebToken.Service
{
    public static class Create
    {
        public static JwtHeader CreateHeader()
        {
            // algorithm being used 
            const string alg = "HS256";
            // create header
            // create security key with secret to make it readable for SigingCredentials()
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Key.ssosecret);
            // sign credentials with security key and hs256
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                                        securityKey,
                                        alg);

            // return header with signingCredentials
            return new JwtHeader(signingCredentials);
        }


        public static JwtPayload CreatePayload(string username, int exptime = 1)
        {
            // get current time
            DateTime currenttime = DateTime.UtcNow;

            // convert time to unixtime
            long currentunixTime = ((DateTimeOffset)currenttime).ToUnixTimeSeconds();

            // get 1 hour from current time
            long hrunixtime = ((DateTimeOffset)currenttime.AddHours(exptime)).ToUnixTimeSeconds();

            // Get view claims
            List<Claim> ViewClaim = UserAccessController.GetViewClaims();

            // create payload of jwt
            JwtPayload payload = new JwtPayload()
            {
                { "iss", "https://www.Whatfits.social/" },
                { "sub", username },
                { "aud", "General" },
                { "iat", currentunixTime.ToString() },
                { "nbf", currentunixTime.ToString() },
                { "exp", hrunixtime.ToString() }
            };

            // add view claims to payload
            payload.AddClaims(ViewClaim);

            // return payload
            return payload;
        }
    }
}
