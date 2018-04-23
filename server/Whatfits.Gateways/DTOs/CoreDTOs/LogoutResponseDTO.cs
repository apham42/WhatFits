using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.Interfaces;

namespace Whatfits.DataAccess.DTOs.CoreDTOs
{
    public class LogoutResponseDTO : IResponseDTO
    {
        public List<string> Messages { get; set; }
        public bool isSuccessful { get; set; }
    }
}
