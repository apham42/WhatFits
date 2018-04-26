using server.Business_Logic.Reset_Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Xunit;

namespace Unit_Tests.Reset_Password_Test
{
    public class GetQuestionsTest
    {
        /// <summary>
        /// User does not exist
        /// </summary>
        [Fact]
        public void FailedToGetQuestions ()
        {
            LoginDTO username = new LoginDTO()
            {
                UserName = "asdf"
            };

            GetQuestions failedToGet = new GetQuestions()
            {
                loginDTO = username
            };

            var response = (ResetPasswordResponseDTO)failedToGet.Execute().Result;

            Assert.False(response.isSuccessful);
        }

        /// <summary>
        /// User does exist
        /// </summary>
        [Fact]
        public void GetQuestions()
        {
            LoginDTO username = new LoginDTO()
            {
                UserName = "hi"
            };

            GetQuestions failedToGet = new GetQuestions()
            {
                loginDTO = username
            };

            var response = (ResetPasswordResponseDTO)failedToGet.Execute().Result;

            Assert.True(response.isSuccessful);
            Assert.Equal("Where did you go to highschool or college?", response.Questions[2]);
            Assert.Equal("What is your favorite sports team?", response.Questions[6]);
            Assert.Equal("In what city or town does your nearest sibling live?", response.Questions[9]);
        }
    }
}
