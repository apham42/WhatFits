using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the table where all events
    /// are stored.
    /// </summary>
    public class Event
    {
        [Key]
        public int EventID { get; set; }
         // Foreign Key - Maps to the User Table
        [ForeignKey("User")]
        public int UserID { get; set; }
        
        // The place where the event will take place
        [ForeignKey("Location")]
        public int LocationID { get; set; }

        // Title for the event
        [Required]
        public string Title { get; set; }

        // Time stamp when the event was created
        [Required]
        public string CreatedAt { get; set; }

        // Time when the event will take place
        [Required]
        public DateTime DateAndTime { get; set; }

        // A general description of the event
        [Required]
        public string Description { get; set; }

        // OPTIONAL: An image for the event
        public string Image { get; set; }

        // Navigation Property
        public virtual UserProfile User { get; set; }
        public virtual Location Location { get; set; }
    }
}