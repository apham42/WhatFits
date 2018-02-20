using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models
{
    public class SecurityAnswer
    {
        public SecurityAnswer()
        {

        }
        // Primary Key
        public int SecurityAnswerID { get; set; }
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }

        public int SecurityQuestionID { get; set; }
        public SecurityQuestion SecurityQuestion { get; set; }

        public string Answer { get; set; }
    }
}
