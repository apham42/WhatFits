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
    /// <summary>
    /// Validates Registration Information
    /// </summary>
    public class RegInfoValidator : IValidation<RegInfoResponseDTO, RegInfo>
    {
        /// <summary>
        /// Validated Geocoordinates from Google Map Web API based on user location
        /// </summary>
        public WebAPIGeocode ValidatedLocation { get; set; }

        public RegInfoValidator()
        {

        }

        /// <summary>
        /// Validate command for registration information
        /// </summary>
        /// <param name="user"></param>
        /// <returns>A DTO that contains status and any messages</returns>
        public RegInfoResponseDTO Validate(RegInfo user)
        {
            var validationResult = new RegInfoResponseDTO();
            var messages = new List<string>();

            if (ValidateUserCred(user.UserCredInfo, validationResult) && ValidateQandAs(user.SecurityQandAs, validationResult) && ValidateLocation(user.UserLocation, validationResult))
            {
                // RegInfoResponseDTO contains error messages because of pass by reference.
                validationResult.isSuccessful = true;
            }

            return validationResult;
        }

        /// <summary>
        /// Validates the user credentials of the registraion information
        /// </summary>
        /// <param name="userCred"></param>
        /// <param name="validationResult">The response DTO that the Validate method will be referencing to</param>
        /// <returns>status if the credentials are valid based on business rules</returns>
        public bool ValidateUserCred(UserCredential userCred, RegInfoResponseDTO validationResult)
        {
            var messages = new List<string>();

            // Returns error if user credentials are null
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

            // Returns any error messages if there was any when validating
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

            // Checks username in the database
            var gateway = new RegistrationGateway();
            var gatewayResponse = gateway.CheckUserName(dto);

            // Return error if theres any error messages
            if (!gatewayResponse.isSuccessful)
            {
                validationResult.isSuccessful = false;
                validationResult.Messages = gatewayResponse.Messages;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the Security Questions and Answers of the Registration Information
        /// </summary>
        /// <param name="questions">List of Security questions with answers</param>
        /// <param name="validationResult">The response DTO that the Validate method will be referencing to</param>
        /// <returns> status if the security questions and answers are valid based on business rules </returns>
        public bool ValidateQandAs(List<SecurityQuestion> questions, RegInfoResponseDTO validationResult)
        {
            var messages = new List<string>();

            // Returns error if questions if null
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
                foreach (SecurityQuestion question in questions)
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

        /// <summary>
        /// Validates the User Location of the Registration Information
        /// </summary>
        /// <param name="userLocation"></param>
        /// <param name="validationResult">The response DTO that the Validate method will be referencing to</param>
        /// <returns>status if the location is valid based on business rules</returns>
        public bool ValidateLocation(Address userLocation, RegInfoResponseDTO validationResult)
        {
            var messages = new List<string>();

            // Returns error if userLocation is null
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

            // Returns error messages if there is any
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