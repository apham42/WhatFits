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
    /// Provides APIs for Chat Clientside
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
    }

    
}
