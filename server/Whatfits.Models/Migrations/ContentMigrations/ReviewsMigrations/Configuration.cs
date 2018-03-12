namespace Whatfits.Models.Migrations.ContentMigrations.ReviewsMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Whatfits.Models.Models;
        internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Content.ReviewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContentMigrations\ReviewsMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Content.ReviewsContext context)
        {
            //reviewID reviewerID revieweeID rating reviewmessage datetime
            context.Reviews.AddOrUpdate(x => x.ReviewID,
                new Review()
                {
                    ReviewID = 0001,
                    ReviewerID = 0001,
                    RevieweeID = 0002,
                    Rating = 4,
                    ReviewMessage = "User was great",
                    DateTime = "05/21/2017"
                },
                new Review()
                {
                    ReviewID = 0002,
                    ReviewerID = 0002,
                    RevieweeID = 0003,
                    Rating = 3,
                    ReviewMessage = "User was great",
                    DateTime = "05/21/2017"
                },
                new Review()
                {
                    ReviewID = 0003,
                    ReviewerID = 0003,
                    RevieweeID = 0004,
                    Rating = 4,
                    ReviewMessage = "User was great",
                    DateTime = "05/21/2017"
                },
                new Review()
                {
                    ReviewID = 0004,
                    ReviewerID = 0001,
                    RevieweeID = 0005,
                    Rating = 3,
                    ReviewMessage = "User was great",
                    DateTime = "05/21/2017"
                },
                new Review()
                {
                    ReviewID = 0005,
                    ReviewerID = 0004,
                    RevieweeID = 0005,
                    Rating = 5,
                    ReviewMessage = "User was great",
                    DateTime = "05/21/2017"
                });
        }
    }
}
