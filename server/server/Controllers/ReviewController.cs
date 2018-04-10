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
        //Generic response from server
        [HttpPost]
        public IHttpActionResult CreateReview(ReviewsDTO review)
        {
            ReviewService service = new ReviewService();
            bool response = service.Create(review);
            if (response)
            {
                return Ok("Review has been added");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Review addition has failed");
            }
        }

        //Gets reviews of specific userName
        [Route("Review/GetUserReview/{UserName}")]
        [HttpGet]
        public IEnumerable<ReviewDetailDTO> GetUserReview(string UserName)
        {
            ReviewService service = new ReviewService();
            return service.GetUserReview(UserName);
        }

    }
}
