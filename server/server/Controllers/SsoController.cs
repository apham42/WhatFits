using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace server.Controllers
{
    [RoutePrefix("v1/Sso")]
    [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social, https://fannbrian.github.io", headers: "*", methods: "POST")]
    public class SsoController : ApiController
    {
        /// <summary>
        /// sso registration
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Registration()
        {
            return Ok();
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
