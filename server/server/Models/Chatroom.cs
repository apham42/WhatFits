using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Chatroom
    {
        public int ChatId { get; }
        private User[] _joined;
        private int _joinedIndex;

        public Chatroom (int chatid)
        {
            ChatId = chatid;
            _joined = new User[2];
            _joinedIndex = 0;
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

        public bool DeleteUser (User user)
        {

        }

        public bool Send (Message message, User user)
        {
            //Encrypt
        }

        public bool Receive (Message message)
        {
            //Decrypt
        }
    }
}