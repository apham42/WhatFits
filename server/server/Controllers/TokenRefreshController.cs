using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace server.Controllers
{
    [RoutePrefix("v1/TokenRefresh")]
    public class TokenRefreshController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult Refresh([FromBody] TokenRefreshResponseDTO token)
        {
            return Ok();
        }
    }
}
