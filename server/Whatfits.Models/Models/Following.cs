using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model tracks who is following who for 
    /// following's list.
    /// </summary>
    public class Following
    {
        // Primary Key
        [Key, Column(Order = 0)]
        public int FollowingID { get; set; }

        // Foreign Key to User Table
        [Key, Column(Order = 1)]
        public int UserID { get; set; }

        // Tracks the UserID of the person your following
        [Required]
        public int PersonFollowing { get; set; }

        // Navigation Property for Workoutlog
        public virtual UserProfile User { get; set; }
        
    }
}