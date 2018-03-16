using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

using Whatfits.UserAccessControl.Service;
using System;
using System.Net.Http;
using System.Net;

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

        private string _reason = "sup";

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

                if(tokenstr != "False")
                {
                    // create principal of user from jwt
                    ClaimsPrincipal incommingPrincipal = new ClaimsTransformer().Authenticate(tokenstr);

                    // creat authorization context to check if user has claims
                    AuthorizationContext authcontext = new AuthorizationContext(incommingPrincipal, claimType, claimValue);

                } else
                {
                    throw new Exception();
                }
            } catch (Exception)
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }


        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return false;
        }
    }
}