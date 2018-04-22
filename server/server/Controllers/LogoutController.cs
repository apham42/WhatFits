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
        [AllowAnonymous]
        public IHttpActionResult logout([FromBody] UserCredential userCredential)
        {
            LogoutService logoutService = new LogoutService();
            List<string> message = new List<string>();

            ResponseDTO<bool> responseDTO = logoutService.logout(userCredential);

            if(responseDTO.IsSuccessful == true)
            {
                message.Add("Success!");
                responseDTO.Messages = message;
                return Ok(responseDTO.Messages);
            }

            message.Add("Failed To Logout");
            responseDTO.Messages = message;

            return Content(HttpStatusCode.NotFound, responseDTO.Messages);

        }
    }
}
