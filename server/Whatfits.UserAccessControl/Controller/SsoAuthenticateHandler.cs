using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token) as JwtSecurityToken;


                var username = jwt.Claims.Where(c => c.Type == "username")
                                            .Select(c => c.Value).SingleOrDefault();
                var password = jwt.Claims.Where(c => c.Type == "password")
                                            .Select(c => c.Value).SingleOrDefault();



                return base.SendAsync(request, cancellationToken);
            }
            catch (Exception)
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
