using server.Interfaces;
using server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace server.Business_Logic.Reset_Password
{
    public class GetQuestions : ICommand
    {
        public LoginDTO loginDTO = new LoginDTO();

        /// <summary>
        /// get questions from db
        /// </summary>
        /// <returns>the 3 questions for recovery entered during registration</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            var loginGateway = new LoginGateway();

            response.Result = loginGateway.GetSecurityQuestions(loginDTO);
            
            return response;
        }
    }
}