using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using System.Web.SessionState;
using System;

namespace server.Controllers
{
    public class ChatController : ApiController
    {
        [AcceptVerbs ("GET","POST")]
        public HttpResponseMessage Connect(string username)
        {
            if (!HttpContext.Current.IsWebSocketRequest)
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            HttpContext.Current.AcceptWebSocketRequest(new ChatHandler(username));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }
        
        class ChatHandler : WebSocketHandler
        {
            private static WebSocketCollection _chatUser = new WebSocketCollection();
            private string connectedUser;

            public ChatHandler(string username)
            {
                connectedUser = username;
            }

            public override void OnOpen()
            {
                _chatUser.Add(this);
            }

            public override void OnMessage(string message)
            {
                _chatUser.Broadcast(connectedUser + " said: " + message + "  \n" +DateTime.Now.ToLocalTime());
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
