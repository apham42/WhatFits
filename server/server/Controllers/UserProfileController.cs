using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("v1/profile")]
    public class UserProfileController : ApiController  
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{username}")]
        [EnableCors("http://localhost:8081  , http://longnlong.com , http://whatfits.social", "*", "GET")]
        public IHttpActionResult GetProfileData(string userName)
        {
            // TODO: Validate incoming username to see if it exists in the database
            // TODO: Create a service that gets the required data from the database
            // TODO: Send data back to client side.
            return Ok("NOT FUNCTIONAL - STILL IN DEVELOPMENT ");
        }
    }
}
