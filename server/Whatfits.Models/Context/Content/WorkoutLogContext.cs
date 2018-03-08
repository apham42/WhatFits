using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    public class WorkoutLogContext : DbContext
    {
        public WorkoutLogContext() : base("WhatfitsDb")
        {

        }
        // Insert Model files required for Workout Logger
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<WorkoutLog> Workouts { get; set; }
        public DbSet<Cardio> Cardios { get; set; }
        public DbSet<WeightLifting> WeightLiftings { get; set; }
    }
}
