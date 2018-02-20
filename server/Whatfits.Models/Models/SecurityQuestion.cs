using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public class SecurityQuestion
    {
        public SecurityQuestion()
        {

        }
        // Primary Key
        public int SecurityQuestionID { get; set; }
        public string Question { get; set; }
        
    }
}