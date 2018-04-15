using System.Collections.Generic;
using Xunit;
using server.Model.Account;
using server.Model.Location;
using server.Services;
using server.Controllers;
using System.Web;
using Microsoft.Web.WebSockets;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using System.Net.Http;
using System.IO;
using System;

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
            WebSocketCollection chatUser = new WebSocketCollection();
            WebSocketHandler chatHandler = new WebSocketHandler();
            chatUser.Add(chatHandler);

            // Action
            chatHandler.Send("this is send test");

            // Result

        }

        [Fact]
        public void ReceiveMessage()
        {
            // Arrange
            WebSocketCollection chatUser = new WebSocketCollection();
            WebSocketHandler chatHandler = new WebSocketHandler();
            chatUser.Add(chatHandler);

            // Action
            chatHandler.Send("this is receive test");

            // Result

        }

        [Fact]
        public void Disconnect()
        {

        }

    }
}
