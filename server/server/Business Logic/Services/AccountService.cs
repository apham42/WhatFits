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
    public class AccountService: ICreation<RegGatewayDTO>
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
            
            var gatewayDTO = CreateGatewayDTO(creds, validator.ValidatedLocation);

            // Save user into the database and returns the status
            if (Create(gatewayDTO))
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
        /// Creates dto based on validated information
        /// </summary>
        /// <param name="user"> Validated registeration information </param>
        /// <param name="geoCoordinates"> Validated Geocoordinates based on the location of registration information </param>
        /// <returns> The gateway DTO needed to create the user in the database </returns>
        public RegGatewayDTO CreateGatewayDTO(RegInfo user, WebAPIGeocode geoCoordinates)
        {
            var hmac = new HMAC256();
            var salt = hmac.GenerateSalt();

            // Returns null if salt was not generated (empty string)
            if (salt.Equals(""))
            {
                return null;
            }

            var hashDTO = new HashDTO()
            {
                Original = user.UserCredInfo.Password + salt
            };

            var hashPassword = hmac.Hash(hashDTO);

            // Return null if hash was not generated (empty string)
            if (hashPassword.Equals(""))
            {
                return null;
            }

            var questions = new List<string>();
            var answers = new List<string>();

            foreach (SecurityQuestion QandA in user.SecurityQandAs)
            {
                questions.Add(QandA.Question);

                // hashes the answer to the security question
                var hmacDTO = new HashDTO()
                {
                    Original = QandA.Answer
                };
                var hashAnswer = hmac.Hash(hmacDTO);

                // returns null if hash was not generated
                if (hashAnswer.Equals(""))
                {
                    return null;
                }

                answers.Add(hashAnswer);
            }

            // Maps data to the dto for the gateway
            var mappedDTO = new RegGatewayDTO()
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

            return mappedDTO;
        }

        /// <summary>
        /// Creates the user into the database
        /// </summary>
        /// <param name="gatewayDTO"> contains the info to create a user </param>
        /// <returns>status of the creation</returns>
        public bool Create(RegGatewayDTO gatewayDTO)
        {
            if (gatewayDTO == null)
            {
                return false;
            }

            var gateway = new RegistrationGateway();

            return gateway.Create(gatewayDTO);
        }

    }
}