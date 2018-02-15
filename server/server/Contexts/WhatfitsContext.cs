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
        public DbSet<User> User { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
//        public DbSet<SecurityAnswers> SecurityAnswers { get; set; }
  //      public DbSet<SecurityQuestions> SecurityQuestions { get; set; }
    //    public DbSet<Review> Review { get; set; }
        // NOTE: Sprint 2 Tables Below
        /*
        public DbSet<WorkoutLogs> WorkoutLogs { get; set; }
        public DbSet<WeightLifting> WeightLifting { get; set; }
        public DbSet<Cardio> Cardio { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Following> Following { get; set; }
        */
        

    }
}