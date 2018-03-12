using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [ForeignKey("User")]
        // Foreign Key to User Table
        public int UserID { get; set; }

        // Navigation Property
        public User User { get; set; }

        // Location can have many users
        ICollection<User> Users { get; set; }
    }
}
