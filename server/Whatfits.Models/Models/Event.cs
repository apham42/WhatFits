using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the table where all events
    /// are stored.
    /// </summary>
    public class Event
    {
        // Foreign Key - Maps to the User Table
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        // The place where the event will take place
        [Required]
        public string Location { get; set; }

        // Title for the event
        [Required]
        public string Title { get; set; }

        // Time stamp when the event was created
        [Required]
        public string CreatedAt { get; set; }

        // Time when the event will take place
        [Required]
        public string DateTime { get; set; }

        // A general description of the event
        [Required]
        public string Description { get; set; }

        // OPTIONAL: An image for the event
        public byte[] Image { get; set; }

        // Navigation Property
        public User User { get; set; }
    }
}