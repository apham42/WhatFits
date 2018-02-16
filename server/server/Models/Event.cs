using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Event
    {
        public Event()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
        [Key]
        public int EventID { get; set; }
        // Public Event
        public string Location { get; set; }
        // Ask Abram about the location data
    }
}