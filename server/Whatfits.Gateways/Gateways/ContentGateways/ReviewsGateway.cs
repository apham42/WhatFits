using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Context.Core;
using Whatfits.Models.Models;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    /// <summary>
    /// 
    /// </summary>
    public class ReviewsGateway
    {
        private ReviewsContext db = new ReviewsContext();
        private AccountContext dc = new AccountContext();
        //Add Review into the database
        public bool AddReview(ReviewsDTO b)
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
                    return true;
                }
                catch (SqlException)
                {
                    dbTransaction.Rollback();
                    return false;
                }
                catch (DataException)
                {
                    dbTransaction.Rollback();
                    return false;
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


        public List<string> GetReview(string userName)
        {
            List<string> rmsg = (from b in db.Review 
                                 join cred in db.Credentials
                                 on b.UserID equals cred.UserID
                                 where userName == cred.UserName
                                 select b.ReviewMessage
                                  ).ToList();
            return rmsg;
        }

        //Retrieves all dates of reviews based on userID
        public List<DateTime> GetDates(int UserID)
        {
            List<DateTime> dmsg = (from b in db.Review
                                 where b.UserID == UserID
                                 select b.DateAndTime
                                  ).ToList();
            return dmsg;
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
