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
        // Reference Claims
        public void AddtoClaimsList(Claim obj)
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
                    Save();
                    dbTransaction.Commit();
                    
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                }
            }
        }

        public void RemoveFromClaimsList(UserAccessDTO obj)
        {
            // Creates a temporary claim with the id
            var removeClaim = new ClaimItem { ClaimID = obj.ClaimID };
            // Attaches claim to be removed
            db.Claims.Attach(removeClaim);
            // Removes claim
            db.Claims.Remove(removeClaim);
            // Saves changes
            Save();
        }
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
        //---------------------------------------------------------------------------------
        //  UserClaims
        //---------------------------------------------------------------------------------
        // TODO: Map Claim Type and Value to ClaimID
        public void AddUserClaims(UserAccessDTO obj)
        {
            // Find user based off Username
            var foundUser = db.Credentials.Find(obj.UserName);
            // Create new userclaim with userID and ClaimID
            UserClaims newUserClaim = new UserClaims()
            {
                ClaimID = obj.ClaimID,
                UserID = foundUser.UserID
            };
            // Add UserClaim to database
            db.UserClaims.Add(newUserClaim);
            Save();
        }
        
        public void RemoveUserClaims(UserAccessDTO obj)
        {
            // Find UserId by Username
            var foundUser = db.Credentials.Find(obj.UserName);
            // Create object to be removed from database
            UserClaims removeUserClaim = new UserClaims()
            {
                ClaimID = obj.ClaimID,
                UserID = foundUser.UserID
            };
            // Attaches object to be removed
            db.UserClaims.Attach(removeUserClaim);
            // Removes object from database
            db.UserClaims.Remove(removeUserClaim);
            // Saves changes
            Save();
        }
        // TODO: TEST
        
        /*
        public List<int> GetUserClaims(UserAccessDTO obj)
        {
            // Find UserId by Username
            var foundUser = db.Credentials.Find(obj.UserName);
            // Find all records of that userID and return all claimIds
            // as a list.
            var ClaimsList = (from p in db.UserClaims
                              where p.UserID == foundUser.UserID
                              select p.ClaimID).ToList();
            // Returns list of claims
            return ClaimsList;
        }
        */
        //*
        // TODO: Complete this -Rob
        public List<Claim> GetUserClaims(UserAccessDTO obj)
        {
            List<Claim> temp = new List<Claim>();
            return temp;
        }
        //*/
        private void Save()
        {
            db.SaveChanges();
        }
    }
}
