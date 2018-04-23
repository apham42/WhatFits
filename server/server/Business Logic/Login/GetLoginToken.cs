using server.Interfaces;
using server.Model;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.JsonWebToken.Controller;

namespace server.Business_Logic.Login
{
    public class GetLoginToken : ICommand
    {
        public ResponseDTO<LoginDTO> responseDTO { get; set; }

        /// <summary>
        /// get token for user when valid
        /// </summary>
        /// <returns>returns valid token for user with view claims</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            if(responseDTO.Data.Type == "Enable")
            {
                CreateJWT createJWT = new CreateJWT();
                string token = createJWT.CreateToken(responseDTO.Data.UserName);
                ConvertToJWT convertToJWT = new ConvertToJWT(token);

                response.Result = new LoginResponseDTO()
                {
                    token = token,
                    username = responseDTO.Data.UserName,
                    viewclaims = convertToJWT.GetClaimsFromToken(),
                    Messages = new List<string>(),
                    isSuccessful = true
                };
            }
            else
            {
                response.Result = new LoginResponseDTO()
                {
                    Messages = new List<string>(),
                    isSuccessful = false
                };
            }
            
            return response;
        }
    }
}