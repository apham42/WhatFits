using server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Whatfits.DataAccess.DTOs.ContentDTOs;

namespace server.Controllers
{
    public class ReviewController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Review(ReviewsDTO review)
        {
            ReviewService service = new ReviewService();
            service.Create(review);
            return Ok();
        }

        [Route("Review/GetUserReview/{userID}")]
        [HttpGet]
        public List<string> GetUserReview(int userID)
        {
            ReviewService service = new ReviewService();           
            return service.GetUserReviews(userID);
        }
        
    }
}
