using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Web.Http.Cors;
using System.Text;
using System;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers:"*", methods: "*")]
    public class HomeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            //response.Content = new StringContent("Whatfits", Encoding.Unicode);
            //response.Headers.CacheControl = new CacheControlHeaderValue()
            //{
            //    MaxAge = TimeSpan.FromMinutes(20)
            //};
            //return response;

            return new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test Message")
            };

        }
    }
}
