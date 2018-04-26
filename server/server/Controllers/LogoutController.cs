using server.Business_Logic.Services;
using server.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.UserAccessControl.Controller;

namespace server.Controllers
{
    [RoutePrefix("v1/logout")]
    public class LogoutController : ApiController
    {
        /// <summary>
        /// logout controller to allow users to logout
        /// </summary>
        /// <param name="userCredential">userCredential=Username/Token</param>
        /// <returns>success if stored in blacklist fails if not</returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AuthorizePrincipal(type = "WORKOUT_ADD", value = "Add")]
        public IHttpActionResult logout([FromBody] UserCredential userCredential)
        {
            LogoutService logoutService = new LogoutService();

            LogoutResponseDTO response = logoutService.logout(userCredential);

            if(response.isSuccessful == true)
            {
                return Ok(response.Messages);
            }

            return Content(HttpStatusCode.NotFound, response.Messages);
        }
    }
}
