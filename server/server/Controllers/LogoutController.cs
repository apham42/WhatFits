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
    [RoutePrefix("v1/logout")]
    public class LogoutController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult logout([FromBody] UserCredential userCredential)
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = userCredential.Username,
                Token = userCredential.Token
            };

            LoginGateway loginGateway = new LoginGateway();

            loginGateway.AddTokenToBlackList(loginDTO);

            return Ok();

        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult sendToBlackList([FromBody] UserCredential user)
        {
            string blah = user.Token;
            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = user.Username,
                Token = user.Token
            };

            LoginGateway loginGateway = new LoginGateway();

            loginGateway.AddTokenToBlackList(loginDTO);

            return Ok();
        }
    }
}
