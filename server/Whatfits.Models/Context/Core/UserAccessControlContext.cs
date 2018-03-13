using System.Collections.Generic;
using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Core
{
    class UserAccessControlContext : DbContext
    {
        public UserAccessControlContext(): base("WhatfitsDb")
        {

        }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
    }
}
