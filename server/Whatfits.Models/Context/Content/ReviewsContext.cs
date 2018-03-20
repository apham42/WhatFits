using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    /// <summary>
    /// 
    /// </summary>
    public class ReviewsContext : DbContext
    {
        public ReviewsContext() : base("WhatfitsDb") { }
        public DbSet<UserProfile> User { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}
