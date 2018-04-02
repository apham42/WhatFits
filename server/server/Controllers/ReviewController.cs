using server.Model.Data_Transfer_Objects.ReviewDTO_s;
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
        //Needs a response and promise in client side
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

        //Gets reviews of specific userID, *could be changed to username in the future*
        [Route("Review/GetUserReview/{UserName}")]
        [HttpGet]
        public List<string> GetUserReview(string UserName)
        {
            ReviewService service = new ReviewService();
            return service.GetUserReview(UserName);
        }

    }
}
