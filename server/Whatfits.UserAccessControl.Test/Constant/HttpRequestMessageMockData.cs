using System.Net.Http;

namespace Whatfits.UserAccessControl.Test.Constant
{
    public class HttpRequestMessageMockData
    {
        public static string VALID_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFwaGFtNDIiLCJ3ZWJzaXRlIjoiV2hhdGZpdHMuc29jaWFsIiwiV09SS09VVF9BREQiOiJBREQiLCJuYmYiOjE1MjA1NjUxMjEsImV4cCI6MTUyMDU2ODcyMSwiaWF0IjoxNTIwNTY1MTIxfQ.HFFQr8QtI6efVh2kqbbVDShUXyaHQM72sbj5cxAJs-U";
        public static string INVALID_TOKEN = "invalidToken";

        public static HttpRequestMessage validRequestMessage()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("Token", VALID_TOKEN);


            return request;
        }

        public static HttpRequestMessage InvalidRequestMessage()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("Token", INVALID_TOKEN);


            return request;
        }

        public static HttpRequestMessage NoTokenInHeader()
        {
            HttpRequestMessage request = new HttpRequestMessage();

            return request;
        }
    }
}
