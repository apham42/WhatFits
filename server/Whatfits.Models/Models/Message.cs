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
        [Key]
        public int MessageID { get; set; }

        // Receiver
        public string UserName { get; set; }

        // Stores the message sent by user
        [Required]
        public string MessageContent { get; set; }

        // Time stamps the message
        public DateTime CreatedAt { get; set; }

        // Foreign Key, Tracks the User of the Message Sent
        [ForeignKey("UserProfile")]
        public int UserID { get; set; }

        // Records the UserID of the person recieving the message
        [Required]
        public int ReceiverID { get; set; }
        // Navigation Property for User
        public virtual UserProfile UserProfile { get; set; }
    }
}