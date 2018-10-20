namespace Whatfits.Models.Migrations.ContentMigrations.SearchMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Content.SearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContentMigrations\SearchMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Content.SearchContext context)
        {}
    }
}
