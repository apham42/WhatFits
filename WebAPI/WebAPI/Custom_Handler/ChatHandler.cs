using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace WebAPI.Custom_Handler
{
    public class ChatHandler : IHttpHandler
    {
        // Whether same of instance of HTTP Handler can be used to fulfill another request of same type
        // For performance leave this as default not reuseable to let Garbage Collector easily handle
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if(context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(ProcessWSChat);
            }
        }

        public async Task ProcessWSChat(AspNetWebSocketContext context)
        {
            try
            {
                WebSocket webSocket = context.WebSocket;
                while(true)
                {
                    ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(
                        buffer, CancellationToken.None);
                    if (webSocket.State == WebSocketState.Open)
                    {
                        string userMessage = Encoding.UTF8.GetString(
                            buffer.Array, 0, result.Count);
                        userMessage = "You sent: " + userMessage + " at " +
                            DateTime.Now.ToLongTimeString();
                        buffer = new ArraySegment<byte>(
                            Encoding.UTF8.GetBytes(userMessage));
                        await webSocket.SendAsync(
                            buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
                
            }
            catch (Exception e)
            {

            }
        }
    }
}