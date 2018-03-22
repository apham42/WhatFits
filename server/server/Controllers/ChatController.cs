using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using Whatfits.Models.Models;
using System;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.DataAccess.DataTransferObjects.ContentDTOs;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Linq;

namespace server.Controllers
{
    public class ChatController : ApiController
    {
        ChatDTO chatuser = new ChatDTO();
        ChatGateway mychat = new ChatGateway();

        [AcceptVerbs ("GET","POST")]
        public HttpResponseMessage Connect(string username)
        {
            chatuser.UserName = username;
            if (!HttpContext.Current.IsWebSocketRequest)
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            if (mychat.DoesUserNameExists(chatuser))
            {
                HttpContext.Current.AcceptWebSocketRequest(new ChatHandler(username));
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        class ChatHandler : WebSocketHandler , IDisposable
        {
            private ChatGateway mychat = new ChatGateway();
            private static WebSocketCollection _chatUser = new WebSocketCollection();
            private static List<string> users = new List<string>();
            private string connectedUser;

            public ChatHandler(string username)
            {
                connectedUser = username;
                if(!users.Contains(connectedUser))
                    users.Add(connectedUser);
            }

            public override void OnOpen()
            {
                if(!_chatUser.Contains(this))
                    _chatUser.Add(this);
                string output = "";
                int length = users.Count;
                for (int i = 0; i < length; i++)
                    if (i > 0)
                        output += "," + users[i];
                    else
                        output += users[i];
                _chatUser.Broadcast(JsonConvert.SerializeObject(output));
            }

            public override void OnMessage(string message)
            {
                var ser = new JavaScriptSerializer();
                var deser = ser.Deserialize<Message>(message);
                // get the index of receiver 
                var index = users.IndexOf(deser.UserName);
                // send to receiver
                _chatUser.ElementAtOrDefault(index).Send(JsonConvert.SerializeObject(connectedUser + " said: " + deser.MessageContent + " \n" + DateTime.Now.ToLocalTime()));
                
            }

            public override void OnError()
            {
                base.OnError();
            }

            public override void OnClose()
            {
                _chatUser.Remove(this);
                users.Remove(connectedUser);
            }

            public void Dispose()
            {
                _chatUser.Clear();
            }
        }
    }

    
}
