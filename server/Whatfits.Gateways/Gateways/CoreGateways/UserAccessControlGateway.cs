using System.Collections.Generic;
using System.Linq;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using System.Security.Claims;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using System;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{ 
    /// <summary>
    /// Provides the following functions for UserAcccess Control
    /// - Add new Claim to ClaimsList
    /// - Remove Claim from ClaimsList
    /// - Get ClaimsList
    /// - Add new UserClaim to User
    /// - Remove UserClaim from User
    /// - Get UserClaims
    /// </summary>
    public class UserAccessControlGateway
    {
        private RegistrationContext db = new RegistrationContext();
        /// <summary>
        /// Adds a new claim to the ClaimsList which is used as a reference
        /// to all claims on the system.
        /// </summary>
        /// <param name="obj">
        /// - ClaimValue
        /// - ClaimType
        /// </param>
        /// <returns>
        /// - TRUE: Succeeds to add Claim
        /// - FALSE: Fails to add Claim
        /// </returns>
        public Boolean AddtoClaimsList(Claim obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    ClaimItem newClaim = new ClaimItem()
                    {
                        ClaimValue = obj.Value,
                        ClaimType = obj.Type
                    };
                    db.Claims.Add(newClaim);
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
        }
        /// <summary>
        /// Removes a claim from the ClaimsList
        /// </summary>
        /// <param name="obj">
        /// - ClaimID
        /// </param>
        /// <returns>
        /// - TRUE: Succeeds to remove Claim
        /// - FALSE: Fails to remove Claim
        /// </returns>
        public Boolean RemoveFromClaimsList(UserAccessDTO obj)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    for(int i = 0; i < obj.ClaimID.Count; i++)
                    {
                        // Creates a temporary claim with the id
                        var removeClaim = new ClaimItem { ClaimID = obj.ClaimID[i] };
                        // Attaches claim to be removed
                        db.Claims.Attach(removeClaim);
                        // Removes claim
                        db.Claims.Remove(removeClaim);
                        // Saves changes
                        db.SaveChanges();
                    }
                    dbTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                    return false;
                }
            }
        }
        /// <summary>
        /// Gets the whole ClaimsList as a List of claim objects
        /// </summary>
        /// <returns>
        /// Returns a List of Claim objects
        /// </returns>
        public List<Claim> GetClaimsList()
        {
            var claims = db.Claims.ToList();

            List<Claim> ClaimsList = new List<Claim>();

            for (int i = 0; i < claims.Count; i++)
            {
                ClaimsList.Add(new Claim(claims[i].ClaimType, claims[i].ClaimValue));
            }
            return ClaimsList;
        }

        /// <summary>
        /// Adds a claim to the user
        /// </summary>
        /// <param name="obj">
        /// - UserName
        /// - ClaimID
        /// </param>
        /// <returns>
        /// - TRUE: Succeeds to add UserClaim
        /// - FALSE: Fails to add UserClaim
        /// </returns>
        public Boolean AddUserClaims(UserAccessDTO obj)
        {
            // Find user based off Username
            var foundUser = db.Credentials.Find(obj.UserName);
            if (foundUser != null)
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < obj.ClaimID.Count; i++)
                        {
                            UserClaims newUserClaim = new UserClaims()
                            {
                                ClaimID = obj.ClaimID[i],
                                UserID = foundUser.UserID
                            };
                            db.UserClaims.Add(newUserClaim);
                            db.SaveChanges();
                        }
                        dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
            }
            else
                return false;
        }
        /// <summary>
        /// Removes a Claim from a person
        /// </summary>
        /// <param name="obj">
        /// - UserName
        /// - ClaimID
        /// </param>
        /// <returns>
        /// - TRUE: Succeeds to add Claim
        /// - FALSE: Fails to add Claim
        /// </returns>
        public Boolean RemoveUserClaims(UserAccessDTO obj)
        {
            var foundUser = db.Credentials.Find(obj.UserName);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                if (foundUser!=null)
                {
                    try
                    {
                        for (int i = 0; i < obj.ClaimID.Count; i++)
                        {
                            UserClaims removeUserClaim = new UserClaims()
                            {
                                ClaimID = obj.ClaimID[i],
                                UserID = foundUser.UserID
                            };
                            db.UserClaims.Attach(removeUserClaim);
                            db.UserClaims.Remove(removeUserClaim);
                            db.SaveChanges();
                        }
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
        /// Gets a list of Claims that the user has
        /// </summary>
        /// <param name="obj">
        /// - UserName(string)
        /// </param>
        /// <returns>
        /// - List<Claim>
        /// </returns>
        public List<Claim> GetUserClaims(UserAccessDTO obj)
        {
            List<Claim> temp = new List<Claim>();
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();
            if (foundUser != null)
            {
                // Should return all the userClaims that match UserID
                var foundUserClaims = (from userClaims in db.UserClaims
                                       where userClaims.UserID == foundUser.UserID
                                       select userClaims);
                // TODO Need to map the ClaimIDs to the ClaimList
                return temp;
            }
            else
            {
                return temp;
            }
        }
        /*
        public List<int> GetUserClaims(UserAccessDTO obj)
        {
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();
            // Find all records of that userID and return all claimIds
            // as a list.
            var ClaimsList = (from p in db.UserClaims
                              where p.UserID == foundUser.UserID
                              select p.ClaimID).ToList();
            // Returns list of claims
            return ClaimsList;
        }
        */
    }
}
