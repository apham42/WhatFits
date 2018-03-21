using System;
using System.Linq;
using System.Data;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DTOs.CoreDTOs;

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
        public void RegisterFullUser(UserManagementDTO obj)
        {
            RegisterPartialUser(obj);
            ContinueRegistration(obj);
        }
        /// <summary>
        /// Used for Users who registered on the homepage or from SSO
        /// </summary>
        public void RegisterPartialUser(UserManagementDTO obj)
        {
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
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                }
            }
        }
        /// <summary>
        /// Continues the registration process for users who partially registered from 
        /// the homepage or SSO when they login for first time.
        /// </summary>
        public void ContinueRegistration(UserManagementDTO obj)
        {
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

                    int newLocation = (from u in db.Locations
                                       where u.Address == obj.Address && u.City == obj.City && u.State == obj.State && u.Zipcode == obj.Zipcode
                                       select u.LocationID).FirstOrDefault();
                    // Creating new User
                    UserProfile user = new UserProfile
                    {
                        UserID = newUserID,
                        LocationID = newLocation,
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
                        SaltValue = obj.Salt
                    };
                    db.Salts.Add(salt);
                    db.SaveChanges();
                    // Add UserClaims
                    for (int i = 0; i < obj.UserClaims.Count; i++)
                    {
                        UserClaims temp = new UserClaims { UserID = newUserID, ClaimType = obj.UserClaims[i].Value, ClaimValue = obj.UserClaims[i].Value };
                        db.UserClaims.Add(temp);
                        db.SaveChanges(); ;
                    }
                    // Add Security QandAs
                    for (int i = 0; i < obj.QuestionIDs.Count; i++)
                    {
                        SecurityQandA temp = new SecurityQandA { UserID = newUserID, SecurityQuestionID = obj.QuestionIDs[i], Answer = obj.Answers[i] };
                        db.SecurityQandA.Add(temp);
                        db.SaveChanges(); ;
                    }
                    // Commits changes in database
                    dbTransaction.Commit();
                }
                catch (Exception)
                {
                    // Rolls back any changed tables
                    dbTransaction.Rollback();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean DisableUser(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                // Find User based off UserName
                var foundUser = (from u in db.Credentials join y in db.Users
                                 on u.UserID equals y.UserID
                                 where u.UserName == obj.UserName
                                 select y).FirstOrDefault();


                // Was user found?
                if (foundUser != null)
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
                        return true;
                    }
                    catch (Exception)
                    {
                        // undo any changes if errors
                        dbTransaction.Rollback();
                        // Inform other layer about failure
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EnableUser(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundUser = (from u in db.Credentials join y in db.Users
                                 on u.UserID equals y.UserID
                                 where u.UserName == obj.UserName
                                 select y).FirstOrDefault();
                if (foundUser != null)
                {
                    try
                    {
                        foundUser.Type = "General";
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void DeleteUser(UserManagementDTO obj)
        {
            // Not Implementing according to Business Requirements Document
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean DoesUserNameExists(UserManagementDTO obj)
        {
            // Searches through database if username matches with any usernames already in db
            string foundUserName = (from credentials in db.Credentials
                                    where credentials.UserName == obj.UserName
                                    select credentials.UserName).FirstOrDefault();
            // Sees if there is a username found
            if (foundUserName == obj.UserName)
                // Returns false if username does not exists in database
                return true;
            else
                // Return true if username does exists in database
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EditFirstName(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundCredentials = (from u in db.Credentials
                                        where u.UserName == obj.UserName
                                        select u).FirstOrDefault();
                if (foundCredentials != null)
                {
                    var foundUser = (from user in db.Users
                                     where user.UserID == foundCredentials.UserID
                                     select user).FirstOrDefault();
                    try
                    {
                        foundUser.FirstName = obj.FirstName;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EditLastname(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundCredentials = (from u in db.Credentials
                                        where u.UserName == obj.UserName
                                        select u).FirstOrDefault();
                if (foundCredentials != null)
                {
                    var foundUser = (from user in db.Users
                                     where user.UserID == foundCredentials.UserID
                                     select user).FirstOrDefault();
                    try
                    {
                        foundUser.LastName = obj.LastName;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EditPassword(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundCredentials = (from u in db.Credentials
                                        where u.UserName == obj.UserName
                                        select u).FirstOrDefault();
                if (foundCredentials != null)
                {
                    try
                    {
                        foundCredentials.Password = obj.Password;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EditLocation(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundUser = (from u in db.Credentials join y in db.Users
                                 on u.UserID equals y.UserID
                                        where u.UserName == obj.UserName
                                        select y).FirstOrDefault();
                if (foundUser != null)
                {
                    var foundlocation = (from location in db.Locations
                                         where location.LocationID == foundUser.LocationID
                                         select location).FirstOrDefault();
                    try
                    {
                        foundlocation.Address = obj.Address;
                        foundlocation.City = obj.City;
                        foundlocation.State = obj.State;
                        foundlocation.Zipcode = obj.Zipcode;
                        foundlocation.Address = obj.Address;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EditSkillLevel(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundCredentials = (from u in db.Credentials
                                        where u.UserName == obj.UserName
                                        select u).FirstOrDefault();
                if (foundCredentials != null)
                {
                    var foundUser = (from user in db.Users
                                     where user.UserID == foundCredentials.UserID
                                     select user).FirstOrDefault();
                    try
                    {
                        foundUser.SkillLevel = obj.SkillLevel;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EditGender(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundCredentials = (from u in db.Credentials
                                        where u.UserName == obj.UserName
                                        select u).FirstOrDefault();
                if (foundCredentials != null)
                {
                    var foundUser = (from user in db.Users
                                     where user.UserID == foundCredentials.UserID
                                     select user).FirstOrDefault();
                    try
                    {
                        foundUser.Gender = obj.Gender;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EditProfilePicture(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundCredentials = (from u in db.Credentials
                                        where u.UserName == obj.UserName
                                        select u).FirstOrDefault();
                if (foundCredentials != null)
                {
                    var foundUser = (from user in db.Users
                                     where user.UserID == foundCredentials.UserID
                                     select user).FirstOrDefault();
                    try
                    {
                        foundUser.ProfilePicture = obj.ProfilePicture;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean EditDescription(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundCredentials = (from u in db.Credentials
                                        where u.UserName == obj.UserName
                                        select u).FirstOrDefault();
                if (foundCredentials != null)
                {
                    var foundUser = (from user in db.Users
                                     where user.UserID == foundCredentials.UserID
                                     select user).FirstOrDefault();
                    try
                    {
                        foundUser.Description = obj.Description;
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
    }

}
