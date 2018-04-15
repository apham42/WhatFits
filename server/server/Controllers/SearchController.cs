using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using server.Business_Logic.Services;

namespace server.Controllers
{
    [RoutePrefix("v1/Search")]
    public class SearchController : ApiController
    {
        [HttpPost]
        [Route("User")]
        [EnableCors(origins: "http://localhost:8080 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IHttpActionResult SearchUser(string username)
        {
            SearchService service = new SearchService();
            UsernameDTO userCred = new UsernameDTO()
            {
                Username = username
            };
            UsernameResponseDTO response = service.FindUser(userCred);
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
