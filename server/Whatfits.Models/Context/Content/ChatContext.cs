using System.Data.Entity;
using Whatfits.Models.Models;

namespace Whatfits.Models.Context.Content
{
    /// <summary>
    /// 
    /// </summary>
    public class ChatContext : DbContext
    {
        public ChatContext() : base("WhatfitsDb") { }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<UserProfile> User { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
