using server.Business_Logic.Services;
using server.Interfaces;
using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.JsonWebToken.Controller;

namespace server.Controllers
{

    [RoutePrefix("v1/login")]
    public class LoginController : ApiController
    {

        /// <summary>
        /// Login Controller
        /// Executes Login Service
        /// Checks if user is valid
        /// </summary>
        /// <param name="userCredential"></param>
        /// <returns>token, username, viewclaims</returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult Login([FromBody] UserCredential userCredential)
        {
            LoginService login = new LoginService()
            {
                userCredential = userCredential
            };
            LoginResponseDTO loginResponse = new LoginResponseDTO();

            loginResponse = login.loginService();

            if (loginResponse.Messages.Contains("User does not exist")
                || loginResponse.Messages.Contains("Could not Create Token"))
            {
                return Content(HttpStatusCode.NotFound, loginResponse.Messages);
            } 
            else if(loginResponse.Messages.Contains("Incorrect Credentials"))
            {
                return Content(HttpStatusCode.Unauthorized, loginResponse.Messages);
            }

            return Ok(loginResponse);
        }
    }
}
