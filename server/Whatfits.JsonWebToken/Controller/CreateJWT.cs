using System;
using System.IdentityModel.Tokens.Jwt;
using Whatfits.JsonWebToken.Constant;
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
        /// <summary>
        /// Create tokens from CreateHeader(), and CreatePayload();
        /// </summary>
        /// <param name="username">username of user</param>
        /// <returns>string jwt</returns>
        public static string CreateToken(string username)
        {
            try
            {
                // generate new secret
                byte[] secret = Key.GetSecret;

                // constructor for header and payload
                Create newJwt = new Create();

                // creates jwtsecuritytoken
                var jwt = new JwtSecurityToken(newJwt.CreateHeader(secret), newJwt.CreatePayload(username));

                // converts JwtSecurityToken into serialized format
                // Signs token with SigningCredentials in WriteToken()
                string stringjwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                // adds token to db(TokenList)
                newJwt.AddTokenToDB(username, stringjwt, secret);

                return stringjwt;
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
