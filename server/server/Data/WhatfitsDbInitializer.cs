using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WhatFits.Models;

namespace server.Models
{
    public class WhatfitsDBInitializer : DropCreateDatabaseAlways<WhatfitsContext>
    {
        protected override void Seed(WhatfitsContext context)
        {
            GetUsers().ForEach(c => context.Users.Add(c));
        }
        private static List<User> GetUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    UserID = 0001,
                    UserName = "Tom123",
                    Password = "asdf"
                },
                new User
                {
                    UserID = 0002,
                    UserName = "Emily123",
                    Password = "asdf"
                },
                new User
                {
                    UserID = 0003,
                    UserName = "John123",
                    Password = "asdf"
                },
                new User
                {
                    UserID = 0004,
                    UserName = "Max123",
                    Password = "asdf"
                },
            };
            return users;
        }
    }
}