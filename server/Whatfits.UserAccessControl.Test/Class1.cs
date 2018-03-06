using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Whatfits.UserAccessControl.Controller;
using Xunit;

namespace Whatfits.UserAccessControl.Test
{
    public class Class1
    {
        [Fact]
        public void DefaultClaims()
        {
            string username = "test";
            List<Claim> Default_Claims = UserAccessController.SetDefaultClaims(username);
            Assert.NotEmpty(Default_Claims);
        }
    }
}
