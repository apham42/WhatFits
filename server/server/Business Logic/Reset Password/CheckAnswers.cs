using server.Interfaces;
using server.Model;
using System.Collections.Generic;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.Hash;

namespace server.Business_Logic.Reset_Password
{
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

            incommingAnswers.Messages = new List<string>();

            if(incommingAnswers.Answers == null)
            {
                incommingAnswers.isSuccessful = false;
                response.Result = incommingAnswers;
                return response;
            }

            var loginGateway = new LoginGateway();
            var dbanswers = loginGateway.GetSecurityQandAs(username);

            if(dbanswers.isSuccessful == false)
            {
                incommingAnswers.isSuccessful = false;
                response.Result = incommingAnswers;
                return response;
            }

            // hash answers
            var hashDTO = new HashDTO();
            var hash = new HMAC256();

            var hashedAnswers = new Dictionary<int, string>();

            foreach(var keys in incommingAnswers.Answers.Keys)
            {
                hashDTO.Original = incommingAnswers.Answers[keys];
                hashedAnswers[keys] = hash.Hash(hashDTO);
            }

            foreach(var keys in hashedAnswers.Keys)
            {
                if(hashedAnswers[keys] != dbanswers.Answers[keys])
                {
                    incommingAnswers.isSuccessful = false;
                    response.Result = incommingAnswers;
                    return response;
                }
            }

            incommingAnswers.isSuccessful = true;
            response.Result = incommingAnswers;

            return response;
        }
    }
}