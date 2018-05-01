using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Whatfits.JsonWebToken.Controller;
using Whatfits.UserAccessControl.Service;

namespace Whatfits.UserAccessControl.Controller
{
    public class SsoAuthenticateHandler : DelegatingHandler
    {
        /// <summary>
        /// Sso Authenticate Handler
        /// </summary>
        /// <param name="request">request being sent to server</param>
        /// <param name="cancellationToken">operation </param>
        /// <returns>success</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = new RequestTransformer().GetToken(request);
                
                if(token == null)
                {
                    return base.SendAsync(request, cancellationToken);
                }

                var incommingPrincipal = new VerifyJWT().SsoVerifyToken(token);

                Thread.CurrentPrincipal = incommingPrincipal;
                HttpContext.Current.User = incommingPrincipal;
                
                return base.SendAsync(request, cancellationToken);
            }
            catch (NullReferenceException)
            {
                // send to unauthenticated
                return UnAuthenticated();
            }

        }

        /// <summary>
        /// catches any exceptions that are thrown
        /// </summary>
        /// <returns>returns task with unauthorized(401) response</returns>
        private Task<HttpResponseMessage> UnAuthenticated()
        {
            //set task completion when fail
            var tsc = new TaskCompletionSource<HttpResponseMessage>();

            // creates response message of unauthorized
            var response = new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized };

            // set response of task
            tsc.SetResult(response);

            // kick user out and give them unauthorized.
            return tsc.Task;
        }
    }
}
