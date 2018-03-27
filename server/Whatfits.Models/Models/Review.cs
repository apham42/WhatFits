using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// Review Model
    /// Purpose: To model a table where it keeps a record of all the reviews left
    /// by users to other users.
    /// </summary>
    public class Review : IReview
    {
        // Foreign Key that maps to the User Leaving the review
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        
        
        // This stores the ID of the person reviewing the user
        [Key, Column(Order = 1)]
        public int ReviewID { get; set; }
        
        // Required ID of the other user being reviewed
        [Required]
        public int RevieweeID { get; set; }

        // Records rating with a 1-5 rating
        [Required]
        public int Rating { get; set; }

        // Records the message of the review of the other user
        [Required]
        public string ReviewMessage { get; set; }

        // Records the DateTime when the review was created
        [Required]
        public DateTime DateAndTime { get; set; }

        // Navigation Property back to User model
        public UserProfile User { get; set; }
    }
}