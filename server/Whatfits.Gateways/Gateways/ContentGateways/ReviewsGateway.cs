using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
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
                        RevieweeID = b.RevieweeID,
                        UserID = b.UserID,
                        ReviewMessage = b.ReviewMessage,
                        Rating = b.Rating,
                        DateAndTime = b.DateAndTime,
                        ReviewID = b.ReviewID
                    };
                    //add into database t he new instance and saves
                    db.Review.Add(r);
                    db.SaveChanges();
                    dbTransaction.Commit();

                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                }
            }
        }

        //Retrieves all reviews based on userID
        public List<string> GetReviews(int UserID)
        {
            List<string> rmsg = (from b in db.Review
                                 where b.UserID == UserID
                                 select b.ReviewMessage
                                  ).ToList();
            return rmsg;
        }
        
        //See if the review id exists
        public Boolean ReviewExist(ReviewsDTO r)
        {
            var foundReviewID = (from b in db.Review
                                 where b.ReviewID == r.ReviewID
                                 select b.ReviewID);
            if (foundReviewID == null)
                return false;
            else
                return true;
        }

        //gets all the reviews in the database
        public List<int> GetReviewList()
        {
            List<int> rlist = (from b in db.Review
                                  select b.ReviewID
                                  ).ToList();
            return rlist;
        }

       
    }

}
