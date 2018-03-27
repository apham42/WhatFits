using System.Collections.Generic;
using System.Linq;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using System.Security.Claims;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;
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
        private AccountContext db = new AccountContext();
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
        public ResponseDTO<Boolean> AddUserClaims(UserAccessDTO obj)
        {
            // Find user based off Username
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();
            // Creating Response
            ResponseDTO<Boolean> response = new ResponseDTO<bool>();
            if (foundUser == null)
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
                        response.IsSuccessful = true;
                        response.Data = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Data = false;
                        response.Messages = new List<string> { "Error occured while adding Claims." };
                        return response;
                    }
                }
            }
            else
            {
                response.IsSuccessful = false;
                response.Data = false;
                return response;
            }
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
        public ResponseDTO<Boolean> RemoveUserClaims(UserAccessDTO obj)
        {
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();
            ResponseDTO<Boolean> response = new ResponseDTO<bool>();
            if (foundUser == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User Not Found." };
                return response;
            }
            else
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Finds the User's Claims
                        var foundUserClaims = (from userClaims in db.UserClaims
                                               where userClaims.UserID == foundUser.UserID
                                               select userClaims);
                        // Deletes each UserClaim from user
                        foreach (var userClaim in foundUserClaims)
                        {
                            db.UserClaims.Remove(userClaim);
                        }
                        db.SaveChanges();
                        dbTransaction.Commit();
                        // Returns Response
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        // Failure happened
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Messages = new List<string> { "Error Removing Claims." };
                        return response;
                    }
                }
            }
        }
        /// <summary>
        /// Gets a list of Claims that the user has
        /// </summary>
        /// <param name="obj">
        /// - UserName(string)
        /// </param>
        /// <returns>
        /// - List<Claim> via UserAcccessDTO
        /// </returns>
        public ResponseDTO<List<Claim>> GetUserClaims(UserAccessDTO obj)
        {
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();
            ResponseDTO<List<Claim>> response = new ResponseDTO<List<Claim>>();
            if (foundUser == null)
            {
                response.IsSuccessful = false;
                response.Messages = new List<string> { "User Not Found." };
                return response;
            }
            else
            {
                // Should return all the userClaims that match UserID
                var foundUserClaims = (from userClaims in db.UserClaims
                                       where userClaims.UserID == foundUser.UserID
                                       select userClaims);
                response.Data = QueryToClaims(foundUserClaims);
                response.IsSuccessful = true;
                return response;
            }
        }
        /// <summary>
        /// Converts a query into a list of claims
        /// </summary>
        /// <param name="obj">
        /// IQueryable<UserClaims>
        /// </param>
        /// <returns>
        /// List of Claim objects
        /// </returns>
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
