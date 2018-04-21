//using server.Services;
//using System;
//using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;

namespace server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkoutLoggerController : ApiController
    {
        //        /// <summary>
        //        /// Creates Review
        //        /// </summary>
        //        /// <param name="review"></param>
        //        /// <returns></returns>
        //        [HttpPost]
        //        public IHttpActionResult CreateReview(WorkoutLogDTO workout)
        //        {
        //            WorkoutLoggerService service = new WorkoutLoggerService();
        //            bool response = service.Create(workout);
        //            if (response)
        //            {
        //                return Ok("Workout has been added");
        //            }
        //            else
        //            {
        //                return Content(HttpStatusCode.BadRequest, "Workout addition has failed");
        //            }
        //        }


        [Route("WorkoutLogger/GetWorkout/{UserName}")]
        [HttpGet]
        public IEnumerable<WorkoutLogDTO> GetWorkout(string UserName)
        {
            WorkoutLogGateway service = new WorkoutLogGateway();
            return service.GetWorkouts(UserName);
        }

    }
}
