using System;
using System.Collections.Generic;
using System.Linq;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Xunit;
using Whatfits.DataAccess.DTOs;

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
            ResponseDTO <LoginDTO> found = auth.GetCredentials(findCredential);

            //Assert.Equal(expectedCredential,found.Data);
        }
        [Fact]
        public void CheckBlacklistToken()
        {
            LoginDTO expectedToken = new LoginDTO
            {
                Token = "adhlfkjh323hdh93"
            };

            ResponseDTO<Boolean> found = auth.CheckIfTokenOnBlackList(expectedToken);
            Assert.True(found.Data);
        }
        [Fact]
        public void GetUsersSecurityQandAs()
        {

        }

    }
    
}
