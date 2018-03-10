using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;


namespace Whatfits.UserAccessControl.Auth
{
    public class TokenAuthorize : AuthorizeAttribute
    {
        public string claimType;
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
            var re = actionContext.Request;
            var hey = re.Headers;
            string yo = hey.GetValues("Token").First();

            

            
            //token.ReadToken(yo);

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
        //protected override bool IsAuthorized(HttpActionContext actionContext)
        //{
        //    return false;
        //}
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