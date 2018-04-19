using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Business_Logic.Services
{
    public class LoginService
    {
        public LoginService(string incusername, string incpassword)
        {
            username = incusername;
            password = incpassword;
        }

        public string username { get; set; }
        public string password { get; set; }
    }
}