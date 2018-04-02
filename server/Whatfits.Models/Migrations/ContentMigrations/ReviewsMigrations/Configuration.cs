namespace Whatfits.Models.Migrations.ContentMigrations.ReviewsMigrations
{
    using System;
    using System.Collections.Generic;
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
            var sampleReviews = new List<Review>
            {
                new Review() { ReviewID = 1, UserID = 1, RevieweeID = 2, Rating = 4, ReviewMessage = "User was great", DateAndTime = new DateTime(2018, 03, 15) },
                new Review() { ReviewID = 2, UserID = 2, RevieweeID = 3, Rating = 3, ReviewMessage = "User was great", DateAndTime = new DateTime(2018, 02, 15) },
                new Review() { ReviewID = 3, UserID = 3, RevieweeID = 4, Rating = 4, ReviewMessage = "User was great", DateAndTime = new DateTime(2018, 04, 15) },
                new Review() { ReviewID = 4, UserID = 1, RevieweeID = 5, Rating = 3, ReviewMessage = "User was great", DateAndTime = new DateTime(2018, 03, 25) },
                new Review() { ReviewID = 5, UserID = 4, RevieweeID = 5, Rating = 5, ReviewMessage = "User was great", DateAndTime = new DateTime(2017, 03, 15) }
            };
            context.Review.AddOrUpdate(reviews => reviews.ReviewID,sampleReviews.ToArray());
            context.SaveChanges();
        }
    }
}
