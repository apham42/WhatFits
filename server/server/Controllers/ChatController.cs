using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using server.Service;
using System.Web.Mvc;
using Whatfits.Models;

namespace server.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        [HttpPost]
        public ActionResult Chat(User user, User friend)
        {
            SocketHandler socketHandler = new SocketHandler();
            if (HttpContext.IsWebSocketRequest)
            {
                Chatroom chatroom = socketHandler.Getroom(user,friend);
                return RedirectToAction("Chat");
            }
            return View();
        }
        /*
        [HttpPost]
        public ActionResult SendMessage(Message message, User friend)
        {

        }

        [HttpPost]
        public ActionResult LeaveRoom(User friend)
        {

        }
        */
    }
}