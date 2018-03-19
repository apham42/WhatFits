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
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();
            if (foundUser != null)
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < obj.UserClaims.Count; i++)
                        {
                            UserClaims newUserClaim = new UserClaims()
                            {
                                ClaimType = obj.UserClaims[i].Type,
                                ClaimValue = obj.UserClaims[i].Value,
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
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                if (foundUser!=null)
                {
                    try
                    {
                        for (int i = 0; i < obj.UserClaims.Count; i++)
                        {
                            UserClaims removeUserClaim = new UserClaims()
                            {
                                ClaimType = obj.UserClaims[i].Type,
                                ClaimValue = obj.UserClaims[i].Value,
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
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();
            if (foundUser != null)
            {
                // Should return all the userClaims that match UserID
                var foundUserClaims = (from userClaims in db.UserClaims
                                       where userClaims.UserID == foundUser.UserID
                                       select userClaims);
                return QueryToClaims(foundUserClaims);
            }
            else
            {
                return null;
            }
        }
        private List<Claim> QueryToClaims(IQueryable<UserClaims> obj)
        {
            List<Claim> temp = new List<Claim>();
            
            foreach (var userClaim in obj )
            {
                temp.Add(new Claim(userClaim.ClaimType,userClaim.ClaimValue));
            }
            return temp;
        }
    }
}
