using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
// Used For Models
using Whatfits.Models.Models;
// Used for Context File Registration
using Whatfits.Models.Context.Core;
// Used for Data Transfer Objects
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.GatewayInterfaces;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{ 
    public class UserAccessControlGateway
    {
        private RegistrationContext db = new RegistrationContext();
        public void AddToClaimsList(UserAccessDTO obj)
        {
            // Create new Claim object with the information from the DTO
            Claim newClaim = new Claim()
            {
                ClaimValue = obj.ClaimValue,
                ClaimType = obj.ClaimType
            };
            // Add claim to database
            db.Claims.Add(newClaim);
            // Saves changes made
            Save();
        }

        public void RemoveFromClaimsList(UserAccessDTO obj)
        {
            // Creates a temporary claim with the id
            var removeClaim = new Claim { ClaimID = obj.ClaimID };
            // Attaches claim to be removed
            db.Claims.Attach(removeClaim);
            // Removes claim
            db.Claims.Remove(removeClaim);
            // Saves changes
            Save();
        }

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

        public List<Claim> GetReferenceClaims()
        {
            IEnumerable<int> temp = Enumerable.Empty<int>();
            var claims = db.Claims.ToList();

            return claims;
        }
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
        private void Save()
        {
            db.SaveChanges();
        }
    }
}
