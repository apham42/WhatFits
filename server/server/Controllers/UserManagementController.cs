﻿using System;
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
    [EnableCorsAttribute("http://whatfits.social", "*","post")]
    public class UserManagementController : ApiController
    {
        // Demo Code TO BE REMOVED - Rob
        int[] ints = { 1, 2, 3, 4 };
        [HttpGet]
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
                return Content(HttpStatusCode.BadRequest,"Not Good");
            }
            if (!service.ChangeUserStatus(obj).IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, "Wasn't Successful.");
            }            
            return Ok("Success");
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
            //int x = 1;
            return Ok( 
                new UserManagementDTO {
                    FirstName = "Adam",
                    LastName = "West"
                }
                );
        }
    }
}
