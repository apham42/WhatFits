using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

using System.Web.Http;
using System.Web.Http.Controllers;

namespace Whatfits.UserAccessControl.Auth
{
    public class TokenAuthorize : AuthorizeAttribute
    {
        // claim type
        public string claimType;
        // claim value
        public string claimValue;

        // Summary:
        //     Calls when an action is being authorized.
        //
        // Parameters:
        //   actionContext:
        //     The context.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The context parameter is null.
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // get http request
            var request = actionContext.Request;
            // get header from request
            var header = request.Headers;
            // get string token
            string tokenstr = header.GetValues("Token").First();

            // create principal of user from jwt
            ClaimsPrincipal incommingPrincipal = new ClaimsTransformer().Authenticate(tokenstr);
            
            // creat authorization context to check if user has claims
            AuthorizationContext authcontext = new AuthorizationContext(incommingPrincipal, claimType, claimValue);

            // check if user has claims
            if (new AuthorizationManager().CheckAccess(authcontext))
            {
                // if user does have those specififed claims
                base.IsAuthorized(actionContext);
            } else
            {
                // if user does NOT have those specified claims
                base.HandleUnauthorizedRequest(actionContext);
            }
        }
    }
}