using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Models;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class LocationResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public List<string> Messages { get; set; }
        public List<GeoCoordinates> LocationResults { get; set; }
    }
}
