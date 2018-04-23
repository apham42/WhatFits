using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class FollowsDTO : IFollowing
    {
        public int PersonFollowing { get; set; }
        public string UserName { get; set; }
    }
}
