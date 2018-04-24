using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class ReviewDetailDTO : IResponseDTO
    {
        public List<string> Messages { get; set; }
        public bool isSuccessful { get; set; }

        public string ReviewMessage { get; set; }
        public int Rating { get; set; }
        public DateTime DateAndTime { get; set; }

    }
}
