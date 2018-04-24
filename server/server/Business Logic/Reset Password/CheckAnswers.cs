using server.Interfaces;
using server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.Hash;

namespace server.Business_Logic.Reset_Password
{
    // TODO: @AaronPham compare answers and return response
    public class CheckAnswers : ICommand
    {
        public ResetPasswordResponseDTO incommingAnswers = new ResetPasswordResponseDTO();
        public LoginDTO username = new LoginDTO();

        /// <summary>
        /// check answers from user input
        /// </summary>
        /// <returns>returns true if correct answers</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            var loginGateway = new LoginGateway();
            var dbanswers = loginGateway.GetSecurityQandAs(username);

            // hash answers
            var hashDTO = new HashDTO();
            var hash = new HMAC256();

            foreach(var keys in incommingAnswers.Answers.Keys)
            {
                hashDTO.Original = incommingAnswers.Answers[keys];
                incommingAnswers.Answers[keys] = hash.Hash(hashDTO);
            }

            return response;
        }
    }
}