using System;
using System.Collections.Generic;
using System.Linq;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Xunit;

namespace Gateway.Tester
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginTests
    {
        LoginGateway auth = new LoginGateway();
        [Fact]
        public void GetCredentials(LoginDTO obj)
        {

        }
    }
}
