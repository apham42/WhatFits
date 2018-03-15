using server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace server.Controllers
{
    public class ReviewController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Review([FromBody] string message, int rating)
        {
            ReviewService service = new ReviewService();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return Ok();
        }
    }
}

