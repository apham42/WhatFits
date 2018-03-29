namespace Whatfits.Models.Migrations.ContentMigrations.NotificationMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Whatfits.Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Content.NotificationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContentMigrations\NotificationMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Content.NotificationContext context)
        {
            /*
               var notifications = new List<Notification>
               {
                   new Notification{ Message = "This is a notification message.", UserID=1, NotificationType="Chat"},
                   new Notification{ Message = "This is a notification message.", UserID=1, NotificationType="Chat"},
                   new Notification{ Message = "This is a notification message.", UserID=2, NotificationType="System"},
                   new Notification{ Message = "This is a notification message.", UserID=3, NotificationType="System"},
                   new Notification{ Message = "This is a notification message.", UserID=4, NotificationType="Chat"}
               };
               notifications.ForEach(c => context.Notifications.Add(c));
               context.SaveChanges();
           //*/
        }
    }
}
