namespace Whatfits.Models.Interfaces
{
    public interface INotification
    {
        // Stores the Notification type ei: Chat
        string NotificationType { get; set; }

        // Stores the Message of the Notification ie: John Doe has messaged you
        string Message { get; set; }
    }
}
