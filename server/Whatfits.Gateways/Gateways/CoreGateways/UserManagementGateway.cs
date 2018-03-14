using System;
using System.Linq;
using System.Data;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{
    /// <summary>
    /// This gateway provides methods to Create,Update,Disable, and
    /// Delete users on the system.
    /// </summary>
    public class UserManagementGateway
    {
        private UserManagementContext db = new UserManagementContext();

        public void CreateUser(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Createing new Credential
                    Credential credential = new Credential
                    {
                        UserName = obj.UserName,
                        Password = obj.Password,
                        IsFullyRegistered = obj.IsFullyRegistered,
                        IsBanned = obj.IsBanned
                    };
                    db.Credentials.Add(credential);
                    Save();
                    int newUserID = (from u in db.Credentials
                                     where u.UserName == obj.UserName
                                     select u.UserID).FirstOrDefault();
                    // Creating new User
                    User user = new User
                    {
                        UserID = newUserID,
                        FirstName = obj.FirstName,
                        LastName = obj.LastName,
                        Email = obj.Email,
                        Gender = obj.Gender,
                        Description = obj.Description,
                        ProfilePicture = obj.ProfilePicture,
                        SkillLevel = obj.SkillLevel
                    };
                    db.Users.Add(user);
                    Save();
                    // Creating new Salt
                    Salt salt = new Salt
                    {
                        UserID = newUserID,
                        SaltValue = obj.Salt
                    };
                    db.Salts.Add(salt);
                    Save();

                    // Creating location for User
                    Location location = new Location
                    {
                        UserID = newUserID,
                        Address = obj.Address,
                        City = obj.City,
                        State = obj.State,
                        Zipcode = obj.Zipcode,
                    };
                    // Saving Data for new user
                    db.Locations.Add(location);
                    Save();

                    // Add UserClaims
                    for (int i = 0; i < obj.ClaimIDs.Count; i++)
                    {
                        UserClaims temp = new UserClaims { UserID = newUserID, ClaimID = obj.ClaimIDs[i] };
                        db.UserClaims.Add(temp);
                        Save();
                    }
                    // Add Security QandAs
                    for (int i = 0; i < obj.QuestionIDs.Count; i++)
                    {
                        SecurityQandA temp = new SecurityQandA { UserID = newUserID, SecurityQuestionID = obj.QuestionIDs[i], Answer = obj.Answers[i] };
                        db.SecurityQandA.Add(temp);
                        Save();
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

        public Boolean DisableUser(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                // Find User based off UserName
                var foundUser = (from u in db.Credentials
                                 where u.UserName == obj.UserName
                                 select u).FirstOrDefault();
                // Was user found?
                if (foundUser != null)
                {
                    try
                    {
                        // Edit Value for User
                        foundUser.IsBanned = true;
                        // Saves changes
                        Save();
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

        public Boolean EnableUser(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundUser = (from u in db.Credentials
                                 where u.UserName == obj.UserName
                                 select u).FirstOrDefault();
                if (foundUser != null)
                {
                    try
                    {
                        foundUser.IsBanned = false;
                        Save();
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

        public void DeleteUser(UserManagementDTO obj)
        {
            // Not Implementing according to Business Requirements Document
        }

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
                        Save();
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
                        Save();
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
                        Save();
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
        public Boolean EditLocation(UserManagementDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                var foundCredentials = (from u in db.Credentials
                                        where u.UserName == obj.UserName
                                        select u).FirstOrDefault();
                if (foundCredentials != null)
                {
                    var foundlocation = (from location in db.Locations
                                         where location.UserID == foundCredentials.UserID
                                         select location).FirstOrDefault();
                    try
                    {
                        foundlocation.Address = obj.Address;
                        foundlocation.City = obj.City;
                        foundlocation.State = obj.State;
                        foundlocation.Zipcode = obj.Zipcode;
                        foundlocation.Address = obj.Address;
                        Save();
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
                        Save();
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
                        Save();
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
                        Save();
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
                        Save();
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
        private void Save()
        {
            // Saves any changes in Database
            db.SaveChanges();
        }
    }

}
