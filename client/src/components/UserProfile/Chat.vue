<template>
<div id="Chat">
   <div id="ChatBox">
      <div id="chathead" v-on:click="chatshow = !chatshow">Friends</div>
      <div id="chatbody" v-if="chatshow">
         <div id="username" v-for="(value, index) in chatusers" :key="index" list-style:none>
            <div id="user" v-on:click="SpanBox(index)">
               {{value}}
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
export default {
  name: 'Chats',
  data () {
    return {
      ws: '',
      messages: '',
      onlineUser: '',
      clickeduser: '',
      chatusers: [],
      chatshow: false,
      msgshow: false,
      ciphertext: null,
      key: [],
      iv: [],
      receivestring: ''
    }
  },
  created () {
    // whenever the browser about to close, close webocket connection as well
    document.addEventListener('beforeunload', this.Disconnection)
  },
  mounted () {
    // ask for username when chat webapi gets called and request websocket connection to server
    this.onlineUser = prompt('Enter your name')
    this.ws = new WebSocket('ws://localhost/server/v1/chat/connect' + '?username=' + this.onlineUser)
    this.Connection()
  },
  watch: {
    // detects online users changes
    chatusers: function () {
      console.log('chatusers changed')
    }
  },
  methods: {
    Connection: function () {
      var vm = this
      this.ws.onopen = function (event) {
        console.log('connected')
        vm.ReceiveMessage()
      }
    },
    ReceiveMessage: function () {
      var vm = this
      this.ws.onmessage = function (event) {
        var newiv = []
        var newkey = []
        // if not first time connected receive message from other user
        if (vm.chatusers.length > 0) {
          console.log('receive')
          try {
            vm.Decryption(event.data)
            // if decryption successed
            // show decypted messaged on the receiver side
            window.document.getElementById('receives').prepend(vm.receivestring + '\n')
          } catch (error) {
            // server message cannot decrypted, since it is not encypted
            // show server message
            window.document.getElementById('receives').prepend('User is offline' + '\n')
          }
        } else { // first time connected, get initial value and secret key from server
          vm.chatusers = JSON.parse(event.data).split(',')
          console.log(vm.chatusers)
          // get iv from first 16 elements
          for (var i = 0; i < 16; i++) {
            newiv.push(window.parseInt(vm.chatusers.pop()))
          }
          console.log(newiv)
          vm.iv = newiv
          // get key from next 16 elements
          for (var j = 0; j < 16; j++) {
            newkey.push(window.parseInt(vm.chatusers.pop()))
          }
          console.log(newkey)
          vm.key = newkey
          // get users
          if (vm.chatusers.includes(vm.onlineUser)) {
            var index = vm.chatusers.indexOf(vm.onlineUser)
            vm.chatusers.splice(index, 1)
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
        console.log('sent')
        this.messages = ''
      }
    },
    // set visability of the messagebox
    SpanBox: function (index) {
      this.clickeduser = this.chatusers[index]
      this.msgshow = !this.msgshow
    },
    Disconnection: function (event) {
      if (this.ws.readyState === WebSocket.OPEN) {
        console.log(event)
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
      console.log('encryption called')
      var AesJS = require('aes-js')
      // padding message to 16 bytes
      var StringtoBytes = AesJS.utils.utf8.toBytes(this.Padding(this.messages))
      // eslint-disable-next-line
      var AesCBC = new AesJS.ModeOfOperation.cbc(this.key, this.iv)
      var EncryptedBytes = AesCBC.encrypt(StringtoBytes)
      // convert to hex for eaiser transfer
      var EncryptedHex = AesJS.utils.hex.fromBytes(EncryptedBytes)
      this.ciphertext = EncryptedHex
      console.log(this.ciphertext)
    },
    // AES 128 CBC Decryption
    Decryption: function (data) {
      var AesJS = require('aes-js')
      console.log('decryption called')
      console.log(data)
      var res = data.split(' ')
      var hexmessage = res[2]
      console.log(hexmessage)
      var EncryptedBytes = AesJS.utils.hex.toBytes(hexmessage)
      // eslint-disable-next-line
      var AesCBC = new AesJS.ModeOfOperation.cbc(this.key, this.iv)
      var DecryptedBytes = AesCBC.decrypt(EncryptedBytes)
      var Decryptedtext = AesJS.utils.utf8.fromBytes(DecryptedBytes)
      res[2] = Decryptedtext
      this.receivestring = res.join(' ')
      console.log(this.receivestring)
    },
    // padding user's sending message to 16 bytes base
    Padding: function (source) {
      var paddchar = ' '
      console.log(source.length)
      var extra = source.length % 16
      console.log(extra)
      if (extra > 0) {
        for (var i = 0; i < 16 - extra; i++) {
          source += paddchar
        }
      }
      console.log(source.length)
      return source
    }
  }
}
</script>
<style>
#ChatBox,#MsgBox{
  cursor: pointer;
  background: grey;
  width: 150px;
  position: fixed;
  bottom: 0px;
  right: 20px;
  border-radius: 5px 5px 0px 0px;
  font-family: sans-serif;
}
#send{
  margin-right: 80%;
  background: #16a085;
}
#chathead,#msghead{
  background: rgb(54, 53, 52);
  padding: 5px;
  color:white;
  border-radius: 5px 5px 0px 0px;
  text-align: center;
}
#chatbody{
  height: 400px;
}
#msghead{
  background:#3498db;
  padding:2px;
}
#msgbody{
  height:200px;
  overflow: auto;
  overflow-y: auto;
}
#msgclose{
  float:right;
  color:white;
  padding: 3px;
}
#msgfoot{
  width:250px;
  color:black;
}
#MsgBox{
  width: 250px;
  height: 350px;
  background: white;
  bottom: -5px;
}
#username{
  background: gray;
  padding: 5px 25px;
  position: relative;
  color: black;
}
#username:hover{
  background:white
}
#username:before{
  content:'';
  position:absolute;
  background:#2ecc71;
  width:10px;
  height:10px;
  left:10px;
  top: 12px;
}
#messagesent{
  border: transparent;
  width:96%;
  border-color: white;
  border-top: 1px solid #bdc3c7;
}
#receives{
  border-color: white;
  width:96%;
}
</style>
