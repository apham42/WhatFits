using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public class Review
    {
        public Review()
        {

        }
        [ForeignKey("User")]
        // The reviews of that person
        public int ReviewerID { get; set; }
        public User User { get; set; }
        // This stores the ID of the person reviewing the user
        [Key]
        public int ReviewID {get;set;}
        // The reviews of that person
        public int RevieweeID { get; set; }
        public int Rating { get; set; }
        public string ReviewMessage { get; set; }
        public string DateTime { get; set; }
    }
}