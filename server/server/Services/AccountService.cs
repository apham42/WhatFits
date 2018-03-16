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

namespace server.Services
{
    public class AccountService :ICreation
    {
        public UserCredResponseDTO RegisterCredentials(UserCredentials creds)
        {
            var response = ValidateCredentials(creds);
            if(!response.isSuccessful)
            {
                return response;
            }

            response.Messages.Clear();

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

        public UserCredResponseDTO ValidateCredentials(UserCredentials userCreds)
        {
            UserCredResponseDTO validationResult = new UserCredResponseDTO();
            UserCredentialValidator validator = new UserCredentialValidator();
            ValidationResult results = validator.Validate(userCreds);
            IList<ValidationFailure> failures = results.Errors;
            List<string> messages = new List<string>();

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

        public bool Create<T>(T user)
        {

            return false;
        }
        

    }
}