using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model tracks who is following who for 
    /// following's list.
    /// </summary>
    public class Following : IFollowing
    {
        // Primary Key
        [Key]
        public int FollowingID { get; set; }

        // Foreign Key to User Table
        [ForeignKey("UserProfile")]
        public int UserID { get; set; }

        // Tracks the UserID of the person your following
        [Required]
        public int PersonFollowing { get; set; }

        // Navigation Property for Workoutlog
        public virtual UserProfile UserProfile { get; set; }
        
    }
}