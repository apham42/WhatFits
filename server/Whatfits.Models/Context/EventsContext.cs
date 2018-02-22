using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models.Context
{
    public class EventsContext : DbContext
    {
        public EventsContext(): base("WhatfitsDb")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
