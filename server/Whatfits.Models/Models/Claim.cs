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
    /// This model represents the list of claims
    /// in our system. Each user will be assigned 
    /// a list of claims to determine what they can do in
    /// the system.
    /// </summary>
    public class Claim
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
