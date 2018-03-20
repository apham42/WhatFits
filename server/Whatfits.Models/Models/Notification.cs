using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the table of notifications being stored.
    /// </summary>
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        // Foreign Key - Maps to the User Table
        [ForeignKey("User")]
        public int UserID { get; set; }

        // Stores the Notification type ei: Chat
        [Required]
        public string NotificationType { get; set; }

        // Stores the Message of the Notification ie: John Doe has messaged you
        [Required]
        public string Message { get; set; }

        // Navigation Property for User
        public virtual UserProfile User { get; set; }

        
    }
}
