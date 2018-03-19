using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    /// <summary>
    /// 
    /// </summary>
    public class NotificationContext : DbContext
    {
        public NotificationContext() : base("WhatfitsDb") { }
        // Insert Model files required for Notifications
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
