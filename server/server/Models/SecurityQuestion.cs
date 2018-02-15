using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class SecurityQuestion
    {
        public SecurityQuestion()
        {

        }
        [ForeignKey("User")]
        public int Id { get; set; }
        public string[] Questions { get; set; }
    }
}