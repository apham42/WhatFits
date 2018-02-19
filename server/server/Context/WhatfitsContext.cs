using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Whatfits.Models;

namespace server.Context
{
    public class WhatfitsContext : DbContext
    {
        public WhatfitsContext() : base("WhatfitsDb")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Event> Events { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        //public DbSet<UserPermission> UserPermissions { get; set; }
        //public DbSet<SecurityAnswer> Securit yAnswers { get; set; }
        //public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        //public DbSet<Review> Review { get; set; }
        //public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        //public DbSet<WeightLifting> WeightLifting { get; set; }
        //public DbSet<Following> Following { get; set; }
        // Note: Do i not need this?
        //public DbSet<Cardio> Cardio { get; set; }  
    }
}