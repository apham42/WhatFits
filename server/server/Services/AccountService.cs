using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using server.Constants;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using server.Interfaces;
using server.Model.Account;
using server.Model.Validators.Account_Validator;
using FluentValidation.Results;
using Whatfits.Hash;

namespace server.Services
{
    public class AccountService :ICreation<RegInfo>
    {
        public RegInfoResponseDTO CreateUser(RegInfo creds)
        {
            var response = ValidateRegInfo(creds);
            if(!response.isSuccessful)
            {
                return response;
            }

            if (Create(creds))
            {
                response.isSuccessful = true;
                response.Messages.Add(AccountConstants.USER_CREATED);
            }
            else
            {
                response.isSuccessful = false;
                response.Messages.Add(AccountConstants.USER_CREATE_FAIL);
            }
            return response;
        }

        public RegInfoResponseDTO ValidateRegInfo(RegInfo userCreds)
        {
            RegInfoResponseDTO validationResult = new RegInfoResponseDTO();
            List<string> messages = new List<string>();

            if (userCreds == null)
            {
                validationResult.isSuccessful = false;
                validationResult.Messages = messages;
                validationResult.Messages.Add("Registration Information is not valid. Please include the proper information needed.");
                return validationResult;
            }

            UserCredValidator validator = new UserCredValidator();
            ValidationResult results = validator.Validate(userCreds.UserCredInfo);



            IList<ValidationFailure> failures = results.Errors;

            if (!failures.Any())
            {
                validationResult.isSuccessful = true;
            }
            else
            {
                foreach(ValidationFailure failure in failures)
                {
                    messages.Add(failure.ErrorMessage);
                }
                validationResult.isSuccessful = false;
            }

            validationResult.Messages = messages;
            return validationResult;
        }



        public bool Create(RegInfo user)
        {
            HMAC256 hmac = new HMAC256();
            var salt = hmac.GenerateSalt();

            if (salt != null || salt.Equals(""))
            {
                return false;
            }

            var original = new HashDTO()
            {
                Original = user.UserCredInfo.Password
            };

            var hashPassword = hmac.Hash(original);
            if (hashPassword != null || hashPassword.Equals(""))
            {
                return false;
            }

            var userCredentials = new UserCredentialDTO()
            {
                Username = user.UserCredInfo.Username

            };

            return true;
        }

    }
}