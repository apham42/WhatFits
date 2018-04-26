using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Account
{
    public class UserProfile
    {
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Skill { get; set; }
    }
}