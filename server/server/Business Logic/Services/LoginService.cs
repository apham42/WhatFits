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
using Whatfits.Hash;
using Whatfits.JsonWebToken.Controller;
using server.Business_Logic.Login;

namespace server.Business_Logic.Services
{
    public class LoginService
    {
        public LoginService() { }
        private LoginResponseDTO response { get; set; }
        public UserCredential userCredential { get; set; }
        
        /// <summary>
        /// Executes login commands
        /// </summary>
        /// <returns>return username, token, view claims when pass, else fail messages</returns>
        public LoginResponseDTO loginService ()
        {
            response = new LoginResponseDTO();
            response.Messages = new List<string>();

            var userCredential = new UserCredentialTransformer()
            {
                userCredential = this.userCredential
            };

            var incommingloginDTO = (LoginDTO) userCredential.Execute().Result;

            var getUserCredentials = new GetUsersCredentials()
            {
                loginDTO = incommingloginDTO
            };

            var credentials = (ResponseDTO<LoginDTO>) getUserCredentials.Execute().Result;

            if(credentials.IsSuccessful == false)
            {
                response.isSuccessful = false;
                response.Messages.Add("User does not exist");
                return response;
            }

            var validated = new ValidateCredentials()
            {
                loginDTO = incommingloginDTO,
                responseDTO = credentials
            };

            var isValidated = (bool) validated.Execute().Result;

            if(isValidated == false)
            {
                response.isSuccessful = false;
                response.Messages.Add("Incorrect Credentials");
                return response;
            }

            var getToken = new GetLoginToken()
            {
                responseDTO = credentials
            };

            response = (LoginResponseDTO) getToken.Execute().Result;

            if(response.isSuccessful == false)
            {
                response.isSuccessful = false;
                response.Messages.Add("Could not Create Token");
                return response;
            }

            response.Messages.Add("Success");
            return response;
        }

        //public bool ValidateCredentials(LoginDTO loginDTO, ResponseDTO<LoginDTO> responseDTO)
        //{
        //    HashDTO hashDTO = new HashDTO()
        //    {
        //        Original = loginDTO.Password + responseDTO.Data.Salt
        //    };

        //    string hashedincommingpassword = new HMAC256().Hash(hashDTO);

            

        //    return checkIfEqual(hashedincommingpassword, responseDTO.Data.Password);
        //}

        //private bool checkIfEqual(string incommingpassword, string dbpassword)
        //{
        //    if(incommingpassword == dbpassword)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public ResponseDTO<LoginDTO> GetUsersCredentails(LoginDTO loginDTO)
        //{
        //    LoginGateway loginGateway = new LoginGateway();

        //    return loginGateway.GetCredentials(loginDTO);
        //}

        //public LoginDTO UserCredentialTransformer(UserCredential userCredential)
        //{
        //    return new LoginDTO()
        //    {
        //        UserName = userCredential.Username,
        //        Password = userCredential.Password
        //    };
        //}

        //public LoginResponseDTO GetLoginToken(ResponseDTO<LoginDTO> responseDTO)
        //{
        //    if(responseDTO.Data.Type == "Enable")
        //    {
        //        CreateJWT createJWT = new CreateJWT();
        //        string token = createJWT.CreateToken(responseDTO.Data.UserName);
        //        ConvertToJWT convertToJWT = new ConvertToJWT(token);

        //        return new LoginResponseDTO()
        //        {
        //            token = token,
        //            username = responseDTO.Data.UserName,
        //            viewclaims = convertToJWT.GetClaimsFromToken(),
        //            isSuccessful = true
        //        };
        //    }

        //    return new LoginResponseDTO()
        //    {
        //        isSuccessful = false
        //    };
        //}
    }
}