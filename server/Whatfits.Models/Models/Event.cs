using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public class Event
    {
        public Event()
        {

        }
        // Primary Key
        public int EventID { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string CreatedAt { get; set; }
        // Note: Should I create a DateTime table and record date and time
        public string DateTime { get; set; }
        public string Description { get; set; }
        // Note: For image uploads for event banner
        //public byte[] Image { get; set; }
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }
        // Note: Possible enhancement is having a list of people who are going
        // to the event. 
    }
}