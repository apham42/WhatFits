using server.Business_Logic.Login;
using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System.Collections.Generic;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;

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
    }
}