namespace Whatfits.Models.Migrations.ContentMigrations.FollowsMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Whatfits.Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Content.FollowsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContentMigrations\FollowsMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Content.FollowsContext context)
        {
            /*
            var followingList = new List<Following>
             {
                 new Following{ UserID = 0001, PersonFollowing = 0002 },
                 new Following{ UserID = 0002, PersonFollowing = 0002 },
                 new Following{ UserID = 0003, PersonFollowing = 0002 },
                 new Following{ UserID = 0004, PersonFollowing = 0001 },
                 new Following{ UserID = 0005, PersonFollowing = 0003 }
             };
            followingList.ForEach(c => context.Following.Add(c));
            context.SaveChanges();
            //*/
        }
    }
}
