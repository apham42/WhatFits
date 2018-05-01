using FluentValidation.Results;
using server.Business_Logic.Services;
using server.Constants;
using server.Interfaces;
using server.Model;
using server.Model.Account;
using server.Model.Validators.Account_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.Hash;

namespace server.Business_Logic.Reset_Password
{
    public class SetNewPassword : ICommand
    {
        public UserCredential incommingCredentials;

        /// <summary>
        /// Set nw password for user
        /// </summary>
        /// <returns>return true if successful else false</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            var messages = new List<string>();

            ResetPasswordResponseDTO validResponse = new ResetPasswordResponseDTO();

            // Returns error if user credentials are null
            if (incommingCredentials == null)
            {
                validResponse.isSuccessful = false;
                messages.Add(AccountConstants.REGISTRATION_INVALID);
                validResponse.Messages = messages;
                response.Result = validResponse;
                return response;
            }
            var validator = new UserCredValidator();
            var results = validator.Validate(incommingCredentials);

            IList<ValidationFailure> failures = results.Errors;

            // Returns any error messages if there was any when validating
            if (failures.Any())
            {
                foreach (ValidationFailure failure in failures)
                {
                    messages.Add(failure.ErrorMessage);
                }
                validResponse.isSuccessful = false;
                validResponse.Messages = messages;
                response.Result = validResponse;
                return response;
            }

            if (new BadPasswordService().BadPassword(incommingCredentials.Password) == true)
            {
                validResponse.isSuccessful = false;
                messages.Add("Bad Password");
                validResponse.Messages = messages;
                response.Result = validResponse;
                return response;
            }

            HMAC256 hashPassword = new HMAC256();
            string newSALT = hashPassword.GenerateSalt();

            HashDTO hashDTO = new HashDTO()
            {
                Original = incommingCredentials.Password + newSALT
            };

            string newPassword = hashPassword.Hash(hashDTO);

            LoginDTO newCredentials = new LoginDTO()
            {
                UserName = incommingCredentials.Username,
                Password = newPassword,
                SaltValue = newSALT
            };
            
            LoginGateway loginGateway = new LoginGateway();

            response.Result = loginGateway.SetNewPass(newCredentials);

            return response;
        }
    }
}