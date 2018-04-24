using server.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace server.Controllers
{
    // TODO: @AaronPham Controller not done
    [RoutePrefix("v1/ResetPassword")]
    public class ResetPasswordController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult GetQuestions([FromBody] UserCredential userCredentials)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult GetAnswers([FromBody] UserCredential userCredentials)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult SetPassword([FromBody] UserCredential userCredentials)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = "ay"
            };

            LoginGateway loginGateway = new LoginGateway();
            ResetPasswordResponseDTO yo = loginGateway.GetSecurityQandAs(loginDTO);

            return Ok(yo);
        }
    }
}
