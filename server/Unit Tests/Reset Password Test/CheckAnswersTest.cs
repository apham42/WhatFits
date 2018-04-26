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
    public class CheckAnswersTest
    {
        /// <summary>
        /// Correct ANswers
        /// </summary>
        [Fact]
        public void CorrectAnswers()
        {
            LoginDTO username = new LoginDTO()
            {
                UserName = "hi"
            };

            ResetPasswordResponseDTO incommingAnswers = new ResetPasswordResponseDTO()
            {
                Answers = new Dictionary<int, string>()
                {
                    { 2, "CSULB" },
                    { 6, "Lakers" },
                    { 9, "Huntington Beach" }
                }
            };

            CheckAnswers correct = new CheckAnswers()
            {
                username = username,
                incommingAnswers = incommingAnswers
            };

            var response = (ResetPasswordResponseDTO)correct.Execute().Result;

            Assert.True(response.isSuccessful);
        }

        /// <summary>
        /// User does not exist
        /// </summary>
        [Fact]
        public void UserDoesNotExist()
        {
            LoginDTO username = new LoginDTO()
            {
                UserName = "asdfasdf"
            };

            CheckAnswers userdoesnotexist = new CheckAnswers()
            {
                username = username
            };

            var response = (ResetPasswordResponseDTO)userdoesnotexist.Execute().Result;

            Assert.False(response.isSuccessful);
        }

        /// <summary>
        /// incorrect answers
        /// </summary>
        [Fact]
        public void InCorrectAnswers()
        {
            LoginDTO username = new LoginDTO()
            {
                UserName = "hi"
            };

            ResetPasswordResponseDTO incommingAnswers = new ResetPasswordResponseDTO()
            {
                Answers = new Dictionary<int, string>()
                {
                    { 2, "asdf" },
                    { 6, "Lakers" },
                    { 9, "Huntington Beach" }
                }
            };

            CheckAnswers correct = new CheckAnswers()
            {
                username = username,
                incommingAnswers = incommingAnswers
            };

            var response = (ResetPasswordResponseDTO)correct.Execute().Result;

            Assert.False(response.isSuccessful);
        }
    }
}
