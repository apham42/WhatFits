using System;
using System.Linq;
using System.Data;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using System.Collections.Generic;

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
        public void RegisterFullUser(RegistrationDTO obj)
        {
            RegisterPartialUser(obj);
            ContinueRegistration(obj);
        }
        /// <summary>
        /// Used for Users who registered on the homepage or from SSO
        /// </summary>
        public void RegisterPartialUser(RegistrationDTO obj)
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
        public void ContinueRegistration(RegistrationDTO obj)
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
                    User user = new User
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
                    db.SaveChanges();;


                    
                    // Add UserClaims
                    for (int i = 0; i < obj.UserClaims.Count; i++)
                    {
                        UserClaims temp = new UserClaims { UserID = newUserID, ClaimType= obj.UserClaims[i].Value, ClaimValue=obj.UserClaims[i].Value };
                        db.UserClaims.Add(temp);
                        db.SaveChanges();;
                    }
                    // Add Security QandAs
                    for (int i = 0; i < obj.QuestionIDs.Count; i++)
                    {
                        SecurityQandA temp = new SecurityQandA { UserID = newUserID, SecurityQuestionID = obj.QuestionIDs[i], Answer = obj.Answers[i] };
                        db.SecurityQandA.Add(temp);
                        db.SaveChanges();;
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
        /// This function checks if the incoming username exists in the database
        /// </summary>
        /// <returns>
        ///     True : When UserName exists in database
        ///     False: When UserName does NOT exists in database
        /// </returns>
        public Boolean DoesUserNameExists(RegistrationDTO obj)
        {
            var foundUserName = (from credentials in db.Credentials
                                 where credentials.UserName == obj.UserName
                                 select credentials.UserName);
            if (foundUserName == null)
                return false;
            else
                return true;
        }
        public List<string> GetUserList()
        {
            List<string> usrlist = (from x in db.Users join y in db.Credentials
                                    on x.UserID equals y.UserID
                                    select y.UserName).ToList<string>();
            return usrlist;
        }
    }
}
