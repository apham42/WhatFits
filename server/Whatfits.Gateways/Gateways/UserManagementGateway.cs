using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Whatfits.Models;
using Whatfits.Models.Context;
using Whatfits.DataAccess.DataTransferObjects;
using Whatfits.DataAccess.DataTransferObjects.UserManagementDTOs;
using Whatfits.DataAccess.GatewayInterfaces;

namespace Whatfits.DataAccess.Gateways
{
    public class UserManagementGateway : IDataGateway<UserManagementDTO>
    {
        private UserManagementContext db = new UserManagementContext();

        public void Create(UserManagementDTO obj)
        {
            User user = new User
            {
                FirstName = obj.GetFirstName(),
                LastName = obj.GetLastName(),
                ID = obj.GetID(),
                Email = obj.GetEmail(),
                Gender = obj.GetGender(),
                IsPartialRegistration = obj.GetPartialRegistration(),
                IsDisabled = obj.GetIsDisabled()
            };
            Credential credential = new Credential
            {
                UserName = obj.GetUserName(),
                Password = obj.GetPassword(),
                UserID = obj.GetID()
            };
            PersonalKey personalkey = new PersonalKey
            {
                Salt = obj.GetSalt(),
                UserID = obj.GetID()
            };
            Claim newClaim = new Claim
            {
                UserID = obj.GetID(),
                ClaimsType = obj.GetClaimType(),
                ClaimsValue = obj.GetClaimValue()
            };
            db.Users.Add(user);
            db.Claims.Add(newClaim);
            db.Credentials.Add(credential);
            db.PersonalKeys.Add(personalkey);
            Save();
        }

        public void Delete(int id)
        {
            User usr = new User() { ID = id };
            db.Users.Attach(usr);
            db.Users.Remove(usr);
            Save();
        }

        public void Disable(int? id)
        {
            throw new NotImplementedException();
        }

        public void DisableUser(int? id)
        {
            // Need to Implement
        }

        public void EnableUser(int? id)
        {
            // Need to Implement
        }

        public string FindByID(int? id)
        {
            string UserName = (from x in db.Credentials
                               where x.UserID == id
                               select x.UserName).FirstOrDefault();
            return UserName;
        }

        public string FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public int FindByUserName(string userName)
        {
            int userID = (from u in db.Credentials
                          where u.UserName == userName
                          select u.UserID).FirstOrDefault();
            return userID;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(UserManagementDTO obj)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(int id, string password)
        {
            // update Password in exists
        }
    }
}
