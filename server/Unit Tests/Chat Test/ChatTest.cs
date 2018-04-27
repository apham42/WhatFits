using Xunit;
using server.Controllers;
using Microsoft.Web.WebSockets;
using server.Business_Logic.Services;
using System.Web.Script.Serialization;
using Whatfits.Models.Models;

namespace ChatTest
{
    
    public class ChatTest
    {
        [Fact]
        public void Connect()
        {
            // Arrange
            ChatController chatController = new ChatController();

            // Action
            var response = chatController.Connect("amay").IsSuccessStatusCode;

            // Result
            Assert.False(response);
        }

        [Fact]
        public void SendMessage()
        {
            // Arrange
            ChatController chatController = new ChatController();
            WebSocketCollection chatUser = new WebSocketCollection();
            ChatService chatHandler = new ChatService("amay");
            var serialization = new JavaScriptSerializer();
            chatUser.Add(chatHandler);
            var Jmsg = "{\"Username\":\"rblue\",\"MessageContent\":\"this is send test\"}";

            // Action
            chatHandler.OnMessage(Jmsg);

            // Result
            Assert.True(chatHandler.GetSendStatus());
        }

        [Fact]
        public void Disconnect()
        {
            // Arrange
            ChatController chatController = new ChatController();
            WebSocketCollection chatUser = new WebSocketCollection();
            ChatService chatHandler = new ChatService("amay");
            chatUser.Add(chatHandler);

            // Action
            chatHandler.OnClose();

            // Result
            Assert.True(chatHandler.GetDisconnectStatus());
        }

    }
}
