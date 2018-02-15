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
        public DbSet<User> User { get; set; }

    }
}