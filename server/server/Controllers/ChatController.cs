using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace server.Controllers
{
    public class ChatController : Controller
    {
        
        // GET: Chat
        public HttpResponseMessage Get()
        {
            if (HttpContext.IsWebSocketRequest)
            {
                HttpContext.AcceptWebSocketRequest(SendMessage);
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }


         
        [HttpPost]
        public JsonResult SendMessage (string message, string friend)
        {
            
            return Json(null);
        }

        [HttpPost]
        public JsonResult receive()
        {
            try
            {

                return Json(message);
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}