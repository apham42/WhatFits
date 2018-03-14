using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents the table where all 
    /// security questions are mapped to 
    /// </summary>
    public class SecurityQandA
    {
        // Answer Stored to a question 
        [Required, StringLength(100, MinimumLength = 2)]
        public string Answer { get; set; }

        // Foreign Key - Maps to the User Table
        [Key, Column(Order = 1)]
        public int UserID { get; set; }

        // Foreign Key - Maps to the Security Table
        [Key, Column(Order = 2)]
        public int SecurityQuestionID { get; set; }

        // Navigation Property for Security Question
        public virtual SecurityQuestion SecurityQuestion { get; set; }
        // Navigation Property for User
        public virtual Credential Credential { get; set; }
    }
}
