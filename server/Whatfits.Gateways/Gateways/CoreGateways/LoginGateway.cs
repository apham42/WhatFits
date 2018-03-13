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

namespace Whatfits.DataAccess.Gateways.CoreGateways
{
    public class LoginGateway
    {
        /// <summary>
        /// LoginGateway
        /// PURPOSE: Provides a method to search for User by Username,
        /// once found it returns the data to be processed for login.
        /// </summary>
        LoginContext db = new LoginContext();
        // Gets Credential Data
        public LoginDTO GetCredentials(string UserName)
        {
            // Finds the User based off UserName
            var foundCredential = db.Credentials.Find(UserName);
            if(foundCredential != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                LoginDTO credentials = new LoginDTO()
                {
                    UserID = foundCredential.UserID,
                    Password = foundCredential.Password,
                    Salt = db.Salts.Find(foundCredential.UserID).SaltValue
                };
                // Returns data
                return credentials;
            }
            else
            {
                // Failed to find user based off UserName
                // Returns Null Values
                LoginDTO nullValues = new LoginDTO()
                {
                    UserID = -1,
                    Password = null,
                    Salt = null
                };
                // Returns null data
                return nullValues;
            }
        }
    }
}
