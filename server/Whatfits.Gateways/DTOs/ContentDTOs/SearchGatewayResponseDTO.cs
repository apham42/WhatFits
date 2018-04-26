using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class SearchGatewayResponseDTO
    {
        public List<string> Messages { get; set; }
        public bool IsSuccessful { get; set; }
        public List <UserSearch> Results { get; set; }
    }
}
