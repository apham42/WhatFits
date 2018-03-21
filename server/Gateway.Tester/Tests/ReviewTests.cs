using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Xunit;

namespace Gateway.Tester.Tests
{
    public class ReviewTests
    {
        public ReviewsGateway r = new ReviewsGateway();

        [Fact]
        public void TestAddUser()
        {
            ReviewsDTO rev = new ReviewsDTO()
            {
                UserID = 5,
                RevieweeID = 1,
                ReviewMessage = "Here's the test",
                ReviewID = 6,
                Rating = 4,
                DateAndTime = new DateTime(2017, 05, 15)

            };

            // Passing DTO to gateway to be processed and stored
            r.AddReview(rev);
            // Finding UserID by Name that is stored
            Boolean found = r.ReviewExist(rev);
            Assert.True(found);
        }
    }
}
