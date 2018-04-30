using server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;

namespace server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("v1/review")]
    public class ReviewController : ApiController
    {
        /// <summary>
        /// Creates Review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IHttpActionResult CreateReview([FromBody] ReviewsDTO review)
        {
            ReviewService service = new ReviewService();
            bool response = service.Create(review);
            if (response)
            {
                return Ok("Review has been added");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Review addition has failed. Invalid Inputs.");
            }
        }

        /// <summary>
        /// Gets reviews of specific userName
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 ,http://localhost:8081, http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IEnumerable<ReviewDetailDTO> GetUserReview(UsernameDTO obj)
        {
            ReviewService service = new ReviewService();
            return service.GetUserReview(obj);
        }

    }
}
