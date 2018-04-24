using server.Business_Logic.Reset_Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.Hash;

namespace server.Business_Logic.Services
{
    // TODO: @AaronPham CheckAnswer and SetNewPassword service
    public class ResetPasswordService
    {
        public ResetPasswordService() { }

        /// <summary>
        /// Get questions for user
        /// </summary>
        /// <param name="loginDTO">user</param>
        /// <returns>user's security questions</returns>
        public ResetPasswordResponseDTO GetQuestions(LoginDTO loginDTO)
        {
            ResetPasswordResponseDTO response = new ResetPasswordResponseDTO();

            GetQuestions getQuestions = new GetQuestions()
            {
                loginDTO = loginDTO
            };

            response = (ResetPasswordResponseDTO) getQuestions.Execute().Result;

            return response;
        }

        /// <summary>
        /// checks answers
        /// </summary>
        /// <param name="incommingAnswers">incomming answers </param>
        /// <param name="username">username</param>
        /// <returns>true if answers are correct else false</returns>
        public ResetPasswordResponseDTO CheckAnswers(ResetPasswordResponseDTO incommingAnswers, LoginDTO username)
        {
            CheckAnswers checkAnswers = new CheckAnswers()
            {
                incommingAnswers = incommingAnswers,
                username = username
            };

            return (ResetPasswordResponseDTO) checkAnswers.Execute().Result;
        }

        public ResetPasswordResponseDTO ReplaceOldPassword()
        {
            throw new NotImplementedException();
        }
    }
}