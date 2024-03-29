﻿using System;
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
using server.Model.Search;
using Whatfits.UserAccessControl.Controller;
using Whatfits.UserAccessControl.Constants;
using server.Controllers.Constants;

namespace server.Controllers
{
    [RoutePrefix("v1/Search")]
    public class SearchController : ApiController
    {
        
        [HttpPost]
        [AuthorizePrincipal(type = TypeConstant.SEARCH_CLAIM_TYPE, value = ValueConstant.SEARCH_CLAIM_VALUE)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, methods: "POST")]
        public IHttpActionResult SearchUser([FromBody] SearchUserDTO dto)
        {
            var service = new SearchUserStrategy
            {
                SearchUserCriteria = dto.SearchUserCriteria
            };
            var response = (SearchResponseDTO) (service.Execute().Result);
            if (response.IsSuccessful)
            {
                return Ok(new { response.SearchResults, response.Messages });
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { response.Messages });
            }
        }

        [HttpPost]
        [AuthorizePrincipal(type = TypeConstant.SEARCH_CLAIM_TYPE, value = ValueConstant.SEARCH_CLAIM_VALUE)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, methods: "POST")]
        public IHttpActionResult SearchNearby([FromBody] SearchDTO dto)
        {
            var service = new SearchNearbyUserStrategy
            {
                Search = dto.Criteria
            };
            var response = (SearchResponseDTO) (service.Execute().Result);
            if (response.IsSuccessful)
            {
                return Ok(new { response.SearchResults, response.Messages });
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { response.Messages });
            }
        }
    }
}
