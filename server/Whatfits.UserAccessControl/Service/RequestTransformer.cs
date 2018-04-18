using System;
using System.Linq;
using System.Net.Http;

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
            try
            {
                // gets header of request
                var header = request.Headers;

                // gets token from header
                token = header.Authorization.Parameter;

                if (header.Authorization.Scheme == "Bearer" && !string.IsNullOrEmpty(token))
                {
                    return token;
                }

                return token;
            }
            catch (NullReferenceException)
            {
                return token;
            }
        }
    }
}
