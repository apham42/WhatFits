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
    [RoutePrefix("v1/management")]
    public class UserManagementController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public IHttpActionResult CreateUser(UserManagementDTO obj)
        {
            return Ok("To be completed");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("enable")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult EnableUser(UserManagementDTO obj)
        {
            UserManagementService service = new UserManagementService();
            if(obj == null)
            {
                return Content(HttpStatusCode.BadRequest,"Failure: Bad Request");
            }
            if (!service.EnableUser(obj).IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Failed to change status.");
            }    
            return Ok("Success: "+obj.UserName +"'s account was enabled.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("disable")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult DisableUser(UserManagementDTO obj)
        {
            UserManagementService service = new UserManagementService();
            if (obj == null)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Bad Request");
            }
            if (!service.DisableUser(obj).IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Failed to change status.");
            }
            return Ok("Success: " + obj.UserName + "'s account was disabled.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("delete")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult DeleteUser (UserManagementDTO obj)
        {
            UserManagementService service = new UserManagementService();
            if(obj == null)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Bad Request");
            }
            if (!service.DeleteUser(obj).IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Failed to delete user.");
            }
            return Ok("Success: " + obj.UserName+" was deleted.");
        }
        // Note: Used for testing Purposes, will be deleted once done -Rob
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("samplePost")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "POST")]
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sampleGet")]
        [EnableCors("http://localhost:8081  , http://longnlong.com , http://whatfits.social", "*", "POST")]
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
