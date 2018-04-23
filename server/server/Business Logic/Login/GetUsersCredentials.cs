using server.Interfaces;
using server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace server.Business_Logic.Login
{
    public class GetUsersCredentials : ICommand
    {
        public LoginDTO loginDTO { get; set; }

        /// <summary>
        /// Get user credentials from db
        /// username, salt, hash pass, type, id
        /// </summary>
        /// <returns>returns dto with user credentials</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            LoginGateway loginGateway = new LoginGateway();

            response.Result = loginGateway.GetCredentials(loginDTO);
            
            return response;
        }
    }
}