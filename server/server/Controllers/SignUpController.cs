using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using server.Services;

namespace server.Controllers
{
    public class SignUpController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Register([FromBody] string username, string password)
        {
            AccountService service = new AccountService();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return Ok();
        }
    }
}
