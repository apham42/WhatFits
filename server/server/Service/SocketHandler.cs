using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Whatfits.Models;

namespace server.Service
{
    public class SocketHandler : IHttpHandler
    {
        public bool IsReusable => throw new NotImplementedException();

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public Chatroom Getroom(User user, User friend)
        {
            Chatroom chatroom = null;

            chatroom = new Chatroom(user, friend);

            return chatroom;
            
        }

    }
}