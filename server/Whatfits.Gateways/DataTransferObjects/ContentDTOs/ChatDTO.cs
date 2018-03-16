using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DataTransferObjects.ContentDTOs
{
    public class ChatDTO
    {
        // All the data for a message
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string MessageContent {
            get
            {
                return MessageContent;
            }
            set
            {
                MessageContent = value;
            }
        }
    }
}
