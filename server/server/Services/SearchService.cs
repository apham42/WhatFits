using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;

namespace server.Services
{
    public class SearchService
    {
        public UsernameResponseDTO SearchUser (UsernameDTO dto)
        {
            SearchGateway gateway = new SearchGateway();
            return gateway.SearchUser(dto);
        }
    }
}