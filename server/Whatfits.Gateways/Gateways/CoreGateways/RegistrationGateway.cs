using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.GatewayInterfaces;

namespace Whatfits.Gateways.Gateways.CoreGateways
{
    public class RegistrationGateway //: IDataGateway<RegistrationDTO>
    {
        private RegistrationContext db = new RegistrationContext();

        public void RegisterUser(RegistrationDTO obj)
        {
            User user = new User
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                //ID = obj.ID,
                Email = obj.Email,
                Gender = obj.Gender,
                IsPartialRegistration = obj.IsPartial,
                IsDisabled = obj.IsDisable
            };

            Credential credential = new Credential {
                UserName = obj.UserName,
                Password = obj.Password,
                UserID = obj.ID
            };

            Location location = new Location {
                Address = obj.Address,
                City = obj.City,
                State = obj.State,
                Zipcode = obj.Zipcode,
                UserID = obj.ID
            };

            PersonalKey personalkey = new PersonalKey
            {
                Salt = obj.Salt,
                UserID = obj.ID
            };

            db.Users.Add(user);
            var id = db.Users.Find();
            // Find UserID to relate to user class
            // implementing userClaims
            List<int> claims = obj.ClaimID;
            for (int i = 0; i < claims.Count; i++)
            {
                UserClaims temp = new UserClaims
                {
                    UserID = user.ID,
                    ClaimID = claims[i]
                };
                db.UserClaims.Add(temp);
            }
            db.Credentials.Add(credential);
            db.Locations.Add(location);
            db.PersonalKeys.Add(personalkey);
            Save();
        }

        public string FindUserNameByID(int id)
        {
            var result = db.Credentials.Find(id);
            return result.UserName;
            /*
             * Reminder: Compare with the new query
            string UserName = (from x in db.Credentials
                               where x.UserID == id
                               select x.UserName).FirstOrDefault();
            return UserName;
            */
        }

        public int FindIDByUserName(string userName)
        {
            var userID = db.Credentials.Find(userName);
            return userID.UserID;
        }

        public Boolean DoesUserNameExist(string userName)
        {
            var foundUserName = db.Credentials.Find(userName);
            if (userName == foundUserName.UserName)
                return true;
            else
                return false;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
