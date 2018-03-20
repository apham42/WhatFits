using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the model for location
    /// </summary>
    public class Location
    {
        // Primary Key
        [Key]
        public int LocationID { get; set; }

        // Stores the Address of the User
        [Required]
        public string Address { get; set; }

        // Stores the City of the User
        [Required]
        public string City { get; set; }

        // Stores the State of the User
        [Required]
        public string State { get; set; }

        // Stores the Zipcode of the User
        [Required]
        public string Zipcode { get; set; }

        // Stores the Latitude coordinate
        [Required]
        public string Latitude { get; set; }
        // Stores the Longitude coordinate
        [Required]
        public string Longitude { get; set; }

        // Location can have many users
        ICollection<UserProfile> Users { get; set; }
    }
}
