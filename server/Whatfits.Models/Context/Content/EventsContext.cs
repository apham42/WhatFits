using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    /// <summary>
    /// Represents the Events table
    /// </summary>
    public class EventsContext : DbContext
    {
        public EventsContext() : base("WhatfitsDb") { }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
