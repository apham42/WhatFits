using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Account
{
    /// <summary>
    /// Contains the credentials of the user for them to login
    /// </summary>
    public class UserCredential
    {
        public UserCredential(string username, string password, string token)
        {
            Username = username;
            Password = password;
            Token = token;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Token { get; private set; }
    }
}