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
    /// Provides APIs for UserManagement for Clientside
    /// </summary> 
    [RoutePrefix("v1/checkPassword")]
    public class BadPasswordController : ApiController
    {
        [HttpPost]
        [Route("checkPasswor")]
        [EnableCors("http://localhost:8081  , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public IHttpActionResult CheckPassword ()
        {
            return Ok("NOT FUNCTIONAL - STILL IN DEVELOPMENT ");
        }
    }
}
