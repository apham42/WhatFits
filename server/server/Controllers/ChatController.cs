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
using server.Controllers.Constants;

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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, "Get")]
        public HttpResponseMessage Connect(string username)
        {
            chatuser.UserName = username;
            if (HttpContext.Current == null || !HttpContext.Current.IsWebSocketRequest)
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            if (mychat.DoesUserNameExists(chatuser))
            {
                HttpContext.Current.AcceptWebSocketRequest(new ChatService(username));
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    } 
}
