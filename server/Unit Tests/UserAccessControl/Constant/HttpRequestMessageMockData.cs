using System.Net.Http;
using System.Net.Http.Headers;

namespace Whatfits.UserAccessControl.Test.Constant
{
    public class HttpRequestMessageMockData
    {
        public string VALID_TOKEN = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL3d3dy5XaGF0Zml0cy5zb2NpYWwvIiwiYXVkIjoiZ2VuZXJhbCIsImlhdCI6IjE1MjI3MDk4NDEiLCJuYmYiOiIxNTIyNzA5ODQxIiwiZXhwIjoiMTUyNjMwOTg0MSIsIlVzZXJOYW1lIjoiYW1heSIsIlZJRVdfUEFHRSI6WyJWaWV3IFdva291dGxvZyIsIlZpZXcgU2VhcmNoIiwiVmlldyBDaGF0IiwiVmlldyBGb2xsb3dlcnNsaXN0IiwiVmlldyBSYXRpbmcgYW5kIFJldmlld3MiLCJWaWV3IEV2ZW50Il19.2FK5Q-y1jJDTlWg2adKa-qIruOCzhxIdhi4m8KsMy4Q";
        public string VALID_TOKEN_WITHOUT_SCHEME = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL3d3dy5XaGF0Zml0cy5zb2NpYWwvIiwiYXVkIjoiZ2VuZXJhbCIsImlhdCI6IjE1MjI3MDk4NDEiLCJuYmYiOiIxNTIyNzA5ODQxIiwiZXhwIjoiMTUyNjMwOTg0MSIsIlVzZXJOYW1lIjoiYW1heSIsIlZJRVdfUEFHRSI6WyJWaWV3IFdva291dGxvZyIsIlZpZXcgU2VhcmNoIiwiVmlldyBDaGF0IiwiVmlldyBGb2xsb3dlcnNsaXN0IiwiVmlldyBSYXRpbmcgYW5kIFJldmlld3MiLCJWaWV3IEV2ZW50Il19.2FK5Q-y1jJDTlWg2adKa-qIruOCzhxIdhi4m8KsMy4Q";
        public string EMPTY_TOKEN_WITH_SCHEME = "Bearer";

        public HttpRequestMessage validRequestMessage()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("Authorization", VALID_TOKEN);
            
            return request;
        }

        public HttpRequestMessage NoSchemeValidTokenRequestMessage()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("Authorization", VALID_TOKEN_WITHOUT_SCHEME);

            return request;
        }

        public HttpRequestMessage EmptyAuthorizationParam()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("Authorization", EMPTY_TOKEN_WITH_SCHEME);

            return request;
        }
    }
}
