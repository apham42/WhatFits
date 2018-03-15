using System.Web.Http.Controllers;
using Whatfits.UserAccessControl.Service;
using Whatfits.UserAccessControl.Test.Constant;
using Xunit;



namespace Whatfits.UserAccessControl.Test.ServiceTest
{
    public class RequestTransformerTest
    {
        public string validtoken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFwaGFtNDIiLCJ3ZWJzaXRlIjoiV2hhdGZpdHMuc29jaWFsIiwiV09SS09VVF9BREQiOiJBREQiLCJuYmYiOjE1MjA1NjUxMjEsImV4cCI6MTUyMDU2ODcyMSwiaWF0IjoxNTIwNTY1MTIxfQ.HFFQr8QtI6efVh2kqbbVDShUXyaHQM72sbj5cxAJs-U";
        public string invalidtoken = "invalidToken";

        [Fact]
        public void TokenInHeader()
        {
            HttpActionContext context = HttpActionContextMockData.validActionContext();

            Assert.Equal(validtoken, RequestTransformer.GetToken(context));
        }

        //[Fact]
        //public void TokenInvalid()
        //{

        //}

        //[Fact]
        //public void ValidToken()
        //{

        //}

        //[Fact]
        //public void NoTokenHeader()
        //{
            
        //}
    }
}
