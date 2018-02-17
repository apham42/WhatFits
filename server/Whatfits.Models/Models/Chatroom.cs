using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Chatroom
    {
        public Chatroom()
        {

        }
        // Primary Key
        public int ChatroomID { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        // A chat can have multiple Messages
        ICollection<Message> Messages { get; set; }
    }
}