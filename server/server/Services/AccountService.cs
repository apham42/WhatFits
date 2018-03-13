using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using server.Constants;
using server.Data_Transfer_Objects.AccountDTO_s;

namespace server.Services
{
    public class AccountService
    {
        private string user = "Abram";

        public bool RegisterCredentials(UserCredentialDTO creds)
        {
            ValidateCredentials(creds);
            return true;
        }

        public bool ValidateCredentials (UserCredentialDTO creds)
        {
            return true;
        }

        public bool ValidateUserName(string userName)
        {
            bool isUserValid = false;

            if (!userName.Equals(user) && ValidateCharacters(userName))
            {
                isUserValid = true;
            }
            return isUserValid;
        }

        public bool ValidatePassword(string password)
        {
            bool isPassValid = false;
            if (password.Length >= 8 && password.Length <= 64 && ValidateCharacters(password))
            {
                isPassValid = true;
            }
            return isPassValid;
        }

        public bool ValidateCharacters(string credential)
        {
            bool isCredentialValid = false;
            var rgxCheck = new Regex(AccountConstants.CREDCHARACTERS);
            if (rgxCheck.IsMatch(credential))
            {
                isCredentialValid = true;
            }
            return isCredentialValid;
        }

        
    }
}