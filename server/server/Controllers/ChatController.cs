using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using System;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using System.Web.Http.Cors;
using server.Business_Logic.Services;

namespace server.Controllers
{
    /// <summary>
    /// Provides APIs for Chat for Clientside
    /// </summary>
    [RoutePrefix("v1/chat")]
    public class ChatController : ApiController
    {
        ChatDTO chatuser = new ChatDTO();
        ChatGateway mychat = new ChatGateway();
        private byte[] key = new byte[16];
        private byte[] iv = new byte[16];
        private Random randomkey = new Random();
        private Random randomiv = new Random();

        /// <summary>
        /// Provides local key value
        /// </summary>
        public byte[] Getkey()
        {
            randomkey.NextBytes(key);
            return key;
        }
        /// <summary>
        /// Provides local inivial value
        /// </summary>
        public byte[] Getiv()
        {
            randomiv.NextBytes(iv);
            return iv;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("connect")]
        [EnableCors("http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "Get")]
        public HttpResponseMessage Connect(string username)
        {
            chatuser.UserName = username;
            if (HttpContext.Current == null || !HttpContext.Current.IsWebSocketRequest)
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            if (mychat.DoesUserNameExists(chatuser))
            {
                HttpContext.Current.AcceptWebSocketRequest(new ChatService(username, Getkey(), Getiv()));
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        /// <summary>
        /// Provides websocket handler when chat connection called
        /// </summary>
        //class ChatHandler : WebSocketHandler
        //{
        //    private ChatGateway mychat = new ChatGateway();
        //    private static WebSocketCollection _chatUser = new WebSocketCollection();
        //    // user list for feature friends list
        //    private static List<string> friends = new List<string>();
        //    private string connectedUser;
        //    private byte[] _key;
        //    private byte[] _iv;
        //    /// <summary>
        //    /// ChatHandler initialization
        //    /// </summary>
        //    public ChatHandler(string username, byte[] key, byte[] iv)
        //    {
        //        connectedUser = username;
        //        if (!friends.Contains(connectedUser))
        //            // add new user to user list
        //            friends.Add(connectedUser);
        //        _key = key;
        //        _iv = iv;
        //    }
        //    /// <summary>
        //    /// Provides connection functionality
        //    /// Send back friends list and secrete key and initial value for encryption and decryption
        //    /// </summary>
        //    public override void OnOpen()
        //    {
        //        // check duplicate username
        //        if (!_chatUser.Contains(this))
        //            _chatUser.Add(this);
        //        // prepare send back string message
        //        var friends_info = "";

        //        // add friends
        //        int length = friends.Count;
        //        for (int i = 0; i < length; i++)
        //        {
        //            if (i > 0)
        //                friends_info += "," + friends[i];
        //            else
        //                friends_info += friends[i];
        //        }
        //        // for sending key
        //        for (int j = 0; j < _key.Length; j++)
        //        {
        //            friends_info += "," + _key[j];
        //        }
        //        // for sending iv
        //        for (int k = 0; k < _iv.Length; k++)
        //        {
        //            friends_info += "," + _iv[k];
        //        }
        //        // send friends information, key and initial value to connected user via websocket
        //        _chatUser.Broadcast(JsonConvert.SerializeObject(friends_info));
        //    }
        //    /// <summary>
        //    /// Provides receive message from server
        //    /// Send back 
        //    /// </summary>
        //    public override void OnMessage(string message)
        //    {
        //        var ser = new JavaScriptSerializer();
        //        var deser = ser.Deserialize<Message>(message);
        //        // get the index of receiver 
        //        //var index = friends.IndexOf(deser.UserName);
        //        // send to receiver
        //        if(!friends.Contains(deser.UserName))
        //        {
        //            Send(JsonConvert.SerializeObject("server"+ " said: " + "user-is-offline" + "  " + DateTime.Now.ToLocalTime()));
        //        }
        //        else
        //        {
        //            // type cast fine receiver's username in the websocket collection
        //            _chatUser.SingleOrDefault(r => ((ChatHandler)r).connectedUser == deser.UserName).Send(JsonConvert.SerializeObject(connectedUser + " said: " + deser.MessageContent + "  " + DateTime.Now.ToLocalTime()));
        //        }
        //    }
        //    /// <summary>
        //    /// Error handler
        //    /// </summary>
        //    public override void OnError()
        //    {
        //        base.OnError();
        //    }
        //    /// <summary>
        //    /// Provides disconnection functionality
        //    /// remove connected user from websocket user collection
        //    /// </summary>
        //    public override void OnClose()
        //    {
        //        _chatUser.Remove(this);
        //        friends.Remove(this.connectedUser);
        //    }
        //}
    }

    
}
