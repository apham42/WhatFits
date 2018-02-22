using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Whatfits.Models;
using Whatfits.Models.Context;
using Whatfits.Gateways.DataTransferObjects;

namespace Whatfits.Gateways
{
    public class UserDataGateway
    {
        private UserDataContext db = new UserDataContext();
        // Possible Improvement by only passing a CreateUserDTO with all this information
        public void CreateUser(CreateUserDTO user)
        {
            db.Users.Add(user.ReceiveUser());
            // Should I include a Save()?
            db.SaveChanges();
        }

        public void CreatePartialUser(UserDTO partialUser)
        {
            db.Credentials.Add(partialUser.ReceiveCredential());
        }

        public void UpdateUser(CreateUserDTO user)
        {

        }

        public void DeleteUser(int? ID)
        {

        }

        public void DisableUser(int? ID)
        {

        }

        public void EnableUser(int? ID)
        {

        }

        /*
        public IEnumerable String GetClaims()
        {
            return null;
        }
        */
        public void RemoveClaims(CreateUserDTO user)
        {

        }

        public int FindByID(int? id)
        {
            return 0;
        }

        public User FindByUserName(string userName)
        {
            User temp = new User();
            return temp;
        }
    }
}
