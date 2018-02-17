using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; }
        public string Time { get; set; }
        public string Content { get; set; }

        public Message (int messageid, int userid, string content, string time)
        {
            MessageId = messageid;
            UserId = userid;
            time = DateTime.Now.ToLongDateString();
            Time = time;
            Content = content;
            
        }
    }
}