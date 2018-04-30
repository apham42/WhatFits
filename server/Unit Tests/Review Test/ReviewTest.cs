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
                Username = "asdf",
                TargetUser = "amay",
                Rating = 4,
                ReviewMessage = "Here's the test",
                DateAndTime = new DateTime(2017, 05, 15),
            };

            // Passing DTO to gateway to be processed and stored
            r.AddReview(rev);
            // Finding UserID by Name that is stored
            Boolean found = r.ReviewExist(rev);
            Assert.True(found);
        }
    }
}
