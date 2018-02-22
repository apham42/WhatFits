using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public class Chatroom
    {
        public Chatroom(User user, User friend)
        {
            ChatroomID = user.ID + friend.ID;
            CreatedAt = DateTime.Now.ToLongDateString();
        }
        // Primary Key
        public int ChatroomID { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        // A chat can have multiple Messages
        ICollection<Message> Messages { get; set; }
    }
}