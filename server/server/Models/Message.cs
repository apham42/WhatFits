using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Message
    {
        public Message()
        {

        }
        [ForeignKey("Chat")]
        public int ChatID { get; set; }
        [Key]
        public int MessageID { get; set; }
        public string MessageContent { get; set; }
        public string DateTime { get; set; }
    }
}