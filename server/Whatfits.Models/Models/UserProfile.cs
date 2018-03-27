using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the User table of this system's database.   
    /// </summary>
    public class UserProfile : IUserProfile
    {
        // Primary key of the User model
        [Key, ForeignKey("Credential")]
        public int UserID { get; set; }
        
        // Foriegn Key to Locations
        [ForeignKey("Location")]
        public int LocationID { get; set; }

        // Stores Email address of the User
        [Required, StringLength(256)]
        public string Email { get; set; }

        // Stores the directory path of the profile picture
        public string ProfilePicture { get; set; }

        // Stores First Name of the User
        [Required, StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        // Stores Last Name of the User
        [Required, StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        // Stores Gender of the User
        [Required, StringLength(50, MinimumLength = 2)]
        public string Gender { get; set; }

        // Stores the User Skill level for workingout
        [Required, StringLength(20, MinimumLength = 2)]
        public string SkillLevel { get; set; }

        // User Description for Profile
        [StringLength(250)]
        public string Description { get; set; }
        
        // Determines what type of user they are.
        [Required]
        public string Type { get; set; }
        
        // User can have One:
        public virtual Credential Credential { get; set; }

        // Navigation Property
        public virtual Location Location { get; set; }

        // Users can have many:
        public ICollection<Review> Review { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<WorkoutLog> WorkoutLogs { get; set; }
        public ICollection<Following> Followers { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}