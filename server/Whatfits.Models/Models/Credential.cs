using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the credentials of the user. Each user is
    /// mapped to one credential object.
    /// </summary>
    public class Credential
    {
        // Primary Key
        [Key]
        public int UserID { get; set; }

        // Stores the Username of the User
        [Required, StringLength(64, MinimumLength = 2)]
        public string UserName { get; set; }

        // Stores the hash of the password of the User
        [Required]
        public string Password { get; set; }
        
        // A Credential can have many:
        public ICollection<UserClaims> UserClaims { get; set; }
        public ICollection<SecurityQandA> SecurityQandAs { get; set; }
    }
}
