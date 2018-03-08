using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Core
{
    class UserAccessControlContext : DbContext
    {
        public UserAccessControlContext(): base("WhatfitsDb")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Credential> Credentails { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
    }
}
