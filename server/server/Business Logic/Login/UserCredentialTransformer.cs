using server.Interfaces;
using server.Model;
using server.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;

namespace server.Business_Logic.Login
{
    public class UserCredentialTransformer : ICommand
    {
        public UserCredential userCredential { get; set; }

        /// <summary>
        /// Execute UserCredentialTransformer
        /// Take UserCredential and turns into LoginDTO
        /// </summary>
        /// <returns>LoginDTO</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            response.Result = new LoginDTO()
            {
                UserName = userCredential.Username,
                Password = userCredential.Password
            };
            
            return response;
        }
    }
}