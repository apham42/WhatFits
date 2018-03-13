using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the UserClaims table for each User.
    /// Each user will have a list of claims to determine what 
    /// they can do in this system.
    /// </summary>
    public class UserClaims
    {
        // Primary Key for UserClaims
        //  [Key]
        // public int UserClaimsID { get; set; }

        // Foreign Key to Claims Model
        [Key, Column(Order = 0)]
        public int ClaimID { get; set; }

        // Foreign Key to User Model
        [Key, Column(Order = 1)]
        public int UserID { get; set; }

        // Navigation Property to User Model
        public virtual User User { get; set; }

        // Navigation Property to Claims Model
        public virtual Claim Claims { get; set; }
    }
}
