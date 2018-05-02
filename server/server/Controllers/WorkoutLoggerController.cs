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
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
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
        /// <summary>
        /// Creates a workout
        /// </summary>
        /// <param name="workout"></param>
        /// <returns>a response</returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IHttpActionResult CreateWorkout(WorkoutLogDTO workout)
        {
            //ModelState.IsValid then the try catch
            WorkoutLoggerService service = new WorkoutLoggerService();
            //change success
            bool response = service.Create(workout);
            if (response)
            {
                return Ok("Workout has been added");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Workout addition has failed. Invalid Inputs.");
            }
        }
        /// <summary>
        /// gets workout enumerable
        /// </summary>
        /// <param name="username"></param>
        /// <returns>workout objects</returns>
        // need to change to response vulnerable to JSON hijacking
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IEnumerable<WorkoutLogDTO> GetWorkout(UsernameDTO obj)
        {
            WorkoutLogGateway service = new WorkoutLogGateway();
            return service.GetWorkouts(obj);
            
        }

    }
}
