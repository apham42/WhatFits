using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using server.Services;
using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System.Web.Http.Cors;
using server.Controllers.Constants;

namespace server.Controllers
{
    [RoutePrefix("v1/Signup")]
    public class SignUpController : ApiController
    {
        /// <summary>
        /// Handles Register requests
        /// </summary>
        /// <param name="userCred"> Registeration Information </param>
        /// <returns> Status of the request with a list of messages </returns>
        [HttpPost]
        [AllowAnonymous]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, methods: "POST")]
        public IHttpActionResult Register([FromBody] RegInfo userCred)
        {
            AccountService service = new AccountService();
            RegInfoResponseDTO response = service.RegisterUser(userCred);
            if (response.isSuccessful)
            {
                return Ok(new { response.Messages });
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { response.Messages });
            }
        }
    }
}
