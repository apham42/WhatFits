using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;

namespace server.Controllers
{
    public class DefaultController : ApiController
    {
        public HttpResponseMessage Get(string username)
        {
            try
            {
                //return Request.CreateResponse(HttpStatusCode.Found);
                HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username));
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data found");
            }
        }

        class ChatWebSocketHandler : WebSocketHandler
        {
            private static WebSocketCollection _chatClients = new WebSocketCollection();
            private string _username;

            public ChatWebSocketHandler(string username)
            {
                _username = username;
            }

            public override void OnOpen()
            {
                _chatClients.Add(this);
            }

            public override void OnMessage(string message)
            {
                _chatClients.Broadcast(_username + ": " + message); 
            }
        }
    }
}
