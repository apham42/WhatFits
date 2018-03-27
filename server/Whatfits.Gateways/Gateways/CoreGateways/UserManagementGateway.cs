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
    /// This gateway provides methods to Create,Update,Disable, and
    /// Delete users on the system.
    /// </summary>
    public class UserManagementGateway
    {
        private AccountContext db = new AccountContext();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> RegisterFullUser(UserManagementDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            RegisterPartialUser(obj);
            ContinueRegistration(obj);
            return response;
        }
        /// <summary>
        /// Used for Users who registered on the homepage or from SSO
        /// </summary>
        public ResponseDTO<Boolean> RegisterPartialUser(UserManagementDTO obj)
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
                    response.Data = true;
                    return response;
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                    response.IsSuccessful = false;
                    response.Data = false;
                    return response;
                }
            }
        }
        /// <summary>
        /// Continues the registration process for users who partially registered from 
        /// the homepage or SSO when they login for first time.
        /// </summary>
        public ResponseDTO<Boolean> ContinueRegistration(UserManagementDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    int newUserID = (from credential in db.Credentials
                                     where credential.UserName == obj.UserName
                                     select credential.UserID).FirstOrDefault();
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
                    db.Users.Add(user);
                    db.SaveChanges();

                    // Creating new Salt
                    Salt salt = new Salt
                    {
                        UserID = newUserID,
                        SaltValue = obj.SaltValue
                    };
                    db.Salts.Add(salt);
                    //db.SaveChanges();
                    foreach (var claims in obj.UserClaims)
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
                        db.SecurityQandA.Add(temp);

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
                    response.Data = true;
                    return response;
                }
                catch (Exception)
                {
                    // Rolls back any changed tables
                    dbTransaction.Rollback();
                    response.IsSuccessful = false;
                    response.Data = false;
                    return response;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> DisableUser(UserManagementDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            // Find User based off UserName
            // NOTE: Does this even work??? -ROB
            var foundUser = (from u in db.Credentials
                             join y in db.Users
                             on u.UserID equals y.UserID
                             where u.UserName == obj.UserName
                             select y).FirstOrDefault();
            // Was user found?
            if (foundUser == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Edit Value for User
                        foundUser.Type = "Disabled";
                        // Saves changes
                        db.SaveChanges();
                        // Commits if works
                        dbTransaction.Commit();
                        // Inform other layer that it succeeded
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        // undo any changes if errors
                        dbTransaction.Rollback();
                        // Inform other layer about failure
                        response.IsSuccessful = false;
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> EnableUser(UserManagementDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            // Find User based off UserName
            // NOTE: Does this even work??? -ROB
            var foundUser = (from u in db.Credentials
                             join y in db.Users
                                on u.UserID equals y.UserID
                             where u.UserName == obj.UserName
                             select y).FirstOrDefault();
            // Was user found?
            if (foundUser == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Edit Value for User
                        foundUser.Type = "Enable";
                        // Saves changes
                        db.SaveChanges();
                        // Commits if works
                        dbTransaction.Commit();
                        // Inform other layer that it succeeded
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        // undo any changes if errors
                        dbTransaction.Rollback();
                        // Inform other layer about failure
                        response.IsSuccessful = false;
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Checks if the username exists
        /// </summary>
        /// <param name="obj">
        /// UserName(string) via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessfull = true if name exits in database
        /// IsSuccessfull = false if name exits in database
        /// </returns>
        public ResponseDTO<Boolean> DoesUserNameExists(UserManagementDTO obj)
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
        /// Edits the First Name of a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String) via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessful - True if successfully edited
        /// IsSuccessful - False if failed to edited
        /// </returns>
        public ResponseDTO<Boolean> EditFirstName(UserManagementDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            var foundCredentials = (from credentials in db.Credentials
                                    where credentials.UserName == obj.UserName
                                    select credentials).FirstOrDefault();
            if (foundCredentials != null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.Users
                                 where user.UserID == foundCredentials.UserID
                                 select user).FirstOrDefault();
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foundUser.FirstName = obj.FirstName;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Messages = new List<string> { "An error occured while editing First Name" };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Edits the Last Name of a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String) via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessful - True if successfully edited
        /// IsSuccessful - False if failed to edited
        /// </returns>
        public ResponseDTO<Boolean> EditLastname(UserManagementDTO obj)
        {
            var foundCredentials = (from credentials in db.Credentials
                                    where credentials.UserName == obj.UserName
                                    select credentials).FirstOrDefault();
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundCredentials != null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.Users
                                 where user.UserID == foundCredentials.UserID
                                 select user).FirstOrDefault();
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foundUser.LastName = obj.LastName;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Messages = new List<string> { "An error occured while editing Last Name" };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Edits the Password of a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String) and Password(string) via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessful - True if successfully edited
        /// IsSuccessful - False if failed to edited
        /// </returns>
        public ResponseDTO<Boolean> EditPassword(UserManagementDTO obj)
        {

            var foundCredentials = (from u in db.Credentials
                                    where u.UserName == obj.UserName
                                    select u).FirstOrDefault();
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundCredentials == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foundCredentials.Password = obj.Password;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.Messages = new List<string> { "An error occured while editing Password." };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Edits the Location of a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String) and Location data via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessful - True if successfully edited
        /// IsSuccessful - False if failed to edited
        /// </returns>
        public ResponseDTO<Boolean> EditLocation(UserManagementDTO obj)
        {
            var foundUser = (from u in db.Credentials
                             join y in db.Users
       on u.UserID equals y.UserID
                             where u.UserName == obj.UserName
                             select y).FirstOrDefault();
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundUser == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundlocation = (from location in db.Locations
                                     where location.LocationID == foundUser.LocationID
                                     select location).FirstOrDefault();
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foundlocation.Address = obj.Address;
                        foundlocation.City = obj.City;
                        foundlocation.State = obj.State;
                        foundlocation.Zipcode = obj.Zipcode;
                        foundlocation.Address = obj.Address;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.Messages = new List<string> { "An error occured while editing Location." };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Edits the skill level of a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String) via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessful - True if successfully edited
        /// IsSuccessful - False if failed to edited
        /// </returns>
        public ResponseDTO<Boolean> EditSkillLevel(UserManagementDTO obj)
        {
            // Searching by UserName
            var foundCredentials = (from credentials in db.Credentials
                                    where credentials.UserName == obj.UserName
                                    select credentials).FirstOrDefault();
            // Creating Response DTO
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundCredentials != null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.Users
                                 where user.UserID == foundCredentials.UserID
                                 select user).FirstOrDefault();
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foundUser.SkillLevel = obj.SkillLevel;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Messages = new List<string> { "An error occured while editing skill level" };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Edits the gender of a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String) and Gender(String) via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessful - True if successfully edited
        /// IsSuccessful - False if failed to edited
        /// </returns>
        public ResponseDTO<Boolean> EditGender(UserManagementDTO obj)
        {
            // Searching by UserName
            var foundCredentials = (from credentials in db.Credentials
                                    where credentials.UserName == obj.UserName
                                    select credentials).FirstOrDefault();
            // Creating Response DTO
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundCredentials != null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.Users
                                 where user.UserID == foundCredentials.UserID
                                 select user).FirstOrDefault();
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foundUser.Gender = obj.Gender;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Messages = new List<string> { "An error occured while editing gender." };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Edits the Profile picture of a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String) and Profile picture via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessful - True if successfully edited
        /// IsSuccessful - False if failed to edited
        /// </returns>
        public ResponseDTO<Boolean> EditProfilePicture(UserManagementDTO obj)
        {
            // Searching by UserName
            var foundCredentials = (from credentials in db.Credentials
                                    where credentials.UserName == obj.UserName
                                    select credentials).FirstOrDefault();
            // Creating Response DTO
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundCredentials != null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.Users
                                 where user.UserID == foundCredentials.UserID
                                 select user).FirstOrDefault();
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foundUser.ProfilePicture = obj.ProfilePicture;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Messages = new List<string> { "An error occured while editing gender." };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Edits the description of a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String) via UserManagementDTO
        /// </param>
        /// <returns>
        /// IsSuccessful - True if successfully edited
        /// IsSuccessful - False if failed to edited
        /// </returns>
        public ResponseDTO<Boolean> EditDescription(UserManagementDTO obj)
        {
            // Searching by UserName
            var foundCredentials = (from credentials in db.Credentials
                                    where credentials.UserName == obj.UserName
                                    select credentials).FirstOrDefault();
            // Creating Response DTO
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundCredentials != null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.Users
                                 where user.UserID == foundCredentials.UserID
                                 select user).FirstOrDefault();
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foundUser.Description = obj.Description;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Messages = new List<string> { "An error occured while editing gender." };
                        return response;
                    }
                }
            }
        }
    }
}
