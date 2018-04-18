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
    public class WorkoutLoggerController : ApiController
    {
        /// <summary>
        /// Creates Review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateReview(WorkoutLogDTO workout)
        {
            WorkoutLoggerService service = new WorkoutLoggerService();
            bool response = service.Create(workout);
            if (response)
            {
                return Ok("Workout has been added");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Workout addition has failed");
            }
        }

        
        [Route("Review/GetWorkout/{UserName}")]
        [HttpGet]
        public IEnumerable<ReviewDetailDTO> GetWorkout(string UserName)
        {
            ReviewService service = new ReviewService();
            return service.GetUserReview(UserName);
        }

    }
}
