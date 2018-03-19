using System;
using System.IdentityModel.Tokens.Jwt;
using Whatfits.JsonWebToken.Service;

namespace Whatfits.JsonWebToken.Controller
{
    /// <summary>
    /// Create jwt
    /// CreateToken(): combines header and payload to make token
    /// CreateHeader(): creates header of token
    /// CreatePayload(): creates payload of token
    /// </summary>
    public static class CreateJWT
    {
        /**
         * Create tokens from CreateHeader(), and CreatePayload();
         * @return: Return jwt else return fail
         * */
        public static string CreateToken(string username)
        {
            // creates jwtsecuritytoken
            var jwt = new JwtSecurityToken(Create.CreateHeader(), Create.CreatePayload(username));

            // converts JwtSecurityToken into serialized format
            // Signs token with SigningCredentials in WriteToken()
            try
            {
                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            /*
             * Catch if
             *      System.ArgumentNullException
             *      System.ArgumentException
             *      Microsoft.IdentityModel.Tokens.SecurityTokenEncryptionFailedException
             * */
            catch (Exception) 
            {
                return "Failed";
            }
        }

        
    }
}
