using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Core
{
    /// <summary>
    /// Represents all the models used for this context
    /// </summary>
    class UserAccessControlContext : DbContext
    {
        public UserAccessControlContext() : base("WhatfitsDb") { }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
    }
}
