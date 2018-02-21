using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Chatroom
    {
        public int ChatId { get; set; }
        private User[] _joined;
        private int _joinedIndex;

        public Chatroom (int chatid)
        {
            ChatId = chatid;
        }

        public bool AddUser (User user)
        {
            if(_joinedIndex < _joined.Length)
            {
                _joined[_joinedIndex] = user;
                _joinedIndex++;
                return true;
            }

            return false;
        }
    }
}