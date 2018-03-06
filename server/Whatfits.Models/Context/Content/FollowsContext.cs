using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Models;
 
namespace Whatfits.Models.Context.Content
{
    public class FollowsContext : DbContext
    {
        public FollowsContext() : base("WhatfitsDb")
        {

        }
        // Insert Model files required for Followers
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Crendtials { get; set; }
        public DbSet<Following> Following { get; set; }
        public DbSet<Follower> Follower { get; set; }
    }
}
