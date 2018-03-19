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
            HttpActionContext context = HttpActionContextMockData.validActionContext();

            Assert.Equal(HttpActionContextMockData.VALID_TOKEN, RequestTransformer.GetToken(context));
        }

        [Fact]
        public void TokenInvalid()
        {
            HttpActionContext context = HttpActionContextMockData.invalidActionContext();

            Assert.Equal("False", RequestTransformer.GetToken(context));
        }

        [Fact]
        public void NoTokenHeader()
        {
            HttpActionContext context = HttpActionContextMockData.NoTokenHeader();

            Assert.Equal("False", RequestTransformer.GetToken(context));
        }
    }
}
