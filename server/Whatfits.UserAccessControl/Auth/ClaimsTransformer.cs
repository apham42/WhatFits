using System.Collections.Generic;
using System.Security.Claims;

using System.IdentityModel.Tokens.Jwt;
using System.Security;

namespace Whatfits.UserAccessControl.Auth
{
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

        private ClaimsPrincipal CreatePrincipal(string incommingToken)
        {
            // create jwt
            var tokenhandler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken();
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
