using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkoutLogContext : DbContext
    {
        public WorkoutLogContext() : base("WhatfitsDb") { }
        // Insert Model files required for Workout Logger
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<WorkoutLog> Workouts { get; set; }
        public DbSet<Cardio> Cardios { get; set; }
        public DbSet<WeightLifting> WeightLiftings { get; set; }
    }
}
