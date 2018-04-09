using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using Whatfits.UserAccessControl.Service;
using Whatfits.UserAccessControl.Test.Constant;
using Xunit;



namespace Whatfits.UserAccessControl.Test.ServiceTest
{
    public class RequestTransformerTest
    {
        [Fact]
        public void ValidToken()
        {
            HttpRequestMessage request = HttpRequestMessageMockData.validRequestMessage();
            RequestTransformer test = new RequestTransformer();

            Assert.Equal(HttpRequestMessageMockData.VALID_TOKEN, test.GetToken(request));
        }

        [Fact]
        public void TokenInvalid()
        {
            HttpRequestMessage request = HttpRequestMessageMockData.InvalidRequestMessage();
            RequestTransformer test = new RequestTransformer();

            Assert.Equal(HttpRequestMessageMockData.INVALID_TOKEN, test.GetToken(request));
        }

        [Fact]
        public void NoTokenHeader()
        {
            HttpRequestMessage request = HttpRequestMessageMockData.NoTokenInHeader();
            RequestTransformer test = new RequestTransformer();
            Action act = () => test.GetToken(request);

            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
