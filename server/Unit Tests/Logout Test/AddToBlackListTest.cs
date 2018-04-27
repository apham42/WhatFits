using server.Business_Logic.Logout;
using server.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Xunit;

namespace Unit_Tests.Logout_Test
{
    public class AddToBlackListTest
    {
        /// <summary>
        /// user does not exist
        /// </summary>
        [Fact]
        public void UserDoesNotExist()
        {
            UserCredential token = new UserCredential("user", "token");

            AddToBlackList add = new AddToBlackList()
            {
                userCredentia = token
            };

            var response = (LogoutResponseDTO)add.Execute().Result;

            Assert.False(response.isSuccessful);
        }

        /// <summary>
        /// user exist
        /// </summary>
        [Fact]
        public void SuccessfulAdd()
        {
            UserCredential token = new UserCredential("hi", "token");

            AddToBlackList add = new AddToBlackList()
            {
                userCredentia = token
            };

            var response = (LogoutResponseDTO)add.Execute().Result;

            Assert.True(response.isSuccessful);
        }
    }
}
