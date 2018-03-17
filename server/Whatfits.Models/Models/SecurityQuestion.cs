using System.ComponentModel.DataAnnotations;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the list of possible security
    /// questions stored in the system.
    /// </summary>
    public class SecurityQuestion
    {
        // Primary Key
        [Key, Required]
        public int SecurityQuestionID { get; set; }
        // Actual Questions Stored
        public string Question { get; set; }
    }
}