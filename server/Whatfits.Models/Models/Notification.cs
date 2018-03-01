using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models.Models
{
    class Notification
    {
        // Primary Key

        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }

        public string type;
        public string message;
    }
}
