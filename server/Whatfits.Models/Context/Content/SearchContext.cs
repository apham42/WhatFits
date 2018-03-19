using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchContext : DbContext
    {
        public SearchContext() : base("WhatfitsDb") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
