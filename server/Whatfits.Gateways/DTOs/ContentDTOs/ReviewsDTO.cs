using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class ReviewsDTO
    {
        public int RevieweeID { get; set; }
        public int UserID { get; set; }
        public string ReviewMessage { get; set; }
        public int Rating { get; set; }
        public DateTime DateAndTime { get; set; }
        public int ReviewID { get; set; }
    }
}
