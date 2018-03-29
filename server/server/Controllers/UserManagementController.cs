using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using server.Services;
namespace server.Controllers
{
    public class UserManagementController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ManageUser(string userCred)
        {
            UserManagementService service = new UserManagementService();
            if(userCred == null)
            {
                return Content(HttpStatusCode.BadRequest, "What");
            }
            return Ok("You reached the end of the controller");
            
        }
    }
}