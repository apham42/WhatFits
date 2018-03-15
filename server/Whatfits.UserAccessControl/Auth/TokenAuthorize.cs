using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

using System.Web.Http;
using System.Web.Http.Controllers;

using Whatfits.UserAccessControl.Service;
using System;

namespace Whatfits.UserAccessControl.Auth
{
    /// <summary>
    /// Allows users to pass in a token in the http request.
    /// Get the token and sends to the claimstransformer
    /// </summary>
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
            try
            {
                string tokenstr = RequestTransformer.GetToken(actionContext);

                // create principal of user from jwt
                ClaimsPrincipal incommingPrincipal = new ClaimsTransformer().Authenticate(tokenstr);

                // creat authorization context to check if user has claims
                AuthorizationContext authcontext = new AuthorizationContext(incommingPrincipal, claimType, claimValue);
            } catch (Exception e)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }

            //    // check if user has claims
            //    if (new AuthorizationManager().CheckAccess(authcontext))
            //    {
            //        // if user does have those specififed claims
            //        base.IsAuthorized(actionContext);
            //    }
            //    else
            //    {
            //        // if user does NOT have those specified claims
            //        base.HandleUnauthorizedRequest(actionContext);
            //    }
            //} else
            //{
            //    // if the header does not contain a Token
            //    base.HandleUnauthorizedRequest(actionContext);
            //}
        }


        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {

        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return false;
        }
    }
}