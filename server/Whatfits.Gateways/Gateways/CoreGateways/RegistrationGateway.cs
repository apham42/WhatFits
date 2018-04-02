using System;
using System.Linq;
using System.Data;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;
using System.Collections.Generic;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{
    /// <summary>
    /// This gateway provides methods to register a user.
    /// </summary>
    public class RegistrationGateway
    {
        private AccountContext db = new AccountContext();
        /// <summary>
        /// Used for Users who registered on the Registration page in app.
        /// </summary>
        public ResponseDTO<Boolean> RegisterFullUser(RegistrationDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            RegisterPartialUser(obj);
            ContinueRegistration(obj);
            return response;
        }
        /// <summary>
        /// Used for Users who registered on the homepage or from SSO
        /// </summary>
        public ResponseDTO<Boolean> RegisterPartialUser(RegistrationDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    Credential newCredential = new Credential()
                    {
                        UserName = obj.UserName,
                        Password = obj.Password,
                    };
                    db.Credentials.Add(newCredential);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    response.IsSuccessful = true;
                    return response;
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                    response.IsSuccessful = false;
                    return response;
                }
            }
        }
        /// <summary>
        /// Continues the registration process for users who partially registered from 
        /// the homepage or SSO when they login for first time.
        /// </summary>
        public ResponseDTO<Boolean> ContinueRegistration(RegistrationDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    int newUserID = (from u in db.Credentials
                                     where u.UserName == obj.UserName
                                     select u.UserID).FirstOrDefault();
                    // Creating Location
                    Location location = new Location
                    {
                        Address = obj.Address,
                        City = obj.City,
                        State = obj.State,
                        Zipcode = obj.Zipcode,
                        Latitude = obj.Latitude,
                        Longitude = obj.Longitude
                    };
                    // Saving Data for new user
                    db.Locations.Add(location);
                    db.SaveChanges();
                    // Getting Location ID for creating User
                    int newLocationID = (from u in db.Locations
                                     where u.Address == obj.Address && u.City == obj.City && u.State == obj.State && u.Zipcode == obj.Zipcode
                                     select u.LocationID).FirstOrDefault();
                    // Creating new User
                    UserProfile user = new UserProfile
                    {
                        UserID = newUserID,
                        LocationID = newLocationID,
                        FirstName = obj.FirstName,
                        LastName = obj.LastName,
                        Email = obj.Email,
                        Gender = obj.Gender,
                        Description = obj.Description,
                        ProfilePicture = obj.ProfilePicture,
                        SkillLevel = obj.SkillLevel,
                        Type = obj.Type
                    };
                    db.UserProfiles.Add(user);
                    db.SaveChanges();

                    // Creating new Salt
                    Salt salt = new Salt
                    {
                        UserID = newUserID,
                        SaltValue = obj.Salt
                    };
                    db.Salts.Add(salt);
                    //db.SaveChanges();
                    foreach(var claims in obj.UserClaims)
                    {
                        UserClaims temp = new UserClaims { UserID = newUserID, ClaimType = claims.Value, ClaimValue = claims.Type };
                        db.UserClaims.Add(temp);
                        
                    }

                    // Add UserClaims
                    /*
                    for (int i = 0; i < obj.UserClaims.Count; i++)
                    {
                        UserClaims temp = new UserClaims { UserID = newUserID, ClaimType= obj.UserClaims[i].Value, ClaimValue=obj.UserClaims[i].Value };
                        db.UserClaims.Add(temp);
                    }
                    */
                    //db.SaveChanges();
                    // Add Security QandAs
                    foreach (var account in obj.Answers)
                    {
                        SecurityAccount temp = new SecurityAccount { UserID = newUserID, SecurityQuestionID = account.Key, Answer = account.Value };
                        db.SecurityAccounts.Add(temp);
                        
                    }
                    //db.SaveChanges();
                    /*
                    for (int i = 0; i < obj.QuestionIDs.Count; i++)
                    {
                        SecurityAccount temp = new SecurityAccount { UserID = newUserID, SecurityQuestionID = obj.QuestionIDs[i], Answer = obj.Answers[i] };
                        db.SecurityQandA.Add(temp);
                        db.SaveChanges();
                    }
                    */
                    // Commits changes in database
                    db.SaveChanges();
                    dbTransaction.Commit();
                    response.IsSuccessful = true;
                    return response;
                }
                catch (Exception)
                {
                    // Rolls back any changed tables
                    dbTransaction.Rollback();
                    response.IsSuccessful = false;
                    return response;
                }
            }
        }
        /// <summary>
        /// This function checks if the incoming username exists in the database
        /// </summary>
        /// <returns>
        ///     True : When UserName exists in database
        ///     False: When UserName does NOT exists in database
        /// </returns>
        public ResponseDTO<Boolean> DoesUserNameExists(RegistrationDTO obj)
        {
            var foundUserName = (from credentials in db.Credentials
                                 where credentials.UserName == obj.UserName
                                 select credentials.UserName);
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();

            if (foundUserName == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User was not found." };
                return response;
            }
            else
            {
                response.IsSuccessful = true;
                return response;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public ResponseDTO<List<string>> GetUserList()
        {
            List<string> userList = (from x in db.UserProfiles
                                     join y in db.Credentials
                                    on x.UserID equals y.UserID
                                    select y.UserName).ToList<string>();
            ResponseDTO<List<string>> response = new ResponseDTO<List<string>>();
            if (userList == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "No users were found."};
            }
            else
            {
                response.Data = userList;
                response.IsSuccessful = true;
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Dictionary<int, string>> GetSecurityQandAs(RegistrationDTO obj)
        {
            var foundUser = (from credential in db.Credentials
                             where credential.UserName == obj.UserName
                             select credential).FirstOrDefault();
            ResponseDTO<Dictionary<int, string>> response = new ResponseDTO<Dictionary<int, string>>();
            if (foundUser == null)
            {
                response.IsSuccessful = false;
                // Returns Response
                return response;
            }
            else
            {
                var foudnQandA = (from answers in db.SecurityAccounts
                                  where answers.UserID == foundUser.UserID
                                  select answers).ToList();
                // Passes the query into a dictionary
                Dictionary<int, String> temp = new Dictionary<int, string>();
                for (int i = 0; i < foudnQandA.Count(); i++)
                {
                    temp.Add(foudnQandA[i].SecurityQuestionID, foudnQandA[i].Answer);
                }
                // Creates the response
                response.Data = temp;
                response.IsSuccessful = true;
                // Returns Response
                return response;
            }
        }
        /// <summary>
        /// Gets list of SecurityQuestions from Database
        /// </summary>
        /// <returns>
        /// Dictionary of Questions and QuestionIDs via LoginDTO
        /// </returns>
        public ResponseDTO<Dictionary<int, string>> GetSecurityQuestions()
        {
            var query = db.SecurityQuestions.ToList();
            ResponseDTO<Dictionary<int, string>> response = new ResponseDTO<Dictionary<int, string>> { };
            if (query == null)
            {
                response.IsSuccessful = false;
            }
            else
            {
                Dictionary<int, String> temp = new Dictionary<int, string>();
                foreach (var question in query)
                {
                    temp.Add(question.SecurityQuestionID, question.Question);
                }
                response.Data = temp;
                response.IsSuccessful = true;
            }
            return response;
        }
    }
}
