using System.Data.Entity;
using Whatfits.Models.Models;
 
namespace Whatfits.Models.Context.Content
{
    /// <summary>
    /// 
    /// </summary>
    public class FollowsContext : DbContext
    {
        public FollowsContext() : base("WhatfitsDb") { }
        // Insert Model files required for Followers
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Credential> Crendtials { get; set; }
        public DbSet<Following> Following { get; set; }
    }
}
