using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Xunit;

namespace Gateway.Tester.Tests
{
    public class ReviewTests
    {
        public ReviewsGateway r = new ReviewsGateway();

        [Fact]
        public void TestAddReview()
        {
            ReviewsDTO rev = new ReviewsDTO()
            {
                RevieweeID = 3,
                UserID = 5,
                ReviewMessage = "Here's the test",
                Rating = 4,
                DateAndTime = new DateTime(2017, 05, 15),
                ReviewID = 9
            };

            // Passing DTO to gateway to be processed and stored
            r.AddReview(rev);
            // Finding UserID by Name that is stored
            Boolean found = r.ReviewExist(rev);
            Assert.True(found);
        }

        [Fact]
        public void DoesReviewExist()
        {
            // Checks if the review does exist
            ReviewsDTO SearchReview = new ReviewsDTO()
            {
                ReviewID = 1
            };
            Boolean result = r.ReviewExist(SearchReview);
            Assert.True(result);
        }
        [Fact]
        public void TestGetReviews()
        {
            // NOTE: This is based on order in the database
            List<int> expectedList = new List<int>
            {
                1,4,2,3,5,6
            };
            Assert.Equal(expectedList, r.GetReviewList());
        }
        [Fact]
        public void TestGetReviewMessage()
        {
            // NOTE: This is based on order in the database
            List<string> expectedList = new List<string>
            {
                "User was great"
            };
            Assert.Equal(expectedList, r.GetReviews(1));
        }
    }
}
