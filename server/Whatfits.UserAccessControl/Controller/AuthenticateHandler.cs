﻿using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Whatfits.JsonWebToken.Controller;
using Whatfits.UserAccessControl.Service;

namespace Whatfits.UserAccessControl.Controller
{
    /// <summary>
    /// Check is request is authenticated
    /// </summary>
    public class AuthenticateHandler : DelegatingHandler
    {
        /// <summary>
        /// Handles all request comming into server
        /// </summary>
        /// <param name="request">request being sent to server</param>
        /// <param name="cancellationToken">operation </param>
        /// <returns>success</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                //get token from request
                string token = new RequestTransformer().GetToken(request);

                if(token == null)
                {
                    return base.SendAsync(request, cancellationToken);
                }

                // check if token is valid. returns principals
                var incommingprincipal = new VerifyJWT().VerifyToken(token);

                // Authenticates principals and gets user claims fromd db
                ClaimsPrincipal AuthenticatedPrincipal = new ClaimsTransformer().Authenticate(incommingprincipal);

                // create IPrincipal
                IPrincipal principal = AuthenticatedPrincipal;

                // run thread in principal
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

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
