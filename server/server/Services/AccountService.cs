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
using Whatfits.Hash;
using server.Model.Location;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.UserAccessControl.Service;

namespace server.Services
{
    /// <summary>
    /// Handles all request that revolves around user accounts
    /// </summary>
    public class AccountService
    {
        public AccountService()
        {

        }

        /// <summary>
        /// Tries to create the user based on registration information
        /// </summary>
        /// <param name="creds"> Registeration Information </param>
        /// <returns> A DTO that contains status and any messages </returns>
        public RegInfoResponseDTO RegisterUser(RegInfo creds)
        {
            var validator = new RegInfoValidator();
            List<string> messages = new List<string>();

            // validates Register info
            var response = validator.Validate(creds);
            if (!response.isSuccessful)
            {
                return response;
            }

            // Save user into the database and returns the status
            if (Create(creds, validator.ValidatedLocation))
            {
                response.isSuccessful = true;
                messages.Add(AccountConstants.USER_CREATED);
                response.Messages = messages;
            }
            else
            {
                response.isSuccessful = false;
                messages.Add(AccountConstants.USER_CREATE_FAIL);
                response.Messages = messages;
            }
            return response;
        }

        /// <summary>
        /// Creates user based on validated information
        /// </summary>
        /// <param name="user"> Validated registeration information </param>
        /// <param name="geoCoordinates"> Validated Geocoordinates based on the location of registration information </param>
        /// <returns> status of the creation of the user </returns>
        public bool Create(RegInfo user, WebAPIGeocode geoCoordinates)
        {
            var hmac = new HMAC256();
            var salt = hmac.GenerateSalt();

            // Returns false if salt was not generated (empty string)
            if (salt.Equals(""))
            {
                return false;
            }

            var original = new HashDTO()
            {
                Original = user.UserCredInfo.Password,
                Salt = salt
            };

            var hashPassword = hmac.Hash(original);

            // Return false if hash was not generated (empty string)
            if (hashPassword.Equals(""))
            {
                return false;
            }

            var questions = new List<string>();
            var answers = new List<string>();

            foreach (SecurityQuestion QandA in user.SecurityQandAs)
            {
                questions.Add(QandA.Question);
                answers.Add(QandA.Answer);
            }

            // Maps data to the dto for the gateway
            var gatewayDTO = new RegGatewayDTO()
            {
                UserName = user.UserCredInfo.Username,
                Password = hashPassword,
                Type = user.UserType,
                Address = user.UserLocation.Street,
                City = user.UserLocation.City,
                State = user.UserLocation.State,
                Zipcode = user.UserLocation.ZipCode,
                Longitude = geoCoordinates.Longitude,
                Latitude = geoCoordinates.Latitude,
                UserClaims = SetDefaultClaims.GetDefaultClaims(),
                Salt = salt,
                Questions = questions,
                Answers = answers
            };

            var gateway = new RegistrationGateway();

            return gateway.Create(gatewayDTO);
        }

    }
}