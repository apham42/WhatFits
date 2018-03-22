using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Whatfits.JsonWebToken.Controller;
using Whatfits.UserAccessControl.Service;

namespace Whatfits.UserAccessControl.Controller
{
    public class AuthenticateHttpMessageHandler : HttpMessageHandler
    {
        private TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();

        private HttpResponseMessage response = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.Unauthorized
        };

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                // get token from request
                string token = new RequestTransformer().GetToken(request);
                
                //check if token is valid.
                var incommingprincipal = VerifyJWT.VerifyToken(token);

                ClaimsPrincipal AuthenticatedPrincipal = new ClaimsTransformer().Authenticate(incommingprincipal);

                // run thread in principal
                Thread.CurrentPrincipal = AuthenticatedPrincipal;
                HttpContext.Current.User = AuthenticatedPrincipal;

                return tsc.Task;
            }
            catch (Exception)
            {
                tsc.SetResult(response);
                return tsc.Task;
            }

        }
    }
}
