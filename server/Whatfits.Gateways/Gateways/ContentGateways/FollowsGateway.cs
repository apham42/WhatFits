using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Context.Core;
using Whatfits.Models.Models;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    public class FollowsGateway
    {
        private FollowsContext fdb = new FollowsContext();
        private AccountContext adb = new AccountContext();

        public bool DoesUserNameExists(Credential obj)
        {
            // Find username inside database based on obj.UserName
            var foundUserName = (from credentials in fdb.Crendtials
                                 where credentials.UserName == obj.UserName
                                 select credentials.UserName).FirstOrDefault();
            // Checking if it found a user
            if (foundUserName == null)
                // returns false if passed username does not exists in database
                return false;
            else
                // returns true if passed username does exists in database
                return true;
        }

        public IEnumerable<FollowsDTO> GetFollowers(string userName)
        {
            // get userID based on userName
            var requestedUsername = userName;
            var requiredID = 0;
            var foundCredential = (from u in adb.Credentials
                                   where u.UserName == requestedUsername
                                   select u).FirstOrDefault();
            ResponseDTO<LoginDTO> response = new ResponseDTO<LoginDTO>();
            if (foundCredential != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                response.Data = new LoginDTO
                {
                    UserID = foundCredential.UserID,
                };
                requiredID = foundCredential.UserID;
                response.IsSuccessful = true;
            }

            return (from c in fdb.Crendtials
                    join b in (from d in fdb.Following
                                where d.UserID == requiredID
                                    select new {d.PersonFollowing }) 
                                        on c.UserID equals b.PersonFollowing
                    select new FollowsDTO { PersonFollowing = c.UserID,
                                            UserName = c.UserName }).ToList();
        }

        public bool AddtoFollow(string userName, string follouserName)
        {
            // Get Requested User ID
            var requestedUsername = userName;
            var requiredID = 0;
            var foundCredential = (from u in adb.Credentials
                                   where u.UserName == requestedUsername
                                   select u).FirstOrDefault();
            ResponseDTO<LoginDTO> response = new ResponseDTO<LoginDTO>();
            if (foundCredential != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                response.Data = new LoginDTO
                {
                    UserID = foundCredential.UserID,
                };
                requiredID = foundCredential.UserID;
                response.IsSuccessful = true;
            }
            // Get Want to Follow User ID
            var wantedfolloname = follouserName;
            var wantedfolloID = 0;
            var foundFollo = (from u in adb.Credentials
                                   where u.UserName == wantedfolloname
                                   select u).FirstOrDefault();
            ResponseDTO<LoginDTO> responseFollo = new ResponseDTO<LoginDTO>();
            if (foundFollo != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                responseFollo.Data = new LoginDTO
                {
                    UserID = foundFollo.UserID,
                };
                wantedfolloID = foundFollo.UserID;
                responseFollo.IsSuccessful = true;
            }
            
            // Add wanted follow userid into requested user following list
            using (var dbTransaction = fdb.Database.BeginTransaction())
            {
                try
                {
                    var newFolo = (from c in fdb.Following
                                   where c.UserID == requiredID
                                   select c).FirstOrDefault();
                    newFolo.PersonFollowing = wantedfolloID;

                    Following folo = new Following();
                    
                    fdb.Following.Add(newFolo);
                    fdb.SaveChanges();
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

        public bool DeletefromFollow(string userName, string follouserName)
        {
            // Get Requested User ID
            var requestedUsername = userName;
            var requiredID = 0;
            var foundCredential = (from u in adb.Credentials
                                   where u.UserName == requestedUsername
                                   select u).FirstOrDefault();
            ResponseDTO<LoginDTO> response = new ResponseDTO<LoginDTO>();
            if (foundCredential != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                response.Data = new LoginDTO
                {
                    UserID = foundCredential.UserID,
                };
                requiredID = foundCredential.UserID;
                response.IsSuccessful = true;
            }
            // Get Want to UnFollow User ID
            var wantedfolloname = follouserName;
            var wantedfolloID = 0;
            var foundFollo = (from u in adb.Credentials
                              where u.UserName == wantedfolloname
                              select u).FirstOrDefault();
            ResponseDTO<LoginDTO> responseFollo = new ResponseDTO<LoginDTO>();
            if (foundFollo != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                responseFollo.Data = new LoginDTO
                {
                    UserID = foundFollo.UserID,
                };
                wantedfolloID = foundFollo.UserID;
                responseFollo.IsSuccessful = true;
            }

            // Delete wanted follow userid from requested user following list
            using (var dbTransaction = fdb.Database.BeginTransaction())
            {
                try
                {
                    var newFolo = (from c in fdb.Following
                                   where (c.UserID == requiredID && c.PersonFollowing == wantedfolloID) 
                                   select c).FirstOrDefault();
                    

                    Following folo = new Following();

                    fdb.Following.Remove(newFolo);
                    fdb.SaveChanges();
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

        public bool IsFollow(string userName, string follouserName)
        {
            // Get Requested User ID
            var requestedUsername = userName;
            var requiredID = 0;
            var foundCredential = (from u in adb.Credentials
                                   where u.UserName == requestedUsername
                                   select u).FirstOrDefault();
            ResponseDTO<LoginDTO> response = new ResponseDTO<LoginDTO>();
            if (foundCredential != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                response.Data = new LoginDTO
                {
                    UserID = foundCredential.UserID,
                };
                requiredID = foundCredential.UserID;
                response.IsSuccessful = true;
            }
            // Get Want to UnFollow User ID
            var wantedfolloname = follouserName;
            var wantedfolloID = 0;
            var foundFollo = (from u in adb.Credentials
                              where u.UserName == wantedfolloname
                              select u).FirstOrDefault();
            ResponseDTO<LoginDTO> responseFollo = new ResponseDTO<LoginDTO>();
            if (foundFollo != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                responseFollo.Data = new LoginDTO
                {
                    UserID = foundFollo.UserID,
                };
                wantedfolloID = foundFollo.UserID;
                responseFollo.IsSuccessful = true;
            }

            // check if userid is in requested user's following list
            using (var dbTransaction = fdb.Database.BeginTransaction())
            {
                try
                {
                    bool IfFolo = (from c in fdb.Following
                                   where (c.UserID == requiredID && c.PersonFollowing == wantedfolloID)
                                   select c).Any();

                    return IfFolo;
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                    return false;
                }
            }
        }
    }
}