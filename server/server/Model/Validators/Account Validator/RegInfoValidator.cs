using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using FluentValidation.Results;
using server.Model.Account;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using server.Constants;
using server.Model.Location;
using server.Model.Validators.Location_Validator;
using server.Model.Network_Communication;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace server.Model.Validators.Account_Validator
{
    public class RegInfoValidator: IValidation<RegInfoResponseDTO, RegInfo>
    {
        public WebAPIGeocode ValidatedLocation { get; set; }
        public RegInfoValidator()
        {

        }

        public RegInfoResponseDTO Validate(RegInfo user)
        {
            var validationResult = new RegInfoResponseDTO();
            var messages = new List<string>();
            
            if (ValidateUserCred(user.UserCredInfo, validationResult) && ValidateQandAs(user.SecurityQandAs, validationResult) && ValidateLocation(user.UserLocation, validationResult) )
            {
                validationResult.isSuccessful = true;
            }

            return validationResult;
        }

        public bool ValidateUserCred(UserCredential userCred, RegInfoResponseDTO validationResult)
        {
            var messages = new List<string>();
            if (userCred == null)
            {
                validationResult.isSuccessful = false;
                messages.Add(AccountConstants.REGISTRATION_INVALID);
                validationResult.Messages = messages;
                return false;
            }
            var validator = new UserCredValidator();
            var results = validator.Validate(userCred);

            IList<ValidationFailure> failures = results.Errors;

            if (failures.Any())
            {
                foreach (ValidationFailure failure in failures)
                {
                    messages.Add(failure.ErrorMessage);
                }
                validationResult.isSuccessful = false;
                validationResult.Messages = messages;
                return false;
            }

            var dto = new UsernameDTO()
            {
                Username = userCred.Username
            };

            var gateway = new RegistrationGateway();
            var gatewayResponse = gateway.CheckUserName(dto);

            if (!gatewayResponse.isSuccessful)
            {
                validationResult.isSuccessful = false;
                validationResult.Messages = gatewayResponse.Messages;
                return false;
            }

            return true;
        }

        public bool ValidateQandAs(List<SecurityQuestion> questions, RegInfoResponseDTO validationResult)
        {
            var messages = new List<string>();
            if (questions == null)
            {
                validationResult.isSuccessful = false;
                messages.Add(AccountConstants.QUESTION_INVALID_ERROR);
                validationResult.Messages = messages;
                return false;
            }
            var validator = new SecurityQuestionValidator();
            var results = validator.Validate(questions);

            // Checks if questions and answers fits the required length 
            var failures = results.Errors;
            if (failures.Any())
            {
                foreach (ValidationFailure failure in failures)
                {
                    messages.Add(failure.ErrorMessage);
                }
                validationResult.isSuccessful = false;
                validationResult.Messages = messages;
                return false;
            }

            // Retrieves the questions from the database
            RegistrationGateway gateway = new RegistrationGateway();
            var gatewayResponse = gateway.GetQuestions();
            if (!gatewayResponse.isSuccessful)
            {
                validationResult.isSuccessful = false;
                validationResult.Messages = gatewayResponse.Messages;
                return false;
            }
            else
            {
                // Goes through each user's question and checks if its in the list of retrieved question
                var retrievedQuestions = gatewayResponse.Questions;
                foreach(SecurityQuestion question in questions)
                {
                    if (!retrievedQuestions.Contains(question.Question))
                    {
                        validationResult.isSuccessful = false;
                        messages.Add(AccountConstants.QUESTION_INVALID_ERROR);
                        validationResult.Messages = messages;
                        return false;
                    }
                    else
                    {
                        // Removes the question from retrieved to catch duplicates
                        retrievedQuestions.Remove(question.Question);
                    }
                }
            }
            return true;
        }

        public bool ValidateLocation(Address userLocation, RegInfoResponseDTO validationResult)
        {
            var messages = new List<string>();
            if (userLocation == null)
            {
                validationResult.isSuccessful = false;
                messages.Add(LocationConstants.ADDRESS_DOESNT_EXIST_ERROR);
                validationResult.Messages = messages;
                return false;
            }

            var validator = new LocationValidator();
            var results = validator.Validate(userLocation);

            IList<ValidationFailure> failures = results.Errors;

            if (failures.Any())
            {
                foreach (ValidationFailure failure in failures)
                {
                    messages.Add(failure.ErrorMessage);
                }
                validationResult.isSuccessful = false;
                validationResult.Messages = messages;
                return false;
            }
            ValidatedLocation = validator.ValidatedLocation;
            return true;
        }

    }
}