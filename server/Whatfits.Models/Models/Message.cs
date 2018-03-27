using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// Models the message being sent
    /// </summary>
    public class Message : IMessage
    {
        //  Primary Key
        [Key, Column(Order = 0)]
        public int MessageID { get; set; }

        // Stores the message sent by user
        public string MessageContent { get; set; }

        // Time stamps the message
        public DateTime CreatedAt { get; set; }

        // Foreign Key, Tracks the User of the Message Sent
        [Key, Column(Order = 1)]
        public int UserID { get; set; }

        // Records the UserID of the person recieving the message
        public int ReceiverID { get; set; }
        // Navigation Property for User
        public virtual UserProfile User { get; set; }
    }
}