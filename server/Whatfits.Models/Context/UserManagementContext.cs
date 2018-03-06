using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Whatfits.Models.Context
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext() : base("WhatfitsDb")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<PersonalKey> PersonalKeys { get; set; }
    }
}
