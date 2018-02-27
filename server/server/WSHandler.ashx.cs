using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace server
{
    /// <summary>
    /// Summary description for WSHandler
    /// To host a WebSocket server, I create a custom HTTP handler to accept client WebSocket connection requests and communicate with the client.
    /// </summary>
    [AllowCrossSite]
    public class WSHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // I check whether HttpContext.IsWebSocketRequest is true. 
            // True means the request is an AspNetWebSocket (System.Web.WebSockets) request. 
            // Then, call HttpContext.AcceptWebSocketRequest to accept the request and establish the connection. 
            // Pass in a method as the argument. 
            // This method contains code to do the duplex communication through AspNetWebSocketContext.WebSocket. 
            // just echo what the client has sent to the server.
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(ProcessWSChat);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private async Task ProcessWSChat(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            while(true)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(
                    buffer, CancellationToken.None);
                if (socket.State == WebSocketState.Open)
                {
                    string userMessage = Encoding.UTF8.GetString(
                        buffer.Array, 0, result.Count);
                    userMessage = "You sent: " + userMessage + " at " + DateTime.Now.ToLongTimeString();
                    buffer = new ArraySegment<byte>(
                        Encoding.UTF8.GetBytes(userMessage));
                    await socket.SendAsync(
                        buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                    break;
            }
        }
    }
}