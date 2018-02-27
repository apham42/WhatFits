using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models.Context
{
    class UserAccessControlContext : DbContext
    {
        public UserAccessControlContext(): base("WhatfitsDb")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}
