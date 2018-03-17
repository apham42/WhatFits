using System.ComponentModel.DataAnnotations;

namespace Whatfits.Models.Models
{
    public class Following
    {
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }
        // Primary Key
        [Key]
        public int FollowingID { get; set; }

        public int PersonFollowing { get; set; }
    }
}