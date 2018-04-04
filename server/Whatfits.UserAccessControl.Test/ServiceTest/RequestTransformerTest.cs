using System;
using System.Net.Http;
using Whatfits.UserAccessControl.Service;
using Whatfits.UserAccessControl.Test.Constant;
using Xunit;



namespace Whatfits.UserAccessControl.Test.ServiceTest
{
    public class RequestTransformerTest
    {
        HttpRequestMessageMockData mockData = new HttpRequestMessageMockData();

        [Fact]
        public void ValidToken()
        {
            HttpRequestMessage request = mockData.validRequestMessage();
            RequestTransformer test = new RequestTransformer();

            Assert.Equal(mockData.VALID_TOKEN, test.GetToken(request));
        }

        [Fact]
        public void ValidTokenWithoutScheme()
        {
            HttpRequestMessage request = mockData.NoSchemeValidTokenRequestMessage();
            RequestTransformer test = new RequestTransformer();
            Action act = () => test.GetToken(request);

            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void NoTokenInParam()
        {
            HttpRequestMessage request = mockData.EmptyAuthorizationParam();
            RequestTransformer test = new RequestTransformer();
            Action act = () => test.GetToken(request);

            Assert.Throws<Exception>(act);
        }
    }
}
