using FluentValidation.Results;
using server.Constants;
using server.Interfaces;
using server.Model;
using server.Model.Account;
using server.Model.Validators.Account_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;

namespace server.Business_Logic.Login
{
    public class UserCredentialTransformer : ICommand
    {
        public UserCredential userCredential { get; set; }

        /// <summary>
        /// Execute UserCredentialTransformer
        /// Take UserCredential and turns into LoginDTO
        /// </summary>
        /// <returns>LoginDTO</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            ResponseDTO<LoginDTO> validResponse = new ResponseDTO<LoginDTO>();
            validResponse.Messages = new List<string>();
            // Returns error if user credentials are null
            if (userCredential == null)
            {
                validResponse.IsSuccessful = false;
                validResponse.Messages.Add(AccountConstants.REGISTRATION_INVALID);
                
                response.Result = validResponse;
                return response;
            }
            var validator = new UserCredValidator();
            var results = validator.Validate(userCredential);

            IList<ValidationFailure> failures = results.Errors;

            // Returns any error messages if there was any when validating
            if (failures.Any())
            {
                foreach (ValidationFailure failure in failures)
                {
                    validResponse.Messages.Add(failure.ErrorMessage);
                }
                validResponse.IsSuccessful = false;
                response.Result = validResponse;
                return response;
            }

            validResponse.Data = new LoginDTO()
            {
                UserName = userCredential.Username,
                Password = userCredential.Password
            };
            validResponse.IsSuccessful = true;
            response.Result = validResponse;
            
            return response;
        }
    }
}