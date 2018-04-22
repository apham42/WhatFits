namespace Whatfits.Models.Migrations.ContentMigrations.ChatMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Whatfits.Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Content.ChatContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContentMigrations\ChatMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Content.ChatContext context)
        {
            /**
            var sampleMessages = new List<Message>
           {
               new Message{ MessageID = 1, UserID = 1, MessageContent = "This is a message", CreatedAt = new DateTime(2018, 03, 15), ReceiverID = 2 },
               new Message{ MessageID = 2, UserID = 2, MessageContent = "This is a message", CreatedAt = new DateTime(2018, 03, 15), ReceiverID = 1 },
               new Message{ MessageID = 3, UserID = 3, MessageContent = "This is a message", CreatedAt = new DateTime(2018, 03, 15), ReceiverID = 4 },
               new Message{ MessageID = 4, UserID = 5, MessageContent = "This is a message", CreatedAt = new DateTime(2018, 03, 15), ReceiverID = 3 },
               new Message{ MessageID = 5, UserID = 4, MessageContent = "This is a message", CreatedAt = new DateTime(2018, 03, 15), ReceiverID = 1 }
           };
            context.Messages.AddOrUpdate(messages => messages.MessageID, (sampleMessages.ToArray()));
            context.SaveChanges();
            **/
        }
    }
}
