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
                return Ok(new { response.Messages });
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
                return Ok(new { response.SearchResults });
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { response.Messages });
            }
        }


        [HttpPost]
        // [EnableCors(origins: "http://localhost:8080 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        public IHttpActionResult Testinb([FromBody] UsernameDTO dto)
        {
            var gateway = new SearchGateway();
            var locations = gateway.RetrieveLocations().LocationResults;
            var filter = new FilterGeoCoordinates()
            {
                Distance = 5,
                GeoCoordinates = locations,
                UserLocation = new System.Device.Location.GeoCoordinate(33.7830608, -118.1148909)
            };


            return Ok(filter.Execute().Result);

        }

        public static Dictionary<TKey, double> ToDictionary<TKey>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<TKey, double>>(json);
            return dictionary;
        }
    }
}
