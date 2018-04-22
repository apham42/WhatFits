using System;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class SearchGatewayDTO
    {
        public string RequestedUser { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
