using System;
using System.IdentityModel.Tokens.Jwt;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
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
    public class CreateJWT
    {
        /// <summary>
        /// Create tokens from CreateHeader(), and CreatePayload();
        /// </summary>
        /// <param name="username">username of user</param>
        /// <returns>string jwt</returns>
        public string CreateToken(string username)//, string type)
        {
            try
            {
                // generate new secret
                byte[] secret = new Key().CreateSecret;

                // constructor for header and payload
                Create newJwt = new Create();

                // creates jwtsecuritytoken
                var jwt = new JwtSecurityToken(newJwt.CreateHeader(secret), newJwt.CreatePayload(username));//, type));

                // converts JwtSecurityToken into serialized format
                // Signs token with SigningCredentials in WriteToken()
                string stringjwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                // adds token to db(TokenList)
                AddTokenToDB(username, stringjwt, secret);

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


        /// <summary>
        /// adds token and secret to db
        /// </summary>
        /// <param name="username">user to get new token</param>
        /// <param name="jwt">token created</param>
        /// <param name="secret">secret that has signed token</param>
        private void AddTokenToDB(string username, string jwt, byte[] secret)
        {
            // login gateway use to connect to db
            LoginGateway loginGateway = new LoginGateway();

            // dto that is sent to gateway
            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = username,
                Token = jwt,
                Salt = Convert.ToBase64String(secret)
            };

            // adds token to db
            loginGateway.AddToTokenList(loginDTO);
        }
    }
}
