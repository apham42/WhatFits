using System;
using System.Data.Entity;

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

        public class UserDBContext : DbContext
        {
            public DbSet<User> Users { get; set; }
        }
    }
}