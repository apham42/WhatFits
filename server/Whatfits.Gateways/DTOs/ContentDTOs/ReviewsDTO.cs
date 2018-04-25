using System;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class ReviewsDTO : IReview
    {
        public string Username { get; set; }
        public int RevieweeID { get; set; }
        public string ReviewMessage { get; set; }
        public int Rating { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}
