<template>
<div id="Chat">
   <div id="ChatBox">
      <div id="chathead" v-on:click="SpanList()">Follows</div>
      <div id="chatbody" v-if="chatshow">
         <div id="username" v-for="(value, index) in chatusers" :key="index" list-style:none>
            <div id="user" v-on:click="SpanBox(index)">
               {{value.UserName}}
            </div>
         </div>
      </div>
   </div>
   <div id="MsgBox" style="right:290px" v-if="msgshow">
      <div id="msghead">
         {{clickeduser}}
      </div>
      <div id="msgbody">
         <textarea id="receives" rows="10" />
      </div>
      <div id="msgfoot">
      <textarea id="messagesent" v-model="messages" v-on:keyup.enter="SendMessage" rows="4" placeholder="Enter the message"></textarea>
      <button id="send" type="submit" @click="SendMessage">Send Message</button><br/>
      </div>
   </div>
</div>
</template>

<script>
import axios from 'axios'
import { setTimeout } from 'timers'

export default {
  name: 'Chats',
  data () {
    return {
      ws: '',
      messages: '',
      onlineUser: '',
      clickeduser: '',
      clickedid: 0,
      chatusers: [],
      chatshow: false,
      msgshow: false,
      ciphertext: null,
      key: [],
      iv: [],
      receivestring: '',
      messageArray: []
    }
  },
  created () {
    // whenever the browser about to close, close webocket connection as well
    document.addEventListener('beforeunload', this.Disconnection)
  },
  mounted () {
    // ask for username when chat webapi gets called and request websocket connection to server
    // this.onlineUser = prompt('Enter your name')
    this.onlineUser = this.$store.getters.getusername
    this.ws = new WebSocket('ws://' + this.$store.getters.getURL + 'v1/chat/connect' + '?username=' + this.onlineUser)
    this.Connection()
  },
  methods: {
    Connection: function () {
      var vm = this
      // get secret key and initial value from server
      vm.GetIV()
      this.ws.onopen = function (event) {
        vm.ReceiveMessage()
      }
    },
    ReceiveMessage: function () {
      var vm = this
      this.ws.onmessage = function (event) {
        try {
          vm.Decryption(event.data)
          // if decryption successed
          // show decypted messaged on the receiver side
          window.document.getElementById('receives').prepend(vm.receivestring + '\n')
        } catch (error) { // server message cannot decrypted, since it is not encypted
          // send message to offline user
          if (event.data === ' ') {
            window.document.getElementById('receives').prepend('User is offline' + '\n')
          }
        }
      }
    },
    SendMessage: function () {
      // check if user is still connected  before send
      if (this.ws.readyState === WebSocket.OPEN) {
        this.Encryption()
        var jmsg = {
          UserName: this.clickeduser,
          MessageContent: this.ciphertext
        }
        this.ws.send(JSON.stringify(jmsg))
        window.document.getElementById('receives').prepend('You said: ' + this.messages)
        // clear the message input area
        this.messages = ''
      }
    },
    // set visability of the messagebox
    SpanBox: function (index) {
      var vm = this
      this.clickeduser = this.chatusers[index].UserName
      this.clickedid = this.chatusers[index].PersonFollowing
      setTimeout(function () {
        vm.CallHistory()
      }, 1000)
      this.msgshow = !this.msgshow
    },
    // show the messages are sent by other users when open the message box
    CallHistory: function () {
      if (this.messageArray != null) {
        // checking username
        var usernamecheck = '"' + this.clickeduser
        for (var x = 0; x < this.messageArray.length; x++) {
          if (usernamecheck === this.messageArray[x][0]) {
            window.document.getElementById('receives').prepend(this.messageArray[x][0] + ':said ' + this.messageArray[x][1])
          }
        }
      }
    },
    SpanList: function () {
      var vm = this
      if (vm.chatshow === false) {
        vm.GetFollows()
        vm.chatshow = !vm.chatshow
      } else {
        vm.chatshow = !vm.chatshow
      }
    },
    Disconnection: function (event) {
      if (this.ws.readyState === WebSocket.OPEN) {
        this.ws.onclose()
      }
    },
    Error: function () {
      this.ws.onerror = function (event) {
        window.document.getElementById('receives').prepend(JSON.parse(event.data) + '\n')
      }
    },
    // AES 128 CBC Encryption
    Encryption: function () {
      // get initial value from server
      var AesJS = require('aes-js')
      // padding message to 16 bytes
      var StringtoBytes = AesJS.utils.utf8.toBytes(this.Padding(this.messages))
      // eslint-disable-next-line
      var AesCBC = new AesJS.ModeOfOperation.cbc(this.key, this.iv)
      var EncryptedBytes = AesCBC.encrypt(StringtoBytes)
      // convert to hex for eaiser transfer
      var EncryptedHex = AesJS.utils.hex.fromBytes(EncryptedBytes)
      this.ciphertext = EncryptedHex
    },
    // AES 128 CBC Decryption
    Decryption: function (data) {
      var AesJS = require('aes-js')
      var res = data.split(' ')
      var hexmessage = res[2]
      var EncryptedBytes = AesJS.utils.hex.toBytes(hexmessage)
      // eslint-disable-next-line
      var AesCBC = new AesJS.ModeOfOperation.cbc(this.key, this.iv)
      var DecryptedBytes = AesCBC.decrypt(EncryptedBytes)
      var Decryptedtext = AesJS.utils.utf8.fromBytes(DecryptedBytes)
      res[2] = Decryptedtext
      // save message in client side when message box closed injection HTML
      this.messageArray.push([res[0], res[2]])
      // prepare message to be show in the message box
      this.receivestring = res.join(' ')
    },
    // padding user's sending message to 16 bytes base
    Padding: function (source) {
      var paddchar = ' '
      var extra = source.length % 16
      if (extra > 0) {
        for (var i = 0; i < 16 - extra; i++) {
          source += paddchar
        }
      }
      return source
    },
    GetFollows: function () {
      var vm = this
      axios({
        method: 'POST',
        url: this.$store.getters.getURL + 'v1/Follows/Getfollows',
        data: {
          'Username': this.$store.getters.getusername
        },
        headers: this.$store.getters.getheader
      })
        // get follows list from response
        .then(response => {
          vm.chatusers = response.data
        }).catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.errorMessage = 'Error: An Error Occurd.'
            this.errorFlag = true
          } else if (error.request) {
            this.errorMessage = 'Error: Server Error'
            this.errorFlag = true
          } else {
            this.errorMessage = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    },
    GetIV: function () {
      var vm = this
      axios({
        method: 'POST',
        url: this.$store.getters.getURL + 'v1/Follows/GetInitialvalue',
        data: {
          'Username': this.$store.getters.getusername
        },
        headers: this.$store.getters.getheader
      })
        // get iv from server
        // apply to encryption key
        .then(response => {
          vm.iv = response.data
          vm.key = response.data
        }).catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.errorMessage = 'Error: An Error Occurd.'
            this.errorFlag = true
          } else if (error.request) {
            this.errorMessage = 'Error: Server Error'
            this.errorFlag = true
          } else {
            this.errorMessage = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    }
  }
}
</script>
<style>
#ChatBox,#MsgBox{
  cursor: pointer;
  background: #307F83;
  width: 150px;
  position: fixed;
  bottom: 0px;
  right: 20px;
  border-radius: 5px 5px 0px 0px;
  border: solid #34495e;
  font-family: sans-serif;
}
#send{
  width: 248px;
  height: 40px;
  background: white;
  border-top: solid grey;
  border-right: solid #34495e;
}
#chathead,#msghead{
  background: #34495E;
  padding: 5px;
  color:white;
  border-radius: 5px 5px 0px 0px;
  text-align: center;
  border: solid #34495E;
  transition: 0.5s;
}
#chathead:hover{
  background: white;
  text-shadow: 0 5px 5px rgba(0,0,0,0.2);
  color: grey;
}
#chatbody{
  height: 300px;
  overflow-y: auto;
}
#msghead{
  background:#34495E;
  border: solid white;
  padding:2px;
}
#msgbody{
  overflow:auto;
  height:100px;
}
#msgclose{
  float:right;
  color:white;
  padding: 3px;
}
#msgfoot{
  width:100%;
  border-top: solid grey;
}
#MsgBox{
  width: 250px;
  height: 250px;
  background: white;
  bottom: -5px;
}
#username{
  padding: 5px 25px;
  position: relative;
  color: white;
  transition: 0.5s;
}
#username:hover{
  background:white;
  text-shadow: 0 5px 5px rgba(0,0,0,0.2);
  color: grey;
}
#username:before{
  border-radius: 50%;
  content:'';
  position:absolute;
  background:#2ecc71;
  width:10px;
  height:10px;
  left:10px;
  top: 12px;
}
#messagesent{
  width: 100%;
  border-color: white;
  border-top: 1px solid #bdc3c7;
}
#receives{
  width: 100%;
}
</style>
