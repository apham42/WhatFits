using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using server.Services;
using System.Web.Http.Cors;

namespace server.Controllers
{
    /// <summary>
    /// Provides APIs for UserManagement for Clientside
    /// </summary>
    /// NOTE: Change headers to appropriate 
    [EnableCors("http://localhost:8081", "*","GET,POST,PUT")]
    public class UserManagementController : ApiController
    {
        int[] ints = { 1, 2, 3, 4 };
        [HttpGet]
        //[Route("morenums")]
        //[DisableCors]
        public IHttpActionResult GetInt()
        {
            return Ok(ints);
        }
        //-------------------------------------------
        [HttpPut]
        //[Authorize]
        public IHttpActionResult ChangeStatus(UserManagementDTO obj)
        {
            UserManagementService service = new UserManagementService();
            if(obj == null)
            {
                return Content(HttpStatusCode.BadRequest,"Failure: Bad Request");
            }
            if (!service.ChangeUserStatus(obj).IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Failed to change status.");
            }    
            return Ok("Success: "+obj.UserName +"'s account was "+obj.Type+"d.");
        }
        [HttpPost]
        //[Route("temp/so")]
        public IHttpActionResult TestPost(UserManagementDTO obj)
        {
            if (obj == null)
            {
                return Content(HttpStatusCode.BadRequest,"Forgot to add data.");
            }
            else
            {
                return Ok("This has executed Correctly." + obj.FirstName +" "+obj.LastName);
            }
        }
        //[]
        [HttpGet]
        public IHttpActionResult getTest()
        {
            return Ok( 
                new UserManagementDTO {
                    FirstName = "Adam",
                    LastName = "West"
                }
            );
        }
    }
}
