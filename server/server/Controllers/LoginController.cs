using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.JsonWebToken.Controller;

namespace server.Controllers
{
    [RoutePrefix("v1/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult Login([FromBody] UserCredential userCredential)
        {
            LoginResponseDTO response = new LoginResponseDTO();
            string username = userCredential.Username;
            response.username = username;
            CreateJWT createJWT = new CreateJWT();
            response.token = createJWT.CreateToken(username, "general");
            return Ok(new { response });
        }
    }
}
