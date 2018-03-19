using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Core
{
    /// <summary>
    /// 
    /// </summary>
    class UserAccessControlContext : DbContext
    {
        public UserAccessControlContext() : base("WhatfitsDb") { }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<ClaimItem> Claims { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
    }
}
