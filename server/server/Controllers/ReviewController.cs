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
    /// <summary>
    /// 
    /// </summary>
    public class ReviewController : ApiController
    {
        /// <summary>
        /// Creates Review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets reviews of specific userName
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [Route("Review/GetUserReview/{UserName}")]
        [HttpGet]
        public IEnumerable<ReviewDetailDTO> GetUserReview(string UserName)
        {
            ReviewService service = new ReviewService();
            return service.GetUserReview(UserName);
        }

    }
}
