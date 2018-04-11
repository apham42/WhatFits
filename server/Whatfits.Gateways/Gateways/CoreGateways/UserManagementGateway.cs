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
        /// Registers a full user
        /// </summary>
        /// <param name="obj">
        /// 
        /// </param>
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
        /// <param name="obj">
        /// Address(String),City(String),State(String),Zipcode(String),Latitude(String),
        /// Longitude(String),FirstName(String), LastName(String), Email(String), Gender(String),
        /// Description(String), ProfilePicture(String), SkillLevel(String), Type(String)
        /// </param>
        /// <returns>
        /// True - If successfully inserted into models
        /// False - An error occured inserting into models
        /// </returns>
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
                    db.UserProfiles.Add(user);
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
                    /*
                    //db.SaveChanges();
                    // Add Security QandAs
                    foreach (var account in obj.Answers)
                    {
                        SecurityAccount temp = new SecurityAccount { UserID = newUserID, SecurityQuestionID = account.Key, Answer = account.Value };
                        db.SecurityAccounts.Add(temp);

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
        /// Disables a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String)
        /// </param>
        /// <returns>
        /// True - Successfully disable a user
        /// False - Disabling user was unsuccessful
        /// </returns>
        public ResponseDTO<Boolean> DisableUser(UserManagementDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            var foundUser = (from user in db.Credentials
                             join profile in db.UserProfiles
                                on user.UserID equals profile.UserID
                             where user.UserName == obj.UserName
                             select profile).FirstOrDefault();
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
        /// Enables a user
        /// </summary>
        /// <param name="obj">
        /// UserName(String)
        /// </param>
        /// <returns>
        /// True - Successfully enable a user
        /// False - Ennabling user was unsuccessful
        /// </returns>
        public ResponseDTO<Boolean> EnableUser(UserManagementDTO obj)
        {
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();

            var foundUser = (from user in db.Credentials
                             join profile in db.UserProfiles
                                on user.UserID equals profile.UserID
                             where user.UserName == obj.UserName
                             select profile).FirstOrDefault();
            // Was user found?
            if (foundUser == null)
            {
                // Sending error in responseDTO
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
            var foundUserName = (from user in db.Credentials
                                 where user.UserName == obj.UserName
                                 select user.UserName);
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
            var foundCredentials = (from user in db.Credentials
                                    where user.UserName == obj.UserName
                                    select user).FirstOrDefault();
            if (foundCredentials == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.UserProfiles
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
            var foundCredentials = (from user in db.Credentials
                                    where user.UserName == obj.UserName
                                    select user).FirstOrDefault();
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundCredentials == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.UserProfiles
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

            var foundCredentials = (from user in db.Credentials
                                    where user.UserName == obj.UserName
                                    select user).FirstOrDefault();
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
                             join y in db.UserProfiles
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
            if (foundCredentials == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.UserProfiles
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
            if (foundCredentials == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.UserProfiles
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
            if (foundCredentials == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.UserProfiles
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
                        response.Messages = new List<string> { "An error occured while editing Profile Picture." };
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
            var foundCredentials = (from user in db.Credentials
                                    where user.UserName == obj.UserName
                                    select user).FirstOrDefault();
            // Creating Response DTO
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            if (foundCredentials == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                var foundUser = (from user in db.UserProfiles
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
                        response.Messages = new List<string> { "An error occured while editing description." };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Deletes every entry of a user throughout the database.
        /// </summary>
        /// <param name="obj">
        /// UserName(String)
        /// </param>
        /// <returns>
        /// True - Deletion of user was successful
        /// False - Deletion was not successful
        /// </returns>
        public ResponseDTO<Boolean> DeleteUser(UserManagementDTO obj)
        {
            // Creating Response DTO
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();
            // Find the user to be deleted
            var foundCredentials = (from credentials in db.Credentials
                                    where credentials.UserName == obj.UserName
                                    select credentials).FirstOrDefault();
            // Does user exists?
            if (foundCredentials == null)
            {
                // Return responseDTO with error
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User not found." };
                return response;
            }
            else
            {
                // Start deleting user's data
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Deleting UserClaims
                        var foundUserClaims = (from userClaims in db.UserClaims
                                               where userClaims.UserID == foundCredentials.UserID
                                               select userClaims);
                        // Deletes each UserClaim from user
                        foreach (var userClaim in foundUserClaims)
                        {
                            db.UserClaims.Remove(userClaim);
                        }
                        //db.SaveChanges();
                        // Deleting Salt
                        var foundSalt = (from salts in db.Salts
                                         where salts.UserID == foundCredentials.UserID
                                         select salts).First();
                        db.Salts.Remove(foundSalt);
                        // Deleting Security Answers
                        var foundAnswers = (from answers in db.SecurityAccounts
                                            where answers.UserID == foundCredentials.UserID
                                            select answers);
                        foreach (var answer in foundAnswers)
                        {
                            db.SecurityAccounts.Remove(answer);
                        }
                        // Delete Location
                        // NOTE: I don't think we should delete locations because others might share
                        // the same location with others. -ROB

                        // Delete UserProfile
                        var foundProfile = (from profiles in db.UserProfiles
                                            where profiles.UserID == foundCredentials.UserID
                                            select profiles).First();
                        db.UserProfiles.Remove(foundProfile);
                        // Delete Credential Table
                        db.Credentials.Remove(foundCredentials);
                        db.SaveChanges();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch
                    {
                        // An error occured while deleting, sending responseDTO with error
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Messages = new List<string> { "An error occured while deleting user." };
                        return response;
                    }
                }
            }  
        }
    }
}
