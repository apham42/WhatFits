using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace server.Models
{
    public class WhatfitsContext : DbContext
    {
        public WhatfitsContext() : base("WhatfitsDb")
        {
            Database.SetInitializer(new WhatfitsDBInitializer());
        }
        // NOTE: Sprint 1 Data Tables Below
        public DbSet<User> Users { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<SecurityAnswer> SecurityAnswers { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        //public DbSet<Review> Review { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        public DbSet<WeightLifting> WeightLifting { get; set; }
        //public DbSet<Cardio> Cardio { get; set; }  
        // Do i not need this?
        // NOTE: Sprint 2 Tables Below
        
        public DbSet<Event> Events { get; set; }
        /*
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
        */
        public DbSet<Following> Following { get; set; }
        


    }
}