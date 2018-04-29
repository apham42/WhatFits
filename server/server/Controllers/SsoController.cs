using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace server.Controllers
{
    [RoutePrefix("v1/Sso")]
    public class SsoController : ApiController
    {
        /// <summary>
        /// sso registration
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Registration()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// sso login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// sso reset password
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ResetPassword()
        {
            throw new NotImplementedException();
        }
    }
}
