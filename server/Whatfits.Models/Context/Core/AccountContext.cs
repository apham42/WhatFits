using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Core
{
    /// <summary>
    /// Represents all the models used for this context
    /// </summary>
    public class AccountContext : DbContext
    {
        public AccountContext() : base("WhatfitsDb"){}
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Salt> Salts { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<SecurityAccount> SecurityAccounts { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TokenBlackList> TokenBlackLists { get; set; }
        public DbSet<TokenList> TokenLists { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
