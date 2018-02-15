using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Chat
    {
        public Chat()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public int ReceiverID { get; set; }
        [Key]
        public int ChatID { get; set; }
        public string DateTime { get; set; }



    }
}