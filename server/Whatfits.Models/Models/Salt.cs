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
    /// This model represents the Salt table where each salt 
    /// is mapped to one and only one user.
    /// </summary>
    public class Salt
    {
        // Primary and Foreign Key of this Model
        [Key, ForeignKey("Credential")]
        public int UserID { get; set; }

        // This stores the Salt value for each user
        [Required]
        public string SaltValue { get; set; }
        // Navigation Property to Credential Model
        [Required]
        public virtual Credential Credential { get; set; }
    }
}
