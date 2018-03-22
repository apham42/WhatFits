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
        private  byte[] key = new byte[16];
        private  byte[] iv = new byte[16];
        private  Random randomkey = new Random();
        private  Random randomiv = new Random();

        public byte[] Getkey()
        {
           randomkey.NextBytes(key);
           return key;
        }

        public byte[] Getiv()
        {
           randomiv.NextBytes(iv);
            return iv;
        }

        [AcceptVerbs ("GET","POST")]
        public HttpResponseMessage Connect(string username)
        {
            chatuser.UserName = username;
            if (!HttpContext.Current.IsWebSocketRequest)
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            if (mychat.DoesUserNameExists(chatuser))
            {
                HttpContext.Current.AcceptWebSocketRequest(new ChatHandler(username,Getkey(),Getiv()));
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
            private byte[] _key;
            private byte[] _iv;

            public ChatHandler(string username, byte[] key, byte[] iv)
            {
                connectedUser = username;
                if(!users.Contains(connectedUser))
                    users.Add(connectedUser);
                _key = key;
                _iv = iv;
            }

            public override void OnOpen()
            {
                
                if(!_chatUser.Contains(this))
                    _chatUser.Add(this);
                var userlist = "";
                int length = users.Count;
                for (int i = 0; i < length; i++)
                {
                    if (i > 0)
                        userlist += "," + users[i];
                    else
                        userlist += users[i];
                }
                // for sending key
                for (int j = 0; j < _key.Length; j++)
                {
                        userlist += "," + _key[j];
                }
                // for sending iv
                for (int k = 0; k < _iv.Length; k++)
                {
                        userlist += "," + _iv[k];
                }
                
                _chatUser.Broadcast(JsonConvert.SerializeObject(userlist));
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
