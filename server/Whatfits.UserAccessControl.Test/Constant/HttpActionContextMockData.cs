using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Whatfits.UserAccessControl.Test.Constant
{
    public class HttpActionContextMockData
    {
        static string VALID_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFwaGFtNDIiLCJ3ZWJzaXRlIjoiV2hhdGZpdHMuc29jaWFsIiwiV09SS09VVF9BREQiOiJBREQiLCJuYmYiOjE1MjA1NjUxMjEsImV4cCI6MTUyMDU2ODcyMSwiaWF0IjoxNTIwNTY1MTIxfQ.HFFQr8QtI6efVh2kqbbVDShUXyaHQM72sbj5cxAJs-U";
        static string INVALID_TOKEN = "invalidToken";

        public static HttpActionContext validActionContext()
        {
            HttpActionContext context = new HttpActionContext();
            AuthenticationHeaderValue headerValue = new AuthenticationHeaderValue("Basic", "bzUwkDal=");
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = headerValue;
            HttpControllerContext controllerContext = new HttpControllerContext();
            controllerContext.Request = request;
            context.ControllerContext = controllerContext;

            context.Request.Headers.Add("Token", VALID_TOKEN);

            return context;
        }

        public static HttpActionContext invalidActionContext()
        {
            HttpActionContext context = new HttpActionContext();
            AuthenticationHeaderValue headerValue = new AuthenticationHeaderValue("Basic", "bzUwkDal=");
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = headerValue;
            HttpControllerContext controllerContext = new HttpControllerContext();
            controllerContext.Request = request;
            context.ControllerContext = controllerContext;

            context.Request.Headers.Add("Token", INVALID_TOKEN);

            return context;
        }

        public HttpActionContext NoTokenHeader()
        {
            HttpActionContext context = new HttpActionContext();
            AuthenticationHeaderValue headerValue = new AuthenticationHeaderValue("Basic", "bzUwkDal=");
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = headerValue;
            HttpControllerContext controllerContext = new HttpControllerContext();
            controllerContext.Request = request;
            context.ControllerContext = controllerContext;

            return context;
        }
    }
}
