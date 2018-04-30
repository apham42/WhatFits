using server.Business_Logic.Login;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
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
    public class GetLoginTokenTest
    {
        [Fact]
        public void UserNotEnable()
        {
            ResponseDTO<LoginDTO> responseDTO = new ResponseDTO<LoginDTO>();
            responseDTO.Data = new LoginDTO()
            {
                UserName = "ay",
                Type = "Disable"
            };

            GetLoginToken disabledUser = new GetLoginToken()
            {
                responseDTO = responseDTO
            };

            var response = (LoginResponseDTO) disabledUser.Execute().Result;

            Assert.False(response.isSuccessful);
        }

        [Fact]
        public void TokenCreated()
        {
            ResponseDTO<LoginDTO> responseDTO = new ResponseDTO<LoginDTO>();
            responseDTO.Data = new LoginDTO()
            {
                UserName = "hi",
                Type = "Enable"
            };

            GetLoginToken disabledUser = new GetLoginToken()
            {
                responseDTO = responseDTO
            };

            var response = (LoginResponseDTO)disabledUser.Execute().Result;

            Assert.True(response.isSuccessful);
        }
    }
}
