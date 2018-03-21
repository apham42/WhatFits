using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using Whatfits.JsonWebToken.Constant;

namespace Whatfits.JsonWebToken.Controller
{
    /// <summary>
    /// Verifies token with valid parameters
    /// VerifyToken(string, byte[]): verifies incomming token
    /// </summary>
    public static class VerifyJWT
    {
        /**
         * Verifies incoming string token
         * @param: string token, string format of jwt token.
         * @param: byte[] secret, secret in byte[] format
         * @return: true if valid token, false if not
         * */
        public static bool VerifyToken(string token, byte[] secret)
        {
            // create handler to verify token
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // if token is validated will set the securitytoken to this.
            SecurityToken validatedToken = null;

            try
            {
                // validates users 
                handler.ValidateToken(token, Verify.validationParameters, out validatedToken);
            }
            /*
             * System.ArgumentNullException
             * System.ArgumentException
             * Microsoft.IdentityModel.Tokens.SecurityTokenDecryptionFailedException
             * Microsoft.IdentityModel.Tokens.SecurityTokenEncryptionKeyNotFoundException
             * Microsoft.IdentityModel.Tokens.SecurityTokenException
             * Microsoft.IdentityModel.Tokens.SecurityTokenExpiredException
             * Microsoft.IdentityModel.Tokens.SecurityTokenInvalidAudienceException
             * Microsoft.IdentityModel.Tokens.SecurityTokenInvalidLifetimeException
             * Microsoft.IdentityModel.Tokens.SecurityTokenInvalidSignatureException
             * Microsoft.IdentityModel.Tokens.SecurityTokenNoExpirationException
             * Microsoft.IdentityModel.Tokens.SecurityTokenNotYetValidException
             * Microsoft.IdentityModel.Tokens.SecurityTokenReplayAddFailedException
            * */
            catch (Exception)
            {
                // return false if fail
                return false;
            }
            // returns true
            return true;
            
        }
    }
}
