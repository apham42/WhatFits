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
            if(string.IsNullOrEmpty(incommingToken))
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
            // create token from incomming token string
            var token = tokenhandler.ReadJwtToken(incommingToken);

            // return users principal
            return new ClaimsPrincipal(new ClaimsIdentity(token.Claims));
        }
    }
}