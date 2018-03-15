using System;
using System.Linq;
using System.Web.Http.Controllers;

namespace Whatfits.UserAccessControl.Service
{
    /// <summary>
    /// Request Transformer gets the token from http request
    /// </summary>
    public static class RequestTransformer
    {
        public static string GetToken(HttpActionContext actionContext)
        {
            try
            {


                string token = null;

                var request = actionContext.Request;
                var header = request.Headers;

                token = header.GetValues("Token").First();
                
                return token;
            }
            catch (Exception e)
            {
                return e.StackTrace;
            }
        }
    }
}
