using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models.Context
{
    public class UserDataContext : DbContext
    {
        public UserDataContext() : base("WhatfitsDb")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PersonalKey> PersonalKeys { get; set; }
        public DbSet<SecurityAnswer> SecurityAnswers { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}
