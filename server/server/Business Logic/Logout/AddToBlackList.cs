using server.Interfaces;
using server.Model;
using server.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace server.Business_Logic.Logout
{
    /// <summary>
    /// add token to blacklist
    /// </summary>
    public class AddToBlackList : ICommand
    {
        public UserCredential userCredentia;

        /// <summary>
        /// add token to blacklist
        /// </summary>
        /// <returns>isSuccessful = true is added else false</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = userCredentia.Username,
                Token = userCredentia.Token
            };
            
            LoginGateway logoutGateway = new LoginGateway();

            response.Result = logoutGateway.AddTokenToBlackList(loginDTO);

            return response;
        }
    }
}