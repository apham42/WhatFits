using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models.Models
{
    public class Notification
    {
        public Notification()
        {

        }
        // Primary Key
        public int NotificationID { get; set; }
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }

        public string NotificationType { get; set; }
        public string Message { get; set; }
    }
}
