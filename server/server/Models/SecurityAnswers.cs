using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class SecurityAnswers
    {
        public SecurityAnswers()
        {

        }
        [Key]
        public int SecurityQuestionID { get; set; }
        public string Answer { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
        [ForeignKey("SecurityQuestion")]
        public string Question { get; set; }
        public SecurityQuestions SecurityQuestion { get; set; }
    }
}