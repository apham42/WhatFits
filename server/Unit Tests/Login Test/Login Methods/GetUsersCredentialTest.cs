using server.Business_Logic.Login;
using server.Controllers;
using server.Model.Account;
using server.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Xunit;

namespace Unit_Tests.Login_Test.Login_Methods
{
    public class GetUsersCredentialTest
    {
        [Fact] 
        public void UserExist()
        {
            LoginDTO username = new LoginDTO();
            username.UserName = "hi";
            GetUsersCredentials getUserCredentials = new GetUsersCredentials()
            {
                loginDTO = username
            };

            ResponseDTO<LoginDTO> response = (ResponseDTO<LoginDTO>) getUserCredentials.Execute().Result;
            
            Assert.Equal("hi", response.Data.UserName);
            Assert.Equal("Enable", response.Data.Type);
            Assert.Equal("1", response.Data.UserID.ToString());
        }

        [Fact]
        public void UserDOesNotExist()
        {
            LoginDTO username = new LoginDTO();
            username.UserName = "lol";
            GetUsersCredentials getUserCredentials = new GetUsersCredentials()
            {
                loginDTO = username
            };

            ResponseDTO<LoginDTO> response = (ResponseDTO<LoginDTO>)getUserCredentials.Execute().Result;

            Assert.False(response.IsSuccessful);
        }


    }
}
