using System;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class ReviewsDTO : IReview
    {
        public int RevieweeID { get; set; }
        public int UserID { get; set; }
        public string ReviewMessage { get; set; }
        public int Rating { get; set; }
        public DateTime DateAndTime { get; set; }
        public int ReviewID { get; set; }
    }
}
