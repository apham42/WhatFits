using System.Collections.Generic;
using System.Security.Claims;
using Whatfits.UserAccessControl.Controller;
using Xunit;

namespace UserAccessControl.ServiceTest
{
    public class SetDefaultClaimsTest
    {
        [Fact]
        public void DefaultClaims()
        {
            List<Claim> Default_Claims = UserAccessController.SetDefaultClaims();
            Assert.NotEmpty(Default_Claims);
        }
    }
}
