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
    /// This model represents the credentials of the user. Each user is
    /// mapped to one credential object.
    /// </summary>
    public class Credential
    {
        // Primary and Foreign Key, maps to the User Class in a 1 to 1 relationship
        [Key]
        public int UserID { get; set; }

        // Stores the Username of the User
        [Required, StringLength(64, MinimumLength = 2)]
        public string UserName { get; set; }

        // Stores the hash of the password of the User
        [Required, StringLength(64, MinimumLength = 2)]
        public string Password { get; set; }

        // Tracks the status of the account such as Disabled or Enabled.
        [Required]
        public Boolean IsBanned { get; set; }

        // Tracks if the user is fully registered or not
        [Required]
        public Boolean IsFullyRegistered { get; set; }

        // Navigation Property to the User Class
        public virtual User User { get; set; }
        public ICollection<UserClaims> UserClaims { get; set; }
        public ICollection<SecurityQandA> SecurityQandAs { get; set; }
    }
}
