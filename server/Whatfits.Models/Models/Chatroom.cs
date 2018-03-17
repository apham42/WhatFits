using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Chatroom
    {
        // Primary Key
        [Key]
        public int ChatroomID { get; set; }
        // Name of the chatroom
        [Required]
        public string Name { get; set; }
        // Records the time Chatroom was created
        [Required]
        public string CreatedAt { get; set; }
        // Navigation Property to Message
        ICollection<Message> Message { get; set; }
    }
}