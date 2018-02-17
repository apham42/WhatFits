using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class User
    {
        public int UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public User (int userid, string firstname, string lastname)
        {
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
        }
    }
}