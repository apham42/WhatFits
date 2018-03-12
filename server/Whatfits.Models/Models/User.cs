using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the User table of this system's database.   
    /// </summary>
    public class User
    {
        // Primary key of the User model
        [Key]
        public int UserID { get; set; }

        // Stores Email address of the User
        [Required, StringLength(256)]
        public string Email { get; set; }

        // Stores Profile picture of each user
        public byte[] ProfilePicture { get; set; }

        // Stores First Name of the User
        [Required, StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        // Stores Last Name of the User
        [Required, StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        // Stores Gender of the User
        [Required, StringLength(50, MinimumLength = 2)]
        public string Gender { get; set; }

        // User can have One:
        //[Required]
        // Note: This causes an error, don't know why
        public virtual Credential Credential { get; set; }

        // Users can have many:
        public ICollection<UserClaims> UserClaims { get; set; }
        public ICollection<SecurityQandA> SecurityQandAs { get; set; }
        /*
        public ICollection<Message> Messages { get; set; }
        public ICollection<Event> Event { get; set; }
        public ICollection<WorkoutLog> WorkoutLogs { get; set; }
        public ICollection<Following> Following { get; set; }
        public ICollection<Follower> Followers { get; set; }
        public ICollection<Review> Review { get; set; }
        */
    }
}