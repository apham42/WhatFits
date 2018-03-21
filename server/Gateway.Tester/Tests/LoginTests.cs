using System;
using System.Collections.Generic;
using System.Linq;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
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
        public void GetCredentials()
        {
            // Getting Credentials from amay
            LoginDTO findCredential = new LoginDTO
            {
                UserName = "latmey"
            };
            LoginDTO expectedCredential = new LoginDTO
            {
                UserID = 2,
                Password = "123456",
                Salt = "asdf",
                Type = "General"
            };
            Assert.Equal(expectedCredential, auth.GetCredentials(findCredential));
        }
        [Fact]
        public void CheckBlacklistToken()
        {
            LoginDTO expectedToken = new LoginDTO
            {
                Token = "adhlfkjh323hdh93"
            };
        }
        [Fact]
        public void GetUsersSecurityQandAs()
        {

        }

    }
    
}
