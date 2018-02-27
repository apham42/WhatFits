using server.Service;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using Xunit;

namespace server.Controllers
{
    public class ChatController : Controller
    {
        SocketHandler socketHandler = new SocketHandler();
        // GET: Chat
        /*
        [HttpGet]
        public ActionResult Chat(User user, User friend)
        {
            if (HttpContext.IsWebSocketRequest)
            {
                Chatroom chatroom = socketHandler.Getroom(user,friend);
                return RedirectToAction("Chat");
            }
            return View();
        }
        */
        [HttpGet]
        public ActionResult Index()
        {
            if(HttpContext.IsWebSocketRequest)
            {
                //return httpContext.AcceptWebSocketRequest(ProcessWebSocket);
                return PartialView(socketHandler);
            }

            else
            {
                var result = new HttpStatusCodeResult(404);
                return result;
            }

        }
        /*
        private Task ProcessWebSocket(AspNetWebSocketContext aspNetWebSocketContext)
        {
            var process = socketHandler.ProcessWebSocketRequestAsync(aspNetWebSocketContext);
            return process;
        }
        /*
        [HttpPost]
        public string SendMessage(User user, Message message, User friend)
        {
            try
            {
                Chatroom chatroom = socketHandler.Getroom(user, friend);
                string respond = "";
                if(chatroom != null)
                {
                    respond = chatroom.SendMessage(user,message,friend);
                }
                return respond;
            }
            catch(Exception ex)
            {
                return "";
            }

        }
        /*
        [HttpPost]
        public ActionResult LeaveRoom(User friend)
        {

        }
        */
    }
}