using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Models;
using Xunit;

namespace Unit_Tests.Review_Test
{
    public class ReviewTest
    {
        ReviewsGateway test = new ReviewsGateway();
        private ReviewsContext db = new ReviewsContext();
        [Fact]
        public bool createReview()
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    Review rev = new Review
                    {
                        UserID = 1,
                        RevieweeID = 2,
                        Rating = 3,
                        ReviewMessage = "test",
                        DateAndTime = new DateTime(2015, 12, 12)
                    };
                    db.Review.Add(rev);
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
    }
}
