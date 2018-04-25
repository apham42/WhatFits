using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using server.Business_Logic.Search;
using server.Model.Data_Transfer_Objects.SearchDTO_s;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Newtonsoft.Json;
using Whatfits.DataAccess.DTOs.ContentDTOs;

namespace server.Controllers
{
    [RoutePrefix("v1/Search")]
    public class SearchController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IHttpActionResult SearchUser([FromBody] UsernameDTO user)
        {
            var service = new SearchUser
            {
                User = user
            };
            var response = (UsernameResponseDTO) (service.Execute().Result);
            if (response.isSuccessful)
            {
                return Ok(new { response });
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { response.Messages });
            }
        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IHttpActionResult SearchNearby([FromBody] SearchDTO dto)
        {
            var service = new SearchNearbyUserStrategy
            {
                Search = dto
            };
            var response = (SearchResponseDTO) (service.Execute().Result);
            if (response.IsSuccessful)
            {
                return Ok(new { response });
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { response.Messages });
            }
        }
    }
}
