using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Models;
namespace Whatfits.Models.Context.Content
{
    public class ChatContext : DbContext
    {
        public ChatContext(): base("WhatfitsDb")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
