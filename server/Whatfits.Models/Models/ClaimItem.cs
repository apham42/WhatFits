using System;
using System.ComponentModel.DataAnnotations;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the list of claims
    /// in our system. Each user will be assigned 
    /// a list of claims to determine what they can do in
    /// the system.
    /// </summary>
    public class ClaimItem
    {
        // Primary Key
        [Key]
        public int ClaimID { get; set; }

        // Stores the type of claim
        [Required, StringLength(80, MinimumLength = 2)]
        public String ClaimType { get; set; }

        // Stores the value of the claim
        [Required, StringLength(80, MinimumLength = 2)]
        public String ClaimValue { get; set; }
    }
}
