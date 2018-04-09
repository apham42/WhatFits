using System;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class ChatDTO : IMessage
    {
        // Contains the message
        public string MessageContent { get; set;}
        // Contains the UserName of the User
        public string UserName { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserID { get; set; }

        public int ChatroomID { get; set; }
    }
}
