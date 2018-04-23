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
                    select new FollowsDTO { UserName = c.UserName }).ToList();
        }

        public bool AddtoFollow(FollowsDTO fdto)
        {
            using (var dbTransaction = fdb.Database.BeginTransaction())
            {
                try
                {
                    Following fllo = new Following
                    {
                        PersonFollowing = fdto.PersonFollowing
                    };
                    fdb.Following.Add(fllo);
                    fdb.SaveChanges();
                    dbTransaction.Commit();
                    return true;
                }
                catch(SqlException)
                {
                    dbTransaction.Rollback();
                    return false;
                }
                catch(DataException)
                {
                    dbTransaction.Rollback();
                    return false;
                }
            }
        }



    }
}