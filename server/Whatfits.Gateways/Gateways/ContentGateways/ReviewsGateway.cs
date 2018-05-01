using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Models;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    /// <summary>
    /// Reviews gateway will include adding and reading
    /// Deleting and updating will be added as an extra feature if theres time
    /// </summary>
    public class ReviewsGateway
    {
        private ReviewsContext db = new ReviewsContext();

        //Add Review into the database
        public bool AddReview(ReviewsDTO obj)
        {
            //begins transaction between linq and sql
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    //Gets userID based off of username based on credentials
                    int getUserID = (from cred in db.Credentials
                                     where obj.Username == cred.UserName
                                     select cred.UserID).FirstOrDefault();
                    int getTargetUserID = (from cred in db.Credentials
                                     where obj.TargetUser == cred.UserName
                                     select cred.UserID).FirstOrDefault();
                    //ReviewID is a key and will be automatically incremented
                    //creates a new review instance by grabbing object's data from client
                    Review r = new Review
                    {
                        UserID = getTargetUserID,
                        RevieweeID = getUserID,
                        Rating = obj.Rating,
                        ReviewMessage = obj.ReviewMessage,
                        DateAndTime = obj.DateAndTime,
                    };
                    //add the new instance and saves into database
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


        ////See if the review id exists (used for testing)
        public Boolean ReviewExist(ReviewsDTO obj)
        {
            int getUserID = (from cred in db.Credentials
                             where obj.Username == cred.UserName
                             select cred.UserID).FirstOrDefault();
            var foundReviewID = getUserID;
            //gets the reviewID, if null will return false
            if (foundReviewID>0)
                return true;
            else
                return false;
        }


        //Return ReviewDetailDTO 
        public IEnumerable<ReviewDetailDTO> GetUserReviewDetails(UsernameDTO obj)
        {
            //gets user ID from userprofile
            int getUserID = (from cred in db.Credentials
                             where obj.Username == cred.UserName
                             select cred.UserID).FirstOrDefault();

            var revieweeID = (from rev in db.Review
                              where getUserID == rev.UserID
                              select rev.RevieweeID).FirstOrDefault();

            var revieweeUsername = (from cred in db.Credentials
                                    where revieweeID == cred.UserID
                                    select cred.UserName).FirstOrDefault();

            return (from b in db.Review
                    join cred in db.Credentials
                    on b.UserID equals cred.UserID
                    where obj.Username == cred.UserName
                    select new ReviewDetailDTO()
                    {
                        Reviewee = revieweeUsername,
                        ReviewMessage = b.ReviewMessage,
                        Rating = b.Rating,
                        DateAndTime = b.DateAndTime
                    });
        }
    }
}

