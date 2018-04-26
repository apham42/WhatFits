using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Whatfits.Models.Models;
using Newtonsoft.Json;
using Whatfits.DataAccess.Gateways.ContentGateways;

namespace server.Business_Logic.Services
{
    /// <summary>
    /// Provides websocket handler when chat connection called
    /// </summary>
    public class ChatService: WebSocketHandler
    {
        private ChatGateway mychat = new ChatGateway();
        private static WebSocketCollection _chatUser = new WebSocketCollection();
        // user list for feature friends list
        private static List<string> friends = new List<string>();
        private string connectedUser;

        // check the success status of the Connect, Send and Disconnect method
        private bool connectSuccess = false;
        private bool sendSuccess = false;
        private bool disconnectSuccess = false;
        /// <summary>
        /// ChatHandler initialization
        /// </summary>
        public ChatService(string username)
        {
            connectedUser = username;
            if (!friends.Contains(connectedUser))
                // add new user to user list
                friends.Add(connectedUser);
        }
        /// <summary>
        /// Provides connection functionality
        /// Send back friends list and secrete key and initial value for encryption and decryption
        /// </summary>
        public override void OnOpen()
        {
            // check duplicate username
            if (!_chatUser.Contains(this))
            {
                _chatUser.Add(this);
                connectSuccess = true;
            }
            else
            {
                connectSuccess = false;
            }
        }
        /// <summary>
        /// Provides receive message from server
        /// Send back 
        /// </summary>
        public override void OnMessage(string message)
        {
            var ser = new JavaScriptSerializer();
            var deser = ser.Deserialize<Message>(message);

            // send to receiver
            if (!friends.Contains(deser.UserName))
            {
                try
                {
                    // if receiver is not online
                    _chatUser.Broadcast(" ");
                    sendSuccess = false;
                }
                catch(Exception)
                {
                    sendSuccess = false;
                }
            }
            else // receiver is online
            {
                // type cast fine receiver's username in the websocket collection
                try
                {
                    _chatUser.SingleOrDefault(r => ((ChatService)r).connectedUser == deser.UserName).Send(JsonConvert.SerializeObject(connectedUser + " said: " + deser.MessageContent + "  " + DateTime.Now.ToLocalTime()));
                    sendSuccess = true;
                }
                catch(Exception)
                {
                    sendSuccess = false;
                }
            }
        }
        /// <summary>
        /// Error handler
        /// </summary>
        public override void OnError()
        {
            base.OnError();
        }
        /// <summary>
        /// Provides disconnection functionality
        /// remove connected user from websocket user collection
        /// </summary>
        public override void OnClose()
        {
            try
            {
                _chatUser.Remove(this);
                friends.Remove(this.connectedUser);
                disconnectSuccess = true;
            }
            catch(Exception)
            {
                disconnectSuccess = false;
            }
            
        }
        /// <summary>
        /// return connection status
        /// </summary>
        /// <returns>connection status</returns>
        public bool GetConnectStatus()
        {
            return connectSuccess;
        }
        /// <summary>
        /// return send success status
        /// </summary>
        /// <returns>send success status</returns>
        public bool GetSendStatus()
        {
            return sendSuccess;
        }
        /// <summary>
        /// return disconnection status
        /// </summary>
        /// <returns>disconnection status</returns>
        public bool GetDisconnectStatus()
        {
            return disconnectSuccess;
        }
    }
}