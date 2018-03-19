using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    /// <summary>
    /// 
    /// </summary>
    public class EventsContext : DbContext
    {
        public EventsContext() : base("WhatfitsDb") { }
        // Insert Model files required for Events
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
