using System;
using System.Linq;
using System.Collections.Generic;
using Whatfits.Models.Context.Core;
using Whatfits.Models.Models;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;

namespace Whatfits.DataAccess.Gateways.CoreGateways
{
    /// <summary>
    /// Used for handling login functions with the database.
    /// </summary>
    public class LoginGateway
    {
        AccountContext db = new AccountContext();
        /// <summary>
        /// Gets credential information for login
        /// </summary>
        /// <param name="obj">UserName</param>
        /// <returns>
        /// UserID, Password, Salt, IsBannded, and IsFullyRegistered via LoginDTO
        /// </returns>
        public ResponseDTO<LoginDTO> GetCredentials(LoginDTO obj)
        {
            // Finds the User based off UserName
            var foundCredential = (from u in db.Credentials
                             where u.UserName == obj.UserName
                             select u).FirstOrDefault();
            ResponseDTO<LoginDTO> response = new ResponseDTO<LoginDTO>();
            response.Messages = new List<string>();
            if (foundCredential != null)
            {
                // Found user in database, creating LoginDTO to send 
                // credential infromation
                response.Data = new LoginDTO
                {
                    UserName = foundCredential.UserName,
                    UserID = foundCredential.UserID,
                    Password = foundCredential.Password,
                    Salt = db.Salts.Find(foundCredential.UserID).SaltValue,
                    Type = db.UserProfiles.Find(foundCredential.UserID).Type
                };
                response.IsSuccessful = true;
                // Returns data
            }
            else
            {
                // Failed to find user based off UserName
                // Returns Null Values
                response.IsSuccessful = false;
                // Returns failure
            }
            return response;
        }
        /// <summary>
        /// Returns Both the answer and the QuestionID of the answer 
        /// </summary>
        /// <param name="obj">UserName</param>
        /// <returns>
        /// Dictionary of Answers and thier corresponding QuestionIDs via LoginDTO
        /// </returns>
        public ResponseDTO<Dictionary<int, string>> GetSecurityQandAs(LoginDTO obj)
        {
            var foundUser = (from credential in db.Credentials
                             where credential.UserName == obj.UserName
                             select credential).FirstOrDefault();
            ResponseDTO<Dictionary<int, string>> response = new ResponseDTO<Dictionary<int, string>>();
            if (foundUser == null)
            {
                response.IsSuccessful = false;
                // Returns Response
                return response;
            }
            else
            {
                var foudnQandA = (from answers in db.SecurityAccounts
                                  where answers.UserID == foundUser.UserID
                                  select answers).ToList();
                // Passes the query into a dictionary
                Dictionary<int, String> temp = new Dictionary<int, string>();
                for (int i = 0; i < foudnQandA.Count(); i++)
                {
                    temp.Add(foudnQandA[i].SecurityQuestionID, foudnQandA[i].Answer);
                }
                // Creates the response
                response.Data = temp;
                response.IsSuccessful = true;
                // Returns Response
                return response;
            }
        }
        /// <summary>
        /// Gets list of SecurityQuestions from Database
        /// </summary>
        /// <returns>
        /// Dictionary of Questions and QuestionIDs via LoginDTO
        /// </returns>
        public ResponseDTO<Dictionary<int, string>> GetSecurityQuestions()
        {
            var query = db.SecurityQuestions.ToList();
            ResponseDTO<Dictionary<int, string>> response = new ResponseDTO<Dictionary<int, string>> { };
            if (query == null)
            {
                response.IsSuccessful = false;
            }
            else
            {
                Dictionary<int, String> temp = new Dictionary<int, string>();
                foreach (var question in query)
                {
                    temp.Add(question.SecurityQuestionID, question.Question);
                }
                response.Data = temp;
                response.IsSuccessful = true;
            }
            return response;
        }
        /// <summary>
        /// Determines whether token is on blacklist
        /// </summary>
        /// <param name="obj">
        /// - Token(string)
        /// </param>
        /// <returns>
        /// True - Token exists in BlackList
        /// False - Token does not exists in Blacklist
        /// </returns>
        public ResponseDTO<Boolean> CheckIfTokenOnBlackList(LoginDTO obj)
        {
            // Queries to see if token exists in database
            var query = (from x in db.TokenBlackLists
                         where x.Token == obj.Token
                         select x).FirstOrDefault();
            // Creates response DTO
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean> { };

            if (query == null)
            {
                // Set to false if not found
                response.IsSuccessful = false;
                response.Data = false;
            }
            else
            {
                // Set to true if found
                response.IsSuccessful = true;
                response.Data = true;
            }
            // returns response
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public LogoutResponseDTO AddTokenToBlackList(LoginDTO obj)
        {
            // Creates response DTO
            LogoutResponseDTO response = new LogoutResponseDTO { };
            // Find user based off Username
            var foundCredential = (from u in db.Credentials
                                   where u.UserName == obj.UserName
                                   select u).FirstOrDefault();

            // If token already exists in database
            if (foundCredential != null)
            {
                // Token does not exists in database
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Creates temporary token to store in database
                        TokenBlackList temp = new TokenBlackList
                        {
                            UserID = foundCredential.UserID,
                            Token = obj.Token
                        };
                        db.TokenBlackLists.Add(temp);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        // Sends response
                        response.isSuccessful = true;
                        return response;
                    }
                    catch (NullReferenceException)
                    {
                        dbTransaction.Rollback();
                        response.isSuccessful = false;
                        return response;
                    }
                }
            }
            else
            {
                // Token already exists in database
                response.isSuccessful = false;
                response.Messages = new List<string> { "Error: Token already Exists in Database." };
                return response;
            }  
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> RemoveTokenFromBlackList(LoginDTO obj)
        {
            // Creates response DTO
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean> { };
            var foundToken = (from token in db.TokenBlackLists
                              where token.Token == obj.Token
                              select token).FirstOrDefault();

            if (foundToken == null)
            {
                // If token not found in database
                response.IsSuccessful = false;
                response.Messages = new List<string> { "Error: Token not found in database."};
                return response;
            }else
            {
                // If token is found in database, procede to delete token
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Deletes token that was found
                        db.TokenBlackLists.Remove(foundToken);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        response.IsSuccessful = true;
                        return response;
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        return response;
                    }
                }
            }
        }

        /// <summary>
        /// get salt to verify jwt
        /// </summary>
        /// <param name="obj">LoginDTO</param>
        /// <returns>jwt salt</returns>
        public ResponseDTO<string> GetSaltFromTokenList(LoginDTO obj)
        {
            // response
            ResponseDTO<string> response = new ResponseDTO<string>();

            // find user base of username
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();

            if (foundUser == null)// if user not found
            {
                response.IsSuccessful = false;
                return response;
            }
            else
            {
                // find if user already has token
                var foundToken = (from Token in db.TokenLists
                                  where Token.UserID == foundUser.UserID
                                  select Token).FirstOrDefault();

                // connection to db.
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // if cant find token
                        if (foundToken == null)
                        {
                            response.IsSuccessful = false;
                            return response;
                        }
                        else
                        {
                            response.Data = foundToken.Salt;
                            response.IsSuccessful = true;
                            return response;
                        }
                    }
                    catch (Exception)
                    {
                        // undo transaction
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        return response;
                    }

                }
            }
        }

        /// <summary>
        /// Add token to token list.
        /// newly created tokens are added to this list.
        /// </summary>
        /// <param name="obj">LoginDTO</param>
        /// <returns>ResponseDTO true if added</returns>
        public ResponseDTO<Boolean> AddToTokenList(LoginDTO obj)
        {
            // response
            ResponseDTO<Boolean> response = new ResponseDTO<Boolean>();

            // Find user based off Username
            var foundUser = (from account in db.Credentials
                             where account.UserName == obj.UserName
                             select account).FirstOrDefault();

            if (foundUser == null)// if not found
            {
                response.IsSuccessful = false;
                response.Data = false;
                return response;
            }
            else
            {
                // find if user already has token
                var foundToken = (from Token in db.TokenLists
                                  where Token.UserID == foundUser.UserID
                                  select Token).FirstOrDefault();
                // connection to db.
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (foundToken == null) // if not token found
                        {
                            TokenList newToken = new TokenList() // new token to be added
                            {
                                Token = obj.Token,
                                Salt = obj.Salt,
                                UserID = foundUser.UserID
                            };

                            // add and save token
                            db.TokenLists.Add(newToken);
                            db.SaveChanges();
                            dbTransaction.Commit();
                            response.IsSuccessful = true;
                            response.Data = true;
                            return response;
                        } else // if token 
                        {
                            // update token
                            foundToken.Token = obj.Token;
                            foundToken.Salt = obj.Salt;
                            db.SaveChanges();
                            dbTransaction.Commit();
                            response.IsSuccessful = true;
                            return response;
                        }
                    }
                    catch (Exception) // if fail
                    {
                        // undo transaction
                        dbTransaction.Rollback();
                        response.IsSuccessful = false;
                        response.Data = false;
                        return response;
                    }
                }
            }
        }
    }
}
