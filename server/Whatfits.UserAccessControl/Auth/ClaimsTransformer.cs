using System.Collections.Generic;
using System.Security.Claims;

using System.IdentityModel.Tokens.Jwt;
using System.Security;

namespace Whatfits.UserAccessControl.Auth
{
    /// <summary>
    /// Convert the incoming Token into 
    /// </summary>
    public class ClaimsTransformer : ClaimsAuthenticationManager
    {
        public ClaimsPrincipal Authenticate(string incommingToken)
        {
            // check if token exist
            if (string.IsNullOrEmpty(incommingToken))
            {
                throw new SecurityException("No Token");
            }

            // create principal
            return CreatePrincipal(incommingToken);
        }

        /*
        * Gives new users a set of default claims.
        * This should only be used in Registration.
        * @param string username, username of the new registered user
        * @returns List<int>, returns list of ints(id of the claims) 
        * */
        private ClaimsPrincipal CreatePrincipal(string incommingToken)
        {
            // create jwt
            var tokenhandler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken();

            // create users principal
            ClaimsPrincipal cp = new ClaimsPrincipal();
            
            // check if valid token
            if (tokenhandler.CanReadToken(incommingToken)) {
                // create token from incomming token string
                token = tokenhandler.ReadJwtToken(incommingToken); 

                // return users principal
                cp = new ClaimsPrincipal(new ClaimsIdentity(token.Claims));
                return cp;
            }

            return cp;
        }
    }
}
