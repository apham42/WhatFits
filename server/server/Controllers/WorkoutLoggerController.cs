//using server.Services;
//using System;
//using System.Collections.Generic;
using server.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;

namespace server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("v1/WorkoutLogger")]
    public class WorkoutLoggerController : ApiController
    {
        //        /// <summary>
        //        /// Creates Review
        //        /// </summary>
        //        /// <param name="review"></param>
        //        /// <returns></returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IHttpActionResult CreateWorkout(WorkoutLogDTO workout)
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

        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IEnumerable<WorkoutLogDTO> GetWorkout()
        {
            WorkoutLogGateway service = new WorkoutLogGateway();
            return service.GetWorkouts("Latmay");
            
        }

    }
}
