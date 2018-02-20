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
        public int UserID { get; set; }
        public User User { get; set; }
        // This stores the ID of the person reviewing the user
        public int Reviewee { get; set; }
        [Key]
        public int ReviewID {get;set;}
        public int Rating { get; set; }
        public string ReviewMessage { get; set; }
        public string DateTime { get; set; }


    }
}