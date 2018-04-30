using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.JsonWebToken.Controller;

namespace server.Business_Logic.Services
{  
    public class TokenRefreshService
    {
        public string username;
        public string token;
        public TokenRefreshResponseDTO response = new TokenRefreshResponseDTO();
        public TokenRefreshService(TokenRefreshResponseDTO response)
        {
            username = response.username;
            token = response.token;
            this.response = response;
        }

        /// <summary>
        /// refreshes token
        /// </summary>
        /// <returns>new token</returns>
        public TokenRefreshResponseDTO RefreshService()
        {
            LoginGateway gateway = new LoginGateway();

            LoginDTO incUsername = new LoginDTO()
            {
                UserName = username,
                Token = response.token
            };


            response.Messages = new List<string>();

            var storetoken = gateway.AddTokenToBlackList(incUsername);


            if(storetoken.isSuccessful == false)
            {
                response.Messages.Add("Failed to add token");
                return response;
            }

            CreateJWT newJWT = new CreateJWT();

            var jwt = newJWT.CreateToken(username);

            if(jwt == "Failed")
            {
                response.Messages.Add("Failed To make token");
                return response;
            }

            response.token = jwt;
            response.username = this.username;
            response.isSuccessful = true;
            response.Messages.Add("Success!");

            return response;
        }



    }
}