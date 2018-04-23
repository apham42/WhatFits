namespace Whatfits.Models.Migrations.ContentMigrations.EventsMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Whatfits.Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Content.EventsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContentMigrations\EventsMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Content.EventsContext context)
        {
            /**
            var sampleEvents = new List<Event>
                {
                    new Event { EventID = 1, Title = "Title1", DateAndTime = new DateTime(2018,1,2), CreatedAt = new DateTime(2018,1,2), Description = "Description1", Image = "/Dir/", Latitude = "Lat1", Longitude = "Long1",Location = "312 W. Fake St.", UserID = 1 },
                    new Event { EventID = 2, Title = "Title2", DateAndTime = new DateTime(2018,1,2), CreatedAt = new DateTime(2018,1,2), Description = "Description2", Image = "/Dir/", Latitude = "Lat2", Longitude = "Long2",Location = "312 W. Fake St.", UserID = 2 },
                    new Event { EventID = 3, Title = "Title3", DateAndTime = new DateTime(2018,1,2), CreatedAt = new DateTime(2018,1,2), Description = "Description3", Image = "/Dir/", Latitude = "Lat3", Longitude = "Long3",Location = "312 W. Fake St.", UserID = 3 },
                    new Event { EventID = 4, Title = "Title4", DateAndTime = new DateTime(2018,1,2), CreatedAt = new DateTime(2018,1,2), Description = "Description4", Image = "/Dir/", Latitude = "Lat4", Longitude = "Long4",Location = "312 W. Fake St.", UserID = 4 },
                    new Event { EventID = 5, Title = "Title5", DateAndTime = new DateTime(2018,1,2), CreatedAt = new DateTime(2018,1,2), Description = "Description5", Image = "/Dir/", Latitude = "Lat5", Longitude = "Long5",Location = "312 W. Fake St.", UserID = 5 }
                };
            context.Events.AddOrUpdate(events => events.EventID, sampleEvents.ToArray());
            context.SaveChanges();
            **/
        }
    }
}
