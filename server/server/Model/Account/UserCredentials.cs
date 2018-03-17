using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Account
{
    public class UserCredentials
    {
        public UserCredentials(string user, string pass)
        {
            UserName = user;
            Password = pass;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}