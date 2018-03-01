using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;

namespace server.Controllers
{
    public class ChatController : ApiController
    {
        public HttpResponseMessage Get(string username, int roomid)
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatHandler(username, roomid));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }
        
        class ChatHandler : WebSocketHandler
        {
            private static WebSocketCollection _chatUser = new WebSocketCollection();
            private string _userName;
            private int _roomId;

            public ChatHandler(string username, int roomid)
            {
                _userName = username;
                _roomId = roomid;
            }

            public override void OnOpen()
            {
                _chatUser.Add(this);
            }

            public override void OnMessage(byte[] message)
            {
                _chatUser.Broadcast(_userName + ": " + message);
            }

            public override void OnError()
            {
                base.OnError();
            }

            public override void OnClose()
            {
                _chatUser.Remove(this);
            }
        }
    }

    
}
