using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Review
    {
        public Review()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public int Reviewee { get; set; }
        [Key]
        public int ReviewID {get;set;}
        public int Rating { get; set; }
        public string ReviewMessage { get; set; }
        public string DateTime { get; set; }


    }
}