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
        /// <param name="loginDTO">username and token</param>
        /// <returns>responseDTO with true or false</returns>
        public ResponseDTO<bool> logout(UserCredential userCredential)
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = userCredential.Username,
                Token = userCredential.Token
            };
            
            LoginGateway logoutGateway = new LoginGateway();

            return logoutGateway.AddTokenToBlackList(loginDTO);
        }
    }
}