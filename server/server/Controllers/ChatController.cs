using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using Whatfits.Models.Models;
using System;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.DataAccess.DataTransferObjects.ContentDTOs;

namespace server.Controllers
{
    public class ChatController : ApiController
    {
        [AcceptVerbs ("GET","POST")]
        public HttpResponseMessage Connect(string username)
        {
            ChatDTO chatuser = new ChatDTO();
            chatuser.UserName = username;
            ChatGateway mychat = new ChatGateway();
            if (!HttpContext.Current.IsWebSocketRequest)
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            if (mychat.DoesUserNameExists(chatuser))
            {
                HttpContext.Current.AcceptWebSocketRequest(new ChatHandler(username));
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
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
