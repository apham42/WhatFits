using server.Business_Logic.Reset_Password;
using server.Model.Account;
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
        public ResetPasswordResponseDTO GetQuestions(UserCredential userCredential)
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = userCredential.Username
            };

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
        public ResetPasswordResponseDTO CheckAnswers(ResetPasswordResponseDTO incommingAnswers, UserCredential username)
        {
            LoginDTO user = new LoginDTO()
            {
                UserName = username.Username
            };  
            CheckAnswers checkAnswers = new CheckAnswers()
            {
                incommingAnswers = incommingAnswers,
                username = user
            };

            return (ResetPasswordResponseDTO) checkAnswers.Execute().Result;
        }

        /// <summary>
        /// Replace old password service
        /// </summary>
        /// <param name="newCredentials">new user credentials</param>
        /// <returns>true if success else false</returns>
        public ResetPasswordResponseDTO ReplaceOldPassword(UserCredential newCredentials)
        {

            SetNewPassword setNewPassword = new SetNewPassword()
            {
                incommingCredentials = newCredentials
            };

            return (ResetPasswordResponseDTO)setNewPassword.Execute().Result;
        }
    }
}