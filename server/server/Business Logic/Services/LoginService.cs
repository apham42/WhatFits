using server.Interfaces;
using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.JsonWebToken.Controller;

namespace server.Business_Logic.Services
{
    public class LoginService : ILogin
    {
        public LoginService() { }

        public string username { get; set; }
        public string password { get; set; }
        public LoginResponseDTO response { get; set; }

        public ResponseDTO<LoginDTO> ValidateCredentials(ResponseDTO<LoginDTO> responseDTO)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<LoginDTO> GetUsersCredentails(LoginDTO loginDTO)
        {
            LoginGateway loginGateway = new LoginGateway();

            return loginGateway.GetCredentials(loginDTO);
        }

        public LoginDTO UserCredentialTransformer(UserCredential userCredential)
        {
            return new LoginDTO()
            {
                UserName = userCredential.Username,
                Password = userCredential.Password
            };
        }

        public LoginResponseDTO GetLoginToken(ResponseDTO<LoginDTO> responseDTO)
        {
            if(responseDTO.Data.Type == "Enable")
            {
                CreateJWT createJWT = new CreateJWT();
                string token = createJWT.CreateToken(responseDTO.Data.UserName);
                ConvertToJWT convertToJWT = new ConvertToJWT(token);

                return new LoginResponseDTO()
                {
                    token = token,
                    username = responseDTO.Data.UserName,
                    viewclaims = convertToJWT.GetClaimsFromToken(),
                    isSuccessful = true
                };
            }

            return new LoginResponseDTO()
            {
                isSuccessful = false
            };
        }
    }
}