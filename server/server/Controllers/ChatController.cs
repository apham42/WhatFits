using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace server.Controllers
{
    public class ChatController : Controller
    {
        DataLayer dl = new DataLayer();
        // GET: Chat
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