using Microsoft.Web.WebSockets;
using System.Linq;
using Whatfits.Models;
using Newtonsoft.Json;

namespace server.Service
{
    public class SocketHandler : WebSocketHandler
    {
        private static WebSocketCollection _wsClients = new WebSocketCollection();

        public override void OnOpen()
        {
            _wsClients.Add(this);
            base.OnOpen();
        }

        public override void OnClose()
        {
            _wsClients.Remove(this);
            base.OnClose();
        }

        public void SendMessage(Message message, User friend)
        {
            string friendId = friend.ID;
            var webSockets = _wsClients.Where(s =>
           {
               var httpCookie = s.WebSocketContext.Cookies["FriendId"];
               return httpCookie != null && httpCookie.Value == friendId;
           });

            foreach (var socket in webSockets)
            {
                socket.Send(JsonConvert.SerializeObject(message));
            }

        }

        /*
        public Chatroom Getroom(User user, User friend)
        {
            Chatroom chatroom = null;

            chatroom = new Chatroom(user, friend);

            return chatroom;
            
        }

        public string Createchatroom(User user, User friend)
        {
            int userid = user.ID;
            int friendid = friend.ID;

            return userid + ";" + friendid;
        }

        public void Deletechatroom(string roomid)
        {

        }
        */
    }
}