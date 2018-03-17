using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using server.Constants;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using server.Interfaces;
using server.Model.Account;
using server.Model.Validators;
using FluentValidation.Results;
using Whatfits.Hash;

namespace server.Services
{
    public class AccountService :ICreation<UserCredInfo>
    {
        public UserCredResponseDTO CreateUser(UserCredInfo creds)
        {
            var response = ValidateCredentials(creds);
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

        public UserCredResponseDTO ValidateCredentials(UserCredInfo userCreds)
        {
            UserCredResponseDTO validationResult = new UserCredResponseDTO();
            List<string> messages = new List<string>();

            if (userCreds == null)
            {
                validationResult.isSuccessful = false;
                validationResult.Messages = messages;
                validationResult.Messages.Add("EMPTY");
                return validationResult;
            }

            UserCredentialValidator validator = new UserCredentialValidator();
            ValidationResult results = validator.Validate(userCreds);
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



        public bool Create(UserCredInfo user)
        {
            HMAC256 hmac = new HMAC256();
            var salt = hmac.GenerateSalt();

            if (salt != null || salt.Equals(""))
            {
                return false;
            }

            var original = new HashDTO()
            {
                Original = user.Password
            };

            var hashPassword = hmac.Hash(original);
            if (hashPassword != null || hashPassword.Equals(""))
            {
                return false;
            }

            var userCredentials = new UserCredentialDTO()
            {
                Username = user.Username

            };

            return true;
        }

    }
}