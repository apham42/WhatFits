using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class ReviewMessageDTO
    {
        public int UserID { get; set; }
        public string ReviewMessage { get; set; }
        public int Rating { get; set; }
    }
}
