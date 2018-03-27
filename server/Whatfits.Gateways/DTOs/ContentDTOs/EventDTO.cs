using System;
using Whatfits.Models.Interfaces;
namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class EventDTO : IEvent
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
