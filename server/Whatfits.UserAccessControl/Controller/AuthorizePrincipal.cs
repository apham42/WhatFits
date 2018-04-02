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
    /// <summary>
    /// Check if user is authorized
    /// </summary>
    public class AuthorizePrincipal : AuthorizeAttribute
    {
        // type and value of claim to be checked
        public string type;
        public string value;
        
        /// <summary>
        /// Is called when request is being authorized
        /// </summary>
        /// <param name="actionContext">context of request</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // if principal is authenticated
            if(IsAuthorized(actionContext))
            {
                base.IsAuthorized(actionContext); // allows access to feature
            } else // if not authenticated
            {
                HandleUnauthorizedRequest(actionContext); // return unauthorized status code
            }
        }
        
        /// <summary>
        /// if authorization is failed
        /// </summary>
        /// <param name="actionContext">request context.</param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// Check is user is authorized
        /// </summary>
        /// <param name="actionContext">request context. where the claims principal is stored</param>
        /// <returns>true if authorized else false</returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // get claims principal from action context
            ClaimsPrincipal incommingPrincipal = (ClaimsPrincipal) System.Web.HttpContext.Current.User;//(ClaimsPrincipal) actionContext.RequestContext.Principal;

            // check if principal has claims
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
