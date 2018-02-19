using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public class Message
    {
        public Message()
        {

        }
        // Primary Key
        public int MessageID { get; set; }
        // Foreign Key
        public int UserID { get; set; }
        // Navigation Property of User
        public User User { get; set; }
        // Foreign Key
        public int ChatroomID { get; set; }
        // Navigation Property of ChatID
        public Chatroom Chatroom { get; set; }
        public string MessageContent { get; set; }
        public string CreatedAt { get; set; }
    }
}