namespace Whatfits.Models.Migrations.CoreMigrations.UserAccessControlMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Core.UserAccessControlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CoreMigrations\UserAccessControlMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Core.UserAccessControlContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
