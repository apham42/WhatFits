using server.Business_Logic.Logout;
using server.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace server.Business_Logic.Services
{
    public class LogoutService
    {
        public LogoutService() { }

        /// <summary>
        /// add token to login gateway
        /// </summary>
        /// <param name="userCredential">username and token</param>
        /// <returns>responseDTO with true or false</returns>
        public LogoutResponseDTO logout(UserCredential userCredential)
        {   
            LoginGateway logoutGateway = new LoginGateway();

            var addToBlackList = new AddToBlackList()
            {
                userCredentia = userCredential
            };

            var response = (LogoutResponseDTO) addToBlackList.Execute().Result;
            response.Messages = new List<string>();

            if(response.isSuccessful == false)
            {
                response.Messages.Add("Failed To Logout");
                return response;
            }

            response.Messages.Add("Success!");
            return response;
        }
    }
}