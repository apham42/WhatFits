using System;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class SearchDTO : IUserProfile, IEvent
    {
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string SkillLevel { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Image { get; set; }
    }
}
