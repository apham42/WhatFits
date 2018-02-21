using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Whatfits.Models;

namespace Whatfits.Models.Context
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
        public DbSet<PersonalKey> PersonalKeys { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<SecurityAnswer> SecurityAnswers { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        public DbSet<Following> Following { get; set; }
        public DbSet<Follower> Followers { get; set; }
    }
}