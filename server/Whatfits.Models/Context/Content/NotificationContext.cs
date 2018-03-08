using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    public class NotificationContext : DbContext
    {
        public NotificationContext() : base("WhatfitsDb")
        {

        }
        // Insert Model files required for Notifications
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
