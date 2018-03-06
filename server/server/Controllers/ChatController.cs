using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;

namespace server.Controllers
{
    public class ChatController : ApiController
    {
        [AcceptVerbs ("GET","POST")]
        public HttpResponseMessage Connect()
        {
            if (!HttpContext.Current.IsWebSocketRequest)
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);

            HttpContext.Current.AcceptWebSocketRequest(new ChatHandler());
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }
        
        class ChatHandler : WebSocketHandler
        {
            private static WebSocketCollection _chatUser = new WebSocketCollection();
            private string connectedUser;

            public ChatHandler()
            {
            }

            public override void OnOpen()
            {
                _chatUser.Add(this);
            }

            public override void OnMessage(byte[] message)
            {
                _chatUser.Broadcast(": " + message);
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
