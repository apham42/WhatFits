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
            /**
            var sampleNotifications = new List<Notification>
            {
                new Notification{ NotificationID = 1, Message = "This is a notification message.", UserID=1, NotificationType="Chat"},
                new Notification{ NotificationID = 2, Message = "This is a notification message.", UserID=1, NotificationType="Chat"},
                new Notification{ NotificationID = 3, Message = "This is a notification message.", UserID=2, NotificationType="System"},
                new Notification{ NotificationID = 4, Message = "This is a notification message.", UserID=3, NotificationType="System"},
                new Notification{ NotificationID = 5, Message = "This is a notification message.", UserID=4, NotificationType="Chat"}
            };
            context.Notifications.AddOrUpdate(notifications => notifications.NotificationID, sampleNotifications.ToArray());
            context.SaveChanges();
            **/
        }
    }
}
