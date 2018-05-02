//using server.Services;
//using System;
//using System.Collections.Generic;
using server.Controllers.Constants;
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
using Whatfits.UserAccessControl.Constants;
using Whatfits.UserAccessControl.Controller;

namespace server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("v1/WorkoutLogger")]
    public class WorkoutLoggerController : ApiController
    {
        /// <summary>
        /// Creates Review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizePrincipal(type = TypeConstant.WORKOUTLOG_CLAIM_TYPE_ADD, value = ValueConstant.WORKOUTLOG_CLAIM_VALUE_ADD)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, methods: "POST")]
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
                return Content(HttpStatusCode.BadRequest, "Workout addition has failed. Invalid Inputs.");
            }
        }

        [HttpPost]
        [AuthorizePrincipal(type = TypeConstant.VIEW_PAGE, value = ValueConstant.WORKOUTLOG_CLAIM_VALUE_VIEW)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, methods: "POST")]
        public IEnumerable<WorkoutLogDTO> GetWorkout(UsernameDTO obj)
        {
            WorkoutLogGateway service = new WorkoutLogGateway();
            return service.GetWorkouts(obj);
            
        }

    }
}
