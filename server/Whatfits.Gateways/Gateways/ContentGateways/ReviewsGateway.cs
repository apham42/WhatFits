using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Models;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    /// <summary>
    /// 
    /// </summary>
    public class ReviewsGateway
    {
        private ReviewsContext db = new ReviewsContext();

        //Add Review into the database
        public void AddReview(ReviewsDTO b)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    //creates a new review instance by grabbing object's data
                    Review r = new Review
                    {
                        ReviewID = b.ReviewID,
                        RevieweeID = b.RevieweeID,
                        UserID = b.UserID,
                        ReviewMessage = b.ReviewMessage,
                        DateAndTime = b.DateAndTime
                    };
                    //add into database t he new instance and saves
                    db.Review.Add(r);
                    Save();
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                }
            }
        }

        //Get:api/Reviews/[userID]
        public List<Review> GetReviews(ReviewsDTO obj)
        {
            var target = db.Review.Find(obj.UserID);
            return (from b in db.Review
                    where b.UserID == target.UserID
                    select new Review()
                    {
                        ReviewID = b.ReviewID,
                        RevieweeID = b.RevieweeID,
                        UserID = b.UserID,
                        ReviewMessage = b.ReviewMessage,
                        DateAndTime = b.DateAndTime
                    }).ToList();
        }

        private void Save()
        {
            // Saves any changes to the database
            db.SaveChanges();
        }
    }

}
