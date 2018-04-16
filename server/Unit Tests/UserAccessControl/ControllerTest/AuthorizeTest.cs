using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http.Controllers;
using Whatfits.UserAccessControl.Controller;
using Whatfits.UserAccessControl.Test.Constant;
using Xunit;

namespace UserAccessControl.ControllerTest
{
    public class AuthorizeTest : AuthorizePrincipal
    {
        AuthorizePrincipal authorizePrincipal = new AuthorizePrincipal();
        ClaimsPrincipalMockData mockData = new ClaimsPrincipalMockData();
        HttpActionContext actionContext = new HttpActionContext();

        [Fact]
        public void NullCurrentPrincipal()
        {
            Thread.CurrentPrincipal = null;

            authorizePrincipal.OnAuthorization(actionContext);

            Assert.Equal(HttpStatusCode.Unauthorized, actionContext.Response.StatusCode);
        }

        [Fact]
        public void InValidCurrentPrincipal()
        {
            authorizePrincipal.type = "WORKOUT_ADD";
            authorizePrincipal.value = "Add";

            Thread.CurrentPrincipal = mockData.PrincipalHasClaim();

            authorizePrincipal.OnAuthorization(actionContext);

            Assert.Equal(HttpStatusCode.Unauthorized, actionContext.Response.StatusCode);
        }
    }
}
