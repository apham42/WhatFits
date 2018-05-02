using server.Controllers.Constants;
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
using Whatfits.UserAccessControl.Constants;
using Whatfits.UserAccessControl.Controller;

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
        [AuthorizePrincipal(type = TypeConstant.REVIEW_CLAIM_TYPE, value = ValueConstant.REVIEW_CLAIM_VALUE)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, methods: "POST")]
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
        [AuthorizePrincipal(type = TypeConstant.REVIEW_CLAIM_TYPE, value = ValueConstant.REVIEW_CLAIM_VALUE)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, methods: "POST")]
        public IEnumerable<ReviewDetailDTO> GetUserReview(UsernameDTO obj)
        {
            ReviewService service = new ReviewService();
            return service.GetUserReview(obj);
        }

    }
}
