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
        {}
    }
}
