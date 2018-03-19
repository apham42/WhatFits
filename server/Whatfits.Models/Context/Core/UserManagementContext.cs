using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class UserManagementContext : DbContext
    {
        public UserManagementContext() : base("WhatfitsDb") { }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Salt> Salts { get; set; }
        public DbSet<ClaimItem> Claims { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<SecurityQandA> SecurityQandA { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
