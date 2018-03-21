namespace Whatfits.Models.Interfaces
{
    public interface IMessage
    {
        // Stores the message sent by user
        string MessageContent { get; set; }

        // Time stamps the message
        string CreatedAt { get; set; }

        // Foreign Key, Tracks the User of the Message Sent
        int UserID { get; set; }

        // Records the ChatroomID
        int ChatroomID { get; set; }
    }
}
