namespace Whatfits.Models.Interfaces
{
    public interface IChatroom
    {
        // Name of the chatroom
        string Name { get; set; }

        // Records the time Chatroom was created
        string CreatedAt { get; set; }
    }
}
