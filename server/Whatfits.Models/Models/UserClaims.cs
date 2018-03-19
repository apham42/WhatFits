using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the UserClaims table for each User.
    /// Each user will have a list of claims to determine what 
    /// they can do in this system.
    /// </summary>
    public class UserClaims
    {
        // Primary Key to Claims Model
        [Key]
        public int ClaimID { get; set; }

        // Foreign Key to User Model
        [ForeignKey("Credential")]
        public int UserID { get; set; }

        // Stores the Claim Value
        public string ClaimValue { get; set; }

        // Stores the Claim Type
        public string ClaimType { get; set; }

        // Navigation Property to User Model
        public virtual Credential Credential { get; set; }
    }
}
