using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using server.Constants;
using server.Model.Data_Transfer_Objects.AccountDTO_s;

namespace server.Services
{
    public class AccountService 
    {
        private string user = "Abram";

        public UserCredResponseDTO RegisterCredentials(UserCredentialDTO creds)
        {
            UserCredResponseDTO response = ValidateCredentials(creds);
            return response;
        }

        public UserCredResponseDTO ValidateCredentials (UserCredentialDTO creds)
        {
            UserCredResponseDTO response = new UserCredResponseDTO();
            if (!ValidateUserName(creds.UserName, response))
            {
                return response;
            }
            ValidatePassword(creds.Password, response);

            return response;
        }

        public bool ValidateUserName(string userName, UserCredResponseDTO response)
        {
            if (!ValidateCharacters(userName))
            {
                response.Message = AccountConstants.USERNAME_INVALID_CHARACTERS_ERROR;
                response.Status = false;
                return false;
            }

            // Checks username if its unique using gateway
            response.Message = AccountConstants.USERNAME_VALID;
            response.Status = true;
            return true;
        }

        //public bool ValidateUserNameCharacters( string userName)

        public bool ValidatePassword(string password, UserCredResponseDTO response)
        {
            if (password.Length < 8)
            {
                response.Message = AccountConstants.PASSWORD_SHORT_ERROR;
                response.Status = false;
                return false;
            }

            if (password.Length > 64)
            {
                response.Message = AccountConstants.PASSWORD_LONG_ERROR;
                response.Status = false;
                return false;
            }

            if (!ValidateCharacters(password))
            {
                response.Message = AccountConstants.PASSWORD_INVALID_CHARACTERS_ERROR;
                response.Status = false;
                return false;
            }

            response.Message = AccountConstants.USER_AND_PASSWORD_VALID;
            response.Status = true;
            return true;
        }

        public bool ValidateCharacters(string credential)
        {
            var rgxCheck = new Regex(AccountConstants.CREDCHARACTERS);
            if (rgxCheck.IsMatch(credential))
            {
                return true;
            }
            return false;
        }

        
    }
}