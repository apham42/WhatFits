using server.Business_Logic.Reset_Password;
using server.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Xunit;

namespace Unit_Tests.Reset_Password_Test
{
    public class SetNewPasswordTest
    {
        /// <summary>
        /// Failed to set new password
        /// </summary>
        [Fact]
        public void UserDoesNotExist()
        {
            UserCredential newCredentials = new UserCredential("asdf", "asdf");

            SetNewPassword nouser = new SetNewPassword()
            {
                incommingCredentials = newCredentials
            };

            var response = (ResetPasswordResponseDTO)nouser.Execute().Result;

            Assert.False(response.isSuccessful);
        }

        /// <summary>
        /// user exist but invalid pass
        /// </summary>
        [Fact]
        public void NotValidPassword()
        {
            UserCredential newCredentials = new UserCredential("hi", "hello");

            SetNewPassword nouser = new SetNewPassword()
            {
                incommingCredentials = newCredentials
            };

            var response = (ResetPasswordResponseDTO)nouser.Execute().Result;

            Assert.False(response.isSuccessful);
        }

        /// <summary>
        /// successfullysetpass
        /// </summary>
        [Fact]
        public void SuccessfulResetPass()
        {
            UserCredential newCredentials = new UserCredential("hi", "hellohello");

            SetNewPassword nouser = new SetNewPassword()
            {
                incommingCredentials = newCredentials
            };

            var response = (ResetPasswordResponseDTO)nouser.Execute().Result;

            Assert.True(response.isSuccessful);
        }

    }
}
