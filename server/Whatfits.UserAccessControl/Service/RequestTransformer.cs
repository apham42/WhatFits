using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace Whatfits.UserAccessControl.Service
{
    /// <summary>
    /// Request Transformer gets the principal from http request
    /// </summary>
    public class RequestTransformer
    {
        // token
        private string token = null;

        // constructor
        public RequestTransformer() { }

        /// <summary>
        /// get token from request
        /// </summary>
        /// <param name="request"> incomming request</param>
        /// <returns>string token</returns>
        public string GetToken(HttpRequestMessage request)
        {
            // gets header of request
            var header = request.Headers;

            // gets token from header
            token = header.GetValues("Token").First();

            // check if null or empty
            if(!string.IsNullOrEmpty(token))
            {
                // returns jwt
                return token;
            }

            // throws excpetion to be caught in AuthenticateHttpMessageHandler
            throw new Exception();
        }
    }
}
