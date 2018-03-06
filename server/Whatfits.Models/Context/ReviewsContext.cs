using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models.Context
{
    public class ReviewsContext : DbContext
    {
        public ReviewsContext() : base("WhatfitsDb")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}
