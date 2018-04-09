using System.ComponentModel.DataAnnotations;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the list of possible security
    /// questions stored in the system.
    /// </summary>
    public class SecurityQuestion : ISecurityQuestions
    {
        // Primary Key
        [Key]
        public int SecurityQuestionID { get; set; }

        // Actual Questions Stored
        public string Question { get; set; }
    }
}