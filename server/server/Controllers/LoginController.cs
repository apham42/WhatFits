using server.Model.Account;
using System.Web.Http;
using System.Web.Http.Cors;

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
            return Ok(new { reponse.Messages });
        }
    }
}
