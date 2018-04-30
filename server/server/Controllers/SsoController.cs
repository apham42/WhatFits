using server.Business_Logic.SSO.SSOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.UserAccessControl.Controller;

namespace server.Controllers
{
    [RoutePrefix("v1/Sso")]
    [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://localhost:8085 http://longnlong.com , http://whatfits.social, https://fannbrian.github.io", headers: "*", methods: "POST")]
    public class SsoController : ApiController
    {
        /// <summary>
        /// sso registration
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthorizePrincipal(type = "application", value = "WhatFits")]
        public IHttpActionResult Registration()
        {
            SSOService service = new SSOService();

            var response = service.SSORegistrationService();

            if(response.isSuccessful == false)
            {
                return Content(HttpStatusCode.BadRequest, response);
            }

            return Ok(response);
        }

        /// <summary>
        /// sso login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login()
        {
            return Ok();
        }

        /// <summary>
        /// sso reset password
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ResetPassword()
        {
            return Ok();
        }
    }
}
