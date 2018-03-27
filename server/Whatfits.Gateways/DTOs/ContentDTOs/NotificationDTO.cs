using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class NotificationDTO : INotification
    {
        public string NotificationType { get; set; }
        public string Message { get; set; }
    }
}
