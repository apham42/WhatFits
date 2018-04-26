using server.Business_Logic.Login;
using server.Model.Account;
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
    public class UserCredentialTransformerTest
    {
        /// <summary>
        /// invalid password length
        /// </summary>
        [Fact]
        public void InValidPassword()
        {
            string username = "yo";
            string invalidpass = "hello";
            ResponseDTO<LoginDTO> responseDTO = new ResponseDTO<LoginDTO>();
            UserCredential InvalidCreds = new UserCredential(username, invalidpass);

            var userCredentialTransformer = new UserCredentialTransformer()
            {
                userCredential = InvalidCreds
            };

            responseDTO = (ResponseDTO<LoginDTO>) userCredentialTransformer.Execute().Result;

            Assert.False(responseDTO.IsSuccessful);
        }

        /// <summary>
        /// valid password length
        /// </summary>
        [Fact]
        public void ValidPassword()
        {
            string username = "yo";
            string invalidpass = "hellohello";
            ResponseDTO<LoginDTO> responseDTO = new ResponseDTO<LoginDTO>();
            UserCredential InvalidCreds = new UserCredential(username, invalidpass);

            var userCredentialTransformer = new UserCredentialTransformer()
            {
                userCredential = InvalidCreds
            };

            responseDTO = (ResponseDTO<LoginDTO>)userCredentialTransformer.Execute().Result;

            Assert.True(responseDTO.IsSuccessful);
        }

        /// <summary>
        /// inValid usernamelength
        /// </summary>
        [Fact]
        public void InValidUsername()
        {
            string username = "";
            string invalidpass = "hellohello";
            ResponseDTO<LoginDTO> responseDTO = new ResponseDTO<LoginDTO>();
            UserCredential InvalidCreds = new UserCredential(username, invalidpass);

            var userCredentialTransformer = new UserCredentialTransformer()
            {
                userCredential = InvalidCreds
            };

            responseDTO = (ResponseDTO<LoginDTO>)userCredentialTransformer.Execute().Result;

            Assert.False(responseDTO.IsSuccessful);
        }

        /// <summary>
        /// Valid username length
        /// </summary>
        [Fact]
        public void ValidUsername()
        {
            string username = "yo";
            string invalidpass = "hellohello";
            ResponseDTO<LoginDTO> responseDTO = new ResponseDTO<LoginDTO>();
            UserCredential InvalidCreds = new UserCredential(username, invalidpass);

            var userCredentialTransformer = new UserCredentialTransformer()
            {
                userCredential = InvalidCreds
            };

            responseDTO = (ResponseDTO<LoginDTO>)userCredentialTransformer.Execute().Result;

            Assert.True(responseDTO.IsSuccessful);
        }
    }
}
