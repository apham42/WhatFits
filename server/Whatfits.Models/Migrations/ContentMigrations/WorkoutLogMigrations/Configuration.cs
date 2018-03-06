namespace Whatfits.Models.Migrations.ContentMigrations.WorkoutLogMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Content.WorkoutLogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContentMigrations\WorkoutLogMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Content.WorkoutLogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
