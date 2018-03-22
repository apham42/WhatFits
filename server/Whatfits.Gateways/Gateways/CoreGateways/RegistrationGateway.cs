using System;
using System.Linq;
using System.Data;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{
    /// <summary>
    /// This gateway provides methods to register a user.
    /// </summary>
    public class RegistrationGateway
    {
        private RegistrationContext db = new RegistrationContext();
        /// <summary>
        /// Used for Users who registered on the Registration page in app.
        /// </summary>
        public bool Create(RegGatewayDTO dto)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    bool doesLocationExist = (from x in db.Locations
                                      where x.Address == dto.Address &&
                                      x.Latitude == dto.Latitude && x.Longitude == x.Longitude
                                      select x.Address).Any();
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

                    Salt userSalt = new Salt()
                    {
                        UserID = userID,
                        SaltValue = dto.Salt
                    };
                    db.Salts.Add(userSalt);
                    db.SaveChanges();

                    int answerCounter = 0;
                    foreach(string question in dto.Questions)
                    {
                        if (answerCounter < 3)
                        {
                            int secQuesID = (from x in db.SecurityQuestions
                                             where x.Question == question
                                             select x.SecurityQuestionID).FirstOrDefault();
                            SecurityQandA userQandA = new SecurityQandA()
                            {
                                UserID = userID,
                                SecurityQuestionID = secQuesID,
                                Answer = dto.Answers[answerCounter]
                            };
                            db.SecurityQandA.Add(userQandA);
                            db.SaveChanges();
                            answerCounter ++;
                        }
                    }

                    // TODO: Save LocationID and UserID on User table for user management

                    // TODO: Add default claims.
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
            }
        }
        
        /// <summary>
        /// This function checks if the incoming username exists in the database
        /// </summary>
        public UsernameResponseDTO CheckUserName(UsernameDTO dto)
        {
            UsernameResponseDTO response = new UsernameResponseDTO();
            List<string> messages= new List<string>();
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
            catch (System.Data.SqlClient.SqlException)
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

        public SecurityQuestionResponseDTO GetQuestions()
        {
            SecurityQuestionResponseDTO response = new SecurityQuestionResponseDTO();
            List<string> messages = new List<string>();
            try
            {
                List<string> questions = (from x in db.SecurityQuestions
                                              select x.Question).ToList<string>();
                if(!questions.Any())
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
