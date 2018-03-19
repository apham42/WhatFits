using System;
using System.Linq;
using System.Collections.Generic;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{
    /// <summary>
    /// Used for handling login functions with the database.
    /// </summary>
    public class LoginGateway
    {
        LoginContext db = new LoginContext();
        /// <summary>
        /// Gets credential information for login
        /// </summary>
        /// <param name="obj">UserName</param>
        /// <returns>
        /// UserID, Password, Salt, IsBannded, and IsFullyRegistered via LoginDTO
        /// </returns>
        public LoginDTO GetCredentials(LoginDTO obj)
        {
            // Finds the User based off UserName
            var foundCredential = (from u in db.Credentials
                             where u.UserName == obj.UserName
                             select u).FirstOrDefault();

            if (foundCredential != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                LoginDTO credentials = new LoginDTO()
                {
                    UserID = foundCredential.UserID,
                    Password = foundCredential.Password,
                    Salt = db.Salts.Find(foundCredential.UserID).SaltValue,
                    Type = "General"
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
                    Salt = null,
                    Type = null
                };
                // Returns null data
                return nullValues;
            }
        }
        /// <summary>
        /// Returns Both the answer and the QuestionID of the answer 
        /// </summary>
        /// <param name="obj">UserName</param>
        /// <returns>
        /// Dictionary of Answers and thier corresponding QuestionIDs via LoginDTO
        /// </returns>
        public LoginDTO GetSecurityQandAs(LoginDTO obj)
        {
            var foundUser = (from u in db.Credentials
                             where u.UserName == obj.UserName
                             select u).FirstOrDefault();

            var foudnQandA = (from QandA in db.SecurityQandA
                              where QandA.UserID == foundUser.UserID
                              select QandA).ToList();
            Dictionary<int, String> temp = new Dictionary<int, string>();
            for (int i = 0; i < foudnQandA.Count(); i++)
            {
                temp.Add(foudnQandA[i].SecurityQuestionID, foudnQandA[i].Answer);
            }
            LoginDTO results = new LoginDTO()
            {
                Answers = temp
            };
            return results;
        }
        /// <summary>
        /// Gets list of SecurityQuestions from Database
        /// </summary>
        /// <returns>
        /// Dictionary of Questions and QuestionIDs via LoginDTO
        /// </returns>
        public LoginDTO GetSecurityQuestions()
        {
            var query = db.SecurityQuestions.ToList();
            Dictionary<int,String> temp = new Dictionary<int, string>();
            for(int i =0; i< query.Count();i++)
            {
                temp.Add(query[i].SecurityQuestionID, query[i].Question);
            }
            LoginDTO results = new LoginDTO()
            {
                Questions = temp
            };
            return results;
        }       
    }
}
