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

        // test function
        public List<Claim> getClaims(string username)
        {
            List<Claim> userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Webpage, "Whatfits.social"),
                new Claim("WORKOUT_ADD", "ADD")
            };
            

            return userClaims;
        }
        
        //
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

            ClaimsPrincipal incommingPrincipal = new ClaimsTransformer().Authenticate(tokenstr);

            //ClaimsIdentity currentid = 
            //token.ReadToken(yo);
            AuthorizationContext authcontext = new AuthorizationContext(incommingPrincipal, claimType, claimValue);

            if (new AuthorizationManager().CheckAccess(authcontext))
            {
                base.IsAuthorized(actionContext);
            } else
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
        }
        //
        // Summary:
        //     Indicates whether the specified control is authorized.
        //
        // Parameters:
        //   actionContext:
        //     The context.
        //
        // Returns:
        //     true if the control is authorized; otherwise, false.
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return true;
        }

        //
        // Summary:
        //     Processes requests that fail authorization.
        //
        // Parameters:
        //   actionContext:
        //     The context.
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {

        }
    }
}