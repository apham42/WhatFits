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
            var token = tokenhandler.ReadJwtToken(incommingToken);

            // get claims from token
            List<Claim> tokenClaims = new List<Claim>();

            foreach (Claim claim in token.Claims)
            {
                tokenClaims.Add(claim);
            }

            return new ClaimsPrincipal(new ClaimsIdentity(tokenClaims));
        }
    }
}