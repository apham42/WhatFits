using server.Business_Logic.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.Hash;
using Xunit;

namespace Unit_Tests.Login_Test.Login_Methods
{
    public class ValidateCredentialTest
    {
        [Fact]
        public void InValidMatch()
        {
            string Salt = "asdf";
            string PassFromDB = "pass";
            string IncommingPass = "invalidpass";

            var inchashDTO = new HashDTO()
            {
                Original = IncommingPass + Salt
            };

            var dbHashDTO = new HashDTO()
            {
                Original = PassFromDB + Salt
            };

            var incomminghashpass = new HMAC256().Hash(inchashDTO);

            var dbhashpass = new HMAC256().Hash(dbHashDTO);

            var loginDTO = new LoginDTO()
            {
                Password = IncommingPass
            };
            var responseDTO = new ResponseDTO<LoginDTO>()
            {
                Data = new LoginDTO()
                {
                    Salt = Salt
                }
            };

            var validate = new ValidateCredentials()
            {

            };


        }
    }
}
