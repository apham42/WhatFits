using System;
using System.Linq;
using System.Data;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Security.Claims;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{
    /// <summary>
    /// This gateway provides methods to register a user.
    /// </summary>
    public class RegistrationGateway
    {
        private AccountContext db = new AccountContext();
        /// <summary>
        /// Creates a user based on registration information
        /// </summary>
        /// <param name="dto"> Registeration Information </param>

        public bool Create(RegGatewayDTO dto)
        {
            // Saving Location and finding ID
            bool doesLocationExist = (from x in db.Locations
                                      where x.Address == dto.Address &&
                                      x.Latitude == dto.Latitude && x.Longitude == x.Longitude
                                      select x.Address).Any();

            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                { 
                    // if location doesnt exist, create a new location data
                    if (!doesLocationExist)
                    {
                        Location location = new Location()
                        {
                            Address = dto.Address,
                            City = dto.City,
                            State = dto.State,
                            Zipcode = dto.Zipcode,
                            Latitude = dto.Latitude,
                            Longitude = dto.Longitude
                        };
                        db.Locations.Add(location);
                        db.SaveChanges();
                    }

                    int locationID = (from x in db.Locations
                                      where x.Address == dto.Address &&
                                      x.Latitude == dto.Latitude && x.Longitude == x.Longitude
                                      select x.LocationID).FirstOrDefault();

                    // Saving Credentials
                    Credential credential = new Credential()
                    {
                        UserName = dto.UserName,
                        Password = dto.Password,
                    };
                    db.Credentials.Add(credential);
                    db.SaveChanges();

                    int userID = (from u in db.Credentials
                                  where u.UserName == dto.UserName
                                  select u.UserID).FirstOrDefault();

                    // Saving Salt
                    Salt userSalt = new Salt()
                    {
                        UserID = userID,
                        SaltValue = dto.Salt
                    };
                    db.Salts.Add(userSalt);
                    db.SaveChanges();

                    int answerCounter = 0;
                    // Saving Security Question and user's Answers
                    foreach (string question in dto.Questions)
                    {

                        int secQuesID = (from x in db.SecurityQuestions
                                         where x.Question == question
                                         select x.SecurityQuestionID).FirstOrDefault();
                        SecurityAccount userQandA = new SecurityAccount()
                        {
                            UserID = userID,
                            SecurityQuestionID = secQuesID,
                            Answer = dto.Answers[answerCounter]
                        };
                        db.SecurityAccounts.Add(userQandA);
                        db.SaveChanges();
                        answerCounter++;
                    }

                    // Saving User info
                    UserProfile userInfo = new UserProfile()
                    {
                        UserID = userID,
                        LocationID = locationID,
                        Type = dto.Type
                    };
                    db.UserProfiles.Add(userInfo);
                    db.SaveChanges();

                    // Adding each claims
                    foreach (Claim userclaim in dto.UserClaims)
                    {
                        UserClaims claim = new UserClaims()
                        {
                            UserID = userID,
                            ClaimValue = userclaim.Value,
                            ClaimType = userclaim.Type
                        };
                        db.UserClaims.Add(claim);
                        db.SaveChanges();
                    }

                    dbTransaction.Commit();
                    return true;
                }
                catch (SqlException)
                {
                    dbTransaction.Rollback();
                    return false;
                }
                catch (DataException)
                {
                    dbTransaction.Rollback();
                    return false;
                }
                catch (InvalidOperationException)
                {
                    dbTransaction.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// This function checks if the incoming username exists in the database
        /// </summary>
        /// <param name="dto"> Username dto from Business layer to Data Access Layer </param>

        public UsernameResponseDTO CheckUserName(UsernameDTO dto)
        {
            UsernameResponseDTO response = new UsernameResponseDTO();
            List<string> messages = new List<string>();
            try
            {
                string username = (from x in db.Credentials
                                   where x.UserName == dto.Username
                                   select x.UserName).FirstOrDefault();
                if (dto.Username == username)
                {
                    response.isSuccessful = false;
                    messages.Add("Username already exists. Please try again");
                    response.Messages = messages;
                }
                else
                {
                    response.isSuccessful = true;
                }
            }
            catch (SqlException)
            {
                response.isSuccessful = false;
                messages.Add("Your request could not be made. Please try again.");
                response.Messages = messages;
            }
            catch (DataException)
            {
                response.isSuccessful = false;
                messages.Add("Your request could not be made. Please try again.");
                response.Messages = messages;
            }
            return response;
        }

        /// <summary>
        /// Gets all the security questions in the database
        /// </summary>
        /// <returns> list of security questions in the database</returns>
        public SecurityQuestionResponseDTO GetQuestions()
        {
            SecurityQuestionResponseDTO response = new SecurityQuestionResponseDTO();
            List<string> messages = new List<string>();
            try
            {
                List<string> questions = (from x in db.SecurityQuestions
                                          select x.Question).ToList<string>();
                if (!questions.Any())
                {
                    response.isSuccessful = false;
                    messages.Add("Your request could not be made. Please try again.");
                    response.Messages = messages;
                }
                else
                {
                    response.isSuccessful = true;
                    response.Questions = questions;
                }
            }
            catch (SqlException)
            {
                response.isSuccessful = false;
                messages.Add("Your request could not be made. Please try again.");
                response.Messages = messages;
            }
            catch (DataException)
            {
                response.isSuccessful = false;
                messages.Add("Your request could not be made. Please try again.");
                response.Messages = messages;
            }
            return response;

        }
    }
}