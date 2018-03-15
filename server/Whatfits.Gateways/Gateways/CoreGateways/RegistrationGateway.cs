using System;
using System.Linq;
using System.Data;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{
    /// <summary>
    /// This gateway provides methods to register a user.
    /// </summary>
    public class RegistrationGateway
    {
        private RegistrationContext db = new RegistrationContext();

        public void RegisterUser(RegistrationDTO obj)
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
        public Boolean DoesUserNameExists(RegistrationDTO obj)
        {
            // Find username inside database based on obj.UserName
            var foundUserName = (from credentials in db.Credentials
                                 where credentials.UserName == obj.UserName
                                 select credentials.UserName);
            // Checking if it found a user
            if (foundUserName == null)
                // returns false if passed username does not exists in database
                return false;
            else
                // returns true if passed username does exists in database
                return true;
        }

        private void Save()
        {
            // Saves any changes to the database
            db.SaveChanges();
        }
    }
}
