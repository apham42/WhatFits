using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// Models the message being sent
    /// </summary>
    public class Message
    {
        //  Primary Key
        [Key, Column(Order = 0)]
        public int MessageID { get; set; }

        // Stores the message sent by user
        public string MessageContent { get; set; }

        // Time stamps the message
        public string CreatedAt { get; set; }

        // Foreign Key, Tracks the User of the Message Sent
        [Key, Column(Order = 1)]
        public int UserID { get; set; }

        // Records the ChatroomID
        [Key, Column(Order = 2)]
        public int ChatroomID { get; set; }

        // Navigation Property for Chatroom
        public virtual Chatroom Chatroom { get; set; }

        // Navigation Property for User
        public virtual UserProfile User { get; set; }
    }
}