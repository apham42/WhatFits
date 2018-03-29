using System;
using System.Security;
using System.Security.Claims;
using Whatfits.UserAccessControl.Service;
using Xunit;

namespace Whatfits.UserAccessControl.Test.ServiceTest
{
    public class ClaimsTransformerTest
    {
        [Fact]
        public void IsNull()
        {
            ClaimsPrincipal nullPrincipal = null;
            ClaimsTransformer test = new ClaimsTransformer();

            Action act = () => test.Authenticate(nullPrincipal);

            Assert.Throws<SecurityException>(act);
        }

    }
}
