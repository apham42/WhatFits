using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Whatfits.UserAccessControl.Controller
{
    public class AuthorizePrincipal : AuthorizeAttribute
    {
        // type and value of claim to be checked
        public string type;
        public string value;

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
            if(IsAuthorized(actionContext))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK);
            } else
            {
                HandleUnauthorizedRequest(actionContext);
            }
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
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
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
            ClaimsPrincipal incommingPrincipal = (ClaimsPrincipal) actionContext.RequestContext.Principal;

            if(incommingPrincipal.HasClaim(type, value))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
